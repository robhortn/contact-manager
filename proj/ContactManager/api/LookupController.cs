﻿using System.Linq;
using System.Web.Http;

using ContactManager.Data;
using ContactManager.Data.Interfaces;
using ContactManager.Data.Models;

namespace ContactManager.api
{
    public class LookupController : BaseController
    {
        private readonly IRepoLookups _repo;

        public LookupController()
        {
            _repo = new RepoLookup();
        }

        [HttpGet]
        [Route("api/lookup/getStateProvinces")]
        public IHttpActionResult GetStateProvinces()
        {
            return Ok(_repo.GetStateProvinces.OrderBy(x => x.StateCode).ToList());
        }
    }
}