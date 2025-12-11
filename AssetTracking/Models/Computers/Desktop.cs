using System;

namespace AssetTracking.Models.Computers
{
    /// Represents desktop computers (stationary computers)
    public class Desktop : Computer
    {
        public Desktop()
        {

        }

        public override string GetAssetType()
        {
            return "Desktop";
        }

        // Future expansion examples:
        // public string TowerSize { get; set; }
        // public bool IncludesMonitor { get; set; }
        // public int MonitorCount { get; set; }
    }
}