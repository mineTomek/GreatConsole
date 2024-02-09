# ConsoleUtilities

NuGet package for various console utilities


## What does it do

### With this package it is easy to change colors of printed text:

```csharp
// You can transform all your apps  by replacing "System.Console" with "ConsoleColors" class.
// And most methods will still work!
using Console = GreatConsole.ConsoleColors;

// You don't have to type "ConsoleUtilities.ConsoleColors.AllowedColor" all the time.
using static GreatConsole.ConsoleColors.AllowedColor;
                                                          
Console.WriteLine("Hello World!", Green); // It will pring "Hello World!" in green
```

Don't want whole line to be same color?

We got you covered!

```csharp
using Console = GreatConsole.ConsoleColors;

// This code will print blue (&b') "Hello", red (&r') "World" and green (&g') "!".
Console.WriteFromString("&b'Hello &r'World&g'!");
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

### You can also create easy menus:

There are two types of menus: single-choice and multi-choice.

Single-choice allows user to use arrow keys to select one of the options and press the Enter key to choose it. \
For single-choice use this code:

```csharp
using static GreatConsole.ConsoleColors.AllowedColor;
using GreatConsole;

MenuOption[] options = new MenuOption[] {
    new MenuOption("Option 1"),
    new MenuOption("Option 2", DarkGreen, Green),
    new MenuOption("Option 3", Cyan, Yellow),
};

ConsoleMenu menu = new ConsoleMenu("Choose option: ", options.ToArray());

(int selectedIndex, string selectedOption) = menu.Show(allowEscape: false);

ConsoleColors.WriteLine($"Selected Index: {selectedIndex}, Selected Option Name: {selectedOption}", Green);
```

Multi-choice allows the user to select multiple options. The option is added to the selection using the Space key and the interaction is ended with the Enter key. \
And for multi-choice use this:

```csharp
using static GreatConsole.ConsoleColors.AllowedColor;
using GreatConsole;

MenuOption[] options = new MenuOption[] {
    new MenuOption("Option 1"),
    new MenuOption("Option 2", DarkGreen, Green),
    new MenuOption("Option 3", Cyan, Yellow),
};

ConsoleMultichoiceMenu menu = new ConsoleMultichoiceMenu("Choose option: ", options.ToArray());

List<int> chosenOptions = menu.Show(allowEscape: false);

foreach (int option in chosenOptions) {
    ConsoleColors.WriteLine($"Chosen Index: {option}, Chosen Option Name: {options[option].name}", Green);
}
```

## How to install it

You have two options:

- Go to [NuGet page](https://nuget.org/packages/GreatConsole) of this project and download it.
- In Visual Studio's menu bar go to `Project >> Manage NuGet Packages` and find this package.
