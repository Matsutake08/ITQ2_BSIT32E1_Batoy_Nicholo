using ITQ2_BSIT32E1_Batoy_Nicholo.Data;
using ITQ2_BSIT32E1_Batoy_Nicholo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITQ2_BSIT32E1_Batoy_Nicholo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserGroupController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Usergroup>> GetAll()
        {
            return Ok(Datastore.Usergroups);
        }

        [HttpGet("{id}")]
        public ActionResult<Usergroup> GetById(int id)
        {
            Usergroup? group = null;
            foreach (Usergroup item in Datastore.Usergroups)
            {
                if (item.Id == id)
                {
                    group = item;
                    break;
                }
            }

            if (group == null)
            {
                return NotFound($"UserGroup with ID {id} not found.");
            }

            return Ok(group);
        }

        [HttpPost]
        public ActionResult<Usergroup> Create([FromBody] Usergroup request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Group name is required.");
            }

            List<User> users = request.Users;
            if (users == null)
            {
                users = new List<User>();
            }

            Usergroup newGroup = new Usergroup
            {
                Id = Datastore.NextUserGroupId++,
                Name = request.Name,
                Users = users
            };

            Datastore.Usergroups.Add(newGroup);

            return CreatedAtAction(nameof(GetById), new { id = newGroup.Id }, newGroup);
        }

        [HttpPut]
        public ActionResult<Usergroup> Update([FromBody] Usergroup request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Group data is required.");
            }

            Usergroup? existingGroup = null;
            foreach (Usergroup item in Datastore.Usergroups)
            {
                if (item.Id == request.Id)
                {
                    existingGroup = item;
                    break;
                }
            }

            if (existingGroup == null)
            {
                return NotFound($"UserGroup with ID {request.Id} not found.");
            }

            existingGroup.Name = request.Name;
            if (request.Users != null)
            {
                existingGroup.Users = request.Users;
            }
            else
            {
                existingGroup.Users = new List<User>();
            }

            return Ok(existingGroup);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Usergroup? existingGroup = null;
            foreach (Usergroup item in Datastore.Usergroups)
            {
                if (item.Id == id)
                {
                    existingGroup = item;
                    break;
                }
            }

            if (existingGroup == null)
            {
                return NotFound($"UserGroup with ID {id} not found.");
            }

            Datastore.Usergroups.Remove(existingGroup);
            return NoContent();
        }
    }
}
