using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class userpictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"create procedure[dbo].[messagepictures]
            @email varchar(50)
            as
            select ImageURL from AspNetUsers inner join WriterMessages on AspNetUsers.Email = WriterMessages.Sender where WriterMessages.Sender = @email";

            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
