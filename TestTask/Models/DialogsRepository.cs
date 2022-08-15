namespace TestTask.Models;

public class DialogsRepository : IRepository<RGDialogsClients>
{
    private static readonly List<RGDialogsClients> _dialogsClients = new RGDialogsClients().Init();

    public IEnumerable<RGDialogsClients> Get() => _dialogsClients;
}