using System;
using System.Text.RegularExpressions;

namespace WebApplication1
{
    [Serializable]
    public class ElectricityBill
    {
        private string _consumerNumber;
        private string _consumerName;
        private int _unitsConsumed;
        private double _billAmount;

        public string ConsumerNumber
        {
            get => _consumerNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !System.Text.RegularExpressions.Regex.IsMatch(value, @"^EB\d{5}$"))
                    throw new FormatException("Invalid Consumer Number");
                _consumerNumber = value;
            }
        }

        public string ConsumerName
        {
            get => _consumerName;
            set => _consumerName = value;
        }

        public int UnitsConsumed
        {
            get => _unitsConsumed;
            set => _unitsConsumed = value;
        }

        public double BillAmount
        {
            get => _billAmount;
            set => _billAmount = value;
        }
    }
}
