using System.Web.Http;

namespace ContactManager.api
{
    public class ContactController : BaseController
    {
        [HttpGet]
        [Route("api/contacts")]
        public IHttpActionResult GetContacts()
        {
            // Gets all active companies 
            return Ok("imaCompanyUraUser");
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
