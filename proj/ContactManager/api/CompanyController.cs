using System.Web.Http;

using System.Linq;

namespace ContactManager.api
{
    public class CompanyController : BaseController
    {        
        [HttpGet]
        [Route("api/companies")]
        public IHttpActionResult GetCompanies()
        {
            // Gets all active companies 
            return Ok(_repoCompanies.GetCompanies.OrderBy(x => x.CompanyName).ToList());
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
