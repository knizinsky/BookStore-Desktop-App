using System;

namespace BookStoreApp.Tests
{
    [TestClass]
    public class BookStoreTests
    {
        [TestMethod]
        public void Test_CreateBook()
        {
            // Arrange
            var dbContext = new BookStoreDbContext();
            var book = new Book
            {
                title = "Test Book",
                ISBN = "1234567890",
                description = "This is a test book",
                price = 10,
                amount = 5,
                AuthorsId = 1,
                categoriesId = 1
            };

            // Act
            dbContext.Books.Add(book);
            dbContext.SaveChanges();

            // Assert
            var createdBook = dbContext.Books.FirstOrDefault(b => b.title == "Test Book");
            Assert.IsNotNull(createdBook);
        }

        [TestMethod]
        public void Test_DeleteBook()
        {
            // Arrange
            var dbContext = new BookStoreDbContext();
            var book = new Book
            {
                title = "Test Book",
                ISBN = "1234567890",
                description = "This is a test book",
                price = 10,
                amount = 5,
                AuthorsId = 1,
                categoriesId = 1
            };
            dbContext.Books.Add(book);
            dbContext.SaveChanges();

            // Act
            dbContext.Books.Remove(book);
            dbContext.SaveChanges();

            // Assert
            var deletedBook = dbContext.Books.FirstOrDefault(b => b.title == "Test Book");
            Assert.IsNotNull(deletedBook);
        }

        [TestMethod]
        public void Test_CreateOrder()
        {
            // Arrange
            var dbContext = new BookStoreDbContext();
            var book = new Book
            {
                title = "Test Book",
                ISBN = "1234567890",
                description = "This is a test book",
                price = 10,
                amount = 5,
                AuthorsId = 1,
                categoriesId = 1
            };
            dbContext.Books.Add(book);
            dbContext.SaveChanges();

            var order = new Orders
            {
                orderType = "Test Order",
                bookId = book.bookId
            };

            // Act
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();

            // Assert
            var createdOrder = dbContext.Orders.FirstOrDefault(o => o.orderType == "Test Order");
            Assert.IsNotNull(createdOrder);
        }
    }
}
