namespace QLCuaHangThucAnNhanh
{
    partial class frmItemRowOrder
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
            this.btnTable = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCusname = new System.Windows.Forms.TextBox();
            this.lbQuantityItem = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCusPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnTable
            // 
            this.btnTable.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnTable.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTable.Location = new System.Drawing.Point(0, 0);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(134, 90);
            this.btnTable.TabIndex = 0;
            this.btnTable.Text = "Bàn số ";
            this.btnTable.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Khách hàng:";
            // 
            // txtCusname
            // 
            this.txtCusname.Location = new System.Drawing.Point(258, 5);
            this.txtCusname.Name = "txtCusname";
            this.txtCusname.ReadOnly = true;
            this.txtCusname.Size = new System.Drawing.Size(328, 26);
            this.txtCusname.TabIndex = 2;
            // 
            // lbQuantityItem
            // 
            this.lbQuantityItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbQuantityItem.Location = new System.Drawing.Point(714, 5);
            this.lbQuantityItem.Name = "lbQuantityItem";
            this.lbQuantityItem.Size = new System.Drawing.Size(201, 69);
            this.lbQuantityItem.TabIndex = 1;
            this.lbQuantityItem.Text = "Số lượng món: ";
            this.lbQuantityItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbQuantityItem.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Số điện thoại:";
            // 
            // txtCusPhone
            // 
            this.txtCusPhone.Location = new System.Drawing.Point(258, 32);
            this.txtCusPhone.Name = "txtCusPhone";
            this.txtCusPhone.ReadOnly = true;
            this.txtCusPhone.Size = new System.Drawing.Size(328, 26);
            this.txtCusPhone.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày:";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(258, 58);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(328, 26);
            this.txtDate.TabIndex = 2;
            // 
            // frmItemRowOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1000, 100);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCusPhone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbQuantityItem);
            this.Controls.Add(this.txtCusname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTable);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmItemRowOrder";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Text = "frmItemRowOrder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCusname;
        private System.Windows.Forms.Label lbQuantityItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCusPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDate;
    }
}