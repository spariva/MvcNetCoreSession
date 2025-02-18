using System.Runtime.Serialization.Formatters.Binary;

namespace MvcNetCoreSession.Helpers
{
    public class HelperBinarySession
    {
        public static byte[] ObjectToByte(Object objeto)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, objeto);
                return stream.ToArray();
            }
        }

        public static Object ByteToObject(byte[] bytes)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (MemoryStream stream = new MemoryStream(bytes))
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(stream);
            }
        }
    }
}
