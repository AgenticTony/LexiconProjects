using System;
using AssetTracking.Models.Base;

namespace AssetTracking.Models.Phones
{
    public class Phone : Asset
    {
        public Phone()
        {
            Type = "Phone";
        }

        public override string GetAssetType()
        {
            return "Phone";
        }


        // public decimal ScreenSizeInches { get; set; }
        // public bool Has5G { get; set; }
        // public int BatteryCapacityMAh { get; set; }
        // public string OperatingSystem { get; set; }
        // public int StorageGB { get; set; }
    }
}