using Sharprompt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PSSharprompt;

/// <summary>
/// Shows the Sharprompt confirm prompt.
/// </summary>
[Cmdlet(VerbsCommon.Show, "PromptConfirm")]
[OutputType(typeof(bool))]
public class ShowPromptConfirm : BasePSCmdlet
{
    /// <summary>
    /// The message to display to the user.
    /// </summary>
    [Parameter(Mandatory = true, Position = 0)]
    public required string Message { get; set; }

    /// <summary>
    /// The default value if the user does not enter a value.
    /// </summary>
    [Parameter(Mandatory = false)]
    public bool? Default { get; set; }

    protected override void ProcessRecord()
    {
        Console.OutputEncoding = Encoding.UTF8;
        var result = Prompt.Confirm(Message, Default);
        WriteObject(result);
    }
}
