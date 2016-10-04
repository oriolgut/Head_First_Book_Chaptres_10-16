using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretIngredients
{
    class Amy
    {
        public GetSecretIngredient MySecretIngredientMethod
        {
            get
            {
                return new GetSecretIngredient(AmysSecretIngredient);
            }
        }

        private string AmysSecretIngredient(int amount)
        {
            if(amount < 10)
            {
                return $"{amount} cans of sardines -- you need more!";
            }
            else
            {
                return $"{amount} cans of sardines";
            }
            
        }
    }
}
