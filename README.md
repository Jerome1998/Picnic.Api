# Picnic.Api

An unofficial C# wrapper for the [Picnic](https://picnic.app/) grocery online store.

This library is based on the Node.js library [picnic-api](https://github.com/MRVDH/picnic-api) and on the Python library [python-picnic-api](https://github.com/MikeBrink/python-picnic-api).
It is completely vibe coded based on the mentioned libraries.
This API is unofficial and is not affiliated with Picnic in any way.

## Getting Started

### 1. Install the package

```bash
dotnet add package Picnic.Api
```

### 2. Create a client

```csharp
using Picnic.Api;
using Picnic.Api.Configuration;

var client = new PicnicClient(new PicnicApiOptions
{
  CountryCode = "DE",
  ApiVersion = "15"
});
```

### 3. Login

```csharp
var login = await client.LoginAsync("your-email-or-phone", "your-password");

if (login.SecondFactorAuthenticationRequired)
{
  await client.Auth.Generate2FaCodeAsync(Picnic.Api.Models.Auth.TwoFactorChannel.EMAIL);
  // Ask the user for the code received by email/sms.
  await client.Auth.Verify2FaCodeAsync("123456");
}
```

### 4. Make your first calls

```csharp
var user = await client.User.GetUserDetailsAsync();
var results = await client.Catalog.SearchAsync("milch");
var cart = await client.Cart.GetCartAsync();
```

### 5. Optional: reuse an existing auth token

```csharp
using Picnic.Api;
using Picnic.Api.Configuration;

var client = new PicnicClient(new PicnicApiOptions
{
  AuthToken = "your-existing-auth-token",
  CountryCode = "DE"
});
```
