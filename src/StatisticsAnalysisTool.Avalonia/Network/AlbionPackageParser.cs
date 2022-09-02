using log4net;
using PhotonPackageParser;
using StatisticsAnalysisTool.Avalonia.Enumerations;
using StatisticsAnalysisTool.Avalonia.Network.Handler;
using StatisticsAnalysisTool.Avalonia.Network.Manager;
using StatisticsAnalysisTool.Avalonia.Network.Operations.Responses;
using StatisticsAnalysisTool.Avalonia.ViewModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace StatisticsAnalysisTool.Avalonia.Network;

public class AlbionPackageParser : PhotonParser
{
    private readonly JoinResponseHandler _joinResponseHandler;

    private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

    public AlbionPackageParser(TrackingController trackingController, MainWindowViewModel mainWindowViewModel)
    {
        _joinResponseHandler = new JoinResponseHandler(trackingController, mainWindowViewModel);
    }

    #region Actions

    protected override void OnEvent(byte code, Dictionary<byte, object> parameters)
    {
        throw new NotImplementedException();
    }

    protected override void OnRequest(byte operationCode, Dictionary<byte, object> parameters)
    {
        throw new NotImplementedException();
    }

    protected override void OnResponse(byte operationCode, short returnCode, string debugMessage, Dictionary<byte, object> parameters)
    {
        var opCode = ParseOperationCode(parameters);

        if (opCode == OperationCodes.Unused)
        {
            return;
        }

        Task.Run(async () =>
        {
            switch (opCode)
            {
                case OperationCodes.Join:
                    await JoinResponseHandlerAsync(parameters);
                    return;
            }
        });
    }

    #endregion

    #region Code Parser

    private static EventCodes ParseEventCode(IReadOnlyDictionary<byte, object> parameters)
    {
        if (!parameters.TryGetValue(252, out var value))
        {
            return EventCodes.Unused;
        }

        return (EventCodes)Enum.ToObject(typeof(EventCodes), value);
    }

    private OperationCodes ParseOperationCode(IReadOnlyDictionary<byte, object> parameters)
    {
        if (!parameters.TryGetValue(253, out var value))
        {
            return OperationCodes.Unused;
        }

        return (OperationCodes)Enum.ToObject(typeof(OperationCodes), value);
    }

    #endregion

    #region Handler

    #region Response

    private async Task JoinResponseHandlerAsync(Dictionary<byte, object> parameters)
    {
        var value = new JoinResponse(parameters);
        await _joinResponseHandler.OnActionAsync(value);
    }

    #endregion

    #endregion
}