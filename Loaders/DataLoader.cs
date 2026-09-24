using System.Xml.Serialization;
using System.Xml;
using UtilityPayments.Models;

namespace UtilityPayments.Loaders
{
    public class DataLoader
    {
        private string TariffFileName = "Tariffs.xml";
        private string BillFileName   = "Bill.xml";

        public PaymentBill? LoadBill()
        {
            PaymentBill? bill;

            var xmlDocument = new XmlDocument();
            xmlDocument.Load(BillFileName);
            var xmlString = xmlDocument.OuterXml;
            using (var read = new StringReader(xmlString))
            {
                var serializer = new XmlSerializer(typeof(PaymentBill));
                using (XmlReader reader = new XmlTextReader(read))
                {
                    bill = serializer.Deserialize(reader) as PaymentBill;
                }
            }

            return bill;
        }
        public PaymentTariff? LoadTariffs()
        {
            PaymentTariff? tariff;

            var xmlDocument = new XmlDocument();
            xmlDocument.Load(TariffFileName);
            var xmlString = xmlDocument.OuterXml;
            using (var read = new StringReader(xmlString))
            {
                var serializer = new XmlSerializer(typeof(PaymentTariff));
                using (XmlReader reader = new XmlTextReader(read))
                {
                    tariff = serializer.Deserialize(reader) as PaymentTariff;
                }
            }

            return tariff;
        }
    }
}
