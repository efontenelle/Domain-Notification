using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared.ValueObject
{
    public class CreateValueObjectResult<T>
    {      
        public T Result { get; private set; }
        public IReadOnlyCollection<Notification> Errors => _errors.ToList();
        private IEnumerable<Notification> _errors;
        public bool Created => Result != null;

        private CreateValueObjectResult(T result)
        {
            Result = result;
            _errors = new List<Notification>();
        }

        private CreateValueObjectResult(IEnumerable<Notification> notifications)
        {
            _errors = notifications;
        }

        public static CreateValueObjectResult<T> CreateSuccesResult(T result)
        {
            return new CreateValueObjectResult<T>(result);
        }

        public static CreateValueObjectResult<T> CreateFailResult(IEnumerable<Notification> notifications)
        {
            return new CreateValueObjectResult<T>(notifications);
        }
    }
}
