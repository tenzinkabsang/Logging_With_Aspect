using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Common
{
    public interface ILogSerializer
    {
        object Serialize(object msg);
    }

    public class LogSerializer :ILogSerializer
    {
        public object Serialize(object msg)
        {
            Type type = msg.GetType();

            if (type.IsClass && type != typeof(string))
                msg = JsonConvert.SerializeObject(msg, Formatting.Indented);

            return string.Format("{0} => {1}", type.FullName, msg);
        }

        public object SerializeXml(object msg)
        {
            Type type = msg.GetType();
            if (type.IsClass && type != typeof(string))
            {
                var serializer = new XmlSerializer(type);
                var writer = new StringWriter();
                serializer.Serialize(writer, msg);
                return writer.ToString();
            }

            return msg;
        }
    }
}