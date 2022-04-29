# Differences between Newtonsoft.Json and System.Text.Json

System.Text.Json has better performance with serialization/deserialization. Also, it is integrated in the .NET SDK from .NET Core 3.0 on, as to Newtonsoft.Json for which you need a NuGet package.

James Newton-King wrote the original Newtonsoft.Json library and found that he couldn't refactor the library for performance. Therefore, System.Text.Json was written from scratch, implementing async in the serializers properly.

System.Text.Json adheres strictly to the [JSON specifications](https://datatracker.ietf.org/doc/html/rfc8259), so there are things you cannot do anymore compared to the older Newtonsoft.Json.

Here's the official [documentation](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-migrate-from-newtonsoft-how-to?pivots=dotnet-6-0) with differences between the libraries.

## Short summary of important differences:
- System.Text is more strict compared to Newtonsoft, meaning ...
- 

More detailed examples can be found in [NewtonsoftVsSystemTests.cs](../Validation.Tests/NewtonsoftVsSystemTests.cs).

## FAQ: 

Do I need to switch from Newtonsoft.Json to System.Text.Json?
> Absolutely not. Switching will almost certainly cause issues since there are many subtle differences. Newtonsoft will still do the job, albeit a bit slower. However, if performance seems to be a bottleneck, it might pay off to switch to the newer library.

I'm starting a new project, should I go with Newtonsoft, or System?
> System.Text.Json is promoted as the new default library when it comes to JSON. Microsoft is actively maintaining and improving System.Text.Json and therefore its missing features and differences compared to Newtonsoft are less and less bothering.
Developer proficiency of Newtonsoft is also important. If you're comfortable with API's of the older library then it's absolutely fine to stick with it.

## Takeaways:
- Do not mix different serializers in your solution. Choose either one of the libraries and go with it, otherwise you'll be in for major problems and confusion.
- 