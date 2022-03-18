using Microsoft.AspNetCore.Mvc.Rendering;

namespace bookish.Models.Database
{
    public class AuthorDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public IEnumerable<SelectListItem> Names { get; set; }
    }
}