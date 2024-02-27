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
    public partial class frmPopupBill : Form
    {
        int orderId;
        public frmPopupBill(int orderid)
        {
            InitializeComponent();
            orderId = orderid;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPopupBill_Load(object sender, EventArgs e)
        {
            using(var ctx = new DBContext())
            {
                var order = ctx.orders
                    .FirstOrDefault(item => item.order_id == orderId);

                if (order != null)
                {
                    txtCusName.Text = order?.customer?.customer_name ?? "N/A";
                    txtEmpName.Text = order?.user_account?.full_name ?? "N/A";
                    txtTable.Text = order?.table_order?.table_name ?? "N/A";
                    txtDate.Text = $"{order?.date_buy}";
                    txtTotal.Text = $"{string.Format("{0:N0} VNĐ", order.total)}";
                    txtNetTotal.Text = $"{string.Format("{0:N0} VNĐ", order.total)}";
                    txtPoint.Text = $"{order?.customer?.point ?? 0}";
                    txtDiscount.Text = $"{order?.discount ?? 0}%";

                    order.order_items
                        .ToList()
                        .ForEach(item =>
                        {
                            ListViewItem lvi = new ListViewItem(item.food_id.ToString());
                            lvi.SubItems.Add(item.food.food_name);
                            lvi.SubItems.Add(string.Format("{0:N0} VNĐ", item.food.price)); // Định dạng đơn giá
                            lvi.SubItems.Add(item.quantity.ToString());
                            lvi.SubItems.Add(string.Format("{0:N0} VNĐ", item.total)); // Định dạng thành tiền
                            lvOrder.Items.Add(lvi);
                        });
                }
            }
        }
    }
}
