using System;
using System.Collections.Generic;
using Business;
using Models;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Product> products = new List<Product>();
            var business = new ProductBusiness();
            products = business.GetAllProducts();
            foreach ( var product in products ) 
            {
                lstData.Items.Add( product );
            }
        }
    }
}
