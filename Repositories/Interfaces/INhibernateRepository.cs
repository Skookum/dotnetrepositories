using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Interfaces
{
    public interface INhibernateRepository : IRepository
    {
        void Flush();
    }
}
