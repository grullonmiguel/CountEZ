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

        [XmlElement(ElementName = "STREET")]
        public string? Street { get; set; }

        [XmlElement(ElementName = "CITY")]
        public string? City { get; set; }

        [XmlElement(ElementName = "STATE")]
        public StateCode StateID { get; set; }

        [XmlElement(ElementName = "ZIP")]
        public string? Zip { get; set; }

        [XmlElement(ElementName = "PHONE")]
        public string? Phone { get; set; }

        [XmlElement(ElementName = "URL")]
        public string? URL { get; set; }
    }
}
