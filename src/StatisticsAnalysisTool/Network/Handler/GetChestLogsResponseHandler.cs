using StatisticsAnalysisTool.Network.Manager;
using StatisticsAnalysisTool.Network.Operations.Responses;
using System.Threading.Tasks;

namespace StatisticsAnalysisTool.Network.Handler
{
    public class GetChestLogsResponseHandler
    {
        private readonly TrackingController _trackingController;

        public GetChestLogsResponseHandler(TrackingController trackingController)
        {
            _trackingController = trackingController;
        }

        public async Task OnActionAsync(GetChestLogsResponse value)
        {
            await Task.CompletedTask;
        }
    }
}