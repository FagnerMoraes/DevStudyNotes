using DevStudyNotes.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevStudyNotes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudyNotesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(){
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(){
            return Ok();
        }

        // api/study-notes HTTP POST
        [HttpPost]
        public IActionResult Post(AddStudyNoteInputModel model){
            // TALVEZ RETORNE BAD REQUEST
            return CreatedAtAction("GetById", new{id =1},model);
        }

        [HttpPost("{id}/reactions")]
        public IActionResult PostReaction(AddReactionStudyNomeInputModel model){
            // talvez retorne not found or bad request
            return NoContent();
        }
    
    }
}