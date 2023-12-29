using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PSSharprompt;

public class ValidatorPSCmdlet : BasePSCmdlet
{
    /// <summary>
    /// Validates that the user has entered a value.
    /// </summary>
    [Parameter(Mandatory = false)]
    public SwitchParameter Required { get; set; }

    /// <summary>
    /// Validates that the user has entered a value of at least the specified length.
    /// </summary>
    [Parameter(Mandatory = false)]
    public int? MinLength { get; set; }

    /// <summary>
    /// Validates that the user has entered a value of at least the specified length.
    /// </summary>
    [Parameter(Mandatory = false)]
    public int? MaxLength { get; set; }

    /// <summary>
    /// Validates that the user has entered a value that matches the specified regular expression.
    /// </summary>
    [Parameter(Mandatory = false)]
    public string? RegularExpression { get; set; }

    public List<Func<object?, ValidationResult?>>? BuildValidators()
    {
        return new ValidatorBuilder()
            .SetRequired(Required)
            .SetMinLength(MinLength)
            .SetMaxLength(MaxLength)
            .SetRegularExpression(RegularExpression)
            .Build();
    }
}
