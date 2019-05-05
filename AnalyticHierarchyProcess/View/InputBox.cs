using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace NamespaceInputBox
{
    class InputBoxs
    {
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
    }
}
