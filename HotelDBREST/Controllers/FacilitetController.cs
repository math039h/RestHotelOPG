using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelDBREST.DBUtil;
using ModelLib.model;

namespace HotelDBREST.Controllers
{
    public class FacilitetController : ApiController
    {
        ManageFacilitet mgr = new ManageFacilitet();

        // GET: api/Facilitet
        public IEnumerable<Facilitet> Get()
        {
            return mgr.Get();
        }

        // GET: api/Facilitet/5
        public Facilitet Get(int id)
        {
            return mgr.Get(id);
        }

        // POST: api/Facilitet
        public bool Post([FromBody]Facilitet value)
        {
            return mgr.Post(value);
        }

        // PUT: api/Facilitet/5
        public bool Put(int id, [FromBody]Facilitet value)
        {
            return mgr.Put(id, value);
        }

        // DELETE: api/Facilitet/5
        public bool Delete(int id)
        {
            return mgr.Delete(id);
        }
    }
}
