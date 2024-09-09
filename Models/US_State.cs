using System.Xml.Serialization;

namespace CountEZ.Models
{
    [Serializable]
    [XmlRoot("STATE", Namespace = "", IsNullable = false)]
    internal class US_State
    {
        [XmlAttribute(AttributeName = "ID")]
        public StateCode StateID { get; set; }

        [XmlAttribute(AttributeName = "NAME")]
        public string? Name { get; set; }

        [XmlElement(ElementName = "INTEREST_RATE")]
        public string? InterestRate { get; set; }

        [XmlElement(ElementName = "INTEREST_RATE_COMMENTS")]
        public string? InterestRateComments { get; set; }

        [XmlElement(ElementName = "REDEMPTION_PERIOD")]
        public string? RedemptionPeriod { get; set; }

        [XmlElement(ElementName = "REDEMPTION_PERIOD_COMMENTS")]
        public string? RedemptionPeriodComments { get; set; }

        [XmlArray("COUNTIES")]
        [XmlArrayItem(ElementName = "COUNTY", Type = typeof(US_County))]
        public List<US_County>? Counties { get; set; }
    }
}
