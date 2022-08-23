using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using StatisticsAnalysisTool.Avalonia.Common;
using StatisticsAnalysisTool.Avalonia.Controls;
using System;
using Application = System.Windows.Application;

// ReSharper disable UnusedParameter.Local
// ReSharper disable UnusedMember.Local

namespace StatisticsAnalysisTool.Avalonia.Views
{
    public class MainWindow : Window
    {
        private static bool _isWindowMaximized;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void TitleBar_OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            if (e.GetCurrentPoint(null).Properties.PointerUpdateKind == PointerUpdateKind.LeftButtonPressed)
            {
                PlatformImpl?.BeginMoveDrag(e);
            }
        }

        private void MainWindow_OnOpened(object? sender, EventArgs e)
        {
            if (DataContext is ICloseWindow vm)
            {
                vm.Close += Close;
            }
        }

        private void Hotbar_OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            if (e.GetCurrentPoint(null).Properties.PointerUpdateKind == PointerUpdateKind.LeftButtonPressed)
            {
                PlatformImpl?.BeginMoveDrag(e);
                return;
            }

            switch (e.ClickCount)
            {
                case 2 when WindowState == WindowState.Normal:
                    SwitchState();
                    _isWindowMaximized = true;
                    return;
                case 2 when WindowState == WindowState.Maximized:
                    SwitchState();
                    //Utilities.CenterWindowOnScreen(this);
                    _isWindowMaximized = false;
                    break;
            }
        }
        
        private void SwitchState()
        {
            WindowState = WindowState switch
            {
                WindowState.Normal => WindowState.Maximized,
                WindowState.Maximized => WindowState.Normal,
                _ => WindowState
            };
        }
    }
}
