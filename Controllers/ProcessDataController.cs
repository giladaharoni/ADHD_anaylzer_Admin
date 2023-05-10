using ADHD_anaylzer_Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADHD_anaylzer_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessDataController : ControllerBase
    {
        private readonly IProcessDataModel processDataModel;
        public ProcessDataController(IProcessDataModel processDataModel)
        {
            this.processDataModel = processDataModel;
        }
        [HttpGet]
        public IActionResult getDataBySessionAndUser(string username, int session)
        {
            return Ok(processDataModel.GetDataBySessionAndUser(username, session));
        }
        [HttpGet("session")]
        public IActionResult getAvilabeSessions(string username)
        {
            return Ok(processDataModel.GetAvilableSessionForUser(username));
        }
        [HttpPost]
        public void UploadData(ICollection<GivenProcessData> datas, string username)
        {
            var processData = datas.Select(d => new ProcessedData { CreatedByUser=username,SessionId=d.SessionId, HighAdhd=d.HighAdhd,Timestamp=d.Timestamp,StayInPlace=d.StayInPlace});
            processDataModel.AddData(processData.ToList());
        }
        [HttpDelete("deleteAll")]
        public void DeleteData(string admin_password)
        {
            if (admin_password == "ADHD_analyzer_reset_all_everything#%$^")
            {
                processDataModel.DeleteAll();
            }
        }
    }
}
