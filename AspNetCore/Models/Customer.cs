using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Models
{
    //DataAnnotation
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ad alanı boş geçilemez")] //zorunlu alan dataannotation ile validation
        [MaxLength(30, ErrorMessage ="Ad alanı en fazşa 30 karakter olabilir")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Soyad alanı boş geçilemez")]
        [MinLength(3, ErrorMessage ="Soyad alanı en az 3 karakter olabilir")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Yaş alanı boş geçilemez")]
        [Range(18,40, ErrorMessage= "Yaş değeri en az 18, en fazla 40 olabilir")] // değer aralığı
        public int Age { get; set; }
    }
}
