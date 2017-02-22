using Intership.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.IO;

namespace Intership.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult JobFair()
        {
            return View();
        }
    
        [HttpPost]
        public JsonResult SaveFiles(string Name, string MobileNo, string Email, string CollegeName, string SelectValue, string SSCMark, string HscDiplomaMark, string GraduateMark, string PGMark, string AcceptTermAndCondition)
        {
            string Date = System.DateTime.Now.ToString("dd/MM/yyyy h:mm tt");

                string Message, fileName, actualFileName;
                Message = fileName = actualFileName = string.Empty;
                bool flag = false;
                if (Request.Files != null)
                {
                    var file = Request.Files[0];
                    actualFileName = file.FileName;
                    fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    int size = file.ContentLength;
                    string FilePath = fileName;
                    //file.SaveAs(Path.Combine(Server.MapPath("~/UploadResume"), fileName));
                    try                                
                    {

                        file.SaveAs(Path.Combine(Server.MapPath("~/UploadResume/"), fileName));

                        SqlConnection bcs = new SqlConnection(DBContext.GetConnectionString());
                        bcs.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "Insert into IntesrShipStudentDetails values('" + Name + "','" + MobileNo + "','" + Email + "','" + CollegeName + "','" + SelectValue + "','" + SSCMark + "','" + HscDiplomaMark + "','" + GraduateMark + "','" + PGMark + "','" + AcceptTermAndCondition + "','" + fileName + "', '" + Date + "')";
                        cmd.Connection = bcs;
                        cmd.ExecuteNonQuery();
                        Message = "Resume Send successfully...";
                        flag = true;
                    }
                    catch (Exception ex)
                    {

                        Message = ex.Message; //"Authentication problem and please your check internet connection..!! Resume upload failed! Please try again!";
                    }
                }
                return new JsonResult { Data = new { Message = Message, Status = flag } };      
        }

        public FileResult DownloadFile(string name)
        {

            var files = new DataAccess().GetFiles();
            string filename = (from f in files
                               where f.FileName == name
                               select f.FilePath).First();
            string contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document,application/pdf";
            //Parameters to file are
            //1. The File Path on the File Server
            //2. The content type MIME type
            //3. The parameter for the file save by the browser
            return File(filename, contentType, filename + ".docx");
        }



        private void SendEmail(string p1, string p2)
        {

        }

        public ActionResult ShowAllDeatils()
        {
            return View();
        }

        public JsonResult SelectAllData()
        {
            DataSet ds = null;
            try
            {
                SqlConnection bcs = new SqlConnection(DBContext.GetConnectionString());

                bcs.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * from IntesrShipStudentDetails";
                cmd.Connection = bcs;
                var result = new List<StudentModelData>();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result.Add(new StudentModelData
                    {
                        StudentId = Convert.ToInt32(dr["StudentId"]),
                        StudentName = (string)dr["StudentName"],
                        MobailNumber = dr["MobailNumber"] as string,
                        EmailID = dr["EmailID"] as string,
                        Current_And_Last_College_Name = dr["Current_And_Last_College_Name"] as string,
                        Education_Type = dr["Education_Type"] as string,
                        SSC_mark = dr["SSC_mark"] as string,
                        HSC_And_Deploma_mark = dr["HSC_And_Deploma_mark"] as string,
                        Graduate_mark = dr["Graduate_mark"] as string,
                        PG_mark = dr["PG_mark"] as string,
                        Term_And_Condition = dr["Term_And_Condition"] as string,
                        Resumes = dr["Resumes"] as string,
                        DateTime = dr["DateTime"] as string,

                    });
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
//<input type="file" class="form-control" name="file" accept="application/msword, application/vnd.ms-excel, application/vnd.ms-powerpoint,text/plain, application/pdf, image/*" onchange="angular.element(this).scope().selectFileforUpload(this.files)" required />