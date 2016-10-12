using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

namespace ApiInvoker
{
    public partial class MainForm : Form
    {
        private readonly Facebook _fb = new Facebook();

        public MainForm()
        {
            InitializeComponent();
            var token = Properties.Settings.Default.Token;
            var scope = Properties.Settings.Default.TokenPermits;
            // check if token in settings and if scope matches
            if (!string.IsNullOrEmpty(token) && scope.Equals(Facebook.Scope, StringComparison.OrdinalIgnoreCase))
            {
                _fb.Token = token;
            }
        }

        private async void locationButton_Click(object sender, EventArgs e)
        {
            var loc = await IpLocation.Get();
            richTextBox1.Text = $"{loc.ZipCode} {loc.City}, {loc.Country}";
        }

        private async void facebookButton_Click(object sender, EventArgs e)
        {
            if (_fb.Token == null)
            {
                var login = new LoginForm();
                login.Show(this);
                var uri = _fb.LoginUrl().AbsoluteUri;
                var token = await login.GetToken(uri);
                _fb.Token = token;
                Properties.Settings.Default.Token = token;
                Properties.Settings.Default.TokenPermits = Facebook.Scope;
                Properties.Settings.Default.Save();
            }
            var response = await _fb.GetMe();
            richTextBox1.Text = response.ToString();
        }
    }
}
