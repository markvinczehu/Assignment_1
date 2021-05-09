using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PeopleWebApi.Models;
using PeopleWebApi.Repository;

namespace PeopleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobsController : ControllerBase
    {
        private IJobRepository jobRepository;

        public JobsController(IJobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Job>>> GetJobsAsync()
        {
            try
            {
                IList<Job> jobs = await jobRepository.GetJobsAsync();
                return Ok(jobs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }
    }
}