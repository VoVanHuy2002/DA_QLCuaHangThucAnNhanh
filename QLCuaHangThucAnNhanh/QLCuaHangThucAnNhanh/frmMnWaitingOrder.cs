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
    public partial class frmMnWaitingOrder : Form
    {
        public frmMnWaitingOrder()
        {
            InitializeComponent();
        }

        bool isWaitingList = true;

        private void loadData()
        {
            flpOrder.Controls.Clear();
            var text = isWaitingList ? "WAITING" : "IN PROGRESS";
            using(var ctx = new DBContext())
            {
                var list = ctx.orders
                    .Where(item => item.progress.Equals(text))
                    .ToList();
                list.ForEach(item =>
                {
                   var frmitem =   new frmItemRowOrder(item?.table_order?.table_name,
                                item?.customer?.customer_name,
                                item?.customer?.phone,
                                Convert.ToInt32(item?.order_items.Count),
                                Convert.ToDateTime(item.date_buy)
                        );
                    frmitem.TopLevel = false;
                    frmitem.Show();
                    flpOrder.Controls.Add(frmitem);
                });
            }
        }

        private void frmMnWaitingOrder_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnWaiting_Click(object sender, EventArgs e)
        {
            isWaitingList = true;
            loadData();
        }

        private void btnInprogress_Click(object sender, EventArgs e)
        {
            isWaitingList = false;
            loadData();
        }
    }
}
