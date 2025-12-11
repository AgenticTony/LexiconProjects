# 📊 Asset Tracking System

A comprehensive C# console application for tracking company assets across multiple international offices with automatic currency conversion and lifecycle management.

## 🎯 Project Overview

This project implements a complete asset tracking system that manages computers and phones across different office locations. Assets are tracked with purchase dates, prices, and automatically calculated end-of-life status with color-coded urgency indicators.

## ✨ Features

### Level 1 - Basic Asset Management

- **Multiple Asset Types**: Computers (Laptops, Desktops) and Phones
- **Brand-Specific Classes**: MacBook, Asus, Lenovo laptops; Dell, HP desktops; iPhone, Samsung, Nokia phones
- **Core Properties**: Brand, Model, Price, Purchase Date, Office Assignment

### Level 2 - Sorting and Lifecycle Management

- **Smart Sorting**: Assets sorted by type and purchase date
- **Lifecycle Tracking**: 3-year end-of-life calculation
- **Color-Coded Status**:
  - 🔴 **Red**: ≤90 days until end-of-life (urgent replacement needed)
  - 🟡 **Yellow**: ≤180 days until end-of-life (plan replacement)
  - ⚪ **White**: >180 days until end-of-life (normal operation)

### Level 3 - International Operations

- **Multi-Office Support**: Sweden, USA, Spain
- **Currency Conversion**: Automatic USD to local currency conversion (SEK, EUR)
- **Office-Based Sorting**: Assets grouped by office location
- **Localized Pricing**: Display prices in appropriate local currency

## 🛠️ Technical Implementation

### Object-Oriented Programming Concepts

- **Inheritance Hierarchy**: 4-level deep inheritance (Asset → Computer → Laptop → MacBook)
- **Abstract Base Classes**: Asset class provides common functionality
- **Polymorphism**: Virtual methods for asset type identification
- **Encapsulation**: Proper property accessors and method organization

### Advanced C# Features

- **Expression-Bodied Members**: Calculated properties using `=>` syntax
- **LINQ Queries**: Complex sorting with `OrderBy().ThenBy().ToList()`
- **Local Static Functions**: Input validation helpers
- **Nullable Reference Types**: Safe null handling with `Asset?`
- **String Interpolation**: Advanced formatting with alignment (`{value,-12:N2}`)

### Data Structures & Algorithms

- **Collections**: `List<T>` for asset and office management
- **Switch Statements**: Clean currency conversion logic
- **DateTime Operations**: Date calculations and formatting
- **Input Validation**: Robust user input handling with retry loops

## 🏗️ Project Structure

```
AssetTracking/
├── Models/
│   ├── Base/
│   │   ├── Asset.cs          # Abstract base class for all assets
│   │   └── Office.cs         # Office location with currency info
│   ├── Computers/
│   │   ├── Computer.cs       # Base computer class
│   │   ├── Laptop.cs         # Laptop-specific functionality
│   │   ├── Desktop.cs        # Desktop-specific functionality
│   │   ├── MacBook.cs        # Apple laptop implementation
│   │   ├── AsusLaptop.cs     # Asus laptop implementation
│   │   ├── LenovoLaptop.cs   # Lenovo laptop implementation
│   │   ├── DellDesktop.cs    # Dell desktop implementation
│   │   └── HPDesktop.cs      # HP desktop implementation
│   └── Phones/
│       ├── Phone.cs          # Base phone class
│       ├── iPhone.cs         # Apple phone implementation
│       ├── SamsungPhone.cs   # Samsung phone implementation
│       └── NokiaPhone.cs     # Nokia phone implementation
├── CurrencyConverter/
│   └── CurrencyConverter.cs  # Currency conversion utilities
├── Program.cs                # Main application logic
└── README.md                # This documentation
```

## 🚀 How to Run

### Prerequisites

- **.NET 8.0 SDK** installed
- **Console/Terminal** access
- **C# development environment** (Visual Studio, VS Code, or Rider)

### Running the Application

1. **Clone or Download** the project
2. **Navigate to the project directory**:

   ```bash
   cd "Asset Tracking/AssetTracking"
   ```

3. **Build the project**:

   ```bash
   dotnet build
   ```

4. **Run the application**:
   ```bash
   dotnet run
   ```

### Sample Usage Flow

1. **Start Application** - See welcome banner and available offices
2. **Enter Asset Count** - Specify how many assets to add
3. **For Each Asset**:
   - Choose asset type (Computer or Phone)
   - Select specific category (Laptop/Desktop or Phone brand)
   - Choose brand (MacBook/Asus/Lenovo for laptops, etc.)
   - Enter model name (e.g., "MacBook Pro 16", "iPhone 15 Pro")
   - Enter price in USD
   - Enter purchase date (yyyy-MM-dd format)
   - Assign to office location
4. **View Reports**:
   - Level 2: Assets sorted by type and date
   - Level 3: Assets sorted by office and date
   - Color-coded status indicators
   - Automatic currency conversion

## 🎓 Learning Objectives Covered

### Beginner Concepts ✅

- Classes and Objects
- Properties and Constructors
- Basic Inheritance
- Method Overriding
- Switch Statements
- For/While Loops
- Console I/O
- Input Validation

### Intermediate Concepts 📈

- Multi-Level Inheritance
- Abstract Classes
- Virtual Methods
- Collections (List<T>)
- DateTime Operations
- String Formatting
- Error Handling

### Advanced Concepts 🚀

- LINQ Queries
- Expression-Bodied Members
- Local Static Functions
- Nullable Reference Types
- Complex String Interpolation
- Namespace Organization
- Project Architecture

## 💱 Currency Support

| Currency      | Code | Symbol | Exchange Rate\* |
| ------------- | ---- | ------ | --------------- |
| US Dollar     | USD  | $      | 1.00 (base)     |
| Euro          | EUR  | €      | 0.92            |
| Swedish Krona | SEK  | kr     | 10.85           |

\*Exchange rates are hardcoded for educational purposes

## 📋 Example Output

```
╔═══════════════════════════════════════════════════════════╗
║           ASSET TRACKING SYSTEM                           ║
╚═══════════════════════════════════════════════════════════╝

Available offices
1. Sweden (SEK)
2. USA (USD)
3. Spain (EUR)

===============================================================================================================================
LEVEL 2: ASSETS SORTED BY TYPE AND PURCHASE DATE
===============================================================================================================================
│ Type        │ Brand     │ Model                │ Office         │ Purchase Date│ Price in USD │ Currency │ Local price today│
├─────────────┼───────────┼──────────────────────┼────────────────┼──────────────┼──────────────┼──────────┼──────────────────┤
│ Computer    │ Apple     │ MacBook Pro 16       │ Sweden         │ 2022-01-15   │        2,499 │ SEK      │      27,114.15kr │
│ Phone       │ Apple     │ iPhone 15 Pro        │ USA            │ 2023-09-15   │        1,199 │ USD      │        1,199.00$ │
===============================================================================================================================
```

## 🔮 Future Expansion Possibilities

- **Real-time Currency APIs**: Live exchange rate updates
- **Database Integration**: Persistent data storage
- **Asset Search/Filtering**: Find assets by criteria
- **Reporting System**: Generate PDF/Excel reports
- **Asset Photos**: Image attachment support
- **Maintenance Tracking**: Service history logs
- **User Authentication**: Multi-user access control

## 🏆 Project Complexity Level

**Assessment**: 60% Beginner, 40% Intermediate/Advanced

This project successfully bridges the gap between basic C# concepts and more sophisticated programming techniques, making it an excellent learning progression for students moving from beginner to intermediate level.
