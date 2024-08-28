using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKParliament.CodeTest.Data.DTO
{
    public class CreateTodoRequestDTO
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
    }
}
