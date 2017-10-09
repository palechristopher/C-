using System;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

            //Get Firefox Browser History
            FirefoxBrowserHistory firefox = new FirefoxBrowserHistory();
            dataGridView1.DataSource = firefox.GetDataTable();

            //Get Chrome Browser History
            ChromeBrowserHistory chrome = new ChromeBrowserHistory();
            dataGridView2.DataSource    = chrome.GetDataTable();

            //get Opera Browser History
            OperaBrowserHistory opera = new OperaBrowserHistory();
            dataGridView3.DataSource = opera.GetDataTable();
        }

    }
}
