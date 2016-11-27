using System;
using System.Windows.Forms;

namespace MifuminLib
{
    public partial class NumberInputBox : Form
    {
        private NumberInputBox()
        {
            InitializeComponent();
        }

        static public decimal Show(IWin32Window owner, string message, decimal minimum, decimal maximum, decimal value)
        {
            NumberInputBox form = new NumberInputBox();
            form.Text = message;
            form.numericUpDown1.Minimum = minimum;
            form.numericUpDown1.Maximum = maximum;
            form.numericUpDown1.Value = value;
            if (form.ShowDialog(owner) == DialogResult.OK)
            {
                return form.numericUpDown1.Value;
            }
            else
            {
                return value;
            }
        }

        private void NumberInputBox_Load(object sender, EventArgs e)
        {
            numericUpDown1.Select(0, numericUpDown1.ToString().Length);
        }
    }
}