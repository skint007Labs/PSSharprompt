using Sharprompt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PSSharprompt;

[Cmdlet(VerbsCommon.Show, "PromptPassword")]
[OutputType(typeof(bool))]
public class ShowPromptPassword : ValidatorPSCmdlet
{
    /// <summary>
    /// The message to display to the user.
    /// </summary>
    [Parameter(Mandatory = true, Position = 0)]
    public required string Message { get; set; }

    /// <summary>
    /// The character to display in place of the user's input.
    /// </summary>
    [Parameter(Mandatory = false)]
    public string PasswordChar { get; set; } = "*";

    /// <summary>
    /// The default value to select.
    /// </summary>
    [Parameter(Mandatory = false)]
    public string? Default { get; set; }

    /// <summary>
    /// The placeholder text to display before the user enters a value.
    /// </summary>
    [Parameter(Mandatory = false)]
    public string? PlaceHolder { get; set; }

    protected override void ProcessRecord()
    {
        Console.OutputEncoding = Encoding.UTF8;
        // Build validators from parameters
        var validators = BuildValidators();

        var result = Prompt.Password(Message,
                                     PasswordChar,
                                     placeholder: PlaceHolder,
                                     validators: validators);
        WriteObject(result);
    }
}
