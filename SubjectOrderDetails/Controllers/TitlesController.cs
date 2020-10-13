using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubjectOrderDetails.Entities;
using SubjectOrderDetails.Models;
using SubjectOrderDetails.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.Controllers
{
    /// <summary>
    /// Controller for the titles object
    /// </summary>
    [ApiController]
    [Route("api/titles")]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class TitlesController : ControllerBase
    {
        private readonly ISubjectOrderRepository _subjectOrderRepository;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="subjectOrderRepository"></param>
        public TitlesController(ISubjectOrderRepository subjectOrderRepository)
        {
            _subjectOrderRepository = subjectOrderRepository ?? throw new Exception(nameof(subjectOrderRepository));
        }

        /// <summary>
        /// Get all tities
        /// </summary>
        /// <returns></returns>
        [Produces("application/json", "application/xml")]
        [HttpGet()]
        public ActionResult<IEnumerable<TitleDto>> GetTitles()
        {
            var titlesFromRepo = _subjectOrderRepository.GetTitles();

            List<TitleDto> titlesToReturn = new List<TitleDto>();

            foreach (Title title in titlesFromRepo)
            {
                titlesToReturn.Add(new TitleDto
                {
                    titleId = title.titleId,
                    titleName = title.titleName
                });
            }

            return Ok(titlesToReturn);
        }
    }
}
