using System;

namespace DotNetLab1.Models
{
    internal class Deposit
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public float DurationInMonths { get; set; }
        public decimal MinimalInvestment { get; set; }
        public float PercentRate { get; set; }
        public override bool Equals(object? obj)
        {
            var other = obj as Deposit;
            return Id == other.Id && CurrencyId == other.CurrencyId
                                  && DurationInMonths.Equals(other.DurationInMonths)
                                  && MinimalInvestment == other.MinimalInvestment
                                  && PercentRate.Equals(other.PercentRate);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CurrencyId, DurationInMonths, MinimalInvestment, PercentRate);
        }
    }
}
