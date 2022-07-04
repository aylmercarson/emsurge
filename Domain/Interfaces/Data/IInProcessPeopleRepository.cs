using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Data;
public interface IInProcessPeopleRepository
{
    public Person? GetByIdOrDefault(Guid id);

    public IEnumerable<Person> GetAll();
}
