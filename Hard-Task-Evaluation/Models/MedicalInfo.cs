using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hard_Task_Evaluation.Models
{
    public class MedicalInfo
    {
        [Key]
        public int Id { get; set; }

        [Range(30,250)]
        public int Weight { get; set; }


        [Range(100, 250)]
        public int Height { get; set; }


        [Display(Name = "Goal Of Diet")]
        public string GoalOfDiet { get; set; }


        [Display(Name = "Exercise Time")]
        public string ExerciseTime { get; set; }


        [Display(Name = "Level Of Exercise")]
        public string LevelOfExercise { get; set; }


        [Display(Name = "Daily Food")]
        public string DailyFood { get; set; }


        public string Vitamins { get; set; }


        [Display(Name = "Problem History")]
        public string ProblemHistory { get; set; }
    }
}