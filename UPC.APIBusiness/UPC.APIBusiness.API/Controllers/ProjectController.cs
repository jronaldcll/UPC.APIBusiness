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

    public class ProjectController : Controller

    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IProjectRepository _ProjectRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectRepository"></param>
        public ProjectController(IProjectRepository ProjectRepository)
        {
            _ProjectRepository = ProjectRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getprojects")]
        public ActionResult GetProjects()
        {
            var ret = _ProjectRepository.GetProjects();
            return Json(ret);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getproject")]

        public ActionResult GetProject(int id)
        {
            var ret = _ProjectRepository.GetProject(id);

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="price_min"></param>
        /// <param name="price_max"></param>
        /// <param name="direccion"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getprojectprice")]

        public ActionResult GetProjectPrice(decimal price_min, decimal price_max, string direccion)
        {
            var ret = _ProjectRepository.GetProjectPrice(price_min, price_max, direccion);

            return Json(ret);
        }
    }
}