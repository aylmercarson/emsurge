using Microsoft.Extensions.Configuration;

namespace Infrastructure;
public abstract class RepositoryBase
{
    private readonly IConfiguration _configuration;

    public RepositoryBase(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string PeopleJsonLocation {
        get { return _configuration["AppSettings:PeopleJsonLocation"]; }
    }

    public string AnimalsJsonLocation {
        get { return _configuration["AppSettings:AnimalsJsonLocation"]; }
    }
}
