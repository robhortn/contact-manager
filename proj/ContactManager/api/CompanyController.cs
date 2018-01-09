using System;
using System.Web.Http;

using System.Linq;
using ContactManager.Data;
using ContactManager.Data.Models;

namespace ContactManager.api
{
    public class CompanyController : BaseController
    {
        [HttpGet]
        [Route("api/companies")]
        public IHttpActionResult Companies()
        {
            // Gets all active companies 
            var results = _repoCompanies.GetCompanies.OrderBy(x => x.CompanyName).ToList();
            if (results == null) return BuildResponse("No companies found.", ResponseTypes.NotFound);
            return Ok(results);
        }

        [HttpGet]
        [Route("api/company/{id}")]
        public IHttpActionResult CompanyById(int id) {
            if (id == 0) return BuildResponse("Company ID must be greater than zero.", ResponseTypes.BadRequest);
            var results = _repoCompanies.GetCompanies.Where(x => x.Id == id).FirstOrDefault();
            if (results == null) return BuildResponse("No companies found with the specified ID.", ResponseTypes.NotFound);

            return Ok(results);
        }

        [HttpGet]
        [Route("api/company/{categoryId}")]
        public IHttpActionResult CompaniesByCategory(int categoryId)
        {
            if (categoryId == 0) return BuildResponse("Category ID must be greater than zero.", ResponseTypes.BadRequest);
            var results = _repoCompanies.GetCompanies.Where(x => x.CategoryId == categoryId).FirstOrDefault();
            if (results == null) return BuildResponse("No companies found with the specified Category.", ResponseTypes.NotFound);

            return Ok(results);
        }

        [HttpGet]
        [Route("api/company/{phone}")]
        public IHttpActionResult CompaniesByPhoneNumber(string phone)
        {
            if (phone.Length < 10) return BuildResponse("Phone Number must be 10 characters in length.", ResponseTypes.BadRequest);
            var results = _repoCompanies.GetCompanies.Where(x => x.CompanyPhone == phone).FirstOrDefault();
            if (results == null) return BuildResponse("No companies found with the specified phone number.", ResponseTypes.NotFound);

            return Ok(results);
        }

        [HttpPost]
        [Route("api/company/{company}")]
        public IHttpActionResult CompanyAdd([FromBody] Company company) {

            if (company == null) return BuildResponse("Company data not provided for saving.", ResponseTypes.BadRequest);

            try
            {
                DataWriter db = new DataWriter();
                db.SetForTestMode = this._isInTestMode;

                int result = db.AddCompany(company);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BuildResponse("Error while saving the company.", ResponseTypes.BadRequest, ex);
            }
        }

        // [HttpPut]
        // [Route("api/company/{company}")]
        // public IHttpActionResult CompanyUpdate()

        [HttpDelete]
        [Route("api/company/{id}")]
        public IHttpActionResult CompanyDelete(int id) {
            return Ok(string.Format("company with id {0} was deleted", id));
        }
    }
}
