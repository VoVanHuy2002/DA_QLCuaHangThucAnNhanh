namespace QLCuaHangThucAnNhanh
{
    partial class frmPayment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvBill = new System.Windows.Forms.ListView();
            this.foodId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.foodName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.totalItemPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnPayment = new System.Windows.Forms.Button();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNameEmp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNameCus = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBuyDate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.BackColor = System.Drawing.Color.LightSkyBlue;
            this.flpTable.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpTable.Location = new System.Drawing.Point(0, 0);
            this.flpTable.Name = "flpTable";
            this.flpTable.Padding = new System.Windows.Forms.Padding(20);
            this.flpTable.Size = new System.Drawing.Size(452, 720);
            this.flpTable.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lvBill);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(452, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 720);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(725, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hóa đơn thanh toán";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTableName);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtTotal);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtDiscount);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtBuyDate);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtPhone);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtNameCus);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtOrderId);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtNameEmp);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(725, 204);
            this.panel2.TabIndex = 5;
            // 
            // lvBill
            // 
            this.lvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.foodId,
            this.foodName,
            this.price,
            this.quantity,
            this.totalItemPrice});
            this.lvBill.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvBill.FullRowSelect = true;
            this.lvBill.GridLines = true;
            this.lvBill.HideSelection = false;
            this.lvBill.Location = new System.Drawing.Point(0, 263);
            this.lvBill.MultiSelect = false;
            this.lvBill.Name = "lvBill";
            this.lvBill.Size = new System.Drawing.Size(725, 397);
            this.lvBill.TabIndex = 6;
            this.lvBill.UseCompatibleStateImageBehavior = false;
            this.lvBill.View = System.Windows.Forms.View.Details;
            // 
            // foodId
            // 
            this.foodId.Text = "Mã món ăn";
            this.foodId.Width = 120;
            // 
            // foodName
            // 
            this.foodName.Text = "Tên món ăn";
            this.foodName.Width = 250;
            // 
            // quantity
            // 
            this.quantity.Text = "Số lượng";
            this.quantity.Width = 120;
            // 
            // totalItemPrice
            // 
            this.totalItemPrice.Text = "Thành tiền";
            this.totalItemPrice.Width = 150;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnPayment);
            this.panel3.Controls.Add(this.txtTotalPrice);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 660);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(725, 60);
            this.panel3.TabIndex = 7;
            // 
            // btnPayment
            // 
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.Location = new System.Drawing.Point(541, 15);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(128, 36);
            this.btnPayment.TabIndex = 7;
            this.btnPayment.Text = "Thanh toán";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalPrice.Enabled = false;
            this.txtTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.txtTotalPrice.Location = new System.Drawing.Point(257, 15);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(253, 36);
            this.txtTotalPrice.TabIndex = 6;
            this.txtTotalPrice.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tổng tiền sau khi giảm giá:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên nhân viên:";
            // 
            // txtNameEmp
            // 
            this.txtNameEmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNameEmp.Enabled = false;
            this.txtNameEmp.Location = new System.Drawing.Point(156, 60);
            this.txtNameEmp.Name = "txtNameEmp";
            this.txtNameEmp.ReadOnly = true;
            this.txtNameEmp.Size = new System.Drawing.Size(255, 30);
            this.txtNameEmp.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-1, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tên khách hàng:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtNameCus
            // 
            this.txtNameCus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNameCus.Enabled = false;
            this.txtNameCus.Location = new System.Drawing.Point(156, 96);
            this.txtNameCus.Name = "txtNameCus";
            this.txtNameCus.ReadOnly = true;
            this.txtNameCus.Size = new System.Drawing.Size(255, 30);
            this.txtNameCus.TabIndex = 1;
            this.txtNameCus.TextChanged += new System.EventHandler(this.txtNameCus_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-1, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Số điện thoại:";
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Enabled = false;
            this.txtPhone.Location = new System.Drawing.Point(156, 132);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(255, 30);
            this.txtPhone.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(430, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Chiết khấu:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtDiscount
            // 
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscount.Enabled = false;
            this.txtDiscount.Location = new System.Drawing.Point(541, 130);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Size = new System.Drawing.Size(172, 30);
            this.txtDiscount.TabIndex = 1;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-1, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ngày:";
            // 
            // txtBuyDate
            // 
            this.txtBuyDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuyDate.Enabled = false;
            this.txtBuyDate.Location = new System.Drawing.Point(156, 168);
            this.txtBuyDate.Name = "txtBuyDate";
            this.txtBuyDate.ReadOnly = true;
            this.txtBuyDate.Size = new System.Drawing.Size(255, 30);
            this.txtBuyDate.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(430, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Bàn:";
            this.label8.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtTableName
            // 
            this.txtTableName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTableName.Enabled = false;
            this.txtTableName.Location = new System.Drawing.Point(541, 94);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.ReadOnly = true;
            this.txtTableName.Size = new System.Drawing.Size(172, 30);
            this.txtTableName.TabIndex = 1;
            this.txtTableName.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(-1, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 25);
            this.label9.TabIndex = 0;
            this.label9.Text = "Mã hóa đơn:";
            // 
            // txtOrderId
            // 
            this.txtOrderId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderId.Enabled = false;
            this.txtOrderId.Location = new System.Drawing.Point(156, 24);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.ReadOnly = true;
            this.txtOrderId.Size = new System.Drawing.Size(255, 30);
            this.txtOrderId.TabIndex = 1;
            // 
            // price
            // 
            this.price.Text = "Đơn giá";
            this.price.Width = 120;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(430, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 25);
            this.label10.TabIndex = 0;
            this.label10.Text = "Thành tiền:";
            this.label10.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(541, 166);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(172, 30);
            this.txtTotal.TabIndex = 1;
            this.txtTotal.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 720);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpTable);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmPayment";
            this.Text = "frmPayment";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvBill;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColumnHeader foodId;
        private System.Windows.Forms.ColumnHeader foodName;
        private System.Windows.Forms.ColumnHeader quantity;
        private System.Windows.Forms.ColumnHeader totalItemPrice;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNameEmp;
        private System.Windows.Forms.TextBox txtNameCus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBuyDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label10;
    }
}