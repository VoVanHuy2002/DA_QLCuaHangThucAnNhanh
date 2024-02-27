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
    public partial class frmMain : Form
    {
        private user_account currentUser;
        public frmMain(user_account user)
        {
            InitializeComponent();
            this.currentUser = user;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reInitComponent()
        {
            if(currentUser.role_id == (int?)ROLE.CASH_STAFF)
            {
                btnDashboard.Visible = false;
                btnEmployee.Visible = false;
                btnOrder.Visible = false;
            }
            frmPayment frm = new frmPayment();
            frm.TopLevel = false;
            pnContent.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            reInitComponent();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();   
            frmMnTable frm = new frmMnTable();
            frm.TopLevel = false;
            pnContent.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            frmMnFood frm = new frmMnFood();
            frm.TopLevel = false;
            pnContent.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();

            frmMnStaff frm = new frmMnStaff();
            frm.TopLevel = false;
            pnContent.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();

            frmDashboard frm = new frmDashboard();
            frm.TopLevel = false;
            pnContent.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();

            frmMnOrder frm = new frmMnOrder();
            frm.TopLevel = false;
            pnContent.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();

            var frm = new frmPayment();
            frm.TopLevel = false;
            pnContent.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnWaitingOrder_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();

            var frm = new frmMnWaitingOrder();
            frm.TopLevel = false;
            pnContent.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnManaCus_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();

            var frm = new frmMnCustomer();
            frm.TopLevel = false;
            pnContent.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnTakeAway_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();

            var frm = new frmTakeAway();
            frm.TopLevel = false;
            pnContent.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
    }
}
