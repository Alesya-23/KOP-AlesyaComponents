using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingOfProductsInTheStoreView.Logic.BindingModels
{
    public class ProductBindingModel
    {
        public int? Id { get; set; }
        public string name { get; set; }
        public string SupplierOne { get; set; }
        public string SupplierTwo { get; set; }
        public string SupplierThree { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string Country { get; set; }
    }
}
