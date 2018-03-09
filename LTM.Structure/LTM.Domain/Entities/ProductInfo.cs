using System;
using System.Collections.Generic;
using System.Text;
using LTM.Domain.Commands.Input;
using LTM.Domain.Commands.Input.Product;

namespace LTM.Domain.Entities
{
    public class ProductInfo : EntityInfo
    {
        public ProductInfo(InsertProductCommand insertProductCommand)
        {
            this.Description = insertProductCommand.Description;
        }

        public int IdProduct { get; set; }

        public string Description { get; set; }
        public IEnumerable<ProductPriceInfo> ProductPrices { get; set; }
    }
}
