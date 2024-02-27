namespace QLCuaHangThucAnNhanh
{
    partial class frmMnWaitingOrder
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnWaiting = new System.Windows.Forms.Button();
            this.btnInprogress = new System.Windows.Forms.Button();
            this.flpOrder = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnInprogress);
            this.panel1.Controls.Add(this.btnWaiting);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1177, 72);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flpOrder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(1177, 648);
            this.panel2.TabIndex = 1;
            // 
            // btnWaiting
            // 
            this.btnWaiting.Location = new System.Drawing.Point(25, 12);
            this.btnWaiting.Name = "btnWaiting";
            this.btnWaiting.Size = new System.Drawing.Size(183, 53);
            this.btnWaiting.TabIndex = 0;
            this.btnWaiting.Text = "Các đơn chờ làm";
            this.btnWaiting.UseVisualStyleBackColor = true;
            this.btnWaiting.Click += new System.EventHandler(this.btnWaiting_Click);
            // 
            // btnInprogress
            // 
            this.btnInprogress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInprogress.Location = new System.Drawing.Point(229, 12);
            this.btnInprogress.Name = "btnInprogress";
            this.btnInprogress.Size = new System.Drawing.Size(183, 53);
            this.btnInprogress.TabIndex = 0;
            this.btnInprogress.Text = "Các đơn đang làm";
            this.btnInprogress.UseVisualStyleBackColor = true;
            this.btnInprogress.Click += new System.EventHandler(this.btnInprogress_Click);
            // 
            // flpOrder
            // 
            this.flpOrder.AutoScroll = true;
            this.flpOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpOrder.Location = new System.Drawing.Point(10, 10);
            this.flpOrder.Name = "flpOrder";
            this.flpOrder.Size = new System.Drawing.Size(1157, 628);
            this.flpOrder.TabIndex = 0;
            // 
            // frmMnWaitingOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 720);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMnWaitingOrder";
            this.Text = "frmMnWaitingOrder";
            this.Load += new System.EventHandler(this.frmMnWaitingOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnInprogress;
        private System.Windows.Forms.Button btnWaiting;
        private System.Windows.Forms.FlowLayoutPanel flpOrder;
    }
}