using log4net;
using StatisticsAnalysisTool.Avalonia.Models;
using StatisticsAnalysisTool.Avalonia.Settings;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Xml.Linq;

namespace StatisticsAnalysisTool.Avalonia.Common
{
    public class LanguageController
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        private static readonly Dictionary<string, string> Translations = new();
        private static CultureInfo? _currentCultureInfo;
        public static List<FileInformation>? LanguageFiles { get; set; }

        #region Culture

        public static CultureInfo? CurrentCultureInfo
        {
            get => _currentCultureInfo;
            set
            {
                _currentCultureInfo = value;
                SettingsController.CurrentUserSettings.CurrentLanguageCultureName = value?.TextInfo.CultureName ?? ApplicationSettings.DefaultLanguageCultureName;
                try
                {
                    Thread.CurrentThread.CurrentUICulture = value!;
                }
                catch (Exception e)
                {
                    Log.Error(MethodBase.GetCurrentMethod()?.DeclaringType, e);
                }
            }
        }

        #endregion

        #region Language

        public static bool InitializeLanguage()
        {
            try
            {
                if (CurrentCultureInfo == null)
                {
                    if (!string.IsNullOrEmpty(SettingsController.CurrentUserSettings.CurrentLanguageCultureName))
                    {
                        CurrentCultureInfo = new CultureInfo(SettingsController.CurrentUserSettings.CurrentLanguageCultureName);
                    }
                    else if (!string.IsNullOrEmpty(ApplicationSettings.DefaultLanguageCultureName))
                    {
                        CurrentCultureInfo = new CultureInfo(ApplicationSettings.DefaultLanguageCultureName);
                    }
                    else
                    {
                        throw new CultureNotFoundException();
                    }
                }

                if (SetLanguage())
                {
                    return true;
                }

                CurrentCultureInfo = new CultureInfo(ApplicationSettings.DefaultLanguageCultureName);
                if (SetLanguage())
                {
                    return true;
                }

                throw new CultureNotFoundException();
            }
            catch (CultureNotFoundException)
            {
                Log.Error(MethodBase.GetCurrentMethod()?.DeclaringType, new CultureNotFoundException());
                //MessageBox.Show("No culture info found!", Translation("ERROR"), MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }

        public static string Translation(string key)
        {
            try
            {
                if (Translations.TryGetValue(key, out var value)) return !string.IsNullOrEmpty(value) ? value : key;
            }
            catch (ArgumentNullException)
            {
                return "TRANSLATION-ERROR";
            }

            return key;
        }

        public static bool SetLanguage()
        {
            LoadLocalLanguageFiles();

            try
            {
                if (LanguageFiles == null)
                {
                    throw new FileNotFoundException();
                }

                var fileInfos = (from file in LanguageFiles
                                 where string.Equals(file.FileName, CurrentCultureInfo?.TextInfo.CultureName, StringComparison.CurrentCultureIgnoreCase)
                                 select new FileInformation(file.FileName, file.FilePath)).FirstOrDefault();

                return fileInfos != null && LoadTranslationsInDirectory(fileInfos.FilePath, Translations);
            }
            catch (ArgumentNullException e)
            {
                //MessageBox.Show(e.Message, Translation("ERROR"));
                //ConsoleManager.WriteLineForError(MethodBase.GetCurrentMethod()?.DeclaringType, e);
                Log.Error(MethodBase.GetCurrentMethod()?.DeclaringType, e);
                return false;
            }
            catch (FileNotFoundException ex)
            {
                //MessageBox.Show("Language file not found. ", Translation("ERROR"), MessageBoxButton.OK, MessageBoxImage.Error);
                //ConsoleManager.WriteLineForError(MethodBase.GetCurrentMethod()?.DeclaringType, ex);
                Log.Error(MethodBase.GetCurrentMethod()?.DeclaringType, ex);
                return false;
            }
        }

        private static bool LoadTranslationsInDirectory(string filePath, IDictionary<string, string> translations)
        {
            try
            {
                var xDoc = XDocument.Load(filePath);
                foreach (var node in xDoc.Descendants("translation"))
                {
                    if (!node.HasAttributes)
                    {
                        continue;
                    }

                    if (translations.ContainsKey(node.Value))
                    {
                        Log.Warn($"{nameof(LoadTranslationsInDirectory)}: {Translation("DOUBLE_VALUE_EXISTS_IN_THE_LANGUAGE_FILE")}: {node.Value}");
                        continue;
                    }

                    var attributeName = node.Attribute("name")?.Value;
                    if (!string.IsNullOrEmpty(attributeName))
                    {
                        translations.Add(attributeName, node.Value);
                    }
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, Translation("ERROR"));
                //ConsoleManager.WriteLineForError(MethodBase.GetCurrentMethod()?.DeclaringType, e);
                Log.Error(MethodBase.GetCurrentMethod()?.DeclaringType, e);
                return false;
            }

            return true;
        }

        private static void LoadLocalLanguageFiles()
        {
            if (LanguageFiles != null)
            {
                return;
            }

            var languageFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ApplicationSettings.LanguageDirectoryName);
            if (!Directory.Exists(languageFilePath))
            {
                return;
            }

            try
            {
                var files = Directory.GetFiles(languageFilePath, "*.xml");
                if (files.Length <= 0)
                {
                    return;
                }

                LanguageFiles ??= new List<FileInformation>();

                foreach (var file in files)
                {
                    var fileInfo = new FileInformation(Path.GetFileNameWithoutExtension(file), file);
                    LanguageFiles.Add(fileInfo);
                }
            }
            catch (Exception e)
            {
                Log.Error(MethodBase.GetCurrentMethod()?.DeclaringType, e);
            }
        }

        #endregion
    }
}