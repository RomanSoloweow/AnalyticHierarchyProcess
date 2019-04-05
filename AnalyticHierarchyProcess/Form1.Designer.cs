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
            this.buttonGetResult = new System.Windows.Forms.Button();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.labelResult = new System.Windows.Forms.Label();
            this.labelResultHeader = new System.Windows.Forms.Label();
            this.dataGridViewOptions = new System.Windows.Forms.DataGridView();
            this.ColumnOptions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAddOption = new System.Windows.Forms.Button();
            this.tabCompares = new System.Windows.Forms.TabPage();
            this.labelChoiseCriterion = new System.Windows.Forms.Label();
            this.comboBoxCompare = new System.Windows.Forms.ComboBox();
            this.dataGridViewCompare = new System.Windows.Forms.DataGridView();
            this.tabTask = new System.Windows.Forms.TabPage();
            this.buttonLoadTaskFromFile = new System.Windows.Forms.Button();
            this.buttonSaveTaskInFile = new System.Windows.Forms.Button();
            this.buttonAddTask = new System.Windows.Forms.Button();
            this.dataGridViewTaskCompare = new System.Windows.Forms.DataGridView();
            this.tabCriterions = new System.Windows.Forms.TabPage();
            this.buttonAddCriterion = new System.Windows.Forms.Button();
            this.dataGridViewCriterions = new System.Windows.Forms.DataGridView();
            this.ColumnCriterions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelSelectedTask = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.tab.SuspendLayout();
            this.tabOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOptions)).BeginInit();
            this.tabCompares.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompare)).BeginInit();
            this.tabTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaskCompare)).BeginInit();
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
            // buttonGetResult
            // 
            this.buttonGetResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGetResult.Location = new System.Drawing.Point(276, 15);
            this.buttonGetResult.Name = "buttonGetResult";
            this.buttonGetResult.Size = new System.Drawing.Size(249, 66);
            this.buttonGetResult.TabIndex = 9;
            this.buttonGetResult.Text = "Расчитать";
            this.buttonGetResult.UseVisualStyleBackColor = true;
            this.buttonGetResult.Click += new System.EventHandler(this.buttonGetResult_Click);
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabOptions);
            this.tab.Controls.Add(this.tabCompares);
            this.tab.Controls.Add(this.tabTask);
            this.tab.Controls.Add(this.tabCriterions);
            this.tab.Location = new System.Drawing.Point(1, 40);
            this.tab.Name = "tab";
            this.tab.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1657, 992);
            this.tab.TabIndex = 11;
            this.tab.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            // 
            // tabOptions
            // 
            this.tabOptions.AutoScroll = true;
            this.tabOptions.Controls.Add(this.labelResult);
            this.tabOptions.Controls.Add(this.labelResultHeader);
            this.tabOptions.Controls.Add(this.dataGridViewOptions);
            this.tabOptions.Controls.Add(this.buttonAddOption);
            this.tabOptions.Controls.Add(this.buttonGetResult);
            this.tabOptions.Location = new System.Drawing.Point(8, 39);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(1641, 945);
            this.tabOptions.TabIndex = 0;
            this.tabOptions.Text = "Главная";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(741, 36);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(0, 25);
            this.labelResult.TabIndex = 15;
            // 
            // labelResultHeader
            // 
            this.labelResultHeader.AutoSize = true;
            this.labelResultHeader.Location = new System.Drawing.Point(552, 36);
            this.labelResultHeader.Name = "labelResultHeader";
            this.labelResultHeader.Size = new System.Drawing.Size(183, 25);
            this.labelResultHeader.TabIndex = 14;
            this.labelResultHeader.Text = "Лучший вариант:";
            // 
            // dataGridViewOptions
            // 
            this.dataGridViewOptions.AllowUserToAddRows = false;
            this.dataGridViewOptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewOptions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewOptions.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnOptions});
            this.dataGridViewOptions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridViewOptions.EnableHeadersVisualStyles = false;
            this.dataGridViewOptions.Location = new System.Drawing.Point(6, 87);
            this.dataGridViewOptions.Name = "dataGridViewOptions";
            this.dataGridViewOptions.RowHeadersVisible = false;
            this.dataGridViewOptions.RowTemplate.Height = 33;
            this.dataGridViewOptions.Size = new System.Drawing.Size(1581, 790);
            this.dataGridViewOptions.TabIndex = 11;
            this.dataGridViewOptions.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOptions_CellValueChanged);
            this.dataGridViewOptions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewOptions_KeyDown);
            // 
            // ColumnOptions
            // 
            this.ColumnOptions.HeaderText = "Объекты";
            this.ColumnOptions.Name = "ColumnOptions";
            this.ColumnOptions.Width = 146;
            // 
            // buttonAddOption
            // 
            this.buttonAddOption.Location = new System.Drawing.Point(6, 15);
            this.buttonAddOption.Name = "buttonAddOption";
            this.buttonAddOption.Size = new System.Drawing.Size(264, 66);
            this.buttonAddOption.TabIndex = 10;
            this.buttonAddOption.Text = "Добавить объект для сравнения";
            this.buttonAddOption.UseVisualStyleBackColor = true;
            this.buttonAddOption.Click += new System.EventHandler(this.buttonAddOption_Click);
            // 
            // tabCompares
            // 
            this.tabCompares.AutoScroll = true;
            this.tabCompares.Controls.Add(this.labelChoiseCriterion);
            this.tabCompares.Controls.Add(this.comboBoxCompare);
            this.tabCompares.Controls.Add(this.dataGridViewCompare);
            this.tabCompares.Location = new System.Drawing.Point(8, 39);
            this.tabCompares.Name = "tabCompares";
            this.tabCompares.Size = new System.Drawing.Size(1641, 945);
            this.tabCompares.TabIndex = 2;
            this.tabCompares.Text = "Сравнения";
            this.tabCompares.UseVisualStyleBackColor = true;
            // 
            // labelChoiseCriterion
            // 
            this.labelChoiseCriterion.AutoSize = true;
            this.labelChoiseCriterion.Location = new System.Drawing.Point(10, 12);
            this.labelChoiseCriterion.Name = "labelChoiseCriterion";
            this.labelChoiseCriterion.Size = new System.Drawing.Size(163, 25);
            this.labelChoiseCriterion.TabIndex = 3;
            this.labelChoiseCriterion.Text = "Редактировать";
            // 
            // comboBoxCompare
            // 
            this.comboBoxCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCompare.FormattingEnabled = true;
            this.comboBoxCompare.Location = new System.Drawing.Point(8, 45);
            this.comboBoxCompare.Name = "comboBoxCompare";
            this.comboBoxCompare.Size = new System.Drawing.Size(1617, 33);
            this.comboBoxCompare.TabIndex = 2;
            this.comboBoxCompare.SelectedIndexChanged += new System.EventHandler(this.comboBoxCompare_SelectedIndexChanged);
            // 
            // dataGridViewCompare
            // 
            this.dataGridViewCompare.AllowUserToAddRows = false;
            this.dataGridViewCompare.AllowUserToDeleteRows = false;
            this.dataGridViewCompare.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewCompare.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCompare.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewCompare.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCompare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompare.EnableHeadersVisualStyles = false;
            this.dataGridViewCompare.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewCompare.Location = new System.Drawing.Point(8, 84);
            this.dataGridViewCompare.Name = "dataGridViewCompare";
            this.dataGridViewCompare.RowTemplate.Height = 33;
            this.dataGridViewCompare.Size = new System.Drawing.Size(1586, 805);
            this.dataGridViewCompare.TabIndex = 0;
            this.dataGridViewCompare.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCompare_CellValueChanged);
            // 
            // tabTask
            // 
            this.tabTask.Controls.Add(this.buttonLoadTaskFromFile);
            this.tabTask.Controls.Add(this.buttonSaveTaskInFile);
            this.tabTask.Controls.Add(this.buttonAddTask);
            this.tabTask.Controls.Add(this.dataGridViewTaskCompare);
            this.tabTask.Location = new System.Drawing.Point(8, 39);
            this.tabTask.Name = "tabTask";
            this.tabTask.Size = new System.Drawing.Size(1641, 945);
            this.tabTask.TabIndex = 3;
            this.tabTask.Text = "Цель";
            this.tabTask.UseVisualStyleBackColor = true;
            // 
            // buttonLoadTaskFromFile
            // 
            this.buttonLoadTaskFromFile.Location = new System.Drawing.Point(540, 13);
            this.buttonLoadTaskFromFile.Name = "buttonLoadTaskFromFile";
            this.buttonLoadTaskFromFile.Size = new System.Drawing.Size(298, 78);
            this.buttonLoadTaskFromFile.TabIndex = 4;
            this.buttonLoadTaskFromFile.Text = "Загрузить из файла";
            this.buttonLoadTaskFromFile.UseVisualStyleBackColor = true;
            this.buttonLoadTaskFromFile.Click += new System.EventHandler(this.buttonLoadTaskFromFile_Click);
            // 
            // buttonSaveTaskInFile
            // 
            this.buttonSaveTaskInFile.Location = new System.Drawing.Point(271, 13);
            this.buttonSaveTaskInFile.Name = "buttonSaveTaskInFile";
            this.buttonSaveTaskInFile.Size = new System.Drawing.Size(263, 78);
            this.buttonSaveTaskInFile.TabIndex = 3;
            this.buttonSaveTaskInFile.Text = "Сохранить в файл";
            this.buttonSaveTaskInFile.UseVisualStyleBackColor = true;
            this.buttonSaveTaskInFile.Click += new System.EventHandler(this.buttonSaveTaskInFile_Click);
            // 
            // buttonAddTask
            // 
            this.buttonAddTask.Location = new System.Drawing.Point(7, 13);
            this.buttonAddTask.Name = "buttonAddTask";
            this.buttonAddTask.Size = new System.Drawing.Size(258, 78);
            this.buttonAddTask.TabIndex = 1;
            this.buttonAddTask.Text = "Создать цель";
            this.buttonAddTask.UseVisualStyleBackColor = true;
            this.buttonAddTask.Click += new System.EventHandler(this.buttonAddTask_Click);
            // 
            // dataGridViewTaskCompare
            // 
            this.dataGridViewTaskCompare.AllowUserToAddRows = false;
            this.dataGridViewTaskCompare.AllowUserToDeleteRows = false;
            this.dataGridViewTaskCompare.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewTaskCompare.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewTaskCompare.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewTaskCompare.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTaskCompare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTaskCompare.EnableHeadersVisualStyles = false;
            this.dataGridViewTaskCompare.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewTaskCompare.Location = new System.Drawing.Point(7, 97);
            this.dataGridViewTaskCompare.Name = "dataGridViewTaskCompare";
            this.dataGridViewTaskCompare.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewTaskCompare.RowTemplate.Height = 33;
            this.dataGridViewTaskCompare.Size = new System.Drawing.Size(1592, 787);
            this.dataGridViewTaskCompare.TabIndex = 0;
            this.dataGridViewTaskCompare.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTaskCompare_CellValueChanged);
            // 
            // tabCriterions
            // 
            this.tabCriterions.AutoScroll = true;
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
            // buttonAddCriterion
            // 
            this.buttonAddCriterion.Location = new System.Drawing.Point(6, 6);
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
            this.dataGridViewCriterions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCriterions});
            this.dataGridViewCriterions.EnableHeadersVisualStyles = false;
            this.dataGridViewCriterions.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewCriterions.Location = new System.Drawing.Point(6, 84);
            this.dataGridViewCriterions.Name = "dataGridViewCriterions";
            this.dataGridViewCriterions.RowHeadersVisible = false;
            this.dataGridViewCriterions.RowTemplate.Height = 33;
            this.dataGridViewCriterions.Size = new System.Drawing.Size(1584, 800);
            this.dataGridViewCriterions.TabIndex = 0;
            this.dataGridViewCriterions.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCriterions_CellValueChanged);
            this.dataGridViewCriterions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewCriterions_KeyDown);
            // 
            // ColumnCriterions
            // 
            this.ColumnCriterions.HeaderText = "Критерии";
            this.ColumnCriterions.Name = "ColumnCriterions";
            this.ColumnCriterions.Width = 152;
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
            this.Controls.Add(this.tab);
            this.Name = "Form1";
            this.Text = "Метод анализа иерархий";
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.tab.ResumeLayout(false);
            this.tabOptions.ResumeLayout(false);
            this.tabOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOptions)).EndInit();
            this.tabCompares.ResumeLayout(false);
            this.tabCompares.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompare)).EndInit();
            this.tabTask.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaskCompare)).EndInit();
            this.tabCriterions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCriterions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.Button buttonGetResult;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.TabPage tabCriterions;
        private System.Windows.Forms.TabPage tabCompares;
        private System.Windows.Forms.DataGridView dataGridViewCompare;
        private System.Windows.Forms.DataGridView dataGridViewCriterions;
        private System.Windows.Forms.TabPage tabTask;
        private System.Windows.Forms.DataGridView dataGridViewTaskCompare;
        private System.Windows.Forms.Button buttonAddCriterion;
        private System.Windows.Forms.Button buttonAddTask;
        private System.Windows.Forms.Label labelSelectedTask;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Button buttonAddOption;
        private System.Windows.Forms.DataGridView dataGridViewOptions;
        private System.Windows.Forms.Label labelChoiseCriterion;
        private System.Windows.Forms.ComboBox comboBoxCompare;
        private System.Windows.Forms.Button buttonSaveTaskInFile;
        private System.Windows.Forms.Button buttonLoadTaskFromFile;
        private System.Windows.Forms.Label labelResultHeader;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOptions;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCriterions;
    }
}

