using System.ComponentModel.DataAnnotations;

namespace SuperProject.Model
{
    public class User
    {
        [Display(Name = "Введи логин")]
        [MinLength(3, ErrorMessage = "Логин минимум 3 буквы")]
        [MaxLength(10, ErrorMessage = "Логин максимум 10 букв")]
        public string Name { get; set; } = null!;

        [Display(Name = "Введи пароль")]
        [MinLength(3, ErrorMessage = "Пароль минимум 3 буквы")]
        [MaxLength(10, ErrorMessage = "Пароль максимум 10 букв")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Введи пароль еще разок")]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordAgain { get; set; } = null!;

        [Display(Name = "Введи страну")]
        [MinLength(3, ErrorMessage = "Страна минимум 3 буквы")]
        [MaxLength(100, ErrorMessage = "Страна максимум 100 букв")]
        public string Country { get; set; } = null!;
    }
}
