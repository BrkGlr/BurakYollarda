using System.ComponentModel.DataAnnotations;

namespace BurakYollarda.WebUI.Areas.Admin.Models
{
	public class PostFormViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Lütfen Kategori Seçiniz.")]
		[Display(Name = "Kategori")]
		public int CategoryId { get; set; }

		[Required(ErrorMessage = "Lütfen Alt Kategori Seçiniz.")]
		[Display(Name = "Alt Kategori")]
		public int? SubCategoryId { get; set; }

		[Required(ErrorMessage = "Lütfen Başlık Giriniz.")]
		[Display(Name = "Başlık")]
		public string Title { get; set; }
		[Required(ErrorMessage = "Lütfen İçerik Giriniz.")]
		[Display(Name = "İçerik")]
		public string Content { get; set; }
		[Required(ErrorMessage = "Lütfen Özet Giriniz")]
		[Display(Name = "Özet")]
		public string Summary { get; set; }
		
		[Display(Name = "Resim")]
        
		public IFormFile File { get; set; }

	}
}
