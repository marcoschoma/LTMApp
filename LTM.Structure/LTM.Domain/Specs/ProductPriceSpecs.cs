using LTM.Domain.Commands.Results;
using LTM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LTM.Domain.Specs
{
    public class ProductPriceSpecs
    {
        public static readonly Expression<Func<ProductPriceInfo, ProductPriceCommandResult>> AsProductPriceCommandResult = x => new ProductPriceCommandResult()
        {
            IdProductPrice = x.IdProductPrice,
            IdProduct = x.IdProduct,
            Value = x.Value,
            EndDate = x.EndDate
        };
    }
}
