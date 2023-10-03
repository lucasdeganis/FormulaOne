using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Presistence.Scripts
{
    public class StoresProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE GetUsersByUserAndPassword
                                (
                                    @UserName varchar(50),
                                    @Password varchar(50)
                                )
                                AS
                                BEGIN
                                    SELECT Id, FirstName, LastName, UserName, Role, NULL as Password
                                    FROM Users
                                    WHERE UserName = @UserName and Password = @Password
                                END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE GetUsersByUserAndPassword");
        }
    }
}
