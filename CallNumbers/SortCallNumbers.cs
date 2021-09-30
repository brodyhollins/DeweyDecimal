using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallNumbers
{
    public class SortCallNumbers
    {
        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///    Insertion Sort Algorithm used to sort List
        ///    Reason: Speed won't be a concern because of the list size and it is a stable algorithm
        /// </summary>
        public List<string> InsertionSort(List<string> callNumbers, int length)
        {
            int upperIndex, lowerIndex;
            for (upperIndex = 1; upperIndex < length; upperIndex++)
            {
                string item = callNumbers[upperIndex];
                int ins = 0;
                for (lowerIndex = upperIndex - 1; lowerIndex >= 0 && ins != 1;)
                {
                    //Get the 3 digit number for both items
                    string threeItem = item.Contains(".") ? item.Split('.')[0] : item.Split(' ')[0];
                    string threeData = callNumbers[lowerIndex].Contains(".") ? callNumbers[lowerIndex].Split('.')[0] : callNumbers[lowerIndex].Split(' ')[0];

                    //Get the decimal number after the . and put 0 to the right until 5 digits
                    string fiveItem = item.Split(' ')[0].Contains(".") ? item.Split(' ')[0].Split('.')[1].PadRight(5, '0') : "0".PadRight(5, '0');
                    string fiveData = callNumbers[lowerIndex].Split(' ')[0].Contains(".") ? callNumbers[lowerIndex].Split(' ')[0].Split('.')[1].PadRight(5, '0')  : "0".PadRight(5, '0');

                    //Get the 3 letter string for author surname
                    string surnameItem = item.Split(' ')[1];
                    string surnameData = callNumbers[lowerIndex].Split(' ')[1];

                    //Concat the 3 digit to the 5 digit as compare as a decimal value
                    if ((Convert.ToDouble((string.Concat(threeItem, ',', fiveItem))) < (Convert.ToDouble((string.Concat(threeData, ',', fiveData))))))
                    {
                        callNumbers[lowerIndex + 1] = callNumbers[lowerIndex];
                        lowerIndex--;
                        callNumbers[lowerIndex + 1] = item;
                    }
                    //If the decimal value is equal we can compare the letters to be sorted, as this is only needed then
                    else if ((Convert.ToDouble((string.Concat(threeItem, ',', fiveItem))) == (Convert.ToDouble((string.Concat(threeData, ',', fiveData))))))
                    {
                        if (string.Compare(surnameItem, surnameData) < 0)
                        {
                            callNumbers[lowerIndex + 1] = callNumbers[lowerIndex];
                            lowerIndex--;
                            callNumbers[lowerIndex + 1] = item;
                        }
                        else
                        {
                            ins = 1;
                        }
                    }
                    else ins = 1;
                }
            }
            return callNumbers;
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------------------//