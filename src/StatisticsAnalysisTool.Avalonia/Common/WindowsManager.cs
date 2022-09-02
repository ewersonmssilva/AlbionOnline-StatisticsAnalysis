using Avalonia.Controls;
using System.Collections.Generic;
using System.Linq;

namespace StatisticsAnalysisTool.Avalonia.Common;

public class WindowsManager
{
    public static List<Window> AllWindows = new();

    public static T? GetWindow<T>() where T : class
    {
        var typeParameterType = typeof(T);
        var window = AllWindows.FirstOrDefault(x => x.GetType() == typeParameterType);

        if (window?.GetType() == typeParameterType)
        {
            return window as T;
        }

        return null;
    }
}