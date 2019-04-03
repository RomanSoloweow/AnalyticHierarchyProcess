namespace AnalyticHierarchyProcess
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
            this.dataSet1 = new System.Data.DataSet();
            this.LabelTasks = new System.Windows.Forms.Label();
            this.ButtonOpenFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabMane = new System.Windows.Forms.TabPage();
            this.tabTask = new System.Windows.Forms.TabPage();
            this.tabCompare = new System.Windows.Forms.TabPage();
            this.dataGridViewCompare = new System.Windows.Forms.DataGridView();
            this.tabCriterions = new System.Windows.Forms.TabPage();
            this.dataGridViewCriterions = new System.Windows.Forms.DataGridView();
            this.dataGridViewTasks = new System.Windows.Forms.DataGridView();
            this.buttonAddCriterion = new System.Windows.Forms.Button();
            this.buttonAddTask = new System.Windows.Forms.Button();
            this.textBoxCriterionName = new System.Windows.Forms.TextBox();
            this.textBoxTaskName = new System.Windows.Forms.TextBox();
            this.ColumnTasks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelSelectedTask = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            this.ColumnCriterions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.tabs.SuspendLayout();
            this.tabMane.SuspendLayout();
            this.tabTask.SuspendLayout();
            this.tabCompare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompare)).BeginInit();
            this.tabCriterions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCriterions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // LabelTasks
            // 
            this.LabelTasks.AutoSize = true;
            this.LabelTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelTasks.Location = new System.Drawing.Point(272, 3);
            this.LabelTasks.Name = "LabelTasks";
            this.LabelTasks.Size = new System.Drawing.Size(164, 31);
            this.LabelTasks.TabIndex = 4;
            this.LabelTasks.Text = "Выбор цели";
            // 
            // ButtonOpenFile
            // 
            this.ButtonOpenFile.Location = new System.Drawing.Point(87, 360);
            this.ButtonOpenFile.Name = "ButtonOpenFile";
            this.ButtonOpenFile.Size = new System.Drawing.Size(242, 59);
            this.ButtonOpenFile.TabIndex = 5;
            this.ButtonOpenFile.Text = "Открыть";
            this.ButtonOpenFile.UseVisualStyleBackColor = true;
            this.ButtonOpenFile.Click += new System.EventHandler(this.ButtonOpenFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(412, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(262, 166);
            this.button1.TabIndex = 9;
            this.button1.Text = "Тест";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabMane);
            this.tabs.Controls.Add(this.tabTask);
            this.tabs.Controls.Add(this.tabCompare);
            this.tabs.Controls.Add(this.tabCriterions);
            this.tabs.Location = new System.Drawing.Point(1, 40);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1657, 992);
            this.tabs.TabIndex = 11;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            this.tabs.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabs_Selecting);
            // 
            // tabMane
            // 
            this.tabMane.AutoScroll = true;
            this.tabMane.Controls.Add(this.button1);
            this.tabMane.Controls.Add(this.ButtonOpenFile);
            this.tabMane.Controls.Add(this.LabelTasks);
            this.tabMane.Location = new System.Drawing.Point(8, 39);
            this.tabMane.Name = "tabMane";
            this.tabMane.Padding = new System.Windows.Forms.Padding(3);
            this.tabMane.Size = new System.Drawing.Size(1641, 945);
            this.tabMane.TabIndex = 0;
            this.tabMane.Text = "Главная";
            this.tabMane.UseVisualStyleBackColor = true;
            // 
            // tabTask
            // 
            this.tabTask.Controls.Add(this.textBoxTaskName);
            this.tabTask.Controls.Add(this.buttonAddTask);
            this.tabTask.Controls.Add(this.dataGridViewTasks);
            this.tabTask.Location = new System.Drawing.Point(8, 39);
            this.tabTask.Name = "tabTask";
            this.tabTask.Size = new System.Drawing.Size(1641, 945);
            this.tabTask.TabIndex = 3;
            this.tabTask.Text = "Цели";
            this.tabTask.UseVisualStyleBackColor = true;
            // 
            // tabCompare
            // 
            this.tabCompare.AutoScroll = true;
            this.tabCompare.Controls.Add(this.dataGridViewCompare);
            this.tabCompare.Location = new System.Drawing.Point(8, 39);
            this.tabCompare.Name = "tabCompare";
            this.tabCompare.Size = new System.Drawing.Size(1641, 945);
            this.tabCompare.TabIndex = 2;
            this.tabCompare.Text = "Сравнения";
            this.tabCompare.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCompare
            // 
            this.dataGridViewCompare.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewCompare.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCompare.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewCompare.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCompare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompare.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewCompare.Location = new System.Drawing.Point(-8, 0);
            this.dataGridViewCompare.Name = "dataGridViewCompare";
            this.dataGridViewCompare.RowHeadersVisible = false;
            this.dataGridViewCompare.RowTemplate.Height = 33;
            this.dataGridViewCompare.Size = new System.Drawing.Size(1616, 894);
            this.dataGridViewCompare.TabIndex = 0;
            // 
            // tabCriterions
            // 
            this.tabCriterions.AutoScroll = true;
            this.tabCriterions.Controls.Add(this.textBoxCriterionName);
            this.tabCriterions.Controls.Add(this.buttonAddCriterion);
            this.tabCriterions.Controls.Add(this.dataGridViewCriterions);
            this.tabCriterions.Location = new System.Drawing.Point(8, 39);
            this.tabCriterions.Name = "tabCriterions";
            this.tabCriterions.Padding = new System.Windows.Forms.Padding(3);
            this.tabCriterions.Size = new System.Drawing.Size(1641, 945);
            this.tabCriterions.TabIndex = 1;
            this.tabCriterions.Text = "Критерии";
            this.tabCriterions.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCriterions
            // 
            this.dataGridViewCriterions.AllowUserToAddRows = false;
            this.dataGridViewCriterions.AllowUserToResizeColumns = false;
            this.dataGridViewCriterions.AllowUserToResizeRows = false;
            this.dataGridViewCriterions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewCriterions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCriterions.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewCriterions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCriterions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewCriterions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCriterions.ColumnHeadersVisible = false;
            this.dataGridViewCriterions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCriterions});
            this.dataGridViewCriterions.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewCriterions.Location = new System.Drawing.Point(6, 93);
            this.dataGridViewCriterions.Name = "dataGridViewCriterions";
            this.dataGridViewCriterions.RowHeadersVisible = false;
            this.dataGridViewCriterions.RowTemplate.Height = 33;
            this.dataGridViewCriterions.Size = new System.Drawing.Size(1563, 830);
            this.dataGridViewCriterions.TabIndex = 0;
            this.dataGridViewCriterions.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewCriterions_UserAddedRow);
            this.dataGridViewCriterions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewCriterions_KeyDown);
            // 
            // dataGridViewTasks
            // 
            this.dataGridViewTasks.AllowUserToAddRows = false;
            this.dataGridViewTasks.AllowUserToDeleteRows = false;
            this.dataGridViewTasks.AllowUserToResizeColumns = false;
            this.dataGridViewTasks.AllowUserToResizeRows = false;
            this.dataGridViewTasks.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTasks.ColumnHeadersVisible = false;
            this.dataGridViewTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTasks});
            this.dataGridViewTasks.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewTasks.Location = new System.Drawing.Point(7, 108);
            this.dataGridViewTasks.Name = "dataGridViewTasks";
            this.dataGridViewTasks.RowHeadersVisible = false;
            this.dataGridViewTasks.RowTemplate.Height = 33;
            this.dataGridViewTasks.Size = new System.Drawing.Size(1623, 858);
            this.dataGridViewTasks.TabIndex = 0;
            this.dataGridViewTasks.SelectionChanged += new System.EventHandler(this.dataGridViewTasks_SelectionChanged);
            // 
            // buttonAddCriterion
            // 
            this.buttonAddCriterion.Location = new System.Drawing.Point(6, 15);
            this.buttonAddCriterion.Name = "buttonAddCriterion";
            this.buttonAddCriterion.Size = new System.Drawing.Size(258, 72);
            this.buttonAddCriterion.TabIndex = 1;
            this.buttonAddCriterion.Text = "Добавить критерий";
            this.buttonAddCriterion.UseVisualStyleBackColor = true;
            this.buttonAddCriterion.Click += new System.EventHandler(this.buttonAddCriterion_Click);
            // 
            // buttonAddTask
            // 
            this.buttonAddTask.Location = new System.Drawing.Point(7, 13);
            this.buttonAddTask.Name = "buttonAddTask";
            this.buttonAddTask.Size = new System.Drawing.Size(258, 78);
            this.buttonAddTask.TabIndex = 1;
            this.buttonAddTask.Text = "Добавить цель";
            this.buttonAddTask.UseVisualStyleBackColor = true;
            this.buttonAddTask.Click += new System.EventHandler(this.buttonAddTask_Click);
            // 
            // textBoxCriterionName
            // 
            this.textBoxCriterionName.Location = new System.Drawing.Point(280, 36);
            this.textBoxCriterionName.Name = "textBoxCriterionName";
            this.textBoxCriterionName.Size = new System.Drawing.Size(417, 31);
            this.textBoxCriterionName.TabIndex = 2;
            // 
            // textBoxTaskName
            // 
            this.textBoxTaskName.Location = new System.Drawing.Point(281, 37);
            this.textBoxTaskName.Name = "textBoxTaskName";
            this.textBoxTaskName.Size = new System.Drawing.Size(382, 31);
            this.textBoxTaskName.TabIndex = 2;
            // 
            // ColumnTasks
            // 
            this.ColumnTasks.HeaderText = "ColumnTasks";
            this.ColumnTasks.Name = "ColumnTasks";
            // 
            // labelSelectedTask
            // 
            this.labelSelectedTask.AutoSize = true;
            this.labelSelectedTask.Location = new System.Drawing.Point(172, 5);
            this.labelSelectedTask.Name = "labelSelectedTask";
            this.labelSelectedTask.Size = new System.Drawing.Size(0, 25);
            this.labelSelectedTask.TabIndex = 12;
            this.labelSelectedTask.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeader.Location = new System.Drawing.Point(8, 5);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(158, 25);
            this.labelHeader.TabIndex = 13;
            this.labelHeader.Text = "Текущая цель:";
            // 
            // ColumnCriterions
            // 
            this.ColumnCriterions.HeaderText = "ColumnCriterions";
            this.ColumnCriterions.Name = "ColumnCriterions";
            this.ColumnCriterions.Width = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1663, 1241);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.labelSelectedTask);
            this.Controls.Add(this.tabs);
            this.Name = "Form1";
            this.Text = "Метод анализа иерархий";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.tabs.ResumeLayout(false);
            this.tabMane.ResumeLayout(false);
            this.tabMane.PerformLayout();
            this.tabTask.ResumeLayout(false);
            this.tabTask.PerformLayout();
            this.tabCompare.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompare)).EndInit();
            this.tabCriterions.ResumeLayout(false);
            this.tabCriterions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCriterions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LabelTasks;
        private System.Windows.Forms.Button ButtonOpenFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabMane;
        private System.Windows.Forms.TabPage tabCriterions;
        private System.Windows.Forms.TabPage tabCompare;
        private System.Windows.Forms.DataGridView dataGridViewCompare;
        private System.Windows.Forms.DataGridView dataGridViewCriterions;
        private System.Windows.Forms.TabPage tabTask;
        private System.Windows.Forms.DataGridView dataGridViewTasks;
        private System.Windows.Forms.Button buttonAddCriterion;
        private System.Windows.Forms.Button buttonAddTask;
        private System.Windows.Forms.TextBox textBoxCriterionName;
        private System.Windows.Forms.TextBox textBoxTaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTasks;
        private System.Windows.Forms.Label labelSelectedTask;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCriterions;
    }
}

