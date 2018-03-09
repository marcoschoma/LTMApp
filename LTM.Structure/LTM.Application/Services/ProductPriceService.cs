using LTM.Domain.Commands.Input.ProductPrice;
using LTM.Domain.Repositories;
using LTM.Domain.Services;
using LTM.Infra.Data.Base;
using LTM.Infra.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Application.Services
{
    public class ProductPriceService : ApplicationService, IProductPriceService
    {
        private readonly IProductPriceRepository _repository;
        //private readonly ProductCommandHandler _handler;

        public ProductPriceService(IUnitOfWork uow) : base(uow) { }

        public void CreateNewPrice(InsertProductPriceCommand insertProductPriceCommand)
        {
            throw new NotImplementedException();
        }
    }
}
