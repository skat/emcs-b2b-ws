using System.Xml;

namespace UFSTWSSecuritySample
{
    public interface IPayloadWriter
    {
        void Write(XmlTextWriter writer);
    }

}
