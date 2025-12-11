using System;

namespace AssetTracking.CurrencyConverter
{
    /// Handles currency conversion from USD to various international currencies
    /// Uses hardcoded exchange rates for simplicity
    public class CurrencyConverter
    {
        public CurrencyConverter()
        {
        }

        /// Converts USD amount to specified target currency
        public static decimal ConvertFromUSD(decimal amountUSD, string toCurrency)
        {
            switch (toCurrency)
            {
                case "USD": return amountUSD * 1.00m;
                case "EUR": return amountUSD * 0.92m;
                case "SEK": return amountUSD * 10.85m;
                default: return amountUSD;           // Unknown currency, return original
            }
        }

        /// Gets the exchange rate for a specific currency (defaults to 1.0 if not found)
        public static decimal GetRate(string currency)
        {
            switch (currency)
            {
                case "USD": return 1.00m;
                case "EUR": return 0.92m;
                case "SEK": return 10.85m;
                default: return 1.00m; // Default rate
            }
        }

    };


}
