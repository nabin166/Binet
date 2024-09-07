using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BinetWebsite.Models
{
    public class jobApply
    {
        [Key]
        public int JobId { get; set; }
        public Level JobTitle { get; set; }
        public string? applicantName { get; set; }
        public string? applicantEmail { get; set; }
      
        public string? applicantDescription { get; set; }
        public string? portfolioLink { get; set; }
        public string? applicantCoverletter { get; set; }
        public string? CV { get; set; } = null!;

        [NotMapped]
        public IFormFile PhotoPath { get; set; } = null!;
    }
}
public enum Level
{
    Frontend,
    Backend,
    Designing,
    BinetGold,
    BinetMessageApp

}