using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hard_Task_Evaluation.Models
{
    public class Food_Supplements
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EnumDataType(typeof(Food_SupplementsType))]
        public Food_SupplementsType Food_SupplementsType { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(Time))]
        public Time Time { get; set; }

        [Required]
        public string Item { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Protien { get; set; }

        [Required]
        public int Fat { get; set; }

        [Required]
        public int Carb { get; set; }

        [Required]
        public int TotalCalories { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}