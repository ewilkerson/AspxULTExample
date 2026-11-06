
    using System;
    using System.IO;
    using System.Xml.Serialization;

    namespace AspxULTExample.Repository
    {
    public abstract class SerializeDeserializeXmlRepository
    {
    protected void XmlSerialize<T>(T result, string xml)
    {
    if (result != null && !string.IsNullOrWhiteSpace(xml))
    {
    XmlSerializer serializer = new XmlSerializer(typeof(T));

    using (var writer = new StreamWriter(xml))
    {
    serializer.Serialize(writer, result);
    writer.Close();
    }
    }
    else
    {
    Exception exception = new Exception("XmlSerialize - T result, string xml");
    Log4ExceptionConnDb.ExXml(exception);
    }

    }

    protected T XmlDeserialize<T>(string xml)
    {
    T result = default;

    if (!string.IsNullOrWhiteSpace(xml))
    {

    XmlSerializer serializer = new XmlSerializer(typeof(T));
    using (TextReader reader = new StreamReader(xml))
    {
    result = (T)serializer.Deserialize(reader);
    reader.Close();
    }
    }
    else
    {
    Exception exception = new Exception("XmlDeserialize - string xml");
    Log4ExceptionConnDb.ExXml(exception);
    }

    return result;
    }
    }
    }
  