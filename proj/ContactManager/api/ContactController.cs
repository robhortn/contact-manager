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
            if (id == 0) return BuildResponse("Contact ID must be greater than zero.", ResponseTypes.BadRequest);
            var contact = _repoContacts.GetContacts.Where(x => x.Id == id).FirstOrDefault();
            if (contact == null) return BuildResponse("Unable to find a contact with the specified ID.", ResponseTypes.NotFound);

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
