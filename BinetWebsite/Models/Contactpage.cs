using System.ComponentModel.DataAnnotations;

namespace BinetWebsite.Models
{
    public class Contactpage
    {
        [Key]
        public int ContactId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Subject is required")]
        public string? Subject { get; set; }
        [Required(ErrorMessage = "Message is required")]
        [MaxLength(100)]
        public Contactfor Contactfor { get; set; } = Contactfor.Normal;
        public string? Message { get; set; }
        public string? Phoneno { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyWebsite { get; set; }
        public string? CompanyPost { get; set; }
        
    }

    
}
public enum Contactfor
{
    Normal,
    Invest
}