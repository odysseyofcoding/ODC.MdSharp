# Welcome to project MdSharp

The focus of this project is to wrap Melissa® API Cloud Services and to demonstrate the implementation of this library into a .NET7 Blazor Server Project as well as a Console Application using "Microsoft.Hosting".

This is not going to be a production demo because it will not include any ui cleansing nor traffic handling services or further middlewares. In my scenario, Polly will handle as a registered service Http Exceptions.

It is dedicated to my own educational benefit and for other developers who are considering to implement a Web Service for Address Validation and those who like to build a prototype in about 10 lines of code.

# Console Example

1.  Add YourSecrets File to project and change in settings => copy to outputfolder
```csharp
MdClientService clientService;
IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();
var mdClientServiceCollection = new ServiceCollection();
```
2. Add typed client, customize Exception policies as you like
```csharp
mdClientServiceCollection.AddHttpClient("Global", client => { }).AddPolicyHandler(GetRetryPolicy());

mdClientServiceCollection.AddSingleton(provider => new MdClientService(provider.GetRequiredService<IHttpClientFactory>(), configuration["x:ApiKey"]!, CancellationToken.None));
```
3. build
```csharp
var mdClientServiceProvider = mdClientServiceCollection.BuildServiceProvider();
clientService = mdClientServiceProvider.GetRequiredService<MdClientService>();
```

4. Get your first result
```csharp
var globalExpressRequestModel = new ExpressRequest.GlobalRequestAddressModel(MdClientService.CountryISO2.DE, ExpressRequest.GlobalRequestAddressModel.ValidFormats.JSON, "Haupt") { Locality = "Berlin" };
var firstResult = await _clientService.GET_GlobalExpressAddress(globalExpressRequestModel);
```

5. Print, we are expecting General Error Code 05 from the API - No valid key
```csharp
            if (firstResult is not null)
            {
                switch (firstResult.ResultCode)
                {
                    case "GE05": await Console.Out.WriteLineAsync(firstResult.ToString()); break;
                    case "XS01": /*DO SOMETHING*/; break;
                    case "XS02": /*DO SOMETHING DIFFERENT*/; break;
                    case "XS03": /*DO SOMETHING DIFFERENT*/; break;
                    default: throw new NotImplementedException("No ResultCode catched"); // TODO: Result Code coverage 
                }
            }
```
### Output:
![grafik](https://github.com/odysseyofcoding/ODC.MdSharp/assets/74965926/bedd039e-33e8-4b07-a4c0-dbbe9bd718fa)


#

### Note: I will update it from time to time. It is a project, nobody asked for.
 
### Parts of the documentation from MelissaWiki® will be reflected in summaries to provide a smooth coding.

### Feel free to copy the code and to build your own version out of it.

### I will probably refactor the code. For example, I am considering using Interfaces instead of Generics and some other little things that could be a better practice.

If you have any questions regarding this project, contact me via the contact owner button at https://www.nuget.org/packages/Xdroid.MyFirstNuget
<br/>
<br/>

# Roadmap for MdSharp.Types
<ul>
    <li>JSON: Reflect all Cloud Service Response Types in DotNet objects</li>
    <li>JSON: Reflect all Cloud Service Request Types in DotNet objects</li>
    <li>XML:  Reflect all Cloud Service Response Types in DotNet objects</li>
    <li>XML:  Reflect all Cloud Service Request Types in DotNet objects</li>
    <li>Reflect all Resultcodes regarding Cloud services</li>
    <li>xUnit Tests</li>
</ul>
<br/>
<br/>

# Roadmap for MdSharp.MdClientService
<ul>
    <li>Reflect all Cloud Service Endpoint requests in REST and SOAP if supported for endpoint</li>
    <li>RequestStringbuilder</li>
    <li>Global Cloud Services</li>
    <li>North American Cloud Services</li>
    <li>Deserializer for XML, JSON Respones</li>
    <li>xUnit Tests</li>
</ul>
