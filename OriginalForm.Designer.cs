using MetroFramework;

namespace Laundry_System
{
    partial class OriginalForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblClothesType;
        private System.Windows.Forms.ComboBox cmbClothesType;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OriginalForm));
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblService = new System.Windows.Forms.Label();
            this.cmbService = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.ClothesType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServicePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblClothesType = new System.Windows.Forms.Label();
            this.cmbClothesType = new System.Windows.Forms.ComboBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtSquareMeters = new System.Windows.Forms.TextBox();
            this.toolTipMeter = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipCustomer = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipPhone = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipAdd = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipDelete = new System.Windows.Forms.ToolTip(this.components);
            this.customStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customStyleManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(23, 60);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(109, 23);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Customer Name:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtCustomerName.Location = new System.Drawing.Point(138, 60);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(213, 23);
            this.txtCustomerName.TabIndex = 1;
            this.toolTipCustomer.SetToolTip(this.txtCustomerName, "Enter Letters Only");
            this.txtCustomerName.Enter += new System.EventHandler(this.txtCustomerName_Enter);
            this.txtCustomerName.Leave += new System.EventHandler(this.txtCustomerName_Leave);
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.Location = new System.Drawing.Point(32, 86);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(100, 23);
            this.lblPhoneNumber.TabIndex = 2;
            this.lblPhoneNumber.Text = "Phone Number:";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumber.Location = new System.Drawing.Point(138, 86);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(213, 23);
            this.txtPhoneNumber.TabIndex = 3;
            this.toolTipPhone.SetToolTip(this.txtPhoneNumber, "Enter Numbers Only");
            this.txtPhoneNumber.Enter += new System.EventHandler(this.txtPhoneNumber_Enter);
            this.txtPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhoneNumber_KeyPress);
            this.txtPhoneNumber.Leave += new System.EventHandler(this.txtPhoneNumber_Leave);
            // 
            // lblService
            // 
            this.lblService.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblService.Location = new System.Drawing.Point(65, 142);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(58, 23);
            this.lblService.TabIndex = 6;
            this.lblService.Text = "Service:";
            // 
            // cmbService
            // 
            this.cmbService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbService.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbService.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbService.Items.AddRange(new object[] {
            "Wash",
            "Dry",
            "Wash & Dry"});
            this.cmbService.Location = new System.Drawing.Point(138, 139);
            this.cmbService.Name = "cmbService";
            this.cmbService.Size = new System.Drawing.Size(121, 24);
            this.cmbService.TabIndex = 7;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(61, 166);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(62, 23);
            this.lblQuantity.TabIndex = 8;
            this.lblQuantity.Text = "Quantity:";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudQuantity.Location = new System.Drawing.Point(138, 166);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(120, 23);
            this.nudQuantity.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(26, 203);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.toolTipAdd.SetToolTip(this.btnAdd, "Click to add in the order");
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToOrderColumns = true;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClothesType,
            this.dataGridViewTextBoxColumn1,
            this.ServicePrice,
            this.dataGridViewTextBoxColumn2,
            this.TotalPrice});
            this.dgvOrders.Location = new System.Drawing.Point(14, 239);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.Size = new System.Drawing.Size(558, 228);
            this.dgvOrders.TabIndex = 11;
            // 
            // ClothesType
            // 
            this.ClothesType.HeaderText = "Clothes Type";
            this.ClothesType.Name = "ClothesType";
            this.ClothesType.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Service";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // ServicePrice
            // 
            this.ServicePrice.HeaderText = "Service Price";
            this.ServicePrice.Name = "ServicePrice";
            this.ServicePrice.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // TotalPrice
            // 
            this.TotalPrice.HeaderText = "Total Price";
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.ReadOnly = true;
            this.TotalPrice.Width = 115;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.Location = new System.Drawing.Point(14, 473);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(88, 34);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "Submit Order";
            // 
            // lblClothesType
            // 
            this.lblClothesType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClothesType.Location = new System.Drawing.Point(35, 115);
            this.lblClothesType.Name = "lblClothesType";
            this.lblClothesType.Size = new System.Drawing.Size(97, 23);
            this.lblClothesType.TabIndex = 4;
            this.lblClothesType.Text = "Clothes Type:";
            // 
            // cmbClothesType
            // 
            this.cmbClothesType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbClothesType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbClothesType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClothesType.Items.AddRange(new object[] {
            "Thobe",
            "Wool Thobe",
            "Shmogh",
            "Ghutra",
            "Shirt",
            "Pant",
            "Tie",
            "Cap",
            "Militery Suit",
            "Jacket",
            "Over Coat",
            "Men\'s Suit",
            "Bisht",
            "Furwah",
            "T-Shirt",
            "Pyjama",
            "Bath Robe",
            "Towel",
            "U. Shirt",
            "Sarwal",
            "U. Short",
            "Socks (Pair)",
            "Ladies Suit",
            "Blouse",
            "Skirt",
            "Ladies Dress Long",
            "Ladies Dress Short",
            "Dress Pleated",
            "Special Dress",
            "Abaya",
            "Baby Frock",
            "Bed Sheet",
            "Pillow",
            "Pillow Cover",
            "Bed Spread Cover",
            "Blanket",
            "Mattress",
            "Curtain",
            "Carpet"});
            this.cmbClothesType.Location = new System.Drawing.Point(138, 112);
            this.cmbClothesType.Name = "cmbClothesType";
            this.cmbClothesType.Size = new System.Drawing.Size(121, 24);
            this.cmbClothesType.TabIndex = 5;
            this.cmbClothesType.SelectedIndexChanged += new System.EventHandler(this.CmbClothesType_SelectedIndexChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(161, 203);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(98, 23);
            this.btnRemove.TabIndex = 13;
            this.btnRemove.Text = "Delete Service";
            this.toolTipDelete.SetToolTip(this.btnRemove, "Click a row first then click this button");
            // 
            // txtSquareMeters
            // 
            this.txtSquareMeters.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSquareMeters.Location = new System.Drawing.Point(265, 112);
            this.txtSquareMeters.Multiline = true;
            this.txtSquareMeters.Name = "txtSquareMeters";
            this.txtSquareMeters.Size = new System.Drawing.Size(86, 24);
            this.txtSquareMeters.TabIndex = 14;
            this.txtSquareMeters.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipMeter.SetToolTip(this.txtSquareMeters, "Enter The Size");
            // 
            // customStyleManager
            // 
            this.customStyleManager.Owner = this;
            this.customStyleManager.Style = MetroFramework.MetroColorStyle.Black;
            this.customStyleManager.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1142, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "label1";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // OriginalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 516);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSquareMeters);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.lblClothesType);
            this.Controls.Add(this.cmbClothesType);
            this.Controls.Add(this.lblService);
            this.Controls.Add(this.cmbService);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.btnSubmit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(587, 516);
            this.MinimumSize = new System.Drawing.Size(587, 516);
            this.Name = "OriginalForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "Laundry Order System";
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Load += new System.EventHandler(this.OriginalForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customStyleManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtSquareMeters;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClothesType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServicePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.ToolTip toolTipMeter;
        private System.Windows.Forms.ToolTip toolTipCustomer;
        private System.Windows.Forms.ToolTip toolTipPhone;
        private System.Windows.Forms.ToolTip toolTipAdd;
        private System.Windows.Forms.ToolTip toolTipDelete;
        private MetroFramework.Components.MetroStyleManager customStyleManager;
        private System.Windows.Forms.Label label1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}