using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TissueSampleDirectory.Models
{
    public class SampleModels
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Collection_Id { get; set; }

        [Required]
        public int Donor_Count { get; set; }

        [Required]
        public string Material_Type { get; set; }

        [Required]
        public string Last_Updated { get; set; }
    }
}