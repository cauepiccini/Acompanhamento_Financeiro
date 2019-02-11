using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssApp
{
    class Validar
    {
        public static bool RG(string rg)
        {
            try
            {
                // Pegar os 8 primeiros dígitos e multiplicar o primeiro por 2, e cada número subir + 1 até chegar em 9
                rg = rg.Replace(".", "").Replace("-", "").Replace(",", "").Replace(" ", "").Trim();
 
                int n1 = int.Parse(rg.Substring(0, 1));
                int n2 = int.Parse(rg.Substring(1, 1));
                int n3 = int.Parse(rg.Substring(2, 1));
                int n4 = int.Parse(rg.Substring(3, 1));
                int n5 = int.Parse(rg.Substring(4, 1));
                int n6 = int.Parse(rg.Substring(5, 1));
                int n7 = int.Parse(rg.Substring(6, 1));
                int n8 = int.Parse(rg.Substring(7, 1));
 
                string DV = rg.Substring(8, 1);
 
                int Soma = n1 * 2 + n2 * 3 + n3 * 4 + n4 * 5 + n5 * 6 + n6 * 7 + n7 * 8 + n8 * 9;
 
                string digitoVerificador = Convert.ToString(Soma % 11);
 
                // Se o dígito verificador for igual a 1, automaticamente ele se tornará o algarismo romano X,
                // pois será feito o cálculo de 11 - o dígito verificador. No caso, ficaria 11 - 1, que é igual a 10.
 
                if (digitoVerificador == "1")
                {
                    digitoVerificador = "X";
                }
 
                // Se o dígito verificador for igual a 0, automaticamente ele se torna 0, pois 11 - 0 é igual a 11, e
                // não será permitido isso no dígito verificador, então automaticamente o dígito será 0.
                else if (digitoVerificador == "0")
                {
                    digitoVerificador = "0";
                }
 
                // Se não for nem 0 nem 1, vai ser feito 11 - o dígito verificador. Por exemplo, se o a soma dividida por 11
                // deu resto 5, será feito 11 - 5, que é igual a 6. Então automaticamente o dígito verificador do RG se tornará o número 6!
 
                else
                {
                    digitoVerificador = (11 - int.Parse(digitoVerificador)).ToString();
                }
 
                // Verificar se o dígito verificador é igual ao DV do RG que está sendo validado.
 
                if (digitoVerificador == DV)
                {
                    return true;
                }
                else
                {
                    return false;
                }
 
            }
            catch
            {
                return false;
            }
        }
    }
}
