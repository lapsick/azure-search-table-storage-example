namespace MessageSearchApp {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing ) {
            if ( disposing && (components != null) ) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textMessageSearch = new System.Windows.Forms.TextBox();
            this.labelMessageSearch = new System.Windows.Forms.Label();
            this.dateTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimeTo = new System.Windows.Forms.DateTimePicker();
            this.labelFilter1 = new System.Windows.Forms.Label();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.labelFilter2 = new System.Windows.Forms.Label();
            this.checkBoxOneParents = new System.Windows.Forms.CheckBox();
            this.checkBoxFilter = new System.Windows.Forms.CheckBox();
            this.groupResults = new System.Windows.Forms.GroupBox();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.labelElapsedTime = new System.Windows.Forms.Label();
            this.txtElapsedTime = new System.Windows.Forms.TextBox();
            this.groupBoxSearch.SuspendLayout();
            this.groupResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(452, 145);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(120, 35);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textMessageSearch
            // 
            this.textMessageSearch.Location = new System.Drawing.Point(78, 23);
            this.textMessageSearch.Name = "textMessageSearch";
            this.textMessageSearch.Size = new System.Drawing.Size(202, 20);
            this.textMessageSearch.TabIndex = 1;
            // 
            // labelMessageSearch
            // 
            this.labelMessageSearch.AutoSize = true;
            this.labelMessageSearch.Location = new System.Drawing.Point(6, 26);
            this.labelMessageSearch.Name = "labelMessageSearch";
            this.labelMessageSearch.Size = new System.Drawing.Size(52, 13);
            this.labelMessageSearch.TabIndex = 2;
            this.labelMessageSearch.Text = "Enter text";
            // 
            // dateTimeFrom
            // 
            this.dateTimeFrom.Enabled = false;
            this.dateTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFrom.Location = new System.Drawing.Point(9, 150);
            this.dateTimeFrom.Name = "dateTimeFrom";
            this.dateTimeFrom.Size = new System.Drawing.Size(200, 20);
            this.dateTimeFrom.TabIndex = 3;
            // 
            // dateTimeTo
            // 
            this.dateTimeTo.Enabled = false;
            this.dateTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeTo.Location = new System.Drawing.Point(229, 150);
            this.dateTimeTo.Name = "dateTimeTo";
            this.dateTimeTo.Size = new System.Drawing.Size(200, 20);
            this.dateTimeTo.TabIndex = 4;
            // 
            // labelFilter1
            // 
            this.labelFilter1.AutoSize = true;
            this.labelFilter1.Location = new System.Drawing.Point(6, 134);
            this.labelFilter1.Name = "labelFilter1";
            this.labelFilter1.Size = new System.Drawing.Size(30, 13);
            this.labelFilter1.TabIndex = 5;
            this.labelFilter1.Text = "From";
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.labelFilter2);
            this.groupBoxSearch.Controls.Add(this.checkBoxOneParents);
            this.groupBoxSearch.Controls.Add(this.checkBoxFilter);
            this.groupBoxSearch.Controls.Add(this.labelMessageSearch);
            this.groupBoxSearch.Controls.Add(this.buttonSearch);
            this.groupBoxSearch.Controls.Add(this.dateTimeTo);
            this.groupBoxSearch.Controls.Add(this.labelFilter1);
            this.groupBoxSearch.Controls.Add(this.dateTimeFrom);
            this.groupBoxSearch.Controls.Add(this.textMessageSearch);
            this.groupBoxSearch.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(602, 203);
            this.groupBoxSearch.TabIndex = 6;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Search Criteria";
            // 
            // labelFilter2
            // 
            this.labelFilter2.AutoSize = true;
            this.labelFilter2.Location = new System.Drawing.Point(226, 134);
            this.labelFilter2.Name = "labelFilter2";
            this.labelFilter2.Size = new System.Drawing.Size(20, 13);
            this.labelFilter2.TabIndex = 8;
            this.labelFilter2.Text = "To";
            // 
            // checkBoxOneParents
            // 
            this.checkBoxOneParents.AutoSize = true;
            this.checkBoxOneParents.Location = new System.Drawing.Point(9, 58);
            this.checkBoxOneParents.Name = "checkBoxOneParents";
            this.checkBoxOneParents.Size = new System.Drawing.Size(154, 17);
            this.checkBoxOneParents.TabIndex = 7;
            this.checkBoxOneParents.Text = "Enable Predefined Partition";
            this.checkBoxOneParents.UseVisualStyleBackColor = true;
            // 
            // checkBoxFilter
            // 
            this.checkBoxFilter.AutoSize = true;
            this.checkBoxFilter.Location = new System.Drawing.Point(9, 96);
            this.checkBoxFilter.Name = "checkBoxFilter";
            this.checkBoxFilter.Size = new System.Drawing.Size(110, 17);
            this.checkBoxFilter.TabIndex = 6;
            this.checkBoxFilter.Text = "Enable Date Filter";
            this.checkBoxFilter.UseVisualStyleBackColor = true;
            this.checkBoxFilter.CheckedChanged += new System.EventHandler(this.checkBoxFilter_CheckedChanged);
            // 
            // groupResults
            // 
            this.groupResults.Controls.Add(this.dgvResults);
            this.groupResults.Location = new System.Drawing.Point(12, 221);
            this.groupResults.Name = "groupResults";
            this.groupResults.Size = new System.Drawing.Size(988, 453);
            this.groupResults.TabIndex = 7;
            this.groupResults.TabStop = false;
            this.groupResults.Text = "Search Results";
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.Location = new System.Drawing.Point(3, 16);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.Size = new System.Drawing.Size(982, 434);
            this.dgvResults.TabIndex = 0;
            // 
            // labelElapsedTime
            // 
            this.labelElapsedTime.AutoSize = true;
            this.labelElapsedTime.Location = new System.Drawing.Point(12, 683);
            this.labelElapsedTime.Name = "labelElapsedTime";
            this.labelElapsedTime.Size = new System.Drawing.Size(74, 13);
            this.labelElapsedTime.TabIndex = 9;
            this.labelElapsedTime.Text = "Elapsed Time:";
            // 
            // txtElapsedTime
            // 
            this.txtElapsedTime.Location = new System.Drawing.Point(107, 680);
            this.txtElapsedTime.Name = "txtElapsedTime";
            this.txtElapsedTime.ReadOnly = true;
            this.txtElapsedTime.Size = new System.Drawing.Size(114, 20);
            this.txtElapsedTime.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 705);
            this.Controls.Add(this.txtElapsedTime);
            this.Controls.Add(this.labelElapsedTime);
            this.Controls.Add(this.groupResults);
            this.Controls.Add(this.groupBoxSearch);
            this.Name = "Form1";
            this.Text = "Messages Search Test Application";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.groupResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textMessageSearch;
        private System.Windows.Forms.Label labelMessageSearch;
        private System.Windows.Forms.DateTimePicker dateTimeFrom;
        private System.Windows.Forms.DateTimePicker dateTimeTo;
        private System.Windows.Forms.Label labelFilter1;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.CheckBox checkBoxFilter;
        private System.Windows.Forms.CheckBox checkBoxOneParents;
        private System.Windows.Forms.Label labelFilter2;
        private System.Windows.Forms.GroupBox groupResults;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Label labelElapsedTime;
        private System.Windows.Forms.TextBox txtElapsedTime;
    }
}

