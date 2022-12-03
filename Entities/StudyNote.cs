namespace DevStudyNotes.Entities;
 public class StudyNote
{
    public StudyNote(string title, string description, bool ispublic)
    {
        Title = title;
        Description = description;
        Ispublic = ispublic;

        Reactions = new List<StudyNoteReaction>();
        CreatedAt = DateTime.Now;
    }
 
    public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool Ispublic { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<StudyNoteReaction> Reactions { get; private set; }

        public void AddReaction(bool isPositive){
                if(!Ispublic){
                        throw new InvalidOperationException();
                }
                Reactions.Add(new StudyNoteReaction(isPositive));
        }

        
}