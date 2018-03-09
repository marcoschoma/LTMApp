using LTM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Domain.Commands.Results
{
    public class ProductPriceCommandResult
    {
        public int IdProductPrice { get; set; }
        public decimal Value { get; set; }
        public int IdProduct { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
