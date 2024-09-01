using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data.DTO;
using UKParliament.CodeTest.Data.Entities;

namespace UKParliament.CodeTest.Services
{
    public interface IToDoItemValidator
    {
        ICollection<string> ValidateToDoItem(TodoItem item);

        ICollection<string> ValidateCreateToDoItem(CreateTodoRequestDTO item);

        ICollection<string> ValidateUpdateToDoItem(UpdateTodoRequestDTO item);

        public void Validate<T>(Func<T, ICollection<string>> validateMethod, T entityToValidate);
        public void Validate(Func<CreateTodoRequestDTO, ICollection<string>> validateCreateToDoItem, CreateTodoRequestDTO request);
        public void Validate(Func<UpdateTodoRequestDTO, ICollection<string>> validateUpdateToDoItem, UpdateTodoRequestDTO request);
    }
}
