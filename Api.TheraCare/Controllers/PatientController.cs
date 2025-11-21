using Api.TheraCare.Enterprise;
using Library.TheraCare.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.TheraCare.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : Controller
{
    // // GET
    // public IActionResult Index()
    // {
    //     return View();
    // }

    private readonly ILogger<PatientController> _logger;

    public PatientController(ILogger<PatientController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public Patient? Post([FromBody] Patient patient)
    {
        return new PatientEC().Post(patient);
    }

    [HttpGet]
    public IEnumerable<Patient> Get()
    {
        return new PatientEC().GetPatients();
    }

    [HttpGet("{id}")]
    public Patient? GetById(Guid id)
    {
        return new PatientEC().GetById(id);
    }

    [HttpPut("{id}")]
    public void Put(Guid id, [FromBody] Patient patient)
    {
        var resp = new PatientEC().Put(id, patient);
    }

    [HttpDelete("{id}")]
    public Patient? Delete(Guid id)
    {
        return new PatientEC().Delete(id);
    }
}