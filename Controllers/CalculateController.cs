using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using new_project.Models;

namespace new_project.Controllers;

public class CalculateController : Controller
{
    [HttpGet]

    public IActionResult Calc()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Calc(string FirstNumber, string SecondNumber)
    {
        try
        {
            
        if (int.Parse(FirstNumber) < 0 || int.Parse(SecondNumber) < 0)
        {
            ViewBag.NegNumError = "Please input a positive number";
        }

        double firstNum = double.Parse(FirstNumber);
        double secondNum= double.Parse(SecondNumber);

        double firstNumSqrt = Math.Sqrt(firstNum);
        double secondNumSqrt = Math.Sqrt(secondNum);

        ViewBag.first = firstNum;
        ViewBag.second = secondNum;
        ViewBag.firstNumSqrt = firstNumSqrt;
        ViewBag.secondNumSqrt = secondNumSqrt;            
        }
        catch (ArgumentNullException ex)
        {
             // TODO
            string emptyValueError = ex.Message;
            ViewBag.errorMessageEmpty = "Please input a number and try again";
        }
        catch (FormatException ex)
        {
             // TODO
             string AlphabetError = ex.Message;
            ViewBag.alphaError = "Please input number only and try again";

        }

        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}