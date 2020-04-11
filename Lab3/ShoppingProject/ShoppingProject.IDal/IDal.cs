using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.IDal
{
    // Design pattern :- Generic Repository pattern
    public interface IDal<AnyType>
    {
        void Add(AnyType obj); // Inmemory addition
        void Update(AnyType obj);  // Inmemory updation
        List<AnyType> Search();
        void Save(); // Physical committ
    }
}
