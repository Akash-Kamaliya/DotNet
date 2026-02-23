using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MOM_Project.Models;
using System.Collections.Generic;
using System.Data;

namespace MOM_Project.Controllers
{
    public class DepartmentController : Controller
    {
        #region Configuration Injection
        private readonly IConfiguration _configuration;
        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion
        
        #region Get All Departments
        [HttpGet]
        public IActionResult DepartmentList()
        {
            List<DepartmentModel> departmentList = new List<DepartmentModel>();
            string sqlConnString = _configuration.GetConnectionString("DefaultConnection");
            using (var sqlConnection = new SqlConnection(sqlConnString))
            using (var sqlCommand = sqlConnection.CreateCommand())
            {

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "PR_MOM_Department_SelectAll";

                sqlConnection.Open();
                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dept = new DepartmentModel
                        {
                            DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                            DepartmentName = reader["DepartmentName"].ToString(),
                            Created = Convert.ToDateTime(reader["Created"]),
                            Modified = Convert.ToDateTime(reader["Modified"])
                        };
                        departmentList.Add(dept);
                    }
                }
            }
            return View("DepartmentList",departmentList);
        }
        #endregion


        public IActionResult DepartmentAdd()
        {
            return View();
        }


        #region Add Department Operation
        [HttpPost]
        public IActionResult DepartmentAdd(DepartmentModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                model.Created = DateTime.UtcNow;
                model.Modified = DateTime.UtcNow;

                string sqlConnString = _configuration.GetConnectionString("DefaultConnection");
                using (var sqlConnection = new SqlConnection(sqlConnString))
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "PR_MOM_Department_Insert";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@DepartmentName", model.DepartmentName);
                    sqlCommand.Parameters.AddWithValue("@Modified", model.Modified);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    
                }

                TempData["SucessMessage"] = "Record Inserted Successfully";
                return RedirectToAction("DepartmentList");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(model);
            }
        }
        #endregion


        #region Get Department Data For Edit Department Operation
        [HttpGet]
        public IActionResult DepartmentEditForm(int DepartmentID)
        {
            DepartmentModel model = new DepartmentModel();

            string sqlConnString = _configuration.GetConnectionString("DefaultConnection");
            using (var sqlConnection = new SqlConnection(sqlConnString))
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
               
                sqlCommand.CommandText = "PR_MOM_Department_SelectByPK";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@DepartmentID", DepartmentID);

                sqlConnection.Open();
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        model.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                        model.DepartmentName = reader["DepartmentName"].ToString();
                    }
                }
            }
            return View(model);
        }
        #endregion


        #region Edit Operation
        [HttpPost]
        public IActionResult DepartmentEditForm(DepartmentModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                model.Modified = DateTime.UtcNow;

                string sqlConnString = _configuration.GetConnectionString("DefaultConnection");
                using (var sqlConnection = new SqlConnection(sqlConnString))
                using (var sqlCommand = sqlConnection.CreateCommand())
                {

                    sqlCommand.CommandText = "PR_MOM_Department_UpdateByPK";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@DepartmentID", model.DepartmentID);
                    sqlCommand.Parameters.AddWithValue("@DepartmentName", model.DepartmentName);
                    sqlCommand.Parameters.AddWithValue("@Modified", model.Modified);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }


                TempData["SucessMessage"] = "Department Updated Successfully";
                return RedirectToAction("DepartmentList");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(model);
            }
        }
        #endregion



        #region Get Department Data For Delete Operation
        [HttpGet]
        public IActionResult DepartmentDeleteForm(int DepartmentID)
        {
            DepartmentModel model = new DepartmentModel();

            string sqlConnString = _configuration.GetConnectionString("DefaultConnection");

            using (var sqlConnection = new SqlConnection(sqlConnString))
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "PR_MOM_Department_SelectByPK";

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@DepartmentID", DepartmentID);

                sqlConnection.Open();
                using (var reader = sqlCommand.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        model.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                        model.DepartmentName = reader["DepartmentName"].ToString();
                    }
                }
            }
            return View(model);
        }
        #endregion


        #region Delete Operation
        [HttpPost]
        public IActionResult DepartmentDeleteConfirm(int DepartmentID)
        {
            try
            {
                string sqlConnString = _configuration.GetConnectionString("DefaultConnection");

                using (var sqlConnection = new SqlConnection(sqlConnString))
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "PR_MOM_Department_DeleteByPK";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@DepartmentID", DepartmentID);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                TempData["SucessMessage"] = "Department Deleted Successfully";
            }
            catch
            {
                TempData["ErrorMessage"] =
                    "Cannot delete this department because it is referenced by other records.";
            }

            return RedirectToAction("DepartmentList");
        }
        #endregion


        #region View Detail
        [HttpGet]
        public IActionResult DepartmentView(int DepartmentID)
        {
            DepartmentModel model = new DepartmentModel();

            string sqlConnString = _configuration.GetConnectionString("DefaultConnection");
            using (var sqlConnection = new SqlConnection(sqlConnString))
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "PR_MOM_Department_SelectByPK";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@DepartmentID", DepartmentID);  

                sqlConnection.Open();
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        model.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                        model.DepartmentName = reader["DepartmentName"].ToString();
                        model.Created = Convert.ToDateTime(reader["Created"]);
                        model.Modified = Convert.ToDateTime(reader["Modified"]);
                    }
                }
            }
            return View(model);
        }
        #endregion
    }
}