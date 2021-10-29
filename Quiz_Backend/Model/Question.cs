using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz_Backend.Model
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string question { get; set; }
        public string CorrectAnswer { get; set; }
        public string answer1 { get; set; }
        public string answer2 { get; set; }
        public string answer3 { get; set; }

        [ForeignKey("Quiz")]
        public int IdQuiz { get; set; }
        public Quiz Quiz { get; set; }


    }
}
