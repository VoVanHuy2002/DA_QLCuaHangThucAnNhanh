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
    public partial class frmPayment : Form
    {
        private order currentOrder;
        public frmPayment()
        {
            InitializeComponent();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (currentOrder != null)
            {
                using (var confirmForm = new frmCustomPopup(currentOrder))
                {
                    confirmForm.ShowDialog();
                }
                resetForm();
                load();
            }
        }
        private void load()
        {
            using (var ctx = new DBContext())
            {
                ctx.table_order
                    .Where(item => item.status.Equals("ACTIVE"))
                    .ToList()
                    .ForEach(item =>
                    {
                        Button btn = new Button();
                        btn.BackColor = !item.available.Equals("YES") ? Color.LightBlue : Color.LightGray;
                        btn.Enabled = !item.available.Equals("YES");
                        btn.Width = 125;
                        btn.Height = 60;
                        btn.Text = $"{item.table_name}\n{translate(item.available)}";
                        btn.Tag = item;
                        btn.Click += btnChooseTable;
                        flpTable.Controls.Add(btn);
                    });
            }
        }
        private void resetForm()
        {
            txtBuyDate.ResetText();
            txtOrderId.ResetText();
            txtNameCus.ResetText();
            txtNameEmp.ResetText();
            txtPhone.ResetText();
            txtTotal.ResetText();
            txtTotalPrice.Text = "0 VND";
            txtDiscount.ResetText();
            txtTableName.ResetText();
            lvBill.Items.Clear();
            flpTable.Controls.Clear();
        }
        private void frmPayment_Load(object sender, EventArgs e)
        {
            load();
        }
        private string translate(string statusOfTable)
        {
            return statusOfTable.Equals("YES") ? "Còn trống" : "Có người ngồi";
        }
        private void btnChooseTable(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var tag = btn.Tag as table_order;
            if (tag != null)
            {
                using (var ctx = new DBContext())
                {
                    var order = ctx.orders
                        .Where(o => o.table_id == tag.table_id && o.status.Equals("PENDING"))
                        .OrderBy(o => o.order_id)
                        .ToList()
                        .FirstOrDefault();
                    txtOrderId.Text = order.order_id.ToString();
                    txtNameEmp.Text = order.user_account?.full_name;
                    txtNameCus.Text = order.customer?.customer_name;
                    txtPhone.Text = order.customer?.phone;
                    txtBuyDate.Text = order.date_buy.ToString();
                    txtDiscount.Text = order.discount.ToString();
                    txtTableName.Text = order.table_order?.table_name;
                    txtTotalPrice.Text = string.Format("{0:N0} VNĐ", order.net_total);
                    txtTotal.Text = string.Format("{0:N0} VNĐ", order.total);
                    currentOrder = order;

                    lvBill.Items.Clear();
                    order.order_items
                        .ToList()
                        .ForEach(item =>
                        {
                            ListViewItem lvi = new ListViewItem(item.food_id.ToString());
                            lvi.SubItems.Add(item.food.food_name);
                            lvi.SubItems.Add(string.Format("{0:N0} VNĐ", item.food.price)); // Định dạng đơn giá
                            lvi.SubItems.Add(item.quantity.ToString());
                            lvi.SubItems.Add(string.Format("{0:N0} VNĐ", item.total)); // Định dạng thành tiền
                            lvBill.Items.Add(lvi);
                        });

                    if(!order.progress.Equals("DONE"))
                    {
                        btnPayment.Enabled = false;
                        MessageBox.Show("Vui lòng đợi món ăn hoàn thành mới được thanh toán");
                    }
                    else
                    {
                        btnPayment.Enabled = true;
                    }
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtNameCus_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
