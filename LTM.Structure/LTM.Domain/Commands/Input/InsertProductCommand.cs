using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Domain.Commands.Input
{
    public class InsertProductCommand
    {
        public int IdProduct { get; set; }
        public string Description { get; set; }
    }
}
