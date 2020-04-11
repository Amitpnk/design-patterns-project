using ShoppingProject.Factory;
using ShoppingProject.InterfaceDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingProject.WindowsCustomerUI
{
    public partial class FrmCustomer : Form
    {
        private ICustomer customer = null;

        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {

        }

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            customer = SimpleFactory.Create(cmbCustomerType.Text);
        }

        void SetCustomer()
        {
            customer.CustomerName = txtCustomerName.Text;
            customer.PhoneNumber = txtPhoneNumber.Text;
            customer.BillDate = Convert.ToDateTime(txtBillDate.Text);
            customer.BillAmount = Convert.ToDecimal(txtBillAmount.Text);
            customer.Address = txtAddress.Text;
        }
        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                SetCustomer();
                customer.Validate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
