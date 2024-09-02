using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UKParliament.CodeTest.Data.DTO
{
    public class CreateTodoRequestDTO
    {
        // Validator will only kick in if you take these Annotations off
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [DefaultValue("false")]
        public bool IsComplete { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        // set as false when constructing as you are unlikely to want to create a new item that has already been completed
        public CreateTodoRequestDTO()
        {
            IsComplete = false;
        }
    }
}
