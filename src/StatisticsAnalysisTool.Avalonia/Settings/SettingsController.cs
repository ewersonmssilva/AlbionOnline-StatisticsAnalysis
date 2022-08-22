using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Avalonia.Controls;
using log4net;
using StatisticsAnalysisTool.Avalonia.Common;

namespace StatisticsAnalysisTool.Avalonia.Settings;

public static class SettingsController
{
    public static UserSettings CurrentUserSettings = new();

    private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
    private static bool _haveSettingsAlreadyBeenLoaded;

    public static void SaveSettings(WindowState windowState, double height, double width)
    {
        #region Window

        if (windowState != WindowState.Maximized)
        {
            CurrentUserSettings.MainWindowHeight = double.IsNegativeInfinity(height) || double.IsPositiveInfinity(height) ? 0 : height;
            CurrentUserSettings.MainWindowWidth = double.IsNegativeInfinity(width) || double.IsPositiveInfinity(width) ? 0 : width;
        }

        CurrentUserSettings.MainWindowMaximized = windowState == WindowState.Maximized;

        #endregion

        SaveToLocalFile();

        ItemController.SaveFavoriteItemsToLocalFile();
    }

    public static void LoadSettings()
    {
        if (_haveSettingsAlreadyBeenLoaded)
        {
            return;
        }

        var localFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}{ApplicationSettings.SettingsFileName}";

        if (File.Exists(localFilePath))
        {
            try
            {
                var settingsString = File.ReadAllText(localFilePath, Encoding.UTF8);
                CurrentUserSettings = JsonSerializer.Deserialize<UserSettings>(settingsString) ?? throw new ArgumentNullException();
                _haveSettingsAlreadyBeenLoaded = true;
            }
            catch (Exception e)
            {
                ConsoleManager.WriteLineForError(MethodBase.GetCurrentMethod()?.DeclaringType, e);
                Log.Error(MethodBase.GetCurrentMethod()?.DeclaringType, e);
            }
        }
    }

    private static void SaveToLocalFile()
    {
        var localFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}{ApplicationSettings.SettingsFileName}";

        try
        {
            var fileString = JsonSerializer.Serialize(CurrentUserSettings);
            File.WriteAllText(localFilePath, fileString, Encoding.UTF8);
        }
        catch (Exception e)
        {
            ConsoleManager.WriteLineForError(MethodBase.GetCurrentMethod()?.DeclaringType, e);
            Log.Error(MethodBase.GetCurrentMethod()?.DeclaringType, e);
        }
    }
}