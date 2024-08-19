using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    
    public class RegisterViewModel
    {
    [Required]
    [Display(Name ="Username")]
    public string? UserName { get; set; }

    [Required]
    [Display(Name ="Ad Soyad")]
    public string? Name { get; set; }
    [Required]
    [Display(Name ="Email")]
    public string? Email { get; set; }
    
        [Required(ErrorMessage = "Parola alanı gereklidir.")]
        [StringLength(10, ErrorMessage = "Parola en az {2} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name ="Parola")]
        public string? Password { get; set; }

         [Required(ErrorMessage = "Parola alanı gereklidir.")]
         [Compare(nameof(Password), ErrorMessage="Parolanız eşleşmiyor.")]
        [DataType(DataType.Password)]
        [Display(Name ="Parola Tekrar")]
        public string? ConfirmPassword { get; set; }
    }
}
