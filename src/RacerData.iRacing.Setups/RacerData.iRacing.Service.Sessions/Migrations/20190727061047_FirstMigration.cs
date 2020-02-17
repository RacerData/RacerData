using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RacerData.iRacing.Service.Sessions.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Length = table.Column<float>(nullable: false),
                    Banking = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ClassName = table.Column<string>(maxLength: 50, nullable: true),
                    ShortName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Season = table.Column<int>(nullable: false),
                    ActivityType = table.Column<int>(nullable: false),
                    TrackId = table.Column<long>(nullable: false),
                    VehicleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activities_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityId = table.Column<long>(nullable: false),
                    EnvironmentId = table.Column<long>(nullable: false),
                    iSessionId = table.Column<long>(nullable: false),
                    iSubSessionId = table.Column<long>(nullable: false),
                    SessionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Environments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SessionId = table.Column<long>(nullable: false),
                    Temperature = table.Column<float>(nullable: false),
                    TrackTemperature = table.Column<float>(nullable: false),
                    Sky = table.Column<string>(maxLength: 50, nullable: false),
                    Humidity = table.Column<float>(nullable: false),
                    TrackState = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Environments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Environments_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Runs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SessionId = table.Column<long>(nullable: false),
                    RunNumber = table.Column<int>(nullable: false),
                    SetupId = table.Column<long>(nullable: false),
                    PreviousSetupId = table.Column<long>(nullable: false),
                    TelemetryId = table.Column<long>(nullable: false),
                    DriverId = table.Column<long>(nullable: false),
                    Notes = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Runs_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Runs_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Laps",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RunId = table.Column<long>(nullable: false),
                    LapNumber = table.Column<int>(nullable: false),
                    OverallLapNumber = table.Column<int>(nullable: false),
                    LapTime = table.Column<float>(nullable: false),
                    LapSpeed = table.Column<float>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laps_Runs_RunId",
                        column: x => x.RunId,
                        principalTable: "Runs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Setups",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RunId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    FileName = table.Column<string>(maxLength: 50, nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Season = table.Column<int>(nullable: false),
                    VehicleId = table.Column<long>(nullable: false),
                    UpdateCount = table.Column<int>(nullable: false),
                    SetupData = table.Column<byte[]>(nullable: true),
                    ExportHtml = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Setups_Runs_RunId",
                        column: x => x.RunId,
                        principalTable: "Runs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Setups_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Telemetry",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RunId = table.Column<long>(nullable: false),
                    FileName = table.Column<string>(maxLength: 255, nullable: true),
                    Data = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telemetry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telemetry_Runs_RunId",
                        column: x => x.RunId,
                        principalTable: "Runs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TireReadings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RunId = table.Column<long>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    ColdPsi = table.Column<float>(nullable: false),
                    HotPsi = table.Column<float>(nullable: false),
                    TempInner = table.Column<float>(nullable: false),
                    TempMiddle = table.Column<float>(nullable: false),
                    TempOuter = table.Column<float>(nullable: false),
                    WearInner = table.Column<float>(nullable: false),
                    WearMiddle = table.Column<float>(nullable: false),
                    WearOuter = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TireReadings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TireReadings_Runs_RunId",
                        column: x => x.RunId,
                        principalTable: "Runs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TrackId",
                table: "Activities",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_VehicleId",
                table: "Activities",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Environments_SessionId",
                table: "Environments",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Laps_RunId",
                table: "Laps",
                column: "RunId");

            migrationBuilder.CreateIndex(
                name: "IX_Runs_DriverId",
                table: "Runs",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Runs_SessionId",
                table: "Runs",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Runs_TelemetryId",
                table: "Runs",
                column: "TelemetryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ActivityId",
                table: "Sessions",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_EnvironmentId",
                table: "Sessions",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Setups_RunId",
                table: "Setups",
                column: "RunId");

            migrationBuilder.CreateIndex(
                name: "IX_Setups_VehicleId",
                table: "Setups",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Telemetry_RunId",
                table: "Telemetry",
                column: "RunId");

            migrationBuilder.CreateIndex(
                name: "IX_TireReadings_RunId",
                table: "TireReadings",
                column: "RunId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Environments_EnvironmentId",
                table: "Sessions",
                column: "EnvironmentId",
                principalTable: "Environments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Runs_Telemetry_TelemetryId",
                table: "Runs",
                column: "TelemetryId",
                principalTable: "Telemetry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Tracks_TrackId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Vehicles_VehicleId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Environments_Sessions_SessionId",
                table: "Environments");

            migrationBuilder.DropForeignKey(
                name: "FK_Runs_Sessions_SessionId",
                table: "Runs");

            migrationBuilder.DropForeignKey(
                name: "FK_Telemetry_Runs_RunId",
                table: "Telemetry");

            migrationBuilder.DropTable(
                name: "Laps");

            migrationBuilder.DropTable(
                name: "Setups");

            migrationBuilder.DropTable(
                name: "TireReadings");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Environments");

            migrationBuilder.DropTable(
                name: "Runs");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Telemetry");
        }
    }
}
