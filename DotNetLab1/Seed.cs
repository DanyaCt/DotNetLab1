using System;
using System.Collections.Generic;
using DotNetLab1.Models;

namespace DotNetLab1
{
    internal class Seed
    {
        public static List<Client> Clients =>
            new()
            {
                new Client
                {
                    Id = 1,
                    FullName = "Semenuk Daniil Volodimirovich",
                    PhoneNumber = "+380529625378",
                    RegistrationCode = "1111111111"
                },
                new Client
                {
                    Id = 2,
                    FullName = "Stankov Artem Vitaliyovich",
                    PhoneNumber = "+380542256956",
                    RegistrationCode = "1234567890"
                },
                new Client
                {
                    Id = 3,
                    FullName = "Vinnyk Vitaliy Vadymovich",
                    PhoneNumber = "+380554545455",
                    RegistrationCode = "0987654321"
                },
                new Client
                {
                    Id = 4,
                    FullName = "Zozuluk Viktor Olehovich",
                    PhoneNumber = "+380554545455",
                    RegistrationCode = "0987654321"
                }

            };

        public static List<Currency> Currencies =>
            new()
            {
                new Currency
                {
                    Id = 1,
                    Name = "UAH"
                },
                new Currency
                {
                    Id = 2,
                    Name = "USD"
                },
                new Currency
                {
                    Id = 3,
                    Name = "TRY"
                }
            };

        public static List<Credit> Credits =>
            new()
            {
                new Credit
                {
                    Id = 1,
                    CurrencyId = 1,
                    PercentRate = 5,
                    RepaymentDurationInMonths = 10
                },
                new Credit
                {
                    Id = 2,
                    CurrencyId = 3,
                    PercentRate = 0.5f,
                    RepaymentDurationInMonths = 12
                },
                new Credit
                {
                    Id = 3,
                    CurrencyId = 2,
                    PercentRate = 15,
                    RepaymentDurationInMonths = 3
                }
            };
        public static List<Deposit> Deposits =>
            new()
            {
                new Deposit
                {
                    Id = 1,
                    CurrencyId = 1,
                    DurationInMonths = 12,
                    MinimalInvestment = 1000,
                    PercentRate = 1
                },
                new Deposit
                {
                    Id = 2,
                    CurrencyId = 2,
                    DurationInMonths = 24,
                    MinimalInvestment = 500,
                    PercentRate = 1.5f
                },
                new Deposit
                {
                    Id = 3,
                    CurrencyId = 3,
                    DurationInMonths = 24,
                    MinimalInvestment = 50000,
                    PercentRate = 5
                },
                new Deposit
                {
                    Id = 4,
                    CurrencyId = 1,
                    DurationInMonths = 6,
                    MinimalInvestment = 2500,
                    PercentRate = 10
                }
            };

        public static List<ClientToCredit> ClientsToCredits => new()
        {
            new ClientToCredit
            {
                ClientId = 1,
                CreditId = 3,
                AmountOfMoneyTaken = 100000,
                DateOfIssue = Convert.ToDateTime("10.12.2021"),
                DateOfRepayment = Convert.ToDateTime("10.03.2022")
            },
            new ClientToCredit
            {
                ClientId = 1,
                CreditId = 3,
                AmountOfMoneyTaken = 25000,
                DateOfIssue = Convert.ToDateTime("03.07.2022"),
                DateOfRepayment = null
            },
            new ClientToCredit
            {
                ClientId = 3,
                CreditId = 2,
                AmountOfMoneyTaken = 2000000,
                DateOfIssue = Convert.ToDateTime("10.05.2022"),
                DateOfRepayment = Convert.ToDateTime("14.06.2022")
            }
        };
        public static List<ClientToDeposit> ClientsToDeposits => new()
        {
            new ClientToDeposit
            {
                ClientId = 1,
                DepositId = 1,
                AccountNumber = "12345",
                AmountOfMoneyToDeposit = 5000,
                DateOfBeginning = Convert.ToDateTime("03.07.2021"),
                DateOfEnding = Convert.ToDateTime("03.07.2022")
            },
            new ClientToDeposit
            {
                ClientId = 1,
                DepositId = 3,
                AccountNumber = "12345",
                AmountOfMoneyToDeposit = 50000,
                DateOfBeginning = Convert.ToDateTime("10.05.2022"),
                DateOfEnding = null
            },
            new ClientToDeposit
            {
                ClientId = 1,
                DepositId = 2,
                AccountNumber = "24680",
                AmountOfMoneyToDeposit = 2000,
                DateOfBeginning = Convert.ToDateTime("11.06.2022"),
                DateOfEnding = null
            },
            new ClientToDeposit
            {
                ClientId = 2,
                DepositId = 2,
                AccountNumber = "10101",
                AmountOfMoneyToDeposit = 500,
                DateOfBeginning = Convert.ToDateTime("01.10.2021"),
                DateOfEnding = Convert.ToDateTime("12.05.2022")
            }
        };
    }
}
