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
using static System.Net.Mime.MediaTypeNames;

namespace QLCuaHangThucAnNhanh
{
    public partial class frmMnTable : Form
    {
        private bool add = false;
        public frmMnTable()
        {
            InitializeComponent();
        }

        private void resetText()
        {
            txtID.ResetText();
            txtName.ResetText();
            txtDes.ResetText();
        }

        private void toggleTextbox(bool state)
        {
            txtName.Enabled = state;
            txtDes.Enabled = state;
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
                dgvTable.DataSource = ctx.table_order
                    .Where(item => item.status.Equals("ACTIVE")).ToList()
                    .Select(item => new
                    {
                        item.table_id,
                        item.table_name,
                        item.description
                    })
                    .ToList();
            }
            loadFlpTable();
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtID.Text = $"{dgvTable.Rows[e.RowIndex].Cells[0].Value ?? ""}";
            txtName.Text = $"{dgvTable.Rows[e.RowIndex].Cells[1].Value ?? ""}";
            txtDes.Text = $"{dgvTable.Rows[e.RowIndex].Cells[2].Value ?? ""}";

            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            btnSave.Enabled = false;
        }

        private void frmMnTable_Load(object sender, EventArgs e)
        {
            btnReload_Click(sender, e);
            dgvTable.Columns[0].HeaderText = "Mã nhân viên";
            dgvTable.Columns[1].HeaderText = "Tên bàn";
            dgvTable.Columns[2].HeaderText = "Mô tả";
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            resetText();
            disableButton();
            toggleTextbox(false);
            loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isEmptyInput())
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
                        var table = new table_order
                        {
                            table_name = txtName.Text.Trim(),
                            description = txtDes.Text.Trim(),
                            available = "YES",
                            status = "ACTIVE"
                        };
                        ctx.table_order.Add(table);
                        ctx.SaveChanges();
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        var tbId = Convert.ToInt32(txtID.Text);
                        var tb = ctx.table_order
                            .FirstOrDefault(item => item.table_id == tbId);
                        if (tb != null)
                        {
                            tb.table_name = txtName.Text.Trim();
                            tb.description = txtDes.Text.Trim();
                            ctx.SaveChanges();
                            MessageBox.Show("Chỉnh thông tin thành công");
                        }

                    }
                }
                btnReload_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void loadFlpTable()
        {
            flpTable.Controls.Clear();
            using (var ctx = new DBContext())
            {
                ctx.table_order
                    .Where(item => item.status.Equals("ACTIVE"))
                    .ToList()
                    .ForEach(item =>
                    {
                        Button btn = new Button();
                        btn.BackColor = item.available.Equals("YES") ? Color.LightBlue : Color.LightGray;
                        btn.Enabled = item.available.Equals("YES");
                        btn.Width = 120;
                        btn.Height = 60;
                        btn.Text = $"{item.table_name}\n{translate(item.available)}";
                        btn.Tag = item;
                        flpTable.Controls.Add(btn);
                    });
            }
        }
        private string translate(string statusOfTable)
        {
            return statusOfTable.Equals("YES") ? "Còn trống" : "Có người ngồi";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            add = true;
            toggleTextbox(true);
            resetText();
            enableButton();
            txtName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            add = false;
            toggleTextbox(true);
            enableButton();
            txtName.Focus();
        }
        private bool isEmptyInput()
        {
            return string.IsNullOrEmpty(txtName.Text.Trim());
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn bàn xóa");
                return;
            }

            if (MessageBox.Show("Bạn chắc chắn muốn xóa bàn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var ctx = new DBContext())
                    {
                        var tbId = Convert.ToInt32(txtID.Text);
                        var table = ctx.table_order
                            .FirstOrDefault(item => item.table_id == tbId);
                        if (table != null)
                        {
                            table.status = "INACTIVE";
                            ctx.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show($"Không tìm thấy bàn này");
                        }
                    }
                    btnReload_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
        }
    }
}
