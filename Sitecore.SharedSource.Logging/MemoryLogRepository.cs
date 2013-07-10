using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Sitecore.SharedSource.Logging
{
    public class MemoryLogRepository : ILogRepository
    {
        private const int MaxLogEntriesInMemory = 1000;
        private static BlockingCollection<MemoryLogRepositoryEntry> _memoryLogEntries = new BlockingCollection<MemoryLogRepositoryEntry>();

        public static BlockingCollection<MemoryLogRepositoryEntry> Entries
        {
            get
            {
                return _memoryLogEntries;
            }
        }

        public static void Clear()
        {
            _memoryLogEntries = new BlockingCollection<MemoryLogRepositoryEntry>();
        }
        
        public void Audit(object owner, string format, params string[] parameters)
        {
            if (_memoryLogEntries.Count < MaxLogEntriesInMemory)
            {
                _memoryLogEntries.Add(new MemoryLogRepositoryEntry {Caller = owner.ToString(), Level = Log.Levels.Audit, Message = String.Format(format, parameters)});
            }
        }

        public void Audit(string message, object owner = null)
        {
            if (_memoryLogEntries.Count < MaxLogEntriesInMemory)
            {
                _memoryLogEntries.Add(new MemoryLogRepositoryEntry { Caller = owner.ToString(), Level = Log.Levels.Audit, Message = message });
            }
        }

        public void Audit(string message, Type ownerType = null)
        {
            if (_memoryLogEntries.Count < MaxLogEntriesInMemory)
            {
                _memoryLogEntries.Add(new MemoryLogRepositoryEntry { Caller = ownerType != null ? ownerType.FullName : null, Level = Log.Levels.Audit, Message = message });
            }
        }

        public void Audit(Type ownerType, string format, params string[] parameters)
        {
            if (_memoryLogEntries.Count < MaxLogEntriesInMemory)
            {
                _memoryLogEntries.Add(new MemoryLogRepositoryEntry { Caller = ownerType != null ? ownerType.FullName : null, Level = Log.Levels.Audit, Message = String.Format(format, parameters) });
            }
        }

        public void Debug(string message, object owner = null)
        {
            if (_memoryLogEntries.Count < MaxLogEntriesInMemory)
            {
                _memoryLogEntries.Add(new MemoryLogRepositoryEntry { Caller = owner != null ? owner.ToString() : null, Level = Log.Levels.Debug, Message = message });
            }
        }

        public void Error(string message, Exception exception, object owner)
        {
            if (_memoryLogEntries.Count < MaxLogEntriesInMemory)
            {
                _memoryLogEntries.Add(new MemoryLogRepositoryEntry { Caller = owner != null ? owner.ToString() : null, Level = Log.Levels.Error, Message = message, Exception = exception });
            }
        }

        public void Error(string message, Exception exception, Type ownerType)
        {
            if (_memoryLogEntries.Count < MaxLogEntriesInMemory)
            {
                _memoryLogEntries.Add(new MemoryLogRepositoryEntry { Caller = ownerType != null ? ownerType.FullName : null, Level = Log.Levels.Error, Message = message, Exception = exception });
            }
        }

        public void Error(string message, object owner = null)
        {
            if (_memoryLogEntries.Count < MaxLogEntriesInMemory)
            {
                _memoryLogEntries.Add(new MemoryLogRepositoryEntry { Caller = owner != null ? owner.ToString() : null, Level = Log.Levels.Error, Message = message });
            }
        }

        public void Error(string message, Type ownerType)
        {
            if (_memoryLogEntries.Count < MaxLogEntriesInMemory)
            {
                _memoryLogEntries.Add(new MemoryLogRepositoryEntry { Caller = ownerType != null ? ownerType.FullName : null, Level = Log.Levels.Error, Message = message });
            }
        }

        public void Fatal(string message, Exception exception, object owner)
        {
            if (_memoryLogEntries.Count < MaxLogEntriesInMemory)
            {
                _memoryLogEntries.Add(new MemoryLogRepositoryEntry { Caller = owner != null ? owner.ToString() : null, Level = Log.Levels.Fatal, Message = message, Exception = exception });
            }
        }

        public void Fatal(string message, Exception exception, Type ownerType)
        {
            if (_memoryLogEntries.Count < MaxLogEntriesInMemory)
            {
                _memoryLogEntries.Add(new MemoryLogRepositoryEntry { Caller = ownerType != null ? ownerType.FullName : null, Level = Log.Levels.Fatal, Message = message, Exception = exception });
            }
        }

        public void Fatal(string message, object owner = null)
        {
            if (_memoryLogEntries.Count < MaxLogEntriesInMemory)
            {
                _memoryLogEntries.Add(new MemoryLogRepositoryEntry { Caller = owner != null ? owner.ToString() : null, Level = Log.Levels.Fatal, Message = message });
            }
        }

        public void Fatal(string message, Type ownerType = null)
        {
            if (_memoryLogEntries.Count < MaxLogEntriesInMemory)
            {
                _memoryLogEntries.Add(new MemoryLogRepositoryEntry { Caller = ownerType != null ? ownerType.FullName : null, Level = Log.Levels.Fatal, Message = message });
            }
        }

        public void Info(string message, object owner = null)
        {
            if (_memoryLogEntries.Count < MaxLogEntriesInMemory)
            {
                _memoryLogEntries.Add(new MemoryLogRepositoryEntry { Caller = owner != null ? owner.ToString() : null, Level = Log.Levels.Info, Message = message });
            }
        }

        public void Warn(string message, Exception exception, object owner)
        {
            if (_memoryLogEntries.Count < MaxLogEntriesInMemory)
            {
                _memoryLogEntries.Add(new MemoryLogRepositoryEntry { Caller = owner != null ? owner.ToString() : null, Level = Log.Levels.Warning, Message = message, Exception = exception });
            }
        }

        public void Warn(string message, object owner = null)
        {
            if (_memoryLogEntries.Count < MaxLogEntriesInMemory)
            {
                _memoryLogEntries.Add(new MemoryLogRepositoryEntry { Caller = owner != null ? owner.ToString() : null, Level = Log.Levels.Warning, Message = message });
            }
        }

        public void Trace(string message, object owner = null)
        {
            if (_memoryLogEntries.Count < MaxLogEntriesInMemory)
            {
                _memoryLogEntries.Add(new MemoryLogRepositoryEntry { Caller = owner != null ? owner.ToString() : null, Level = Log.Levels.Trace, Message = message });
            }
        }
    }
}
