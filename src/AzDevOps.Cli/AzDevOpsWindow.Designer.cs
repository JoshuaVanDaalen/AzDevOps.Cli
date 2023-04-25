using AzDevOps.Cli.Components;
using AzDevOps.Cli.Services;
using AzDevOps.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Terminal.Gui;
using Terminal.Gui.Trees;

namespace AzDevOps.Cli;
public partial class AzDevOpsWindow : Terminal.Gui.Window {

    private Terminal.Gui.Label label1;

    private Terminal.Gui.Button button1;

    private void InitializeComponent(IList<Organisation> orgList) {
        this.Title = "AzDevOps Cli";
        this.button1 = new Terminal.Gui.Button();
        this.label1 = new Terminal.Gui.Label();
        this.Width = Dim.Fill(0);
        this.Height = Dim.Fill(0);
        this.X = 0;
        this.Y = 0;
        this.Modal = false;
        this.Text = "";
        this.Border.BorderStyle = Terminal.Gui.BorderStyle.Single;
        this.Border.Effect3D = false;
        this.Border.DrawMarginFrame = true;
        this.TextAlignment = Terminal.Gui.TextAlignment.Left;
        this.label1.Width = 4;
        this.label1.Height = 1;
        this.label1.X = Pos.Center();
        this.label1.Y = Pos.Center();
        this.label1.Data = "label1";
        this.label1.Text = "Hello World";
        this.label1.TextAlignment = Terminal.Gui.TextAlignment.Left;
        this.Add(this.label1);
        this.button1.Width = 12;
        this.button1.X = Pos.Center();
        this.button1.Y = Pos.Center() + 1;
        this.button1.Data = "button1";
        this.button1.Text = "Click Me";
        this.button1.TextAlignment = Terminal.Gui.TextAlignment.Centered;
        this.button1.IsDefault = false;
        this.Add(this.button1);
        // var navBar = new NavBar();
        //var tree = new TreeView()
        //{
        //    X = 0,
        //    Y = 0,
        //    Width = 40,
        //    Height = 20
        //};
        //var root1 = new TreeNode("Root1");
        //root1.Children.Add(new TreeNode("Child1.1"));
        //root1.Children.Add(new TreeNode("Child1.2"));

        //var root2 = new TreeNode("Root2");
        //root2.Children.Add(new TreeNode("Child2.1"));
        //root2.Children.Add(new TreeNode("Child2.2"));

        //tree.AddObject(root1);
        //tree.AddObject(root2);
        //var adoService = services.GetRequiredService<IAzDevOpsService>();
        //var orgTree = OrgTree.Create(adoService).Result;
        this.Add(new OrgTree(orgList));
    }
}
