using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MOM_Project.Models;
using System.Data;

namespace MOM_Project.Controllers
{
    public class MeetingVenueController : Controller
    {
        #region Configuration Injection
        private readonly IConfiguration _configuration;
        public MeetingVenueController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion



        #region Get All MeetingVenue
        [HttpGet]
        public IActionResult MeetingVenueList()
        {
            List<MeetingVenueModel> meetingVenueList = new List<MeetingVenueModel>();
            string sqlConnString = _configuration.GetConnectionString("DefaultConnection");
            using (var sqlConnection = new SqlConnection(sqlConnString))
            using (var sqlCommand = sqlConnection.CreateCommand())
            {

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "PR_MOM_MeetingVenue_SelectAll";

                sqlConnection.Open();
                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var mv = new MeetingVenueModel
                        {
                            MeetingVenueID = Convert.ToInt32(reader["MeetingVenueID"]),
                            MeetingVenueName = reader["MeetingVenueName"].ToString(),
                            Created = Convert.ToDateTime(reader["Created"]),
                            Modified = Convert.ToDateTime(reader["Modified"])
                        };
                        meetingVenueList.Add(mv);
                    }
                }
            }
            return View("MeetingVenueList", meetingVenueList);
        }
        #endregion

        public IActionResult MeetingVenueAdd()
        {
            return View();
        }

        #region Add MeetingVenue Operation
        [HttpPost]
        public IActionResult MeetingVenueAdd(MeetingVenueModel model)
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
                    sqlCommand.CommandText = "PR_MOM_MeetingVenue_Insert";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@MeetingVenueName", model.MeetingVenueName);
                    sqlCommand.Parameters.AddWithValue("@Modified", model.Modified);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();

                }

                TempData["SucessMessage"] = "Record Inserted Successfully";
                return RedirectToAction("MeetingVenueList");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(model);
            }
        }
        #endregion




        #region Get MeetingVenue Data For Edit MeetingVenue Operation
        [HttpGet]
        public IActionResult MeetingVenueEditForm(int MeetingVenueID)
        {   
            MeetingVenueModel model = new MeetingVenueModel();

            string sqlConnString = _configuration.GetConnectionString("DefaultConnection");
            using (var sqlConnection = new SqlConnection(sqlConnString))
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandText = "PR_MOM_MeetingVenue_SelectByPK";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@MeetingVenueID", MeetingVenueID);

                sqlConnection.Open();
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        model.MeetingVenueID = Convert.ToInt32(reader["MeetingVenueID"]);
                        model.MeetingVenueName = reader["MeetingVenueName"].ToString();
                    }
                }
            }
            return View(model);
        }
        #endregion

        #region Edit Operation
        [HttpPost]
        public IActionResult MeetingVenueEditForm(MeetingVenueModel model)
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

                    sqlCommand.CommandText = "PR_MOM_MeetingVenue_UpdateByPK";
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@MeetingVenueID", model.MeetingVenueID);
                    sqlCommand.Parameters.AddWithValue("@MeetingVenueName", model.MeetingVenueName);
                    sqlCommand.Parameters.AddWithValue("@Modified", model.Modified);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }


                TempData["SucessMessage"] = "MeetingVenue Updated Successfully";
                return RedirectToAction("MeetingVenueList");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(model);
            }
        }
        #endregion

        #region View Detail
        [HttpGet]
        public IActionResult MeetingVenueView(int MeetingVenueID)
        {
            MeetingVenueModel model = new MeetingVenueModel();

            string sqlConnString = _configuration.GetConnectionString("DefaultConnection");
            using (var sqlConnection = new SqlConnection(sqlConnString))
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "PR_MOM_MeetingVenue_SelectByPK";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MeetingVenueID", MeetingVenueID);

                sqlConnection.Open();
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        model.MeetingVenueID = Convert.ToInt32(reader["MeetingVenueID"]);
                        model.MeetingVenueName = reader["MeetingVenueName"].ToString();
                        model.Created = Convert.ToDateTime(reader["Created"]);
                        model.Modified = Convert.ToDateTime(reader["Modified"]);
                    }
                }
            }
            return View(model);
        }
        #endregion

        #region Get MeetingVenue Data For Delete Operation
        [HttpGet]
        public IActionResult MeetingVenueDeleteForm(int MeetingVenueID)
        {
            MeetingVenueModel model = new MeetingVenueModel();

            string sqlConnString = _configuration.GetConnectionString("DefaultConnection");

            using (var sqlConnection = new SqlConnection(sqlConnString))
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "PR_MOM_MeetingVenue_SelectByPK";

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MeetingVenueID", MeetingVenueID);

                sqlConnection.Open();
                using (var reader = sqlCommand.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        model.MeetingVenueID = Convert.ToInt32(reader["MeetingVenueID"]);
                        model.MeetingVenueName = reader["MeetingVenueName"].ToString();
                    }
                }
            }
            return View(model);
        }
        #endregion

        #region Delete Operation
        [HttpPost]
        public IActionResult MeetingVenueDeleteConfirm(int MeetingVenueID)
        {
            try
            {
                string sqlConnString = _configuration.GetConnectionString("DefaultConnection");

                using (var sqlConnection = new SqlConnection(sqlConnString))
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "PR_MOM_MeetingVenue_DeleteByPK";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@MeetingVenueID", MeetingVenueID);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                TempData["SucessMessage"] = "MeetingVenue Deleted Successfully";
            }
            catch
            {
                TempData["ErrorMessage"] =
                    "Cannot delete this MeetingVenue because it is referenced by other records.";
            }

            return RedirectToAction("MeetingVenueList");
        }
        #endregion
    }
}
