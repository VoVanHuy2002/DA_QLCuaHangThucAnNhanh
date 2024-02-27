using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
namespace QLCuaHangThucAnNhanh
{
    public partial class ucMenu : UserControl
    {
        food currentFood;
        public ucMenu(food item)
        {
            InitializeComponent();
            this.currentFood = item;
        }

        private void ucMenu_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = new Bitmap(currentFood.food_image);
            }
            catch (Exception)
            {
                pictureBox1.Image = pictureBox1.ErrorImage;
            }
            var price = string.Format("{0:N0} VND", currentFood.price);
            label1.Text = $"{currentFood.food_name}\n{price}";
        }
    }
}
