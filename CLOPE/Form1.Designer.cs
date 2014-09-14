namespace CLOPE
{
	partial class Form1
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
			this.button1 = new System.Windows.Forms.Button();
			this.clustersTable = new System.Windows.Forms.DataGridView();
			this.Cluster = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.S = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.W = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ClusterSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.E = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.P = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.statusLabel = new System.Windows.Forms.Label();
			this.rTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.clustersTable)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(205, 26);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Старт";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// clustersTable
			// 
			this.clustersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.clustersTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cluster,
            this.S,
            this.W,
            this.ClusterSize,
            this.E,
            this.P});
			this.clustersTable.Location = new System.Drawing.Point(38, 76);
			this.clustersTable.Name = "clustersTable";
			this.clustersTable.Size = new System.Drawing.Size(655, 420);
			this.clustersTable.TabIndex = 1;
			// 
			// Cluster
			// 
			this.Cluster.HeaderText = "Кластер";
			this.Cluster.Name = "Cluster";
			this.Cluster.ReadOnly = true;
			// 
			// S
			// 
			this.S.HeaderText = "S";
			this.S.Name = "S";
			this.S.ReadOnly = true;
			// 
			// W
			// 
			this.W.HeaderText = "W";
			this.W.Name = "W";
			this.W.ReadOnly = true;
			// 
			// ClusterSize
			// 
			this.ClusterSize.HeaderText = "Размер";
			this.ClusterSize.Name = "ClusterSize";
			this.ClusterSize.ReadOnly = true;
			// 
			// E
			// 
			this.E.HeaderText = "E";
			this.E.Name = "E";
			// 
			// P
			// 
			this.P.HeaderText = "P";
			this.P.Name = "P";
			this.P.ReadOnly = true;
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Location = new System.Drawing.Point(444, 32);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(74, 13);
			this.statusLabel.TabIndex = 2;
			this.statusLabel.Text = "Остановлено";
			// 
			// rTextBox
			// 
			this.rTextBox.Location = new System.Drawing.Point(41, 29);
			this.rTextBox.Name = "rTextBox";
			this.rTextBox.Size = new System.Drawing.Size(100, 20);
			this.rTextBox.TabIndex = 3;
			this.rTextBox.Text = "2,6";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(38, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(150, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Коэффициент отталкивания";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(391, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Статус: ";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(724, 518);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.rTextBox);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.clustersTable);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "CLOPE";
			((System.ComponentModel.ISupportInitialize)(this.clustersTable)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridView clustersTable;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.DataGridViewTextBoxColumn Cluster;
		private System.Windows.Forms.DataGridViewTextBoxColumn S;
		private System.Windows.Forms.DataGridViewTextBoxColumn W;
		private System.Windows.Forms.DataGridViewTextBoxColumn ClusterSize;
		private System.Windows.Forms.DataGridViewTextBoxColumn E;
		private System.Windows.Forms.DataGridViewTextBoxColumn P;
		private System.Windows.Forms.TextBox rTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}

