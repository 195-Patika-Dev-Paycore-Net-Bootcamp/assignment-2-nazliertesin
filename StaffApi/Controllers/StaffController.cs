using Microsoft.AspNetCore.Mvc;
using StaffApi.Model;
using StaffApi.Validation;

namespace StaffApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : Controller
    {
        private List<Staff> staffList;
        public StaffController()
        {
            staffList = new List<Staff>();
            staffList.Add(new Staff() { Id = 1, Name = "Nazlı", Lastname = "Ertesin", DateOfBirth = new DateTime(1997, 10, 20), Email = "nazli@gmail.com", PhoneNumber = "5556665555", Salary = 8500 });
        }
        [HttpGet("GetAllStaff")]
        public IEnumerable<Staff> GetAllStaff()
        {
            return staffList;
        }
        [HttpGet("GetByIdStaff/{id}")]
        public IActionResult GetByIdStaff([FromRoute] int id)
        {
            var result = staffList.Find(x => x.Id == id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost("InsertStaff")]
        public IActionResult InsertStaff([FromBody] Staff model)
        {

            var validator = new StaffValidator();
            var result = validator.Validate(model);
            if (result.IsValid)
            {

                staffList.Add(model);
                return Ok();

            }
            else
            {
                return BadRequest(result.Errors);
            }

        }
        [HttpDelete("DeleteStaff/{id}")]
        public IActionResult DeleteStaff([FromRoute] int id)
        {
            var result = staffList.Find(x => x.Id == id);
            if (result != null)
            {
                staffList.Remove(result);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut("UpdateStaff/{id}")]
        public IActionResult UpdateStaff(int id, [FromBody] Staff request)
        {

            var result = staffList.Find(x => x.Id == id);

            if (result != null)
            {
                var validator = new StaffValidator();
                var resultValidate = validator.Validate(request);
                if (resultValidate.IsValid)
                {
                    staffList.Remove(result);
                    request.Id = id;
                    staffList.Add(request);
                    return Ok();
                }
                else
                {
                    return BadRequest(resultValidate.Errors);
                }
            }
            else
            {
                return NotFound();
            }

        }

    }
}
