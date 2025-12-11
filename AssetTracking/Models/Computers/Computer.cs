using System;
using AssetTracking.Models.Base;


namespace AssetTracking.Models.Computers
{
    /// Base class for all computer assets (laptops, desktops)
    public class Computer : Asset
    {

        public Computer()
        {
            Type = "Computer";
        }

        // Future expansion examples - properties common to ALL computers:
        // Hardware specs
        // public string Processor { get; set; }        
        // public int RamGB { get; set; }               
        // public string StorageType { get; set; }      

        // Asset management
        // public string AssetTagNumber { get; set; }   
        // public string AssignedUser { get; set; }     

        // Condition tracking
        // public string Condition { get; set; }        
        // public DateTime LastMaintenance { get; set; }

    }
}