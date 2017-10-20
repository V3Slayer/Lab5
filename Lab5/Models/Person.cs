using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5.Models
{
    public class Person
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First name must be 2-20 characters long")]
        public String FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public String LastName { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Birth Date is required")]
        public String BirthDate { get; set;
        }
        public int Age
        {
            get
            {
                DateTime Birth;
                DateTime Now = DateTime.Now;
                if (BirthDate == null)
                {
                    Birth = Convert.ToDateTime(Now);
                }
                else
                {
                    Birth = Convert.ToDateTime(BirthDate);
                }
                int Age = Now.Year - Birth.Year;
                if (Now.Year >= Birth.Year)
                    if (Now.Month >= Birth.Month)
                        if (Now.DayOfYear >= Birth.DayOfYear)
                            return Age;
                return Age - 1;
            }
        }
    }
}
