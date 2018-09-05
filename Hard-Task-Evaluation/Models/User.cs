using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hard_Task_Evaluation.Models
{
    public class User : ApplicationUser
    {
        public User()
        {
            Food_Supplements = new List<Food_Supplements>();
        }
        [Required, MinLength(3), MaxLength(50), Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required, MinLength(3), MaxLength(50), Display(Name = "Last Name")]
        public string LastName { get; set; }


        [NotMapped]
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
            private set { }
        }


        [Required, DataType(DataType.DateTime), Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }


        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }


        [Required, MaxLength(100)]
        public string Nationality { get; set; }

        [Display(Name = "Civil Id")]
        public int? CivilId { get; set; }

        public virtual List<Food_Supplements> Food_Supplements { get; set; }

        [ForeignKey("MedicalInfo")]
        public int? MedicalInfoId { get; set; }
        public virtual MedicalInfo MedicalInfo { get; set; }
    }
}