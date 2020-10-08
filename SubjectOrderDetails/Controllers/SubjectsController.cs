﻿using Microsoft.AspNetCore.Mvc;
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
                subjectId = subjectfromRepo.subjectId,
                firstName = subjectfromRepo.firstName,
                lastName = subjectfromRepo.lastName,
                dateOfBirth = subjectfromRepo.dateOfBirth,
                titleId = subjectfromRepo.titleId
            };

            return Ok(subjectToReturn);
        }

        [HttpPost]
        public ActionResult CreateSubject([FromBody] SubjectForCreationDto subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Subject subjectEntity = new Subject
            {
                firstName = subject.firstName,
                lastName = subject.lastName,
                dateOfBirth = subject.dateOfBirth,
                titleId = subject.titleId
            };

            _subjectOrderRepository.AddSubject(subjectEntity);
            _subjectOrderRepository.Save();

            var subjectToReturn = new SubjectDto
            {
                subjectId = subjectEntity.subjectId,
                firstName = subjectEntity.firstName,
                lastName = subjectEntity.lastName,
                dateOfBirth = subjectEntity.dateOfBirth,
                titleId = subjectEntity.titleId
            };

            return CreatedAtRoute("GetSubject",
                    new { subjectId = subjectToReturn.subjectId },
                    subjectToReturn); ;
        }

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

            subjectfromRepo.firstName = subject.firstName;
            subjectfromRepo.lastName = subject.lastName;
            subjectfromRepo.dateOfBirth = subject.dateOfBirth;
            subjectfromRepo.titleId = subject.titleId;

            _subjectOrderRepository.UpdateSubject(subjectfromRepo);
            _subjectOrderRepository.Save();

            return NoContent();
        }
    }
}
