using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Nancy.Json;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.Json;

namespace egs_QATest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniCallController_SQLServer : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public UniCallController_SQLServer(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        //readonly SqlConnection con = new SqlConnection("Data Source=WORKSTATION-181\\SQLEXPRESS;Initial Catalog=EgsQAsuite;User ID = egs.karl;Password = p0sM,VkqCaY)wD");
        //"MainDB": "Server=egspimqa-cluster.chzlnlcqo5x5.us-east-1.rds.amazonaws.com; Initial Catalog=egspim; User Id=egsaurora_joan;Password=Bd#lLV7x!Z6QoDIl;Connect Timeout= 6000;"
        // These are the parameters for the function
        // BEGIN BLOCK
        public class feed
        {
            public string CommandText { get; set; }
            public List<object> Params { get; set; }
            //public bool isString { get; set; }
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

            string msg = string.Empty;
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
                //cmd.ExecuteNonQuery();
                //con.Close();
                //return msg;

            }
        }


    }

}
