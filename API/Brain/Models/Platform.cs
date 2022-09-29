using System.ComponentModel.DataAnnotations;
namespace Brain.Models
{
    public class Platform
    {
        [Key]
        public int PlatformID { get; set; }
        public string Name { get; set; }
    }
}