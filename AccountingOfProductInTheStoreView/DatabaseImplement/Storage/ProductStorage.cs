using AccountingOfProductInTheStoreView.DatabaseImplement;
using AccountingOfProductInTheStoreView.DatabaseImplement.Models;
using AccountingOfProductInTheStoreView.Logic.BindingModels;
using AccountingOfProductInTheStoreView.Logic.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfProductInTheStoreView.ProductDatabaseImplement.Storage
{
    public class ProductStorage
    {
        public List<ProductViewModel> GetFullList()
        {
            using (var context = new ProductDatabase())
            {
                return context.Products
                .Select(CreateModel)
               .ToList();
            }
        }

        public ProductViewModel GetElement(ProductBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ProductDatabase())
            {
                var product = context.Products
                .FirstOrDefault(rec => rec.Id == model.Id);
                return product != null ?
                CreateModel(product) : null;
            }
        }

        public void Insert(ProductBindingModel model)
        {
            using (var context = new ProductDatabase())
            {
                context.Products.Add(CreateModel(model, new Product()));
                context.SaveChanges();
            }
        }

        public void Update(ProductBindingModel model)
        {
            using (var context = new ProductDatabase())
            {
                Product product = context.Products
                    .FirstOrDefault(rec => rec.Id == model.Id);
                if (product == null)
                {
                    throw new Exception("Продукт не найден");
                }
                CreateModel(model, product);
                context.SaveChanges();
            }
        }

        public void Delete(ProductBindingModel model)
        {
            using (var context = new ProductDatabase())
            {
                Product product = context.Products
                    .FirstOrDefault(rec => rec.Id == model.Id);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Продукт не найден");
                }
            }
        }

        private ProductViewModel CreateModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                name = product.name,
                UnitOfMeasurement = product.UnitOfMeasurement,
                Country = product.Country,
                SupplierOne = product.SupplierOne,
                SupplierTwo = product.SupplierTwo,
                SupplierThree = product.SupplierThree,
            };
        }

        private Product CreateModel(ProductBindingModel model, Product product)
        {
            product.name = model.name;
            product.UnitOfMeasurement = model.UnitOfMeasurement;
            product.Country = model.Country;
            product.SupplierOne = model.SupplierOne;
            product.SupplierTwo = model.SupplierTwo;
            product.SupplierThree = model.SupplierThree;
            return product;
        }
    }
}
