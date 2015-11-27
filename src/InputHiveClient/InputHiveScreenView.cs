using System.Windows.Forms;

namespace InputHiveClient
{
    using System.Drawing;

    public partial class InputHiveScreenView : Form
    {
        public InputHiveScreenView()
        {
            this.InitializeComponent();
            this.HideForm();
        }


        public void UpdateScreenShot(Image image)
        {
            if (!this.Visible) return;
            this.pbxScreenShot.Invoke((MethodInvoker)(() =>
            {
                this.pbxScreenShot.Image = image;
            }));
        }

        public void OpenForm()
        {
            this.Visible = true;
            this.ShowInTaskbar = true;
        }

        public void HideForm()
        {
            this.Visible = false;
            this.ShowInTaskbar = false;

        }
        private void InputHiveScreenView_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
