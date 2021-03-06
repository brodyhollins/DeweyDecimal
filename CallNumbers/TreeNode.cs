using System;
using System.Collections.Generic;
using System.Text;

namespace CallNumbers
{
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public TreeNode<T> Parent { get; set; }
        public List<TreeNode<T>> Children { get; set; }

        public int GetDistance()
        {
            int distance = 1;
            TreeNode<T> current = this;
            while (current.Parent != null)
            {
                distance++;
                current = current.Parent;
            }
            return distance;
        }
    }
}
