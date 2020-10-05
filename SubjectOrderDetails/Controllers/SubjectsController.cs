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
    [Route("api/subjects")]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectOrderRepository _subjectOrderRepository;

        public SubjectsController(ISubjectOrderRepository subjectOrderRepository)
        {
            _subjectOrderRepository = subjectOrderRepository ?? throw new Exception(nameof(subjectOrderRepository));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<SubjectDto>> GetSubjects()
        {
            var subjectsFromRepo = _subjectOrderRepository.GetSubjects();

            List<SubjectDto> subjectsToReturn = new List<SubjectDto>();

            foreach (Subject subject in subjectsFromRepo)
            {
                subjectsToReturn.Add(new SubjectDto
                {
                    subjectId = subject.subjectId,
                    firstName = subject.firstName,
                    lastName = subject.lastName,
                    dateOfBirth = subject.dateOfBirth,
                    titleId = subject.titleId
                });
            }

            return Ok(subjectsToReturn);
        }

        [HttpGet("{subjectId}")]
        public ActionResult<SubjectDto> GetSubject(int subjectId)
        {
            var subjectfromRepo = _subjectOrderRepository.GetSubject(subjectId);

            if (subjectfromRepo == null)
            {
                return NotFound();
            }

            SubjectDto subjectToReturn = new SubjectDto
            {
                subjectId = subjectfromRepo.subjectId,
                firstName = subjectfromRepo.firstName,
                lastName = subjectfromRepo.lastName,
                dateOfBirth = subjectfromRepo.dateOfBirth,
                titleId = subjectfromRepo.titleId
            };

            return Ok(subjectToReturn);
        }
    }
}
