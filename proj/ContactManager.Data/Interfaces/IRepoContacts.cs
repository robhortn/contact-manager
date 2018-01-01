using System.Linq;
using ContactManager.Data.Models;

namespace ContactManager.Data.Interfaces
{
    public interface IRepoContacts
    {
        IQueryable<Contact> GetContacts { get; }
    }
}
