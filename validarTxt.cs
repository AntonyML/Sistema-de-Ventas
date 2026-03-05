using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace sistema_de_ventas
{
    internal class validarTxt
    {
        public static bool soloNumeros(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
                return true;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return true;
            }
            else
            {
                e.Handled = true;
                return false;
            }
        }
        public static bool validarEmail(string pCorreo)
        {
            return pCorreo!=null && Regex.IsMatch(pCorreo,
               @"^[^@\s]+@[^@\s]+\.[^@\s]+$"); 
        }
        public static void soloLetras(KeyPressEventArgs v
            )
        {

            if (char.IsLetter(v.KeyChar))
            {
                v.Handled = false;
               
            }
            else if (char.IsSeparator(v.KeyChar))
            {
                v.Handled = false;
               
            }
            else if (char.IsControl(v.KeyChar))
            {
                v.Handled = false;

            }
            else
            {
                v.Handled = true;
                
            }
        }
        }
}
