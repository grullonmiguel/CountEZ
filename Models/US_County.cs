using System.Xml.Serialization;

namespace CountEZ.Models
{
    [Serializable]
    [XmlRoot("COUNTY", Namespace = "", IsNullable = false)]
    internal class US_County
    {
        [XmlAttribute(AttributeName = "FIPS")]
        public string? FIPS { get; set; }

        [XmlAttribute(AttributeName ="NAME")]
        public string? Name { get; set; }

        [XmlAttribute(AttributeName = "STATE")]
        public StateCode StateID { get; set; }
    }
}
