# PSSharprompt

[![GitHub version](https://badge.fury.io/gh/skint007Labs%2FPSSharprompt.svg)](https://badge.fury.io/gh/skint007Labs%2FPSSharprompt)
![Static Badge](https://img.shields.io/badge/PS-v1.2.0-blue?style=flat&logo=powershell&logoColor=white&link=https%3A%2F%2Fwww.powershellgallery.com%2Fpackages%2FPSSharprompt)

## About
This is a simple wrapper for the great [Sharprompt](https://github.com/shibayan/Sharprompt) library to make it easier to use in PowerShell.

This is still a work in progress and not all features are supported yet.

## Installation
Install the module from the PowerShell Gallery
```powershell
Install-Module -Name PSSharprompt
```

You can also install the module from the GitHub repository by downloading the latest release.

*Note: You will need to include the Sharprompt.dll in the same directory as the module dll.*
```powershell
Import-Module .\PSSharprompt.dll
```

## Supported Features from Sharprompt
### Basic Input

- Show-PromptInput
- Show-PromptPassword
- Show-PromptConfirm
- Show-PromptSelect
- Show-PromptMultiSelect

### Schema settings
- Set-PromptColorSchema
- Set-PromptSymbol

## Validation Support
The following functions support validation:
- Show-PromptInput
- Show-PromptList
- Show-PromptPassword

You can use the following parameters to validate the input:
```powershell
[switch] -Required
   [int] -MinLength
   [int] -MaxLength
[string] -RegularExpression
```

When not supplied, they have the same defaults as Sharprompt.

### Examples

Make sure to import the module first
```powershell
Import-Module PSSharprompt
```

#### Show-PromptInput
```powershell
$Name = Show-PromptInput -Message 'What is your name?' -Default 'John Doe'
"Hello, $Name!"
```

#### Show-PromptPassword
```powershell
$Password = Show-PromptPassword -Message 'Enter your password'
"Your password is valid!"
```

```powershell
$Password = Show-PromptPassword -Message 'Enter your password' -Required -MinLength 8 -MaxLength 16 -RegularExpression '^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&\._\-\(\)]+$'
"Your password is valid!"
```

#### Show-PromptConfirm
```powershell
$Confirm = Show-PromptConfirm -Message 'Are you sure?' -Default $false
"They said: $Confirm"
```

#### Show-PromptSelect
```powershell
$Selected = Show-PromptSelect -Message 'Select your favorite color' -Items 'Red', 'Green', 'Blue'
$Selected
```

#### Show-PromptMultiSelect
```powershell
$Selected = Show-PromptMultiSelect -Message 'Select your favorite colors' -Items 'Red', 'Green', 'Blue'
$Selected -join ', '
```

