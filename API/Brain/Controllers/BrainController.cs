using AutoMapper;
using Brain.Data;
using Brain.Dtos;
using Brain.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Brain.Controls
{

    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly IBrainRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(IBrainRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }
        // GET api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            else
            {
                return NotFound();
            }
        }
        // Post api/commands/{id}
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var CommandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { id = CommandReadDto }, CommandReadDto);///
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {

            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);

            patchDoc.ApplyTo(commandToPatch, ModelState);
            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {

            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}