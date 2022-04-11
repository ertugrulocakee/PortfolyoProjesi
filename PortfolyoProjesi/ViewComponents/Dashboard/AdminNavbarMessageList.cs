using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList : ViewComponent
    {

        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDAL());

        private readonly UserManager<WriterUser> _userManager;

        public AdminNavbarMessageList(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
                                           
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var values = writerMessageManager.GetListReceiveMessage(user.Email).OrderByDescending(x=>x.Date).Take(5).ToList();
  
            return View(new Tuple<List<String>,List<WriterMessage>>(pictures(user.Email),values));  

        }


        protected List<String> pictures(string email)
        {

            List<String> userPictures = new List<String>(); 


            string connection = "server=DESKTOP-I1ODVGB;database=Portfolio;integrated security=true";
            string sql = "EXECUTE messagepictures @email = @p1";

            SqlConnection sqlConnection = new SqlConnection(connection);

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(sql,sqlConnection);

            sqlCommand.Parameters.AddWithValue("@p1", email);

            SqlDataReader dr = sqlCommand.ExecuteReader();

            while (dr.Read())
            {

                userPictures.Add(dr["ImageURL"].ToString());


            }

            dr.Close();

            sqlConnection.Close();

            return userPictures;

        }


    }
}
