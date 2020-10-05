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
    [ApiController]
    [Route("api/titles")]
    public class TitlesController : ControllerBase
    {
        private readonly ISubjectOrderRepository _subjectOrderRepository;

        public TitlesController(ISubjectOrderRepository subjectOrderRepository)
        {
            _subjectOrderRepository = subjectOrderRepository ?? throw new Exception(nameof(subjectOrderRepository));
        }

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

            return Ok();
        }
    }
}
