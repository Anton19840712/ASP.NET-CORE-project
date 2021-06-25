using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using Web.DAL.Validators;

namespace Web.DAL.Models
{
    public class AppUser : IdentityUser
    {
        private readonly Func<string, bool> _mustHaveLengthOf9 = x => x.Length == 9;
        private readonly Func<string, bool> _mustStartWithAlpha = x => new Regex("[a-zA-Z]").IsMatch(x.Substring(0, 2));
        private readonly Func<string, bool> _mustHaveNext6CharsAsDigits = x => new Regex("[0-9]").IsMatch(x.Substring(2, 6));
        private readonly Func<string, bool> _mustHaveAValidLastChar = x => new Regex("[A-D]").IsMatch(x.Substring(8, 1));
        private readonly Func<string, bool> _mustHaveAValidFirstChar = x => new Regex("[^DFIQUV]").IsMatch(x.Substring(0, 1));
        private readonly Func<string, bool> _mustHaveAValidSecondChar = x => new Regex("[^DFIOQUV]").IsMatch(x.Substring(1, 1));
        
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public virtual ICollection<ProductRating> ProductRatings { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public bool IsNameValid(string name) => LastName.Replace(" ", "")
            .Validate(_mustHaveLengthOf9,
                _mustStartWithAlpha,
                _mustHaveNext6CharsAsDigits,
                _mustHaveAValidLastChar,
                _mustHaveAValidFirstChar,
                _mustHaveAValidSecondChar);
    }
}
