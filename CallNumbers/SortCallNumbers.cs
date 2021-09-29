using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallNumbers
{
    public class SortCallNumbers
    {
        public List<string> InsertionSort(List<string> data, int n)
        {
            int i, j;
            for (i = 1; i < n; i++)
            {
                string item = data[i];
                int ins = 0;
                for (j = i - 1; j >= 0 && ins != 1;)
                {
                    //Get the 3 digit number for both items
                    string threeItem = item.Split('.')[0];
                    string threeData = data[j].Split('.')[0];

                    //Get the decimal number after the . and put 0 to the right until 5 digits
                    string fiveItem = item.Split(' ')[0].Split('.')[1].PadRight(5, '0');
                    string fiveData = data[j].Split(' ')[0].Split('.')[1].PadRight(5, '0');

                    //Get the 3 letter string for author surname
                    string surnameItem = item.Split(' ')[1];
                    string surnameData = data[j].Split(' ')[1];

                    //Concat the 3 digit to the 5 digit as compare as a decimal value
                    if ((Convert.ToDouble((string.Concat(threeItem, ',', fiveItem))) < (Convert.ToDouble((string.Concat(threeData, ',', fiveData))))))
                    {
                        data[j + 1] = data[j];
                        j--;
                        data[j + 1] = item;
                    }
                    //If the decimal value is equal we can compare the letters to be sorted, as this is only needed then
                    else if ((Convert.ToDouble((string.Concat(threeItem, ',', fiveItem))) == (Convert.ToDouble((string.Concat(threeData, ',', fiveData))))))
                    {
                        if (string.Compare(surnameItem, surnameData) < 0)
                        {
                            data[j + 1] = data[j];
                            j--;
                            data[j + 1] = item;
                        }
                        else {
                            ins = 1;
                        }
                    }
                    else ins = 1;
                }
            }

            return data;
        }
    }
}
