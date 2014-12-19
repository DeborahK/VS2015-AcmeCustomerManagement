using System;
using System.Windows.Forms;

namespace ACM.Win
{
    /// <summary>
    /// Displays a dialog for entering the customer to find.
    /// </summary>
    public partial class CustomerFindWin : Form
    {
        public string NameToFind { get; set; }

        public CustomerFindWin()
        {
            InitializeComponent();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            NameToFind = NameToFindTextBox.Text;
            DialogResult = DialogResult.OK;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
