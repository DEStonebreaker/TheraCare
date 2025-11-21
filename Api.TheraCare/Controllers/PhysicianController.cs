using Api.TheraCare.Enterprise;
using Library.TheraCare.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.TheraCare.Controllers;
[ApiController]
[Route("[controller]")]
public class PhysicianController : ControllerBase
{
    private readonly ILogger<PhysicianController> _logger;

    public PhysicianController(ILogger<PhysicianController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public Physician? Post([FromBody] Physician physician)
    {
        return new PhysicianEC().Post(physician);
    }
    
    [HttpGet]
    public IEnumerable<Physician> Get()
    {
        return new PhysicianEC().GetPhysicians();
    }
    
    [HttpGet("{id}")]
    public Physician? GetById(Guid id)
    {
        return new PhysicianEC().GetById(id);
    }
    
    [HttpPut("{id}")]
    public void Put(Guid id, [FromBody] Physician physician)
    {
        new PhysicianEC().Put(id, physician);
    }
    
    [HttpDelete("{id}")]
    public Physician? Delete(Guid id)
    {
        return new PhysicianEC().Delete(id);
    }
}