using System;

namespace Sitecore.SharedSource.Logging
{
    public class SitecoreLogRepository : ILogRepository
    {
        public void Audit(object owner, string format, params string[] parameters)
        {
            Diagnostics.Log.Audit(owner, format, parameters);
        }

        public void Audit(Type ownerType, string format, params string[] parameters)
        {
            Diagnostics.Log.Audit(ownerType, format, parameters);
        }

        public void Audit(string message, object owner = null)
        {
            Diagnostics.Log.Audit(message, owner);
        }

        public void Audit(string message, Type ownerType = null)
        {
            Diagnostics.Log.Audit(message, ownerType);
        }

        public void Debug(string message, object owner = null)
        {
            Diagnostics.Log.Debug(message, owner);
        }

        public void Error(string message, Exception exception, object owner = null)
        {
            Diagnostics.Log.Error(message, exception, owner);
        }

        public void Error(string message, Exception exception, Type ownerType = null)
        {
            Diagnostics.Log.Error(message, exception, ownerType);
        }

        public void Error(string message, object owner = null)
        {
            Diagnostics.Log.Error(message, owner);
        }

        public void Error(string message, Type ownerType = null)
        {
            Diagnostics.Log.Error(message, ownerType);
        }

        public void Fatal(string message, Exception exception, object owner)
        {
            Diagnostics.Log.Fatal(message, exception, owner);
        }

        public void Fatal(string message, Exception exception, Type ownerType)
        {
            Diagnostics.Log.Fatal(message, exception, ownerType);
        }

        public void Fatal(string message, object owner = null)
        {
            Diagnostics.Log.Fatal(message, owner);
        }

        public void Fatal(string message, Type ownerType = null)
        {
            Diagnostics.Log.Fatal(message, ownerType);
        }

        public void Info(string message, object owner = null)
        {
            Diagnostics.Log.Info(message, owner);
        }

        public void Warn(string message, Exception exception, object owner = null)
        {
            Diagnostics.Log.Warn(message, exception, owner);
        }

        public void Warn(string message, object owner = null)
        {
            Diagnostics.Log.Warn(message, owner);
        }

        public void Trace(string message, object owner = null)
        {
            Diagnostics.Log.Debug(String.Concat("Trace:", message), owner);
        }
    }
}
