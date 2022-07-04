using System;

namespace DotNetLab1.Models
{
    internal class ClientToDeposit
    {
        public int ClientId { get; set; }
        public int DepositId { get; set; }
        public string AccountNumber { get; set; }
        public DateTimeOffset DateOfBeginning { get; set; }
        public DateTimeOffset? DateOfEnding { get; set; }
        public decimal AmountOfMoneyToDeposit { get; set; }
    }
}
