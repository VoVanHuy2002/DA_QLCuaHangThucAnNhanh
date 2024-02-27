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
    public partial class frmItemRowOrder : Form
    {

        public frmItemRowOrder(string tableName, string cusName, string cusPhone, int quantityItem, DateTime date)
        {
            InitializeComponent();
            txtCusname.Text = cusName;
            txtCusPhone.Text = cusPhone;
            btnTable.Text += tableName;
            lbQuantityItem.Text += $"{quantityItem}";
            txtDate.Text = $"{date.ToString()}";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
