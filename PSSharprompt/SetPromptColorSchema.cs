using Sharprompt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PSSharprompt;

/// <summary>
/// Sets the color for the given schema.
/// </summary>
[Cmdlet(VerbsCommon.Set, "PromptColorSchema")]
public class SetPromptColorSchema : PSCmdlet
{
    /// <summary>
    /// The schema to set the color for.
    /// </summary>
    [Parameter(Mandatory = true, Position = 0)]
    [ValidateSet("DoneSymbol", "PromptSymbol", "Answer", "Select", "Error", "Hint", "DisabledOption")]
    public required string Schema { get; set; }

    /// <summary>
    /// The color to set, must be a valid ConsoleColor.
    /// </summary>
    [Parameter(Mandatory = true, Position = 1)]
    [ValidateSet("Red", "Yellow", "Green", "Cyan", "Blue", "Magenta", "White", "Gray", "DarkGray", "DarkBlue", "DarkCyan", "DarkGreen", "DarkMagenta", "DarkRed", "Black")]
    public required string Color { get; set; }

    protected override void ProcessRecord()
    {
        switch (Schema)
        {
            case nameof(Prompt.ColorSchema.DoneSymbol):
                Prompt.ColorSchema.DoneSymbol = Enum.Parse<ConsoleColor>(Color);
                break;
            case nameof(Prompt.ColorSchema.PromptSymbol):
                Prompt.ColorSchema.PromptSymbol = Enum.Parse<ConsoleColor>(Color);
                break;
            case nameof(Prompt.ColorSchema.Answer):
                Prompt.ColorSchema.Answer = Enum.Parse<ConsoleColor>(Color);
                break;
            case nameof(Prompt.ColorSchema.Select):
                Prompt.ColorSchema.Select = Enum.Parse<ConsoleColor>(Color);
                break;
            case nameof(Prompt.ColorSchema.Error):
                Prompt.ColorSchema.Error = Enum.Parse<ConsoleColor>(Color);
                break;
            case nameof(Prompt.ColorSchema.Hint):
                Prompt.ColorSchema.Hint = Enum.Parse<ConsoleColor>(Color);
                break;
            case nameof(Prompt.ColorSchema.DisabledOption):
                Prompt.ColorSchema.DisabledOption = Enum.Parse<ConsoleColor>(Color);
                break;
        }
    }
}
