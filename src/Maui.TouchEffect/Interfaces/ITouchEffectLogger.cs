using System;

namespace Maui.TouchEffect.Interfaces;

/// <summary>
/// Interface for logging TouchEffect events and errors.
/// </summary>
public interface ITouchEffectLogger
{
    /// <summary>
    /// Logs an error with exception details.
    /// </summary>
    /// <param name="exception">The exception that occurred.</param>
    /// <param name="context">Context information about where the error occurred.</param>
    /// <param name="additionalInfo">Optional additional information.</param>
    void LogError(Exception exception, string context, string? additionalInfo = null);

    /// <summary>
    /// Logs a warning message.
    /// </summary>
    /// <param name="message">The warning message.</param>
    /// <param name="context">Context information about the warning.</param>
    void LogWarning(string message, string context);

    /// <summary>
    /// Logs an informational message.
    /// </summary>
    /// <param name="message">The information message.</param>
    /// <param name="context">Context information.</param>
    void LogInformation(string message, string context);

    /// <summary>
    /// Logs debug information (only in debug builds).
    /// </summary>
    /// <param name="message">The debug message.</param>
    /// <param name="context">Context information.</param>
    void LogDebug(string message, string context);

    /// <summary>
    /// Logs performance metrics.
    /// </summary>
    /// <param name="operationName">Name of the operation being measured.</param>
    /// <param name="elapsedMilliseconds">Time taken in milliseconds.</param>
    /// <param name="additionalMetrics">Optional additional metrics.</param>
    void LogPerformance(string operationName, double elapsedMilliseconds, Dictionary<string, object>? additionalMetrics = null);
}

/// <summary>
/// Default implementation of ITouchEffectLogger that uses System.Diagnostics.
/// </summary>
public class DefaultTouchEffectLogger : ITouchEffectLogger
{
    private readonly bool _enableDebugLogging;
    private readonly bool _enablePerformanceLogging;

    /// <summary>
    /// Creates a new instance of the default logger.
    /// </summary>
    /// <param name="enableDebugLogging">Whether to enable debug logging.</param>
    /// <param name="enablePerformanceLogging">Whether to enable performance logging.</param>
    public DefaultTouchEffectLogger(bool enableDebugLogging = false, bool enablePerformanceLogging = false)
    {
        _enableDebugLogging = enableDebugLogging;
        _enablePerformanceLogging = enablePerformanceLogging;
    }

    /// <inheritdoc/>
    public void LogError(Exception exception, string context, string? additionalInfo = null)
    {
        var message = $"[TouchEffect ERROR] {context}: {exception.Message}";
        if (!string.IsNullOrEmpty(additionalInfo))
        {
            message += $" | Additional Info: {additionalInfo}";
        }

        System.Diagnostics.Debug.WriteLine(message);
        System.Diagnostics.Debug.WriteLine($"Stack Trace: {exception.StackTrace}");

        // In production, you might want to send this to a crash reporting service
#if !DEBUG
        // Example: AppCenter, Sentry, Application Insights, etc.
        // CrashReporting.TrackError(exception, new Dictionary<string, string> { { "Context", context } });
#endif
    }

    /// <inheritdoc/>
    public void LogWarning(string message, string context)
    {
        System.Diagnostics.Debug.WriteLine($"[TouchEffect WARNING] {context}: {message}");
    }

    /// <inheritdoc/>
    public void LogInformation(string message, string context)
    {
        System.Diagnostics.Debug.WriteLine($"[TouchEffect INFO] {context}: {message}");
    }

    /// <inheritdoc/>
    public void LogDebug(string message, string context)
    {
#if DEBUG
        if (_enableDebugLogging)
        {
            System.Diagnostics.Debug.WriteLine($"[TouchEffect DEBUG] {context}: {message}");
        }
#endif
    }

    /// <inheritdoc/>
    public void LogPerformance(string operationName, double elapsedMilliseconds, Dictionary<string, object>? additionalMetrics = null)
    {
        if (!_enablePerformanceLogging)
            return;

        var message = $"[TouchEffect PERF] {operationName}: {elapsedMilliseconds:F2}ms";

        if (additionalMetrics != null)
        {
            var metrics = string.Join(", ", additionalMetrics.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            message += $" | Metrics: {metrics}";
        }

        System.Diagnostics.Debug.WriteLine(message);

        // In production, you might want to send this to analytics
#if !DEBUG
        // Example: Application Insights, Google Analytics, etc.
        // Analytics.TrackMetric(operationName, elapsedMilliseconds, additionalMetrics);
#endif
    }
}

/// <summary>
/// Null logger implementation for when logging is disabled.
/// </summary>
public class NullTouchEffectLogger : ITouchEffectLogger
{
    /// <summary>
    /// Gets the singleton instance of the null logger.
    /// </summary>
    public static NullTouchEffectLogger Instance { get; } = new NullTouchEffectLogger();

    private NullTouchEffectLogger() { }

    public void LogError(Exception exception, string context, string? additionalInfo = null) { }
    public void LogWarning(string message, string context) { }
    public void LogInformation(string message, string context) { }
    public void LogDebug(string message, string context) { }
    public void LogPerformance(string operationName, double elapsedMilliseconds, Dictionary<string, object>? additionalMetrics = null) { }
}