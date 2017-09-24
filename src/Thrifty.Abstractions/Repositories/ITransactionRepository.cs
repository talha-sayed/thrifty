using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Thrifty.Models;

namespace Thrifty.Abstractions
{
    public interface ITransactionRepository
    {
        Task Create(Transaction transaction);
    }
}
