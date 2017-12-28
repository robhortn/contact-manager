using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactManager.api
{
    public class CompanyController : BaseController
    {
        [HttpGet]
        [Route("api/Company/getCompanies")]
        public IHttpActionResult GetCompanies()
        {
            return Ok("imaCompanyUraUser");
        }


        // GetCompanyById
        // DeleteCompany

    }
}
