using System;
using System.Web.Http;
using ContactManager.Data;

namespace ContactManager.api
{
    public abstract class BaseController : ApiController
    {
        protected bool _inTestMode = false;

        protected RepoCompanies _repoCompanies = new RepoCompanies();
        protected RepoContacts _repoContacts = new RepoContacts();
        protected RepoLookups _repoLookups = new RepoLookups();

        public enum ResponseTypes {
            BadRequest,
            DatabaseSaveFailure,
            NotFound
        }

        public BaseController()
        {

        }
        public BaseController(bool setForTestMode)
        {
            _inTestMode = setForTestMode;
        }

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

