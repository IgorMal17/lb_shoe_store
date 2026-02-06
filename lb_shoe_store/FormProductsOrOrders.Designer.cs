namespace lb_shoe_store
{
    partial class FormProductsOrOrders
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
            ProductsBtn = new Button();
            OrdersBtn = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lbUserName = new Label();
            dgvProductsOrOrders = new DataGridView();
            panel1 = new Panel();
            btnLogut = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProductsOrOrders).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ProductsBtn
            // 
            ProductsBtn.Location = new Point(89, 105);
            ProductsBtn.Name = "ProductsBtn";
            ProductsBtn.Size = new Size(100, 50);
            ProductsBtn.TabIndex = 0;
            ProductsBtn.Text = "Продукты";
            ProductsBtn.UseVisualStyleBackColor = true;
            ProductsBtn.Click += ProductsBtn_Click;
            // 
            // OrdersBtn
            // 
            OrdersBtn.Location = new Point(195, 105);
            OrdersBtn.Name = "OrdersBtn";
            OrdersBtn.Size = new Size(100, 50);
            OrdersBtn.TabIndex = 1;
            OrdersBtn.Text = "Заказы";
            OrdersBtn.UseVisualStyleBackColor = true;
            OrdersBtn.Click += OrdersBtn_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(249, 169);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(8, 8);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // lbUserName
            // 
            lbUserName.AutoSize = true;
            lbUserName.Dock = DockStyle.Right;
            lbUserName.Location = new Point(196, 0);
            lbUserName.Name = "lbUserName";
            lbUserName.Size = new Size(38, 15);
            lbUserName.TabIndex = 6;
            lbUserName.Text = "label1";
            lbUserName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvProductsOrOrders
            // 
            dgvProductsOrOrders.AllowUserToAddRows = false;
            dgvProductsOrOrders.AllowUserToDeleteRows = false;
            dgvProductsOrOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductsOrOrders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvProductsOrOrders.BackgroundColor = Color.White;
            dgvProductsOrOrders.BorderStyle = BorderStyle.None;
            dgvProductsOrOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductsOrOrders.Dock = DockStyle.Fill;
            dgvProductsOrOrders.Location = new Point(0, 40);
            dgvProductsOrOrders.MultiSelect = false;
            dgvProductsOrOrders.Name = "dgvProductsOrOrders";
            dgvProductsOrOrders.ReadOnly = true;
            dgvProductsOrOrders.RowHeadersVisible = false;
            dgvProductsOrOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductsOrOrders.Size = new Size(384, 221);
            dgvProductsOrOrders.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(lbUserName);
            panel1.Controls.Add(btnLogut);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 0, 0, 10);
            panel1.Size = new Size(384, 40);
            panel1.TabIndex = 3;
            // 
            // btnLogut
            // 
            btnLogut.BackColor = Color.MediumSpringGreen;
            btnLogut.Dock = DockStyle.Right;
            btnLogut.FlatAppearance.BorderSize = 0;
            btnLogut.FlatStyle = FlatStyle.Flat;
            btnLogut.Location = new Point(234, 0);
            btnLogut.Name = "btnLogut";
            btnLogut.Size = new Size(150, 30);
            btnLogut.TabIndex = 5;
            btnLogut.Text = "Выход";
            btnLogut.UseVisualStyleBackColor = false;
            btnLogut.Click += BtnLogut_Click;
            // 
            // FormProductsOrOrders
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(384, 261);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(OrdersBtn);
            Controls.Add(ProductsBtn);
            Controls.Add(dgvProductsOrOrders);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormProductsOrOrders";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Просмотреть товары или заказы";
            ((System.ComponentModel.ISupportInitialize)dgvProductsOrOrders).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button ProductsBtn;
        private Button OrdersBtn;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lbUserName;
        private DataGridView dgvProductsOrOrders;
        private Panel panel1;
        private Button btnLogut;
    }
}