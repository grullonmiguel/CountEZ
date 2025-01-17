using CommunityToolkit.Mvvm.ComponentModel;
using System.Xml.Serialization;

namespace CountEZ.Models
{
    [Serializable]
    [XmlRoot("STATE", Namespace = "", IsNullable = false)]
    public class US_State : ObservableObject
    {
        [XmlAttribute(AttributeName = "ID")]
        public StateCode StateID { get; set; }

        [XmlAttribute(AttributeName = "NAME")]
        public string? Name { get; set; }

        [XmlAttribute(AttributeName = "SALES_TYPE")]
        public SaleTypeCode SalesType { get; set; }

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

        [XmlAttribute(AttributeName = "FREQUENCY")]
        public string? Frequency { get; set; }

        public int Count => Counties == null ? 0 : Counties.Count;

        public bool CanShowCountyMap { get; set; }

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
        private bool _isSelected;
    }
}