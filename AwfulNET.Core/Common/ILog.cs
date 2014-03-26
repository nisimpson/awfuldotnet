using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Common
{
    public interface ILog
    {
        void AddEntry(LogLevel level, string message);
        void AddEntry(LogLevel level, Exception ex);
        string WriteAsString();
    }

    public enum LogLevel { CRITICAL = 0, WARNING, INFO };

    public interface ILogEntry
    {
        DateTime Timestamp { get; }
        LogLevel Level { get; }
        string Message { get; }
    }

    [DataContract]
    public class LogEntry : ILogEntry
    {
        private DateTime timestamp;
        private LogLevel level;
        private string message;

        [DataMember]
        public DateTime Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }
        
        [DataMember]
        public LogLevel Level
        {
            get { return level; }
            set { level = value; }
        }

        [DataMember]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public override string ToString()
        {
            return string.Format("[{0}][{1}]: {2}",
                timestamp.ToString("{0:yyyyMMdd_HHmm}"),
                level,
                message);
        }
    }

    [DataContract]
    public class ConsoleLog : ILog
    {
        [DataMember]
        public List<LogEntry> Entries { get; set; }

        public ConsoleLog() { Entries = new List<LogEntry>(); }

        public void AddEntry(LogLevel level, string message)
        {
            var entry = new LogEntry() { Timestamp = DateTime.UtcNow, Level = level, Message = message };
            if (Debugger.IsAttached)
                Debug.WriteLine(entry);

            Entries.Add(entry);
        }

        public string WriteAsString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var entry in Entries)
                builder.AppendLine(entry.ToString());

            return builder.ToString();
        }

        public void AddEntry(LogLevel level, Exception ex)
        {
            string message = string.Format("<{0}> {1}", ex.GetType(), ex.Message);
            AddEntry(level, message);
        }
    }

    public class EmptyLog : ILog
    {
        public void AddEntry(LogLevel level, string message)
        {
            
        }

        public string WriteAsString()
        {
            return string.Empty;
        }
        public void AddEntry(LogLevel level, Exception ex)
        {
            
        }
    }

    public static class Logger
    {
        private static EmptyLog emptyLog = new EmptyLog();
        private static ILog defaultLog;
        public static ILog Default
        {
            get { return defaultLog == null ? emptyLog : defaultLog; }
            set { defaultLog = value; }
        }
    }
}
