using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Quiz_Backend
{
    public class QuizContext: DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options) : base(options)
        { }

        public DbSet<Model.Question> Questions { get; set; }

        public DbSet<Model.Quiz> Quizes { get; set; }


    }
}
