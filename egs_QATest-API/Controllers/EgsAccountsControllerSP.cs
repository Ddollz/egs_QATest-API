using Microsoft.AspNetCore.Mvc;
using egs_QATest_API.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace egs_QATest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EgsAccountsControllerSP : ControllerBase
    {
        EgsAccount egsAcc = new EgsAccount();
        // GET: api/<EgsAccountsControllerSP>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<EgsAccountsControllerSP>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<EgsAccountsControllerSP>
        [HttpPost]
        public string PostAndUpdate([FromBody] EgsAccount account)
        {
            string msg = string.Empty;
            try
            {
                msg = egsAcc.EgsAccountOpt(account);
            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // PUT api/<EgsAccountsControllerSP>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<EgsAccountsControllerSP>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
