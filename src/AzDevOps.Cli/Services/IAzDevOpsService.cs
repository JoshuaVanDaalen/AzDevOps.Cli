﻿using AzDevOps.Contracts;

namespace AzDevOps.Cli.Services; 
public interface IAzDevOpsService {
    public Task<IList<Account>?> GetAccountAsync(Guid? id, bool isOwner = false);
    public Task<IList<Project>?> GetProjectAsync();

}