namespace BurakYollarda.WebUI.Models
{
    public class SubCategoryTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public List<PostTypeViewModel> Posts { get; set; }
    }
}
