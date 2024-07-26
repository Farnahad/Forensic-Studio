using System.Diagnostics;
using ForensicStudio.Core.Main.Method;
using ForensicStudio.Logic.Windows.Model;

namespace ForensicStudio.Logic.Windows.Extractor;

// FORENSIC
public class SystemResourceMonitoringExtractor
{
    public MethodResult<SystemResourceMonitoring> GetSystemResourceMonitorings()
    {
        var category = "Processor";
        var counterName = "% Processor Time";

        return GetSystemResourceMonitorings(category, counterName);
    }

    public MethodResult<SystemResourceMonitoring> GetSystemResourceMonitorings(string category, string counterName)
    {
        var systemResourceMonitoring = new SystemResourceMonitoring();

        try
        {
            var performanceCounter = new PerformanceCounter(category, counterName, "_Total");

            var counterValue = performanceCounter.NextValue();

            systemResourceMonitoring.Category = category;
            systemResourceMonitoring.CounterName = counterName;
            systemResourceMonitoring.CounterValue = counterValue;

        }
        catch (Exception exception)
        {
            return new MethodResult<SystemResourceMonitoring>(exception);
        }

        return new MethodResult<SystemResourceMonitoring>(systemResourceMonitoring);
    }
}