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

    [HttpGet]
    public IEnumerable<Patient> Get()
    {
        return new PatientEC().GetBlogs();
    }

    [HttpGet("{id}")]
    public Patient? GetById(Guid id)
    {
        return new PatientEC().GetById(id);
    }

    [HttpDelete("{id}")]
    public Patient? Delete(Guid id)
    {
        return new PatientEC().Delete(id);
    }
}