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
            var results = _repoCompanies.GetCompanies.OrderBy(x => x.CompanyName).ToList();
            if (results == null) return BuildResponse("No companies found.", ResponseTypes.NotFound);
            return Ok(results);
        }

        [HttpGet]
        [Route("api/company/{id}")]
        public IHttpActionResult GetCompany(int id) {
            if (id == 0) return BuildResponse("Company ID must be greater than zero.", ResponseTypes.BadRequest);
            var results = _repoCompanies.GetCompanies.Where(x => x.Id == id).FirstOrDefault();
            if (results == null) return BuildResponse("No companies found with the specified ID.", ResponseTypes.NotFound);

            return Ok(results);
        }

        [HttpDelete]
        [Route("api/company/{id}")]
        public IHttpActionResult DeleteCompany(int id) {
            return Ok(string.Format("company with id {0} was deleted", id));
        }

        // [HttpPost]
        // [Route("api/company/{company}")]
        // public IHttpActionResult Company()
    }
}
