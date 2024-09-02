using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data.DTO;
using UKParliament.CodeTest.Data.Entities;
using UKParliament.CodeTest.Services.Exceptions;

namespace UKParliament.CodeTest.Services
{
    public class ToDoItemValidator: IToDoItemValidator
    {

        public ICollection<string> ValidateToDoItem(TodoItem item)
            {
                var errors = new List<string>();

                errors.AddRange(ValidateToDoItemSummary(item));

                return errors;
            }

        public ICollection<string> ValidateCreateToDoItem(CreateTodoRequestDTO item)
        {
            var errors = new List<string>();

            errors.AddRange(ValidateCreateToDoItemSummary(item));

            return errors;
        }

        public ICollection<string> ValidateUpdateToDoItem(UpdateTodoRequestDTO item)
        {
            var errors = new List<string>();

            errors.AddRange(ValidateUpdateToDoItemSummary(item));

            return errors;
        }
        public void Validate<T>(Func<T, ICollection<string>> validateMethod, T entityToValidate)
        {
            var validation = validateMethod(entityToValidate);

            if (validation?.Any() ?? false)
            {
                throw new ValidationException($"Validation errors: {validation}");
            }

        }

        public void Validate(Func<CreateTodoRequestDTO, ICollection<string>> validateToDoItem, CreateTodoRequestDTO request)
        {
            var validation = validateToDoItem(request);

            if (validation?.Any() ?? false)
            {
                throw new ValidationException($"Validation errors: {validation}");
            }
        }

        public void Validate(Func<UpdateTodoRequestDTO, ICollection<string>> validateToDoItem, UpdateTodoRequestDTO request)
        {
            var validation = validateToDoItem(request);

            if (validation?.Any() ?? false)
            {
                throw new ValidationException($"Validation errors: {validation}");
            }
        }

        private IEnumerable<string> ValidateToDoItemSummary(TodoItem item)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(item.Title))
            {
                errors.Add("To Do Item must have a title");
            }

            if (item.Title.Length > 100)
            {
                errors.Add("To Do Item Title must be less than 100 characters");
            }

            if (item.Description.Length > 500)
            {
                errors.Add("To Do Item Description must be less than 500 characters");
            }

            if (item.IsComplete.GetType() != typeof(bool))
            {
                errors.Add("To Do Item 'Is Completed' field must be 'true' or 'false'");
            }

            if (item.DueDate.GetType() != typeof(DateTime))
            {
                errors.Add("To Do Item 'Due date' field must be in Date Time format");
            }

            return errors;

        }

        private IEnumerable<string> ValidateCreateToDoItemSummary(CreateTodoRequestDTO item)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(item.Title))
            {
                errors.Add("To Do Item must have a title");
            }

            if (item.Title.Length > 100)
            {
                errors.Add("To Do Item Title must be less than 100 characters");
            }

            if (item.Description.Length > 500)
            {
                errors.Add("To Do Item Description must be less than 500 characters");
            }

            if (item.IsComplete.GetType() != typeof(bool))
            {
                errors.Add("To Do Item 'Is Completed' field must be 'true' or 'false'");
            }

            if (item.DueDate.GetType() != typeof(DateTime))
            {
                errors.Add("To Do Item 'Due date' field must be in Date Time format");
            }

            return errors;

        }

        private IEnumerable<string> ValidateUpdateToDoItemSummary(UpdateTodoRequestDTO item)
        {
            var errors = new List<string>();

            if (item.Title.Length > 100)
            {
                errors.Add("To Do Item Title must be less than 100 characters");
            }

            if (item.Description.Length > 500)
            {
                errors.Add("To Do Item Description must be less than 500 characters");
            }

            if (item.IsComplete.GetType() != typeof(bool))
            {
                errors.Add("To Do Item 'Is Completed' field must be 'true' or 'false'");
            }

            if (item.DueDate.GetType() != typeof(DateTime))
            {
                errors.Add("To Do Item 'Due date' field must be in Date Time format");
            }

            return errors;

        }

    }
}
