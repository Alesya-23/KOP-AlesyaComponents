using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingOfProductsInTheStoreView.DatabaseImplement.Models
{
    public class UnitOfMeasurement
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
