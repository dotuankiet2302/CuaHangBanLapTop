using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BanLaptop
{
    public class DecisionTreeNode
    {
        public string SplitAttribute { get; set; }
        public string Prediction { get; set; }
        public Dictionary<string, DecisionTreeNode> Children { get; set; }

        public DecisionTreeNode()
        {
            Children = new Dictionary<string, DecisionTreeNode>();
        }
    }
}
