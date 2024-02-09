using static GreatConsole.ConsoleColors.AllowedColor;
using static GreatConsole.ConsoleColors;

namespace GreatConsole;

public class ConsoleMenu
{
    readonly AllowedColor arrowColor;

    readonly MenuOption[] options;

    readonly string message;

    public ConsoleMenu(string message, MenuOption[] options, AllowedColor arrowColor = Yellow)
    {
        this.arrowColor = arrowColor;
        this.options = options;
        this.message = message;
    }

    public int Show(int startIndex = 0, bool allowEscape = true)
    {
        int selectedIndex = startIndex;

        while (true)
        {
            Clear();

            WriteLine(message);

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Write("  > ", arrowColor);
                    WriteLine(options[i].name, options[i].selectedColor);
                }
                else
                {
                    Write("    ");
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
                    return selectedIndex;
                case ConsoleKey.Escape:
                    if (allowEscape)
                    {
                        return -1;
                    }
                    break;
            }

            if (selectedIndex < 0)
            {
                selectedIndex = options.Length - 1;
            }
            else if (selectedIndex >= options.Length)
            {
                selectedIndex = 0;
            }
        }
    }
}
