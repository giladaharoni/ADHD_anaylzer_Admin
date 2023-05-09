using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADHD_anaylzer_Admin.Models
{
    [Table("Answers")]
    public class QuizAnswer
    {
        [Key]
        public String? AnswerByUserName { get; set; }
        [Key]
        public int QuestionNumber { get; set; }
        public int Answer { get; set; }

    }
}
