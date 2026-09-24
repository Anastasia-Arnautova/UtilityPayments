using System.Reflection.Metadata.Ecma335;
using UtilityPayments.Loaders;
using UtilityPayments.Models;

namespace UtilityPayments.Calculator
{
    public class PaymentCalculator
    {
        internal class DefaultBill
        {
            protected float _tariff;
            protected int _consumption;

            public DefaultBill(float tariff, int consumption)
            {
                _tariff = tariff;
                _consumption = consumption;
            }
            public virtual float GetBill()
            {
                return _tariff * _consumption;
            }
        }

        internal class ElectricityBill : DefaultBill
        {
            private int _nightConsumption;

            public ElectricityBill(float tariff, int dayConsumption, int nightConsumption) : base(tariff, dayConsumption)
            {
                _nightConsumption = nightConsumption;
            }

            public override float GetBill()
            {
                float benefitTariff = _tariff / 2;
                float benefitBill = benefitTariff * _nightConsumption;

                return (base.GetBill() + benefitBill);
            }
        }

        public void Calculate()
        {
            DataLoader dataLoader  = new DataLoader();
            PaymentTariff? tariff  = dataLoader.LoadTariffs();
            PaymentBill? bill      = dataLoader.LoadBill();

            if (tariff == null) { Console.WriteLine("Can`t read tariffs data"); return; }
            if (bill   == null) { Console.WriteLine("Can`t read bills data ");  return; }

            _gasBill         = new DefaultBill(tariff.gas, bill.consumption?.gas ?? 0).GetBill();
            _waterBill       = new DefaultBill(tariff.water, bill.consumption?.water ?? 0).GetBill();
            _electricityBill = new ElectricityBill(tariff.electricity, bill.consumption?.electricityDay ?? 0, bill.consumption?.electricityNight ?? 0).GetBill();
            _totalBill       = _gasBill + _waterBill + _electricityBill;

            Console.WriteLine($"Payment for account:\t{bill.accountNumber}");
            Console.WriteLine($"Reporting period:\t{bill.reportingMonth}.{bill.reportingYear}");
            Console.WriteLine($"Gas:\t\t\t{gasBill.ToString("0.00")} uah");
            Console.WriteLine($"Water:\t\t\t{waterBill.ToString("0.00")} uah");
            Console.WriteLine($"Electricity:\t\t{electricityBill.ToString("0.00")} uah");
            Console.WriteLine($"TOTAL:\t\t\t{totalBill.ToString("0.00")} uah");
        }

        private float _gasBill;
        private float _waterBill;
        private float _electricityBill;
        private float _totalBill;

        public float gasBill            { get => _gasBill; }
        public float waterBill          { get => _waterBill; }
        public float electricityBill    { get => _electricityBill; }
        public float totalBill          { get => _totalBill; }
    }
}
