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

    // ponemos el Name para que el CreatedAtRoute lo reconozca
    [HttpGet("{id}", Name="GetCommandById")]
    public ActionResult<CommandReadDto> GetCommandById(int id)
    {
      var commandItem = _repository.GetCommandById(id);
      if (commandItem != null)
      {
        return Ok(_mapper.Map<CommandReadDto>(commandItem));
      }
      return NotFound();
    }

    [HttpPost]
    public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
    {
      var commandModel = _mapper.Map<Command>(commandCreateDto);
      _repository.CreateCommand(commandModel);
      _repository.SaveChanges();
      var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
      // return Ok(commandReadDto);
      // const el created CreatedAtRoute generamos el hateoas solo que el link se muestra en el header del response
      // const el parametro location
      return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
    {
      var commandModelFromRepo = _repository.GetCommandById(id);
      if (commandModelFromRepo == null)
      {
          return NotFound();
      }
      // cuando mapea automaticamente se actualizan los datos del commandModelFromRepo
      _mapper.Map(commandUpdateDto, commandModelFromRepo);
      _repository.UpdateCommand(commandModelFromRepo);
      _repository.SaveChanges();
      return NoContent();
    }
  }
}