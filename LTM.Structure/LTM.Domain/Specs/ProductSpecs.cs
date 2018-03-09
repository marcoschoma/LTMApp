using LTM.Domain.Commands.Results;
using LTM.Domain.Entities;
using System;
using System.Collections.Generic;
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
    }
}
