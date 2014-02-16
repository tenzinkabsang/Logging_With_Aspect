using System;
using System.Collections.Generic;

namespace Common
{
    public interface ILogManager
    {
        ILogger GetLogger(Type type);
    }

    public class LogManager 
    {
        private static readonly ILogSerializer _serializer;
        private static readonly IDictionary<Type, LogAdapter> _logAdapters;

        static LogManager()
        {
            _serializer = new LogSerializer();
            _logAdapters = new Dictionary<Type, LogAdapter>();
        }
        
        public static ILogger GetLogger<T>()
        {
            return GetLogger(typeof(T));
        }
        
        public static ILogger GetLogger(Type type)
        {
            LogAdapter adapter;
            if (!_logAdapters.TryGetValue(type, out adapter))
            {
                var logger = log4net.LogManager.GetLogger(type);
                adapter = new LogAdapter(logger, _serializer);

                _logAdapters.Add(type, adapter);    
            }

            return adapter;
        }
    }
}