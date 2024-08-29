using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKParliament.CodeTest.Data.DTO
{
    public class CompleteTodoRequestDTO
    {

        [DefaultValue(true)]
        public bool IsComplete { get; set; }
    }
}
