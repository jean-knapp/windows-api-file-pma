using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PMAFileAPI
{
    public class PMAFile
    {
        public static PMANode read(String path)
        {

            Stack<PMANode> stack = new Stack<PMANode>();
            PMANode root = new PMANode();

            stack.Push(root);

            foreach (String row in File.ReadLines(path, Encoding.GetEncoding("iso-8859-1")))
            {
                string line = row;
                int equalIndex = line.IndexOf(" = ");
                int hyphenIndex = line.IndexOf(" - ");
                bool isNode = (hyphenIndex < equalIndex && hyphenIndex > 0) || (equalIndex == -1);

                // - = node
                // - node
                // node
                // = property
                // = - property


                int level = 1;
                while (line.StartsWith("\t"))
                {
                    line = line.Substring(1);
                    level++;
                }

                //MessageBox.Show(level + ": " + line);

                while ((isNode && level <= stack.Peek().level) ||
                    (!isNode && level < stack.Peek().level + 1))
                {
                    // Sibling of stack top.
                    //if (isNode)
                    //{
                    PMANode top = stack.Pop();
                    if (stack.Count > 0)
                    {
                        stack.Peek().items.Add(top);
                    }
                    //}
                }

                if (isNode)
                {
                    // It's a node
                    PMANode node = new PMANode();
                    node.level = level;
                    if (line.Contains(" - "))
                    {
                        node.type = line.Substring(0, line.IndexOf(" - ")).Trim();
                        node.name = line.Replace(node.type + " - ", "").Trim();
                    }
                    else
                    {
                        node.type = line.Trim();
                    }

                    stack.Push(node);
                }
                else
                {
                    // It's a property
                    string key = line.Substring(0, line.IndexOf(" = ")).Trim();
                    string value = line.Replace(key + " = ", "").Trim();
                    stack.Peek().properties.Add(key, value);
                }
            }

            while (stack.Count > 1)
            {
                PMANode top = stack.Pop();
                stack.Peek().items.Add(top);
            }

            //MessageBox.Show(root.items.Count + "");

            return root;
        }

        public static void write(PMANode root, string path)
        {
            List<string> lines = writeInOrder(root);
            lines.RemoveAt(0);
            File.WriteAllLines(path, lines, Encoding.GetEncoding("iso-8859-1"));
        }

        private static List<string> writeInOrder(PMANode node)
        {
            List<string> lines = new List<string>();
            string tabs = getLevelTab(node.level);

            lines.Add(tabs + node.type + (node.name != "" ? " - " + node.name : ""));

            foreach (PMANode child in node.items)
            {
                lines.AddRange(writeInOrder(child));
            }

            foreach (string key in node.properties.Keys)
            {
                lines.Add(tabs + "\t" + key + " = " + node.properties[key]);
            }

            return lines;
        }

        private static string getLevelTab(int level)
        {
            string tabs = "";
            for (int i = 0; i < level - 1; i++)
            {
                tabs = tabs + "\t";
            }

            return tabs;
        }
    }
}
