using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingOfProductInTheStoreView.DatabaseImplement.Models
{
    /*  По продуктам хранить следующую 
    информацию: название, список поставщиков (не более 3), единицы 
    измерения поставок (упак., кг, литры и т.п.) (список значений), страна 
    производитель (от 10 до 50 символов). */
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string SupplierOne { get; set; }
        [Required]
        public string SupplierTwo { get; set; }
        [Required]
        public string SupplierThree { get; set; }

        [Required]
        public string UnitOfMeasurement { get; set; }

        [Required]
        public string Country { get; set; }

    }
}
