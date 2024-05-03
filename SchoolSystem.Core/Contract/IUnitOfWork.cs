using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Contract
{
    public interface IUnitOfWork<T> where T : class,new()
    {
        IBaseRepository<T> GenericRepository { get; }

    }
}
