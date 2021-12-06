using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AccountingOfProductInTheStoreView.Logic.ViewModels
{
    public class ProductViewModel
    {

        [DisplayName("Идентификатор")]
        public int? Id { get; set; }

        [DisplayName("Название продуукта")]
        public string name { get; set; }

        [DisplayName("Поставщик 1")]
        public string SupplierOne { get; set; }
        [DisplayName("Поставщик 2")]
        public string SupplierTwo { get; set; }
        [DisplayName("Поставщик 3")]
        public string SupplierThree { get; set; }
        [DisplayName("Единица измеренич")]
        public string UnitOfMeasurement { get; set; }
        [DisplayName("Страна")]
        public string Country { get; set; }
    }
}
