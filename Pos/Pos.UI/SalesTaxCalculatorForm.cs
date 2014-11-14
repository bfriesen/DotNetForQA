using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos.UI
{
    public partial class SalesTaxCalculatorForm : Form
    {
        public SalesTaxCalculatorForm()
        {
            InitializeComponent();
        }

        private void btnCalculateTax_Click(object sender, EventArgs e)
        {
            decimal amount = decimal.Parse(txtAmount.Text);
            State state = (State)Enum.Parse(typeof(State), txtState.Text);

            SalesTaxCalculator calculator = new SalesTaxCalculator(new LocalFileSalesTaxRepository("state_tax_rates.xml"));
            decimal salesTaxAmount = calculator.Calculate(amount, state);

            lblTaxAmount.Text = salesTaxAmount.ToString("c");
        }
    }
}
