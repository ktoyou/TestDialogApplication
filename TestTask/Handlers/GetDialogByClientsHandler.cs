using TestTask.Models;

namespace TestTask.Handlers;

public class GetDialogByClientsHandler : IGetDialogHandler
{
    public GetDialogByClientsHandler(IEnumerable<Guid> clients, DialogsRepository repository)
    {
        _clients = clients;
        _dialogsRepository = repository;
    }

    public Guid Handle()
    {
        ThrowIfClientsEmpty();
        var group = FindDialogGroup();
        return group?.Key ?? Guid.Empty;
    }

    private void ThrowIfClientsEmpty()
    {
        if (!_clients.Any()) throw new Exception("Clients cannot be empty");
    }

    private IGrouping<Guid, RGDialogsClients>? FindDialogGroup()
    {
        return _dialogsRepository
            .Get()
            .GroupBy(e => e.IDRGDialog)
            .Where(dialog =>
                _clients.All(q =>
                    dialog.Any(client => client.IDClient == q)))
            .ToList()
            .FirstOrDefault();
    }

    private readonly IEnumerable<Guid> _clients;

    private readonly DialogsRepository _dialogsRepository;
}