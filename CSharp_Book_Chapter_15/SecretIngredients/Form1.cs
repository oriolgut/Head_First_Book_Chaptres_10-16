using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecretIngredients
{
    public partial class FormSecretIngredient : Form
    {
        public FormSecretIngredient()
        {
            InitializeComponent();
        }
        GetSecretIngredient ingredientMethod = null;
        Suzanne suzanne = new Suzanne();
        Amy amy = new Amy();

        private void OnButtonGetIngredient_Click(object sender, EventArgs e)
        {
            if(ingredientMethod != null)
            {
                MessageBox.Show($"I'll add {ingredientMethod((int)numericUpDownAmount.Value)}");
            }
        }

        private void OnButtonGetSuzanneDelegate_Click(object sender, EventArgs e)
        {
            ingredientMethod = new GetSecretIngredient(suzanne.MySecretIngredientMethod);
        }

        private void OnButtonGetAmyDelegate_Click(object sender, EventArgs e)
        {
            ingredientMethod = new GetSecretIngredient(amy.MySecretIngredientMethod);
        }
    }
}