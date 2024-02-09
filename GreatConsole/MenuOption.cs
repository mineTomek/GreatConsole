using static GreatConsole.ConsoleColors.AllowedColor;
using static GreatConsole.ConsoleColors;

namespace GreatConsole;

public class MenuOption
{
    public string name;
    public object value;

    public AllowedColor standardColor;
    public AllowedColor selectedColor;

    public MenuOption(string _name, object _value, AllowedColor _standardColor = DarkYellow, AllowedColor _selectedColor = White)
    {
        name = _name.ToString()!;
        value = _value;

        standardColor = _standardColor;
        selectedColor = _selectedColor;
    }
}

