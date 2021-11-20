using AccountingOfProductsInTheStoreView.Logic.BindingModels;
using AccountingOfProductsInTheStoreView.Logic.ViewModels;
using AccountingOfProductsInTheStoreView.ProductDatabaseImplement.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingOfProductsInTheStoreView.Logic.BusinessLogics
{
    public class ProductLogic
    {
        private readonly ProductStorage courseStorage = new ProductStorage();
        public ProductLogic()
        {

        }

        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            if (model == null)
            {
                return courseStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ProductViewModel> { courseStorage.GetElement(model) };
            }
            return null;
        }

        public void Create(ProductBindingModel model)
        {
            courseStorage.Insert(model);
        }

        public void Update(ProductBindingModel model)
        {
            var element = courseStorage.GetElement(new ProductBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            courseStorage.Update(model);
        }

        public void Delete(ProductBindingModel model)
        {
            var element = courseStorage.GetElement(new ProductBindingModel
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
