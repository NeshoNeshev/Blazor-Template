# Blazor WebAssembly Asp Net Hosted Template

A ready-to-use template for Blazor with services, models mapping and  DI.
## Framework  and Language version
-	Dot Net 6.0
-	C# 10

## Author

- [Nesho Neshev]( https://github.com/NeshoNeshev)

## Project Overview

![Dependencies Graph](https://github.com/NeshoNeshev/BlazorWebAssembly-Template/blob/master/.github/Diagram.png)
![image](https://github.com/NeshoNeshev/BlazorWebAssembly-Template/blob/master/.github/Project%20SnapShot.png)

### Common

** BlazorWebAssembly.Common** contains common things for the project solution. For example:

- [GlobalConstants.cs](https://github.com/NeshoNeshev/BlazorWebAssembly-Template/blob/master/BlazorWebAssembly.Common/GlobalConstants.cs).

### Data

This solution folder contains two subfolders:

- BlazorWebAssembly.Data
- BlazorWebAssembly.Data.Models

#### BlazorWebAssembly.Data

[BlazorWebAssembly.Data](https://github.com/NeshoNeshev/BlazorWebAssembly-Template/tree/master/Data/BlazaorWebAssembly.Data) contains DbContext, Migrations and Configuraitons for the EF Core and Seeding users and roles.

#### BlazorWebAssembly.Data.Models

[BlazorWebAssembly.Data.Models](https://github.com/NeshoNeshev/BlazorWebAssembly-Template/tree/master/Data/BlazorWebAssembly.Data.Models) provides abstract generics classes and interfaces, which holds information about our entities. For example when the object is Created, Modified, Deleted or IsDeleted. It contains a property for the primary key as well. contains Deletable Models ApplicationUser and ApplicationRole classes, which inherits IdentityRole and IdentityUsers.


### Services

This solution folder contains three subfolders:

- BlazorWebAssembly.Services
- BlazorWebAssembly.Services.Mapping
- BlazorWebAssembly.Services.Messaging

#### BlazorWebAssembly.Services

[BlazorWebAssembly.Services](https://github.com/NeshoNeshev/BlazorWebAssembly-Template/tree/master/Services/BlazaorWebAssembly.Services) wil contains service layer logic and Cloudinary service that uploads photos to Cloudinary(https://cloudinary.com/)..

#### BlazorWebAssembly.Services.Mapping

[BlazorWebAssembly.Services.Mapping](https://github.com/NeshoNeshev/BlazorWebAssembly-Template/tree/master/Services/BlazorWebAssembly.Services.Mapping) provides simplified functionlity for auto mapping. For example:

```csharp
using BlazorWebAssembly.Services.Mapping.Interfaces;
using BlazorWebAssembly.Data.Models.DemoModels;

namespace BlazorWebAssembly.Web.Shared
{
    public class DemoViewModel : IMapFrom<Demo>
    {
        public string Name { get; set; }
    }
} 
```

#### BlazorWebAssembly.Services.Messaging

[BlazorWebAssembly.Services.Messaging](https://github.com/NeshoNeshev/BlazorWebAssembly-Template/tree/master/Services/BlazorWebAssembly.Services.Messaging) a ready to use integration with [SendGrid](https://sendgrid.com/).
### Tests

This solution folder contains three subfolders:

- BlazorWebAssembly.Test.Web
- BlazorWebAssembly.Services.Data.Tests

#### BlazorWebAssembly.Web.Tests

[BlazorWebAssembly.Test.Webs](https://github.com/NeshoNeshev/BlazorWebAssembly-Template/tree/master/Tests/BlazaorWebAssembly.Test.Web) setted up Bunit tests.

### Web

This solution folder contains three subfolders:

- BlazorWebAssembly.Web.Client
- BlazorWebAssembly.Web.Server
- BlazorWebAssembly.Web.Shared

#### BlazorWebAssembly.Web.Client

[BlazorWebAssembly.Web.Client](https://github.com/NeshoNeshev/BlazorWebAssembly-Template/tree/master/Web/BlazorWebAssembly.Web/Client) contains Blazor Client side functionality.
## Support
-	Not authenticated client to return data from controller. For Example:
```csharp
@code {

    private DemoViewModel? viewModel;

    protected override async Task OnInitializedAsync()
    {
        //This component demonstrate how to return data from controller with No Authentication Client.
        var client = ClientFactory.CreateClient("BlazorWebAssembly.Web.ServerAPI.NoAuthenticationClient");
        try
        {
            viewModel = await client.GetFromJsonAsync<DemoViewModel>("Index");
        }
        catch (AccessTokenNotAvailableException exception)
        {
            exception.Redirect();
        }
        base.OnInitialized();
    }
}
```

-	Role based authorization. For Example:

```csharp
@page "/administration"
@using BlazorWebAssembly.Web.Shared
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@using System.ComponentModel.DataAnnotations

@attribute [Authorize(Roles = "Administrator")]
@inject HttpClient Http

<PageTitle>Administration</PageTitle>

<h1 class= "text-center">Administration</h1>
<AuthorizeView Roles="Administrator">
    <Authorized>
        <h1>Hello, @context.User.Identity.Name!</h1>
        <p>You can only see this content if you're Administrator.</p>

    </Authorized>
</AuthorizeView>

<AuthorizeView Roles="Moderator">
    <Authorized>
        <h1>Hello, @context.User.Identity.Name!</h1>
        <p>You can only see this content if you're Moderator.</p>

    </Authorized>
</AuthorizeView>

@if (viewModel == null)
{
    
    <p><em>Loading...</em></p>
}
else
{   
    <h4 class = "text-center">This is response on Administration Controller => @viewModel.Name</h4>

}
<div class="card text-center">
  <div class="card-header">
   Post only is in role Administrator
  </div>
  <div class="card-body">
    
    <EditForm Model="@inputModel" OnValidSubmit="@HandleValidSubmit">
    <DataAnnotationsValidator />
    <ValidationSummary />

    <p>
        <label>
            Name:
            <InputText @bind-Value="inputModel.Name" />
        </label>
    </p>
    <button type="submit">Submit</button>
</EditForm>
  </div>
  <div class="card-footer text-muted">
    @DateTime.UtcNow.Date.Year
  </div>
</div>


@code {
    private DemoViewModel? viewModel;

    private DemoInputModel? inputModel;

    protected override async Task OnInitializedAsync()
    {
        inputModel = new DemoInputModel();

        try
        {
            viewModel = await Http.GetFromJsonAsync<DemoViewModel>("DemoAdministration");
        }
        catch (AccessTokenNotAvailableException exception)
        {
            exception.Redirect();
        }
    }
    private void HandleValidSubmit()
    {
        var response = Http.PostAsJsonAsync("DemoAdministration", inputModel?.Name);
    }
}
```

#### BlazorWebAssembly.Web.Server

[BlazorWebAssembly.Web.Server](https://github.com/NeshoNeshev/BlazorWebAssembly-Template/tree/master/Web/BlazorWebAssembly.Web/Server) contains controlllers, areas and server side functionality.
## Support
-	Attribute [Authorize(Roles = "Administrator")] For Example:

```csharp
using BlazaorWebAssembly.Services.Interfaces;
using BlazorWebAssembly.Web.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebAssembly.Web.Server.Controllers
{
    [Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("[controller]")]
    public class DemoAdministrationController : ControllerBase
    {
        private readonly IDemoService demoService;

        public DemoAdministrationController(IDemoService demoService)
        {
            this.demoService = demoService;
        }
        [HttpGet]
        public DemoViewModel Get()
        {
            return this.demoService.GetDemo("FirstDemo");
        }

        [HttpPost]
        public IActionResult Post([FromBody] string? name)
        {
            var demo = this.demoService.CreateDemo(name);
            if (demo != null)
            {
                return Ok(demo);
            }
            return BadRequest("Existing Demo");
        }
    }
}
```

#### BlazorWebAssembly.Web.Shared

[BlazorWebAssembly.Web.Shared](https://github.com/NeshoNeshev/BlazorWebAssembly-Template/tree/master/Web/BlazorWebAssembly.Web/Shared) contains objects, which will be mapped from/to our entities and used in the front-end/back-end..

## Support


If you are having problems, please let me know by [raising a new issue](https://github.com/NeshoNeshev/BlazorWebAssembly-Template/issues).



