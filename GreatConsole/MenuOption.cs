using static GreatConsole.ConsoleColors.AllowedColor;
using static GreatConsole.ConsoleColors;

namespace GreatConsole;

public class MenuOption
{
    public string name;
    public object value;

    public AllowedColor standardColor;
    public AllowedColor selectedColor;

    public MenuOption(string name, object value, AllowedColor standardColor = DarkYellow, AllowedColor selectedColor = White)
    {
        this.name = name.ToString();
        this.value = value;

        this.standardColor = standardColor;
        this.selectedColor = selectedColor;
    }
}

