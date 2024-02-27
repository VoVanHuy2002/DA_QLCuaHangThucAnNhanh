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
    public partial class frmCustomPopup : Form
    {
        private readonly order currentOrder;
        public frmCustomPopup(order o)
        {
            InitializeComponent();
            this.currentOrder = o;
        }
        private readonly List<order_items> cart;
        private readonly decimal currentTotal;
        public frmCustomPopup(List<order_items> order_Items, decimal total)
        {
            InitializeComponent();
            this.cart = order_Items;
            this.currentTotal = total;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCustomPopup_Load(object sender, EventArgs e)
        {

        }

        private void btnBank_Click(object sender, EventArgs e)
        {
            using (var ctx = new DBContext())
            {
                if (currentOrder != null)
                {
                    var order = ctx.orders.FirstOrDefault(item => item.order_id == currentOrder.order_id);
                    if (order != null)
                    {
                        order.status = "BANK";
                        ctx.SaveChanges();
                    }
                    var table = ctx.table_order.FirstOrDefault(item => item.table_id == currentOrder.table_id);
                    if (table != null)
                    {
                        table.available = "YES";
                        ctx.SaveChanges();
                    }
                    new frmPopupBill(order.order_id).ShowDialog();
                }
                else
                {
                    var newOrder = new order
                    {
                        total = Convert.ToDouble(currentTotal),
                        net_total = Convert.ToDouble(currentTotal),
                        progress = "WAITING",
                        status = "BANK",
                        date_buy = DateTime.Now,
                        discount = 0,
                        order_items = cart
                    };
                    var returnOrder = ctx.orders.Add(newOrder);
                    ctx.SaveChanges();
                    new frmPopupBill(returnOrder.order_id).ShowDialog();
                }

            }
            this.Close();
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            using (var ctx = new DBContext())
            {
                if (currentOrder != null)
                {
                    var order = ctx.orders.FirstOrDefault(item => item.order_id == currentOrder.order_id);
                    if (order != null)
                    {
                        order.status = "CASH";
                        ctx.SaveChanges();
                    }
                    var table = ctx.table_order.FirstOrDefault(item => item.table_id == currentOrder.table_id);
                    if (table != null)
                    {
                        table.available = "YES";
                        ctx.SaveChanges();
                    }
                    new frmPopupBill(order.order_id).ShowDialog();
                }
                else
                {
                    var newOrder = new order
                    {
                        total = Convert.ToDouble(currentTotal),
                        net_total = Convert.ToDouble(currentTotal),
                        progress = "WAITING",
                        status = "CASH",
                        date_buy = DateTime.Now,
                        discount = 0,
                        order_items = cart
                    };
                    var returnOrder = ctx.orders.Add(newOrder);
                    ctx.SaveChanges();
                    new frmPopupBill(returnOrder.order_id).ShowDialog();
                }
            }
            this.Close();
        }
    }
}
