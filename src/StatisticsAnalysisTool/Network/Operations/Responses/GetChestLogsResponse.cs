using log4net;
using StatisticsAnalysisTool.Common;
using StatisticsAnalysisTool.Models.NetworkModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace StatisticsAnalysisTool.Network.Operations.Responses
{
    public class GetChestLogsResponse
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        public List<ChestLogObject> ChestLog = new();

        public GetChestLogsResponse(Dictionary<byte, object> parameters)
        {
            ConsoleManager.WriteLineForNetworkHandler(GetType().Name, parameters);

            ChestLog.Clear();

            try
            {
                if (!parameters[0].GetType().IsArray || typeof(string[]).Name != parameters[0].GetType().Name
                    && !parameters[1].GetType().IsArray || typeof(short[]).Name != parameters[1].GetType().Name
                    && !parameters[3].GetType().IsArray || typeof(short[]).Name != parameters[3].GetType().Name
                    && !parameters[4].GetType().IsArray || typeof(long[]).Name != parameters[4].GetType().Name)
                {
                    return;
                }

                var names = ((string[])parameters[0]).ToArray();
                var itemIds = parameters[1].ToIntArray();
                var quantities = parameters[3].ToIntArray();
                var timestamps = parameters[4].ToLongArray();

                var length = Utilities.GetHighestLength(names, itemIds, quantities, timestamps);

                for (var i = 0; i < length; i++)
                {
                    var name = names[i];
                    var itemId = itemIds[i];
                    var quantity = quantities[i];
                    var timestamp = timestamps[i];

                    ChestLog.Add(new ChestLogObject(name, itemId, quantity, timestamp));
                }
            }
            catch (Exception e)
            {
                Log.Error(nameof(GetMailInfosResponse), e);
            }
        }
    }
}