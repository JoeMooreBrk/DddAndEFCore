using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace App
{
    public class Email : ValueObject
    {
        public string Value { get; }
        private Email(string value)
        {
            Value = value;
        }
        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return Result.Failure<Email>("Email cannot be empty");
            email = email.Trim();
            if (email.Length > 200) return Result.Failure<Email>($"Email is too long: {email.Length}");
            if (!Regex.IsMatch(email, @"^(.+)@(.+)$"))
                return Result.Failure<Email>($"Email is invalid: {email}");
            return Result.Success(new Email(email));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static implicit operator string(Email email) => email.Value;
    }
}
