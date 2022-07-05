using Microsoft.Extensions.Configuration;

namespace Infrastructure;
public class RepositoryBase
{
    private readonly IConfiguration _configuration;

    public RepositoryBase(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string PersonJsonLocation {
        get {
            return _configuration["AppSettings:PeopleJsonLocation"];
        }
    }
}
