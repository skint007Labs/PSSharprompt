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
    /// Shows the Sharprompt list prompt.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "PromptList")]
    [OutputType(typeof(string[]))]
    public class ShowPromptList : PSCmdlet
    {
        /// <summary>
        /// The message to display to the user.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0)]
        public required string Message { get; set; }

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


        protected override void ProcessRecord()
        {
            var result = Prompt.List<string>(Message, Minimum, Maximum);
            WriteObject(result);
        }
    }
}
