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

    public IList<Organisation>? OrgList { get; set; }

    #endregion Properties
    //public OrgTree(IAzDevOpsService adoService) {
    //    _adoService = adoService;
    //}

    public OrgTree(IList<Organisation> orgList) {
        OrgList = orgList;
        this.X = 0;
        this.Y = 0;
        this.Width = 40;
        this.Height = 20;

        var treeNode = new TreeNode("Organizations");

        foreach (var org in OrgList) {
            var orgNode = new TreeNode(org.Properties.AccountName);

            var projectNode = new TreeNode("Projects");
            orgNode.Children.Add(projectNode);
            foreach (var obj in org.Projects) {
                projectNode.Children.Add(new TreeNode(obj.Name));
            }

            var usersNode = new TreeNode("Users");
            var allUsersNode = new TreeNode("All users");

            foreach (var obj in org.Users) {
                allUsersNode.Children.Add(new TreeNode(obj.DisplayName));
            }

            var groupRulesNode = new TreeNode("Groups rules");
            orgNode.Children.Add(usersNode);
            usersNode.Children.Add(allUsersNode);
            usersNode.Children.Add(groupRulesNode);

            var permissionsNode = new TreeNode("Permissions");
            var groupsNode = new TreeNode("Groups");
            var usersNode2 = new TreeNode("Users");
            orgNode.Children.Add(permissionsNode);
            orgNode.Children.Add(groupsNode);
            permissionsNode.Children.Add(usersNode2);

            treeNode.Children.Add(orgNode);
        }

        this.AddObject(treeNode);
    }

    //public async static Task<OrgTree> Create(IAzDevOpsService adoService) {
    //    var accountList = await GetOrgsAsync(adoService);
    //    return new OrgTree(adoService, accountList);
    //}

    //public async static Task<IList<Account>?> GetOrgsAsync(IAzDevOpsService adoService) {
    //    return await adoService.GetAccountAsync(null);
    //}
}
