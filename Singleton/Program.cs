using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public enum EventLevel
    {
        Normal,
        Warning,
        Error
    }

    public class Event
    {
        public DateTime Time { get; set; }
        public EventLevel Level { get; set; }
        public string Message { get; set; }
    }

    public class EventLogger
    {
        private static EventLogger instance;
        private List<Event> eventLog;
        private const int MaxLogSize = 10;

        private EventLogger()
        {
            eventLog = new List<Event>();
        }

        public static EventLogger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventLogger();
                }
                return instance;
            }
        }

        public void LogEvent(EventLevel level, string message)
        {
            Event newEvent = new Event
            {
                Time = DateTime.Now,
                Level = level,
                Message = message
            };

            eventLog.Add(newEvent);

            if (eventLog.Count > MaxLogSize)
            {
                eventLog.RemoveAt(0);
            }
        }

        public void PrintEventLog()
        {
            Console.WriteLine("Event Log:");
            foreach (var ev in eventLog)
            {
                Console.WriteLine($"Time: {ev.Time}, Level: {ev.Level}, Message: {ev.Message}");
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            EventLogger logger = EventLogger.Instance;

            EventLogger.Instance.LogEvent(EventLevel.Normal, "This is a normal event");
            logger.LogEvent(EventLevel.Warning, "This is a warning event");
            logger.LogEvent(EventLevel.Error, "This is an error event");
            logger.LogEvent(EventLevel.Normal, "This is a normal event");
            logger.LogEvent(EventLevel.Warning, "This is a warning event");
            logger.LogEvent(EventLevel.Error, "This is an error event");
            logger.LogEvent(EventLevel.Normal, "This is a normal event");
            logger.LogEvent(EventLevel.Warning, "This is a warning event");
            logger.LogEvent(EventLevel.Error, "This is an error event");
            logger.LogEvent(EventLevel.Normal, "This is a normal event");
            

            logger.PrintEventLog();
            Console.ReadLine();
        }
    }
    
}
