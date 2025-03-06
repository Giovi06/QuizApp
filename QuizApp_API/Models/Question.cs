using System.ComponentModel.DataAnnotations;

namespace QuizApp_API.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string QuestionText { get; set; }

        [Required]
        public string Answer1 { get; set; }

        [Required]
        public string Answer2 { get; set; }

        [Required]
        public string Answer3 { get; set; }

        [Required]
        public string Answer4 { get; set; }

        [Required]
        public int CorrectAnswer { get; set; } // 1-4 für die richtige Antwort
    }
}