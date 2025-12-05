using System;


namespace AssetTracking.Models
{

    /// <summary>
    /// Represents a company office location with currency information
    /// </summary>
    public class Office
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public string CurrencySymbol { get; set; }
        public Office
        (
            string name,
            string country,
            string currency,
            string symbol
        )
        {
            Name = name;
            Country = country;
            Currency = currency;
            CurrencySymbol = symbol;
        }

        // Returns formatted office display string
        public override string ToString()
        {
            return $"{Name} ({Country}) - {CurrencySymbol} ";
        }


    }
}