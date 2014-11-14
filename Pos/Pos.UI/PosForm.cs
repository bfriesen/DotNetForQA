using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pos.UI
{
    public partial class PosForm : Form
    {
        public PosForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var price = decimal.Parse(txtPrice.Text);
            var quantity = int.Parse(txtQuantity.Text);

            var lineItem = new LineItem(txtProduct.Text, price, quantity);

            lstLineItems.Items.Add(lineItem);

            UpdateTotal();
        }

        private void cboStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            decimal subTotal = 0;

            foreach (LineItem lineItem in lstLineItems.Items)
            {
                subTotal += lineItem.Amount;
            }

            lblSubtotal.Text = subTotal.ToString("c");
        }

        private void btnCompleteOrder_Click(object sender, EventArgs e)
        {

        }

        private class LineItem
        {
            private readonly string _product;
            private readonly decimal _price;
            private readonly int _quantity;

            public LineItem(string product, decimal price, int quantity)
            {
                _product = product;
                _price = price;
                _quantity = quantity;
            }

            public override string ToString()
            {
                return string.Format("{0} - {1} @ {2:c}", _product, _quantity, _price);
            }

            public decimal Amount
            {
                get { return _price * _quantity; }
            }
        }
    }
}
