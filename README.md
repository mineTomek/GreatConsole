# ConsoleUtilities

NuGet package for various console utilities

Newest version is `1.1.2`

## What does it do

### Colored Text

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
- `&b'` - Blue
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

### Single-choice and multi-choice menus

Menus allow user to choose from a bunch of options (`GreatConsole.MenuOption`). Each options consists of a name (`string`) and a value (`object?` it's by default null). \
Constructor of a menu takes the prompt and an array of options. It doesn't appear when the constructor is called and you have to run the `Show()` method on the menu. \
The `Show()` method has two optional parameters:

- `startIndex` changes which option is selected by default when shown (default is `0`)
- `allowEscape` changes whether the user can press the Escape key to exit the menu and return `-1` for single-choice menu and an empty `List<int>` for multi-choice menus (default is `true`)

There are two types of menus: single-choice and multi-choice.

Single-choice allows user to use arrow keys to select one of the options and press the Enter key to choose it. \
For single-choice menu use this code:

```csharp
using static GreatConsole.ConsoleColors.AllowedColor;
using GreatConsole;

MenuOption[] options = new MenuOption[] {
    new MenuOption("Option 1", 1),
    new MenuOption("Option 2", "second option", DarkGreen, Green),
    new MenuOption("Option 3", new object[] { "option", "number", 3 }, Cyan, Yellow),
};

ConsoleMenu menu = new ConsoleMenu("Choose option: ", options);

int index = menu.Show(allowEscape: false);

ConsoleColors.WriteLine($"Selected Index: {index}, Selected Option Name: {options[index].name}, Chosen Option Value: {options[index].value}", Green);
```

Multi-choice allows the user to select multiple options. The option is added to the selection using the Space key and the interaction is ended with the Enter key. \
And for multi-choice menu use this:

```csharp
using static GreatConsole.ConsoleColors.AllowedColor;
using GreatConsole;

MenuOption[] options = new MenuOption[] {
    new MenuOption("Option 1"), // It's by default null
    new MenuOption("Option 2", 2, DarkGreen, Green),
    new MenuOption("Option 3", new string[] { "this", "can", "be", "anything" }, Cyan, Yellow),
};

ConsoleMultichoiceMenu menu = new ConsoleMultichoiceMenu("Choose option: ", options);

List<int> chosenOptions = menu.Show(allowEscape: false);

foreach (int option in chosenOptions)
{
    ConsoleColors.WriteLine($"Chosen Index: {option}, Chosen Option Name: {options[option].name}, Chosen Option Value: {options[option].value}", Green);
}
```

> [!TIP]
> You can put the option array directly in menu's constructor and get it later using the `GetMenuOptions()` method in the menu instance, which works for both menu types.

### Progress Bars

Last functionality of this package is progress bars.

After using the constructor, same as with the menus, it won't actually appear until you invoke the `Show()` method. This method writes the progress bar initially then you can update the progress bar using the `Update()` method. It takes a float percentage (`0.5f` for 50%, `0.35f` for 35% and so on). \

> [!IMPORTANT]
> You can't write anything between the invoking `Show()` and each invoking of `Update()`, as the the `Update()` method relies on the cursor being on the end of the progress bar.

```csharp
using GreatConsole;

ConsoleProgressBar bar = new ConsoleProgressBar();

bar.Show();

for (int i = 0; i <= 20; i++) {
    bar.Update(i/20f);

    Thread.Sleep(100);
}
```

This example code will show a progress bar and update every 100 milliseconds until it reaches 100% after 2.1 seconds.

The 'f' after the '20' is important because it makes the division return float values instead of rounding to an integer.

## How to install it

You have two options:

- Go to [NuGet page](https://nuget.org/packages/GreatConsole) of this project and download it.
- In Visual Studio's menu bar go to `Project >> Manage NuGet Packages` and find this package.
