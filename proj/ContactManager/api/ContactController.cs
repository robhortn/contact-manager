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
            var results = _repoContacts.GetContacts.OrderBy(x => x.NameLast).ToList();
            return Ok(results);
        }

        [HttpGet]
        [Route("api/contact/{id}")]
        public IHttpActionResult GetContact(int id)
        {
            if (id == 0) return BuildResponse("Contact ID must be greater than zero.", ResponseTypes.BadRequest);
            var results = _repoContacts.GetContacts.Where(x => x.Id == id).FirstOrDefault();
            if (results == null) return BuildResponse("No contacts found with the specified ID.", ResponseTypes.NotFound);

            return Ok(results);
        }

        [HttpDelete]
        [Route("api/contact/{id}")]
        public IHttpActionResult DeleteContact(int id)
        {
            return Ok(string.Format("contact with id {0} was deleted", id));
        }

        // [HttpPost]
        // [Route("api/contact/{contact}")]
        // public IHttpActionResult Contact()

    }
}
