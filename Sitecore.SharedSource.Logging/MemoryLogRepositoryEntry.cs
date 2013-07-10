using System;

namespace Sitecore.SharedSource.Logging
{
    public class MemoryLogRepositoryEntry
    {
        /// <summary>
        /// Gets or sets the type. i.E. WARN, ERROR, INFO
        /// </summary>
        public Log.Levels Level { get; set; }

        /// <summary>
        /// Gets or sets the log message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the method name that created the log entry.
        /// </summary>
        public string Caller { get; set; }

        /// <summary>
        /// Gets or sets the source code line number that created the log entry.
        /// </summary>
        public int LineNumber { get; set; }

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        public Exception Exception { get; set; }
    }
}
