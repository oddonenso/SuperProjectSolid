using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICommand<in T> where T : class
    {
        void Execute(T obj);
    }
}
