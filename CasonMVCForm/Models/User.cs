using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CasonMVCForm.Models
{
    public class User
    {
        [Key]
        [Required(ErrorMessage = "Please enter username")]
        [StringLength(64, ErrorMessage = "Name too long. Max chars: 64")]
        [Display(Name= "User Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(100, ErrorMessage = "Email address too long. Max chars: 100")]
        [EmailAddress(ErrorMessage ="Date is not in correct format (format: xxx@yyy.zz")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Select your gender")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please provide your birth date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "yyyy.MM.dd")]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        public String Comment { get; set; }

        public override string ToString()
        {
            return "Name: " + this.Name + ", Email: " + this.Email + ", Gender: " + this.Gender + ", Birthdate: " + this.BirthDate.Year
                + "." + this.BirthDate.Month + "." + this.BirthDate.Day + ", Comment: " + this.Comment;
        }
    }
}
