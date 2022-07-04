namespace DotNetLab1.Models
{
    internal class Credit
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public float RepaymentDurationInMonths { get; set; }
        public float PercentRate { get; set; }
    }
}
