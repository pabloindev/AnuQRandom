using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnuQRandom;

namespace FormTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AQRandJSON j = new AQRandJSON();
            byte[] b = j.getBinary(DataType.hex16, 1010);
            b = j.getBinary(DataType.uint8, 1010);
            string s = j.getString(1010);
            textBox1.Text = s;

            //AQRand r = new AQRand();
            //byte[] arr = r.getBinary(2049);
            //textBox1.Text = Convert.ToBase64String(arr);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AQRand r = new AQRand();
            string s = r.getString(2000);

            //still waiting for the page RawHex.php
            //r.getBinary(100);

            textBox1.Text = s;
        }
    }
}
