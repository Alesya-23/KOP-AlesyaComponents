using AccountingOfProductsInTheStoreView.Logic.BindingModels;
using AccountingOfProductsInTheStoreView.Logic.ViewModels;
using AccountingOfProductsInTheStoreView.ProductDatabaseImplement.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingOfProductsInTheStoreView.Logic.BusinessLogics
{
    public class UnitOfMeasurementLogic
    {

        private readonly UnitOfMeasurementStorage courseStorage = new UnitOfMeasurementStorage();
        public UnitOfMeasurementLogic()
        {

        }

        public List<UnitOfMeasurementViewModel> Read(UnitOfMeasurementBindingModel model)
        {
            if (model == null)
            {
                return courseStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<UnitOfMeasurementViewModel> { courseStorage.GetElement(model) };
            }
            return null;
        }

        public void Create(UnitOfMeasurementBindingModel model)
        {
            courseStorage.Insert(model);
        }

        public void Update(UnitOfMeasurementBindingModel model)
        {
            var element = courseStorage.GetElement(new UnitOfMeasurementBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            courseStorage.Update(model);
        }

        public void Delete(UnitOfMeasurementBindingModel model)
        {
            var element = courseStorage.GetElement(new UnitOfMeasurementBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            courseStorage.Delete(model);
        }
    }
}