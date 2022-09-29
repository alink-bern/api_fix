using Brain.Models;

namespace Brain.Data
{
    public class SQLBrainRepo : IBrainRepo
    {
        private readonly BrainContext _context;

        public SQLBrainRepo(BrainContext context)
        {
            _context = context;
        }
        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Command.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Command.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Command.ToList<Command>();
        }

        public Command GetCommandById(int id)
        {
            Command CommandToReturn = _context.Command.FirstOrDefault(x => x.CommandID == id);

            return CommandToReturn;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
            //Nothing
        }
    }
}