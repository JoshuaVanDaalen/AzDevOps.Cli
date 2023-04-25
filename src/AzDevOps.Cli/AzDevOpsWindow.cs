using AzDevOps.Contracts;
using Terminal.Gui;

namespace AzDevOps.Cli;
public partial class AzDevOpsWindow
{

    public AzDevOpsWindow(IList<Organisation> orgList)
    {
        InitializeComponent(orgList);
        
        button1.Clicked += () => MessageBox.Query("Hello", "Hello There!", "Ok");
    }
}
