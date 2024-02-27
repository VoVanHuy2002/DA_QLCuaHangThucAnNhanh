using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCuaHangThucAnNhanh
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            using (var ctx = new DBContext())
            {
                // Nhan vien
                var totalEmp = ctx.user_account
                    .Where(item => item.role_id != 1)
                    .ToList()
                    .Count;
                var totalCurrentEmp = ctx.user_account
                    .Where(item => item.user_id != 1 && item.status.Equals("ACTIVE"))
                    .ToList()
                    .Count;
                var totalEmpOrder = ctx.user_account
                    .Where(item => item.role_id == 3 && item.status.Equals("ACTIVE"))
                    .ToList()
                    .Count;
                var totalEmpCash = ctx.user_account
                    .Where(item => item.role_id == 4 && item.status.Equals("ACTIVE"))
                    .ToList()
                    .Count;
                var totalBatender = ctx.user_account
                    .Where(item => item.role_id == 2 && item.status.Equals("ACTIVE"))
                    .ToList()
                    .Count;
                var totalEmpInactive = totalEmp - totalCurrentEmp;
                txtSumCurrentEmp.Text = totalCurrentEmp.ToString();
                txtSumEmp.Text = totalEmp.ToString();
                txtSumInactiveEmp.Text = totalEmpInactive.ToString();
                txtSumEmpOrder.Text = totalEmpOrder.ToString();
                txtSumEmpBartender.Text = totalBatender.ToString();
                txtSumEmpCash.Text = totalEmpCash.ToString();

                // Mon an
                var totalFood = ctx.foods
                    .ToList().Count;
                var totalFoodCurrent = ctx.foods
                    .Where(item => item.status.Equals("ACTIVE"))
                    .ToList()
                    .Count;
                var totalFoodInactive = totalFood - totalFoodCurrent;
                txtSumFood.Text = totalFood.ToString();
                txtSumFoodCurrent.Text = totalFoodCurrent.ToString();
                txtSumFoodInactive.Text = totalFoodInactive.ToString();

                // customer
                var totalCurrentCustomer = ctx.customers
                    .Where(item => item.status.Equals("ACTIVE"))
                    .ToList()
                    .Count;
                var totalCus200 = ctx.customers
                    .Where(item => item.status.Equals("ACTIVE") && item.point >= 200 && item.point <= 400)
                    .ToList()
                    .Count;

                var totalCus400 = ctx.customers
                    .Where(item => item.status.Equals("ACTIVE") && item.point >= 400 && item.point <= 600)
                    .ToList()
                    .Count;

                var totalCus600 = ctx.customers
                    .Where(item => item.status.Equals("ACTIVE") && item.point >= 600 && item.point <= 800)
                    .ToList()
                    .Count;

                var totalCus800 = ctx.customers
                    .Where(item => item.status.Equals("ACTIVE") && item.point >= 800)
                    .ToList()
                    .Count;
                txtCus200.Text = totalCus200.ToString();
                txtCus400.Text = totalCus400.ToString();
                txtCus600.Text = totalCus600.ToString();
                txtCus800.Text = totalCus800.ToString();
                txtSumCusCurrent.Text = totalCurrentCustomer.ToString();


                // Hoa don
                DateTime currentDate = DateTime.Now;
                var totalRevenueInMonth = ctx.orders
                    .Where(item => (item.status.Equals("CASH") || item.status.Equals("BANK"))
                                        && item.date_buy.Value.Year == currentDate.Year
                                        && item.date_buy.Value.Month == currentDate.Month)
                    .Sum(item => item.net_total);
                var totalDiscountInMonh = ctx.orders
                    .Where(item => (item.status.Equals("CASH") || item.status.Equals("BANK"))
                                        && item.date_buy.Value.Year == currentDate.Year
                                        && item.date_buy.Value.Month == currentDate.Month)
                    .Sum(item => (item.total - item.net_total));
                var totalOrderInMonth = ctx.orders
                    .Where(item => (item.status.Equals("CASH") || item.status.Equals("BANK"))
                                        && item.date_buy.Value.Year == currentDate.Year
                                        && item.date_buy.Value.Month == currentDate.Month)
                    .ToList()
                    .Count;
                var totalRevenue = ctx.orders
                    .Where(item => (item.status.Equals("CASH") || item.status.Equals("BANK")))
                    .Sum(item => item.net_total);
                var totalDiscount = ctx.orders
                    .Where(item => (item.status.Equals("CASH") || item.status.Equals("BANK")))
                    .Sum(item => (item.total - item.net_total));
                txtRevenueInMonth.Text = string.Format("{0:N0} VNĐ", totalRevenueInMonth);
                txtSumDiscountInMonth.Text = string.Format("{0:N0} VNĐ", totalDiscountInMonh);
                txtSumOrderInMonth.Text = string.Format("{0:N0} VNĐ", totalOrderInMonth);
                txtSumRevenue.Text = string.Format("{0:N0} VNĐ", totalRevenue);
                txtSumDiscount.Text = string.Format("{0:N0} VNĐ", totalDiscount);
            }
        }
    }
}
