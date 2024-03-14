

using System.Linq.Expressions;

var a = Expression.Variable(typeof(int), "y");
var x = Expression.Variable(typeof(int),"x");
var label = Expression.Label(typeof(int));

var condition = Expression.IfThenElse(
            Expression.GreaterThan(x, a),
            Expression.Block(Expression.Increment(x), Expression.Return(label, x)),
            Expression.Block(Expression.Decrement(x), Expression.Return(label, x))
        );

var body = Expression.Block(
        new[] { a },
        Expression.Assign(a,Expression.Constant(10)),
        condition,
        Expression.Label(label)
    );
    

var program = Expression.Lambda<Func<int,int>>(body, new[] { x });

var u = program.Compile()(6);


Console.WriteLine();


//Expression.Lambda(ex,)


//Expression.Condition(test,)
//Console.WriteLine(f.Body);