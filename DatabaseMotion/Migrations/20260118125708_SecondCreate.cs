using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatabaseMotion.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotels_HotelNo1",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_HotelNo1",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "HotelNo1",
                table: "Rooms");

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelNo", "Name" },
                values: new object[,]
                {
                    { 1, "Grand Hotel" },
                    { 2, "Seaside inn" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomNo", "HotelNo", "Price", "Type" },
                values: new object[,]
                {
                    { 1, 1, 500m, "Single" },
                    { 2, 1, 700m, "Double" },
                    { 3, 2, 1200m, "Suite" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelNo",
                table: "Rooms",
                column: "HotelNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hotels_HotelNo",
                table: "Rooms",
                column: "HotelNo",
                principalTable: "Hotels",
                principalColumn: "HotelNo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotels_HotelNo",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_HotelNo",
                table: "Rooms");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomNo",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomNo",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomNo",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelNo",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelNo",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "HotelNo1",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelNo1",
                table: "Rooms",
                column: "HotelNo1");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hotels_HotelNo1",
                table: "Rooms",
                column: "HotelNo1",
                principalTable: "Hotels",
                principalColumn: "HotelNo");
        }
    }
}
