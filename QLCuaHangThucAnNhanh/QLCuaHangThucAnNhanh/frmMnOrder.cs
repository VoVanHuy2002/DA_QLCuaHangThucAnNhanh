using DataLayer;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QLCuaHangThucAnNhanh
{
    public partial class frmMnOrder : Form
    {
        public frmMnOrder()
        {
            InitializeComponent();
        }

        private void frmMnOrder_Load(object sender, EventArgs e)
        {
            using (var ctx = new DBContext())
            {
                var list = ctx.orders.ToList();
                dgvOrder.DataSource = list
                    .Select(item => new
                    {
                        item.order_id,
                        empName = item.user_account?.username ?? "",
                        cusName = item.customer?.customer_name ?? "",
                        cusPhone = item.customer?.phone ?? "",
                        item.date_buy,
                        item.total,
                        item.discount,
                        item.net_total,
                        item.status
                    }).ToList();
            }
            dgvOrder.Columns[0].HeaderText = "Mã hóa đơn";
            dgvOrder.Columns[1].HeaderText = "Tên nhân viên";
            dgvOrder.Columns[2].HeaderText = "Tên khách hàng";
            dgvOrder.Columns[3].HeaderText = "Số điện thoại";
            dgvOrder.Columns[4].HeaderText = "Ngày mua";
            dgvOrder.Columns[5].HeaderText = "Tổng tiền";
            dgvOrder.Columns[6].HeaderText = "Giảm giá";
            dgvOrder.Columns[7].HeaderText = "Thành tiền";
            dgvOrder.Columns[8].HeaderText = "Trạng thái";
        }
    }
}
