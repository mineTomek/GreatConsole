using static GreatConsole.ConsoleColors.AllowedColor;
using static GreatConsole.ConsoleColors;

namespace GreatConsole;

public class ConsoleMenu
{
    readonly AllowedColor arrowColor;

    readonly MenuOption[] options;

    readonly string message;

    public ConsoleMenu(string _message, MenuOption[] _options, AllowedColor _arrowColor = Yellow)
    {
        arrowColor = _arrowColor;
        options = _options;
        message = _message;
    }

    public (int, string) Show(int startIndex = 0)
    {
        bool selected = false;

        int selectedIndex = startIndex;

        while (!selected)
        {
            Clear();

            WriteLine(message);

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Write("\t> ", arrowColor);
                    WriteLine(options[i].name, options[i].selectedColor);
                } else
                {
                    Write("\t  ");
                    WriteLine(options[i].name, options[i].standardColor);
                }
            }

            ConsoleKey key = ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex--;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex++;
                    break;
                case ConsoleKey.Enter:
                    return (selectedIndex, options[selectedIndex].name);
                case ConsoleKey.Escape:
                    return (-1, string.Empty);
                default:
                    break;
            }

            if (selectedIndex < 0)
            {
                selectedIndex = options.Length - 1;
            } else if (selectedIndex >= options.Length)
            {
                selectedIndex = 0;
            }
        }

        NewLine();

        return (selectedIndex, options[selectedIndex].name);
    }

    public class MenuOption
    {
        public string name;
        public AllowedColor standardColor;
        public AllowedColor selectedColor;

        public MenuOption(object _name, AllowedColor _standardColor = Gray, AllowedColor _selectedColor = White)
        {
            name = _name.ToString()!;
            standardColor = _standardColor;
            selectedColor = _selectedColor;
        }
    }
}
