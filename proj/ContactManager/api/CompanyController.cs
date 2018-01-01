using System.Web.Http;

using System.Linq;
using ContactManager.Data;
using ContactManager.Data.Interfaces;

namespace ContactManager.api
{
    public class CompanyController : BaseController
    {

        private readonly IRepoCompanies _repo;

        public CompanyController()
        {
            _repo = new RepoCompanies();
        }
        
        [HttpGet]
        [Route("api/companies")]
        public IHttpActionResult GetCompanies()
        {
            // Gets all active companies 
            return Ok(_repo.GetCompanies.OrderBy(x => x.CompanyName).ToList());
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
