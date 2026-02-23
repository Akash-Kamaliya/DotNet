using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MOM_Project.Models;
using System.Data;

namespace MOM_Project.Controllers
{
    public class MeetingTypeController : Controller
    {

        #region Configuration Injection
        private readonly IConfiguration _configuration;
        public MeetingTypeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        #region Get All MeetingTypes
        [HttpGet]
        public IActionResult MeetingTypelist()
        {
            List<MeetingTypeModel> meetingTypelist = new List<MeetingTypeModel>();
            string sqlConnString = _configuration.GetConnectionString("DefaultConnection");
            using (var sqlConnection = new SqlConnection(sqlConnString))
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "PR_MOM_MeetingType_SelectAll";

                sqlConnection.Open();

                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MeetingTypeModel mt = new MeetingTypeModel();
                        mt.MeetingTypeID = Convert.ToInt32(reader["MeetingTypeID"]);
                        mt.MeetingTypeName = reader["MeetingTypeName"].ToString();
                        mt.Created = Convert.ToDateTime(reader["Created"]);
                        mt.Modified = Convert.ToDateTime(reader["Modified"]);

                        meetingTypelist.Add(mt);
                    }
                }
            }
            return View(meetingTypelist);
        }
        #endregion

        public IActionResult MeetingTypeAdd()
        {
            return View();
        }


        #region Add Operation
        [HttpPost]
        public IActionResult MeetingTypeAdd(MeetingTypeModel model)
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
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "PR_MOM_MeetingType_Insert";

                    sqlCommand.Parameters.AddWithValue("@MeetingTypeName", model.MeetingTypeName);
                    sqlCommand.Parameters.AddWithValue("@Remarks", model.Remarks);
                    sqlCommand.Parameters.AddWithValue("@Modified", model.Modified);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                TempData["SucessMessage"] = "Record Inserted Successfully";
                return RedirectToAction("MeetingTypeList");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(model);
            }
        }
        #endregion

        #region Get Data of Meeting Type for Edit Operation
        [HttpGet]
        public IActionResult MeetingTypeEditForm(int MeetingTypeID)
        {
            MeetingTypeModel model = new MeetingTypeModel();

            string sqlConnString = _configuration.GetConnectionString("DefaultConnection");
            using (var sqlConnection = new SqlConnection(sqlConnString))
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandText = "PR_MOM_MeetingType_SelectByPK";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@MeetingTypeID", MeetingTypeID);

                sqlConnection.Open();
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        model.MeetingTypeID = Convert.ToInt32(reader["MeetingTypeID"]);
                        model.MeetingTypeName = reader["MeetingTypeName"].ToString();
                        model.Remarks = reader["Remarks"].ToString();
                    }
                }
            }
            return View(model);
        }
        #endregion

        #region Edit Operattion
        [HttpPost]
        public IActionResult MeetingTypeEditForm(MeetingTypeModel model)
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

                    sqlCommand.CommandText = "PR_MOM_MeetingType_UpdateByPK";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@MeetingTypeID", model.MeetingTypeID);
                    sqlCommand.Parameters.AddWithValue("@MeetingTypeName", model.MeetingTypeName);
                    sqlCommand.Parameters.AddWithValue("@Remarks", model.Remarks);
                    sqlCommand.Parameters.AddWithValue("@Modified", model.Modified);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }


                TempData["SucessMessage"] = "MeetingType Updated Successfully";
                return RedirectToAction("MeetingTypeList");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(model);
            }
        }
        #endregion


        #region Get Detail
        [HttpGet]
        public IActionResult MeetingTypeView(int MeetingTypeID)
        {
            MeetingTypeModel model = new MeetingTypeModel();

            string sqlConnString = _configuration.GetConnectionString("DefaultConnection");
            using (var sqlConnection = new SqlConnection(sqlConnString))
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "PR_MOM_MeetingType_SelectByPK";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MeetingTypeID", MeetingTypeID);

                sqlConnection.Open();
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        model.MeetingTypeID = Convert.ToInt32(reader["MeetingTypeID"]);
                        model.MeetingTypeName = reader["MeetingTypeName"].ToString();
                        model.Remarks = reader["Remarks"].ToString();
                        model.Created = Convert.ToDateTime(reader["Created"]);
                        model.Modified = Convert.ToDateTime(reader["Modified"]);
                    }
                }
            }
            return View(model);
        }
        #endregion



        #region Get MeetingType Data For Delete Operation
        [HttpGet]
        public IActionResult MeetingTypeDeleteForm(int MeetingTypeID)
        {
            MeetingTypeModel model = new MeetingTypeModel();

            string sqlConnString = _configuration.GetConnectionString("DefaultConnection");

            using (var sqlConnection = new SqlConnection(sqlConnString))
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "PR_MOM_MeetingType_SelectByPK";

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MeetingTypeID", MeetingTypeID);

                sqlConnection.Open();
                using (var reader = sqlCommand.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        model.MeetingTypeID = Convert.ToInt32(reader["MeetingTypeID"]);
                        model.MeetingTypeName = reader["MeetingTypeName"].ToString();
                        model.Remarks = reader["Remarks"].ToString();
                    }
                }
            }
            return View(model);
        }
        #endregion


        #region Delete Operation
        [HttpPost]
        public IActionResult MeetingTypeDeleteConfirm(int MeetingTypeID)
        {
            try
            {
                string sqlConnString = _configuration.GetConnectionString("DefaultConnection");

                using (var sqlConnection = new SqlConnection(sqlConnString))
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "PR_MOM_MeetingType_DeleteByPK";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@MeetingTypeID", MeetingTypeID);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                TempData["SucessMessage"] = "MeetingType Deleted Successfully";
            }
            catch
            {
                TempData["ErrorMessage"] =
                    "Cannot delete this MeetingType because it is referenced by other records.";
            }

            return RedirectToAction("MeetingTypeList");
        }
        #endregion
    }
}
