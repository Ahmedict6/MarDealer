# MarDealer

A comprehensive C# desktop application for dealer management system built with .NET Framework.

## 📋 Overview

MarDealer is a desktop application designed to manage dealer operations, providing a complete solution for dealer management with a clean architecture pattern. The application follows modern software development practices with separation of concerns.

## 🏗️ Architecture

The project follows a layered architecture pattern with the following structure:

```
MarDealer/
├── Business/          # Business logic layer
├── DTOs/             # Data Transfer Objects
├── Entities/         # Domain entities
├── Repository/       # Data access layer
├── MarDealer.sln     # Visual Studio solution file
└── MarDealer/        # Main application project
```

## 🚀 Features

- **Dealer Management**: Complete CRUD operations for dealer information
- **Clean Architecture**: Separation of concerns with distinct layers
- **Data Transfer Objects**: Efficient data handling between layers
- **Repository Pattern**: Abstracted data access layer
- **Entity Framework**: Modern data access technology

## 🛠️ Technology Stack

- **Language**: C#
- **Framework**: .NET Framework
- **Architecture**: Layered Architecture
- **Data Access**: Repository Pattern
- **UI**: Windows Forms (Desktop Application)

## 📦 Prerequisites

- Visual Studio 2019 or later
- .NET Framework 4.7.2 or later
- SQL Server (for database operations)

## 🔧 Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/Ahmedict6/MarDealer.git
   cd MarDealer
   ```

2. **Open the solution**
   - Open `MarDealer.sln` in Visual Studio

3. **Restore NuGet packages**
   - Right-click on the solution in Solution Explorer
   - Select "Restore NuGet Packages"

4. **Build the solution**
   - Press `Ctrl + Shift + B` or go to Build → Build Solution

## 🗄️ Database Setup

1. Create a new database in SQL Server
2. Update the connection string in the configuration file
3. Run the application to initialize the database schema

## 📁 Project Structure

### Business Layer
Contains all business logic and rules for the dealer management system.

### DTOs (Data Transfer Objects)
Defines data structures for transferring data between different layers of the application.

### Entities
Contains domain entities that represent the core business objects.

### Repository Layer
Handles all data access operations and database interactions.

## 🚀 Getting Started

1. Launch the application
2. Configure your database connection
3. Start managing your dealers!

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Ahmed Khalid**
- GitHub: [@Ahmedict6](https://github.com/Ahmedict6)

## 📞 Support

If you have any questions or need help, please open an issue on GitHub.

---

⭐ If you found this project helpful, please give it a star!
