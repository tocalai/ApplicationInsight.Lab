using Microsoft.ApplicationInsights;
using System;

namespace Application.Insights
{
    public class AzureMonitorManager
    {
        private readonly TelemetryClient _telemetryClient;

        public AzureMonitorManager(TelemetryClient TelemetryClient)
        {
            _telemetryClient = TelemetryClient;
        }

        public void ThrowException(Exception ex)
        {
            _telemetryClient.TrackException(ex);
        }

        public void ThrowMessageTrace(string title, string message)
        {
            _telemetryClient.TrackTrace($"{title}, {message}");
        }
    }
}
