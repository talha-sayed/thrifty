using Microsoft.VisualStudio.TestTools.UnitTesting;
using Thrifty.Models;
using Thrifty.Services;

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
            Assert.IsTrue(result, "Method ValidateTransaction returned false for a valid transaction");
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
            Assert.IsFalse(result, "Method ValidateTransaction returned true for a invalid transaction");
        }
    }
}
