using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium2.Migrations
{
    public partial class SeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "IdArtist", "Nickname" },
                values: new object[,]
                {
                    { 1, "Artist1" },
                    { 2, "Artist2" },
                    { 3, "Artist3" },
                    { 4, "Artist4" }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "IdEvent", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event1", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event2", new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2020, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event3", new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2020, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event4", new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2020, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event5", new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Organiser",
                columns: new[] { "IdOrganiser", "Name" },
                values: new object[,]
                {
                    { 1, "Organiser1" },
                    { 2, "Organiser2" },
                    { 3, "Organiser3" },
                    { 4, "Organiser4" }
                });

            migrationBuilder.InsertData(
                table: "Artist_Event",
                columns: new[] { "IdEvent", "IdArtist", "PerfomanceDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 3, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Event_Organiser",
                columns: new[] { "IdEvent", "IdOrganiser" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "IdArtist",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Artist_Event",
                keyColumns: new[] { "IdEvent", "IdArtist" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Artist_Event",
                keyColumns: new[] { "IdEvent", "IdArtist" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Artist_Event",
                keyColumns: new[] { "IdEvent", "IdArtist" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Artist_Event",
                keyColumns: new[] { "IdEvent", "IdArtist" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "IdEvent",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Event_Organiser",
                keyColumns: new[] { "IdEvent", "IdOrganiser" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Event_Organiser",
                keyColumns: new[] { "IdEvent", "IdOrganiser" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Event_Organiser",
                keyColumns: new[] { "IdEvent", "IdOrganiser" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Event_Organiser",
                keyColumns: new[] { "IdEvent", "IdOrganiser" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Organiser",
                keyColumn: "IdOrganiser",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "IdArtist",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "IdArtist",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artist",
                keyColumn: "IdArtist",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "IdEvent",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "IdEvent",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "IdEvent",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "IdEvent",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Organiser",
                keyColumn: "IdOrganiser",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organiser",
                keyColumn: "IdOrganiser",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Organiser",
                keyColumn: "IdOrganiser",
                keyValue: 4);
        }
    }
}
