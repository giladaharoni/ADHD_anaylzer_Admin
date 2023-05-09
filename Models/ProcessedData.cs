using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADHD_anaylzer_Admin.Models
{
    [Table("processedData")]
    public class ProcessedData
    {
        [Key]
        public string? CreatedByUser { get; set; }
        [Key]
        public int SessionId { get; set; }
        [Key]
        public long Timestamp { get; set; }
        public bool StayInPlace { get; set; }
        public bool HighAdhd { get; set; }
    }
}
