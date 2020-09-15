using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TissueSampleDirectory.Models
{
    public class SampleModels
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Donor Count")]
        public int Donor_Count { get; set; }

        [Required]
        [DisplayName("Material Type")]
        public string Material_Type { get; set; }

        public string Last_Updated { get; set; }

        public string Collection_Title { get; set; }
    }
}