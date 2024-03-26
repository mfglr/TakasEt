using AutoMapper;



var s = new Source()
{
    Total = 5
};


var configuration = new MapperConfiguration(cfg =>
   cfg.CreateMap<Source, Destination>()
     .ForMember(dest => dest.ContainerName, opt => opt.MapFrom<CustomResolver>()));
configuration.AssertConfigurationIsValid();

var mapper = new Mapper(configuration);

var d = mapper.Map<Destination>(s);

Console.WriteLine();
public class ContainerName
{
    public string Value { get;  set; }
}

public class Destination
{
    public ContainerName ContainerName { get; set; }
}

public class Source
{
    public int Total { get; set; }
}

public class CustomResolver : IValueResolver<Source, Destination, ContainerName>
{
    public ContainerName Resolve(Source source, Destination destination, ContainerName member, ResolutionContext context)
    {
        return new ContainerName() { Value = "deneme"};
    }
}