
using System.Collections;
using System.Reflection;

Level0 data = new Level0()
{
    DateTime = DateTime.UtcNow,
    Level1 = new Level1()
    {
        DateTime = DateTime.UtcNow,
        Level2 = new Level2()
        {
            DateTime = DateTime.UtcNow
        }
    }
};

var list = CreateList();

ConvertDateTimes(list, -180);


Console.WriteLine();

List<Level0> CreateList()
{
    return new List<Level0>()
    {
        new Level0()
        {
            DateTime = DateTime.UtcNow,
            Level1 = new Level1()
            {
                DateTime = DateTime.UtcNow,
                Level2 = new Level2()
                {
                    DateTime = DateTime.UtcNow
                }
            }
        },
        new Level0()
        {
            DateTime = DateTime.UtcNow,
            Level1 = new Level1()
            {
                DateTime = DateTime.UtcNow,
                Level2 = new Level2()
                {
                    DateTime = DateTime.UtcNow
                }
            }
        }
    };
}

void ConvertDateTimes(object? instance, int offset)
{
    if (instance == null)
        return;
    var type = instance.GetType();

    if (typeof(IEnumerable).IsAssignableFrom(type))
    {
        Type? itemType = type.GetElementType();
        if (itemType == null)
            itemType = type.GetGenericArguments()[0];

        var items = (IEnumerable)instance;
        foreach (var item in items)
            ConvertDateTimesOfObjectRecursively(item, offset);
    }
    else
        ConvertDateTimesOfObjectRecursively(instance, offset);


}

void ConvertDateTimesOfObjectRecursively(object? instance,int offset)
{
    if (instance == null)
        return;
    var type = instance.GetType();
    PropertyInfo[] properties = type.GetProperties();
    foreach (var property in properties)
    {
        var pType = property.PropertyType;
        var pInstance = property.GetValue(instance);
        if ((pType == typeof(DateTime) || pType == typeof(DateTime?)) && pInstance != null)
        {
            var value = (DateTime)pInstance!;
            property.SetValue(instance, value.AddMinutes(-1 * offset));
            continue;
        }
        if (pType.IsValueType || pType == typeof(string))
            continue;
        ConvertDateTimesOfObjectRecursively(pInstance, offset);
    }
}





class Level0
{
    public Level1 Level1 { get; set; }
    public DateTime DateTime { get; set; }
}

class Level1
{
    public Level2 Level2 { get; set; }
    public DateTime DateTime { get; set; }

}

class Level2
{
    public DateTime DateTime { get; set; }
}


//Expression.Lambda(ex,)


//Expression.Condition(test,)
//Console.WriteLine(f.Body);