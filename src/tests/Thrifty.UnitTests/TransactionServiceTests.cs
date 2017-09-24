using Microsoft.VisualStudio.TestTools.UnitTesting;
using Thrifty.Models;
using Thrifty.Services;
using FluentAssertions;

namespace Thrifty.UnitTests
{
    [TestClass]
    public class TransactionServiceTests
    {
        [TestMethod]
        public void ValidateTransactionShouldReturnTrueForValidTransaction()
        {
            // Arrange
            var transaction = new Transaction
            {
                Legs = new[]
                {
                    new TransactionLeg { IsDebit = true, Amount = 10.5M },
                    new TransactionLeg { IsDebit = false, Amount = 10.5M }
                }
            };

            var transactionService = new TransactionService(null);

            // Act
            var result = transactionService.ValidateTransaction(transaction);

            //Assert
            result.Should().BeTrue("because balanced debit and credit leg should be a valid transaction");
        }

        [TestMethod]
        public void ValidateTransactionShouldReturnFalseForInvalidTransaction()
        {
            // Arrange
            var transaction = new Transaction
            {
                Legs = new[]
                {
                    new TransactionLeg { IsDebit = true, Amount = 10.505M },
                    new TransactionLeg { IsDebit = false, Amount = 10.506M }
                }
            };

            var transactionService = new TransactionService(null);

            // Act
            var result = transactionService.ValidateTransaction(transaction);

            //Assert
            result.Should().BeFalse("because unbalanced debit and credit leg should not be a valid transaction");
        }
    }
}
