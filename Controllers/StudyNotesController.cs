using DevStudyNotes.Models;
using DevStudyNotes.Entities;
using Microsoft.AspNetCore.Mvc;
using DevStudyNotes.Data;
using Microsoft.EntityFrameworkCore;

namespace DevStudyNotes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudyNotesController : ControllerBase
    {
        private readonly StudyDbContext _dbContext;
        public StudyNotesController(StudyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll(){
            var studyNotesList = _dbContext.StudyNotes.ToList();
            return Ok(studyNotesList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var studyNote = _dbContext.StudyNotes
            .Include(s => s.Reactions)
            .SingleOrDefault(s => s.Id == id);
            if(studyNote is null)
                return NotFound();

            return Ok(studyNote);
        }

        // api/study-notes HTTP POST
        /// <summary>
        /// Cadastrar uma nota de estudo
        /// </summary>
        /// <remarks>
        /// { "title": "Estudos AZ-400", "description" : "Sobre o Azure Blob Storage", "IsPublic": true  }
        /// </remarks>
        /// <param name="model">Dados de uma nota de estudo</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Erro</response>
        [HttpPost]
        public IActionResult Post(AddStudyNoteInputModel model){
            // TALVEZ RETORNE BAD REQUEST

            var StudyNote = new StudyNote(model.Title,model.Description, model.IsPublic);

            _dbContext.StudyNotes.Add(StudyNote);
            _dbContext.SaveChanges();

            return CreatedAtAction("GetById", new{id = StudyNote.Id},model);
        }

        [HttpPost("{id}/reactions")]
        public IActionResult PostReaction(int id,AddReactionStudyNomeInputModel model){
            // talvez retorne not found or bad request
            var studyNote = _dbContext.StudyNotes.SingleOrDefault(s => s.Id == id);
            
            if(studyNote is null)
                return BadRequest();

            studyNote.AddReaction(model.IsPositive);
            _dbContext.SaveChanges();

            return NoContent();
        }
    
    }
}