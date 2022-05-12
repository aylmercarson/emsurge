namespace Domain;

public interface IPeopleRepository
{
    IEnumerable<Person> GetAll();
    Person? GetByIdOrDefault(Guid id);

    Person GetByIdOrFail(Guid id)
    {
        var result = GetByIdOrDefault(id);
        if (result is null)
        {
            throw new Exception($"Could not find {nameof(Person)} with Id='{id}'");
        }
        return result;
    }
}
