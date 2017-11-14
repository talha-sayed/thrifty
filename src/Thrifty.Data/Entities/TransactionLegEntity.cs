using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thrifty.Data.Entities
{
    public class TransactionLegEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public int TransactionId { get; set; }

        public TransactionEntity Transaction { get; set; }

        public DateTime Timestamp { get; set; }

        public string AccountKey { get; set; }
    }
}
