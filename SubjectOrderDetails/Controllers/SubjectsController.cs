using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubjectOrderDetails.Entities;
using SubjectOrderDetails.Models;
using SubjectOrderDetails.ResourceParameters;
using SubjectOrderDetails.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.Controllers
{
    /// <summary>
    /// Controller for the subject object
    /// </summary>
    [ApiController]
    [Route("api/subjects")]
    [Produces("application/json", "application/xml")]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectOrderRepository _subjectOrderRepository;

        /// <summary>
        /// Constructor for the subjectcontroller
        /// </summary>
        /// <param name="subjectOrderRepository"></param>
        public SubjectsController(ISubjectOrderRepository subjectOrderRepository)
        {
            _subjectOrderRepository = subjectOrderRepository ?? throw new Exception(nameof(subjectOrderRepository));
        }

        /// <summary>
        /// Get All Subjects
        /// </summary>
        /// <returns>Subject Dto objects, with SubjectID, First Name, Last Name, Data of Birth and TitleID</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet()]
        public ActionResult<IEnumerable<SubjectDto>> GetSubjects([FromQuery] SubjectResourceParameters subjectResourceParameters)
        {
            var subjectsFromRepo = _subjectOrderRepository.GetSubjects(subjectResourceParameters);

            List<SubjectDto> subjectsToReturn = new List<SubjectDto>();

            foreach (Subject subject in subjectsFromRepo)
            {
                subjectsToReturn.Add(new SubjectDto
                {
                    subjectId = subject.SubjectId,
                    firstName = subject.FirstName,
                    lastName = subject.LastName,
                    dateOfBirth = subject.DateOfBirth,
                    titleId = subject.TitleId
                });
            }

            return Ok(subjectsToReturn);
        }

        /// <summary>
        /// Get one subject
        /// </summary>
        /// <param name="subjectId">The id of the subject to retrieve</param>
        /// <returns>Subject Dto object, with SubjectID, First Name, Last Name, Data of Birth and TitleID</returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{subjectId}", Name ="GetSubject")]
        public ActionResult<SubjectDto> GetSubject(int subjectId)
        {
            var subjectfromRepo = _subjectOrderRepository.GetSubject(subjectId);

            if (subjectfromRepo == null)
            {
                return NotFound();
            }

            SubjectDto subjectToReturn = new SubjectDto
            {
                subjectId = subjectfromRepo.SubjectId,
                firstName = subjectfromRepo.FirstName,
                lastName = subjectfromRepo.LastName,
                dateOfBirth = subjectfromRepo.DateOfBirth,
                titleId = subjectfromRepo.TitleId
            };

            return Ok(subjectToReturn);
        }

        /// <summary>
        /// Create a new subject
        /// </summary>
        /// <param name="subject">A subject for creation DTO</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/json")]
        [HttpPost]
        public ActionResult CreateSubject([FromBody] SubjectForCreationDto subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Subject subjectEntity = new Subject
            {
                FirstName = subject.FirstName,
                LastName = subject.LastName,
                DateOfBirth = subject.DateOfBirth,
                TitleId = subject.TitleId
            };

            _subjectOrderRepository.AddSubject(subjectEntity);
            _subjectOrderRepository.Save();

            var subjectToReturn = new SubjectDto
            {
                subjectId = subjectEntity.SubjectId,
                firstName = subjectEntity.FirstName,
                lastName = subjectEntity.LastName,
                dateOfBirth = subjectEntity.DateOfBirth,
                titleId = subjectEntity.TitleId
            };

            return CreatedAtRoute("GetSubject",
                    new { subjectToReturn.subjectId },
                    subjectToReturn); ;
        }

        /// <summary>
        /// Deltete a subject
        /// </summary>
        /// <param name="subjectId">The subject to delete</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{subjectId}")]
        public ActionResult DeleteSubject(int subjectId)
        {
            var subjectfromRepo = _subjectOrderRepository.GetSubject(subjectId);

            if (subjectfromRepo == null)
            {
                return NotFound();
            }

            _subjectOrderRepository.DeleteSubject(subjectfromRepo);
            _subjectOrderRepository.Save();

            return NoContent();

        }

        /// <summary>
        /// Update a subject
        /// </summary>
        /// <param name="subjectId">The ID of the subject to update</param>
        /// <param name="subject">A Subject DTO containing the new details</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/json")]
        [HttpPut("{subjectId}")]
        public ActionResult UpdateSubject(int subjectId, SubjectDto subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subjectfromRepo = _subjectOrderRepository.GetSubject(subjectId);

            if (subjectfromRepo == null)
            {
                return NotFound();
            }

            subjectfromRepo.FirstName = subject.firstName;
            subjectfromRepo.LastName = subject.lastName;
            subjectfromRepo.DateOfBirth = subject.dateOfBirth;
            subjectfromRepo.TitleId = subject.titleId;

            _subjectOrderRepository.UpdateSubject(subjectfromRepo);
            _subjectOrderRepository.Save();

            return NoContent();
        }
    }
}
