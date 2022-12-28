
/// <summary>
/// log调试
/// </summary>
public static class GameDebug
{
    /// <summary>
    /// 记录调试级别日志，仅在带有 GAME_DEBUG 预编译选项时产生。
    /// </summary>
    [System.Diagnostics.Conditional("GAME_DEBUG")]
    public static void Log(object message)
    {
        UnityEngine.Debug.Log(message);
    }

    /// <summary>
    /// 记录调试级别日志，仅在带有 GAME_DEBUG 预编译选项时产生。
    /// </summary>
    [System.Diagnostics.Conditional("GAME_DEBUG")]
    public static void Log(object message, UnityEngine.Object context)
    {
        UnityEngine.Debug.Log(message, context);
    }

    /// <summary>
    /// 记录调试级别日志，仅在带有 GAME_DEBUG 预编译选项时产生。
    /// </summary>
    [System.Diagnostics.Conditional("GAME_DEBUG")]
    public static void LogFormat(string format, params object[] args)
    {
        UnityEngine.Debug.LogFormat(format, args);
    }

    /// <summary>
    /// 记录调试级别日志，仅在带有 GAME_DEBUG 预编译选项时产生。
    /// </summary>
    [System.Diagnostics.Conditional("GAME_DEBUG")]
    public static void LogFormat(UnityEngine.Object context, string format, params object[] args)
    {
        UnityEngine.Debug.LogFormat(context, format, args);
    }

    /// <summary>
    /// 打印信息级别日志，用于记录程序正常运行日志信息。
    /// </summary>
    public static void Info(object message)
    {
        UnityEngine.Debug.Log(message);
    }

    /// <summary>
    /// 打印信息级别日志，用于记录程序正常运行日志信息。
    /// </summary>
    public static void Info(object message, UnityEngine.Object context)
    {
        UnityEngine.Debug.Log(message, context);
    }

    /// <summary>
    /// 打印信息级别日志，用于记录程序正常运行日志信息。
    /// </summary>
    public static void InfoFormat(string format, params object[] args)
    {
        UnityEngine.Debug.LogFormat(format, args);
    }

    /// <summary>
    /// 打印信息级别日志，用于记录程序正常运行日志信息。
    /// </summary>
    public static void InfoFormat(UnityEngine.Object context, string format, params object[] args)
    {
        UnityEngine.Debug.LogFormat(context, format, args);
    }

    /// <summary>
    /// 打印警告级别日志，建议在发生局部功能逻辑错误，但尚不会导致游戏崩溃或异常时使用。
    /// </summary>
    public static void LogWarning(object message)
    {
        UnityEngine.Debug.LogWarning(message);
    }

    /// <summary>
    /// 打印警告级别日志，建议在发生局部功能逻辑错误，但尚不会导致游戏崩溃或异常时使用。
    /// </summary>
    public static void LogWarning(object message, UnityEngine.Object context)
    {
        UnityEngine.Debug.LogWarning(message, context);
    }

    /// <summary>
    /// 打印警告级别日志，建议在发生局部功能逻辑错误，但尚不会导致游戏崩溃或异常时使用。
    /// </summary>
    public static void LogWarningFormat(string format, params object[] args)
    {
        UnityEngine.Debug.LogWarningFormat(format, args);
    }

    /// <summary>
    /// 打印警告级别日志，建议在发生局部功能逻辑错误，但尚不会导致游戏崩溃或异常时使用。
    /// </summary>
    public static void LogWarningFormat(UnityEngine.Object context, string format, params object[] args)
    {
        UnityEngine.Debug.LogWarningFormat(context, format, args);
    }

    /// <summary>
    /// 打印错误级别日志，建议在发生功能逻辑错误，但尚不会导致游戏崩溃或异常时使用。
    /// </summary>
    /// <param name="message">日志内容。</param>
    public static void LogError(object message)
    {
        UnityEngine.Debug.LogError(message);
    }

    /// <summary>
    /// 打印错误级别日志，建议在发生功能逻辑错误，但尚不会导致游戏崩溃或异常时使用。
    /// </summary>
    /// <param name="message">日志内容。</param>
    public static void LogError(object message, UnityEngine.Object context)
    {
        UnityEngine.Debug.LogError(message, context);
    }

    /// <summary>
    /// 打印错误级别日志，建议在发生功能逻辑错误，但尚不会导致游戏崩溃或异常时使用。
    /// </summary>
    public static void LogErrorFormat(string format, params object[] args)
    {
        UnityEngine.Debug.LogErrorFormat(format, args);
    }

    /// <summary>
    /// 打印错误级别日志，建议在发生功能逻辑错误，但尚不会导致游戏崩溃或异常时使用。
    /// </summary>
    public static void LogErrorFormat(UnityEngine.Object context, string format, params object[] args)
    {
        UnityEngine.Debug.LogErrorFormat(context, format, args);
    }

    /// <summary>
    /// 打印异常级别日志，建议在发生严重错误，可能导致游戏崩溃或异常时使用，此时应尝试重启进程或重建游戏。
    /// </summary>
    public static void LogException(string exception)
    {
        LogException(new System.Exception(exception));
    }

    /// <summary>
    /// 打印异常级别日志，建议在发生严重错误，可能导致游戏崩溃或异常时使用，此时应尝试重启进程或重建游戏。
    /// </summary>
    public static void LogException(System.Exception exception)
    {
        UnityEngine.Debug.LogException(exception);
    }

    /// <summary>
    /// 打印异常级别日志，建议在发生严重错误，可能导致游戏崩溃或异常时使用，此时应尝试重启进程或重建游戏。
    /// </summary>
    public static void LogException(System.Exception exception, UnityEngine.Object context)
    {
        UnityEngine.Debug.LogException(exception, context);
    }
}