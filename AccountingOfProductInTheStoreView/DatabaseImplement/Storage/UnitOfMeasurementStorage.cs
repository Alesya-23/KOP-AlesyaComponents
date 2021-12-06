using AccountingOfProductInTheStoreView.DatabaseImplement;
using AccountingOfProductInTheStoreView.DatabaseImplement.Models;
using AccountingOfProductInTheStoreView.Logic.BindingModels;
using AccountingOfProductInTheStoreView.Logic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingOfProductInTheStoreView.ProductDatabaseImplement.Storage
{
    public class UnitOfMeasurementStorage
    {
        public List<UnitOfMeasurementViewModel> GetFullList()
        {
            using (var context = new ProductDatabase())
            {
                return context.UnitOfMeasurement
                .Select(CreateModel)
               .ToList();
            }
        }

        public UnitOfMeasurementViewModel GetElement(UnitOfMeasurementBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ProductDatabase())
            {
                var unitOfMeasurement = context.UnitOfMeasurement
                .FirstOrDefault(rec => rec.Id == model.Id);
                return unitOfMeasurement != null ?
                CreateModel(unitOfMeasurement) : null;
            }
        }

        public void Insert(UnitOfMeasurementBindingModel model)
        {
            using (var context = new ProductDatabase())
            {
                context.UnitOfMeasurement.Add(CreateModel(model, new UnitOfMeasurement()));
                context.SaveChanges();
            }
        }

        public void Update(UnitOfMeasurementBindingModel model)
        {
            using (var context = new ProductDatabase())
            {
                UnitOfMeasurement unitOfMeasurement = context.UnitOfMeasurement
                    .FirstOrDefault(rec => rec.Id == model.Id);
                if (unitOfMeasurement == null)
                {
                    throw new Exception("Единица не найдена");
                }
                CreateModel(model, unitOfMeasurement);
                context.SaveChanges();
            }
        }

        public void Delete(UnitOfMeasurementBindingModel model)
        {
            using (var context = new ProductDatabase())
            {
                UnitOfMeasurement unitOfMeasurement = context.UnitOfMeasurement
                    .FirstOrDefault(rec => rec.Id == model.Id);
                if (unitOfMeasurement != null)
                {
                    context.UnitOfMeasurement.Remove(unitOfMeasurement);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Единица не найдена");
                }
            }
        }

        private UnitOfMeasurementViewModel CreateModel(UnitOfMeasurement unitOfMeasurement)
        {
            return new UnitOfMeasurementViewModel
            {
                Id = unitOfMeasurement.Id,
                Name = unitOfMeasurement.Name
            };
        }

        private UnitOfMeasurement CreateModel(UnitOfMeasurementBindingModel model, UnitOfMeasurement unitOfMeasurement)
        {
            unitOfMeasurement.Name = model.Name;
            return unitOfMeasurement;
        }
    }
}
