using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        public HelperController helper = new HelperController();

        // GET api/calculator/sum/5/5
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Sum(string firstNumber, string secondNumber)
        {
            if(helper.IsNumeric(firstNumber) && helper.IsNumeric(secondNumber))
            {
                var sum = helper.ConvertToDecimal(firstNumber) + helper.ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // GET api/calculator/subtraction/5/5
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Subtraction(string firstNumber, string secondNumber)
        {
            if (helper.IsNumeric(firstNumber) && helper.IsNumeric(secondNumber))
            {
                var sum = helper.ConvertToDecimal(firstNumber) - helper.ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Multiplication(string firstNumber, string secondNumber)
        {
            if (helper.IsNumeric(firstNumber) && helper.IsNumeric(secondNumber))
            {
                var sum = helper.ConvertToDecimal(firstNumber) * helper.ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Division(string firstNumber, string secondNumber)
        {
            if (helper.IsNumeric(firstNumber) && helper.IsNumeric(secondNumber))
            {
                var sum = helper.ConvertToDecimal(firstNumber) / helper.ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Mean(string firstNumber, string secondNumber)
        {
            if (helper.IsNumeric(firstNumber) && helper.IsNumeric(secondNumber))
            {
                var sum = (helper.ConvertToDecimal(firstNumber) + helper.ConvertToDecimal(secondNumber)) / 2;
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("square-root/{number}")]
        public ActionResult<string> SquareRoot(string number)
        {
            if (helper.IsNumeric(number))
            {
                var squareRootum = Math.Sqrt((double)helper.ConvertToDecimal(number));
                return Ok(squareRootum.ToString());
            }

            return BadRequest("Invalid Input");
        }

    }
}
