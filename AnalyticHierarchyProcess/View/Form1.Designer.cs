namespace AnalyticHierarchyProcess
{
    partial class FormView
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
            this.buttonGetResult = new System.Windows.Forms.Button();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabCalculation = new System.Windows.Forms.TabPage();
            this.dataGridViewCalculation = new System.Windows.Forms.DataGridView();
            this.buttonShowCalc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelResultHeader = new System.Windows.Forms.Label();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.buttonDeleteOption = new System.Windows.Forms.Button();
            this.labelIdealResult = new System.Windows.Forms.Label();
            this.labelNormResult = new System.Windows.Forms.Label();
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
            this.buttonDeleteCriterion = new System.Windows.Forms.Button();
            this.buttonAddCriterion = new System.Windows.Forms.Button();
            this.dataGridViewCriterions = new System.Windows.Forms.DataGridView();
            this.ColumnCriterions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.tab.SuspendLayout();
            this.tabCalculation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCalculation)).BeginInit();
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
            // buttonGetResult
            // 
            this.buttonGetResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGetResult.Location = new System.Drawing.Point(14, 25);
            this.buttonGetResult.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGetResult.Name = "buttonGetResult";
            this.buttonGetResult.Size = new System.Drawing.Size(248, 65);
            this.buttonGetResult.TabIndex = 9;
            this.buttonGetResult.Text = "Расчитать";
            this.buttonGetResult.UseVisualStyleBackColor = true;
            this.buttonGetResult.Click += new System.EventHandler(this.buttonGetResult_Click);
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabCalculation);
            this.tab.Controls.Add(this.tabOptions);
            this.tab.Controls.Add(this.tabCompares);
            this.tab.Controls.Add(this.tabTask);
            this.tab.Controls.Add(this.tabCriterions);
            this.tab.Location = new System.Drawing.Point(6, 6);
            this.tab.Margin = new System.Windows.Forms.Padding(4);
            this.tab.Name = "tab";
            this.tab.Padding = new System.Drawing.Point(6, 6);
            this.tab.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1656, 992);
            this.tab.TabIndex = 11;
            this.tab.SelectedIndexChanged += new System.EventHandler(this.tab_SelectedIndexChanged);
            // 
            // tabCalculation
            // 
            this.tabCalculation.Controls.Add(this.dataGridViewCalculation);
            this.tabCalculation.Controls.Add(this.buttonGetResult);
            this.tabCalculation.Controls.Add(this.buttonShowCalc);
            this.tabCalculation.Controls.Add(this.label1);
            this.tabCalculation.Controls.Add(this.labelResultHeader);
            this.tabCalculation.Location = new System.Drawing.Point(8, 43);
            this.tabCalculation.Margin = new System.Windows.Forms.Padding(6);
            this.tabCalculation.Name = "tabCalculation";
            this.tabCalculation.Size = new System.Drawing.Size(1640, 941);
            this.tabCalculation.TabIndex = 4;
            this.tabCalculation.Text = "Расчеты";
            this.tabCalculation.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCalculation
            // 
            this.dataGridViewCalculation.AllowUserToAddRows = false;
            this.dataGridViewCalculation.AllowUserToDeleteRows = false;
            this.dataGridViewCalculation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewCalculation.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCalculation.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewCalculation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCalculation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCalculation.Enabled = false;
            this.dataGridViewCalculation.EnableHeadersVisualStyles = false;
            this.dataGridViewCalculation.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewCalculation.Location = new System.Drawing.Point(14, 94);
            this.dataGridViewCalculation.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewCalculation.Name = "dataGridViewCalculation";
            this.dataGridViewCalculation.RowTemplate.Height = 33;
            this.dataGridViewCalculation.Size = new System.Drawing.Size(1586, 806);
            this.dataGridViewCalculation.TabIndex = 18;
            // 
            // buttonShowCalc
            // 
            this.buttonShowCalc.Location = new System.Drawing.Point(850, 25);
            this.buttonShowCalc.Margin = new System.Windows.Forms.Padding(4);
            this.buttonShowCalc.Name = "buttonShowCalc";
            this.buttonShowCalc.Size = new System.Drawing.Size(244, 65);
            this.buttonShowCalc.TabIndex = 16;
            this.buttonShowCalc.Text = "Показать расчеты";
            this.buttonShowCalc.UseVisualStyleBackColor = true;
            this.buttonShowCalc.Click += new System.EventHandler(this.buttonShowCalc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(564, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Расчет на основании нормализированых приоритетов:";
            // 
            // labelResultHeader
            // 
            this.labelResultHeader.AutoSize = true;
            this.labelResultHeader.Location = new System.Drawing.Point(270, 40);
            this.labelResultHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelResultHeader.Name = "labelResultHeader";
            this.labelResultHeader.Size = new System.Drawing.Size(549, 25);
            this.labelResultHeader.TabIndex = 14;
            this.labelResultHeader.Text = "Расчет на основании идеализированых приоритетов:";
            // 
            // tabOptions
            // 
            this.tabOptions.AutoScroll = true;
            this.tabOptions.Controls.Add(this.buttonDeleteOption);
            this.tabOptions.Controls.Add(this.labelIdealResult);
            this.tabOptions.Controls.Add(this.labelNormResult);
            this.tabOptions.Controls.Add(this.dataGridViewOptions);
            this.tabOptions.Controls.Add(this.buttonAddOption);
            this.tabOptions.Location = new System.Drawing.Point(8, 43);
            this.tabOptions.Margin = new System.Windows.Forms.Padding(4);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(4);
            this.tabOptions.Size = new System.Drawing.Size(1640, 941);
            this.tabOptions.TabIndex = 0;
            this.tabOptions.Text = "Объекты";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteOption
            // 
            this.buttonDeleteOption.Location = new System.Drawing.Point(278, 14);
            this.buttonDeleteOption.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeleteOption.Name = "buttonDeleteOption";
            this.buttonDeleteOption.Size = new System.Drawing.Size(264, 65);
            this.buttonDeleteOption.TabIndex = 19;
            this.buttonDeleteOption.Text = "Удалить выбранный объект";
            this.buttonDeleteOption.UseVisualStyleBackColor = true;
            this.buttonDeleteOption.Click += new System.EventHandler(this.buttonDeleteOption_Click);
            // 
            // labelIdealResult
            // 
            this.labelIdealResult.AutoSize = true;
            this.labelIdealResult.Location = new System.Drawing.Point(1096, 19);
            this.labelIdealResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIdealResult.Name = "labelIdealResult";
            this.labelIdealResult.Size = new System.Drawing.Size(0, 25);
            this.labelIdealResult.TabIndex = 18;
            // 
            // labelNormResult
            // 
            this.labelNormResult.AutoSize = true;
            this.labelNormResult.Location = new System.Drawing.Point(1100, 56);
            this.labelNormResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNormResult.Name = "labelNormResult";
            this.labelNormResult.Size = new System.Drawing.Size(0, 25);
            this.labelNormResult.TabIndex = 15;
            // 
            // dataGridViewOptions
            // 
            this.dataGridViewOptions.AllowUserToAddRows = false;
            this.dataGridViewOptions.AllowUserToDeleteRows = false;
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
            this.dataGridViewOptions.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewOptions.Name = "dataGridViewOptions";
            this.dataGridViewOptions.RowHeadersVisible = false;
            this.dataGridViewOptions.RowTemplate.Height = 33;
            this.dataGridViewOptions.Size = new System.Drawing.Size(1580, 790);
            this.dataGridViewOptions.TabIndex = 11;
            this.dataGridViewOptions.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOptions_CellEndEdit);
            this.dataGridViewOptions.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewOptions_CellValidating);
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
            this.buttonAddOption.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddOption.Name = "buttonAddOption";
            this.buttonAddOption.Size = new System.Drawing.Size(264, 65);
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
            this.tabCompares.Location = new System.Drawing.Point(8, 43);
            this.tabCompares.Margin = new System.Windows.Forms.Padding(4);
            this.tabCompares.Name = "tabCompares";
            this.tabCompares.Size = new System.Drawing.Size(1640, 941);
            this.tabCompares.TabIndex = 2;
            this.tabCompares.Text = "Сравнения";
            this.tabCompares.UseVisualStyleBackColor = true;
            // 
            // labelChoiseCriterion
            // 
            this.labelChoiseCriterion.AutoSize = true;
            this.labelChoiseCriterion.Location = new System.Drawing.Point(10, 12);
            this.labelChoiseCriterion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChoiseCriterion.Name = "labelChoiseCriterion";
            this.labelChoiseCriterion.Size = new System.Drawing.Size(163, 25);
            this.labelChoiseCriterion.TabIndex = 3;
            this.labelChoiseCriterion.Text = "Редактировать";
            // 
            // comboBoxCompare
            // 
            this.comboBoxCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCompare.FormattingEnabled = true;
            this.comboBoxCompare.Location = new System.Drawing.Point(8, 44);
            this.comboBoxCompare.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCompare.Name = "comboBoxCompare";
            this.comboBoxCompare.Size = new System.Drawing.Size(1616, 33);
            this.comboBoxCompare.TabIndex = 2;
            this.comboBoxCompare.DropDown += new System.EventHandler(this.comboBoxCompare_DropDown);
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
            this.dataGridViewCompare.Location = new System.Drawing.Point(8, 85);
            this.dataGridViewCompare.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewCompare.Name = "dataGridViewCompare";
            this.dataGridViewCompare.RowTemplate.Height = 33;
            this.dataGridViewCompare.Size = new System.Drawing.Size(1586, 806);
            this.dataGridViewCompare.TabIndex = 0;
            this.dataGridViewCompare.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCompare_CellEndEdit);
            this.dataGridViewCompare.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewCompare_CellValidating);
            // 
            // tabTask
            // 
            this.tabTask.Controls.Add(this.buttonLoadTaskFromFile);
            this.tabTask.Controls.Add(this.buttonSaveTaskInFile);
            this.tabTask.Controls.Add(this.buttonAddTask);
            this.tabTask.Controls.Add(this.dataGridViewTaskCompare);
            this.tabTask.Location = new System.Drawing.Point(8, 43);
            this.tabTask.Margin = new System.Windows.Forms.Padding(4);
            this.tabTask.Name = "tabTask";
            this.tabTask.Size = new System.Drawing.Size(1640, 941);
            this.tabTask.TabIndex = 3;
            this.tabTask.Text = "Цель";
            this.tabTask.UseVisualStyleBackColor = true;
            // 
            // buttonLoadTaskFromFile
            // 
            this.buttonLoadTaskFromFile.Location = new System.Drawing.Point(540, 13);
            this.buttonLoadTaskFromFile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLoadTaskFromFile.Name = "buttonLoadTaskFromFile";
            this.buttonLoadTaskFromFile.Size = new System.Drawing.Size(258, 79);
            this.buttonLoadTaskFromFile.TabIndex = 4;
            this.buttonLoadTaskFromFile.Text = "Загрузить из файла";
            this.buttonLoadTaskFromFile.UseVisualStyleBackColor = true;
            this.buttonLoadTaskFromFile.Click += new System.EventHandler(this.buttonLoadTaskFromFile_Click);
            // 
            // buttonSaveTaskInFile
            // 
            this.buttonSaveTaskInFile.Location = new System.Drawing.Point(274, 13);
            this.buttonSaveTaskInFile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveTaskInFile.Name = "buttonSaveTaskInFile";
            this.buttonSaveTaskInFile.Size = new System.Drawing.Size(258, 79);
            this.buttonSaveTaskInFile.TabIndex = 3;
            this.buttonSaveTaskInFile.Text = "Сохранить в файл";
            this.buttonSaveTaskInFile.UseVisualStyleBackColor = true;
            this.buttonSaveTaskInFile.Click += new System.EventHandler(this.buttonSaveTaskInFile_Click);
            // 
            // buttonAddTask
            // 
            this.buttonAddTask.Location = new System.Drawing.Point(8, 13);
            this.buttonAddTask.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddTask.Name = "buttonAddTask";
            this.buttonAddTask.Size = new System.Drawing.Size(258, 79);
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
            this.dataGridViewTaskCompare.Location = new System.Drawing.Point(8, 96);
            this.dataGridViewTaskCompare.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewTaskCompare.Name = "dataGridViewTaskCompare";
            this.dataGridViewTaskCompare.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewTaskCompare.RowTemplate.Height = 33;
            this.dataGridViewTaskCompare.Size = new System.Drawing.Size(1592, 787);
            this.dataGridViewTaskCompare.TabIndex = 0;
            this.dataGridViewTaskCompare.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTaskCompare_CellEndEdit);
            this.dataGridViewTaskCompare.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewTaskCompare_CellValidating);
            // 
            // tabCriterions
            // 
            this.tabCriterions.AutoScroll = true;
            this.tabCriterions.Controls.Add(this.buttonDeleteCriterion);
            this.tabCriterions.Controls.Add(this.buttonAddCriterion);
            this.tabCriterions.Controls.Add(this.dataGridViewCriterions);
            this.tabCriterions.Location = new System.Drawing.Point(8, 43);
            this.tabCriterions.Margin = new System.Windows.Forms.Padding(4);
            this.tabCriterions.Name = "tabCriterions";
            this.tabCriterions.Padding = new System.Windows.Forms.Padding(4);
            this.tabCriterions.Size = new System.Drawing.Size(1640, 941);
            this.tabCriterions.TabIndex = 1;
            this.tabCriterions.Text = "Критерии";
            this.tabCriterions.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteCriterion
            // 
            this.buttonDeleteCriterion.Location = new System.Drawing.Point(272, 6);
            this.buttonDeleteCriterion.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeleteCriterion.Name = "buttonDeleteCriterion";
            this.buttonDeleteCriterion.Size = new System.Drawing.Size(258, 71);
            this.buttonDeleteCriterion.TabIndex = 2;
            this.buttonDeleteCriterion.Text = "Удалить выбранный критерий";
            this.buttonDeleteCriterion.UseVisualStyleBackColor = true;
            this.buttonDeleteCriterion.Click += new System.EventHandler(this.buttonDeleteCriterion_Click);
            // 
            // buttonAddCriterion
            // 
            this.buttonAddCriterion.Location = new System.Drawing.Point(6, 6);
            this.buttonAddCriterion.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddCriterion.Name = "buttonAddCriterion";
            this.buttonAddCriterion.Size = new System.Drawing.Size(258, 71);
            this.buttonAddCriterion.TabIndex = 1;
            this.buttonAddCriterion.Text = "Добавить критерий";
            this.buttonAddCriterion.UseVisualStyleBackColor = true;
            this.buttonAddCriterion.Click += new System.EventHandler(this.buttonAddCriterion_Click);
            // 
            // dataGridViewCriterions
            // 
            this.dataGridViewCriterions.AllowUserToAddRows = false;
            this.dataGridViewCriterions.AllowUserToDeleteRows = false;
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
            this.dataGridViewCriterions.Location = new System.Drawing.Point(6, 85);
            this.dataGridViewCriterions.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewCriterions.Name = "dataGridViewCriterions";
            this.dataGridViewCriterions.RowHeadersVisible = false;
            this.dataGridViewCriterions.RowTemplate.Height = 33;
            this.dataGridViewCriterions.Size = new System.Drawing.Size(1584, 800);
            this.dataGridViewCriterions.TabIndex = 0;
            this.dataGridViewCriterions.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCriterions_CellEndEdit);
            this.dataGridViewCriterions.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewCriterions_CellValidating);
            // 
            // ColumnCriterions
            // 
            this.ColumnCriterions.HeaderText = "Критерии";
            this.ColumnCriterions.Name = "ColumnCriterions";
            this.ColumnCriterions.Width = 152;
            // 
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1664, 1171);
            this.Controls.Add(this.tab);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormView";
            this.Text = "Метод анализа иерархий";
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.tab.ResumeLayout(false);
            this.tabCalculation.ResumeLayout(false);
            this.tabCalculation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCalculation)).EndInit();
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

        }

        #endregion
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
        private System.Windows.Forms.Button buttonAddOption;
        private System.Windows.Forms.DataGridView dataGridViewOptions;
        private System.Windows.Forms.Label labelChoiseCriterion;
        private System.Windows.Forms.ComboBox comboBoxCompare;
        private System.Windows.Forms.Button buttonSaveTaskInFile;
        private System.Windows.Forms.Button buttonLoadTaskFromFile;
        private System.Windows.Forms.Label labelResultHeader;
        private System.Windows.Forms.Label labelNormResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOptions;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCriterions;
        private System.Windows.Forms.Button buttonShowCalc;
        private System.Windows.Forms.Label labelIdealResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabCalculation;
        private System.Windows.Forms.DataGridView dataGridViewCalculation;
        private System.Windows.Forms.Button buttonDeleteOption;
        private System.Windows.Forms.Button buttonDeleteCriterion;
    }
}

