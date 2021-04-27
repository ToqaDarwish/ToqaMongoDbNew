using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToqaMongoDbNew.Utilities;

namespace ToqaMongoDbNew.Models
{
    public class CreateBookViewModel
    {
        [Required(ErrorMessage = "Book Name is Required",AllowEmptyStrings = false)]
        [MaxLength(20, ErrorMessage = "You can't enter more than 20 Letters")]
        [MinLength(3, ErrorMessage = "You can't enter less than 3 Letters")]
        [IsEqualToqa(allowedName:"Toqa", ErrorMessage = "The book name must be Toqa")]
        public string BookName { get; set; }
        [Required(ErrorMessage = "Book Description is Required",AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "You can't enter more than 100 Letters")]
        [MinLength(10, ErrorMessage = "You can't enter less than 10 Letters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "You have to insert at least one Tag")]
        public List<string> ListOfTags { get; set; }
        
    }
}
