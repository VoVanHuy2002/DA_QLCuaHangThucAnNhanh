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
    public partial class frmTakeAway : Form
    {
        private List<order_items> order_items;
        private Dictionary<food, int> cart;
        private decimal currentAmout = 0;
        public frmTakeAway()
        {
            InitializeComponent();
            order_items = new List<order_items>();
            cart = new Dictionary<food, int>();
        }

        private void frmTakeAway_Load(object sender, EventArgs e)
        {
            using (var ctx = new DBContext())
            {
                ctx.foods
                    .Where(item => item.status.Equals("ACTIVE"))
                    .ToList()
                    .ForEach(item =>
                    {
                        var uc = new ucMenu(item);
                        uc.pictureBox1.Click +=
                          (s, euc) =>
                          {
                              if (cart.ContainsKey(item))
                              {
                                  cart[item]++;
                              }
                              else
                              {
                                  cart.Add(item, 1);
                              }
                              var f = order_items.FirstOrDefault(item1 => item1.food_id == item.food_id);
                              if (f != null)
                              {
                                  f.quantity++;
                                  f.total += item.price;
                              }
                              else
                              {
                                  order_items.Add(new order_items
                                  {
                                      food_id = item.food_id,
                                      quantity = 1,
                                      total = item.price
                                  });
                              }
                              renderListView();
                          };

                        uc.label1.Click += (s, euc) =>
                        {
                            if (cart.ContainsKey(item))
                            {
                                cart[item]++;
                            }
                            else
                            {
                                cart.Add(item, 1);
                            }
                            var f = order_items.FirstOrDefault(item1 => item1.food_id == item.food_id);
                            if (f != null)
                            {
                                f.quantity++;
                                f.total += item.price;
                            }
                            else
                            {
                                order_items.Add(new order_items
                                {
                                    food_id = item.food_id,
                                    quantity = 1,
                                    total = item.price
                                });
                            }
                            renderListView();
                        };
                        flpMenu.Controls.Add(uc);
                    });
            }
        }

        private void renderListView()
        {
            lvBill.Items.Clear();
            currentAmout = 0;
            foreach (var cart_item in cart)
            {
                var item = cart_item.Key;
                ListViewItem lvi = new ListViewItem(item.food_id.ToString());
                lvi.SubItems.Add(item.food_name);
                lvi.SubItems.Add(string.Format("{0:N0} VNĐ", item.price)); // Định dạng đơn giá
                lvi.SubItems.Add(cart_item.Value.ToString());
                lvi.SubItems.Add(string.Format("{0:N0} VNĐ", (item.price * cart_item.Value))); // Định dạng thành tiền
                lvBill.Items.Add(lvi);
                currentAmout += Convert.ToDecimal((item.price * cart_item.Value));
            }
            txtTotal.Text = string.Format("{0:N0} VNĐ", currentAmout);
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            using (var confirmForm = new frmCustomPopup(order_items, currentAmout))
            {
                confirmForm.ShowDialog();
            }
            txtTotal.Text = "0 VND";
            lvBill.Items.Clear();
        }
    }
}
