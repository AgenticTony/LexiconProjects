using System;
using AssetTracking.Models;
using AssetTracking.Models.Base;
using AssetTracking.Models.Computers;
using AssetTracking.Models.Phones;

namespace AssetTracking;

class Program
{

    // Static fields accessible by all methods
    static List<Office> offices = new List<Office>();
    static bool userWantsToQuit = false;

    static void Main(string[] args)
    {

        // Display application header
        Console.WriteLine("\n" + "=".PadRight(60, '='));
        Console.WriteLine("|           ASSET TRACKING SYSTEM                          |");
        Console.WriteLine("=".PadRight(60, '='));
        Console.WriteLine();

        // Create office locations with their currencies
        offices.Add(new Office("Sweden", "Sweden", "SEK", "kr"));
        offices.Add(new Office("USA", "United States", "USD", "$"));
        offices.Add(new Office("Spain", "Spain", "EUR", "€"));

        // Display available offices to user
        Console.WriteLine("Available offices");
        for (int i = 0; i < offices.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {offices[i].Name} ({offices[i].Currency})");
        }
        Console.WriteLine();

        // Collect assets from user input
        List<Asset> assets = new List<Asset>();

        Console.Write("How many assets would you like to add?");
        int assetCount = GetIntInput();
        Console.WriteLine();

        // Loop to create each asset
        for (int i = 0; i < assetCount; i++)
        {
            Console.WriteLine($"-------------Asset #{i + 1} -------------");

            Asset? asset = CreateAssetFromInput();

            if (userWantsToQuit)
            {
                Console.WriteLine("Finishing asset entry...");
                break;
            }

            if (asset != null)
            {
                assets.Add(asset);
                Console.WriteLine("Asset added successfully!");
            }
            Console.WriteLine();
        }


        // Exit if no assets were added
        if (assets.Count == 0)
        {
            Console.WriteLine("No assets added. Exiting ...");
            return;
        }

        // Local function to create an asset from user input
        static Asset? CreateAssetFromInput()
        {
            // Get asset type selection
            Console.WriteLine("What type of asset?");
            Console.WriteLine("0. Done - finish entering assets");
            Console.WriteLine("1. Computer (Laptop or desktop)");
            Console.WriteLine("2. Phone");
            Console.Write("Enter choice (0-2): ");
            int assetChoice = GetIntInput();

            if (assetChoice == 0)
            {
                userWantsToQuit = true;
                return null;
            }

            Asset? asset = null;

            if (assetChoice == 1)
            {
                // Computer type selection
                Console.WriteLine("\nWhat type of computer");
                Console.WriteLine("1. Laptop");
                Console.WriteLine("2. Desktop");
                Console.WriteLine("Enter choice (1-2): ");
                int computerChoice = GetIntInput();

                if (computerChoice == 1)
                {
                    // Laptop brand selection
                    Console.WriteLine("\nWhich laptop brand?");
                    Console.WriteLine("1. Macbook (Apple)");
                    Console.WriteLine("2. Asus");
                    Console.WriteLine("3. Lenovo");
                    Console.Write("Enter your choice (1-3): ");
                    int brandChoice = GetIntInput();

                    switch (brandChoice)
                    {
                        case 1:
                            asset = new MacBook();
                            break;
                        case 2:
                            asset = new AsusLaptop();
                            break;
                        case 3:
                            asset = new LenovoLaptop();
                            break;
                        default:
                            break;
                    }
                }
                else if (computerChoice == 2)
                {
                    // Desktop brand selection
                    Console.WriteLine("\nWhich desktop brand?");
                    Console.WriteLine("1. Dell");
                    Console.WriteLine("2. HP");
                    Console.Write("Enter choice (1-2): ");
                    int brandChoice = GetIntInput();

                    switch (brandChoice)
                    {
                        case 1:
                            asset = new DellDesktop();
                            break;
                        case 2:
                            asset = new HPDesktop();
                            break;
                        default:
                            break;
                    }
                }
            }
            else if (assetChoice == 2)
            {
                // Phone brand selection
                Console.WriteLine("\nWhich phone brand?");
                Console.WriteLine("1. iPhone (Apple)");
                Console.WriteLine("2. Samsung");
                Console.WriteLine("3. Nokia");
                Console.Write("Enter choice (1-3): ");
                int brandChoice = GetIntInput();

                switch (brandChoice)
                {
                    case 1:
                        asset = new IPhone();
                        break;
                    case 2:
                        asset = new SamsungPhone();
                        break;
                    case 3:
                        asset = new NokiaPhone();
                        break;
                    default:
                        break;
                }
            }

            // Validate asset was created
            if (asset == null)
            {
                Console.WriteLine("Invalid choice. Asset not created.");
                return null;
            }

            // Collect asset details
            Console.WriteLine("\nEnter model name: ");
            asset.Model = Console.ReadLine();

            Console.WriteLine("Enter price in USD: ");
            asset.PriceUSD = GetDecimalInput();

            Console.WriteLine("Enter purchase date (yyyy-MM-dd): ");
            asset.PurchaseDate = GetDateInput();

            // Office assignment
            Console.WriteLine("\nWhich office");
            for (int i = 0; i < offices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {offices[i].Name}");
            }
            Console.WriteLine("Enter choice: ");
            int officeChoice = GetIntInput();

            if (officeChoice >= 1 && officeChoice <= offices.Count)
            {
                asset.Office = offices[officeChoice - 1];
            }
            else
            {
                Console.WriteLine("Invalid office choice. Using default (USA).");
                asset.Office = offices[1];
            }

            return asset;
        }

        // Input validation helper functions
        static int GetIntInput()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                Console.Write("Invalid input. Please enter a number:");
            }
        }

        static decimal GetDecimalInput()
        {
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out decimal result))
                {
                    return result;
                }
                Console.Write("Invalid input. Please enter a number (ex. 1299.99, 1299): ");
            }
        }

        static DateTime GetDateInput()
        {
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out DateTime result))
                {
                    return result;
                }
                Console.Write("Invalid format. Please enter date (yyyy-MM-dd, yyyy/MM/dd): ");
            }
        }


        // Display helper functions
        static void PrinterHeader()
        {
            Console.WriteLine("│ Type        │ Brand     │ Model                │ Office         │ Purchase Date│ Price in USD │ Currency │ Local price today│");
            Console.WriteLine("-".PadRight(126, '-'));
        }

        // Print single asset row with color coding
        static void PrintAsset(Asset asset)
        {
            Console.ForegroundColor = asset.GetStatusColor();
            Console.WriteLine($"│ {asset.GetAssetType(),-11} │ {asset.Brand,-9} │ {asset.Model,-20} │ {asset.Office.Name,-14} │ {asset.PurchaseDate:yyyy-MM-dd}   │ {asset.PriceUSD,12:N0} │ {asset.Office.Currency,-8} │ {asset.LocalPrice,14:N2}{asset.Office.CurrencySymbol} │");
            Console.ResetColor();
        }

        // Level 2: Sort by asset type, then purchase date
        Console.WriteLine("\n" + "=".PadRight(127, '='));
        Console.WriteLine("LEVEL 2: ASSETS SORTED BY TYPE AND PURCHASE DATE");
        Console.WriteLine("=".PadRight(127, '='));

        var sortedByType = assets.OrderBy(a => a.Type).ThenBy(a => a.PurchaseDate).ToList();

        PrinterHeader();
        foreach (var asset in sortedByType)
        {
            PrintAsset(asset);
        }
        Console.WriteLine("=".PadRight(127, '='));

        // Level 3: Sort by office, then purchase date
        Console.WriteLine();
        Console.WriteLine("\n" + "=".PadRight(127, '='));
        Console.WriteLine("LEVEL 3: ASSETS SORTED BY OFFICE AND PURCHASE DATE");
        Console.WriteLine("=".PadRight(127, '='));

        var sortedByOffice = assets.OrderBy(a => a.Office.Name).ThenBy(a => a.PurchaseDate).ToList();

        PrinterHeader();
        foreach (var asset in sortedByOffice)
        {
            PrintAsset(asset);
        }
        Console.WriteLine("=".PadRight(127, '='));

        Console.WriteLine($"\nTotal Assets: {assets.Count}");
    }
}
