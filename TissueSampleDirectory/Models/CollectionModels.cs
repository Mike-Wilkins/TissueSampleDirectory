using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TissueSampleDirectory.Models
{
    public class CollectionModels
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Collection Id")]
        public int Collection_Id { get; set; }

        [Required]
        [DisplayName("Disease Term")]
        public string Disease_Term { get; set; }

        [Required]
        public string Title { get; set; }
    }
}