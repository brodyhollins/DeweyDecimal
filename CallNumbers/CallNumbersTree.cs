using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CallNumbers
{
    public class CallNumbersTree
    {
        public Tree<string> PopulateCallNumbersTree(string fileName)
        {
            List<string> data = File.ReadAllLines(fileName).ToList();
            Dictionary<string, string> levelOne = new Dictionary<string, string>();
            Dictionary<string, string> levelTwo = new Dictionary<string, string>();
            Dictionary<string, string> levelThree = new Dictionary<string, string>();

            //Main Tree
            Tree<string> mainTree = new Tree<string>
            {
                Root = new TreeNode<string>() { Data = "Call Numbers" }
            };

            mainTree.Root.Children = new List<TreeNode<string>>();

            if (File.Exists(fileName))
            {
                //Loop through each line in the document, each line acting as one set of the tree
                for (var i = 0; i < data.Count(); i++)
                {
                    //Level 1
                    List<string> oneTemp = data[i].Split('-').ToList();
                    List<string> one = new List<string>();
                    one.Add(oneTemp[0]);
                    //We now have all the data for each row - each tree parent structure
                    mainTree.Root.Children.Add(new TreeNode<string>() { Data = oneTemp[0].Split(' ')[0], Parent = mainTree.Root });

                    mainTree.Root.Children[i].Children = new List<TreeNode<string>>();

                    //Level 2
                    List<string> twoTemp = oneTemp.ElementAt(1).Split('[').ToList();
                    twoTemp.RemoveAt(0);
                    List<string> two = new List<string>();

                    //Level 3
                    List<string> three = new List<string>();

                    for (int test = 0; test < twoTemp.Count(); test++)
                    {
                        List<string> tempLvlSet = twoTemp[test].Split('|').ToList();
                        string lvl2 = tempLvlSet.ElementAt(0);
                        List<string> lvl3 = tempLvlSet.ElementAt(1).Split('.').ToList();

                        mainTree.Root.Children[i].Children.Add(new TreeNode<string>() { Data = lvl2, Parent = mainTree.Root.Children[i] });

                        mainTree.Root.Children[i].Children[test].Children = new List<TreeNode<string>>();
                        for (int q = 0; q < lvl3.Count(); q++)
                        {
                            mainTree.Root.Children[i].Children[test].Children.Add(new TreeNode<string>() { Data = lvl3[q], Parent = mainTree.Root.Children[i].Children[test] });
                        }
                    }
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("{0} not found - using current" + "directory: ", fileName);
            }

            return mainTree;
        }
    }

    

   
}
