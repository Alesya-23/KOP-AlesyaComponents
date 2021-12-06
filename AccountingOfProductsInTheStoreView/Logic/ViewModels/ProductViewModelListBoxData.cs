using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AccountingOfProductsInTheStoreView.Logic.ViewModels
{
    public class ProductViewModelListBoxData
    {
        [DisplayName("Страна")]

        public string Country { get; set; } 

        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        [DisplayName("Название продукта")]
        public string name { get; set; }
        [DisplayName("Единица измерения")]
        public string UnitOfMeasurement { get; set; }
    
        [DisplayName("Поставщик 1")]
        public string SupplierOne { get; set; }
        [DisplayName("Поставщик 2")]
        public string SupplierTwo { get; set; }
        [DisplayName("Поставщик 3")]
        public string SupplierThree { get; set; }
       
    }
}