using System;
using System.Collections.Generic;
using System.Linq;

namespace CallNumbers
{
    public class GenerateCallNumbers
    {
        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///    Used to obtain digits and letters for the call numbers
        /// </summary>
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
                // 3 digit number before the '.' - category
                string deweyDecimal = "";
                deweyDecimal = random.Next(0, 1000).ToString("000");

                // digits after the '.' - sub categories
                string afterDecimal = "";

                // Handle how many digits between 0 and 5 to randomize after the .
                for (int x = 0; x < random.Next(0, 6); x++)
                {
                    // Randomize each digit between 0 and 9
                    afterDecimal = string.Concat(afterDecimal, random.Next(0, 10).ToString());
                }

                // Concate a dot between category and sub category if there is a sub category
                if(afterDecimal == "")
                {
                    deweyDecimal = string.Concat(deweyDecimal, afterDecimal);
                }
                else
                {
                    deweyDecimal = string.Concat(deweyDecimal, ".", afterDecimal);
                }
                

                // Handle authors 3 letter surname and concat to the digits
                deweyDecimal = string.Concat(deweyDecimal, " ", RandomStringGenerator(3));

                deweyDecimals.Add(deweyDecimal);
            }

            return deweyDecimals;
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Method for random string generation for 3 letter author surname
        /// </summary>
        public string RandomStringGenerator(int length)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(letters, length)
              .Select(letter => letter[random.Next(letter.Length)]).ToArray());
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------------------//