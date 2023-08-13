
using System.Linq.Expressions;

IFilter<User> a = new GetUsersByExpressionDto("furkan");


Console.WriteLine(a.Filter().Compile().Invoke(new User("furkan")));


class Obje
{
    public int Id { get; set; }
    public string Name { get; set; }
}

interface IFilter<T>
{
	Expression<Func<T, bool>> Filter();
}

class Entity
{
	public Guid Id { get; private set; }
	public DateTime CreatedDate { get; private set; }
	public DateTime UpdatedDate { get; private set; }

	public Entity()
	{
		Id = Guid.NewGuid();
		CreatedDate = DateTime.UtcNow;
		UpdatedDate = DateTime.UtcNow;
	}
}

class User : Entity
{
	public string Name { get; private set; }

	public User(string name)
	{
		Name = name;
	}
}

class GetEntitiesByExpressionDto : IFilter<Entity>
{
	public Guid? Id { get; private set; }

	public DateTime? MinCreatedDate { get; private set; }
	public DateTime? MaxCreatedDate { get; private set; }

	public DateTime? MinUpdatedDate { get; private set; }
	public DateTime? MaxUpdatedDate { get; private set; }

	public Expression<Func<Entity, bool>> Filter()
	{
		return
			x =>
				(Id == null || x.Id == Id) &&
				(MinCreatedDate == null || MinCreatedDate <= x.CreatedDate) &&
				(MaxCreatedDate == null || x.CreatedDate <= MaxCreatedDate) &&
				(MinUpdatedDate == null || MinUpdatedDate <= x.UpdatedDate) &&
				(MaxUpdatedDate == null || x.UpdatedDate <= MaxUpdatedDate);
	}
}



class GetUsersByExpressionDto : GetEntitiesByExpressionDto, IFilter<User>
{
	public string? Name { get; private set; }

	Expression<Func<User, bool>> IFilter<User>.Filter()
	{
		Expression<Func<Entity,bool>> baseFilter = ((IFilter<Entity>)this).Filter();
		return
			x =>
				baseFilter.Compile().Invoke(x) &&
				(Name == null || x.Name == Name);
	}
    public GetUsersByExpressionDto(string name)
    {
        Name = name;
    }
}
