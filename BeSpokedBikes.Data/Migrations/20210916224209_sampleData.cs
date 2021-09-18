using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeSpokedBikes.Data.Migrations
{
    public partial class sampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "FirstName", "LastName", "Phone", "StartDate" },
                values: new object[,]
                {
                    { 1, "233 Whos Street, Whos City, TN 37356", "Tom", "Milton", "(555)557-5577", new DateTime(2021, 9, 16, 18, 42, 8, 766, DateTimeKind.Local).AddTicks(2664) },
                    { 2, "322 That Street, That City, PA 39601", "Jim", "Harison", "(555)559-9577", new DateTime(2021, 9, 16, 18, 42, 8, 766, DateTimeKind.Local).AddTicks(2895) },
                    { 3, "966 Whos Street, Whos City, TN 37356", "Kelly", "Belly", "(555)551-5511", new DateTime(2021, 9, 16, 18, 42, 8, 766, DateTimeKind.Local).AddTicks(2902) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CommissionPercentage", "Manufacture", "Name", "PurchasePrice", "QtyOnHand", "SalePrice", "Style" },
                values: new object[,]
                {
                    { 1, 0.14999999999999999, "Manufacturer1", "Product1", 100.0, 10, 100.0, "Style1" },
                    { 2, 0.20000000000000001, "Manufacturer2", "Product2", 200.0, 5, 170.0, "Style2" },
                    { 3, 0.33000000000000002, "Manufacturer3", "Product3", 200.0, 500, 300.0, "Style3" },
                    { 4, 0.33000000000000002, "Manufacturer3", "Product4", 200.0, 0, 300.0, "Style3" }
                });

            migrationBuilder.InsertData(
                table: "SalesPersons",
                columns: new[] { "Id", "Address", "FirstName", "LastName", "Manager", "Phone", "StartDate", "TerminationDate" },
                values: new object[,]
                {
                    { 1, "455 The Street, The City, GA 30107", "John", "Doe", "Johnson", "(555)555-5555", new DateTime(2021, 9, 16, 18, 42, 8, 764, DateTimeKind.Local).AddTicks(2751), null },
                    { 2, "455 The Street, The City, GA 30107", "Jane", "Doe", "Johnson", "(555)555-5555", new DateTime(2021, 9, 16, 18, 42, 8, 766, DateTimeKind.Local).AddTicks(871), null },
                    { 3, "544 My Street, My City, GA 30107", "Brian", "Haynes", "Henry", "(555)556-5555", new DateTime(2021, 9, 16, 18, 42, 8, 766, DateTimeKind.Local).AddTicks(895), new DateTime(2021, 9, 16, 18, 42, 8, 766, DateTimeKind.Local).AddTicks(898) }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeginDate", "DiscountPercentage", "EndDate", "ProductId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.20000000000000001, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.20000000000000001, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.10000000000000001, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.10000000000000001, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.050000000000000003, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.050000000000000003, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "CustomerId", "ProductId", "SaleDate", "SalesPersonId" },
                values: new object[,]
                {
                    { 9, 2, 3, new DateTime(2021, 9, 16, 18, 42, 8, 766, DateTimeKind.Local).AddTicks(4292), 2 },
                    { 8, 2, 3, new DateTime(2021, 9, 16, 18, 42, 8, 766, DateTimeKind.Local).AddTicks(4290), 2 },
                    { 7, 2, 3, new DateTime(2021, 9, 16, 18, 42, 8, 766, DateTimeKind.Local).AddTicks(4288), 2 },
                    { 6, 3, 3, new DateTime(2021, 9, 16, 18, 42, 8, 766, DateTimeKind.Local).AddTicks(4286), 2 },
                    { 3, 1, 3, new DateTime(2021, 9, 16, 18, 42, 8, 766, DateTimeKind.Local).AddTicks(4280), 1 },
                    { 4, 3, 1, new DateTime(2021, 9, 16, 18, 42, 8, 766, DateTimeKind.Local).AddTicks(4282), 1 },
                    { 11, 2, 3, new DateTime(2021, 9, 16, 18, 42, 8, 766, DateTimeKind.Local).AddTicks(4298), 2 },
                    { 2, 1, 2, new DateTime(2021, 9, 16, 18, 42, 8, 766, DateTimeKind.Local).AddTicks(4272), 1 },
                    { 1, 1, 1, new DateTime(2021, 9, 16, 18, 42, 8, 766, DateTimeKind.Local).AddTicks(4050), 1 },
                    { 5, 3, 2, new DateTime(2021, 9, 16, 18, 42, 8, 766, DateTimeKind.Local).AddTicks(4284), 2 },
                    { 10, 2, 3, new DateTime(2021, 9, 16, 18, 42, 8, 766, DateTimeKind.Local).AddTicks(4296), 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SalesPersons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SalesPersons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SalesPersons",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
