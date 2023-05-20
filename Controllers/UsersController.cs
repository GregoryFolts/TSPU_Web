using Laboratory_work_1.Infrastructure;
using Laboratory_work_1.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var result = Repository.GetData();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public ActionResult<int> Get([FromRoute] int id)
    {
        var result = Repository.GetData(id);
        if (result == null)
        {
            return NoContent();
        }

        return Ok(result);
    }

    [HttpPost]
    public ActionResult Post([FromBody] User user)
    {
        if (user == null)
        {
            return BadRequest();
        }
        Repository.Add(user);
        return Ok();
    }

    [HttpPut]
    public ActionResult Put([FromBody] User user)
    {
        if (user == null || user.Id <= 0)
        {
            return BadRequest();
        }

        Repository.Edit(user);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        Repository.Delete(id);
        return Ok();
    }
}                                                                                                                                  //}