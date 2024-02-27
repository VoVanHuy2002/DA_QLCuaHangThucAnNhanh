namespace QLCuaHangThucAnNhanh
{
    partial class frmPopupBill
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCusName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTable = new System.Windows.Forms.Label();
            this.lvOrder = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.txtPoint = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNetTotal = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.Location = new System.Drawing.Point(244, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hóa đơn khách hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhân viên:";
            // 
            // txtEmpName
            // 
            this.txtEmpName.AutoSize = true;
            this.txtEmpName.Location = new System.Drawing.Point(179, 110);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(53, 20);
            this.txtEmpName.TabIndex = 2;
            this.txtEmpName.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 148);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Khách hàng:";
            // 
            // txtCusName
            // 
            this.txtCusName.AutoSize = true;
            this.txtCusName.Location = new System.Drawing.Point(179, 148);
            this.txtCusName.Name = "txtCusName";
            this.txtCusName.Size = new System.Drawing.Size(53, 20);
            this.txtCusName.TabIndex = 2;
            this.txtCusName.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 183);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ngày:";
            // 
            // txtDate
            // 
            this.txtDate.AutoSize = true;
            this.txtDate.Location = new System.Drawing.Point(179, 183);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(53, 20);
            this.txtDate.TabIndex = 2;
            this.txtDate.Text = "label3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 221);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Bàn:";
            // 
            // txtTable
            // 
            this.txtTable.AutoSize = true;
            this.txtTable.Location = new System.Drawing.Point(179, 221);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(53, 20);
            this.txtTable.TabIndex = 2;
            this.txtTable.Text = "label3";
            // 
            // lvOrder
            // 
            this.lvOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvOrder.FullRowSelect = true;
            this.lvOrder.GridLines = true;
            this.lvOrder.HideSelection = false;
            this.lvOrder.Location = new System.Drawing.Point(55, 282);
            this.lvOrder.MultiSelect = false;
            this.lvOrder.Name = "lvOrder";
            this.lvOrder.Size = new System.Drawing.Size(955, 277);
            this.lvOrder.TabIndex = 3;
            this.lvOrder.UseCompatibleStateImageBehavior = false;
            this.lvOrder.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã món ăn";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên món ăn";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Số lượng";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Thành tiền";
            this.columnHeader5.Width = 200;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 596);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(233, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Điểm tích lũy của khách hàng:";
            // 
            // txtPoint
            // 
            this.txtPoint.AutoSize = true;
            this.txtPoint.Location = new System.Drawing.Point(308, 599);
            this.txtPoint.Name = "txtPoint";
            this.txtPoint.Size = new System.Drawing.Size(53, 20);
            this.txtPoint.TabIndex = 5;
            this.txtPoint.Text = "label7";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 628);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Giảm giá:";
            // 
            // txtDiscount
            // 
            this.txtDiscount.AutoSize = true;
            this.txtDiscount.Location = new System.Drawing.Point(160, 628);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(53, 20);
            this.txtDiscount.TabIndex = 7;
            this.txtDiscount.Text = "label8";
            this.txtDiscount.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(55, 659);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "Tổng tiền:";
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.Location = new System.Drawing.Point(160, 659);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(53, 20);
            this.txtTotal.TabIndex = 7;
            this.txtTotal.Text = "label8";
            this.txtTotal.Click += new System.EventHandler(this.label8_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(56, 689);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 20);
            this.label11.TabIndex = 6;
            this.label11.Text = "Thành tiền sau giảm giá:";
            // 
            // txtNetTotal
            // 
            this.txtNetTotal.AutoSize = true;
            this.txtNetTotal.Location = new System.Drawing.Point(265, 689);
            this.txtNetTotal.Name = "txtNetTotal";
            this.txtNetTotal.Size = new System.Drawing.Size(53, 20);
            this.txtNetTotal.TabIndex = 7;
            this.txtNetTotal.Text = "label8";
            this.txtNetTotal.Click += new System.EventHandler(this.label8_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(899, 655);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(111, 54);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmPopupBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 728);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtNetTotal);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPoint);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lvOrder);
            this.Controls.Add(this.txtTable);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCusName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPopupBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPopupBill";
            this.Load += new System.EventHandler(this.frmPopupBill_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtEmpName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtCusName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtTable;
        private System.Windows.Forms.ListView lvOrder;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtPoint;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txtDiscount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label txtNetTotal;
        private System.Windows.Forms.Button btnOk;
    }
}