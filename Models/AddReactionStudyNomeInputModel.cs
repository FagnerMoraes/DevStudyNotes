using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevStudyNotes.Models
{
    public class AddReactionStudyNomeInputModel
    {
        public int StudyNoteId { get; set; }
        public bool IsPositive { get; set; }
    }
}