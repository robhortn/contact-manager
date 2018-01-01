using System.Linq;
using System.Web.Http;

namespace ContactManager.api
{
    public class LookupController : BaseController
    {
        [HttpGet]
        [Route("api/lookup/getStateProvinces")]
        public IHttpActionResult GetStateProvinces()
        {
            return Ok(_repoLookups.GetStateProvinces.OrderBy(x => x.StateCode).ToList());
        }

        [HttpGet]
        [Route("api/lookup/getCategories")]
        public IHttpActionResult GetCategories()
        {
            return Ok(_repoLookups.GetCategories.OrderBy(x => x.Category).ToList());
        }

        [HttpPost]
        [Route("api/lookup/addCategory")]
        public IHttpActionResult AddCategory()
        {
            return NotFound();
        }

    }
}
