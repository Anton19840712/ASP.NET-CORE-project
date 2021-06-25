using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web.DAL.Validators;

namespace Web.Bussiness.Models.UserModels
{

    public class EditUserModel
    {
        public readonly List<Action<EditUser>> Actions = new List<Action<EditUser>>();

        public EditUserModel HasId(string id)
        {
            Actions.Add(p => { p.Id = id; });
            return this;
        }

        public EditUserModel Called(string name)
        {
            Actions.Add(p => { p.Name = name; });
            return this;
        }

        public EditUserModel HasEmail(string email)
        {
            Actions.Add(p => { p.Email = email; });
            return this;
        }

        public EditUserModel HasPassword(string password)
        {
            Actions.Add(p => { p.Password = password; });
            return this;
        }

        public EditUserModel SetPhone(string phone)
        {
            var isPhoneValid = IsPhoneNumberValid(phone);

            if (!isPhoneValid)
            {
                return null;
            }

            Actions.Add(p => { p.Phone = phone; });

            return this;
        }

        public EditUser Build()
        {
            var p = new EditUser();
            Actions.ForEach(a => a(p));
            return p;
        }

        public bool IsPhoneNumberValid(string number) => number.Validate(_mustMatchPhoneValidationRule);


        private readonly Func<string, bool> _mustMatchPhoneValidationRule = x => new Regex(@"^(\+[0-9]{9})$").IsMatch(x.Substring(0, 1));
    }

    public static class EditUserModelBuilderExtensions
    {
        public static EditUserModel SetEmail(this EditUserModel builder, string email)
        {
            builder.Actions.Add(p => { p.Email = email; });
            return builder;
        }
    }
}