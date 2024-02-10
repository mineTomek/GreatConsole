using static GreatConsole.ConsoleColors.AllowedColor;
using static GreatConsole.ConsoleColors;

namespace GreatConsole;

public class ConsoleProgressBar
{
    readonly AllowedColor completedColor;

    readonly AllowedColor uncompletedColor;

    private bool showPercentageText;
    private int consoleWidth;

    public ConsoleProgressBar(AllowedColor completedColor = White, AllowedColor uncompletedColor = DarkGray, bool showPercentageText = true)
    {
        this.completedColor = completedColor;
        this.uncompletedColor = uncompletedColor;

        this.showPercentageText = showPercentageText;

        consoleWidth = Console.WindowWidth;
    }

    public void Show(float startValue = 0)
    {
        WriteProgressBar(startValue);
    }

    public void Update(float percentage)
    {
        Write("\r");

        WriteProgressBar(percentage);
    }

    void WriteProgressBar(float percentage)
    {
        var progressBar = CreateProgressBar(percentage, showPercentageText ? consoleWidth - 6 : consoleWidth - 2);

        Write("|", Cyan);

        Write(progressBar.Item1, completedColor);

        Write(progressBar.Item2, uncompletedColor);

        Write("|", Cyan);

        if (showPercentageText)
        {
            Write(CreatePercentageText(percentage));
        }
    }

    string CreatePercentageText(float percentage)
    {
        int percent = (int)Math.Round(percentage * 100);

        return $"{new string(' ', -percent.ToString().Length + 3)}{percent}%";

    }

    static (string, string) CreateProgressBar(float percentage, int availableColumns, char filledChar = '█', char emptyChar = '░')
    {
        int filledColumns = (int)Math.Round(availableColumns * percentage);

        return (new string(filledChar, filledColumns), new string(emptyChar, availableColumns - filledColumns));
    }
}

