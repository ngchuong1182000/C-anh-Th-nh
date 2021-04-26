namespace R5.Models
{

    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
