using Practic.Data;
using Practic.Data.Mocks;
using Practic.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Practic.ViewModels
{
    public class AddAimViewModel
    {
        [Required]
        [Display(Name = "Название задания")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Описаниение задания")]
        public string TextField { get; set; }

        [Required]
        [Display(Name = "Задача")]
        public string AimTextField { get; set; }

        [Required]
        [Display(Name = "Правильный код")]
        public string CorrectCodeBlock { get; set; }

        [Required]
        [Display(Name = "Изображение")]
        public string Image { get; set; }

        [Display(Name = "Доступность(по умолчанию - доступно)")]
        public bool Avaliable { get; set; }

        [Required]
        [Display(Name = "Часть(первая или вторая)")]
        public virtual Category category { get; set; }

        [Display(Name = "Часть(первая или вторая)")]
        public virtual ApplicationUser applicationUser { get; set; }
    }
}
