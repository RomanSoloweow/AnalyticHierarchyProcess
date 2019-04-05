using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace InputBox
{
    class InputBoxs
    {
        public static DialogResult InputBox(string title, string label_text, List<string> combobox_items, ref string value, ref string key)
        {
            Form form = new Form();

            Label label = new Label();
            label.Text = label_text;
            label.Location = new Point(0, 0);
            label.Size = new Size(TextRenderer.MeasureText(title, form.Font).Width, TextRenderer.MeasureText(title, form.Font).Height);
            label.AutoSize = true;

            TextBox textBox = new TextBox();
            textBox.Text = value;
            textBox.Size = new Size(TextRenderer.MeasureText(textBox.Text, form.Font).Width + 10, TextRenderer.MeasureText(textBox.Text, form.Font).Height);
            textBox.Location = new Point(0, label.Size.Height + 1);
            textBox.MaxLength = 50;
            textBox.TextChanged += textBox_TextChanged;
            void textBox_TextChanged(object sender, EventArgs e)
            {
                if (textBox.Text.Length == 1)
                {
                    textBox.SelectionStart = 0;
                }
                textBox.Size = new Size(TextRenderer.MeasureText(textBox.Text, form.Font).Width + 10, TextRenderer.MeasureText(textBox.Text, form.Font).Height);
                if (textBox.Text.Length == 1)
                {
                    textBox.SelectionStart = 1;
                }
            }

            ComboBox comboBox = new ComboBox();
            comboBox.Location = new Point(0, textBox.Height + textBox.Location.Y + 1);
            comboBox.Size = new Size(30, TextRenderer.MeasureText("  ", form.Font).Height);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 0; i < combobox_items.Count; i++)
            {
                comboBox.Items.Add(combobox_items[i]);
                if (TextRenderer.MeasureText(combobox_items[i], form.Font).Width > comboBox.Size.Width - 17)
                {
                    comboBox.Size = new Size(TextRenderer.MeasureText(combobox_items[i], form.Font).Width + 17, TextRenderer.MeasureText("  ", form.Font).Height);
                }
            }
            string k_key = key;
            if (k_key != "")
                comboBox.SelectedIndex = combobox_items.FindIndex(x => x == k_key);

            Button buttonOk = new Button();
            buttonOk.Text = "OK";
            buttonOk.AutoSize = true;
            buttonOk.DialogResult = DialogResult.OK;
            buttonOk.Location = new Point(comboBox.Size.Width + 1, comboBox.Location.Y);

            Button buttonCancel = new Button();
            buttonCancel.Text = "Cancel";
            buttonCancel.AutoSize = true;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(buttonOk.Size.Width + buttonOk.Location.X + 1, buttonOk.Location.Y);

            form.Text = title;
            form.ClientSize = new Size(buttonCancel.Location.X + buttonCancel.Size.Width + 1, buttonCancel.Location.Y + buttonCancel.Size.Height + 1);
            if (form.ClientSize.Width < TextRenderer.MeasureText(title, form.Font).Width)
                form.ClientSize = new Size(TextRenderer.MeasureText(title, form.Font).Width + 1, buttonCancel.Location.Y + buttonCancel.Size.Height + 1);
            form.Controls.AddRange(new Control[] { label, textBox, comboBox, buttonOk, buttonCancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            if (comboBox.SelectedIndex != -1)
                key = comboBox.Items[comboBox.SelectedIndex].ToString();
            else
                key = null;
            return dialogResult;
        }
        public static DialogResult InputBox(string title, string label_text, string label2_text, List<string> combobox_items, List<string> combobox2_items, ref string key, ref string key2)
        {
            Form form = new Form();

            Label label = new Label();
            label.Text = label_text;
            label.Location = new Point(0, 0);
            label.Size = new Size(TextRenderer.MeasureText(title, form.Font).Width, TextRenderer.MeasureText(title, form.Font).Height);
            label.AutoSize = true;

            ComboBox comboBox = new ComboBox();
            comboBox.Location = new Point(0, label.Size.Height + 1);
            comboBox.Size = new Size(30, TextRenderer.MeasureText("  ", form.Font).Height);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 0; i < combobox_items.Count; i++)
            {
                comboBox.Items.Add(combobox_items[i]);
                if (TextRenderer.MeasureText(combobox_items[i], form.Font).Width > comboBox.Size.Width - 17)
                {
                    comboBox.Size = new Size(TextRenderer.MeasureText(combobox_items[i], form.Font).Width + 17, TextRenderer.MeasureText("  ", form.Font).Height);
                }
            }
            string k_key = key;
            if (k_key != "")
                comboBox.SelectedIndex = combobox_items.FindIndex(x => x == k_key);
            else
                comboBox.SelectedIndex = 0;

            Label label2 = new Label();
            label2.Text = label2_text;
            label2.Location = new Point(0, comboBox.Height + comboBox.Location.Y + 1);
            label2.Size = new Size(TextRenderer.MeasureText(title, form.Font).Width, TextRenderer.MeasureText(title, form.Font).Height);
            label2.AutoSize = true;


            ComboBox comboBox2 = new ComboBox();
            comboBox2.Location = new Point(0, label2.Height + label2.Location.Y + 1);
            comboBox2.Size = new Size(30, TextRenderer.MeasureText("  ", form.Font).Height);
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 0; i < combobox2_items.Count; i++)
            {
                comboBox2.Items.Add(combobox2_items[i]);
                if (TextRenderer.MeasureText(combobox2_items[i], form.Font).Width > comboBox2.Size.Width - 17)
                {
                    comboBox2.Size = new Size(TextRenderer.MeasureText(combobox2_items[i], form.Font).Width + 17, TextRenderer.MeasureText("  ", form.Font).Height);
                }
            }
            string k_key2 = key2;
            if (k_key2 != "")
                comboBox2.SelectedIndex = combobox2_items.FindIndex(x => x == k_key2);
            else
                comboBox2.SelectedIndex = 0;

            Button buttonOk = new Button();
            buttonOk.Text = "OK";
            buttonOk.AutoSize = true;
            buttonOk.DialogResult = DialogResult.OK;
            buttonOk.Location = new Point(comboBox2.Size.Width + 1, comboBox2.Location.Y + 1);

            Button buttonCancel = new Button();
            buttonCancel.Text = "Cancel";
            buttonCancel.AutoSize = true;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(buttonOk.Size.Width + buttonOk.Location.X + 1, buttonOk.Location.Y);

            form.Text = title;
            form.ClientSize = new Size(buttonCancel.Location.X + buttonCancel.Size.Width + 1, buttonCancel.Location.Y + buttonCancel.Size.Height + 1);
            if (form.ClientSize.Width < TextRenderer.MeasureText(title, form.Font).Width)
                form.ClientSize = new Size(TextRenderer.MeasureText(title, form.Font).Width + 1, buttonCancel.Location.Y + buttonCancel.Size.Height + 1);
            form.Controls.AddRange(new Control[] { label, label2, comboBox, comboBox2, buttonOk, buttonCancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            DialogResult dialogResult = form.ShowDialog();
            if (comboBox.SelectedIndex != -1)
                key = comboBox.Items[comboBox.SelectedIndex].ToString();
            else
                key = null;
            if (comboBox2.SelectedIndex != -1)
                key2 = comboBox2.Items[comboBox2.SelectedIndex].ToString();
            else
                key2 = null;
            return dialogResult;
        }
        public static DialogResult InputBox(string title, string label_text, string label2_text, ref string value, ref string value2)
        {
            Form form = new Form();

            Label label = new Label();
            label.Text = label_text;
            label.Location = new Point(0, 0);
            label.Size = new Size(TextRenderer.MeasureText(title, form.Font).Width, TextRenderer.MeasureText(title, form.Font).Height);
            label.AutoSize = true;

            TextBox textBox = new TextBox();
            textBox.Text = value;
            textBox.Location = new Point(0, label.Size.Height + 1);
            textBox.MaxLength = 20;
            textBox.TextChanged += textBox_TextChanged;
            textBox.Size = new Size(TextRenderer.MeasureText(value, form.Font).Width + 10, TextRenderer.MeasureText(textBox.Text, form.Font).Height);
            void textBox_TextChanged(object sender, EventArgs e)
            {
                if (textBox.Text.Length == 1)
                {
                    textBox.SelectionStart = 0;
                }
                textBox.Size = new Size(TextRenderer.MeasureText(textBox.Text, form.Font).Width + 10, TextRenderer.MeasureText(textBox.Text, form.Font).Height);
                if (textBox.Text.Length == 1)
                {
                    textBox.SelectionStart = 1;
                }
            }


            Label label2 = new Label();
            label2.Text = label2_text;
            label2.Location = new Point(0, textBox.Height + textBox.Location.Y + 1);
            label2.Size = new Size(TextRenderer.MeasureText(title, form.Font).Width, TextRenderer.MeasureText(title, form.Font).Height);
            label2.AutoSize = true;

            TextBox textBox2 = new TextBox();
            textBox2.Text = value2;
            textBox2.Location = new Point(0, label2.Height + label2.Location.Y + 1);
            textBox2.MaxLength = 20;
            textBox2.Size = new Size(TextRenderer.MeasureText(value2, form.Font).Width + 10, TextRenderer.MeasureText(textBox2.Text, form.Font).Height);
            textBox2.TextChanged += textBox2_TextChanged;
            void textBox2_TextChanged(object sender, EventArgs e)
            {
                if (textBox2.Text.Length == 1)
                {
                    textBox2.SelectionStart = 0;
                }
                textBox2.Size = new Size(TextRenderer.MeasureText(textBox2.Text, form.Font).Width + 10, TextRenderer.MeasureText(textBox2.Text, form.Font).Height);
                if (textBox2.Text.Length == 1)
                {
                    textBox2.SelectionStart = 1;
                }
            }


            Button buttonOk = new Button();
            buttonOk.Text = "OK";
            buttonOk.AutoSize = true;
            buttonOk.DialogResult = DialogResult.OK;
            buttonOk.Location = new Point(textBox2.Size.Width + 1, textBox2.Location.Y + textBox2.Height + 1);

            Button buttonCancel = new Button();
            buttonCancel.Text = "Cancel";
            buttonCancel.AutoSize = true;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(buttonOk.Size.Width + buttonOk.Location.X + 1, buttonOk.Location.Y);

            form.Text = title;
            form.ClientSize = new Size(buttonCancel.Location.X + buttonCancel.Size.Width + 1, buttonCancel.Location.Y + buttonCancel.Size.Height + 1);
            if (form.ClientSize.Width < TextRenderer.MeasureText(title, form.Font).Width)
                form.ClientSize = new Size(TextRenderer.MeasureText(title, form.Font).Width + 1, buttonCancel.Location.Y + buttonCancel.Size.Height + 1);
            form.Controls.AddRange(new Control[] { label, label2, textBox, textBox2, buttonOk, buttonCancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            value2 = textBox2.Text;
            return dialogResult;
        }
        public static DialogResult InputBox(string title, string label_text, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();


            label.Text = label_text;
            label.Location = new Point(0, 0);
            label.Size = new Size(TextRenderer.MeasureText(title, form.Font).Width, TextRenderer.MeasureText(title, form.Font).Height);
            label.AutoSize = true;
                   
            textBox.Text = value;
            textBox.Size = new Size(TextRenderer.MeasureText(value, form.Font).Width + 10, TextRenderer.MeasureText(value, form.Font).Height);
            textBox.Location = new Point(0, label.Size.Height + 1);
            textBox.TextChanged += textBox_TextChanged;
            void textBox_TextChanged(object sender, EventArgs e)
            {
                if (textBox.Text.Length == 1)
                {
                    textBox.SelectionStart = 0;
                }
                textBox.Size = new Size(TextRenderer.MeasureText(textBox.Text, form.Font).Width + 10, TextRenderer.MeasureText(textBox.Text, form.Font).Height);

                if (textBox.Size.Width >= (buttonCancel.Location.X + buttonCancel.Width))
                    form.Width = textBox.Size.Width + 20;

                if (textBox.Text.Length == 1)
                {
                    textBox.SelectionStart = 1;
                }
            }

           
            buttonOk.Text = "OK";
            buttonOk.AutoSize = true;
            buttonOk.DialogResult = DialogResult.OK;
            buttonOk.Location = new Point(textBox.Size.Width + 1, textBox.Location.Y + textBox.Height + 1);

           
            buttonCancel.Text = "Cancel";
            buttonCancel.AutoSize = true;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(buttonOk.Size.Width + buttonOk.Location.X + 1, buttonOk.Location.Y);

            form.Text = title;
            form.ClientSize = new Size(buttonCancel.Location.X + buttonCancel.Size.Width + 1, buttonCancel.Location.Y + buttonCancel.Size.Height + 1);
            //if (form.ClientSize.Width < TextRenderer.MeasureText(title, form.Font).Width)
               // form.ClientSize = new Size(TextRenderer.MeasureText(title, form.Font).Width + 1, buttonCancel.Location.Y + buttonCancel.Size.Height + 1);

          //  if (TextRenderer.MeasureText(title, form.Font).Width>buttonCancel.Location.X)
               // form.ClientSize = new Size(TextRenderer.MeasureText(title, form.Font).Width + 1, buttonCancel.Location.Y + buttonCancel.Size.Height + 1);

            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
        public static DialogResult InputBox(string title, string check_text, ref bool value)
        {
            Form form = new Form();
            CheckBox checkBox = new CheckBox();
            checkBox.Location = new Point(0, 5);
            checkBox.Text = check_text;
            checkBox.AutoSize = true;
            checkBox.TextAlign = ContentAlignment.MiddleLeft;
            checkBox.Checked = value;
            checkBox.Width = TextRenderer.MeasureText(check_text, form.Font).Width;

            Button buttonOk = new Button();
            buttonOk.Text = "OK";
            buttonOk.AutoSize = true;
            buttonOk.DialogResult = DialogResult.OK;
            buttonOk.Location = new Point(0, checkBox.Location.Y + checkBox.Height + 1);

            Button buttonCancel = new Button();
            buttonCancel.Text = "Cancel";
            buttonCancel.AutoSize = true;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(buttonOk.Size.Width + buttonOk.Location.X + 1, buttonOk.Location.Y);

            form.Text = title;
            form.ClientSize = new Size(buttonCancel.Location.X + buttonCancel.Size.Width + 1, buttonCancel.Location.Y + buttonCancel.Size.Height + 1);
            if (form.ClientSize.Width < TextRenderer.MeasureText(title, form.Font).Width)
                form.ClientSize = new Size(TextRenderer.MeasureText(title, form.Font).Width + 1, buttonCancel.Location.Y + buttonCancel.Size.Height + 1);
            
           
            form.Controls.AddRange(new Control[] { checkBox, buttonOk, buttonCancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            DialogResult dialogResult = form.ShowDialog();
            value = checkBox.Checked;
            return dialogResult;
        }
        public static DialogResult InputBox(string title, string groupBox_text, List<string> radioButtons, ref string value)
        {

            Form form = new Form();

            GroupBox groupBox = new GroupBox();
            groupBox.Location = new Point(0, 5);
            RadioButton radioButton;
            groupBox.Text = groupBox_text;
            groupBox.Width = TextRenderer.MeasureText(groupBox_text, form.Font).Width + 20;
            for (int i = 0; i < radioButtons.Count; i++)
            {
                radioButton = new RadioButton();
                radioButton.Width = TextRenderer.MeasureText(radioButtons[i], form.Font).Width + 20;
                radioButton.Text = radioButtons[i];
                radioButton.Location = new Point(0, i * radioButton.Height + 15);
                groupBox.Controls.Add(radioButton);
                if (radioButton.Width > groupBox.Size.Width)
                {
                    groupBox.Width = radioButton.Width + 15;
                }
                groupBox.Height = radioButton.Location.Y + radioButton.Height + 10;
            }



            Button buttonOk = new Button();
            buttonOk.Text = "OK";
            buttonOk.AutoSize = true;
            buttonOk.DialogResult = DialogResult.OK;
            buttonOk.Location = new Point(groupBox.Size.Width + 5, groupBox.Location.Y + groupBox.Height + 1);

            Button buttonCancel = new Button();
            buttonCancel.Text = "Cancel";
            buttonCancel.AutoSize = true;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(buttonOk.Size.Width + buttonOk.Location.X + 1, buttonOk.Location.Y);

            form.Text = title;
            form.ClientSize = new Size(buttonCancel.Location.X + buttonCancel.Size.Width + 1, buttonCancel.Location.Y + buttonCancel.Size.Height + 1);
            if (form.ClientSize.Width < TextRenderer.MeasureText(title, form.Font).Width)
                form.ClientSize = new Size(TextRenderer.MeasureText(title, form.Font).Width + 1, buttonCancel.Location.Y + buttonCancel.Size.Height + 1);
            form.Controls.AddRange(new Control[] { groupBox, buttonOk, buttonCancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            DialogResult dialogResult = form.ShowDialog();

            for (int i = 0; i < radioButtons.Count; i++)
            {
                if (((RadioButton)groupBox.Controls[i]).Checked == true)
                    value = ((RadioButton)groupBox.Controls[i]).Text;

            }
            return dialogResult;
        }
    }

}
