using System;

namespace DotNetLab1.QueryModels
{
    internal class ClientWithAccountNumber
    {
        public string FullName { get; set; }
        public string AccountCode { get; set; }
        public override bool Equals(object? obj)
        {
            var other = obj as ClientWithAccountNumber;
            return FullName == other.FullName && AccountCode == other.AccountCode;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(FullName, AccountCode);
        }
    }
}
