using System;
using System.Linq;

namespace Web.DAL.Validators
{
    public static class ValidationExtensions
    {
        public static bool Validate<TInput>(this TInput @this, params Func<TInput, bool>[] predicates) => predicates.All(x => x(@this));
    }
}