using System.Web.Http;
using ContactManager.Data;

namespace ContactManager.api
{
    public abstract class BaseController : ApiController
    {
        public enum ResponseTypes {
            BadRequest,
            NotFound
        }

        protected RepoCompanies _repoCompanies = new RepoCompanies();
        protected RepoContacts _repoContacts = new RepoContacts();
        protected RepoLookups _repoLookups = new RepoLookups();

        protected IHttpActionResult BuildResponse(string msg, ResponseTypes rtype) {
            switch (rtype)
            {
                case ResponseTypes.BadRequest:
                    return BadRequest("ERROR: " + msg);
                case ResponseTypes.NotFound:
                    return Ok(msg);
                default:
                    return BadRequest("ERROR: An unknown exception has occured.");
            }
        }
    }
}

