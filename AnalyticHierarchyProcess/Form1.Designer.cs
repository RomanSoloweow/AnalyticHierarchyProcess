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
            this.AddTask = new System.Windows.Forms.Button();
            this.LabelTasks = new System.Windows.Forms.Label();
            this.ButtonOpenFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonClear = new System.Windows.Forms.Button();
            this.comboBoxAllTask = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.buttonAddOption = new System.Windows.Forms.Button();
            this.tabCompare = new System.Windows.Forms.TabPage();
            this.dataGridViewCompare = new System.Windows.Forms.DataGridView();
            this.tabCriterions = new System.Windows.Forms.TabPage();
            this.dataGridViewCriterions = new System.Windows.Forms.DataGridView();
            this.tabTask = new System.Windows.Forms.TabPage();
            this.dataGridViewTasks = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.tabs.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabCompare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompare)).BeginInit();
            this.tabCriterions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCriterions)).BeginInit();
            this.tabTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // AddTask
            // 
            this.AddTask.Location = new System.Drawing.Point(90, 364);
            this.AddTask.Name = "AddTask";
            this.AddTask.Size = new System.Drawing.Size(239, 55);
            this.AddTask.TabIndex = 2;
            this.AddTask.Text = "Добавить цель";
            this.AddTask.UseVisualStyleBackColor = true;
            this.AddTask.Click += new System.EventHandler(this.AddTask_Click);
            // 
            // LabelTasks
            // 
            this.LabelTasks.AutoSize = true;
            this.LabelTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelTasks.Location = new System.Drawing.Point(6, 0);
            this.LabelTasks.Name = "LabelTasks";
            this.LabelTasks.Size = new System.Drawing.Size(164, 31);
            this.LabelTasks.TabIndex = 4;
            this.LabelTasks.Text = "Выбор цели";
            // 
            // ButtonOpenFile
            // 
            this.ButtonOpenFile.Location = new System.Drawing.Point(832, 799);
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
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(504, 14);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(190, 56);
            this.buttonClear.TabIndex = 6;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // comboBoxAllTask
            // 
            this.comboBoxAllTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAllTask.FormattingEnabled = true;
            this.comboBoxAllTask.Location = new System.Drawing.Point(6, 37);
            this.comboBoxAllTask.Name = "comboBoxAllTask";
            this.comboBoxAllTask.Size = new System.Drawing.Size(238, 33);
            this.comboBoxAllTask.TabIndex = 7;
            this.comboBoxAllTask.SelectedIndexChanged += new System.EventHandler(this.comboBoxAllTask_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(641, 399);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(739, 280);
            this.button1.TabIndex = 9;
            this.button1.Text = "Тест";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(793, 194);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(268, 78);
            this.button2.TabIndex = 10;
            this.button2.Tag = "buttonCriterions";
            this.button2.Text = "Критерии";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabMain);
            this.tabs.Controls.Add(this.tabCompare);
            this.tabs.Controls.Add(this.tabTask);
            this.tabs.Controls.Add(this.tabCriterions);
            this.tabs.Location = new System.Drawing.Point(1, 3);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1657, 1029);
            this.tabs.TabIndex = 11;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            this.tabs.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabs_Selecting);
            // 
            // tabMain
            // 
            this.tabMain.AutoScroll = true;
            this.tabMain.Controls.Add(this.buttonAddOption);
            this.tabMain.Controls.Add(this.AddTask);
            this.tabMain.Controls.Add(this.comboBoxAllTask);
            this.tabMain.Controls.Add(this.button1);
            this.tabMain.Controls.Add(this.ButtonOpenFile);
            this.tabMain.Controls.Add(this.buttonClear);
            this.tabMain.Controls.Add(this.button2);
            this.tabMain.Controls.Add(this.LabelTasks);
            this.tabMain.Location = new System.Drawing.Point(8, 39);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(1641, 982);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Главная";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // buttonAddOption
            // 
            this.buttonAddOption.Location = new System.Drawing.Point(456, 194);
            this.buttonAddOption.Name = "buttonAddOption";
            this.buttonAddOption.Size = new System.Drawing.Size(238, 63);
            this.buttonAddOption.TabIndex = 11;
            this.buttonAddOption.Text = "Добавить альтернативу";
            this.buttonAddOption.UseVisualStyleBackColor = true;
            this.buttonAddOption.Click += new System.EventHandler(this.buttonAddOption_Click);
            // 
            // tabCompare
            // 
            this.tabCompare.AutoScroll = true;
            this.tabCompare.Controls.Add(this.dataGridViewCompare);
            this.tabCompare.Location = new System.Drawing.Point(8, 39);
            this.tabCompare.Name = "tabCompare";
            this.tabCompare.Size = new System.Drawing.Size(1641, 982);
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
            this.dataGridViewCompare.Location = new System.Drawing.Point(-8, 0);
            this.dataGridViewCompare.Name = "dataGridViewCompare";
            this.dataGridViewCompare.RowHeadersVisible = false;
            this.dataGridViewCompare.RowTemplate.Height = 33;
            this.dataGridViewCompare.Size = new System.Drawing.Size(1629, 974);
            this.dataGridViewCompare.TabIndex = 0;
            // 
            // tabCriterions
            // 
            this.tabCriterions.AutoScroll = true;
            this.tabCriterions.Controls.Add(this.dataGridViewCriterions);
            this.tabCriterions.Location = new System.Drawing.Point(8, 39);
            this.tabCriterions.Name = "tabCriterions";
            this.tabCriterions.Padding = new System.Windows.Forms.Padding(3);
            this.tabCriterions.Size = new System.Drawing.Size(1641, 982);
            this.tabCriterions.TabIndex = 1;
            this.tabCriterions.Text = "Критерии";
            this.tabCriterions.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCriterions
            // 
            this.dataGridViewCriterions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewCriterions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewCriterions.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewCriterions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCriterions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCriterions.Location = new System.Drawing.Point(0, 3);
            this.dataGridViewCriterions.Name = "dataGridViewCriterions";
            this.dataGridViewCriterions.RowHeadersVisible = false;
            this.dataGridViewCriterions.RowTemplate.Height = 33;
            this.dataGridViewCriterions.Size = new System.Drawing.Size(1638, 973);
            this.dataGridViewCriterions.TabIndex = 0;
            this.dataGridViewCriterions.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewCriterions_UserAddedRow);
            this.dataGridViewCriterions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewCriterions_KeyDown);
            // 
            // tabTask
            // 
            this.tabTask.Controls.Add(this.dataGridViewTasks);
            this.tabTask.Location = new System.Drawing.Point(8, 39);
            this.tabTask.Name = "tabTask";
            this.tabTask.Size = new System.Drawing.Size(1641, 982);
            this.tabTask.TabIndex = 3;
            this.tabTask.Text = "Цели";
            this.tabTask.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTasks
            // 
            this.dataGridViewTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewTasks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewTasks.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTasks.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewTasks.Name = "dataGridViewTasks";
            this.dataGridViewTasks.RowHeadersVisible = false;
            this.dataGridViewTasks.RowTemplate.Height = 33;
            this.dataGridViewTasks.Size = new System.Drawing.Size(1635, 939);
            this.dataGridViewTasks.TabIndex = 0;
            this.dataGridViewTasks.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewTasks_UserAddedRow);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1663, 1241);
            this.Controls.Add(this.tabs);
            this.Name = "Form1";
            this.Text = "Метод анализа иерархий";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.tabs.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.tabCompare.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompare)).EndInit();
            this.tabCriterions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCriterions)).EndInit();
            this.tabTask.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AddTask;
        private System.Windows.Forms.Label LabelTasks;
        private System.Windows.Forms.Button ButtonOpenFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ComboBox comboBoxAllTask;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabCriterions;
        private System.Windows.Forms.TabPage tabCompare;
        private System.Windows.Forms.DataGridView dataGridViewCompare;
        private System.Windows.Forms.DataGridView dataGridViewCriterions;
        private System.Windows.Forms.Button buttonAddOption;
        private System.Windows.Forms.TabPage tabTask;
        private System.Windows.Forms.DataGridView dataGridViewTasks;
    }
}

