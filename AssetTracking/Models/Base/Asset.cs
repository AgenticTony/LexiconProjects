using System;
using AssetTracking.CurrencyConverter;

namespace AssetTracking.Models.Base
{
    /// <summary>
    /// Abstract base class for all trackable assets (computers, phones, etc.)
    /// </summary>
    public abstract class Asset
    {
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public decimal PriceUSD { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Office Office { get; set; }

        // Calculated properties - auto-computed from other properties
        public DateTime EndOfLifeDate => PurchaseDate.AddYears(3);
        public int DaysUntilEndOfLife => (EndOfLifeDate - DateTime.Today).Days;
        public decimal LocalPrice => CurrencyConverter.CurrencyConverter.ConvertFromUSD(PriceUSD, Office.Currency);

        // Returns color based on asset age (red=urgent, yellow=warning, white=ok)
        public ConsoleColor GetStatusColor()
        {
            if (DaysUntilEndOfLife <= 90)
            {
                return ConsoleColor.DarkRed;
            }
            else if (DaysUntilEndOfLife <= 180)
            {
                return ConsoleColor.DarkYellow;

            }
            else
            {
                return ConsoleColor.White;
            }
        }

        public bool IsNearEndOfLife()
        {
            return DaysUntilEndOfLife <= 180;
        }

        // Virtual method - child classes can override to return specific type names
        public virtual string GetAssetType()
        {
            return Type;
        }

        // Returns formatted string representation of the asset
        public override string ToString()
        {
            return $"{GetAssetType(),-12} {Brand,-10} {Model,-20} " +
                   $"{Office.Name,-15}, {PurchaseDate: yyyy-MM-dd} " +
                   $"{Office.CurrencySymbol}{LocalPrice:N2}";


        }
    }
}