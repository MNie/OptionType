﻿namespace Option.Validation
{
    using System.Collections.Generic;
    using System.Linq;

    public static class RulesExtension
    {
        public static IEnumerable<IOption<TError>> Apply<TError>(this IEnumerable<IRule<TError>> rules) =>
            rules
                .Select(x => x.Apply())
                .Where(x => x.IsSome());
    }
}