namespace ADHD_anaylzer_Admin.Models
{
    public interface IQuizAnswerModel
    {
        IEnumerable<QuizAnswer> GetAllQuizAnswer();
        QuizAnswer GetQuizAnswerByUserAndQuestion(String username, int question);

        IEnumerable<QuizAnswer> GetQuizAnswerByUser(String username);

        void AddQuizAnswer(QuizAnswer quizAnswer);
        void AddQuizAnswers(IEnumerable<QuizAnswer> quizAnswer);
        void UpdateQuizAnswer(IEnumerable<QuizAnswer> quizAnswer);
        void DeleteAll();


    }
    public class QuizAnswerModel : IQuizAnswerModel
    {
        private readonly myDBContext _context;
        public QuizAnswerModel(myDBContext context)
        {
            _context = context;
        }
        public void AddQuizAnswer(QuizAnswer quizAnswer)
        {
            _context.Answers.Add(quizAnswer);
            _context.SaveChanges();
        }
        public void AddQuizAnswers(IEnumerable<QuizAnswer> quizAnswer)
        {
            _context.Answers.AddRange(quizAnswer);
            _context.SaveChanges();
        }
        public IEnumerable<QuizAnswer> GetAllQuizAnswer()
        {
            return _context.Answers.ToList();
        }

        public IEnumerable<QuizAnswer> GetQuizAnswerByUser(string username)
        {
            return _context.Answers.Where(e => e.AnswerByUserName == username).ToList();
        }

        public QuizAnswer GetQuizAnswerByUserAndQuestion(string username, int question)
        {
            return _context.Answers.Where(e => e.AnswerByUserName == username && e.QuestionNumber == question).FirstOrDefault();
        }

        public void UpdateQuizAnswer(IEnumerable<QuizAnswer> quizAnswer)
        {
            _context.UpdateRange(quizAnswer);
            _context.SaveChanges();
        }

        public void DeleteAll()
        {
            foreach (var data in _context.Answers)
            {
                _context.Answers.Remove(data);
            }
            _context.SaveChanges();
        }
    }
}
