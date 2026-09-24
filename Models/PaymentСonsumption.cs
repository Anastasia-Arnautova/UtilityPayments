using System.Xml.Serialization;

namespace UtilityPayments.Models
{
    public class PaymentСonsumption
    {
        [XmlElement("ElectricityDay")]
        public int electricityDay { get; set; }

        [XmlElement("ElectricityNight")]
        public int electricityNight { get; set; }

        [XmlElement("Gas")]
        public int gas { get; set; }

        [XmlElement("Water")]
        public int water { get; set; }
    }

}
