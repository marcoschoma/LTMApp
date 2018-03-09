using System;
using System.Collections.Generic;
using System.Text;
using LTM.Domain.Commands.Input.ProductPrice;

namespace LTM.Domain.Entities
{
    public class ProductPriceInfo
    {
        public ProductPriceInfo(InsertProductPriceCommand insertProductCommand)
        {
            EndDate = insertProductCommand.EndDate;
            IdProduct = insertProductCommand.IdProduct;
            Value = insertProductCommand.Value;
        }

        public int IdProductPrice { get; set; }
        public decimal Value { get; set; }
        public int IdProduct { get; set; }
        public DateTime? EndDate { get; set; }
        public ProductInfo Product { get; set; }
    }
}
