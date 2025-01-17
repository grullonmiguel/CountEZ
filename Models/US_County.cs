using CommunityToolkit.Mvvm.ComponentModel;
using System.Xml.Serialization;

namespace CountEZ.Models
{
    [Serializable]
    [XmlRoot("COUNTY", Namespace = "", IsNullable = false)]
    public class US_County : ObservableObject
    {
        [XmlAttribute(AttributeName = "FIPS")]
        public string? FIPS { get; set; }

        [XmlAttribute(AttributeName ="NAME")]
        public string? Name { get; set; }

        [XmlElement(ElementName = "STATE")]
        public StateCode StateID { get; set; }

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
        private bool _isSelected;
    }
}
