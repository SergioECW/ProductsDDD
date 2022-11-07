using System;
using Products.Core.Entities;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
