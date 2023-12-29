using Sharprompt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSSharprompt;

public class ValidatorBuilder
{
    public bool? Required { get; set; }
    public int? MinLength { get; set; }
    public int? MaxLength { get; set; }
    public string? RegularExpression { get; set; }

    public ValidatorBuilder SetRequired(bool? required)
    {
        Required = required;
        return this;
    }

    public ValidatorBuilder SetMinLength(int? minLength)
    {
        MinLength = minLength;
        return this;
    }

    public ValidatorBuilder SetMaxLength(int? maxLength)
    {
        MaxLength = maxLength;
        return this;
    }

    public ValidatorBuilder SetRegularExpression(string? regularExpression)
    {
        RegularExpression = regularExpression;
        return this;
    }

    public List<Func<object?, ValidationResult?>>? Build()
    {
        var validators = new List<Func<object?, ValidationResult?>>();

        if (Required.HasValue && Required.Value)
        {
            validators.Add(Validators.Required());
        }
        if (MinLength.HasValue)
        {
            validators.Add(Validators.MinLength(MinLength.Value));
        }
        if (MaxLength.HasValue)
        {
            validators.Add(Validators.MaxLength(MaxLength.Value));
        }
        if (RegularExpression is not null)
        {
            validators.Add(Validators.RegularExpression(RegularExpression));
        }

        return validators.Count != 0 ? validators : null;
    }
}
