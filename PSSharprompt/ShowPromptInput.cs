using Sharprompt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PSSharprompt
{
    /// <summary>
    /// Shows the Sharprompt input prompt.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "PromptInput")]
    [OutputType(typeof(string))]
    public class ShowPromptInput : PSCmdlet
    {
        /// <summary>
        /// The message to display to the user.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0)]
        public required string Message { get; set; }

        /// <summary>
        /// The placeholder text to display before the user enters a value.
        /// </summary>
        [Parameter(Mandatory = false)]
        public string? Placeholder { get; set; }

        /// <summary>
        /// The default value if the user does not enter a value.
        /// </summary>
        [Parameter(Mandatory = false)]
        public object? Default { get; set; }

        protected override void ProcessRecord()
        {
            var result = Prompt.Input<string>(Message,
                                              defaultValue: Default,
                                              placeholder: Placeholder);
            WriteObject(result);
        }
    }
}
