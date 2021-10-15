# Number to words

Classic number to words console app using .NET 6 and its new features.
The idea is revisit the syntax and make it as readable and shorter as possible. No validations added!

The algorithm uses new C# switch pattern matching features

Range of valid convertable value is between `int.MinValue + 1` to `int.Max`

You could use this program to store all number as words in a redis db, then instead of calculating the value you would query the NumberToWords redis db