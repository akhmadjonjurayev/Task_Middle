using Microsoft.AspNetCore.Mvc;
using Example.Model;
using Example.Service;
namespace Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsosiyController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public AsosiyController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        [HttpPost("createQuote")]
        public IActionResult Create([FromBody] FullQuote full)
        {
            if (ModelState.IsValid)
            {
                var res = _repository.CreateFullQuote(full);
                _repository.Save();
                if (res.IsSuccess)
                    return Ok(res);
                return BadRequest(res);
            }
            return BadRequest(new Response() { IsSuccess = false, Message = "model is not valid" });
        }
        [HttpPut("editauthor")]
        public IActionResult ChangeAuthor([FromBody] Author author)
        {
            if (ModelState.IsValid)
            {
                var res = _repository.Author.Update(author);
                _repository.Save();
                if (res.IsSuccess)
                {
                    return Ok(res);
                }
                else return BadRequest(res);
            }
            return BadRequest(new Response() { IsSuccess = false, Message = "object is not valid" });
        }
        [HttpPut("editcategory")]
        public IActionResult ChangeCategory([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                var res = _repository.Category.Update(category);
                _repository.Save();
                if (res.IsSuccess)
                    return Ok(res);
                else return BadRequest(res);
            }
            return BadRequest(new Response() { IsSuccess = false, Message = "object not valid" });
        }
        [HttpPut("editquote")]
        public IActionResult ChangeQuote([FromBody] Quote quote)
        {
            if (ModelState.IsValid)
            {
                var res = _repository.Quote.Update(quote);
                _repository.Save();
                if (res.IsSuccess)
                    return Ok(res);
                else return BadRequest(res);
            }
            return BadRequest(new Response() { IsSuccess = false, Message = "object is not valid" });
        }
        [HttpDelete("deletequote/id")]
        public IActionResult DeleteQuote(int id)
        {
            var res = _repository.Quote.DeleteById(id);
            if (res.IsSuccess)
                return Ok(res);
            return BadRequest(res);
        }
        [HttpGet("getAllquote")]
        public IActionResult GetAllQuote()
        {
            var res = _repository.Quote.GetAllData();
            if (res.IsSuccsess)
                return Ok(res);
            return BadRequest(new Response() { IsSuccess = false, Message = "Something went wrong" });
        }
        [HttpGet("getbycategory/category")]
        public IActionResult GetByCategory(string category)
        {
            var res = _repository.Quote.GetByCategory(category);
            if (res.IsSuccsess)
                return Ok(res);
            return BadRequest(new Response() { IsSuccess = false, Message = res.Message });
        }
        [HttpGet("getrandom")]
        public IActionResult GetQuoteRandom()
        {
            var res = _repository.Quote.GetRandom();
            if (res.IsSuccsess)
                return Ok(res);
            return BadRequest(new Response() { IsSuccess = false, Message = res.Message });
        }
    }
}
