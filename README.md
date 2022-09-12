# ConsoleUtilities

NuGet package for various console utilities


## What does it do

With this package it is easy to change colors of printed text:

```csharp
using Console = ConsoleUtilities.ConsoleColors; // You can transform all your apps
                                                // by replacing "System.Console" with "ConsoleColors" class.
                                                // And everything will still work!
                                                
using static ConsoleUtilities.ConsoleColors.AllowedColor; // Don't type 
                                                          // "ConsoleUtilities.ConsoleColors.AllowedColor"
                                                          // all the time.
                                                          
Console.WriteLine("Hello World!", Green); // It will pring "Hello World!" in green
```

Don't want whole line to be same color?

We got you covered!

```csharp
using Console = ConsoleUtilities.ConsoleColors;

Console.WriteFromString("&b'Hello &r'World&g!"); // This code will print blue (&b') "Hello",
                                                 // red (&r') "World" and green (&g') "!".
```

There are _"color stamps"_ helping you in your work:
 - `&'` / `&w'` - White
 - `&bl'` - Black
 - `&b'` - BLue
 - `&c'` - Cyan
 - `&db'` - Dark Blue
 - `&dc'` - Dark Cyan
 - `&dgr'` - Dark Gray
 - `&dg'` - Dark Green
 - `&dm'` - Dark Magenta
 - `&dr'` - Dark Red
 - `&dy'` - Dark Yellow
 - `&gr'` - Gray
 - `&g'` - Green
 - `&m'` - Magenta
 - `&r'` - Red
 - `&y'` - Yellow

## How to install it

You have two options:

- Go to [NuGet page](https://nuget.org/packages/GreatConsole) of this project and download it.
- In Visual Studio's menu bar go to `Project >> Manage NuGet Packages` and find this package.