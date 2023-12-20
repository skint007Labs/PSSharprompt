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
    /// Shows the Sharprompt select prompt.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "PromptSelect")]
    [OutputType(typeof(string))]
    public class ShowPromptSelect : PSCmdlet
    {
        /// <summary>
        /// The message to display to the user.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0)]
        public required string Message { get; set; }

        /// <summary>
        /// The items to display to the user.
        /// </summary>
        [Parameter(Mandatory = true)]
        public string[]? Items { get; set; }

        /// <summary>
        /// The number of items to display per page.
        /// </summary>
        [Parameter(Mandatory = false)]
        public int? PageSize { get; set; }

        /// <summary>
        /// The default value to select.
        /// </summary>
        [Parameter(Mandatory = false)]
        public object? Default { get; set; }

        protected override void ProcessRecord()
        {
            var result = Prompt.Select(Message,
                                       Items,
                                       defaultValue: Default,
                                       pageSize: PageSize);
            WriteObject(result);
        }
    }
}
