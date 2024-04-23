using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aaltoenergia.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportNumber = table.Column<int>(type: "int", nullable: false),
                    PassportSeries = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "char(11)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PersonalSubscriptionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypeOfPayment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonalSubscriptionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment", x => x.PaymentID);
                });

            migrationBuilder.CreateTable(
                name: "subscriptionType",
                columns: table => new
                {
                    SubscriptionTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscriptionType", x => x.SubscriptionTypeID);
                });

            migrationBuilder.CreateTable(
                name: "trainer",
                columns: table => new
                {
                    TrainerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportNumber = table.Column<int>(type: "int", nullable: false),
                    PassportSeries = table.Column<int>(type: "int", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    Achievements = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "char(11)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainer", x => x.TrainerID);
                });

            migrationBuilder.CreateTable(
                name: "workoutType",
                columns: table => new
                {
                    WorkoutTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workoutType", x => x.WorkoutTypeID);
                });

            migrationBuilder.CreateTable(
                name: "visiting",
                columns: table => new
                {
                    VisitingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visiting", x => x.VisitingID);
                    table.ForeignKey(
                        name: "FK_visiting_client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subscription",
                columns: table => new
                {
                    SubscriptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubscriptionTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscription", x => x.SubscriptionID);
                    table.ForeignKey(
                        name: "FK_subscription_subscriptionType_SubscriptionTypeID",
                        column: x => x.SubscriptionTypeID,
                        principalTable: "subscriptionType",
                        principalColumn: "SubscriptionTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workout",
                columns: table => new
                {
                    WorkoutID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayOfTheWeek = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    LocationOfTheEvent = table.Column<int>(type: "int", nullable: false),
                    WorkoutTypeID = table.Column<int>(type: "int", nullable: false),
                    TrainerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workout", x => x.WorkoutID);
                    table.ForeignKey(
                        name: "FK_workout_trainer_TrainerID",
                        column: x => x.TrainerID,
                        principalTable: "trainer",
                        principalColumn: "TrainerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workout_workoutType_WorkoutTypeID",
                        column: x => x.WorkoutTypeID,
                        principalTable: "workoutType",
                        principalColumn: "WorkoutTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "personalSubscription",
                columns: table => new
                {
                    PersonalSubscriptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionID = table.Column<int>(type: "int", nullable: false),
                    PaymentID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personalSubscription", x => x.PersonalSubscriptionID);
                    table.ForeignKey(
                        name: "FK_personalSubscription_client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personalSubscription_payment_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "payment",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personalSubscription_subscription_SubscriptionID",
                        column: x => x.SubscriptionID,
                        principalTable: "subscription",
                        principalColumn: "SubscriptionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "сlientWorkout",
                columns: table => new
                {
                    ClientWorkoutID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    WorkoutID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_сlientWorkout", x => x.ClientWorkoutID);
                    table.ForeignKey(
                        name: "FK_сlientWorkout_client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_сlientWorkout_workout_WorkoutID",
                        column: x => x.WorkoutID,
                        principalTable: "workout",
                        principalColumn: "WorkoutID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_сlientWorkout_ClientID",
                table: "сlientWorkout",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_сlientWorkout_WorkoutID",
                table: "сlientWorkout",
                column: "WorkoutID");

            migrationBuilder.CreateIndex(
                name: "IX_personalSubscription_ClientID",
                table: "personalSubscription",
                column: "ClientID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_personalSubscription_PaymentID",
                table: "personalSubscription",
                column: "PaymentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_personalSubscription_SubscriptionID",
                table: "personalSubscription",
                column: "SubscriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_subscription_SubscriptionTypeID",
                table: "subscription",
                column: "SubscriptionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_visiting_ClientID",
                table: "visiting",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_workout_TrainerID",
                table: "workout",
                column: "TrainerID");

            migrationBuilder.CreateIndex(
                name: "IX_workout_WorkoutTypeID",
                table: "workout",
                column: "WorkoutTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "сlientWorkout");

            migrationBuilder.DropTable(
                name: "personalSubscription");

            migrationBuilder.DropTable(
                name: "visiting");

            migrationBuilder.DropTable(
                name: "workout");

            migrationBuilder.DropTable(
                name: "payment");

            migrationBuilder.DropTable(
                name: "subscription");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "trainer");

            migrationBuilder.DropTable(
                name: "workoutType");

            migrationBuilder.DropTable(
                name: "subscriptionType");
        }
    }
}
