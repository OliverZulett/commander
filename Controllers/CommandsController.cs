using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controller
{
  [ApiController]
  // [Route("api/[controller]")] //cuando se le pone el [controller] agarra el nombre de la clase sin el Controller
  [Route("api/commands")]
  public class CommandsController : ControllerBase
  {
    private readonly ICommanderRepo _repository;

    // private readonly MockCommanderRepo _repository = new MockCommanderRepo();

    public CommandsController(ICommanderRepo repostory)
    {
      _repository = repostory;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Command>> GetAllCommands()
    {
      var commandsItems = _repository.GetAllCommands();
      return Ok(commandsItems);
    }

    [HttpGet("{id}")]
    public ActionResult<Command> GetCommandById(int id)
    {
      var commandItem = _repository.GetCommandById(id);
      return Ok(commandItem);
    }
  }
}