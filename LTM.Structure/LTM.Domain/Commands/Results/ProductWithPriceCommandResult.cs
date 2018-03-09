using LTM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Domain.Commands.Results
{
    public class ProductWithPriceCommandResult
    {
        public int? IdProduct { get; set; }

        public string Description { get; set; }

        public ProductPriceInfo ProductPrice { get; set; }
    }
}
