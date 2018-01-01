using System.Web.Http;
using System.Linq;

namespace ContactManager.api
{
    public class ContactController : BaseController
    {
        [HttpGet]
        [Route("api/contacts")]
        public IHttpActionResult GetContacts()
        {
            return Ok(_repoContacts.GetContacts.OrderBy(x => x.NameLast).ToList());
        }

        [HttpGet]
        [Route("api/contact/{id}")]
        public IHttpActionResult GetContact(int id)
        {
            if (id == 0) return NotFound();
            var contact = _repoContacts.GetContacts.FirstOrDefault(x => x.Id == id);
            return Ok(contact);
        }

        [HttpDelete]
        [Route("api/contact/{id}")]
        public IHttpActionResult DeleteContact(int id)
        {
            return Ok(string.Format("contact with id {0} was deleted", id));
        }
    }
}
