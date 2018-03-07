using LTM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Domain.Repositories
{
    public interface IRepository<T> where T : EntityInfo
    {
    }
}
