using LTM.Domain.Commands.Input.ProductPrice;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Domain.Services
{
    public interface IProductPriceService
    {
        void CreateNewPrice(InsertProductPriceCommand insertProductPriceCommand);
    }
}
