using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using System;

namespace Application.Insights
{
    public class CustomTelemetryInitializer : ITelemetryInitializer
    {
        private string ApplicationVersion { get; }
        private string ApplicationName { get; }

        public CustomTelemetryInitializer(string version, string name)
        {
            ApplicationVersion = version;
            ApplicationName = name;
        }

        public void Initialize(ITelemetry telemetry)
        {
            telemetry.Context.User.Id = Environment.UserName;
            telemetry.Context.Session.Id = Guid.NewGuid().ToString();
            telemetry.Context.Device.Id = Environment.MachineName;
            telemetry.Context.Device.OperatingSystem = Environment.OSVersion.ToString();
            telemetry.Context.GlobalProperties.Add("Application Name", ApplicationName);
            telemetry.Context.GlobalProperties.Add("Application Ver.", ApplicationVersion);
        }
    }
}
