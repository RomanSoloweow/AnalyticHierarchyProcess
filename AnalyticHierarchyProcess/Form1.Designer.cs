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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.textBoxOptionName = new System.Windows.Forms.TextBox();
            this.dataGridViewOptions = new System.Windows.Forms.DataGridView();
            this.ColumnOptions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAddOption = new System.Windows.Forms.Button();
            this.tabCompares = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridViewCompare = new System.Windows.Forms.DataGridView();
            this.tabTasks = new System.Windows.Forms.TabPage();
            this.textBoxTaskName = new System.Windows.Forms.TextBox();
            this.buttonAddTask = new System.Windows.Forms.Button();
            this.dataGridViewTasks = new System.Windows.Forms.DataGridView();
            this.ColumnTasks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCriterions = new System.Windows.Forms.TabPage();
            this.textBoxCriterionName = new System.Windows.Forms.TextBox();
            this.buttonAddCriterion = new System.Windows.Forms.Button();
            this.dataGridViewCriterions = new System.Windows.Forms.DataGridView();
            this.ColumnCriterions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelSelectedTask = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.tabs.SuspendLayout();
            this.tabOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOptions)).BeginInit();
            this.tabCompares.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompare)).BeginInit();
            this.tabTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).BeginInit();
            this.tabCriterions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCriterions)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(1184, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(262, 73);
            this.button1.TabIndex = 9;
            this.button1.Text = "Тест";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabOptions);
            this.tabs.Controls.Add(this.tabCompares);
            this.tabs.Controls.Add(this.tabTasks);
            this.tabs.Controls.Add(this.tabCriterions);
            this.tabs.Location = new System.Drawing.Point(1, 40);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1657, 992);
            this.tabs.TabIndex = 11;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            // 
            // tabOptions
            // 
            this.tabOptions.AutoScroll = true;
            this.tabOptions.Controls.Add(this.textBoxOptionName);
            this.tabOptions.Controls.Add(this.dataGridViewOptions);
            this.tabOptions.Controls.Add(this.buttonAddOption);
            this.tabOptions.Controls.Add(this.button1);
            this.tabOptions.Location = new System.Drawing.Point(8, 39);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(1641, 945);
            this.tabOptions.TabIndex = 0;
            this.tabOptions.Text = "Главная";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // textBoxOptionName
            // 
            this.textBoxOptionName.Location = new System.Drawing.Point(413, 33);
            this.textBoxOptionName.Name = "textBoxOptionName";
            this.textBoxOptionName.Size = new System.Drawing.Size(412, 31);
            this.textBoxOptionName.TabIndex = 12;
            // 
            // dataGridViewOptions
            // 
            this.dataGridViewOptions.AllowUserToAddRows = false;
            this.dataGridViewOptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewOptions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewOptions.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOptions.ColumnHeadersVisible = false;
            this.dataGridViewOptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnOptions});
            this.dataGridViewOptions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridViewOptions.EnableHeadersVisualStyles = false;
            this.dataGridViewOptions.Location = new System.Drawing.Point(6, 96);
            this.dataGridViewOptions.Name = "dataGridViewOptions";
            this.dataGridViewOptions.RowHeadersVisible = false;
            this.dataGridViewOptions.RowTemplate.Height = 33;
            this.dataGridViewOptions.Size = new System.Drawing.Size(1629, 790);
            this.dataGridViewOptions.TabIndex = 11;
            this.dataGridViewOptions.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOptions_CellValueChanged);
            // 
            // ColumnOptions
            // 
            this.ColumnOptions.HeaderText = "ColumnOptions";
            this.ColumnOptions.Name = "ColumnOptions";
            this.ColumnOptions.Width = 5;
            // 
            // buttonAddOption
            // 
            this.buttonAddOption.Location = new System.Drawing.Point(6, 15);
            this.buttonAddOption.Name = "buttonAddOption";
            this.buttonAddOption.Size = new System.Drawing.Size(264, 66);
            this.buttonAddOption.TabIndex = 10;
            this.buttonAddOption.Text = "Добавить объекты для сравнения";
            this.buttonAddOption.UseVisualStyleBackColor = true;
            this.buttonAddOption.Click += new System.EventHandler(this.buttonAddOption_Click);
            // 
            // tabCompares
            // 
            this.tabCompares.AutoScroll = true;
            this.tabCompares.Controls.Add(this.button2);
            this.tabCompares.Controls.Add(this.dataGridViewCompare);
            this.tabCompares.Location = new System.Drawing.Point(8, 39);
            this.tabCompares.Name = "tabCompares";
            this.tabCompares.Size = new System.Drawing.Size(1641, 945);
            this.tabCompares.TabIndex = 2;
            this.tabCompares.Text = "Сравнения";
            this.tabCompares.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1380, 864);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridViewCompare
            // 
            this.dataGridViewCompare.AllowUserToAddRows = false;
            this.dataGridViewCompare.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewCompare.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCompare.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewCompare.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCompare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompare.EnableHeadersVisualStyles = false;
            this.dataGridViewCompare.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewCompare.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCompare.Name = "dataGridViewCompare";
            this.dataGridViewCompare.RowHeadersVisible = false;
            this.dataGridViewCompare.RowTemplate.Height = 33;
            this.dataGridViewCompare.Size = new System.Drawing.Size(1616, 839);
            this.dataGridViewCompare.TabIndex = 0;
            this.dataGridViewCompare.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCompare_CellValueChanged);
            // 
            // tabTasks
            // 
            this.tabTasks.Controls.Add(this.textBoxTaskName);
            this.tabTasks.Controls.Add(this.buttonAddTask);
            this.tabTasks.Controls.Add(this.dataGridViewTasks);
            this.tabTasks.Location = new System.Drawing.Point(8, 39);
            this.tabTasks.Name = "tabTasks";
            this.tabTasks.Size = new System.Drawing.Size(1641, 945);
            this.tabTasks.TabIndex = 3;
            this.tabTasks.Text = "Цели";
            this.tabTasks.UseVisualStyleBackColor = true;
            // 
            // textBoxTaskName
            // 
            this.textBoxTaskName.Location = new System.Drawing.Point(281, 37);
            this.textBoxTaskName.Name = "textBoxTaskName";
            this.textBoxTaskName.Size = new System.Drawing.Size(382, 31);
            this.textBoxTaskName.TabIndex = 2;
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
            // dataGridViewTasks
            // 
            this.dataGridViewTasks.AllowUserToAddRows = false;
            this.dataGridViewTasks.AllowUserToDeleteRows = false;
            this.dataGridViewTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewTasks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewTasks.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTasks.ColumnHeadersVisible = false;
            this.dataGridViewTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTasks});
            this.dataGridViewTasks.EnableHeadersVisualStyles = false;
            this.dataGridViewTasks.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewTasks.Location = new System.Drawing.Point(7, 108);
            this.dataGridViewTasks.Name = "dataGridViewTasks";
            this.dataGridViewTasks.RowHeadersVisible = false;
            this.dataGridViewTasks.RowTemplate.Height = 33;
            this.dataGridViewTasks.Size = new System.Drawing.Size(1623, 858);
            this.dataGridViewTasks.TabIndex = 0;
            this.dataGridViewTasks.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTasks_CellValueChanged);
            this.dataGridViewTasks.SelectionChanged += new System.EventHandler(this.dataGridViewTasks_SelectionChanged);
            // 
            // ColumnTasks
            // 
            this.ColumnTasks.HeaderText = "ColumnTasks";
            this.ColumnTasks.Name = "ColumnTasks";
            this.ColumnTasks.Width = 5;
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
            // textBoxCriterionName
            // 
            this.textBoxCriterionName.Location = new System.Drawing.Point(280, 36);
            this.textBoxCriterionName.Name = "textBoxCriterionName";
            this.textBoxCriterionName.Size = new System.Drawing.Size(417, 31);
            this.textBoxCriterionName.TabIndex = 2;
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
            this.dataGridViewCriterions.EnableHeadersVisualStyles = false;
            this.dataGridViewCriterions.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewCriterions.Location = new System.Drawing.Point(6, 104);
            this.dataGridViewCriterions.Name = "dataGridViewCriterions";
            this.dataGridViewCriterions.RowHeadersVisible = false;
            this.dataGridViewCriterions.RowTemplate.Height = 33;
            this.dataGridViewCriterions.Size = new System.Drawing.Size(1615, 819);
            this.dataGridViewCriterions.TabIndex = 0;
            this.dataGridViewCriterions.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCriterions_CellValueChanged);
            this.dataGridViewCriterions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewCriterions_KeyDown);
            // 
            // ColumnCriterions
            // 
            this.ColumnCriterions.HeaderText = "ColumnCriterions";
            this.ColumnCriterions.Name = "ColumnCriterions";
            this.ColumnCriterions.Width = 5;
            // 
            // labelSelectedTask
            // 
            this.labelSelectedTask.AutoSize = true;
            this.labelSelectedTask.Location = new System.Drawing.Point(172, 5);
            this.labelSelectedTask.Name = "labelSelectedTask";
            this.labelSelectedTask.Size = new System.Drawing.Size(0, 25);
            this.labelSelectedTask.TabIndex = 12;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1663, 1045);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.labelSelectedTask);
            this.Controls.Add(this.tabs);
            this.Name = "Form1";
            this.Text = "Метод анализа иерархий";
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.tabs.ResumeLayout(false);
            this.tabOptions.ResumeLayout(false);
            this.tabOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOptions)).EndInit();
            this.tabCompares.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompare)).EndInit();
            this.tabTasks.ResumeLayout(false);
            this.tabTasks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).EndInit();
            this.tabCriterions.ResumeLayout(false);
            this.tabCriterions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCriterions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.TabPage tabCriterions;
        private System.Windows.Forms.TabPage tabCompares;
        private System.Windows.Forms.DataGridView dataGridViewCompare;
        private System.Windows.Forms.DataGridView dataGridViewCriterions;
        private System.Windows.Forms.TabPage tabTasks;
        private System.Windows.Forms.DataGridView dataGridViewTasks;
        private System.Windows.Forms.Button buttonAddCriterion;
        private System.Windows.Forms.Button buttonAddTask;
        private System.Windows.Forms.TextBox textBoxCriterionName;
        private System.Windows.Forms.TextBox textBoxTaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTasks;
        private System.Windows.Forms.Label labelSelectedTask;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCriterions;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonAddOption;
        private System.Windows.Forms.DataGridView dataGridViewOptions;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOptions;
        private System.Windows.Forms.TextBox textBoxOptionName;
    }
}

