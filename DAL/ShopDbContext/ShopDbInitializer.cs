using System;
using System.Collections.Generic;
using System.Data.Entity;
using DAL.DataEntities;

namespace DAL.ShopDbContext
{
    internal class ShopDbInitializer : CreateDatabaseIfNotExists<ShopDbContext>
    {
        protected override void Seed(ShopDbContext context)
        {
            base.Seed(context);

            var categories = new List<ProductCategory>(){
                new ProductCategory() {Caption = "Electronics", Description = "Electronic devices"},
                new ProductCategory() {Caption = "Robots",  Description  = "Here you can find robots"}

            };

            var products = new List<Product>()
            {
                new Product()
                {
                    Caption = "Laser Ruler",
                    Category =  categories[0],
                    Price = 100
                },
                new Product()
                {
                    Caption = "Mobile Phone",
                    Category =  categories[1],
                    Price = 200
                },
                new Product()
                {
                    Caption = "Robot Killer",
                    Category =  categories[0],
                    Price = 300
                },
                new Product()
                {
                    Caption = "Robot Cleaner",
                    Category =  categories[1],
                    Price = 400
                }

            };

            var stages = new List<Stage>()
            {
                new Stage(){Caption = "New"},
                new Stage(){Caption = "Approved"},
                new Stage(){Caption = "Sent"},
                new Stage(){Caption = "Delivery"},
                new Stage() {Caption = "In post office"},
            };

            var persons = new List<Person>
            {
                new Person { Name = "Some guy", Address = "Somewhere", DateOfBirth = new DateTime(2000, 1, 17), PhoneNumber = "+390636451401" },
                new Person { Name = "Someone", Address = "To the moon", DateOfBirth = new DateTime(2004, 2, 1), PhoneNumber = "+390636451423" },
                new Person { Name = "Anybody", Address = "World", DateOfBirth = new DateTime(2002, 1, 17), PhoneNumber = "+390636451456" },
                new Person { Name = "Literaly anyone", Address = "Mars", DateOfBirth = new DateTime(1999, 3, 7), PhoneNumber = "+390636451324" },
            };


            var orders = new List<Order>()
            {
                new Order()
                {
                    Stage = stages[0],
                    Products = new List<Product> { products[0], products[2] },
                    DateOfCreation = DateTime.Now,
                    Person = persons[0]
                },
                new Order()
                {
                    Stage = stages[1],
                    Products = new List<Product> { products[1] },
                    DateOfCreation = DateTime.Now,
                    Person = persons[1]
                },
                new Order()
                {
                    Stage = stages[2],
                    Products = new List<Product> { products[2] },
                    DateOfCreation = DateTime.Now,
                    Person = persons[2]
                },
                new Order()
                {
                    Stage = stages[3],
                    Products = new List<Product> { products[3] },
                    DateOfCreation = DateTime.Now,
                    Person = persons[3]
                },
                new Order()
                {
                    Stage = stages[4],
                    Products = new List<Product> { products[3] },
                    DateOfCreation = DateTime.Now,
                    Person = persons[2]
                },
            };

            context.Orders.AddRange(orders);
            context.SaveChanges();
        }
    }
}
