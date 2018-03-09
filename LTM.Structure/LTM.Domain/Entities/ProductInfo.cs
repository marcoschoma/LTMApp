using System;
using System.Collections.Generic;
using System.Text;
using LTM.Domain.Commands.Input;

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
    }
}
