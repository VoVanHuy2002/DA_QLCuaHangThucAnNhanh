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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var success = false;
            using (var ctx = new DBContext())
            {
                var user = ctx.user_account.FirstOrDefault(item => item.username.Equals(txtUsername.Text));
                if (user != null)
                {
                    if (user.password.Equals(txtPassword.Text))
                    {
                        if (user.role_id == (int?)ROLE.STORE_OWNER || user.role_id == (int?)ROLE.CASH_STAFF)
                        {
                            success = true;
                            this.Hide();
                            new frmMain(user).ShowDialog();
                            this.Show();
                        }
                    }
                }
            }
            if (!success)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
            }
        }
    }
}
