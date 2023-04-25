namespace AzDevOps.Contracts;
public class Organisation {
    public Account Properties { get; set; }
    public IList<Project> Projects { get; set; }
    public IList<User> Users { get; set; }
}
