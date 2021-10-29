using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz_Backend.Model
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }
        public string title { get; set; }
        public string Ownerid { get; set; }

        //relationship one to many
        public ICollection<Question> Questions { get; set; }
    }
}
