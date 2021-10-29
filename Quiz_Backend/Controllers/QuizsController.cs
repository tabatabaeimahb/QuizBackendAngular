﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz_Backend;
using Quiz_Backend.Model;

namespace Quiz_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizsController : ControllerBase
    {
        private readonly QuizContext _context;

        public QuizsController(QuizContext context)
        {
            _context = context;
        }


        [HttpGet(template: "GetallQuiz")]
        //: api/Quizs/GetallQuiz
        public async Task<ActionResult<IEnumerable<Quiz>>> GetallQuiz()
        {
           // var iduser = HttpContext.User.Claims.First().Value;
            return await _context.Quizes.ToListAsync();
        }
        // GET: api/Quizs
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Quiz>>> GetQuiz()
        {
            var iduser = HttpContext.User.Claims.First().Value;
            return await _context.Quizes.Where(e=>e.Ownerid== iduser).ToListAsync();
        }

        // GET: api/Quizs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quiz>> GetQuiz(int id)
        {
            var quiz = await _context.Quizes.FindAsync(id);

            if (quiz == null)
            {
                return NotFound();
            }

            return quiz;
        }

        // PUT: api/Quizs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
      
        public async Task<IActionResult> PutQuiz(int id, Quiz quiz)
        {
            if (id != quiz.Id)
            {
                return BadRequest();
            }

            _context.Entry(quiz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Quizs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
      
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Quiz>> PostQuiz(Quiz quiz)
        {
            // توسط اچ تی تی پی کانتکس به اطلاعات کاربری که لاگین کرده می رسیم
            var ownerid = HttpContext.User.Claims.First().Value;
            quiz.Ownerid = ownerid;

            _context.Quizes.Add(quiz);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuiz", new { id = quiz.Id }, quiz);
        }

        // DELETE: api/Quizs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz(int id)
        {
            var quiz = await _context.Quizes.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }

            _context.Quizes.Remove(quiz);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuizExists(int id)
        {
            return _context.Quizes.Any(e => e.Id == id);
        }
    }
}
