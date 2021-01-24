using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Spaghappi.Models
{
    public class Ingredient
    {
        public String ProductName { get; set; }
        [PrimaryKey]
        public String Barcode { get; set; }
        public int Quantity { get; set; }
    }
}
