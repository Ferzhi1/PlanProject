using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Plan.HospitalGaragoa.Domain.ValueObjects
{
    public sealed class PhoneNumber
    {
        private static readonly Regex PhoneRegex = new(@"^\+?[0-9\s\-]{7,20}$", RegexOptions.Compiled);
        public string Value { get; }

        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Phone number is required");
            value = value.Trim();
            if (!PhoneRegex.IsMatch(value)) throw new ArgumentException("Invalid phone number format");
            Value = value;
        }

        public override string ToString() => Value;
        public override bool Equals(object obj) => obj is PhoneNumber other && Value == other.Value;
        public override int GetHashCode() => Value.GetHashCode();
    }
}
