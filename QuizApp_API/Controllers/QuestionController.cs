using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp_API.Models;
using QuizApp_API.Services;

namespace QuizApp_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        // GET: api/Question/random
        [HttpGet("random")]
        public async Task<ActionResult<Question>> GetRandomQuestion()
        {
            var question = await _questionService.GetRandomQuestionAsync();
            if (question == null)
            {
                return NotFound("Keine Fragen verfügbar");
            }
            return question;
        }

        // GET: api/Question
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            return Ok(await _questionService.GetAllQuestionsAsync());
        }

        // GET: api/Question/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return question;
        }

        // POST: api/Question
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Question>> CreateQuestion(Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdQuestion = await _questionService.CreateQuestionAsync(question);
            return CreatedAtAction(
                nameof(GetQuestion),
                new { id = createdQuestion.Id },
                createdQuestion);
        }

        // PUT: api/Question/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateQuestion(int id, Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedQuestion = await _questionService.UpdateQuestionAsync(id, question);
            if (updatedQuestion == null)
            {
                return NotFound();
            }

            return Ok(updatedQuestion);
        }

        // DELETE: api/Question/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var result = await _questionService.DeleteQuestionAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}