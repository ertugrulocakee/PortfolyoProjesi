using BusinessLayer.Concrete;
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
    public class SlideList : ViewComponent
    {

        PortfolioManager portfolioManager = new PortfolioManager(new EFPortfolioDAL());

        private readonly UserManager<WriterUser> _userManager;

        public SlideList(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            List<String> pictures = new List<String>();

            pictures.Add(picture(user.Email));

            var values = portfolioManager.TGetList().ToList();

            return View(new Tuple<List<String>, List<EntityLayer.Concrete.Portfolio>>(pictures, values));

        }


        protected String picture(String email)
        {

            String picture = "";


            string connection = "server=DESKTOP-I1ODVGB;database=Portfolio;integrated security=true";
            string sql = "execute adminimage @email = @p1";

            SqlConnection sqlConnection = new SqlConnection(connection);

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@p1", email);

            SqlDataReader dr = sqlCommand.ExecuteReader();

            while (dr.Read())
            {

                picture = dr["ImageURL"].ToString();


            }

            dr.Close();

            sqlConnection.Close();

            return picture;

        }



    }
}
