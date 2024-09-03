using Sharprompt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PSSharprompt;

/// <summary>
/// Shows the Sharprompt multi-select prompt.
/// </summary>
[Cmdlet(VerbsCommon.Show, "PromptMultiSelect")]
[OutputType(typeof(string[]))]
public class ShowPromptMultiSelect : PSCmdlet
{
    /// <summary>
    /// The message to display to the user.
    /// </summary>
    [Parameter(Mandatory = true, Position = 0)]
    public string Message { get; set; }

    /// <summary>
    /// The items to display to the user.
    /// </summary>
    [Parameter(Mandatory = true)]
    public string[] Items { get; set; }

    /// <summary>
    /// The number of items to display per page.
    /// </summary>
    [Parameter(Mandatory = false)]
    public int? PageSize { get; set; }

    /// <summary>
    /// Minimum number of items that must be selected.
    /// </summary>
    [Parameter(Mandatory = false)]
    public int Minimum { get; set; } = 1;

    /// <summary>
    /// Maximum number of items that may be selected.
    /// </summary>
    [Parameter(Mandatory = false)]
    public int Maximum { get; set; } = int.MaxValue;

    /// <summary>
    /// The default values to select.
    /// </summary>
    [Parameter(Mandatory = false)]
    public object[]? Defaults { get; set; }

    protected override void ProcessRecord()
    {
        Console.OutputEncoding = Encoding.UTF8;
        var result = Prompt.MultiSelect(Message,
                                        Items,
                                        minimum: Minimum,
                                        maximum: Maximum,
                                        defaultValues: Defaults,
                                        pageSize: PageSize);
        WriteObject(result);
    }
}
