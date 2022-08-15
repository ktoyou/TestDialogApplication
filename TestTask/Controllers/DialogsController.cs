using Microsoft.AspNetCore.Mvc;
using TestTask.Handlers;
using TestTask.Models;

namespace TestTask.Controllers;

[ApiController]
[Route("[controller]")]
public class DialogsController : ControllerBase
{
    public DialogsController(DialogsRepository dialogsRepository)
    {
        _dialogsRepository = dialogsRepository;
    }

    [HttpGet]
    public Guid GetDialogByClients([FromQuery] IEnumerable<Guid> clients) => new GetDialogByClientsHandler(clients, _dialogsRepository).Handle();

    private readonly DialogsRepository _dialogsRepository;
}