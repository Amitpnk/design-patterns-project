using ShoppingProject.IDal;
using ShoppingProject.InterfaceDomain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingProject.Factory;

namespace ShoppingProject.ADOnetDAL
{
    public class CustomerDAL : TemplateADO<ICustomer>, IDal<ICustomer>
    {
        public CustomerDAL(string _ConnectionString)
            : base(_ConnectionString)
        {

        }

        protected override List<ICustomer> ExecuteCommand()
        {
            objCommand.CommandText = "select * from tblCustomer";
            SqlDataReader dr = null;
            dr = objCommand.ExecuteReader();
            List<ICustomer> custs = new List<ICustomer>();
            while (dr.Read())
            {
                ICustomer icust = SimpleFactory<ICustomer>.Create("Customer");
                icust.CustomerName = dr["CustomerName"].ToString();
                icust.BillDate = Convert.ToDateTime(dr["BillDate"]);
                icust.BillAmount = Convert.ToDecimal(dr["BillAmount"]);
                icust.PhoneNumber = dr["PhoneNumber"].ToString();
                icust.Address = dr["Address"].ToString();
                custs.Add(icust);
            }
            return custs;
        }
        protected override void ExecuteCommand(ICustomer obj)
        {
            objCommand.CommandText = "insert into tblCustomer(" +
                                            "CustomerName," +
                                            "BillAmount,BillDate," +
                                            "PhoneNumber,Address)" +
                                            "values('" + obj.CustomerName + "'," +
                                            obj.BillAmount + ",'" +
                                            obj.BillDate + "','" +
                                            obj.PhoneNumber + "','" +
                                            obj.Address + "')";
            objCommand.ExecuteNonQuery();
        }
    }

}
