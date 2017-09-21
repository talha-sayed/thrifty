using Microsoft.VisualStudio.TestTools.UnitTesting;
using Thrifty.Models;
using Thrifty.Services;

namespace Thrifty.UnitTests
{
    [TestClass]
    public class TransactionServiceTest
    {
        [TestMethod]
        public void CheckValidTransaction()
        {
            // Arrange
            var transaction = new Transaction()
            {
                Legs = new[]
                {
                    new TransactionLeg { IsDebit = true, Amount = 10.5M },
                    new TransactionLeg { IsDebit = false, Amount = 10.5M },
                }
            };

            var transactionService = new TransactionService();

            // Act
            var result = transactionService.ValidateTransaction(transaction);

            //Assert
            Assert.IsTrue(result, "Test valid transaction returned false for a valid transaction");
        }
    }
}
