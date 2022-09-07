using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Nancy.Json;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Reflection;
using static egs_QATest_API.Controllers.UniCallController_SQLServer;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.IO;
using Nancy;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace egs_QATest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniCallController_SQLServer : ControllerBase
    {

        //file upload
        public static IWebHostEnvironment _webHostEnvironment;


        private readonly IConfiguration _configuration;
        public UniCallController_SQLServer(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }


        //readonly SqlConnection con = new SqlConnection("Data Source=WORKSTATION-181\\SQLEXPRESS;Initial Catalog=EgsQAsuite;User ID = egs.karl;Password = p0sM,VkqCaY)wD");
        //"MainDB": "Server=egspimqa-cluster.chzlnlcqo5x5.us-east-1.rds.amazonaws.com; Initial Catalog=egspim; User Id=egsaurora_joan;Password=Bd#lLV7x!Z6QoDIl;Connect Timeout= 6000;"
        // These are the parameters for the function
        // BEGIN BLOCK
        public class feed
        {
            public string CommandText { get; set; }
            public List<object> Params { get; set; }
        }

        public class FileUpload
        {
            public string CommandText { get; set; }
            public string Params { get; set; }
            public int? file_ID { get; set; } = null;
            public bool isDownload { get; set; } = false;
            public IFormFile? files { get; set; }
        }

        public class param
        {
            public string Param { get; set; }
            public string Value { get; set; }
        }


        // END BLOCK


        [Route("UniCall")]
        [HttpPost]
        public object UniCallObject([FromBody] feed incoming)
        {

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            using (var cmd = new SqlCommand())
            {

                using (var con = new SqlConnection(_configuration.GetSection("ConnectionStrings:DefaultConnection").Value))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = incoming.CommandText;

                    foreach (JsonElement Iparam in incoming.Params)
                    {
                        param IParam = serializer.Deserialize<param>(Iparam.ToString());
                        cmd.Parameters.AddWithValue(IParam.Param, IParam.Value);

                    }
                    //}
                    con.Open();
                    using (SqlDataAdapter r = new SqlDataAdapter(cmd))
                    {
                        List<object> retObj = new List<object>();
                        using (DataSet ds = new DataSet())
                        {
                            try
                            {
                                r.Fill(ds);
                                foreach (DataTable dt in ds.Tables)
                                {
                                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                                    Dictionary<string, object> row;
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        row = new Dictionary<string, object>();
                                        foreach (DataColumn col in dt.Columns)
                                        {
                                            //if (incoming.isString)
                                            //{
                                            //    row.Add(col.ColumnName, dr[col].ToString());
                                            //}
                                            //else
                                            //{
                                            if (dr[col] == System.DBNull.Value)
                                            {
                                                row.Add(col.ColumnName, "");
                                            }
                                            else
                                            {
                                                row.Add(col.ColumnName, dr[col]);
                                            }
                                            //}
                                        }
                                        rows.Add(row);
                                    }
                                    retObj.Add(rows);
                                }
                            }catch(Exception ex)
                            {
                                return BadRequest(ex.Message);
                            }
                        }
                        return retObj;
                    }
                }

            }
        }


        [Route("UniAttachment")]
        [HttpPost]
        public object testObject([FromForm] FileUpload fileUpload)
        {
            try
            {

                string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                using (var cmd = new SqlCommand())
                {

                    using (var con = new SqlConnection(_configuration.GetSection("ConnectionStrings:DefaultConnection").Value))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = fileUpload.CommandText;
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        var model = JsonConvert.DeserializeObject<List<object>>(fileUpload.Params);
                        foreach (var Iparam in model)
                        {
                            param IParam = serializer.Deserialize<param>(Iparam.ToString());
                            cmd.Parameters.AddWithValue(IParam.Param, IParam.Value);
                            if (fileUpload.files != null && IParam.Param == "@User_ID")
                            {
                                   
                                if (fileUpload.files.Length > 0)
                                {
                                    path = path + IParam.Value + "\\";
                                }
                            }
                                Console.WriteLine(Iparam);
                        }
                        if (fileUpload.files != null)
                        {

                            if (fileUpload.files.Length > 0)
                            {
                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                }
                                using (FileStream fileStream = System.IO.File.Create(path + fileUpload.files.FileName))
                                {
                                    fileUpload.files.CopyTo(fileStream);
                                    fileStream.Flush();
                                }
                            }
                            cmd.Parameters.AddWithValue("@Filetype", fileUpload.files.ContentType.ToString());
                            cmd.Parameters.AddWithValue("@Filepath", path);
                            cmd.Parameters.AddWithValue("@Filename", fileUpload.files.FileName);
                        }

                        con.Open();
                        using (SqlDataAdapter r = new SqlDataAdapter(cmd))
                        {
                            List<object> retObj = new List<object>();
                            var CaseAttachment_ID = "";
                            var filetype = "";
                            var filename = "";
                            var filepath = "";
                            var finalPath = "";

                            using (DataSet ds = new DataSet())
                            {
                                try
                                {
                                    r.Fill(ds);
                                    foreach (DataTable dt in ds.Tables)
                                    {
                                        if (fileUpload.isDownload)
                                        {
                                            string expression;
                                            expression = "CaseAttachment_ID = " + fileUpload.file_ID;
                                            DataRow[] foundRows;
                                            foundRows = dt.Select(expression);

                                            foreach (DataRow dr in foundRows)
                                            {
                                                filetype = dr["Filetype"].ToString();
                                                filepath = dr["Filepath"].ToString();
                                                filename = dr["Filename"].ToString();
                                                CaseAttachment_ID = dr["CaseAttachment_ID"].ToString();
                                                finalPath = filepath + filename;
                                            }
                                            if (System.IO.File.Exists(finalPath))
                                            {
                                                byte[] b = System.IO.File.ReadAllBytes(finalPath);
                                                if (fileUpload.isDownload && fileUpload.file_ID.ToString() == CaseAttachment_ID)
                                                {
                                                    return File(b, filetype);
                                                }
                                            }
                                        }
                                        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                                        Dictionary<string, object> row;
                                        foreach (DataRow dr in dt.Rows)
                                        {
                                            row = new Dictionary<string, object>();
                                            foreach (DataColumn col in dt.Columns)
                                            {


                                                if (dr[col] == System.DBNull.Value) row.Add(col.ColumnName, "");

                                                row.Add(col.ColumnName, dr[col]);
                                                if (col.ColumnName == "Filetype") filetype = dr[col].ToString();
                                                if (col.ColumnName == "Filepath") filepath = dr[col].ToString();
                                                if (col.ColumnName == "Filename") filename = dr[col].ToString();

                                            }
                                            finalPath = filepath + filename;
                                            if (System.IO.File.Exists(finalPath))
                                            {
                                                byte[] b = System.IO.File.ReadAllBytes(finalPath);
                                                row.Add("byteFile", File(b, filetype));
                                            }
                                            rows.Add(row);
                                        }
                                        retObj.Add(rows);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    return BadRequest(ex.Message);
                                }
                            }
                            return retObj;
                        }

                    }
                }
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }




    }

}
