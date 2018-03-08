using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Domain.Entities
{
    public class ProductInfo : EntityInfo
    {
        public int? IdProduct { get; set; }

        public string Description { get; set; }
    }
}
