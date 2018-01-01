using System.Web.Http;

using System.Linq;
using ContactManager.Data;
using ContactManager.Data.Interfaces;

namespace ContactManager.api
{
    public class ContactController : BaseController
    {
        private readonly IRepoContacts _repo;

        public ContactController()
        {
            _repo = new RepoContacts();
        }

        [HttpGet]
        [Route("api/contacts")]
        public IHttpActionResult GetContacts()
        {
            return Ok(_repo.GetContacts.OrderBy(x => x.NameLast).ToList());
        }

        [HttpGet]
        [Route("api/contact/{id}")]
        public IHttpActionResult GetContact(int id)
        {
            return Ok("contact: " + id);
        }

        [HttpDelete]
        [Route("api/contact/{id}")]
        public IHttpActionResult DeleteContact(int id)
        {
            return Ok(string.Format("contact with id {0} was deleted", id));
        }
    }
}
