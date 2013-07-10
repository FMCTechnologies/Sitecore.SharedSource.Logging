using System;

namespace Sitecore.SharedSource.Logging
{
    public interface ILogRepository
    {
        void Audit(object owner, string format, params string[] parameters);
        void Audit(string message, object owner = null);
        void Audit(string message, Type ownerType = null);
        void Audit(Type ownerType, string format, params string[] parameters);

        //void Debug(string message);
        void Debug(string message, object owner = null);

        void Error(string message, Exception exception, object owner);
        void Error(string message, Exception exception, Type ownerType);
        void Error(string message, object owner = null);
        void Error(string message, Type ownerType);

        void Fatal(string message, Exception exception, object owner);
        void Fatal(string message, Exception exception, Type ownerType);
        void Fatal(string message, object owner = null);
        void Fatal(string message, Type ownerType = null);

        void Info(string message, object owner = null);

        void Warn(string message, Exception exception, object owner);
        void Warn(string message, object owner = null);

        void Trace(string message, object owner = null);
    }
}
