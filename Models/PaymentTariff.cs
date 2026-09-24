using System.Xml.Serialization;

namespace UtilityPayments.Models
{
    public class PaymentTariff 
    {
        [XmlElement("Electricity")]
        public float electricity { get; set; }

        [XmlElement("Gas")]
        public float gas         { get; set; }

        [XmlElement("Water")]
        public float water { get; set; }

        [XmlElement("Garbage")]
        public float garbage { get; set; }
    }
}
