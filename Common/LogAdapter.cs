using System;
using log4net;

namespace Common
{
    public class LogAdapter : ILogger
    {
        private readonly ILog _log;
        private readonly ILogSerializer _serializer;

        public LogAdapter(ILog log, ILogSerializer serializer)
        {
            _log = log;
            _serializer = serializer;
        }

        public void Debug(object msg, Exception ex = null)
        {
            if (_log.IsDebugEnabled && msg != null)
            {
                if (ex == null)
                    _log.Debug(msg);
                else
                    _log.Debug(msg, ex);
            }
        }

        public void DebugFormat(string msg, params object[] args)
        {
            if(_log.IsDebugEnabled && !string.IsNullOrEmpty(msg))
                _log.DebugFormat(msg, args);
        }

        public void Info(object msg, Exception ex = null)
        {
            if (_log.IsInfoEnabled && msg != null)
            {
                if (ex == null)
                    _log.Info(_serializer.Serialize(msg));
                else
                    _log.Info(_serializer.Serialize(msg), ex);    
            } 
        }

        public void InfoFormat(string msg, params object[] args)
        {
            if(_log.IsInfoEnabled && !string.IsNullOrEmpty(msg))
                _log.InfoFormat(msg, args);
        }

        public void Error(object msg, Exception ex = null)
        {
            if (_log.IsErrorEnabled && msg != null)
            {
                if (ex == null)
                    _log.Error(_serializer.Serialize(msg));
                else
                    _log.Error(_serializer.Serialize(msg), ex);
            }
        }

        public void ErrorFormat(string msg, params object[] args)
        {
            if(_log.IsErrorEnabled && !string.IsNullOrEmpty(msg))
                _log.ErrorFormat(msg, args);
        }

        public void Warn(object msg, Exception ex = null)
        {
            if (_log.IsWarnEnabled && msg != null)
            {
                if (ex == null)
                    _log.Warn(_serializer.Serialize(msg));
                else
                    _log.Warn(_serializer.Serialize(msg), ex);
            }
        }

        public void WarnFormat(string msg, params object[] args)
        {
            if(_log.IsWarnEnabled && !string.IsNullOrEmpty(msg))
                _log.WarnFormat(msg, args);
        }

        public void Fatal(object msg, Exception ex = null)
        {
            if (_log.IsFatalEnabled && msg != null)
            {
                if (ex == null)
                    _log.Fatal(_serializer.Serialize(msg));
                else
                    _log.Fatal(_serializer.Serialize(msg), ex);
            }
        }

        public void FatalFormat(string msg, params object[] args)
        {
            if(_log.IsFatalEnabled && !string.IsNullOrEmpty(msg))
                _log.FatalFormat(msg, args);
        }
    }
}