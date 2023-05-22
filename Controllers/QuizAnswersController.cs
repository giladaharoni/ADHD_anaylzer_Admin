using ADHD_anaylzer_Admin.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ADHD_anaylzer_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizAnswersController : ControllerBase
    {
        private readonly IQuizAnswerModel _answers;

        public QuizAnswersController(IQuizAnswerModel answers)
        {
            this._answers = answers;
        }

        [HttpGet]
        public IActionResult GetQuizAnswersByUser(string username)
        {
            return Ok(_answers.GetQuizAnswerByUser(username));
        }

        [HttpPost]
        public void UploadAnswers(string username, IEnumerable<GivenAnswer> answers)
        {
            var quizAnswers = answers.Select(x => new QuizAnswer { Answer = x.Answer, QuestionNumber = x.QuestionNumber, AnswerByUserName = username });
            try
            {
                _answers.UpdateQuizAnswer(quizAnswers);

            } catch (Exception ex)
            {
                _answers.AddQuizAnswers(quizAnswers);

            }

        }

        [HttpPut]
        public void UpdateAnswers(string username, IEnumerable<GivenAnswer> answers)
        {
            var quizAnswers = answers.Select(x => new QuizAnswer { Answer = x.Answer, QuestionNumber = x.QuestionNumber, AnswerByUserName = username });
            _answers.UpdateQuizAnswer(quizAnswers);

        }
        [HttpDelete("deleteAll")]
        public void DeleteData(string admin_password)
        {
            if (admin_password == "ADHD_analyzer_reset_all_everything#%$^")
            {
                _answers.DeleteAll();
            }
        }






    }
}
