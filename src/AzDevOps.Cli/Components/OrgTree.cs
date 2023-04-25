using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui.Trees;
using Terminal.Gui;
using AzDevOps.Cli.Services;
using AzDevOps.Contracts;
using Microsoft.VisualStudio.Services.WebApi;
using System.Collections;

namespace AzDevOps.Cli.Components;
public class OrgTree : TreeView {
    #region Fields

    private readonly IAzDevOpsService _adoService;

    #endregion Fields

    #region Properties

    public IList<Account>? OrgList { get; set; }

    #endregion Properties
    //public OrgTree(IAzDevOpsService adoService) {
    //    _adoService = adoService;
    //}

    public OrgTree(IList<Account> accountList)
    {
        OrgList = accountList;
        this.X = 0;
        this.Y = 0;
        this.Width = 40;
        this.Height = 20;

        var tree = new TreeView() {
            X = 0,
            Y = 0,
            Width = 40,
            Height = 20
        };

        var root1 = new TreeNode("Organizations");

        foreach (var org in OrgList) {
            root1.Children.Add(new TreeNode(org.AccountName));
        }

        var root2 = new TreeNode("Root2");
        root2.Children.Add(new TreeNode("Child2.1"));
        root2.Children.Add(new TreeNode("Child2.2"));

        this.AddObject(root1);
        tree.AddObject(root2);
    }

    //public async static Task<OrgTree> Create(IAzDevOpsService adoService) {
    //    var accountList = await GetOrgsAsync(adoService);
    //    return new OrgTree(adoService, accountList);
    //}

    //public async static Task<IList<Account>?> GetOrgsAsync(IAzDevOpsService adoService) {
    //    return await adoService.GetAccountAsync(null);
    //}
}
