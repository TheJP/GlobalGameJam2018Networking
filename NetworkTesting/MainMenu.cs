using System;
using System.Windows.Forms;

namespace NetworkTesting
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void startServer_Click(object sender, EventArgs e)
        {
            new Server(serverUsername.Text).Show();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            new Client(clientUsername.Text, address.Text).Show();
        }
    }
}
