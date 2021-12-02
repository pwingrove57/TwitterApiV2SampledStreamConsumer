# TwitterApiV2SampledStreamConsumer
 Contains applications for exploring the Twitter API V2 sampled stream endpoint
 
# SampledStreamConsumerConsole
This is the challenge application. It's a .NET Core 2.2 console applicationn that processes the Twitter V2 sampled stream API.  It runs in a CMD window, and reports activity and stats based on the sampled stream.  To run the application, build the solution and publish the SampledStreamConsumerConsole application to a local folder.  Then, open a CMD window, change directory to the publish folder, and run 'SampledStreamConsumerConsole.exe'

For this to work, you will need a Twitter Api Only Bearer Token.  Place this string in a file located in the specified folder with the given name:
C:\GitHub\SecretsAndStuff\Authentication.json

NOTE: This is the one hardcoded resource used by the application.

The file structure should be as follows:

{
  "Tokens": {
    "TwitterApiBearerToken": "Put Your Bearer Token Here",
  }
}

...you know what to do.

To run the application, you need to publish it to the folder structure shown here:

C:\GitHub\TwitterApiV2SampledStreamConsumer\SampledStreamConsumerConsole\Properties\PublishProfiles\FolderProfile.pubxml

As mentioned above, open a CMD window, CD to the published folder, and execute 'SampledStreamConsumerConsole.exe'. The amount of information displayed is configurable.  The possible levels are:

None: Should show only the tweet averages and related details
Normal: Should show the tweet averages, and the tweet count for each tweet
Detailed: Should show the tweet averages, as well as the tweet count and received 'ticks' for that tweet
Verbose: Should show all of the information above, plus the tweet itself.

# Tools Used
The SampledStreamConsumerConsole application was built using these tools/frameworks:
C#
Visual Studio 2017 Professional
Microsoft.Extensions.Configuration.Json(6.0.0)
Microsoft.Extensions.DependencyInjection(6.0.0)
JetBrains ReSharper Ultimate 2021.2.2
NET Core 2.2
MSTest

...there may be others, but these are the main ones

