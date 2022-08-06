using log4net;
using PacketDotNet;
using PhotonPackageParser;
using SharpPcap;
using StatisticsAnalysisTool.Common;
using StatisticsAnalysisTool.Network.Manager;
using StatisticsAnalysisTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using Protocol16.Photon;

namespace StatisticsAnalysisTool.Network
{
    public static class NetworkManager
    {
        private static PhotonParser _receiver;
        private static MainWindowViewModel _mainWindowViewModel;
        private static readonly List<ICaptureDevice> CapturedDevices = new();
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        public static bool IsNetworkCaptureRunning => CapturedDevices.Where(device => device.Started).Any(device => device.Started);

        public static bool StartNetworkCapture(MainWindowViewModel mainWindowViewModel, TrackingController trackingController)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _receiver = new AlbionPackageParser(trackingController, mainWindowViewModel);

            try
            {
                CapturedDevices.AddRange(CaptureDeviceList.Instance);
                return StartDeviceCapture();
            }
            catch (Exception e)
            {
                ConsoleManager.WriteLineForError(MethodBase.GetCurrentMethod()?.DeclaringType, e);
                Log.Error(MethodBase.GetCurrentMethod()?.DeclaringType, e);
                _mainWindowViewModel.SetErrorBar(Visibility.Visible, LanguageController.Translation("PACKET_HANDLER_ERROR_MESSAGE"));
                _mainWindowViewModel.StopTracking();
                return false;
            }
        }

        private static bool StartDeviceCapture()
        {
            if (CapturedDevices.Count <= 0)
            {
                return false;
            }

            try
            {
                foreach (var device in CapturedDevices)
                {
                    Debug.Print(device.Name);
                    PacketEvent(device);
                }
            }
            catch (Exception e)
            {
                ConsoleManager.WriteLineForError(MethodBase.GetCurrentMethod()?.DeclaringType, e);
                Log.Error(MethodBase.GetCurrentMethod()?.DeclaringType, e);
                _mainWindowViewModel.SetErrorBar(Visibility.Visible, LanguageController.Translation("PACKET_HANDLER_ERROR_MESSAGE"));
                _mainWindowViewModel.StopTracking();
                return false;
            }

            return true;
        }

        public static void StopNetworkCapture()
        {
            foreach (var device in CapturedDevices.Where(device => device.Started))
            {
                device.StopCapture();
                device.Close();
            }

            CapturedDevices.Clear();
        }

        private static void PacketEvent(ICaptureDevice device)
        {
            if (!device.Started)
            {
                device.Open(new DeviceConfiguration()
                {
                    Mode = DeviceModes.Promiscuous,
                    ReadTimeout = 5000
                });
                device.OnPacketArrival += Device_OnPacketArrival;
                device.StartCapture();
            }
        }

        private static void Device_OnPacketArrival(object sender, PacketCapture e)
        {
            try
            {
                var udpPacket = Packet.ParsePacket(e.GetPacket().LinkLayerType, e.GetPacket().Data).Extract<UdpPacket>();
                var tcpPacket = Packet.ParsePacket(e.GetPacket().LinkLayerType, e.GetPacket().Data).Extract<TcpPacket>();

                if (udpPacket != null && (udpPacket.SourcePort == 5056 || udpPacket.DestinationPort == 5056))
                {
                    _receiver.ReceivePacket(udpPacket.PayloadData);
                }

                if (tcpPacket != null && (tcpPacket.SourcePort == 60598 || tcpPacket.DestinationPort == 6463))
                {
                    _receiver.ReceivePacket(tcpPacket.PayloadData);
                }
            }
            catch (InvalidOperationException ioe)
            {
                ConsoleManager.WriteLineForError(MethodBase.GetCurrentMethod()?.DeclaringType, ioe);
            }
            catch (OverflowException ex)
            {
                ConsoleManager.WriteLineForError(MethodBase.GetCurrentMethod()?.DeclaringType, ex);
            }
            catch (Exception exc)
            {
                ConsoleManager.WriteLineForError(MethodBase.GetCurrentMethod()?.DeclaringType, exc);
                Log.Error(nameof(Device_OnPacketArrival), exc);
            }
        }
    }

    public class ExitLagParser
    {
        private readonly uint[] _raw = new uint[4];

        public uint Version() 
        {
            return _raw[0];
        }

        public void SetVersion(ushort value)
        {
            _raw[0] = value;
        }

        public ulong BodySize()
        {
            return StaticCast(_raw[1]) + (StaticCast(_raw[2]) << 8) + (StaticCast(_raw[3]) << 16);
        }

        public static T StaticCast<T>(T o) => o;

        public void SetBodySize(uint value)
        {
            _raw[1] = (value & 0xFF);
            _raw[2] = ((value >> 8) & 0xFF);
            _raw[3] = ((value >> 16) & 0xFF);
        }
    }
}



//EXITLAG_CORE_PACKED_STRUCT_BEGIN(PacketHeader) {
//    std::array < uint8_t, 4 > raw;
//    uint8_t version() const noexcept{
//        return raw[0];
//    }
//    void set_version(uint8_t value) noexcept {
//        raw[0] = value;
//    }
//    uint32_t body_size() const noexcept {
//        return static_cast<uint32_t>(raw[1])
//               + (static_cast<uint32_t>(raw[2]) << 8) +
//               +(static_cast<uint32_t>(raw[3]) << 16);
//    }
//    void set_body_size(uint32_t value)
//    {
//        raw[1] = value & 0xFF;
//        raw[2] = (value >> 8) & 0xFF;
//        raw[3] = (value >> 16) & 0xFF;
//    }
//}

//EXITLAG_CORE_PACKED_STRUCT_END;
//2.Struct of a field:
////  1. Attributes (1 byte):
////   [0..1] - size of field ID, in bytes
////   [2..3] - size of field "size", in bytes
////  2. ID (1-3 bytes)
////  3. [optional] Remainig data size (1-3 bytes)
////  4. [optional] Payload (any size)