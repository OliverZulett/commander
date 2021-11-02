using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
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
    private readonly IMapper _mapper;

    // private readonly MockCommanderRepo _repository = new MockCommanderRepo();

    public CommandsController(ICommanderRepo repostory, IMapper mapper)
    {
      _repository = repostory;
      _mapper = mapper;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
    {
      var commandsItems = _repository.GetAllCommands();
      return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandsItems));
    }

    [HttpGet("{id}")]
    public ActionResult<CommandReadDto> GetCommandById(int id)
    {
      var commandItem = _repository.GetCommandById(id);
      if (commandItem != null)
      {
        return Ok(_mapper.Map<CommandReadDto>(commandItem));
      }
      return NotFound();
    }
  }
}