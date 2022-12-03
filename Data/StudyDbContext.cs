using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevStudyNotes.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevStudyNotes.Data
{
    public class StudyDbContext : DbContext
    {
        public StudyDbContext(DbContextOptions<StudyDbContext> options) : base(options){}

        public DbSet<StudyNote> StudyNotes {get; set;}
        public DbSet<StudyNoteReaction> StudyNoteReactions {get; set;}

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<StudyNote>(e => {
                    e.HasKey(s => s.Id);

                    e.HasMany(s => s.Reactions)
                        .WithOne()
                        .HasForeignKey(r => r.StudyNoteId)
                        .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<StudyNoteReaction>(e => {
                    e.HasKey(sn => sn.Id);
            });
        }
    }
}