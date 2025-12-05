using System;
using AssetTracking.Models.Base;

namespace AssetTracking.Models.Computers
{
    /// Represents laptop computers (portable computers)

    public class Laptop : Computer
    {
        public Laptop()
        {

        }

        public override string GetAssetType()
        {
            return "Laptop";
        }

        // Future expansion examples:
        // public decimal WeightKG { get; set; }
        // public int BatteryLifeHours { get; set; }
        // public decimal ScreenSizeInches { get; set; }
    }
}