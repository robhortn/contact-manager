using System.Web.Http;

using System.Linq;
using ContactManager.Data;
using ContactManager.Data.Interfaces;

namespace ContactManager.api
{
    public abstract class BaseController : ApiController
    {
        protected RepoCompanies _repoCompanies = new RepoCompanies();
        protected RepoContacts _repoContacts = new RepoContacts();
        protected RepoLookups _repoLookups = new RepoLookups();
    }
}
