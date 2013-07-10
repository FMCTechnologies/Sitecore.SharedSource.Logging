using System;
using System.Diagnostics;

namespace Sitecore.SharedSource.Logging
{
    public static class ExceptionExtensions
    {
        public static void LogAudit(this Exception ex, string message = null, ParameterDictionary parameters = null, ILogRepository log = null)
        {
            if (log == null) log = new SitecoreLogRepository();

            var callingMethod = new StackFrame(1).GetMethod();
            var typeName = callingMethod.DeclaringType != null ? callingMethod.DeclaringType.FullName : string.Empty;
            log.Audit(callingMethod.DeclaringType != null ? callingMethod.DeclaringType.FullName : callingMethod.Name, "{0}.{1}{2}:{3}{4}", new[] { typeName, callingMethod.Name, parameters.GetString(), Log.GetMessage(message, " - "), Log.GetExceptionMessage(ex) });            
        }

        public static void LogDebug(this Exception ex, string message = null, ParameterDictionary parameters = null, ILogRepository log = null)
        {
            if (log == null) log = new SitecoreLogRepository();

            var callingMethod = new StackFrame(1).GetMethod();
            var typeName = callingMethod.DeclaringType != null ? callingMethod.DeclaringType.FullName : string.Empty;
            log.Audit(callingMethod.DeclaringType != null ? callingMethod.DeclaringType.FullName : callingMethod.Name, "{0}.{1}{2}:{3}{4}", new[] { typeName, callingMethod.Name, parameters.GetString(), Log.GetMessage(message, " - "), Log.GetExceptionMessage(ex) });
        }

        public static void LogError(this Exception ex, string message = null, ParameterDictionary parameters = null, ILogRepository log = null)
        {
            if (log == null) log = new SitecoreLogRepository();

            //need ex.StackTrace?
            var callingMethod = new StackFrame(1).GetMethod();
            log.Error(string.Format("{0}.{1}{2}:{3}{4}", callingMethod.DeclaringType, callingMethod.Name, parameters.GetString(), Log.GetMessage(message, " - "), Log.GetExceptionMessage(ex)), ex, callingMethod.DeclaringType);
        }

        public static void LogFatal(this Exception ex, string message = null, ParameterDictionary parameters = null, ILogRepository log = null)
        {
            if (log == null) log = new SitecoreLogRepository();

            var callingMethod = new StackFrame(1).GetMethod();
            log.Fatal(string.Format("{0}.{1}{2}:{3}{4}", callingMethod.DeclaringType, callingMethod.Name, parameters.GetString(), Log.GetMessage(message, " - "), Log.GetExceptionMessage(ex)), ex, callingMethod.DeclaringType);
        }

        public static void LogWarn(this Exception ex, string message = null, ParameterDictionary parameters = null, ILogRepository log = null)
        {
            if (log == null) log = new SitecoreLogRepository();

            var callingMethod = new StackFrame(1).GetMethod();
            log.Warn(string.Format("{0}.{1}{2}:{3}{4}", callingMethod.DeclaringType, callingMethod.Name, parameters.GetString(), Log.GetMessage(message, " - "), Log.GetExceptionMessage(ex)), ex, callingMethod.DeclaringType);
        }
    }
}
