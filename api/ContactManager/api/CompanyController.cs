using System.Web.Http;

namespace ContactManager.api
{
    public class CompanyController : BaseController
    {

        // Add logical delete to all companies and contacts
        // If you delete a company you'd have to contact support to have it 'undeleted'
        //  Put in a fakey contact screen that does nothing really but provides a way to contact support.


        [HttpGet]
        [Route("api/companies")]
        public IHttpActionResult GetCompanies()
        {
            // Gets all active companies 
            return Ok("imaCompanyUraUser");
        }

        [HttpGet]
        [Route("api/company/{id}")]
        public IHttpActionResult GetCompany(int id) {
            return Ok("company: " + id);
        }

        [HttpDelete]
        [Route("api/company/{id}")]
        public IHttpActionResult DeleteCompany(int id) {
            return Ok(string.Format("company with id {0} was deleted", id));
        }   
    }
}
