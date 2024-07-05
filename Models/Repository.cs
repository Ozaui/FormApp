using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormApp.Models;

namespace FormApp.Models
{
    public class Repository
    {
        private static readonly List<Product> _product = new();
        private static readonly List<Category> _category = new();
        static Repository()
        {
            _category.Add(new Category { CategoryId = 1, Name = "Phone" });
            _category.Add(new Category { CategoryId = 2, Name = "Computer" });

            _product.Add(new Product { ProductId = 1, Name = "Iphone 11", Price = 10000, Image = "1.jpg", IsActive = true, CategoryId = 1 });
            _product.Add(new Product { ProductId = 2, Name = "Iphone 12", Price = 20000, Image = "2.jpg", IsActive = true, CategoryId = 1 });
            _product.Add(new Product { ProductId = 3, Name = "Iphone 13", Price = 30000, Image = "3.jpg", IsActive = true, CategoryId = 1 });
            _product.Add(new Product { ProductId = 4, Name = "Iphone 14", Price = 40000, Image = "4.jpg", IsActive = true, CategoryId = 1 });

            _product.Add(new Product { ProductId = 5, Name = "ASUS TUF A15 2023", Price = 40000, Image = "5.jpg", IsActive = true, CategoryId = 2 });
            _product.Add(new Product { ProductId = 6, Name = "Monster Abra A7 V12.1", Price = 15000, Image = "6.jpg", IsActive = true, CategoryId = 2 });

        }

        public static List<Product> Products
        {
            get { return _product; }
        }
        public static void CreateProduct(Product entity)
        {
            _product.Add(entity);
        }
        public static List<Category> Categores
        {
            get { return _category; }
        }
    }
}