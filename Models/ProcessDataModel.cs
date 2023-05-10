namespace ADHD_anaylzer_Admin.Models
{
    public interface IProcessDataModel
    {
        ICollection<ProcessedData> GetDataBySessionAndUser(string userId, int sessionId);
        void AddData(ICollection<ProcessedData> datas);

        ICollection<int> GetAvilableSessionForUser(string username);
        void DeleteAll();
    }
    public class ProcessDataModel : IProcessDataModel
    {
        private readonly myDBContext _context;
        public ProcessDataModel(myDBContext context)
        {
            _context = context;
        }

        public void AddData(ICollection<ProcessedData> datas)
        {
            _context.Datas.AddRange(datas);
            _context.SaveChanges();
        }

        public ICollection<ProcessedData> GetDataBySessionAndUser(string username, int sessionId)
        {
            return _context.Datas.Where(d => d.SessionId == sessionId && d.CreatedByUser == username).OrderBy(d => d.Timestamp).ToList();
        }
        public ICollection<int> GetAvilableSessionForUser(string username)
        {
            return _context.Datas.Where(e => e.CreatedByUser == username).Select(d => d.SessionId).Distinct().ToList();
        }

        public void DeleteAll()
        {
            foreach (var data in _context.Datas)
            {
                _context.Datas.Remove(data);
            }
            _context.SaveChanges();
        }
    }
}
