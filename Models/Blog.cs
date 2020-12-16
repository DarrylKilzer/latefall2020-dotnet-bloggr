namespace latefall2020_dotnet_bloggr.Models
{
  public class Blog
  {
    public string Title { get; set; }
    public bool IsPublished { get; set; }
    public string Body { get; set; }
    public int Id { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
  }

  public class CompanyBlogViewModel : Blog
  {
    public int CompanyBlogId { get; set; }
  }
}