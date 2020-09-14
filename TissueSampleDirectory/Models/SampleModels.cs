using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TissueSampleDirectory.Models
{
    public class SampleModels
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Collection_Id { get; set; }

        [DisplayName("Collection Title")]
        public string Collection_Title { get; set; }

        [Required]
        public int Donor_Count { get; set; }

        [Required]
        public string Material_Type { get; set; }

        [Required]
        public string Last_Updated { get; set; }
    }
}