using System.ComponentModel.DataAnnotations.Schema;

namespace Thrifty.Data.Entities
{
    public class TransactionEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
