
# BookStoreApp

BookStoreApp is a C# application that manages a bookstore's inventory and allows users to add, delete, and order books. It utilizes the Entity Framework Core and a SQL Server database for data storage.

## How to Run

To run the BookStoreApp application, perform the following steps:

1. Set up a SQL Server database and update the connection string in the `BookStoreDbContext` class to point to your database.

2. Build the project using your preferred IDE or the command line.

3. Make sure you have installed all important NuGet packages such as: `Microsoft.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.SqlServer`, `Microsoft.EntityFrameworkCore.Tools`

4. Open the NuGet Package Management Console in your project (e.g. in Visual Studio select "Tools" -> "NuGet Package Manager" -> "Package Manager Console").

5. Type the following command to create a migration for the data model: `Add-Migration InitialCreate`. And after that type: `Update-Database`
   
6. Run the application, and the main window will appear, showing the list of books in the inventory.

7. Use the provided buttons to add, delete, or order books.

Please note that the application assumes a working database connection and suitable database schema is set up for the application to function properly.

## Database Configuration

The `BookStoreDbContext` class is responsible for configuring the database connection. It uses Entity Framework Core's `DbContextOptionsBuilder` to set up the SQL Server database connection string.

The connection string used in this project is as follows:
```
Data Source=ACERASPIRE5\\SQLEXPRESS;Initial Catalog=BookShop;Integrated Security=True;TrustServerCertificate=true
```

## Entity Relationships

The `OnModelCreating` method in the `BookStoreDbContext` class defines the relationships between the entities using Fluent API. It configures the foreign key relationships between `Book` and `Author`, `Book` and `Category`, and `Orders` and `Book`.

## Screenshots
![image](https://github.com/knizinsky/BookStore-Desktop-App/assets/108873272/64593780-5234-4dc3-9289-d674dffda0bc)
![image](https://github.com/knizinsky/BookStore-Desktop-App/assets/108873272/d0347279-8b63-43bc-8436-5d01d247a74c)

## User Interface

The user interface of the application is built using Windows Presentation Foundation (WPF). The `MainWindow` window contains a `DataGrid` control that displays the list of books in the bookstore's inventory. Users can add, delete, and order books using the buttons provided in the interface.

The `BookForm` window is used for adding or editing book details. It contains text boxes for entering the book's title, author, category, ISBN, description, price, and amount. Users can save the book details or cancel the operation.

## Technologies Used

The project utilizes the following technologies:

- C#
  ![C#](https://cdn.icon-icons.com/icons2/2415/PNG/32/csharp_original_logo_icon_146578.png)
- Entity Framework
  ![Entity Framework](https://cdn.icon-icons.com/icons2/2415/PNG/32/dot_net_original_wordmark_logo_icon_146547.png)
- XAML / WPF (Windows Presentation Foundation)
  ![WPF](https://cdn.icon-icons.com/icons2/2530/PNG/48/wpf_button_icon_151942.png)
