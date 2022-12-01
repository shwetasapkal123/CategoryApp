using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMVC1.Models
{
    public class Category
    {
        //key to make sure that id is primary key also identity column entity
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //Adding display name to display on web page for error istead of DisplayOrder it will print Display Order
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display order is between 1 -100 only!!!")]
        public int DisplayOrder { get; set; }
        //Assigning default date time value by using =dateTime.Now
        public DateTime CreatedDateTime { get; set; }=DateTime.Now;
    }
}
