namespace BurakYollarda.WebUI.Areas.Admin.Models
{
    public class PostViewModel
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public string Summary { get; set; }
		public string? ImagePath { get; set; }
		public int? SubCategoryId { get; set; }
		public string SubCategoryName { get; set; }
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }


	}
}
