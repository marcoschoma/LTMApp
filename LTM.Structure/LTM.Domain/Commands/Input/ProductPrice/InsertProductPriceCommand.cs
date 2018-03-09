using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Domain.Commands.Input.ProductPrice
{
    public class InsertProductPriceCommand
    {
        public int IdProduct { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Value { get; set; }
    }
}
