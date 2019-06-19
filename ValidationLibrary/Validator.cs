using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Murach.Validator
{
    /// <summary>
    /// Porvides static methods for validating data.
    /// </summary>
    public static class Validator
	{
		private static string title = "Entry Error";
        /// <summary>
        /// The title that appear in the dialogue box
        /// </summary>
        public static string Title
		{
			get
			{
				return title;
			}
			set
			{
				title = value;
			}
		}
        /// <summary>
        /// Checks whether the user enters data in the textbox
        /// </summary>
        /// <param name="textBox">The textbox to be validated</param>
        /// <returns>true if the user entered a value</returns>
		public static bool IsPresent(TextBox textBox)
		{
			if (textBox.Text == "")
			{
				MessageBox.Show(textBox.Tag + " is a required field.", Title);
				textBox.Focus();
				return false;
			}
			return true;
		}
        /// <summary>
        /// Checks whether the entered value to the textbox is decimal or not
        /// </summary>
        /// <param name="textBox">The textbox to be validated</param>
        /// <returns>True if the user entered deciaml</returns>
        public static bool IsDecimal(TextBox textBox)
        {
            decimal number = 0m;
            if (Decimal.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + " must be a decimal value.", Title);
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// Checks whether the entered value is Integer
        /// </summary>
        /// <param name="textBox">The textbox to be validated</param>
        /// <returns>True if the value entered is integer</returns>
        public static bool IsInt32(TextBox textBox)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + " must be an integer.", Title);
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// Checks whether the entered value is within the range
        /// </summary>
        /// <param name="textBox">The textbox to be validate</param>
        /// <param name="min">The minimum value the user has to enter</param>
        /// <param name="max">The maximum value the user has to enter</param>
        /// <returns>True if the value entered is within the range</returns>
		public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
		{
			decimal number = Convert.ToDecimal(textBox.Text);
			if (number < min || number > max)
			{
				MessageBox.Show(textBox.Tag + " must be between " + min
					+ " and " + max + ".", Title);
				textBox.Focus();
				return false;
			}
			return true;
		}

        /// <summary>
        /// Checks if the user entered value has an email format
        /// </summary>
        /// <param name="textBox">The textbox to be validated</param>
        /// <returns></returns>
        public static bool IsValidEmail(TextBox textBox)
        {
            if (textBox.Text.IndexOf("@") == -1 ||
                 textBox.Text.IndexOf(".") == -1)
            {
                MessageBox.Show(textBox.Tag + " must be a valid email address.",
                    Title);
                textBox.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
