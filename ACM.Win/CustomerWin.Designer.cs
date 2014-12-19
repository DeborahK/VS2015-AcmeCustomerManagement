namespace ACM.Win
{
    partial class CustomerWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerWin));
            this.DetailDataGridView = new System.Windows.Forms.DataGridView();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.InvoiceButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.InvoiceTotalsButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.CutomersButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.DetailDataGridView)).BeginInit();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DetailDataGridView
            // 
            this.DetailDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DetailDataGridView.Location = new System.Drawing.Point(12, 34);
            this.DetailDataGridView.Name = "DetailDataGridView";
            this.DetailDataGridView.Size = new System.Drawing.Size(698, 372);
            this.DetailDataGridView.TabIndex = 2;
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CutomersButton,
            this.toolStripSeparator3,
            this.InvoiceButton,
            this.ToolStripSeparator1,
            this.InvoiceTotalsButton,
            this.ToolStripSeparator2,
            this.ToolStripButton6});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(722, 25);
            this.ToolStrip1.TabIndex = 3;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // InvoiceButton
            // 
            this.InvoiceButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.InvoiceButton.Image = ((System.Drawing.Image)(resources.GetObject("InvoiceButton.Image")));
            this.InvoiceButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InvoiceButton.Name = "InvoiceButton";
            this.InvoiceButton.Size = new System.Drawing.Size(54, 22);
            this.InvoiceButton.Text = "Invoices";
            this.InvoiceButton.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // InvoiceTotalsButton
            // 
            this.InvoiceTotalsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.InvoiceTotalsButton.Image = ((System.Drawing.Image)(resources.GetObject("InvoiceTotalsButton.Image")));
            this.InvoiceTotalsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InvoiceTotalsButton.Name = "InvoiceTotalsButton";
            this.InvoiceTotalsButton.Size = new System.Drawing.Size(84, 22);
            this.InvoiceTotalsButton.Text = "Invoice Totals";
            this.InvoiceTotalsButton.Click += new System.EventHandler(this.ToolStripButton2_Click);
            // 
            // ToolStripButton6
            // 
            this.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton6.Image")));
            this.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton6.Name = "ToolStripButton6";
            this.ToolStripButton6.Size = new System.Drawing.Size(34, 22);
            this.ToolStripButton6.Text = "Find";
            this.ToolStripButton6.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // CutomersButton
            // 
            this.CutomersButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CutomersButton.Image = ((System.Drawing.Image)(resources.GetObject("CutomersButton.Image")));
            this.CutomersButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CutomersButton.Name = "CutomersButton";
            this.CutomersButton.Size = new System.Drawing.Size(68, 22);
            this.CutomersButton.Text = "Customers";
            this.CutomersButton.Click += new System.EventHandler(this.CustomersButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // CustomerWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 412);
            this.Controls.Add(this.DetailDataGridView);
            this.Controls.Add(this.ToolStrip1);
            this.Name = "CustomerWin";
            this.Text = "Customers and Invoices ";
            this.Load += new System.EventHandler(this.CustomerWin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DetailDataGridView)).EndInit();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView DetailDataGridView;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton InvoiceButton;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton InvoiceTotalsButton;
        internal System.Windows.Forms.ToolStripButton ToolStripButton6;
        private System.Windows.Forms.ToolStripButton CutomersButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

