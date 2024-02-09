using static GreatConsole.ConsoleColors.AllowedColor;
using static GreatConsole.ConsoleColors;

namespace GreatConsole;

public class MenuOption
{
    public string name;
    public AllowedColor standardColor;
    public AllowedColor selectedColor;

    public MenuOption(object _name, AllowedColor _standardColor = DarkYellow, AllowedColor _selectedColor = White)
    {
        name = _name.ToString()!;
        standardColor = _standardColor;
        selectedColor = _selectedColor;
    }
}

