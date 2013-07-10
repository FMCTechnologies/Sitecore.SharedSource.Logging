using System;
using System.Diagnostics;
using System.Text;

namespace Sitecore.SharedSource.Logging
{
    public static class Log
    {
        public enum Levels
        {
            Trace,
            Debug,
            Audit,
            Info,
            Warning,
            Error,
            Fatal
        }

        /// <summary>  Logs a message using either error or debug level if Msg is set </summary>
        /// <param name="message"></param>
        /// <param name="owner"></param>
        /// <param name="minimumLevel"></param>
        /// <param name="isError">Flag to set Log Level to Error. If not true, log level will be debug</param>
        /// <param name="log"></param>
        public static void LogMsg(string message, object owner = null, bool isError = false, Levels minimumLevel = Levels.Debug, ILogRepository log = null)
        {
            if (log == null) log = new SitecoreLogRepository();
            var callingMethod = new StackFrame(1).GetMethod();
            var type = callingMethod.DeclaringType;
            var typeName = type != null ? type.FullName : string.Empty;
            if (owner == null && type != null && !type.IsAbstract) owner = Activator.CreateInstance(type);
            if (owner == null && type != null) owner = type;
            var logLevel = isError ? Levels.Error : Levels.Debug;
            if (message != null) LogMsg(message, owner ?? typeName, logLevel, minimumLevel, log);
        }

        public static void LogMsg(string message, object owner = null, Levels level = Levels.Debug, Levels minimumLevel = Levels.Debug, ILogRepository log = null)  //0 = off; 1 = Low; 2 = Med; 3 = Verbose
        {
            if (log == null) log = new SitecoreLogRepository();
            var callingMethod = new StackFrame(1).GetMethod();
            var type = callingMethod.DeclaringType;
            var typeName = type != null ? type.FullName : string.Empty;
            if (owner == null && type != null && !type.IsAbstract) owner = Activator.CreateInstance(type);
            if (owner == null && type != null) owner = type;
            try
            {
                if (level >= Levels.Error || (int)minimumLevel >= 3)
                    LogByLevel(message, owner ?? typeName, level);
                else if ((int)minimumLevel == 2 & level >= Levels.Warning)
                    LogByLevel(message, owner ?? typeName, level);
            }
            catch (Exception ex)
            {
                LogByLevel(string.Format("Unable to use LogMsg to log message {0}\n Error:{1}", message, ex), owner ?? typeName, Levels.Error, ex, log);
            }
        }

        public static void LogByLevel(string message, object owner = null, Levels level = Levels.Debug, Exception exception = null, ILogRepository log = null)
        {
            if (log == null) log = new SitecoreLogRepository();
            var callingMethod = new StackFrame(1).GetMethod();
            var type = callingMethod.DeclaringType;
            var typeName = type != null ? type.FullName : string.Empty;
            if (owner == null && type != null && !type.IsAbstract) owner = Activator.CreateInstance(type);
            if (owner == null && type != null) owner = type;
            switch (level)
            {
                case Levels.Audit: Audit(message, owner ?? typeName, log: log); break;
                case Levels.Debug: Debug(message, owner ?? typeName, log: log); break;
                case Levels.Info: Info(message, owner ?? typeName, log: log); break;
                case Levels.Warning: Warn(message, exception, owner ?? typeName, log: log); break;
                case Levels.Error: Error(message, exception, owner ?? typeName, log: log); break;
                case Levels.Fatal: Fatal(message, exception, owner ?? typeName, log: log); break;
            }
        }

        /// <summary>
        /// Add Audit entry to Log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="owner"></param>
        /// <param name="parameters"></param>
        /// <param name="log"></param>
        public static void Audit(string message = null, object owner = null, ParameterDictionary parameters = null, ILogRepository log = null)
        {
            if (log == null) log = new SitecoreLogRepository();
            var callingMethod = new StackFrame(1).GetMethod();
            var type = callingMethod.DeclaringType;
            var typeName = type != null ? type.FullName : string.Empty;
            if (owner == null && type != null && !type.IsAbstract) owner = Activator.CreateInstance(type);
            if (owner == null && type != null) owner = type;
            log.Audit(owner ?? typeName, "{0}.{1}{2}:{3}", new[] { typeName, callingMethod.Name, parameters.GetString(), GetMessage(message) });
        }

        /// <summary>
        /// Add Error entry to Log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="owner"></param>
        /// <param name="parameters"></param>
        /// <param name="log"></param>
        public static void Error(string message, object owner, ParameterDictionary parameters = null, ILogRepository log = null)
        {
            if (log == null) log = new SitecoreLogRepository();
            var callingMethod = new StackFrame(1).GetMethod();
            var type = callingMethod.DeclaringType;
            var typeName = type != null ? type.FullName : string.Empty;
            if (owner == null && type != null && !type.IsAbstract) owner = Activator.CreateInstance(type);
            if (owner == null && type != null) owner = type;
            log.Error(string.Format("{0}.{1}{2}:{3}", typeName, callingMethod.Name, parameters.GetString(), GetMessage(message)), owner ?? typeName);
        }

        public static void Error(string message = null, Exception exception = null, object owner = null, ParameterDictionary parameters = null, ILogRepository log = null)
        {
            if (log == null) log = new SitecoreLogRepository();
            var callingMethod = new StackFrame(1).GetMethod();
            var type = callingMethod.DeclaringType;
            var typeName = type != null ? type.FullName : string.Empty;
            if (owner == null && type != null && !type.IsAbstract) owner = Activator.CreateInstance(type);
            if (owner == null && type != null) owner = type;
            log.Error(string.Format("{0}.{1}{2}:{3}", typeName, callingMethod.Name, parameters.GetString(), GetMessage(message, exception != null ? " - " : null)), exception, owner);
        }

        /// <summary>
        /// Add Fatal entry to Log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="owner"></param>
        /// <param name="parameters"></param>
        /// <param name="log"></param>
        public static void Fatal(string message = null, Exception exception = null, object owner = null, ParameterDictionary parameters = null, ILogRepository log = null)
        {
            if (log == null) log = new SitecoreLogRepository();
            var callingMethod = new StackFrame(1).GetMethod();
            var type = callingMethod.DeclaringType;
            var typeName = type != null ? type.FullName : string.Empty;
            if (owner == null && type != null && !type.IsAbstract) owner = Activator.CreateInstance(type);
            if (owner == null && type != null) owner = type;
            log.Fatal(string.Format("{0}.{1}{2}:{3}", typeName, callingMethod.Name, parameters.GetString(), GetMessage(message, exception != null ? " - " : null)), exception, owner);
        }

        /// <summary>
        /// Add Warn entry to Log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="log"></param>
        public static void Warn(string message, ILogRepository log = null)
        {
            if (log == null) log = new SitecoreLogRepository();
            var callingMethod = new StackFrame(1).GetMethod();
            var type = callingMethod.DeclaringType;
            var typeName = type != null ? type.FullName : string.Empty;
            var owner = (type != null && !type.IsAbstract) ? Activator.CreateInstance(type) : type;
            log.Warn(string.Format("{0}.{1}{2}:{3}", typeName, callingMethod.Name, string.Empty, GetMessage(message)), owner);
        }

        public static void Warn(ParameterDictionary parameters, ILogRepository log = null)
        {
            if (log == null) log = new SitecoreLogRepository();
            var callingMethod = new StackFrame(1).GetMethod();
            var type = callingMethod.DeclaringType;
            var typeName = type != null ? type.FullName : string.Empty;
            var owner = (type != null && !type.IsAbstract) ? Activator.CreateInstance(type) : type;
            log.Warn(string.Format("{0}.{1}{2}:{3}", typeName, callingMethod.Name, parameters.GetString(), "Warn"), owner);
        }

        public static void Warn(string message, ParameterDictionary parameters, ILogRepository log = null)
        {
            if (log == null) log = new SitecoreLogRepository();
            var callingMethod = new StackFrame(1).GetMethod();
            var type = callingMethod.DeclaringType;
            var typeName = type != null ? type.FullName : string.Empty;
            var owner = (type != null && !type.IsAbstract) ? Activator.CreateInstance(type) : type;
            log.Warn(string.Format("{0}.{1}{2}:{3}", typeName, callingMethod.Name, parameters.GetString(), GetMessage(message)), owner);
        }

        public static void Warn(string message, Exception exception, object owner = null, ParameterDictionary parameters = null, ILogRepository log = null)
        {
            if (log == null) log = new SitecoreLogRepository();
            var callingMethod = new StackFrame(1).GetMethod();
            var type = callingMethod.DeclaringType;
            var typeName = type != null ? type.FullName : string.Empty;
            if (owner == null && type != null && !type.IsAbstract) owner = Activator.CreateInstance(type);
            if (owner == null && callingMethod.DeclaringType != null) owner = type;
            log.Warn(string.Format("{0}.{1}{2}:{3}", typeName, callingMethod.Name, parameters.GetString(), GetMessage(message, exception != null ? " - " : null)), exception, owner ?? type);
        }

        public static void Warn(string message, object owner, ParameterDictionary parameters = null, ILogRepository log = null)
        {
            if (log == null) log = new SitecoreLogRepository();
            var callingMethod = new StackFrame(1).GetMethod();
            var type = callingMethod.DeclaringType;
            var typeName = type != null ? type.FullName : string.Empty;
            if (owner == null && type != null && !type.IsAbstract) owner = Activator.CreateInstance(type);
            if (owner == null && callingMethod.DeclaringType != null) owner = type;
            log.Warn(string.Format("{0}.{1}{2}:{3}", typeName, callingMethod.Name, parameters.GetString(), GetMessage(message)), owner ?? type);
        }

        /// <summary>
        /// Add Info entry to Log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="owner"></param>
        /// <param name="parameters"></param>
        /// <param name="log"></param>
        public static void Info(string message = null, object owner = null, ParameterDictionary parameters = null, ILogRepository log = null)
        {
            if (log == null) log = new SitecoreLogRepository();
            var callingMethod = new StackFrame(1).GetMethod();
            var type = callingMethod.DeclaringType;
            var typeName = type != null ? type.FullName : string.Empty;
            if (owner == null && type != null && !type.IsAbstract) owner = Activator.CreateInstance(type);
            if (owner == null && callingMethod.DeclaringType != null) owner = type;
            log.Info(string.Format("{0}.{1}{2}:{3}", typeName, callingMethod.Name, parameters.GetString(), GetMessage(message)), owner ?? type);
        }

        /// <summary>
        /// Add Debug entry to Log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="owner"></param>
        /// <param name="parameters"></param>
        /// <param name="log"></param>
        public static void Debug(string message = null, object owner = null, ParameterDictionary parameters = null, ILogRepository log = null)
        {
            if (log == null) log = new SitecoreLogRepository();
            var callingMethod = new StackFrame(1).GetMethod();
            var type = callingMethod.DeclaringType;
            var typeName = type != null ? type.FullName : string.Empty;
            if (owner == null && type != null && !type.IsAbstract) owner = Activator.CreateInstance(type);
            if (owner == null && callingMethod.DeclaringType != null) owner = type;
            log.Debug(string.Format("{0}.{1}{2}:{3}", typeName, callingMethod.Name, parameters.GetString(), GetMessage(message)), owner ?? type);
        }
        
        /// <summary>
        /// Add Trace entry to Log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="owner"></param>
        /// <param name="parameters"></param>
        /// <param name="log"></param>
        public static void Trace(string message = null, object owner = null, ParameterDictionary parameters = null, ILogRepository log = null)
        {
            if (log == null) log = new SitecoreLogRepository();
            var callingMethod = new StackFrame(1).GetMethod();
            var type = callingMethod.DeclaringType;
            var typeName = type != null ? type.FullName : string.Empty;
            if (owner == null && type != null && !type.IsAbstract) owner = Activator.CreateInstance(type);
            if (owner == null && type != null) owner = type;
            log.Trace(String.Format("{0}.{1}{2}:{3}", typeName, callingMethod.Name, parameters.GetString(), GetMessage(message)), owner ?? typeName);
        }

        internal static string GetExceptionMessage(Exception exception)
        {
            var results = new StringBuilder();
            results.Append(exception);

            var innerException = exception.InnerException;
            if (innerException != null)
                results.Append(GetExceptionMessage(innerException));

            return results.ToString();
        }

        internal static string GetMessage(string message, string suffix = null)
        {
            return String.IsNullOrEmpty(message) ? string.Empty : string.Format("\n{0}{1}", message, suffix);
        }
    }
}