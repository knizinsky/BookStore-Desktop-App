# BookStoreApp 📖

BookStoreApp is a C# application that manages a bookstore's inventory and allows users to add, delete, and order books. It utilizes the Entity Framework Core and a SQL Server database for data storage.

## ▶️ How to Run

To run the BookStoreApp application, perform the following steps:

1. Open SSMS and create a SQL Server database. Then open the project using your preferred IDE and update the connection string in the `BookStoreDbContext` class to point to your database. [Database Configuration](#database-configuration).

2. Make sure you have installed all important NuGet packages such as: `Microsoft.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.SqlServer`, `Microsoft.EntityFrameworkCore.Tools`

3. Open the NuGet Package Management Console in your project (e.g. in Visual Studio select "Tools" -> "NuGet Package Manager" -> "Package Manager Console").

4. Type the following command to create a migration for the data model: `Add-Migration InitialCreate`. And after that type: `Update-Database`

5. Run the application, and the main window will appear, showing the list of books in the inventory.

6. Use the provided buttons to add, delete, or order books.

Please note that the application assumes a working database connection and suitable database schema is set up for the application to function properly.

## 🛠️ Database Configuration

The `BookStoreDbContext` class is responsible for configuring the database connection. It uses Entity Framework Core's `DbContextOptionsBuilder` to set up the SQL Server database connection string.

The connection string used in this project is as follows:
```
Data Source=ACERASPIRE5\\SQLEXPRESS;Initial Catalog=BookShop;Integrated Security=True;TrustServerCertificate=true
```

## 🔑 Entity Relationships

The `OnModelCreating` method in the `BookStoreDbContext` class defines the relationships between the entities using Fluent API. It configures the foreign key relationships between `Book` and `Author`, `Book` and `Category`, and `Orders` and `Book`.

## Screenshots
![image](https://github.com/knizinsky/BookStore-Desktop-App/assets/108873272/499253b0-c5d0-44f5-b762-d4ab9726ff50)
![image](https://github.com/knizinsky/BookStore-Desktop-App/assets/108873272/9a38165b-ec9d-4768-971c-48d015e1c4b7)

## 🖥️ User Interface

The user interface of the application is built using Windows Presentation Foundation (WPF). The `MainWindow` window contains a `DataGrid` control that displays the list of books in the bookstore's inventory. Users can add, delete, and order books using the buttons provided in the interface.

The `BookForm` window is used for adding or editing book details. It contains text boxes for entering the book's title, author, category, ISBN, description, price, and amount. Users can save the book details or cancel the operation.

## 👨‍💻 Technologies Used

The project utilizes the following technologies:

- C#
  ![C#](https://cdn.icon-icons.com/icons2/2415/PNG/32/csharp_original_logo_icon_146578.png)
- Entity Framework
  ![Entity Framework](https://cdn.icon-icons.com/icons2/2415/PNG/32/dot_net_original_wordmark_logo_icon_146547.png)
- XAML / WPF (Windows Presentation Foundation)
  ![WPF](https://cdn.icon-icons.com/icons2/2530/PNG/48/wpf_button_icon_151942.png)
