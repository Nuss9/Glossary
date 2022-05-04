# Differences between Newtonsoft.Json and System.Text.Json

For a long time, [Newtonsoft](https://www.newtonsoft.com/json) was the default library in .NET when it came to JSON serialization and deserialization. Then from .NET Core 3.0 on, we got Microsofts built-in library for JSON operations: [System.Text.Json](https://docs.microsoft.com/en-us/dotnet/api/system.text.json?view=net-6.0). So now .NET developers face another choice concerning JSON operations: *Newtonsoft* or *Microsoft*?

The reason for the newer System.Text.Json library is that its original writer - [James Newton-King]() - found that he couldn't refactor the library for increased performance. Therefore, System.Text.Json was written from scratch, this time by James **and** the .NET team. Key differences were the strict adherence to the [JSON specifications](https://datatracker.ietf.org/doc/html/rfc8259), and the implementation of asynchronous operations. These changes are fundamentally different and will cause problems when trying to upgrade from Newtonsoft to Microsoft.

Here's the official [documentation](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-migrate-from-newtonsoft-how-to?pivots=dotnet-6-0) with differences between the libraries.

## Short summary of important differences:
- System.Text is more strict compared to Newtonsoft, meaning it will result in errors more often than Newtonsoft (in favor of improved security, and adherence to the specs).
- System.Text is faster than Newtonsoft due to its asynchronous operations.
- During deserialization, System.Text is case sensitive by default, meaning it is should be faster, but could also cause more trouble.

More detailed examples can be found in [NewtonsoftVsSystemTests.cs](../Validation.Tests/NewtonsoftVsSystemTests.cs).

## FAQ: 

**Q:** *Do I need to switch from Newtonsoft.Json to System.Text.Json?*

**A:** Absolutely not. Switching will almost certainly cause issues since there are many subtle differences. Newtonsoft will still do the job, albeit a bit slower. However, if performance seems to be a bottleneck, it might pay off to switch to the newer library.

**Q:** *I'm starting a new project, should I go with Newtonsoft, or System.Text?*

**A:** System.Text.Json is promoted as the new default library when it comes to JSON. Microsoft is actively maintaining and improving System.Text.Json and therefore its missing features and differences compared to Newtonsoft are less and less bothering. Developer proficiency of Newtonsoft is also important. If you're comfortable with API's of the older library then it's absolutely fine to stick with it. And lastly, sometimes the libraries that we use have a hard dependency on either one of these. For example, [build SDK for Azure functions](https://www.nuget.org/packages/Microsoft.NET.Sdk.Functions) has a hard dependency on Newtonsoft.Json at the time of writing, which should be taken into consideration.

## Takeaways:
- Do not mix different serializers in your solution. Choose either one of the libraries and go with it, otherwise you'll be in for major problems and confusion.
- To choose a library with which you/your team are most comfortable with seems to be the best advice.
