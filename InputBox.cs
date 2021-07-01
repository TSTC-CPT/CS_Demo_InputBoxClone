using System;
using System.Windows.Forms;

namespace CS_Demo_InputBoxClone
{
    internal class InputBox
    {
        public static DialogResult Show(string Prompt, string Title, string DefaultResponse, ref string value,
                                        InputBoxValidation validation)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = Title;
            label.Text = Prompt;
            textBox.Text = DefaultResponse;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;

            form.Width = 396;
            form.Height = 150;
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.Width = Math.Max(300, label.Right + 10);

            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;

            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;

            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            buttonOk.Left = textBox.Left;
            buttonCancel.Left = (buttonOk.Left + buttonOk.Width) + 20;

            textBox.Width = form.Width - 60;
            if (validation != null)
            {
                form.FormClosing += delegate (object sender, FormClosingEventArgs e)
                {
                    if (form.DialogResult == DialogResult.OK)
                    {
                        string errorText = validation(textBox.Text);
                        if (e.Cancel = (errorText != ""))
                        {
                            MessageBox.Show(form, errorText, "Validation Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox.Focus();
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                };
            }
            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
    }

    public delegate string InputBoxValidation(string errorMessage);
}
