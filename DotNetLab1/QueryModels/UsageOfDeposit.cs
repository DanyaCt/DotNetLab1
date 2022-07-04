using DotNetLab1.Models;

namespace DotNetLab1.QueryModels
{
    internal class UsageOfDeposit
    {
        public Deposit Deposit { get; set; }
        public int Quantity { get; set; }
    }
}
