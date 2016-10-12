using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiInvoker
{
    public partial class LoginForm : Form
    {
        private const string AccessToken = "access_token";

        public LoginForm()
        {
            InitializeComponent();
        }

        private TaskCompletionSource<string> _tcs;

        public Task<string> GetToken(string url)
        {
            _tcs = new TaskCompletionSource<string>();
            webBrowser1.Navigate(url);
            return _tcs.Task;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var url = webBrowser1.Url.AbsoluteUri;
            if (url.Contains(AccessToken))
            {
                // todo extract token
                var startIndex =
                    url.IndexOf(AccessToken, StringComparison.OrdinalIgnoreCase) + AccessToken.Length + 1;
                var endIndex = url.IndexOf("&", startIndex, StringComparison.OrdinalIgnoreCase);
                var token = url.Substring(startIndex, endIndex - startIndex);
                _tcs.TrySetResult(token);
                // close the login form
                this.Hide();
            }
        }
    }
}
