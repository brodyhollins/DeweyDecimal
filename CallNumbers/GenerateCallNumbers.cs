using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallNumbers
{
    public class GenerateCallNumbers
    {
        public Random random = new Random();
        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Generate random dewey decimal numbers
        /// </summary>
        public List<string> RandomCallNumbersGenerator()
        {
            List<string> deweyDecimals = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                string deweyDecimal = "";

                //3 Digit Main Subject Classes
                deweyDecimal = string.Concat(deweyDecimal, random.Next(0, 900).ToString("000"), ".");

                string afterDecimal =
                      random.Next(0, 9).ToString()
                    + random.Next(0, 9).ToString()
                    + random.Next(0, 9).ToString()
                    + random.Next(0, 9).ToString()
                    + random.Next(0, 9).ToString();

                //After decimal point
                deweyDecimal = string.Concat(deweyDecimal, random.Next(0, Int32.Parse(afterDecimal)).ToString());

                //Author 3 letter of surname
                deweyDecimal = string.Concat(deweyDecimal, " ", RandomString(3));

                deweyDecimals.Add(deweyDecimal);
            }

            return deweyDecimals;
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Method for random string generation
        /// </summary>
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(x => x[random.Next(x.Length)]).ToArray());
        }
    }
}
