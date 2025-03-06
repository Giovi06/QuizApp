using Microsoft.EntityFrameworkCore;
using QuizApp_API.Data;
using QuizApp_API.Models;

namespace QuizApp_API.Services
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
        Task<Question> GetQuestionByIdAsync(int id);
        Task<Question> GetRandomQuestionAsync();
        Task<Question> CreateQuestionAsync(Question question);
        Task<Question> UpdateQuestionAsync(int id, Question question);
        Task<bool> DeleteQuestionAsync(int id);
    }

    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext _context;

        public QuestionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(int id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async Task<Question> GetRandomQuestionAsync()
        {
            var count = await _context.Questions.CountAsync();
            if (count == 0) return null;

            var random = new Random();
            var skip = random.Next(0, count);

            return await _context.Questions.Skip(skip).FirstOrDefaultAsync();
        }

        public async Task<Question> CreateQuestionAsync(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<Question> UpdateQuestionAsync(int id, Question question)
        {
            if (id != question.Id) return null;

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return question;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await QuestionExists(id))
                {
                    return null;
                }
                throw;
            }
        }

        public async Task<bool> DeleteQuestionAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null) return false;

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> QuestionExists(int id)
        {
            return await _context.Questions.AnyAsync(e => e.Id == id);
        }
    }
}