using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UPC.APIBusiness.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/Project")]
    public class ApartmentController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IApartmentRepository _AparmentRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ApartmentRepository"></param>
        public ApartmentController(IApartmentRepository ApartmentRepository)
        {
            _AparmentRepository = ApartmentRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getapartments")]
        public ActionResult GetApartments()
        {
            var ret = _AparmentRepository.GetApartments();
            return Json(ret);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getapartment")]

        public ActionResult GetProject(int id)
        {
            var ret = _AparmentRepository.GetApartments(id);

            return Json(ret);
        }

    }
}
