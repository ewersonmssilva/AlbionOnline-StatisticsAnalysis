﻿using System;
using System.Collections.Generic;
using System.Reflection;
using log4net;
using StatisticsAnalysisTool.Common;

namespace StatisticsAnalysisTool.Network.Operations;

public class FishingStartRequest
{
    private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
    public readonly long EventId;
    public readonly int ItemIndex;

    public FishingStartRequest(Dictionary<byte, object> parameters)
    {
        ConsoleManager.WriteLineForNetworkHandler(GetType().Name, parameters);

        try
        {
            if (parameters.TryGetValue(0, out object objectId))
            {
                EventId = objectId.ObjectToLong() ?? -1;
            }

            if (parameters.TryGetValue(2, out object itemIndex))
            {
                ItemIndex = itemIndex.ObjectToInt();
            }
        }
        catch (Exception e)
        {
            ConsoleManager.WriteLineForError(MethodBase.GetCurrentMethod()?.DeclaringType, e);
            Log.Error(MethodBase.GetCurrentMethod()?.DeclaringType, e);
        }
    }
}