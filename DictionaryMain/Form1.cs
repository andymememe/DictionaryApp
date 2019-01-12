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

namespace DictionaryMain
{
    public partial class MainForm : Form
    {
        public static readonly string[] Languages = { "中文", "英文" };
        public static readonly string[] LanguageCodes = { "zho", "eng" };

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Languages.ToList().ForEach(s => fromBox.Items.Add(s));
            Languages.ToList().ForEach(s => toBox.Items.Add(s));
            fromBox.SelectedIndex = 0;
            toBox.SelectedIndex = 1;
            inputBox.Text = Clipboard.GetText().Split(' ')[0];
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            string fromCode = LanguageCodes[fromBox.SelectedIndex];
            string toCode = LanguageCodes[toBox.SelectedIndex];
            getResult(fromCode, toCode, inputBox.Text.Trim());
            resultBox.Text = "(載入中...)";
        }

        public async void getResult(string fromCode, string toCode, string input)
        {
            resultBox.Text = await DictionaryAPIConnection.GetResult(fromCode, toCode, input);
        }

        private void wayLabel_Click(object sender, EventArgs e)
        {
            int temp = fromBox.SelectedIndex;
            fromBox.SelectedIndex = toBox.SelectedIndex;
            toBox.SelectedIndex = temp;
        }
    }
}
