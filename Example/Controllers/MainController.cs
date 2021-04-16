using Microsoft.AspNetCore.Mvc;
using Example.Model;
using Example.Service;
using System.Threading;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Example.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IEmailServise _email;

        public MainController(IEmailServise email,IRepositoryWrapper repository)
        {
            _repository = repository;
            _email = email;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Welcome !!!");
        }
        [HttpGet("sendemailforscript")]
        public IActionResult SendEmail()
        {
            var res = _repository.Author.GetAll();
            if(res.IsSuccsess)
            {
                foreach(var data in res.Data)
                {
                    _email.SendEmail(new Email() { To = data.Emailaddress,Subject="Subscript" }, data.AId);
                }
                return Ok("jo'natildi");
            }
            return BadRequest(new Response() { IsSuccess = false, Message = "something went wrong" });
        }
        [HttpPost("reaciveemailresponse")]
        public IActionResult Reacive(int id)
        {
            var data = _repository.Author.FindOne(id);
            if (data.IsSuccsess)
            {
                data.Data.DialyNews = true;
                _repository.Save();
                return Ok(new Response() { IsSuccess = true, Message = "succsessfully subscript" });
            }
            return BadRequest(new Response() { IsSuccess = false, Message = "something went wrong" });
            
        }
        [HttpGet("senddialynews")]
        public IActionResult DialyNews()
        {
            var persons = _repository.Author.FindByCondition(i => i.DialyNews).ToList();
            if (persons != null)
            {
                var news = _repository.Quote.FindByCondition(i => i.Entered_Date.AddDays(1) > DateTime.Now).ToList();
                foreach(var per in persons)
                {
                    foreach (var n in news)
                        _email.SendEmail(new Email() { To = per.Emailaddress });
                }
            }
            return Ok(new Response() { IsSuccess = true, Message = "Done" });
        }
        [HttpGet("worker")]
        public async Task<IActionResult> Worker()
        {
            while (true)
            {
                var Data = await _repository.Quote.FindByCondition(i => i.Entered_Date.AddDays(1) < DateTime.Now).ToListAsync();
                foreach (var data in Data)
                    _repository.Quote.Delete(data);
                await _repository.SaveAsync();
                Thread.Sleep(5000);
            }
        }
    }
}
