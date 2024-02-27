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
using System.Xml.Linq;

namespace QLCuaHangThucAnNhanh
{
    public partial class frmMnCustomer : Form
    {
        private bool add = false;
        private List<customer> listCustomer;
        public frmMnCustomer()
        {
            InitializeComponent();
            listCustomer = new List<customer>();
        }

        private void resetText()
        {
            txtCusId.ResetText();
            txtCusname.ResetText();
            txtPhone.ResetText();
            txtPoint.ResetText();
        }

        private void toggleTextbox(bool state)
        {
            txtCusname.Enabled = state;
            txtPhone.Enabled = state;
        }

        private void disableButton()
        {
            btnAdd.Enabled = true;

            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            btnSave.Enabled = false;
        }

        private void enableButton()
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;

            btnSave.Enabled = true;
        }

        private void loadData()
        {
            using (var ctx = new DBContext())
            {
                listCustomer = ctx.customers
                    .Where(item => item.status.Equals("ACTIVE"))
                    .ToList();
                dgvCustomer.DataSource = listCustomer
                    .Select(item => new
                    {
                        item.customer_id,
                        item.customer_name,
                        item.phone,
                        item.point,
                    })
                    .ToList();

            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtCusId.Text = $"{listCustomer[e.RowIndex].customer_id}";
            txtCusname.Text = $"{listCustomer[e.RowIndex].customer_name}";
            txtPhone.Text = $"{listCustomer[e.RowIndex].phone}";
            txtPoint.Text = $"{listCustomer[e.RowIndex].point}";

            btnEdit.Enabled = true;
            btnDel.Enabled = true;

            btnSave.Enabled = false;
        }

        private void frmMnCustomer_Load(object sender, EventArgs e)
        {
            toggleTextbox(false);
            disableButton();
            loadData();
            dgvCustomer.Columns[0].HeaderText = "Mã khách hàng";
            dgvCustomer.Columns[1].HeaderText = "Tên khách hàng";
            dgvCustomer.Columns[2].HeaderText = "Số điện thoại";
            dgvCustomer.Columns[3].HeaderText = "Điểm";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            add = true;
            toggleTextbox(true);
            resetText();
            enableButton();
            txtCusname.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            add = false;
            toggleTextbox(true);
            enableButton();
            txtCusname.Focus();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCusId.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa");
                return;
            }

            if (MessageBox.Show("Bạn chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var ctx = new DBContext())
                    {
                        var item_id = Convert.ToInt32(txtCusId.Text);
                        var user = ctx.foods
                            .FirstOrDefault(item => item.food_id == item_id);
                        if (user != null)
                        {
                            user.status = "INACTIVE";
                            ctx.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show($"Không tìm thấy khách hàng này");
                        }
                    }
                    btnCancel_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            resetText();
            disableButton();
            toggleTextbox(false);
            loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtCusname.Text))
            {
                MessageBox.Show("Vui lòng không bỏ trống thông tin nhập");
                return;
            }

            try
            {
                using (var ctx = new DBContext())
                {
                    if (add)
                    {
                        var isExist = ctx.customers.FirstOrDefault(i => i.phone.Equals(txtPhone.Text));
                        if (isExist != null)
                        {
                            MessageBox.Show("Số điện thoại đã tồn tại");
                            return;
                        }

                        var ele = new customer
                        {
                            customer_name = txtCusname.Text,
                            phone = txtPhone.Text,
                            point = 0,
                            status = "ACTIVE"
                        };
                        ctx.customers.Add(ele);
                        ctx.SaveChanges();
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        var item_id = Convert.ToInt32(txtCusId.Text);
                        var isExist = ctx.customers.FirstOrDefault(i => i.phone.Equals(txtPhone.Text) && i.customer_id != item_id);
                        if (isExist != null)
                        {
                            MessageBox.Show("Số điện thoại đã tồn tại");
                            return;
                        }

                        var _item = ctx.customers
                            .FirstOrDefault(item => item.customer_id == item_id);
                        if (_item != null)
                        {
                            _item.customer_name = txtCusname.Text.Trim();
                            _item.phone = txtPhone.Text.Trim();
                            ctx.SaveChanges();
                            MessageBox.Show("Chỉnh thông tin thành công");
                        }

                    }
                }
                btnCancel_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
    }
}
