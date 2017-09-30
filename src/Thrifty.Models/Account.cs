using System;

namespace Thrifty.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
