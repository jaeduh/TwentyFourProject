using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFour.Models
{
    public class UserCreate
    {
        [Required]
        [MinLength(6, ErrorMessage = "Please enter at least 6 characters.")]
        [MaxLength(24, ErrorMessage = "There are too many characters in this field.")]

        public string Name { get; set; }

        public string Address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
