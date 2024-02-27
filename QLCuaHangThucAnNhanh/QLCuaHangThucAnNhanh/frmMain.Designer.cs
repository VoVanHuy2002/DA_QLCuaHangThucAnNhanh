namespace QLCuaHangThucAnNhanh
{
    partial class frmMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnFood = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnTable = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnWaitingOrder = new System.Windows.Forms.Button();
            this.btnManaCus = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnContent = new System.Windows.Forms.Panel();
            this.btnTakeAway = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 70, 0, 0);
            this.panel1.Size = new System.Drawing.Size(223, 800);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoScrollMargin = new System.Drawing.Size(20, 50);
            this.flowLayoutPanel1.Controls.Add(this.btnDashboard);
            this.flowLayoutPanel1.Controls.Add(this.btnEmployee);
            this.flowLayoutPanel1.Controls.Add(this.btnFood);
            this.flowLayoutPanel1.Controls.Add(this.btnOrder);
            this.flowLayoutPanel1.Controls.Add(this.btnTable);
            this.flowLayoutPanel1.Controls.Add(this.btnPayment);
            this.flowLayoutPanel1.Controls.Add(this.btnWaitingOrder);
            this.flowLayoutPanel1.Controls.Add(this.btnManaCus);
            this.flowLayoutPanel1.Controls.Add(this.btnTakeAway);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 70);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(223, 604);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDashboard.Location = new System.Drawing.Point(3, 3);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(214, 55);
            this.btnDashboard.TabIndex = 5;
            this.btnDashboard.Text = "Trang chủ";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployee.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEmployee.Location = new System.Drawing.Point(3, 64);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(214, 55);
            this.btnEmployee.TabIndex = 6;
            this.btnEmployee.Text = "Quản lý nhân viên";
            this.btnEmployee.UseVisualStyleBackColor = true;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnFood
            // 
            this.btnFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFood.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFood.Location = new System.Drawing.Point(3, 125);
            this.btnFood.Name = "btnFood";
            this.btnFood.Size = new System.Drawing.Size(214, 55);
            this.btnFood.TabIndex = 3;
            this.btnFood.Text = "Quản lý món ăn";
            this.btnFood.UseVisualStyleBackColor = true;
            this.btnFood.Click += new System.EventHandler(this.btnFood_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOrder.Location = new System.Drawing.Point(3, 186);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(214, 55);
            this.btnOrder.TabIndex = 2;
            this.btnOrder.Text = "Quản lý hóa đơn";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnTable
            // 
            this.btnTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTable.Location = new System.Drawing.Point(3, 247);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(214, 55);
            this.btnTable.TabIndex = 4;
            this.btnTable.Text = "Quản lý bàn ăn";
            this.btnTable.UseVisualStyleBackColor = true;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPayment.Location = new System.Drawing.Point(3, 308);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(214, 55);
            this.btnPayment.TabIndex = 7;
            this.btnPayment.Text = "Thanh toán tiền bàn";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnWaitingOrder
            // 
            this.btnWaitingOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWaitingOrder.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnWaitingOrder.Location = new System.Drawing.Point(3, 369);
            this.btnWaitingOrder.Name = "btnWaitingOrder";
            this.btnWaitingOrder.Size = new System.Drawing.Size(214, 55);
            this.btnWaitingOrder.TabIndex = 7;
            this.btnWaitingOrder.Text = "Hóa đơn đang làm";
            this.btnWaitingOrder.UseVisualStyleBackColor = true;
            this.btnWaitingOrder.Click += new System.EventHandler(this.btnWaitingOrder_Click);
            // 
            // btnManaCus
            // 
            this.btnManaCus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManaCus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnManaCus.Location = new System.Drawing.Point(3, 430);
            this.btnManaCus.Name = "btnManaCus";
            this.btnManaCus.Size = new System.Drawing.Size(214, 55);
            this.btnManaCus.TabIndex = 8;
            this.btnManaCus.Text = "Quản lý khách hàng";
            this.btnManaCus.UseVisualStyleBackColor = true;
            this.btnManaCus.Click += new System.EventHandler(this.btnManaCus_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnLogout.Location = new System.Drawing.Point(12, 710);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(190, 55);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(223, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1177, 80);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1177, 80);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ CỬA HÀNG THỨC ĂN NHANH - CHỦ CỬA HÀNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnContent
            // 
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(223, 80);
            this.pnContent.Name = "pnContent";
            this.pnContent.Size = new System.Drawing.Size(1177, 720);
            this.pnContent.TabIndex = 2;
            // 
            // btnTakeAway
            // 
            this.btnTakeAway.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeAway.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTakeAway.Location = new System.Drawing.Point(3, 491);
            this.btnTakeAway.Name = "btnTakeAway";
            this.btnTakeAway.Size = new System.Drawing.Size(214, 55);
            this.btnTakeAway.TabIndex = 9;
            this.btnTakeAway.Text = "Mua mang di";
            this.btnTakeAway.UseVisualStyleBackColor = true;
            this.btnTakeAway.Click += new System.EventHandler(this.btnTakeAway_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.pnContent);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnContent;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnFood;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnWaitingOrder;
        private System.Windows.Forms.Button btnManaCus;
        private System.Windows.Forms.Button btnTakeAway;
    }
}