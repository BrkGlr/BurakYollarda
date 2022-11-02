using System.ComponentModel.DataAnnotations;

namespace BurakYollarda.WebUI.Areas.Admin.Models
{
    public class SubCategoryFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Alt Kategori Adı Giriniz")]
        [Display(Name ="Alt Kategori Adı") ]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kategori Seçiniz")]
        [Display(Name = "Kategori Adı")]
        public int CategoryId { get; set; }
    }
}
