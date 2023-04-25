using Terminal.Gui;
using Terminal.Gui.Trees;

namespace AzDevOps.Cli
{

    public class NavBar : TreeNode
    {
        public NavBar()
        {
            var tree = new TreeView()
            {
                X = 0,
                Y = 0,
                Width = 40,
                Height = 20
            };
            var root1 = new TreeNode("Root1");
            root1.Children.Add(new TreeNode("Child1.1"));
            root1.Children.Add(new TreeNode("Child1.2"));

            var root2 = new TreeNode("Root2");
            root2.Children.Add(new TreeNode("Child2.1"));
            root2.Children.Add(new TreeNode("Child2.2"));

            tree.AddObject(root1);
            tree.AddObject(root2);
        }
    }
}
