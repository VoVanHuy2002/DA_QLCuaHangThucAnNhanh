namespace QLCuaHangThucAnNhanh
{
    partial class frmMnFood
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
            this.nmrPrice = new System.Windows.Forms.NumericUpDown();
            this.btnChoose = new System.Windows.Forms.Button();
            this.picFood = new System.Windows.Forms.PictureBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtDes = new System.Windows.Forms.RichTextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvFood = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUpload = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFood)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFood)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nmrPrice);
            this.panel1.Controls.Add(this.btnChoose);
            this.panel1.Controls.Add(this.picFood);
            this.panel1.Controls.Add(this.btnReload);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.txtDes);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.txtUpload);
            this.panel1.Controls.Add(this.txtImage);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1177, 342);
            this.panel1.TabIndex = 0;
            // 
            // nmrPrice
            // 
            this.nmrPrice.Location = new System.Drawing.Point(177, 131);
            this.nmrPrice.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nmrPrice.Name = "nmrPrice";
            this.nmrPrice.Size = new System.Drawing.Size(120, 30);
            this.nmrPrice.TabIndex = 1;
            // 
            // btnChoose
            // 
            this.btnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChoose.Location = new System.Drawing.Point(599, 131);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(91, 38);
            this.btnChoose.TabIndex = 3;
            this.btnChoose.Text = "Chọn";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // picFood
            // 
            this.picFood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFood.Location = new System.Drawing.Point(716, 131);
            this.picFood.Name = "picFood";
            this.picFood.Size = new System.Drawing.Size(337, 115);
            this.picFood.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFood.TabIndex = 4;
            this.picFood.TabStop = false;
            // 
            // btnReload
            // 
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.Location = new System.Drawing.Point(839, 269);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(160, 52);
            this.btnReload.TabIndex = 8;
            this.btnReload.Text = "Làm mới";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(660, 269);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 52);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Location = new System.Drawing.Point(479, 269);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(160, 52);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "Xóa";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(286, 269);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(160, 52);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(86, 269);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(160, 52);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtDes
            // 
            this.txtDes.Location = new System.Drawing.Point(177, 178);
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(400, 82);
            this.txtDes.TabIndex = 2;
            this.txtDes.Text = "";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(177, 75);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(400, 30);
            this.txtName.TabIndex = 0;
            // 
            // txtImage
            // 
            this.txtImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImage.Enabled = false;
            this.txtImage.Location = new System.Drawing.Point(716, 36);
            this.txtImage.Name = "txtImage";
            this.txtImage.ReadOnly = true;
            this.txtImage.Size = new System.Drawing.Size(337, 30);
            this.txtImage.TabIndex = 11;
            // 
            // txtId
            // 
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(177, 36);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(400, 30);
            this.txtId.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mô tả:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Giá tiền:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(594, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Hình ảnh:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên món ăn:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã món ăn:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvFood);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 342);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(1177, 378);
            this.panel2.TabIndex = 1;
            // 
            // dgvFood
            // 
            this.dgvFood.AllowUserToAddRows = false;
            this.dgvFood.AllowUserToDeleteRows = false;
            this.dgvFood.AllowUserToResizeColumns = false;
            this.dgvFood.AllowUserToResizeRows = false;
            this.dgvFood.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFood.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFood.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvFood.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFood.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFood.Location = new System.Drawing.Point(10, 10);
            this.dgvFood.MultiSelect = false;
            this.dgvFood.Name = "dgvFood";
            this.dgvFood.ReadOnly = true;
            this.dgvFood.RowHeadersWidth = 51;
            this.dgvFood.RowTemplate.Height = 24;
            this.dgvFood.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFood.Size = new System.Drawing.Size(1157, 358);
            this.dgvFood.TabIndex = 0;
            this.dgvFood.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFood_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(594, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Upload:";
            // 
            // txtUpload
            // 
            this.txtUpload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUpload.Enabled = false;
            this.txtUpload.Location = new System.Drawing.Point(716, 76);
            this.txtUpload.Name = "txtUpload";
            this.txtUpload.ReadOnly = true;
            this.txtUpload.Size = new System.Drawing.Size(337, 30);
            this.txtUpload.TabIndex = 11;
            // 
            // frmMnFood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 720);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMnFood";
            this.Text = "frmMnFood";
            this.Load += new System.EventHandler(this.frmMnFood_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFood)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFood)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RichTextBox txtDes;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picFood;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvFood;
        private System.Windows.Forms.NumericUpDown nmrPrice;
        private System.Windows.Forms.TextBox txtUpload;
        private System.Windows.Forms.Label label6;
    }
}