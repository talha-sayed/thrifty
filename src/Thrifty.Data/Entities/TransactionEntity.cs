using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thrifty.Data.Entities
{
    public class TransactionEntity
    {
        public TransactionEntity()
        {
            Legs = new List<TransactionLegEntity>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Description { get; set; }

        public List<TransactionLegEntity> Legs { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
