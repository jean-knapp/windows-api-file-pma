using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMAFileAPI
{
    public class PMANode
    {
        public int level = 0;
        public string type = "";
        public string name = "";
        public List<PMANode> items = new List<PMANode>();
        public Dictionary<string, string> properties = new Dictionary<string, string>();

        public PMANode getNodeByType(string type)
        {
            foreach(PMANode node in items)
            {
                if (node.type == type)
                {
                    return node;
                }
            }
            return null;
        }

        public PMANode getNodeByName(string name)
        {
            foreach (PMANode node in items)
            {
                if (node.name == name)
                {
                    return node;
                }
            }
            return null;
        }

        public PMANode findNodeByName(string name)
        {
            foreach (PMANode node in items)
            {
                if (node.name == name)
                {
                    return node;
                }
                PMANode childSearch = node.findNodeByName(name);
                if (childSearch != null)
                {
                    return childSearch;
                }
            }
            return null;
        }

        public List<PMANode> getNodesByType(string type)
        {
            List<PMANode> result = new List<PMANode>();
            foreach (PMANode node in items)
            {
                if (node.type == type)
                {
                    result.Add(node);
                }
            }
            return result;
        }

        public List<PMANode> findNodesByType(string type)
        {
            List<PMANode> result = new List<PMANode>();
            foreach (PMANode node in items)
            {
                if (node.type == type)
                {
                    result.Add(node);
                }
                result.AddRange(node.findNodesByType(type));
            }
            return result;
        }

        public List<PMANode> getNodesByName(string name)
        {
            List<PMANode> result = new List<PMANode>();
            foreach (PMANode node in items)
            {
                if (node.name == name)
                {
                    result.Add(node);
                }
            }
            return result;
        }

        public List<PMANode> findNodesByName(string name)
        {
            List<PMANode> result = new List<PMANode>();
            foreach (PMANode node in items)
            {
                if (node.name == name)
                {
                    result.Add(node);
                }
                result.AddRange(node.findNodesByName(name));
            }
            return result;
        }
    }
}
