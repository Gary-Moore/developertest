using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKParliament.CodeTest.Data.DTO
{ 
    public class UpdateTodoRequestDTO
    {
        // Validator will only kick in if you take these Annotations off
        [StringLength(100)]

        public string Title { get; set; }

        [StringLength(500)]

        public string Description { get; set; }

        [DefaultValue(false)]
        public bool IsComplete { get; set; }

    
        public DateTime? DueDate { get; set; }

        public UpdateTodoRequestDTO()
        {
            IsComplete = false;
        }
    }
}
