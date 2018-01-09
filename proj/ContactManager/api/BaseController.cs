using System;
using System.Web.Http;
using ContactManager.Data;

namespace ContactManager.api
{
    public abstract class BaseController : ApiController
    {
        public bool _isInTestMode = false;

        public enum ResponseTypes {
            BadRequest,
            DatabaseSaveFailure,
            NotFound
        }

        protected RepoCompanies _repoCompanies = new RepoCompanies();
        protected RepoContacts _repoContacts = new RepoContacts();
        protected RepoLookups _repoLookups = new RepoLookups();

        protected IHttpActionResult BuildResponse(string msg, ResponseTypes rtype, Exception exception = null) {
            switch (rtype)
            {
                case ResponseTypes.BadRequest:
                    return BadRequest("ERROR: " + msg);
                case ResponseTypes.DatabaseSaveFailure:
                    return BadRequest("ERROR: " + msg + exception);
                case ResponseTypes.NotFound:
                    return Ok(msg);
                default:
                    return BadRequest("ERROR: An unknown exception has occured.");
            }
        }
    }
}

