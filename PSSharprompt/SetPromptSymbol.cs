using Sharprompt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PSSharprompt;

/// <summary>
/// Sets the given Sharprompt symbol.
/// </summary>
[Cmdlet(VerbsCommon.Set, "PromptSymbol")]
public class SetPromptSymbol : PSCmdlet
{
    /// <summary>
    /// The symbol to set.
    /// </summary>
    [Parameter(Mandatory = true, Position = 0)]
    [ValidateSet("Prompt", "Done", "Error", "Selector", "Selected", "NotSelect")]
    public required string Symbol { get; set; }

    /// <summary>
    /// The value to set the symbol to.
    /// </summary>
    [Parameter(Mandatory = true)]
    public required string Value { get; set; }

    /// <summary>
    /// The fallback value to set the symbol to.
    /// </summary>
    [Parameter(Mandatory = true)]
    public required string FallBackValue { get; set; }

    protected override void ProcessRecord()
    {
        switch (Symbol)
        {
            case nameof(Prompt.Symbols.Prompt):
                Prompt.Symbols.Prompt = new(Value, FallBackValue);
                break;
            case nameof(Prompt.Symbols.Done):
                Prompt.Symbols.Done = new(Value, FallBackValue);
                break;
            case nameof(Prompt.Symbols.Error):
                Prompt.Symbols.Error = new(Value, FallBackValue);
                break;
            case nameof(Prompt.Symbols.Selector):
                Prompt.Symbols.Selector = new(Value, FallBackValue);
                break;
            case nameof(Prompt.Symbols.Selected):
                Prompt.Symbols.Selected = new(Value, FallBackValue);
                break;
            case nameof(Prompt.Symbols.NotSelect):
                Prompt.Symbols.NotSelect = new(Value, FallBackValue);
                break;
        }
    }
}
