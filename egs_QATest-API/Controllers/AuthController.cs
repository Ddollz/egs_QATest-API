using egs_QATest_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace egs_QATest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        SqlConnection con = new SqlConnection("Data Source=WORKSTATION-181\\SQLEXPRESS;Initial Catalog=EgsQAsuite;User ID = egs.karl;Password = p0sM,VkqCaY)wD");
        
        [HttpPost("Register")]
        public async Task<ActionResult<String>> Register(egsAccount request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            using (var cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "egsQAAccountInsertUpdate";
                cmd.Parameters.AddWithValue("@User_Email", request.User_email);
                cmd.Parameters.AddWithValue("@User_Firstname", request.User_Firstname);
                cmd.Parameters.AddWithValue("@User_LastName", request.User_LastName);
                cmd.Parameters.AddWithValue("@User_PasswordHash", passwordHash);
                cmd.Parameters.AddWithValue("@User_PasswordSalt", passwordSalt);
                cmd.Parameters.AddWithValue("@User_isAdmin", request.User_isAdmin);
                cmd.Parameters.AddWithValue("@User_Status", request.User_Status);
                cmd.Parameters.AddWithValue("@Role_ID", request.Role_ID);
                cmd.Parameters.AddWithValue("@RoleTitle", request.RoleTitle);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


            }

            return Ok("fawef");
        }

        [HttpPost("Login")]
        public async Task<ActionResult<String>> Login(egsAccount request)
        {

            DataTable dt1 = new DataTable();
            string token;

            using (var cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "egsQAAccountGet";
                cmd.Parameters.AddWithValue("@User_Email", request.User_email);
                con.Open();

                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                da1.Fill(dt1);


                if (dt1.Rows.Count <= 0)
                {
                    return BadRequest("User not found.");
                }

                DataRow row = dt1.Rows[0];

                if (!VerifyPasswordHash(request.Password, (byte[])row["User_PasswordHash"], (byte[])row["User_PasswordSalt"]))
                {
                    return BadRequest("Wrong Password");
                }
                token = CreateToken(row);

                con.Close();

            }
            return Ok(token);
        }

        private string CreateToken(DataRow row)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, row["User_Email"].ToString())
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value
                ));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials:cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                System.Diagnostics.Debug.WriteLine(passwordHash);
            }
        }

        private bool VerifyPasswordHash (string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {

                var computedSalt = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedSalt.SequenceEqual(passwordHash);

                //Alternative
                //System.Diagnostics.Debug.WriteLine(computedSalt);
                //for (int i = 0; i < passwordHash.Length; i++)
                //{
                //    if (computedSalt[i] != passwordHash[i])
                //    {
                //        return false;
                //    }
                //}
                //return true;
            }

        }
    }
}
