# OptionType & OptionType.Validation

* NuGet Status

    |   | OptionType | OptionType.Validation |
    |---|---|---|
    | nuget | [![NuGet](https://buildstats.info/nuget/OptionType?includePreReleases=true)](https://www.nuget.org/packages/OptionType) | [![NuGet](https://buildstats.info/nuget/OptionType.Validation?includePreReleases=true)](https://www.nuget.org/packages/OptionType.Validation) |


* Build Status
    [![Build Status](https://travis-ci.org/MNie/OptionType.svg?branch=master)](https://travis-ci.org/MNie/OptionType)

# OptionType
OptionType implementation in C#

Could be downloaded from NuGet:
```Install-Package OptionType```

# usage 

- via Option static method:

```csharp
var result = Option<string>.Some("on nie wiedzial");

var none = Option<string>.None;
```

- via `Some` extension method:

```csharp
var anotherResult = "on nie wiedzial".Some();
```

- via `Some` extension method with predicate:

```csharp
var anotherResult = "on nie wiedzial".Some(x => !string.IsNullOrWhitespace(x));
```

- via `None` extension method with predicate:

```csharp
var anotherResult = "on nie wiedzial".None(x => !string.IsNullOrWhitespace(x));
```

- via implicit cast:

```csharp
Option<string> anotherAnotherResult = "on nie wiedzial";
```

# How to check what `option` contains?

- via `IsSome` and `IsNone` properties on a `OptionType` object.

# OptionType.Validation

[OptionType.Validation](https://www.nuget.org/packages/OptionType.Validation/) package provides a simple Rule class to defines Rules which should apply to some objects and as a result returns OptionType.
Could be downloaded from NuGet:
```Install-Package OptionType.Validation```

example usage looks like this:
```csharp
var rules = new[]
{
    new Rule(() => "name".StartsWith("n"), "name"),
    new Rule(() => "dd".StartsWith("e"), "dd"),
    new Rule(() => "hh".StartsWith("a"), "hh"),
    new Rule(() => "hehe".StartsWith("h"), "hehe"),
};
var result = rules.Apply();
```
