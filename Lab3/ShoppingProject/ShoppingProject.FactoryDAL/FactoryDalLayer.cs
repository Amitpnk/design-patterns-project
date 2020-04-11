using ShoppingProject.ADOnetDAL;
using ShoppingProject.IDal;
using ShoppingProject.InterfaceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Resolution;

namespace ShoppingProject.FactoryDAL
{
    public static class FactoryDalLayer<AnyType> // Design pattern :- Simple factory pattern
    {
        private static IUnityContainer ObjectsofOurProjects = null;


        public static AnyType Create(string Type)
        {
            // Design pattern :- Lazy loading. Eager loading
            if (ObjectsofOurProjects == null)
            {
                ObjectsofOurProjects = new UnityContainer();

                ObjectsofOurProjects.RegisterType<IDal<ICustomer>,
                    CustomerDAL>("ADODal");
            }
            //Design pattern :-  RIP Replace If with Poly
            return ObjectsofOurProjects.Resolve<AnyType>(Type,
                                new ResolverOverride[]
                                {
                                       new ParameterOverride("_ConnectionString",
                                        @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CustomerDB_DP;Integrated Security=True")
                                }); ;
        }
    }
}
