using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
  public class MockCommanderRepo : ICommanderRepo
  {
    public void CreateCommand(Command cms)
    {
      throw new System.NotImplementedException();
    }

    public void DeleteCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<Command> GetAllCommands()
    {
      var commands = new List<Command>
      {
        new Command{
          Id=0,
          HowTo="install node packages",
          Line="npm i <package-name>",
          Platform="all"
        },
        new Command{
          Id=0,
          HowTo="run node programa",
          Line="npm run start",
          Platform="all"
        },
        new Command{
          Id=0,
          HowTo="run node tests",
          Line="npm run test",
          Platform="all"
        },
      };
      return commands;
    }

    public Command GetCommandById(int id)
    {
      return new Command
      {
        Id = 0,
        HowTo = "installl node packages",
        Line = "npm i <package-name>",
        Platform = "all"
      };
    }

    public bool SaveChanges()
    {
      throw new System.NotImplementedException();
    }

    public void UpdateCommand(Command command)
    {
      throw new System.NotImplementedException();
    }
  }
}