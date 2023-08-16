using System.ComponentModel.DataAnnotations;

namespace BtkAkademi.Models
{
    public class Candidate
    {
        [Required(ErrorMessage ="Email is required")]
        public string Email { get; set; }=String.Empty;
         [Required(ErrorMessage ="FirstName is required")]
        public string? FirstName { get; set; }=string.Empty;
         [Required(ErrorMessage ="LastName is required")]
        public string? LastName{get;set;}=string.Empty;
        public string? FullName=>$"{FirstName}{LastName}";
        public int Age { get; set; }
        public string? SelectedCourse{get;set;}=string.Empty;
        public DateTime ApplyAt{get;set;}

        public Candidate()
        {
            ApplyAt=DateTime.Now;
        }
      
   

    }
    
    
   
}
    
