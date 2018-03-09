using LTM.Domain.Commands.Results;
using LTM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LTM.Domain.Specs
{
    public class ProductSpecs
    {
        public static readonly Expression<Func<ProductInfo, ProductCommandResult>> AsProductCommandResult = x => new ProductCommandResult
        {
            IdProduct = x.IdProduct,
            Description = x.Description,
        };

        public static readonly Expression<Func<ProductInfo, ProductWithPriceCommandResult>> AsProductWithPriceCommandResult = x => new ProductWithPriceCommandResult
        {
            IdProduct = x.IdProduct,
            Description = x.Description,
            ProductPrice = x.ProductPrices.FirstOrDefault()
        };
        
    }
}
