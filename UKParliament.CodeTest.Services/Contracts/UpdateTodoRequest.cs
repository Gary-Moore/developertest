using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKParliament.CodeTest.Services.Contracts
{
    public class UpdateTodoRequest
    {
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool? IsComplete { get; set; }

        public DateTime? DueDate { get; set; }

        public UpdateTodoRequest()
        {
            IsComplete = false;
        }
    }
}
