using DataLayer;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QLCuaHangThucAnNhanh
{
    public partial class frmMnFood : Form
    {
        private bool add = false;
        public frmMnFood()
        {
            InitializeComponent();
        }

        private void resetText()
        {
            txtId.ResetText(); 
            txtName.ResetText();
            nmrPrice.Value = 0;
            txtDes.ResetText();
            txtImage.ResetText();
            picFood.Image = null;
        }

        private void toggleTextbox(bool state)
        {
            txtName.Enabled = state;
            nmrPrice.Enabled = state;
            txtDes.Enabled = state;
            txtImage.Enabled = state;
            btnChoose.Enabled = state;
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
                dgvFood.DataSource = ctx.foods
                    .Where(item => item.status.Equals("ACTIVE"))
                    .Select(item => new
                    {
                        item.food_id,
                        item.food_name,
                        item.price,
                        item.description,
                        item.food_image
                    })
                    .ToList();

            }
        }

        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtId.Text = $"{dgvFood.Rows[e.RowIndex].Cells[0].Value ?? ""}";
            txtName.Text = $"{dgvFood.Rows[e.RowIndex].Cells[1].Value ?? ""}";
            nmrPrice.Value = Convert.ToDecimal(dgvFood.Rows[e.RowIndex].Cells[2].Value ?? 0);
            txtDes.Text = $"{dgvFood.Rows[e.RowIndex].Cells[3].Value ?? ""}";
            txtImage.Text = $"{dgvFood.Rows[e.RowIndex].Cells[4].Value ?? ""}";
            try
            {
                picFood.Image = new Bitmap(txtImage.Text);
            }
            catch (Exception)
            {
                picFood.Image = null;
            }

            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            btnSave.Enabled = false;
        }

        private void frmMnFood_Load(object sender, EventArgs e)
        {
            btnReload_Click(sender, e);
            dgvFood.Columns[0].HeaderText = "Mã món ăn";
            dgvFood.Columns[1].HeaderText = "Tên món ăn";
            dgvFood.Columns[2].HeaderText = "Giá tiền";
            dgvFood.Columns[3].HeaderText = "Mô tả";
            dgvFood.Columns[4].HeaderText = "Hình ảnh";
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
            return string.IsNullOrEmpty(txtName.Text.Trim())
                || string.IsNullOrEmpty(nmrPrice.Text.Trim())
                || string.IsNullOrEmpty(txtDes.Text.Trim());
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn món ăn để xóa");
                return;
            }

            if (MessageBox.Show("Bạn chắc chắn muốn xóa món ăn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var ctx = new DBContext())
                    {
                        var item_id = Convert.ToInt32( txtId.Text);
                        var user = ctx.foods
                            .FirstOrDefault(item => item.food_id == item_id);
                        if (user != null)
                        {
                            user.status = "INACTIVE";
                            ctx.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show($"Không tìm thấy món ăn này");
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
                        var ele = new food
                        {
                            food_name = txtName.Text.Trim(),
                            price = Convert.ToDouble(nmrPrice.Value),
                            description = txtDes.Text.Trim(),
                            food_image = txtImage.Text.Trim(),
                            food_image_adr = txtUpload.Text.Trim(),
                            status = "ACTIVE"
                        };
                        ctx.foods.Add(ele);
                        ctx.SaveChanges();
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        var item_id = Convert.ToInt32(txtId.Text);
                        var _item = ctx.foods
                            .FirstOrDefault(item => item.food_id == item_id);
                        if (_item != null)
                        {
                            _item.food_name = txtName.Text.Trim();
                            _item.price = Convert.ToDouble(nmrPrice.Value);
                            _item.description = txtDes.Text.Trim();
                            _item.food_image = txtImage.Text.Trim();
                            _item.food_image_adr = txtUpload.Text.Trim();
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

        private void btnReload_Click(object sender, EventArgs e)
        {
            resetText();
            disableButton();
            toggleTextbox(false);
            loadData();
        }


        private void btnChoose_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog open = new OpenFileDialog())
                {
                    // image filters  
                    open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        // Lấy đường dẫn của tệp được chọn
                        string selectedImagePath = open.FileName;

                        // root path
                        string path = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;

                        // Tạo một đường dẫn mới để lưu bản sao vào thư mục ./images/
                        string destinationPath = Path.Combine(
                                            path,
                                            "images",
                                            Path.GetFileName(selectedImagePath));

                        if (!File.Exists(destinationPath))
                        {
                            // Sao chép tệp hình ảnh vào thư mục ./images/
                            File.Copy(selectedImagePath, destinationPath, true);
                        }
                        // Cập nhật đường dẫn tương đối trong txtImage.Text
                        txtImage.Text = destinationPath;
                        // Hiển thị hình ảnh trong pictureBox
                        picFood.Image = new Bitmap(destinationPath);
                        CloudinaryHelper helper = new CloudinaryHelper();
                        txtUpload.Text =  helper.uploadImage(selectedImagePath);
                    }
                }
            }
            catch (Exception)
            {
            }

        }
    }
}
