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
                    string threeItem = item.Split('.')[0];
                    string fiveItem = item.Split(' ')[0].Split('.')[1].PadRight(5, '0');
                    string surnameItem = item.Split(' ')[1];

                    string threeData = data[j].Split('.')[0];
                    string fiveData = data[j].Split(' ')[0].Split('.')[1].PadRight(5, '0');
                    string surnameData = data[j].Split(' ')[1];

                    //When 3 digit is less than then we swap no matter what
                    if ((Convert.ToDouble((string.Concat(threeItem, ',', fiveItem))) < (Convert.ToDouble((string.Concat(threeData, ',', fiveData))))))
                    {
                        data[j + 1] = data[j];
                        j--;
                        data[j + 1] = item;
                    }
                    //When 3 digit is equal to each other, then we compare the 5 digit number after the .
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
