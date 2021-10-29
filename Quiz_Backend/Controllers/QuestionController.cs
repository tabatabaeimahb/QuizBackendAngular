using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Quiz_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private QuizContext _db;
        public QuestionController(QuizContext db)
        {
            _db = db;
        }
        [HttpPost]
        public void post([FromBody] Model.Question q)
        {
            _db.Questions.Add(new Model.Question {
                question = q.question, answer1 = q.answer1,
                answer2 = q.answer2, answer3 = q.answer3
                                                , CorrectAnswer = q.CorrectAnswer,
                IdQuiz = q.IdQuiz
            });

            _db.SaveChanges();

        }
        //api/Question/getQuestionByid
        [HttpGet(template: "getQuestionByid/{id}")]
      
        public ActionResult<IList<Model.Question>> getQuestionByid(int id)
        {
            List<Model.Question> lst = _db.Questions.Where(r=>r.IdQuiz==id).ToList();
            return lst;
        }

        [HttpGet]
        public ActionResult<IList<Model.Question>> Get()
        {
            List<Model.Question> lst = _db.Questions.ToList();
            return lst;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Model.Question q)
        {
            if (id!=q.Id)
            {
                return BadRequest();
            }

            _db.Questions.Attach(q);
            await _db.SaveChangesAsync();

            return Ok(q);
        }
    }
}
