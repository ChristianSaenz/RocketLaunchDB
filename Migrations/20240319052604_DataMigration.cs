using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rocket_Launch_Database__2_.Migrations
{
    /// <inheritdoc />
    public partial class DataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LaunchSite",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 3, "USA", "Cape Canaveral" },
                    { 4, "USA", "Vandenberg" },
                    { 5, "Russia", "Plesetsk" },
                    { 6, "Kazakhstan", "Baikonur" },
                    { 7, "French Guiana", "Guiana Space Centre" },
                    { 8, "Japan", "Tanegashima" },
                    { 9, "India", "Satish Dhawan" },
                    { 10, "China", "Jiuquan" },
                    { 11, "China", "Taiyuan" },
                    { 12, "USA", "Wallops Flight Facility" },
                    { 13, "Marshall Islands", "Omelek Island" },
                    { 14, "USA", "Kodiak Launch Complex" },
                    { 15, "USA", "Mid-Atlantic Regional Spaceport" },
                    { 16, "South Korea", "Naro Space Center" },
                    { 17, "Israel", "Palmachim Airbase" },
                    { 18, "North Korea", "Sohae Satellite Launching Station" },
                    { 19, "Russia", "Vostochny Cosmodrome" },
                    { 20, "China", "Wenchang Satellite Launch Center" }
                });

            migrationBuilder.InsertData(
                table: "LaunchVehicle",
                columns: new[] { "Id", "Manufacturer", "Name" },
                values: new object[,]
                {
                    { 3, "ULA", "Atlas V" },
                    { 4, "ULA", "Delta IV" },
                    { 5, "Arianespace", "Ariane 5" },
                    { 6, "Arianespace", "Vega" },
                    { 7, "Mitsubishi Heavy Industries", "H-IIA" },
                    { 8, "Mitsubishi Heavy Industries", "H-IIB" },
                    { 9, "Northrop Grumman", "Antares" },
                    { 10, "SpaceX", "Falcon Heavy" },
                    { 11, "Rocket Lab", "Electron" },
                    { 12, "Northrop Grumman", "Pegasus" },
                    { 13, "Northrop Grumman", "Minotaur" },
                    { 14, "Khrunichev", "Proton" },
                    { 15, "CASC", "Long March 2D" },
                    { 16, "CASC", "Long March 3B" },
                    { 17, "CASC", "Long March 5" },
                    { 18, "CASC", "Long March 7" },
                    { 19, "Blue Origin", "New Shepard" },
                    { 20, "SpaceX", "Starship" }
                });

            migrationBuilder.InsertData(
                table: "Payload",
                columns: new[] { "Id", "Name", "Type", "Weight" },
                values: new object[,]
                {
                    { 3, "Communication Satellite 1", "Satellite", 2000m },
                    { 4, "Communication Satellite 2", "Satellite", 1800m },
                    { 5, "Earth Observation Satellite 1", "Satellite", 1200m },
                    { 6, "Earth Observation Satellite 2", "Satellite", 1500m },
                    { 7, "Navigation Satellite 1", "Satellite", 1400m },
                    { 8, "Navigation Satellite 2", "Satellite", 1600m },
                    { 9, "Scientific Satellite 1", "Satellite", 1300m },
                    { 10, "Scientific Satellite 2", "Satellite", 1100m },
                    { 11, "Lunar Probe 1", "Probe", 800m },
                    { 12, "Lunar Probe 2", "Probe", 850m },
                    { 13, "Mars Rover 1", "Rover", 900m },
                    { 14, "Mars Rover 2", "Rover", 950m },
                    { 15, "Space Telescope 1", "Telescope", 2000m },
                    { 16, "Space Telescope 2", "Telescope", 2100m },
                    { 17, "Space Station Module 1", "Module", 4200m },
                    { 18, "Space Station Module 2", "Module", 4300m },
                    { 19, "Interplanetary Probe 1", "Probe", 3000m },
                    { 20, "Interplanetary Probe 2", "Probe", 3200m }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 3, "charlie@example.com", "Charlie" },
                    { 4, "david@example.com", "David" },
                    { 5, "eve@example.com", "Eve" },
                    { 6, "frank@example.com", "Frank" },
                    { 7, "grace@example.com", "Grace" },
                    { 8, "hannah@example.com", "Hannah" },
                    { 9, "ivan@example.com", "Ivan" },
                    { 10, "judy@example.com", "Judy" },
                    { 11, "kevin@example.com", "Kevin" },
                    { 12, "laura@example.com", "Laura" },
                    { 13, "mike@example.com", "Mike" },
                    { 14, "nina@example.com", "Nina" },
                    { 15, "oscar@example.com", "Oscar" },
                    { 16, "pam@example.com", "Pam" },
                    { 17, "quinn@example.com", "Quinn" },
                    { 18, "rob@example.com", "Rob" },
                    { 19, "sara@example.com", "Sara" },
                    { 20, "tom@example.com", "Tom" }
                });

            migrationBuilder.InsertData(
                table: "RocketLaunches",
                columns: new[] { "Id", "LaunchDate", "LaunchSiteId", "LaunchVehicleId", "MissionOutcome", "PayloadId", "UserId" },
                values: new object[,]
                {
                    { 3, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "Success", 3, 3 },
                    { 4, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, "Failure", 4, 4 },
                    { 5, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, "Success", 5, 5 },
                    { 6, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 6, "Failure", 6, 6 },
                    { 7, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 7, "Success", 7, 7 },
                    { 8, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 8, "Failure", 8, 8 },
                    { 9, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 10, "Failure", 10, 10 },
                    { 10, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 9, "Success", 9, 9 },
                    { 11, new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 11, "Success", 11, 11 },
                    { 12, new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 12, "Failure", 12, 12 },
                    { 13, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 13, "Success", 13, 13 },
                    { 14, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 14, "Failure", 14, 14 },
                    { 15, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 15, "Success", 15, 15 },
                    { 16, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 16, "Failure", 16, 16 },
                    { 17, new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 17, "Success", 17, 17 },
                    { 18, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 18, "Failure", 18, 18 },
                    { 19, new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 19, "Success", 19, 19 },
                    { 20, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 20, "Failure", 20, 20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RocketLaunches",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RocketLaunches",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RocketLaunches",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RocketLaunches",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RocketLaunches",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RocketLaunches",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RocketLaunches",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RocketLaunches",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RocketLaunches",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RocketLaunches",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RocketLaunches",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "RocketLaunches",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "RocketLaunches",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "RocketLaunches",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "RocketLaunches",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "RocketLaunches",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "RocketLaunches",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "RocketLaunches",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "LaunchSite",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LaunchSite",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LaunchSite",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LaunchSite",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LaunchSite",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "LaunchSite",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "LaunchSite",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "LaunchSite",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "LaunchSite",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "LaunchSite",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "LaunchSite",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "LaunchSite",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "LaunchSite",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "LaunchSite",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "LaunchSite",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "LaunchSite",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "LaunchSite",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "LaunchSite",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "LaunchVehicle",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LaunchVehicle",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LaunchVehicle",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LaunchVehicle",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LaunchVehicle",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "LaunchVehicle",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "LaunchVehicle",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "LaunchVehicle",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "LaunchVehicle",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "LaunchVehicle",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "LaunchVehicle",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "LaunchVehicle",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "LaunchVehicle",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "LaunchVehicle",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "LaunchVehicle",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "LaunchVehicle",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "LaunchVehicle",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "LaunchVehicle",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Payload",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Payload",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Payload",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Payload",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Payload",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Payload",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Payload",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Payload",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Payload",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Payload",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Payload",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Payload",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Payload",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Payload",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Payload",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Payload",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Payload",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Payload",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
