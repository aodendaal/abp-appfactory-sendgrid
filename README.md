# Abp.AppFactory.SendGrid

To send an email with SendGrid in an aspnetboilerplate project follow the steps below

## 1. Add SendGridModule as a Dependency

In your WebCoreModule add SendGridModule as a dependency like below:

```cs
    [DependsOn(
        ...,
        typeof(SendGridModule)
     )]
    public class ExampleWebCoreModule : AbpModule
    {
        ...
    }
```

## 2. Add Interfaces reference to project

In the project you wish to use SendGrid in, add a reference to *1.4.0 or later* [Abp.AppFactory.Interface Nuget Package](https://www.nuget.org/packages/Abp.AppFactory.Interfaces).

## 3. Get API Key from SendGrid Account

* Create or login to your SendGrid Account.

* Create and copy your API key [here](https://app.sendgrid.com/settings/api_keys).

## 4. Add SendGrid API Key to config

Add the following to your `appsettings.json`:

```json
    ...
    "SendGrid": {
      "Key": "YOUR_SENDGRID_KEY_HERE"
    }
```
  
## 5. Implement ISendGridEmail

Add a class to your solution implementing the ISendGrid interface:

```cs
    public class Email : ISendGridEmail
    {
        ...
    }
```

## 6. Inject SendGrid into your service

Inject the SendGrid provider class into your service with ISendGrid:

```cs
    private readonly ISendGrid sendGrid;

    public ExampleService(..., ISendGrid sendGrid)
    {
        ...
        this.sendGrid = sendGrid;
    }
```

## 7. Send an email 

```cs
    var response = await sendGrid.SendAsync(new Email()
    {
        SenderName = "Billy",
        SenderEmailAddress = "Billy@email.com",
        SubjectContent = "Hello",
        BodyTextContent = "Hello World",
        RecepientName = "Ken",
        RecepientEmailAddress = "Ken@email.com"
    });
```

# Done!
