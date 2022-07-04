using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces;
public interface IInProcessPeopleRepository
{
    public Person? GetByIdOrDefault(Guid id);

    public IEnumerable<Person> GetAll();
}
