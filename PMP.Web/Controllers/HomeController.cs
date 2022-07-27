using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMP.Data;

namespace PMP.Web;

/// <summary>
/// The main controller for the whole website
/// </summary>
public class HomeController : Controller
{
    /// <summary>
    /// Returns the main page of site
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {   
        return View();
    }

}
