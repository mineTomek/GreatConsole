using static GreatConsole.ConsoleColors.AllowedColor;
using static GreatConsole.ConsoleColors;

namespace GreatConsole;

public class ConsoleMultichoiceMenu<T>
{
    readonly AllowedColor arrowColor;

    readonly MenuOption<T>[] options;

    readonly string message;

    public ConsoleMultichoiceMenu(string _message, MenuOption<T>[] _options, AllowedColor _arrowColor = Yellow)
    {
        arrowColor = _arrowColor;
        options = _options;
        message = _message;
    }

    public List<int> Show(int startIndex = 0, bool allowEscape = true)
    {
        int pointingIndex = startIndex;

        List<int> selectedIndexes = new();

        while (true)
        {
            Clear();

            WriteLine(message);

            for (int i = 0; i < options.Length; i++)
            {
                if (i == pointingIndex)
                {
                    Write("\t> ", arrowColor);
                }
                else
                {
                    Write("\t  ");
                }

                WriteLine(options[i].name, selectedIndexes.Contains(i) ? options[i].selectedColor : options[i].standardColor);
            }

            ConsoleKey key = ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    pointingIndex--;
                    break;
                case ConsoleKey.DownArrow:
                    pointingIndex++;
                    break;
                case ConsoleKey.Spacebar:
                    if (selectedIndexes.Contains(pointingIndex))
                    {
                        selectedIndexes.Remove(pointingIndex);
                    } else
                    {
                        selectedIndexes.Add(pointingIndex);
                    }
                    break;
                case ConsoleKey.Enter:
                    return selectedIndexes;
                case ConsoleKey.Escape:
                    if (allowEscape)
                    {
                        return new List<int>();
                    }
                    break;
                default:
                    break;
            }

            if (pointingIndex < 0)
            {
                pointingIndex = options.Length - 1;
            } else if (pointingIndex >= options.Length)
            {
                pointingIndex = 0;
            }
        }
    }
}
