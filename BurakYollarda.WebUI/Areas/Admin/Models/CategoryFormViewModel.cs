using System.ComponentModel.DataAnnotations;

namespace BurakYollarda.WebUI.Areas.Admin.Models
{
	public class CategoryFormViewModel
	{
		public int Id { get; set; }

		[Display(Name="Kategori Adı")]
		[Required(ErrorMessage ="Lütfen Kategori Adı Giriniz")]
		public string Name { get; set; }	
	}
}
