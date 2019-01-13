using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DictionaryAPI;
using DictionaryAPI.ApiClient;

namespace DictionaryMain
{
    public partial class MainForm : Form
    {
        public static readonly Dictionary<string, string> Languages = new Dictionary<string, string>
        {
            { "中文", "zho" },
            { "英文", "eng" }
        };

        private bool _isConn;
        private HttpApiClient _client;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            _isConn = false;
            _client = new HttpApiClient();
            Languages.Keys.ToList().ForEach(s => fromBox.Items.Add(s));
            Languages.Keys.ToList().ForEach(s => toBox.Items.Add(s));
            fromBox.SelectedIndex = 0;
            toBox.SelectedIndex = 1;
            inputBox.Text = Clipboard.GetText().Split(' ')[0];
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            string fromCode = Languages[fromBox.GetItemText(fromBox.SelectedItem)];
            string toCode = Languages[toBox.GetItemText(toBox.SelectedItem)];
            _isConn = true;
            inputBox.Enabled = false;
            fromBox.Enabled = false;
            toBox.Enabled = false;
            submitBtn.Enabled = false;

            getResult(fromCode, toCode, inputBox.Text.Trim());
            resultBox.Text = "(載入中...)";
        }

        private void wayLabel_Click(object sender, EventArgs e)
        {
            if(_isConn)
            {
                return;
            }
            int temp = fromBox.SelectedIndex;
            fromBox.SelectedIndex = toBox.SelectedIndex;
            toBox.SelectedIndex = temp;
        }

        private async void getResult(string fromCode, string toCode, string input)
        {
            resultBox.Text = await DictionaryAPIConnection.GetResult(_client, fromCode, toCode, input);
            _isConn = false;
            inputBox.Enabled = true;
            fromBox.Enabled = true;
            toBox.Enabled = true;
            submitBtn.Enabled = true;
        }
    }
}
