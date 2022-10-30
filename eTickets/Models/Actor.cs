using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage ="Full Name is required")]
        public string FullName { get; set; }
        [Display(Name ="Picture")]
        [Required(ErrorMessage = "Picture is required")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; }
        public List<Actor_Movie> Actors_Movie { get; set; }
    }
}
