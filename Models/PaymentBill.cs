using System.Xml.Serialization;

namespace UtilityPayments.Models
{
    public class PaymentBill
    {
        [XmlElement("AccountNumber")]
        public string accountNumber { get; set; } = string.Empty;

        [XmlElement("TenantsCount")]
        public int tenantsCount     { get; set; }

        [XmlElement("ReportingMonth")]
        public int reportingMonth   { get; set; }

        [XmlElement("ReportingYear")]
        public int reportingYear    { get; set; }

        [XmlElement("Сonsumption")]
        public PaymentСonsumption? consumption { get; set; }
    }
}
