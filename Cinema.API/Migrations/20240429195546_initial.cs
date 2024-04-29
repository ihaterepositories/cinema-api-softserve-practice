using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cinema.API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Photo = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GenreName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: false),
                    StartAiringDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    EndAiringDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Trailer = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Duration = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    Photo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoomName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    NumberOfSeats = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ActorId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MovieActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GenreId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => new { x.MovieId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MovieGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Screenings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MovieId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoomId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ScreeningStart = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screenings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screenings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Screenings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Row = table.Column<int>(type: "INTEGER", nullable: false),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Reserved = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsPaid = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservedSeats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReservationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SeatId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ScreeningId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservedSeats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservedSeats_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservedSeats_Screenings_ScreeningId",
                        column: x => x.ScreeningId,
                        principalTable: "Screenings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservedSeats_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Description", "FullName", "Photo" },
                values: new object[,]
                {
                    { new Guid("0853687d-e8fe-a480-c234-ec19cb493153"), "Eius quidem enim voluptatem cum.\nEst quam quis aliquam maiores aut aliquid qui.\nAb distinctio possimus corporis quibusdam qui qui.\nEt et laboriosam error amet rerum ab alias doloribus.", "Rhoda Wuckert", "http://simone.name" },
                    { new Guid("1e48bab1-ba02-5ae7-1091-d24cb29d1889"), "Non quidem dolorem sed impedit.\nRepellendus deleniti voluptas nihil.\nDistinctio illo nihil illum eaque et autem ad non.\nConsequatur exercitationem nihil maiores corrupti culpa dolores ut.\nEt totam vitae nam et laboriosam.", "Efren Toy", "http://wilford.org" },
                    { new Guid("2d07ed24-a1d9-f14e-3041-3f3c170ed6c3"), "Odit nam eius.\nSint provident omnis accusamus ipsum vel optio aperiam sunt nam.\nVoluptatum consequuntur aliquam sed nihil est veritatis.\nDeserunt et quia debitis.\nRepellendus sed maiores cumque perferendis aliquid aut.", "Jermey Hand", "http://germaine.net" },
                    { new Guid("2f06addf-8f0f-b189-fe91-9a898a324d66"), "Cupiditate rem iste porro provident.\nProvident officia expedita consectetur dicta et nostrum sit.\nEt fugit blanditiis omnis.\nLaudantium tempore labore a officia nam quam.\nMaxime nihil ratione eum.", "Brianne Vandervort", "https://adan.info" },
                    { new Guid("30a82556-fa16-af90-ce76-e264e292e472"), "Expedita fugiat ea aut.\nAut dolorum sint quas impedit itaque magnam.\nA quas ut illo fugit saepe.\nNecessitatibus aliquam quod.\nFacere fugit ut assumenda saepe quas eius et placeat dolores.", "Vern Buckridge", "http://missouri.name" },
                    { new Guid("41189c4e-3ec4-34c1-f297-e68c859dca29"), "Ut sit rerum accusamus.\nEt veritatis neque quia et tenetur sunt possimus in qui.", "Lenna Ebert", "https://amos.com" },
                    { new Guid("43143429-74be-878a-a826-ed07c0af082a"), "Accusantium odit voluptatem nulla accusamus nihil.\nEt aut minus rerum.\nQuia omnis quia consectetur.\nAliquid perspiciatis consectetur inventore voluptatem eligendi consequatur tenetur consequatur.\nEius est dignissimos dolores vel vero aliquid iste quisquam et.", "Ebba Jones", "http://veda.name" },
                    { new Guid("498db59e-5f0f-ffd1-5e72-6efabee6f969"), "Autem exercitationem tempora architecto sed cum magnam.\nNobis at aut minus delectus ipsam labore.", "Florian Daugherty", "https://alice.name" },
                    { new Guid("50162e71-5204-43ed-270b-0ce94fc646f9"), "Culpa qui sed repudiandae voluptas ut.\nVeritatis veritatis optio ea.\nQuo praesentium et voluptatem earum voluptatem a non id ipsam.", "Jany D'Amore", "http://casimir.org" },
                    { new Guid("523b1ee4-3977-d633-b1e9-3fc1a4157ce5"), "Eveniet officia ut.\nId animi id odio qui et ut repudiandae quaerat dolore.\nEnim dolorum ea expedita atque ut et.\nQui rem aut nisi enim reiciendis dolor consequatur.\nQuos consectetur architecto assumenda enim.", "Michael Emard", "https://reta.com" },
                    { new Guid("554a7740-beaf-3350-68ea-f18322a06afc"), "Molestiae quia voluptas libero.\nAut perspiciatis ipsa hic et quas.\nNon ea sapiente autem vitae explicabo sint dolorem temporibus ut.\nQuia autem rem sed dolores voluptatum et.\nAut reprehenderit aspernatur tempora voluptas tenetur perspiciatis quibusdam.", "Kobe Aufderhar", "https://otilia.info" },
                    { new Guid("6199fd49-d263-cb16-1f7d-ab2c814e2b42"), "Fugiat eaque non et vel.\nEos tempore odit aut.\nDeserunt qui voluptatem neque et veniam libero consequuntur porro.", "Elroy Dare", "https://adrienne.com" },
                    { new Guid("64b16995-0cd9-f3f1-625d-cf64a5042f59"), "Consequatur voluptatem perspiciatis voluptatem aperiam vel ipsa.\nIpsum amet cupiditate.", "Leora Treutel", "https://alexandre.net" },
                    { new Guid("6ba03eb3-49e5-a462-f72f-8c278027a292"), "Omnis qui reprehenderit cumque illum iusto officia labore dolores.\nAut velit neque culpa.", "Giles Collins", "http://joaquin.name" },
                    { new Guid("7dce468d-1b3d-2bf0-adc1-d49880563a93"), "Dicta odit rerum quas consequatur ipsam.\nDolores corporis est et quia dolorem quisquam.\nMolestiae accusantium iusto quia enim quia.\nVelit sit itaque quia omnis officia.\nUt rem accusamus ratione ab voluptas sed excepturi.\nCum eligendi ut eligendi.", "Candace O'Connell", "http://dawson.name" },
                    { new Guid("81ad07ac-cc65-e61d-6ca1-49a9e1222ef5"), "Eum incidunt consequatur sit enim.\nDicta ratione neque dicta consequatur iure reprehenderit deserunt.\nEt ratione eum quis.\nQui aliquam dolorem sit possimus nesciunt sunt libero.\nEt rem reprehenderit omnis.\nEt eveniet eos voluptatem ut modi ut.", "Lera Price", "http://mavis.net" },
                    { new Guid("90977f20-6e67-bd4a-a8b6-1ab836e132cb"), "Est ut officia ullam quos quod.\nAb sint pariatur hic velit cum vero.\nAssumenda veniam sequi repellendus.\nNihil quasi quia.\nIn quis soluta consequatur ullam quia et similique ea sapiente.", "Timmy Dickens", "https://rogelio.info" },
                    { new Guid("a4ff575f-9048-afab-794b-db81b7f6d5bc"), "Quidem est sed sed fuga.\nConsectetur praesentium sit aut molestiae.\nAccusantium dolor vel libero.", "Samantha Leffler", "http://freda.net" },
                    { new Guid("b216c89c-e2ec-38e8-67e8-2fff397f9e02"), "Molestiae ad maiores autem.\nNihil rerum ea id repellat.\nIllo ut tempora ab deleniti nam fugit.\nVoluptatum quaerat sit id id voluptate.", "Skye Altenwerth", "http://murl.biz" },
                    { new Guid("b50fd31e-6e92-82d4-af4f-57d81ab47b4a"), "Id ut pariatur quaerat optio et vero tempora quis.\nVel omnis molestias non consequatur aliquam corporis.\nEt suscipit reiciendis cupiditate quia ex omnis et autem placeat.\nAut asperiores unde facere officiis.\nUnde maiores sapiente accusantium.\nSunt quae occaecati quisquam labore fugiat qui.", "Orville Mueller", "https://karlee.biz" },
                    { new Guid("c01fad07-e9b3-ae9c-1f88-d33875663caa"), "Sed ut aut qui non et ut asperiores.\nRepellendus dolores consequatur omnis hic.\nDolores qui quaerat accusamus quis veniam.\nUllam blanditiis est quo id cumque nam omnis necessitatibus sint.\nIure id omnis et enim rem qui voluptate.", "Annette VonRueden", "https://emely.net" },
                    { new Guid("c52ada7a-ab0f-fe9a-1d0c-f8298f0121c3"), "Sit ipsam nihil iste voluptates.\nRerum saepe dignissimos delectus et mollitia.\nDeleniti et ut repellat.\nDoloribus autem laborum.", "Hazle Watsica", "http://ulices.info" },
                    { new Guid("cc7e4d4b-57e6-36d9-bfa6-cba9b63b2e63"), "Rerum hic consequuntur fugiat.\nSapiente repellendus quia.\nEst voluptate ipsa exercitationem.\nEst tempora quia perferendis soluta quas officia quia repudiandae doloremque.\nAliquam molestias cum exercitationem corrupti quos rerum ducimus voluptas quo.\nQuas a molestiae consequatur ipsum animi.", "Clark Grady", "https://wyatt.com" },
                    { new Guid("d4534672-3c09-c145-63da-d8fbbe2c7ea7"), "Odio voluptates dicta rem laborum rerum.\nCum soluta repellat excepturi nisi totam pariatur nostrum voluptas.", "Antwon Rogahn", "http://frederick.org" },
                    { new Guid("dcfa5ed4-a419-7a6c-105f-a4ee65730078"), "Totam est odit aut quasi.\nA laboriosam vel nesciunt beatae cum praesentium et.\nCommodi quo suscipit quisquam deserunt quod fugiat voluptate animi.\nUt veritatis nam officiis eaque hic quia aliquam.\nQuam nesciunt exercitationem ducimus nemo non.", "Audie Reynolds", "http://haylie.org" },
                    { new Guid("e0923758-4a63-7094-c482-99bf41b34fbf"), "Est eveniet eos.\nSed eveniet optio sed voluptatum nulla quasi.\nDucimus voluptas quibusdam consequatur dolorem neque voluptate perspiciatis.\nAspernatur dolorem animi illo aut.", "Estell Kerluke", "https://roselyn.org" },
                    { new Guid("ee93ec18-2c2e-1e29-86c8-950cf210617b"), "Dolorem illo fugit numquam.\nExpedita esse impedit enim qui iure labore illum quia iusto.", "Tevin Gulgowski", "https://jevon.name" },
                    { new Guid("f6d44886-1e3b-3543-5c60-4c94bfe640b6"), "Aliquam ea atque.\nQuis consequatur non ut.\nPlaceat qui aspernatur officia minus voluptas cumque.", "Kylie Dach", "http://javonte.biz" },
                    { new Guid("fb20b70b-3bb3-a0e3-ce6f-639fc56e6b19"), "Non vero pariatur omnis et blanditiis voluptatibus ut sed sit.\nIncidunt molestias quis sit aut quasi.\nSed quaerat illum sed esse.\nOdit delectus sed ullam illo iusto.\nSuscipit eos placeat exercitationem laudantium.", "Zola Murray", "https://naomie.info" },
                    { new Guid("fbbdfcdb-5c18-f7e4-e966-753c3da72902"), "Unde ipsum voluptate.\nPerspiciatis deserunt ipsum aut asperiores labore id ea ex repellat.\nRecusandae hic nostrum.\nNisi magnam dolores.\nSit delectus non reprehenderit error error.", "Jeramy Bergstrom", "http://antonia.biz" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { new Guid("03023299-69cb-8b85-2f0e-a021c46dac3a"), "Latin" },
                    { new Guid("04c1e8f3-d3e8-9580-6f12-13ec5eb753b4"), "Latin" },
                    { new Guid("1ac09dd4-2130-0b14-72bf-42874a9fc995"), "Blues" },
                    { new Guid("1b22f642-2e19-6ed1-b750-44ace454e4ab"), "Classical" },
                    { new Guid("1bdda020-15d7-a21b-de6f-64f9ee0e451f"), "Blues" },
                    { new Guid("2a5522f8-17c2-7dc1-8565-9b91171c9e45"), "Soul" },
                    { new Guid("3696c77b-2040-bf4c-b8f2-0f4f19c3783b"), "Soul" },
                    { new Guid("385a7b5f-7ca9-dd38-353e-3f79c37749c3"), "Stage And Screen" },
                    { new Guid("4fa7670d-4850-9084-b917-70166e0f16e9"), "Pop" },
                    { new Guid("583ca71e-d218-b120-737b-2e490889356a"), "Blues" },
                    { new Guid("5da6bbc5-4f35-5c68-5320-35aaa17653d8"), "Pop" },
                    { new Guid("5e5d4bbf-5124-759f-e7fd-1eed477469f3"), "Folk" },
                    { new Guid("68edfff7-379d-8f05-5eb3-546a3cb47477"), "Jazz" },
                    { new Guid("6ec85fe4-2ca8-ac81-b887-023404087f91"), "Country" },
                    { new Guid("79622f63-da70-b336-3bf2-e7285c9315b9"), "Latin" },
                    { new Guid("8d3e36d0-8dbd-57e7-a236-5b6d512044c5"), "Electronic" },
                    { new Guid("98d377b1-9956-fb89-a23b-995c113275d1"), "Rock" },
                    { new Guid("9b3a1161-c29b-3a46-758e-b5927dd21d46"), "Reggae" },
                    { new Guid("9e9c0966-c70e-d74d-0d2b-518a231162c0"), "Reggae" },
                    { new Guid("a44793d1-d551-d5e1-a66a-1d5d265c0adc"), "Latin" },
                    { new Guid("a5b0cd69-d564-c75f-8020-ce103cc95965"), "Funk" },
                    { new Guid("b398995c-337e-0dbc-e91d-b25eb8c4257d"), "Folk" },
                    { new Guid("c3b7b628-eb85-18cd-bb8a-b787af3c2503"), "Stage And Screen" },
                    { new Guid("c4a4ced9-b5bc-82f0-b43d-396d08acd70d"), "Hip Hop" },
                    { new Guid("cc3303f4-952b-ce54-16d6-9d4b623e6bca"), "Funk" },
                    { new Guid("e0410a9d-8ca1-0b9f-c651-45f57e651aae"), "Rap" },
                    { new Guid("e9d0209d-436d-9042-f557-8aec3d6b11e7"), "Rap" },
                    { new Guid("ec936cc6-d170-e397-2a60-7b3b611a662c"), "Pop" },
                    { new Guid("fb139543-b91b-aa33-47e4-0949a1a9dcf7"), "Metal" },
                    { new Guid("ffc31253-be46-8238-b41f-b470d3c6e112"), "Funk" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Duration", "EndAiringDate", "Name", "Photo", "Rating", "ReleaseDate", "StartAiringDate", "Trailer" },
                values: new object[,]
                {
                    { new Guid("00d2ae28-de44-dda7-396c-bef5ef8f8eb7"), "Beatae natus totam rerum soluta voluptatibus minus.\nDeserunt dolor accusantium aut nobis.\nMolestias commodi quis et sit est quae commodi labore provident.\nDucimus vitae omnis.", new TimeOnly(22, 46, 36, 716).Add(TimeSpan.FromTicks(1893)), new DateOnly(2024, 8, 23), "functionalities", "http://lillie.biz", 6.0, new DateOnly(2023, 10, 27), new DateOnly(2023, 9, 1), "https://hassie.net" },
                    { new Guid("07f01b02-0ad8-1c82-0e95-b04f0771b1f9"), "Debitis repudiandae soluta sequi.\nDolor cupiditate totam et incidunt ut perspiciatis sunt saepe.\nOmnis debitis incidunt et.\nQui aut tenetur aut.\nDolores iusto harum aperiam at expedita.\nDolore perspiciatis accusantium et culpa rerum harum possimus distinctio mollitia.", new TimeOnly(22, 17, 43, 661).Add(TimeSpan.FromTicks(5699)), new DateOnly(2024, 10, 19), "cross-platform", "http://judson.biz", 4.0, new DateOnly(2024, 2, 13), new DateOnly(2023, 9, 16), "http://dell.org" },
                    { new Guid("1923804d-d357-01aa-f96f-0a49dcfd5fe7"), "Totam laboriosam nobis quibusdam facere.\nExplicabo delectus laborum.\nVoluptas dolorem sit enim aut.", new TimeOnly(22, 52, 22, 277).Add(TimeSpan.FromTicks(8828)), new DateOnly(2025, 4, 4), "Lane", "https://chelsie.biz", 5.0, new DateOnly(2024, 2, 15), new DateOnly(2023, 10, 22), "https://lonnie.biz" },
                    { new Guid("223ca744-fa47-b70b-77ee-26c0b3b60eb3"), "Dolorem veniam veritatis est ut velit.\nConsequatur magnam velit veniam.", new TimeOnly(22, 42, 57, 322).Add(TimeSpan.FromTicks(3980)), new DateOnly(2025, 3, 19), "Rustic", "https://linda.com", 2.0, new DateOnly(2024, 3, 27), new DateOnly(2023, 12, 24), "http://tobin.org" },
                    { new Guid("2ae7e115-c3bc-a879-0a8f-0c9522f8b590"), "Repellat eos voluptatem aut sapiente.\nCulpa adipisci sequi omnis.\nFugit quaerat voluptatem voluptatum voluptatem.", new TimeOnly(22, 9, 31, 942).Add(TimeSpan.FromTicks(8797)), new DateOnly(2024, 6, 8), "South Georgia and the South Sandwich Islands", "http://carmel.name", 1.0, new DateOnly(2023, 10, 6), new DateOnly(2023, 7, 27), "http://christophe.com" },
                    { new Guid("39affed0-6c9f-eda9-36cb-77659dfb494e"), "Qui occaecati eos ut voluptatibus rerum minus excepturi.\nMinima omnis aliquam id repellendus natus modi nihil.\nQuae unde assumenda atque impedit.", new TimeOnly(22, 51, 36, 694).Add(TimeSpan.FromTicks(433)), new DateOnly(2024, 7, 3), "Wooden", "http://kaia.biz", 4.0, new DateOnly(2023, 7, 6), new DateOnly(2023, 5, 28), "http://cayla.org" },
                    { new Guid("4910d7b1-006a-9299-a3de-d40beec4e6d8"), "Qui perferendis sint ad voluptatem aut.\nVoluptatem libero harum.\nProvident velit ab et vitae et.", new TimeOnly(22, 11, 57, 833).Add(TimeSpan.FromTicks(5283)), new DateOnly(2024, 7, 22), "Horizontal", "https://orlo.name", 0.0, new DateOnly(2023, 10, 8), new DateOnly(2023, 6, 2), "http://wendell.name" },
                    { new Guid("4f37c3bb-05c8-7896-df42-ccde964a911f"), "Dolores aut corporis natus.\nNon incidunt sed est cum dolorum totam ut.\nOdio fugit sapiente et vitae possimus autem dicta.\nUnde incidunt odio nostrum qui.\nEveniet consequatur amet.\nPerferendis et reiciendis.", new TimeOnly(22, 35, 52, 309).Add(TimeSpan.FromTicks(5301)), new DateOnly(2024, 9, 19), "Loaf", "http://janis.net", 6.0, new DateOnly(2023, 7, 18), new DateOnly(2023, 12, 11), "http://gia.biz" },
                    { new Guid("55a78d2b-7d46-a7f9-87aa-e9cbed43e851"), "Ducimus libero quidem illo quod pariatur inventore consequatur quis saepe.\nVoluptatem eos laudantium itaque rerum.\nCupiditate et quia saepe qui expedita numquam ipsum.\nNam dolorem ab.\nNon nam sed corrupti voluptate voluptatem beatae qui iure magnam.", new TimeOnly(22, 2, 35, 180).Add(TimeSpan.FromTicks(6634)), new DateOnly(2024, 11, 26), "XML", "https://madilyn.net", 5.0, new DateOnly(2023, 11, 4), new DateOnly(2023, 10, 1), "http://gunner.biz" },
                    { new Guid("569bc1e3-3395-cfc7-e803-e22383534e72"), "Beatae accusamus quia.\nNesciunt fugiat iure unde temporibus illo reprehenderit velit.\nDolores a eos sed pariatur rem deserunt rem saepe.\nVoluptatum sit ex error voluptatem.\nQuaerat maxime rem minima provident illo.", new TimeOnly(22, 46, 50, 137).Add(TimeSpan.FromTicks(8036)), new DateOnly(2025, 3, 7), "Consultant", "http://shyanne.info", 7.0, new DateOnly(2023, 5, 5), new DateOnly(2023, 10, 26), "http://priscilla.com" },
                    { new Guid("58c6a342-1221-96f1-0894-84188b69e77c"), "Laboriosam sint aut quidem.\nModi et aliquam nostrum quia.\nIllo id ipsa quis sunt dolorum officia ut illum.\nExcepturi fugit animi expedita.\nNostrum quae quam rem explicabo amet officia earum et temporibus.\nEst quia possimus quod aliquid et suscipit eum aut.", new TimeOnly(22, 27, 41, 776).Add(TimeSpan.FromTicks(6045)), new DateOnly(2025, 3, 28), "Savings Account", "https://muhammad.com", 9.0, new DateOnly(2023, 10, 6), new DateOnly(2023, 11, 9), "https://roselyn.name" },
                    { new Guid("5babb80c-c399-fdbf-d422-3384e145b3f8"), "Dolorem facilis amet.\nCorrupti eum est reiciendis voluptatem.\nFacere aut mollitia.\nProvident nam quia occaecati.\nQuo sint asperiores cum consequuntur.", new TimeOnly(21, 57, 18, 940).Add(TimeSpan.FromTicks(1107)), new DateOnly(2024, 5, 13), "access", "http://trenton.info", 7.0, new DateOnly(2023, 6, 9), new DateOnly(2024, 1, 16), "https://antonetta.com" },
                    { new Guid("5bc3ff93-5b24-5359-f880-058a48018d9f"), "Est velit et alias facere quasi earum consequatur.\nBeatae quod corrupti natus alias ut fugiat.", new TimeOnly(22, 29, 59, 612).Add(TimeSpan.FromTicks(451)), new DateOnly(2024, 5, 8), "strategy", "https://drake.info", 1.0, new DateOnly(2023, 9, 26), new DateOnly(2024, 4, 4), "http://mckenna.biz" },
                    { new Guid("5fa30ad0-07cb-dcf7-09d3-5b5eed7602ed"), "Nulla blanditiis quia sit et perferendis quo perferendis ullam dolorem.\nRerum ea ea laborum.\nHarum voluptatem harum pariatur vero.", new TimeOnly(22, 45, 57, 796).Add(TimeSpan.FromTicks(8974)), new DateOnly(2024, 10, 14), "bandwidth", "http://devin.info", 7.0, new DateOnly(2024, 1, 6), new DateOnly(2024, 4, 23), "http://danika.info" },
                    { new Guid("6410650a-2117-d079-f9f6-fa3ba87b8ae5"), "Omnis sint blanditiis.\nOmnis aliquid ut quia recusandae culpa.\nDolorem totam est ut ratione itaque provident.\nRem sit dolore quos consequatur quia iste.\nConsequatur aliquam tempore labore explicabo sed.\nConsectetur repudiandae rerum nihil voluptatem tempora eos incidunt incidunt ullam.", new TimeOnly(22, 11, 6, 600).Add(TimeSpan.FromTicks(5589)), new DateOnly(2024, 8, 25), "cross-platform", "http://tate.com", 7.0, new DateOnly(2023, 8, 25), new DateOnly(2023, 10, 25), "https://roberto.biz" },
                    { new Guid("6a86dc25-7f9d-4e12-36aa-6e0779067974"), "Ullam ea enim.\nIusto quas perferendis rem quod quae quo qui.\nEos quibusdam iste.\nAsperiores esse dolorum ea qui facere.\nFuga consequatur et aut.", new TimeOnly(22, 19, 10, 886).Add(TimeSpan.FromTicks(8946)), new DateOnly(2024, 6, 10), "monitoring", "http://tyra.name", 8.0, new DateOnly(2023, 6, 23), new DateOnly(2024, 3, 26), "http://jerrold.com" },
                    { new Guid("6cbe7df2-753a-71c1-550d-d39ad912a8d6"), "Quasi eveniet est excepturi laudantium.\nId assumenda est unde adipisci laboriosam at sed.", new TimeOnly(22, 11, 38, 820).Add(TimeSpan.FromTicks(7026)), new DateOnly(2024, 8, 26), "Intelligent Frozen Pizza", "http://jayme.biz", 5.0, new DateOnly(2024, 2, 9), new DateOnly(2024, 1, 28), "http://michaela.com" },
                    { new Guid("81773066-f083-2bf5-c204-6843af2654cd"), "Aliquam possimus dolorum eum repudiandae voluptate ut praesentium explicabo.\nNemo laborum et asperiores qui exercitationem minus ut.\nVoluptas et laudantium excepturi ducimus beatae soluta impedit aut.", new TimeOnly(22, 30, 38, 501).Add(TimeSpan.FromTicks(5628)), new DateOnly(2025, 2, 14), "deposit", "http://taylor.info", 9.0, new DateOnly(2024, 4, 6), new DateOnly(2024, 4, 24), "http://elton.info" },
                    { new Guid("8bb63896-23f1-67f9-9858-7445f9cd14e7"), "Provident sed perferendis sit excepturi expedita facere.\nEst et quasi voluptas voluptatem blanditiis nihil magni qui.\nNon doloribus quia.", new TimeOnly(22, 35, 22, 182).Add(TimeSpan.FromTicks(339)), new DateOnly(2024, 5, 15), "Handmade Granite Hat", "https://ned.name", 6.0, new DateOnly(2023, 6, 22), new DateOnly(2023, 11, 12), "http://rhoda.com" },
                    { new Guid("950fde63-05b9-bba8-01ba-fd2fc67e5f18"), "Eveniet iusto assumenda et enim quis eaque.\nVoluptas sint maxime dicta unde et adipisci.\nFugit quae qui.", new TimeOnly(22, 18, 23, 545).Add(TimeSpan.FromTicks(4513)), new DateOnly(2024, 5, 21), "global", "https://oceane.com", 9.0, new DateOnly(2023, 6, 27), new DateOnly(2024, 4, 24), "https://zaria.biz" },
                    { new Guid("99475bc1-2f38-3793-73eb-a8ab80247a62"), "Sed laudantium culpa sed rerum repellat eveniet.\nConsequatur dolorem aperiam.\nQui et commodi quibusdam ea.\nAut esse ratione corporis cum voluptas ut similique.\nDolores quo itaque velit molestias provident alias.", new TimeOnly(22, 11, 11, 326).Add(TimeSpan.FromTicks(5439)), new DateOnly(2025, 4, 6), "capacitor", "https://bella.info", 7.0, new DateOnly(2023, 7, 3), new DateOnly(2023, 8, 1), "http://ashleigh.biz" },
                    { new Guid("a9b240ec-b72b-a3ad-4e1f-a0fc02e70f71"), "Praesentium illum ut culpa aperiam quia est nostrum non.\nDoloremque vel dolor fugit et.\nVoluptatem qui velit molestiae.\nDolore consectetur ipsam ut tenetur illo nobis perspiciatis et.\nAutem harum et impedit voluptas facere perspiciatis.", new TimeOnly(22, 30, 2, 789).Add(TimeSpan.FromTicks(5559)), new DateOnly(2025, 1, 20), "Washington", "https://braulio.com", 4.0, new DateOnly(2024, 2, 8), new DateOnly(2023, 8, 24), "https://elena.biz" },
                    { new Guid("bd4d6dc2-2fe5-cc5b-390f-e6d46143cf85"), "Nemo dolorem quasi omnis unde non.\nEst tempora id at error laudantium.\nQuisquam non enim velit ipsum.", new TimeOnly(22, 9, 51, 72).Add(TimeSpan.FromTicks(7711)), new DateOnly(2024, 10, 10), "Guyana", "https://davin.info", 3.0, new DateOnly(2023, 11, 6), new DateOnly(2024, 1, 23), "https://sheila.net" },
                    { new Guid("c0837db4-f428-1185-6dbe-030893b588b2"), "Velit velit velit consequuntur vel.\nReprehenderit ullam sunt neque repellat molestias optio.\nEst aliquid repellat ipsum temporibus inventore exercitationem distinctio.\nEst eos soluta dolore ipsam modi voluptas cum praesentium.\nEst possimus maiores ex asperiores.", new TimeOnly(22, 18, 29, 59).Add(TimeSpan.FromTicks(725)), new DateOnly(2025, 2, 15), "Myanmar", "https://marlin.org", 2.0, new DateOnly(2023, 11, 2), new DateOnly(2023, 11, 22), "https://mitchel.name" },
                    { new Guid("c230bee1-82a2-4e24-9677-fb876ca673ae"), "Quis est commodi sunt est sed nihil perferendis officiis illum.\nEt sed corrupti voluptatem sint qui sit temporibus.\nVero dolorem sit architecto sunt magnam voluptates eius quia.\nMolestiae dolores quis voluptatem aut rerum debitis commodi facilis earum.\nQuam sunt voluptatem ratione distinctio.\nIusto iure dicta ut deleniti totam voluptatem.", new TimeOnly(22, 54, 20, 691).Add(TimeSpan.FromTicks(1615)), new DateOnly(2025, 2, 2), "Springs", "https://aleen.com", 5.0, new DateOnly(2023, 5, 11), new DateOnly(2024, 3, 20), "https://marcelle.name" },
                    { new Guid("c582a7e7-7542-8d2b-aa82-63f00b599ab6"), "Quos similique necessitatibus velit commodi commodi sit.\nRepellendus ut asperiores unde ut eum quis.\nEum id atque ipsum libero a.", new TimeOnly(22, 1, 6, 707).Add(TimeSpan.FromTicks(2227)), new DateOnly(2024, 5, 7), "Credit Card Account", "https://dashawn.biz", 5.0, new DateOnly(2023, 12, 19), new DateOnly(2023, 8, 6), "https://demarco.com" },
                    { new Guid("c7ede41b-7030-4f7b-e7ad-e43f9fbe825a"), "Sunt rem ex eius.\nRecusandae a qui est omnis.", new TimeOnly(22, 5, 50, 960).Add(TimeSpan.FromTicks(8636)), new DateOnly(2024, 12, 21), "withdrawal", "https://mavis.com", 7.0, new DateOnly(2023, 7, 18), new DateOnly(2024, 2, 10), "http://lia.com" },
                    { new Guid("dff1c775-39b4-8147-5bb2-cae0152b7d72"), "Voluptates esse dignissimos corporis est ut cupiditate sit eligendi.\nAccusantium est rerum eum harum sunt consectetur doloribus ut maxime.\nEum est corporis expedita qui exercitationem repudiandae nulla.\nConsequatur non sit quia itaque eveniet soluta fugit.\nExpedita blanditiis quis quia autem totam ex dicta hic cum.", new TimeOnly(22, 28, 21, 2).Add(TimeSpan.FromTicks(7239)), new DateOnly(2024, 9, 23), "Clothing & Baby", "https://caesar.biz", 1.0, new DateOnly(2024, 4, 11), new DateOnly(2023, 10, 31), "http://kendall.biz" },
                    { new Guid("e288f915-8057-f150-bdcf-0e34a1770859"), "Rem tempore sed itaque pariatur quo.\nQuos vitae sed corrupti sint et voluptatem voluptatem sint nostrum.\nRecusandae ab inventore consequuntur.\nSapiente sit ipsa rerum delectus.", new TimeOnly(21, 59, 46, 548).Add(TimeSpan.FromTicks(7303)), new DateOnly(2024, 7, 1), "Small Metal Table", "https://ocie.net", 6.0, new DateOnly(2023, 5, 20), new DateOnly(2023, 10, 4), "http://tony.info" },
                    { new Guid("f41b3d1c-39a5-990f-8680-ea3db106a902"), "Repellat enim atque voluptate et aut et dignissimos recusandae assumenda.\nDistinctio totam repudiandae doloremque quia qui eveniet distinctio autem nam.\nQuo fugiat sint delectus aspernatur similique aut consectetur.\nEst rerum magnam nam et est eos fugiat veritatis est.\nEos rerum perferendis esse blanditiis commodi neque ut eaque harum.\nUt dolorum sit provident.", new TimeOnly(22, 20, 22, 466).Add(TimeSpan.FromTicks(1251)), new DateOnly(2024, 11, 12), "Officer", "http://oscar.org", 7.0, new DateOnly(2024, 2, 2), new DateOnly(2023, 9, 13), "https://yasmeen.info" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4dabfd27-4090-49bf-9c99-cdff9d7dd40e"), null, "user", null },
                    { new Guid("ab368576-72f1-4d03-8e81-89ec63037b0b"), null, "admin", null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "NumberOfSeats", "RoomName" },
                values: new object[,]
                {
                    { new Guid("0204be48-99ae-3b9d-cc4c-93d827a99790"), 2116609736, "alias" },
                    { new Guid("0945aafe-6dc1-a59f-50ba-a94d0e21fe59"), -1648880840, "pariatur" },
                    { new Guid("103f1afe-9a98-0b26-0700-9cefc96c7e06"), -986855892, "quam" },
                    { new Guid("1ff119fa-e72d-6f5e-9a06-ba05118a23ce"), 1854446187, "fugiat" },
                    { new Guid("200f96fc-84a7-7023-2721-992db26fde72"), -38157169, "consequatur" },
                    { new Guid("2a394d02-3320-1567-3f28-61004b48cbbb"), 794598074, "maiores" },
                    { new Guid("2b83e612-3f9f-e685-fa3f-e46ef2dc346b"), 244594141, "in" },
                    { new Guid("2ed8933f-07ad-3e3c-ae36-581dc3b7a45c"), -1206048506, "molestiae" },
                    { new Guid("3526225b-984b-3b06-1938-7d9a6d8277e8"), -1070208786, "qui" },
                    { new Guid("36352770-5651-d38a-f32d-31dc3ff57ebd"), 670192658, "hic" },
                    { new Guid("3a4c24bf-b9d4-d734-f6f1-dc33587fbcd5"), 1765027355, "sit" },
                    { new Guid("434f601b-f7c3-d780-39a4-d33fef4737d7"), 379790874, "beatae" },
                    { new Guid("4cbe778f-8510-835e-276c-a9de1824ae2a"), -479682624, "tempora" },
                    { new Guid("579b9ab9-ee9a-fecc-dd6b-5bf20f8ba3c3"), 814056199, "nostrum" },
                    { new Guid("639d0ee2-7261-cce1-96ba-ff7e27672fc9"), -71382257, "cum" },
                    { new Guid("67d62666-9b79-0369-c6d0-1cd1514b2774"), -644243385, "similique" },
                    { new Guid("752e26cf-3203-2a0a-6c40-4577fbb92652"), 1456151016, "at" },
                    { new Guid("790caa0b-534e-d670-7d1d-e7c2948bf34b"), 1830921492, "vel" },
                    { new Guid("920c5171-fd52-2a29-f437-76a2a7d254ca"), -744165646, "doloribus" },
                    { new Guid("9eb48871-442c-3d67-9c71-7afa0b789542"), -884830747, "pariatur" },
                    { new Guid("9f56df9a-6b9e-81a4-0dd1-f1d3208366f1"), 1983146593, "non" },
                    { new Guid("ae843e55-102d-23d7-ea30-6b31c0d77b06"), -1085615459, "modi" },
                    { new Guid("c87d7934-ddbd-ae91-3807-e9d4c6d5cdc4"), -1277332569, "fugiat" },
                    { new Guid("cdfa04ab-9594-24da-db1d-9893f3d86d63"), -1485589483, "aut" },
                    { new Guid("d1517b86-2072-b394-0e0c-475f00b81de3"), -2018620191, "voluptates" },
                    { new Guid("db8d2325-4933-e468-3dbb-78a406240ed8"), 491239612, "neque" },
                    { new Guid("ddec5271-0145-d501-936a-7ba0570d2da0"), -915556937, "beatae" },
                    { new Guid("f04bf802-bdee-7722-a2d7-c5525b770409"), 403659871, "nostrum" },
                    { new Guid("f195c1c1-69f8-4fe9-5ffa-8c5fcb1d8e89"), -345504355, "et" },
                    { new Guid("f5b34448-cd38-73e1-8206-2e5c39084ff4"), -1819054951, "accusantium" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0a5d1e0a-bf8b-c4cc-16c1-42f732b5cab3"), 0, "c32cdd9f-8c2f-4e75-b6b4-f8bde8877ebb", "Halie33@gmail.com", false, false, null, null, null, "ml3FS1KOnM", "267.467.7981", false, null, false, "Pablo.Orn87" },
                    { new Guid("0ddde7b3-07a3-806f-c8b3-1526d00d919c"), 0, "048978c4-b564-4e55-9bdf-c83f9b9752a6", "Neva_Mosciski@hotmail.com", false, false, null, null, null, "7MgAcezMYR", "747.421.5772", false, null, false, "Fredrick_Jakubowski17" },
                    { new Guid("1667e15e-5f5b-0181-8850-169137d167cd"), 0, "38c3a4e3-c468-4d82-ae17-efbb1a94d969", "Glen_Klein@yahoo.com", false, false, null, null, null, "EfVMVVvbG8", "(633) 636-6609 x4296", false, null, false, "Rickey.Hauck85" },
                    { new Guid("16e22f1b-9cd1-1e29-432f-ed889a593a53"), 0, "c85b4c2f-9651-42a7-aa13-e161ba89194c", "William60@gmail.com", false, false, null, null, null, "Kl_L4E1mNF", "317.529.7501 x4843", false, null, false, "Sabina95" },
                    { new Guid("1e47b6b9-b6c3-9404-cad9-bf27a91e49cd"), 0, "5b6d076e-b9b9-4756-b9a0-5793f0817d68", "Laurine32@hotmail.com", false, false, null, null, null, "RA9fhr2cyY", "328-519-6957 x9483", false, null, false, "Giles_Strosin" },
                    { new Guid("2a75148c-98fd-42b4-6b80-780c6db4d0c7"), 0, "844274d1-7c8b-4bb6-b95e-139b038b24f5", "Stacey.Beer48@hotmail.com", false, false, null, null, null, "1BGzOwd0_r", "(473) 797-3387", false, null, false, "Mike_Conn" },
                    { new Guid("2a90f707-ef40-848e-655d-09c8d4da8584"), 0, "bc426c20-a489-4efe-8f96-ea8ad98cf248", "Rachel_Greenfelder19@hotmail.com", false, false, null, null, null, "oEDfSroJrY", "(466) 770-1537 x693", false, null, false, "Kane.Conn" },
                    { new Guid("2c569e1a-59f8-60db-fe75-5598ea46f85a"), 0, "082d55ed-2188-4c10-a13c-842ae3d7e918", "Josiane52@gmail.com", false, false, null, null, null, "Gi9Uv2OVJ2", "819-975-0471", false, null, false, "Malcolm.Prosacco97" },
                    { new Guid("2c610ffc-4eec-2c5b-7603-967b66f44ea5"), 0, "6f0374ab-7566-43dd-b4cf-9459f014a603", "Serena.Fay@gmail.com", false, false, null, null, null, "5NrNx2zwEy", "593-724-7054 x049", false, null, false, "Abby84" },
                    { new Guid("321160ac-b731-aa50-eacd-ac057faf12f8"), 0, "1a85fc09-b4e8-49ad-9b01-79d1933d7e7d", "Eldon12@hotmail.com", false, false, null, null, null, "4EGKfkqDe3", "344.580.0568 x38939", false, null, false, "Conner92" },
                    { new Guid("405477ae-d509-7a98-7b1a-459717fa137d"), 0, "1120b9fe-03e0-4a78-9cbc-837f73b2db29", "Savanna.Franecki@yahoo.com", false, false, null, null, null, "x42YXX9IR0", "399.232.0352", false, null, false, "Era_Osinski57" },
                    { new Guid("4c45fe93-b488-c170-a35f-9880dd130f3f"), 0, "fd1e96c2-247e-4ff7-af15-50f1becec007", "Rubie.Kohler@gmail.com", false, false, null, null, null, "4nzEqZ9QYF", "321.817.9659 x69981", false, null, false, "Brionna.Paucek" },
                    { new Guid("55780f5d-7c11-233b-eb6b-c821d1d50bee"), 0, "03185991-32b5-4d78-8337-437b14d1bf09", "Rhoda.Oberbrunner@hotmail.com", false, false, null, null, null, "9aCmL67f06", "392.410.6828 x85133", false, null, false, "Verlie_Johnston41" },
                    { new Guid("59607377-94fc-ca28-527b-bde453587b61"), 0, "250e99fa-de5b-4a66-b5fc-526c1d9da5e5", "Brenden33@yahoo.com", false, false, null, null, null, "4Jz0j8lETk", "706-700-8795 x2107", false, null, false, "Jules.Herzog" },
                    { new Guid("60f9f1b9-d925-5ba0-4986-691a88763873"), 0, "6fe3baef-f2d8-4fba-9305-361efffd9b7a", "Halle.Doyle73@yahoo.com", false, false, null, null, null, "27lzT6AHIY", "1-963-785-1717", false, null, false, "Antonia80" },
                    { new Guid("64eb7d76-2665-cdfc-4148-0b86fe6eedc6"), 0, "8bd10905-104f-4a16-8ea5-0a2efdb38828", "Thurman.Pagac15@hotmail.com", false, false, null, null, null, "dOT4UaTfvE", "776-615-4555 x70881", false, null, false, "Domenico_McLaughlin17" },
                    { new Guid("77298fa4-0612-2011-e2df-a86f1a1f4515"), 0, "47302840-473a-4258-b341-4678eac0e6b1", "Blaise_Muller19@hotmail.com", false, false, null, null, null, "wAgJbCAGp5", "345-200-0958", false, null, false, "Alexane83" },
                    { new Guid("7aaa320e-3616-0481-823f-b6556c274487"), 0, "e249c93d-ea8c-4f3a-be54-f336b9723000", "Gino_Conroy2@gmail.com", false, false, null, null, null, "JMJ0K9CJeS", "367-714-2810", false, null, false, "Glenna90" },
                    { new Guid("861e45e9-83ae-dfd8-bd5d-0ef11721678b"), 0, "06fe5365-138d-40ba-b7c1-33a3a02795dc", "Jessyca.Anderson95@yahoo.com", false, false, null, null, null, "NrE2V5J6cN", "1-772-813-2522", false, null, false, "Miller.Lemke97" },
                    { new Guid("88d49992-9b93-d20c-70a3-7c42d33a2324"), 0, "f34393d6-50f0-4838-8c9c-3a2a253491c0", "Werner_Shields51@yahoo.com", false, false, null, null, null, "meWA7Un2AG", "911.450.6426 x9699", false, null, false, "Caesar_Thompson31" },
                    { new Guid("92143549-09d6-ccb1-8ef6-8a045548c564"), 0, "5776486d-c526-4738-9dbc-15c77e51c8b9", "Araceli9@gmail.com", false, false, null, null, null, "eGWRfS_EEm", "976-546-3391", false, null, false, "Jordane86" },
                    { new Guid("972e1a36-fe7e-af1c-02d1-bb420454b814"), 0, "a872b64b-2a5d-4783-8639-9693258b1df1", "Adell1@gmail.com", false, false, null, null, null, "g1EG8yRZmG", "949-482-0786 x37816", false, null, false, "Prudence46" },
                    { new Guid("983d3b18-0fed-276c-34b7-d52cb27a0dcb"), 0, "a8ecf364-65c7-4dee-b1bc-1b9c8a92b149", "Cassie10@yahoo.com", false, false, null, null, null, "esRN2vLldM", "1-984-400-0083", false, null, false, "Theron.McCullough" },
                    { new Guid("9d72ec77-0ccc-1a0b-04c4-de592083e4f3"), 0, "d823c024-19a1-43a5-bd52-1d6f0396474d", "Marcelino68@yahoo.com", false, false, null, null, null, "eMoXXNWffC", "1-695-970-9245", false, null, false, "Jon_Schroeder" },
                    { new Guid("9f7014d9-5c08-1789-3a02-8eb39bddbaf3"), 0, "b6e0687e-dec8-4d2d-9bec-d4a78d3c0c4a", "Vincent.Schoen88@gmail.com", false, false, null, null, null, "MDIx0fXLGR", "(326) 730-6499", false, null, false, "Carroll2" },
                    { new Guid("a1d015ac-94cd-fea4-5d16-ab4b8fe06cfe"), 0, "a53bb0bb-dc70-45ef-a823-1a6f0a55e167", "Caden_Hyatt@yahoo.com", false, false, null, null, null, "va0JuwYK7F", "324-519-8381", false, null, false, "Enos_Hoeger" },
                    { new Guid("bedf3932-121d-0819-a1e3-b5136670f2d3"), 0, "d16d32c6-1371-481d-b325-c837405cd79c", "Camryn70@gmail.com", false, false, null, null, null, "uZxoBAh6mL", "870-975-3472", false, null, false, "Kari_Friesen29" },
                    { new Guid("ce2bf93e-97a2-8768-cf45-d4f5264442c6"), 0, "6b08c910-86ae-4353-a8a2-0b3a059e4f8e", "Janice15@hotmail.com", false, false, null, null, null, "xwRefC0r2U", "(686) 518-9727 x35183", false, null, false, "Monica67" },
                    { new Guid("efd419a6-2c40-992a-04a4-096403822f12"), 0, "d165ba6b-2dbd-4071-97ac-857e927df45c", "Lucio86@hotmail.com", false, false, null, null, null, "lRMwO3vNB8", "888-341-1603 x2964", false, null, false, "Krystina.Runolfsdottir" },
                    { new Guid("fdf820d9-c338-29ed-51ba-2b08c27dde78"), 0, "1a26fe82-5aa2-4c74-b5e6-f01b8fa7f54e", "Xzavier_Schulist2@gmail.com", false, false, null, null, null, "l0u_0WqWmR", "(409) 809-3542 x04164", false, null, false, "Leonor_Williamson" }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("cc7e4d4b-57e6-36d9-bfa6-cba9b63b2e63"), new Guid("00d2ae28-de44-dda7-396c-bef5ef8f8eb7") },
                    { new Guid("43143429-74be-878a-a826-ed07c0af082a"), new Guid("07f01b02-0ad8-1c82-0e95-b04f0771b1f9") },
                    { new Guid("b50fd31e-6e92-82d4-af4f-57d81ab47b4a"), new Guid("1923804d-d357-01aa-f96f-0a49dcfd5fe7") },
                    { new Guid("81ad07ac-cc65-e61d-6ca1-49a9e1222ef5"), new Guid("223ca744-fa47-b70b-77ee-26c0b3b60eb3") },
                    { new Guid("fbbdfcdb-5c18-f7e4-e966-753c3da72902"), new Guid("2ae7e115-c3bc-a879-0a8f-0c9522f8b590") },
                    { new Guid("30a82556-fa16-af90-ce76-e264e292e472"), new Guid("39affed0-6c9f-eda9-36cb-77659dfb494e") },
                    { new Guid("6199fd49-d263-cb16-1f7d-ab2c814e2b42"), new Guid("4910d7b1-006a-9299-a3de-d40beec4e6d8") },
                    { new Guid("498db59e-5f0f-ffd1-5e72-6efabee6f969"), new Guid("4f37c3bb-05c8-7896-df42-ccde964a911f") },
                    { new Guid("c01fad07-e9b3-ae9c-1f88-d33875663caa"), new Guid("55a78d2b-7d46-a7f9-87aa-e9cbed43e851") },
                    { new Guid("fb20b70b-3bb3-a0e3-ce6f-639fc56e6b19"), new Guid("569bc1e3-3395-cfc7-e803-e22383534e72") },
                    { new Guid("1e48bab1-ba02-5ae7-1091-d24cb29d1889"), new Guid("58c6a342-1221-96f1-0894-84188b69e77c") },
                    { new Guid("7dce468d-1b3d-2bf0-adc1-d49880563a93"), new Guid("5babb80c-c399-fdbf-d422-3384e145b3f8") },
                    { new Guid("64b16995-0cd9-f3f1-625d-cf64a5042f59"), new Guid("5bc3ff93-5b24-5359-f880-058a48018d9f") },
                    { new Guid("f6d44886-1e3b-3543-5c60-4c94bfe640b6"), new Guid("5fa30ad0-07cb-dcf7-09d3-5b5eed7602ed") },
                    { new Guid("2d07ed24-a1d9-f14e-3041-3f3c170ed6c3"), new Guid("6410650a-2117-d079-f9f6-fa3ba87b8ae5") },
                    { new Guid("0853687d-e8fe-a480-c234-ec19cb493153"), new Guid("6a86dc25-7f9d-4e12-36aa-6e0779067974") },
                    { new Guid("d4534672-3c09-c145-63da-d8fbbe2c7ea7"), new Guid("6cbe7df2-753a-71c1-550d-d39ad912a8d6") },
                    { new Guid("b216c89c-e2ec-38e8-67e8-2fff397f9e02"), new Guid("81773066-f083-2bf5-c204-6843af2654cd") },
                    { new Guid("a4ff575f-9048-afab-794b-db81b7f6d5bc"), new Guid("8bb63896-23f1-67f9-9858-7445f9cd14e7") },
                    { new Guid("523b1ee4-3977-d633-b1e9-3fc1a4157ce5"), new Guid("950fde63-05b9-bba8-01ba-fd2fc67e5f18") },
                    { new Guid("e0923758-4a63-7094-c482-99bf41b34fbf"), new Guid("99475bc1-2f38-3793-73eb-a8ab80247a62") },
                    { new Guid("2f06addf-8f0f-b189-fe91-9a898a324d66"), new Guid("a9b240ec-b72b-a3ad-4e1f-a0fc02e70f71") },
                    { new Guid("554a7740-beaf-3350-68ea-f18322a06afc"), new Guid("bd4d6dc2-2fe5-cc5b-390f-e6d46143cf85") },
                    { new Guid("90977f20-6e67-bd4a-a8b6-1ab836e132cb"), new Guid("c0837db4-f428-1185-6dbe-030893b588b2") },
                    { new Guid("dcfa5ed4-a419-7a6c-105f-a4ee65730078"), new Guid("c230bee1-82a2-4e24-9677-fb876ca673ae") },
                    { new Guid("6ba03eb3-49e5-a462-f72f-8c278027a292"), new Guid("c582a7e7-7542-8d2b-aa82-63f00b599ab6") },
                    { new Guid("c52ada7a-ab0f-fe9a-1d0c-f8298f0121c3"), new Guid("c7ede41b-7030-4f7b-e7ad-e43f9fbe825a") },
                    { new Guid("ee93ec18-2c2e-1e29-86c8-950cf210617b"), new Guid("dff1c775-39b4-8147-5bb2-cae0152b7d72") },
                    { new Guid("50162e71-5204-43ed-270b-0ce94fc646f9"), new Guid("e288f915-8057-f150-bdcf-0e34a1770859") },
                    { new Guid("41189c4e-3ec4-34c1-f297-e68c859dca29"), new Guid("f41b3d1c-39a5-990f-8680-ea3db106a902") }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("3696c77b-2040-bf4c-b8f2-0f4f19c3783b"), new Guid("00d2ae28-de44-dda7-396c-bef5ef8f8eb7") },
                    { new Guid("ffc31253-be46-8238-b41f-b470d3c6e112"), new Guid("07f01b02-0ad8-1c82-0e95-b04f0771b1f9") },
                    { new Guid("e0410a9d-8ca1-0b9f-c651-45f57e651aae"), new Guid("1923804d-d357-01aa-f96f-0a49dcfd5fe7") },
                    { new Guid("e9d0209d-436d-9042-f557-8aec3d6b11e7"), new Guid("223ca744-fa47-b70b-77ee-26c0b3b60eb3") },
                    { new Guid("9b3a1161-c29b-3a46-758e-b5927dd21d46"), new Guid("2ae7e115-c3bc-a879-0a8f-0c9522f8b590") },
                    { new Guid("9e9c0966-c70e-d74d-0d2b-518a231162c0"), new Guid("39affed0-6c9f-eda9-36cb-77659dfb494e") },
                    { new Guid("5e5d4bbf-5124-759f-e7fd-1eed477469f3"), new Guid("4910d7b1-006a-9299-a3de-d40beec4e6d8") },
                    { new Guid("03023299-69cb-8b85-2f0e-a021c46dac3a"), new Guid("4f37c3bb-05c8-7896-df42-ccde964a911f") },
                    { new Guid("583ca71e-d218-b120-737b-2e490889356a"), new Guid("55a78d2b-7d46-a7f9-87aa-e9cbed43e851") },
                    { new Guid("a44793d1-d551-d5e1-a66a-1d5d265c0adc"), new Guid("569bc1e3-3395-cfc7-e803-e22383534e72") },
                    { new Guid("8d3e36d0-8dbd-57e7-a236-5b6d512044c5"), new Guid("58c6a342-1221-96f1-0894-84188b69e77c") },
                    { new Guid("98d377b1-9956-fb89-a23b-995c113275d1"), new Guid("5babb80c-c399-fdbf-d422-3384e145b3f8") },
                    { new Guid("68edfff7-379d-8f05-5eb3-546a3cb47477"), new Guid("5bc3ff93-5b24-5359-f880-058a48018d9f") },
                    { new Guid("c3b7b628-eb85-18cd-bb8a-b787af3c2503"), new Guid("5fa30ad0-07cb-dcf7-09d3-5b5eed7602ed") },
                    { new Guid("4fa7670d-4850-9084-b917-70166e0f16e9"), new Guid("6410650a-2117-d079-f9f6-fa3ba87b8ae5") },
                    { new Guid("79622f63-da70-b336-3bf2-e7285c9315b9"), new Guid("6a86dc25-7f9d-4e12-36aa-6e0779067974") },
                    { new Guid("fb139543-b91b-aa33-47e4-0949a1a9dcf7"), new Guid("6cbe7df2-753a-71c1-550d-d39ad912a8d6") },
                    { new Guid("cc3303f4-952b-ce54-16d6-9d4b623e6bca"), new Guid("81773066-f083-2bf5-c204-6843af2654cd") },
                    { new Guid("2a5522f8-17c2-7dc1-8565-9b91171c9e45"), new Guid("8bb63896-23f1-67f9-9858-7445f9cd14e7") },
                    { new Guid("1ac09dd4-2130-0b14-72bf-42874a9fc995"), new Guid("950fde63-05b9-bba8-01ba-fd2fc67e5f18") },
                    { new Guid("a5b0cd69-d564-c75f-8020-ce103cc95965"), new Guid("99475bc1-2f38-3793-73eb-a8ab80247a62") },
                    { new Guid("6ec85fe4-2ca8-ac81-b887-023404087f91"), new Guid("a9b240ec-b72b-a3ad-4e1f-a0fc02e70f71") },
                    { new Guid("5da6bbc5-4f35-5c68-5320-35aaa17653d8"), new Guid("bd4d6dc2-2fe5-cc5b-390f-e6d46143cf85") },
                    { new Guid("1b22f642-2e19-6ed1-b750-44ace454e4ab"), new Guid("c0837db4-f428-1185-6dbe-030893b588b2") },
                    { new Guid("385a7b5f-7ca9-dd38-353e-3f79c37749c3"), new Guid("c230bee1-82a2-4e24-9677-fb876ca673ae") },
                    { new Guid("04c1e8f3-d3e8-9580-6f12-13ec5eb753b4"), new Guid("c582a7e7-7542-8d2b-aa82-63f00b599ab6") },
                    { new Guid("b398995c-337e-0dbc-e91d-b25eb8c4257d"), new Guid("c7ede41b-7030-4f7b-e7ad-e43f9fbe825a") },
                    { new Guid("c4a4ced9-b5bc-82f0-b43d-396d08acd70d"), new Guid("dff1c775-39b4-8147-5bb2-cae0152b7d72") },
                    { new Guid("ec936cc6-d170-e397-2a60-7b3b611a662c"), new Guid("e288f915-8057-f150-bdcf-0e34a1770859") },
                    { new Guid("1bdda020-15d7-a21b-de6f-64f9ee0e451f"), new Guid("f41b3d1c-39a5-990f-8680-ea3db106a902") }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "IsActive", "IsPaid", "Reserved", "UserId" },
                values: new object[,]
                {
                    { new Guid("052cfc28-9529-6f06-c04a-2bba2c496bf9"), true, false, true, new Guid("405477ae-d509-7a98-7b1a-459717fa137d") },
                    { new Guid("087b1479-549a-e6ef-cd8c-26905a30cf44"), true, true, false, new Guid("321160ac-b731-aa50-eacd-ac057faf12f8") },
                    { new Guid("093d76aa-cbf6-0fd7-eff4-5a49bed9fc63"), false, true, true, new Guid("59607377-94fc-ca28-527b-bde453587b61") },
                    { new Guid("0b318129-7fe5-606a-7e2e-4511a2717186"), true, false, false, new Guid("4c45fe93-b488-c170-a35f-9880dd130f3f") },
                    { new Guid("0bdee1d0-3fec-9cd7-fe82-843ff00a4bfb"), false, true, false, new Guid("1667e15e-5f5b-0181-8850-169137d167cd") },
                    { new Guid("11da56e6-af5a-ec67-dc3e-a65c99e3b6d2"), false, false, true, new Guid("9d72ec77-0ccc-1a0b-04c4-de592083e4f3") },
                    { new Guid("11fadcd4-f585-862b-3a71-77a23586237a"), true, true, false, new Guid("9d72ec77-0ccc-1a0b-04c4-de592083e4f3") },
                    { new Guid("21605fe1-4fc6-546a-dd18-d89fb829e252"), true, false, true, new Guid("ce2bf93e-97a2-8768-cf45-d4f5264442c6") },
                    { new Guid("2b412908-c9ae-5607-36c7-4ec2ed007981"), true, true, false, new Guid("bedf3932-121d-0819-a1e3-b5136670f2d3") },
                    { new Guid("2daa28ac-d808-82bb-a762-7acff642b48d"), true, true, true, new Guid("0a5d1e0a-bf8b-c4cc-16c1-42f732b5cab3") },
                    { new Guid("3818ba81-daef-7d85-6ab3-b8a76115aecf"), true, false, true, new Guid("16e22f1b-9cd1-1e29-432f-ed889a593a53") },
                    { new Guid("3a18c610-76fd-3436-4725-8d363f7c73db"), false, true, false, new Guid("a1d015ac-94cd-fea4-5d16-ab4b8fe06cfe") },
                    { new Guid("3cf07940-2ee4-a23b-1019-96064ea32b07"), true, true, true, new Guid("64eb7d76-2665-cdfc-4148-0b86fe6eedc6") },
                    { new Guid("4330597a-b193-8a02-d4e0-40fa2af8e3f5"), false, true, false, new Guid("0a5d1e0a-bf8b-c4cc-16c1-42f732b5cab3") },
                    { new Guid("43c57ffa-cd69-5ea5-f99f-41fcbfd5845c"), true, false, true, new Guid("92143549-09d6-ccb1-8ef6-8a045548c564") },
                    { new Guid("4eafb22d-a453-6a55-2d85-19915fdb85c9"), true, true, true, new Guid("405477ae-d509-7a98-7b1a-459717fa137d") },
                    { new Guid("5430a06e-d3a7-bcd4-4409-74602d4d8b35"), true, true, false, new Guid("77298fa4-0612-2011-e2df-a86f1a1f4515") },
                    { new Guid("57dc112c-f48a-2fee-567d-63937ce2fc88"), true, true, false, new Guid("77298fa4-0612-2011-e2df-a86f1a1f4515") },
                    { new Guid("5999ac9c-370b-6104-5209-c680f6bd67f3"), true, true, false, new Guid("88d49992-9b93-d20c-70a3-7c42d33a2324") },
                    { new Guid("6c043937-816c-cc64-313b-8a0ada7510ec"), true, false, false, new Guid("9f7014d9-5c08-1789-3a02-8eb39bddbaf3") },
                    { new Guid("6f3c1082-43c1-fb3a-ad38-cbaf72e294c9"), true, false, true, new Guid("861e45e9-83ae-dfd8-bd5d-0ef11721678b") },
                    { new Guid("84ca23da-f0da-2b9d-c67d-d87ce850ba1c"), true, false, false, new Guid("861e45e9-83ae-dfd8-bd5d-0ef11721678b") },
                    { new Guid("948d0a54-146b-53e3-9e7e-c660e6044b40"), true, true, true, new Guid("fdf820d9-c338-29ed-51ba-2b08c27dde78") },
                    { new Guid("95f03a80-9d56-7196-f6dc-b62521dfdb22"), false, false, false, new Guid("2a90f707-ef40-848e-655d-09c8d4da8584") },
                    { new Guid("ab67e44a-91f9-6454-8967-37a384949956"), true, true, true, new Guid("0ddde7b3-07a3-806f-c8b3-1526d00d919c") },
                    { new Guid("ae6496b4-59c9-3b23-89d9-99ade1a1a5b1"), false, true, false, new Guid("efd419a6-2c40-992a-04a4-096403822f12") },
                    { new Guid("dc9c54c5-4aff-0def-4f79-2e35017cb1f1"), false, true, false, new Guid("2c610ffc-4eec-2c5b-7603-967b66f44ea5") },
                    { new Guid("e76a3a39-8650-a082-8b1a-bc72abe2dc7a"), false, false, false, new Guid("2a75148c-98fd-42b4-6b80-780c6db4d0c7") },
                    { new Guid("f7c8f77b-8fe3-c9d9-3ee8-72cae6a8e623"), true, true, true, new Guid("1667e15e-5f5b-0181-8850-169137d167cd") },
                    { new Guid("f9443af2-7687-779f-86db-402613fef46b"), false, false, false, new Guid("bedf3932-121d-0819-a1e3-b5136670f2d3") }
                });

            migrationBuilder.InsertData(
                table: "Screenings",
                columns: new[] { "Id", "MovieId", "Price", "RoomId", "ScreeningStart" },
                values: new object[,]
                {
                    { new Guid("0301eead-236e-4735-6129-e911bef45b78"), new Guid("c7ede41b-7030-4f7b-e7ad-e43f9fbe825a"), 0.85119705517152011, new Guid("639d0ee2-7261-cce1-96ba-ff7e27672fc9"), new TimeOnly(22, 30, 0, 74).Add(TimeSpan.FromTicks(9888)) },
                    { new Guid("1c3c633b-d9f3-072b-34f3-bb9c5098d8ed"), new Guid("f41b3d1c-39a5-990f-8680-ea3db106a902"), 0.84065224426251817, new Guid("2a394d02-3320-1567-3f28-61004b48cbbb"), new TimeOnly(22, 48, 38, 650).Add(TimeSpan.FromTicks(3700)) },
                    { new Guid("23a9bac0-50a4-4bcf-c976-0ac64cc28802"), new Guid("39affed0-6c9f-eda9-36cb-77659dfb494e"), 0.67691786187507175, new Guid("4cbe778f-8510-835e-276c-a9de1824ae2a"), new TimeOnly(22, 9, 28, 84).Add(TimeSpan.FromTicks(4568)) },
                    { new Guid("23f6cd6f-fdcf-f841-1ecf-1c83eb57a6f8"), new Guid("f41b3d1c-39a5-990f-8680-ea3db106a902"), 0.032690707541736197, new Guid("2b83e612-3f9f-e685-fa3f-e46ef2dc346b"), new TimeOnly(22, 39, 34, 584).Add(TimeSpan.FromTicks(3666)) },
                    { new Guid("2c16d4fb-4f59-2b6f-0cd7-36fbf287db0c"), new Guid("8bb63896-23f1-67f9-9858-7445f9cd14e7"), 0.14189463473642194, new Guid("cdfa04ab-9594-24da-db1d-9893f3d86d63"), new TimeOnly(22, 54, 8, 781).Add(TimeSpan.FromTicks(168)) },
                    { new Guid("2de56ddb-a30f-84d7-2b5d-34262f94ea4a"), new Guid("5fa30ad0-07cb-dcf7-09d3-5b5eed7602ed"), 0.11054276207336011, new Guid("c87d7934-ddbd-ae91-3807-e9d4c6d5cdc4"), new TimeOnly(22, 15, 53, 869).Add(TimeSpan.FromTicks(3873)) },
                    { new Guid("3943ba43-e53d-94da-0f64-f6b0a11efdd1"), new Guid("f41b3d1c-39a5-990f-8680-ea3db106a902"), 0.41456930745139486, new Guid("cdfa04ab-9594-24da-db1d-9893f3d86d63"), new TimeOnly(22, 20, 55, 671).Add(TimeSpan.FromTicks(499)) },
                    { new Guid("3c7f9c66-5e5e-c101-2dd8-4f52c584f46f"), new Guid("6410650a-2117-d079-f9f6-fa3ba87b8ae5"), 0.20423383135986894, new Guid("2a394d02-3320-1567-3f28-61004b48cbbb"), new TimeOnly(22, 52, 38, 338).Add(TimeSpan.FromTicks(6934)) },
                    { new Guid("420a5708-1f19-7818-00d3-f935e7681ed0"), new Guid("6410650a-2117-d079-f9f6-fa3ba87b8ae5"), 0.99418388068941832, new Guid("9f56df9a-6b9e-81a4-0dd1-f1d3208366f1"), new TimeOnly(22, 28, 22, 262).Add(TimeSpan.FromTicks(1395)) },
                    { new Guid("44f80959-85a4-c8a0-05a2-7dfff8a1aec4"), new Guid("6410650a-2117-d079-f9f6-fa3ba87b8ae5"), 0.97251661839215797, new Guid("ddec5271-0145-d501-936a-7ba0570d2da0"), new TimeOnly(22, 9, 24, 482).Add(TimeSpan.FromTicks(6930)) },
                    { new Guid("603459c3-99a8-1940-3811-c739af6f6544"), new Guid("569bc1e3-3395-cfc7-e803-e22383534e72"), 0.68390924219884952, new Guid("920c5171-fd52-2a29-f437-76a2a7d254ca"), new TimeOnly(22, 39, 30, 504).Add(TimeSpan.FromTicks(2198)) },
                    { new Guid("63db84f1-2a0e-1ab6-ca56-8ce0ce642a7b"), new Guid("5bc3ff93-5b24-5359-f880-058a48018d9f"), 0.38490178021346966, new Guid("36352770-5651-d38a-f32d-31dc3ff57ebd"), new TimeOnly(22, 10, 29, 997).Add(TimeSpan.FromTicks(8722)) },
                    { new Guid("69a53759-061b-f379-3714-f295c5d9b955"), new Guid("a9b240ec-b72b-a3ad-4e1f-a0fc02e70f71"), 0.47424439791033179, new Guid("790caa0b-534e-d670-7d1d-e7c2948bf34b"), new TimeOnly(22, 23, 41, 601).Add(TimeSpan.FromTicks(1442)) },
                    { new Guid("741a042c-e93c-75a0-bd40-19d57e6990f0"), new Guid("07f01b02-0ad8-1c82-0e95-b04f0771b1f9"), 0.13905105164034037, new Guid("67d62666-9b79-0369-c6d0-1cd1514b2774"), new TimeOnly(22, 20, 27, 784).Add(TimeSpan.FromTicks(7626)) },
                    { new Guid("7c75441f-d75b-fe25-026f-135094f36b4a"), new Guid("00d2ae28-de44-dda7-396c-bef5ef8f8eb7"), 0.30151719815364797, new Guid("d1517b86-2072-b394-0e0c-475f00b81de3"), new TimeOnly(22, 27, 13, 325).Add(TimeSpan.FromTicks(7868)) },
                    { new Guid("84a02bb0-6f5b-9c6d-e2d4-5c756c27e68b"), new Guid("4910d7b1-006a-9299-a3de-d40beec4e6d8"), 0.17890663797147388, new Guid("434f601b-f7c3-d780-39a4-d33fef4737d7"), new TimeOnly(22, 45, 33, 436).Add(TimeSpan.FromTicks(8052)) },
                    { new Guid("a3110358-0c5d-a505-3663-3eb3c9edab94"), new Guid("569bc1e3-3395-cfc7-e803-e22383534e72"), 0.54604647323601196, new Guid("c87d7934-ddbd-ae91-3807-e9d4c6d5cdc4"), new TimeOnly(22, 18, 16, 634).Add(TimeSpan.FromTicks(8303)) },
                    { new Guid("ae676ffd-d4c4-6804-d08e-ae9b4f313f2d"), new Guid("c7ede41b-7030-4f7b-e7ad-e43f9fbe825a"), 0.92184230869523742, new Guid("1ff119fa-e72d-6f5e-9a06-ba05118a23ce"), new TimeOnly(22, 12, 54, 848).Add(TimeSpan.FromTicks(5578)) },
                    { new Guid("b1c3f427-17cb-d39d-2883-edfbea3981fc"), new Guid("99475bc1-2f38-3793-73eb-a8ab80247a62"), 0.57276559764987178, new Guid("0945aafe-6dc1-a59f-50ba-a94d0e21fe59"), new TimeOnly(22, 36, 21, 402).Add(TimeSpan.FromTicks(9224)) },
                    { new Guid("b7cea934-b7c6-1c75-4fe4-65c077cea28b"), new Guid("00d2ae28-de44-dda7-396c-bef5ef8f8eb7"), 0.74465941177666262, new Guid("db8d2325-4933-e468-3dbb-78a406240ed8"), new TimeOnly(22, 50, 57, 513).Add(TimeSpan.FromTicks(1410)) },
                    { new Guid("b8f4b8c4-d095-25d5-c7a2-49620b3b1842"), new Guid("6cbe7df2-753a-71c1-550d-d39ad912a8d6"), 0.94646515949289656, new Guid("920c5171-fd52-2a29-f437-76a2a7d254ca"), new TimeOnly(22, 44, 27, 818).Add(TimeSpan.FromTicks(3091)) },
                    { new Guid("c519a109-cf24-a473-3bf7-7c943d61936b"), new Guid("dff1c775-39b4-8147-5bb2-cae0152b7d72"), 0.2980893975232739, new Guid("200f96fc-84a7-7023-2721-992db26fde72"), new TimeOnly(22, 3, 1, 831).Add(TimeSpan.FromTicks(1340)) },
                    { new Guid("d7033ff4-c2da-93dd-8c73-7f775643a936"), new Guid("a9b240ec-b72b-a3ad-4e1f-a0fc02e70f71"), 0.4186631892891719, new Guid("f5b34448-cd38-73e1-8206-2e5c39084ff4"), new TimeOnly(22, 33, 12, 162).Add(TimeSpan.FromTicks(1940)) },
                    { new Guid("e854d5d4-d52e-a487-337b-12d9fd428075"), new Guid("c0837db4-f428-1185-6dbe-030893b588b2"), 0.9880700810604307, new Guid("434f601b-f7c3-d780-39a4-d33fef4737d7"), new TimeOnly(22, 39, 25, 711).Add(TimeSpan.FromTicks(3021)) },
                    { new Guid("eacf52a0-e003-b6d0-11b0-6c56c19fd308"), new Guid("6410650a-2117-d079-f9f6-fa3ba87b8ae5"), 0.60955370695666944, new Guid("579b9ab9-ee9a-fecc-dd6b-5bf20f8ba3c3"), new TimeOnly(22, 2, 43, 23).Add(TimeSpan.FromTicks(1710)) },
                    { new Guid("ec5e65f0-bcd3-0e8c-6470-28a9aac0c46d"), new Guid("99475bc1-2f38-3793-73eb-a8ab80247a62"), 0.2453805699127477, new Guid("9f56df9a-6b9e-81a4-0dd1-f1d3208366f1"), new TimeOnly(22, 24, 9, 32).Add(TimeSpan.FromTicks(7243)) },
                    { new Guid("ee34aeff-328b-5678-273e-4d280036bdd5"), new Guid("f41b3d1c-39a5-990f-8680-ea3db106a902"), 0.69822865246760824, new Guid("3a4c24bf-b9d4-d734-f6f1-dc33587fbcd5"), new TimeOnly(22, 2, 14, 460).Add(TimeSpan.FromTicks(5427)) },
                    { new Guid("eecbbbf5-c965-55e5-1dd0-fdb0a5f098d0"), new Guid("4910d7b1-006a-9299-a3de-d40beec4e6d8"), 0.056709325479095241, new Guid("434f601b-f7c3-d780-39a4-d33fef4737d7"), new TimeOnly(22, 54, 59, 519).Add(TimeSpan.FromTicks(3088)) },
                    { new Guid("f2b6b89d-020d-7634-726b-47b53a88d7d1"), new Guid("39affed0-6c9f-eda9-36cb-77659dfb494e"), 0.29052484523243405, new Guid("579b9ab9-ee9a-fecc-dd6b-5bf20f8ba3c3"), new TimeOnly(22, 25, 20, 561).Add(TimeSpan.FromTicks(8774)) },
                    { new Guid("f42d2d0f-1395-7526-cb1b-0d295bdc5cc6"), new Guid("8bb63896-23f1-67f9-9858-7445f9cd14e7"), 0.033726521798515874, new Guid("f04bf802-bdee-7722-a2d7-c5525b770409"), new TimeOnly(22, 36, 36, 920).Add(TimeSpan.FromTicks(8101)) }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Number", "RoomId", "Row" },
                values: new object[,]
                {
                    { new Guid("09a2f946-9fc5-d1a1-37e7-d14654ca9eef"), 1502754476, new Guid("9eb48871-442c-3d67-9c71-7afa0b789542"), -1342352726 },
                    { new Guid("1010b384-3f28-f67b-fe08-f38df88fd3a1"), -197836628, new Guid("2ed8933f-07ad-3e3c-ae36-581dc3b7a45c"), 1764411812 },
                    { new Guid("20a5f9c4-b49a-18c1-2670-506c9f9d194f"), -556745613, new Guid("103f1afe-9a98-0b26-0700-9cefc96c7e06"), -1796347352 },
                    { new Guid("3b5ba103-9011-a039-19b4-b9ff6498309d"), -1838282697, new Guid("1ff119fa-e72d-6f5e-9a06-ba05118a23ce"), 828780847 },
                    { new Guid("3c39024b-053a-ff25-6738-fc37db2678c6"), -1427292086, new Guid("0204be48-99ae-3b9d-cc4c-93d827a99790"), -283350271 },
                    { new Guid("4e5bc10b-c5ed-76cb-e848-c2d2bb6fd77a"), -1297569127, new Guid("639d0ee2-7261-cce1-96ba-ff7e27672fc9"), 735626386 },
                    { new Guid("53f91657-956d-669d-8807-ececc796f7d8"), 772140154, new Guid("3a4c24bf-b9d4-d734-f6f1-dc33587fbcd5"), -1549272118 },
                    { new Guid("573e2542-cb93-7e8b-b478-9024ec62bb6d"), 1803202424, new Guid("200f96fc-84a7-7023-2721-992db26fde72"), -466121768 },
                    { new Guid("5f255715-523a-c32e-e996-7dd88f61a8de"), -463556738, new Guid("2ed8933f-07ad-3e3c-ae36-581dc3b7a45c"), 1690413053 },
                    { new Guid("64aa8d74-1c3f-ff11-2259-f67d4c833d89"), -80970931, new Guid("434f601b-f7c3-d780-39a4-d33fef4737d7"), 2099851038 },
                    { new Guid("64f3da82-f49d-9f5b-88de-ebd82a37ce3f"), -1788065544, new Guid("0204be48-99ae-3b9d-cc4c-93d827a99790"), -263034476 },
                    { new Guid("66aa2f71-5db7-e709-61d2-edc2f2e216d2"), -670326723, new Guid("ae843e55-102d-23d7-ea30-6b31c0d77b06"), -718790746 },
                    { new Guid("693ec9f3-1326-1e08-e349-f52866334d60"), -1031596633, new Guid("ddec5271-0145-d501-936a-7ba0570d2da0"), -1507262288 },
                    { new Guid("7965f8a3-6698-d7e4-e9f9-a2292e1db023"), 1168380520, new Guid("0945aafe-6dc1-a59f-50ba-a94d0e21fe59"), 1709822086 },
                    { new Guid("7bf3f69f-804b-4385-0f43-a25a95b39460"), -1268854814, new Guid("3526225b-984b-3b06-1938-7d9a6d8277e8"), -912101437 },
                    { new Guid("7ea0c320-f9cd-eec5-d1f6-bf7885030ef7"), -1039865362, new Guid("4cbe778f-8510-835e-276c-a9de1824ae2a"), 767072248 },
                    { new Guid("7f6bef18-bb8f-49b0-def7-3716270f70d4"), 1802952696, new Guid("434f601b-f7c3-d780-39a4-d33fef4737d7"), 149446195 },
                    { new Guid("8555674d-8844-8115-4d1b-f76063f8550d"), -1724302649, new Guid("0945aafe-6dc1-a59f-50ba-a94d0e21fe59"), 1263568244 },
                    { new Guid("8c274a05-e36d-6707-834f-54b193ae6f38"), -652157737, new Guid("d1517b86-2072-b394-0e0c-475f00b81de3"), 1336213226 },
                    { new Guid("8c954223-0a6a-a500-967b-60ee79d84c9e"), 42572624, new Guid("1ff119fa-e72d-6f5e-9a06-ba05118a23ce"), 695835383 },
                    { new Guid("a4bbfad1-d333-1cd6-c682-71d32027607b"), 1723315360, new Guid("790caa0b-534e-d670-7d1d-e7c2948bf34b"), 1578748842 },
                    { new Guid("ae289c4d-42e5-335d-ee50-64e58d2d26c3"), 1966002567, new Guid("790caa0b-534e-d670-7d1d-e7c2948bf34b"), 2121325284 },
                    { new Guid("b451e2c7-3ce8-a5bf-5bb4-84c6f069fc0d"), -1790864098, new Guid("67d62666-9b79-0369-c6d0-1cd1514b2774"), 305886329 },
                    { new Guid("b9e7030b-cc9e-8500-e6b3-fca517914eb7"), 869013522, new Guid("f5b34448-cd38-73e1-8206-2e5c39084ff4"), 1441306841 },
                    { new Guid("c2683688-2c41-3772-6cee-62e0d37bab6c"), 1195937316, new Guid("0945aafe-6dc1-a59f-50ba-a94d0e21fe59"), -1282208698 },
                    { new Guid("e912ae02-f058-cd0a-07a4-568246d8edd7"), 1365064660, new Guid("c87d7934-ddbd-ae91-3807-e9d4c6d5cdc4"), 887829639 },
                    { new Guid("f11dbc8e-7c17-4671-b527-1b07630dbcd0"), -489153144, new Guid("67d62666-9b79-0369-c6d0-1cd1514b2774"), -1598410107 },
                    { new Guid("f374b66f-18d6-cb96-af0d-8d9e96d49ab7"), -1365326945, new Guid("752e26cf-3203-2a0a-6c40-4577fbb92652"), 779796912 },
                    { new Guid("f46da7fa-2d6d-2445-c447-6a8614ef888b"), 1533684822, new Guid("0945aafe-6dc1-a59f-50ba-a94d0e21fe59"), -1119227455 },
                    { new Guid("fafd3deb-e8b4-46c0-6af7-8cbdbe15439e"), -779909895, new Guid("ae843e55-102d-23d7-ea30-6b31c0d77b06"), 518340433 }
                });

            migrationBuilder.InsertData(
                table: "ReservedSeats",
                columns: new[] { "Id", "ReservationId", "ScreeningId", "SeatId" },
                values: new object[,]
                {
                    { new Guid("0b372f28-17c6-4328-9399-3b5cd69aa8a6"), new Guid("3cf07940-2ee4-a23b-1019-96064ea32b07"), new Guid("603459c3-99a8-1940-3811-c739af6f6544"), new Guid("7965f8a3-6698-d7e4-e9f9-a2292e1db023") },
                    { new Guid("0c8c07c6-1776-1c93-9b55-3407173e3a13"), new Guid("052cfc28-9529-6f06-c04a-2bba2c496bf9"), new Guid("23f6cd6f-fdcf-f841-1ecf-1c83eb57a6f8"), new Guid("20a5f9c4-b49a-18c1-2670-506c9f9d194f") },
                    { new Guid("0f2fcdf9-f510-78bb-a55d-65800511adce"), new Guid("3a18c610-76fd-3436-4725-8d363f7c73db"), new Guid("2c16d4fb-4f59-2b6f-0cd7-36fbf287db0c"), new Guid("c2683688-2c41-3772-6cee-62e0d37bab6c") },
                    { new Guid("102adadf-b79a-e66d-baec-5fd155ac2050"), new Guid("f7c8f77b-8fe3-c9d9-3ee8-72cae6a8e623"), new Guid("e854d5d4-d52e-a487-337b-12d9fd428075"), new Guid("573e2542-cb93-7e8b-b478-9024ec62bb6d") },
                    { new Guid("1a3044a1-a6d5-548e-7a36-fadb3ada7d85"), new Guid("5999ac9c-370b-6104-5209-c680f6bd67f3"), new Guid("7c75441f-d75b-fe25-026f-135094f36b4a"), new Guid("3b5ba103-9011-a039-19b4-b9ff6498309d") },
                    { new Guid("297e4cbf-86a5-cd16-9802-7bbc5fda7b49"), new Guid("4eafb22d-a453-6a55-2d85-19915fdb85c9"), new Guid("63db84f1-2a0e-1ab6-ca56-8ce0ce642a7b"), new Guid("e912ae02-f058-cd0a-07a4-568246d8edd7") },
                    { new Guid("36bc59bc-4181-2acd-2b84-857892c326e3"), new Guid("95f03a80-9d56-7196-f6dc-b62521dfdb22"), new Guid("eacf52a0-e003-b6d0-11b0-6c56c19fd308"), new Guid("b9e7030b-cc9e-8500-e6b3-fca517914eb7") },
                    { new Guid("429af00c-e27a-e11d-9c7d-ce8c980d4b2f"), new Guid("43c57ffa-cd69-5ea5-f99f-41fcbfd5845c"), new Guid("420a5708-1f19-7818-00d3-f935e7681ed0"), new Guid("64aa8d74-1c3f-ff11-2259-f67d4c833d89") },
                    { new Guid("4ad982fd-4239-9811-84b6-6834f3346b41"), new Guid("ab67e44a-91f9-6454-8967-37a384949956"), new Guid("603459c3-99a8-1940-3811-c739af6f6544"), new Guid("8555674d-8844-8115-4d1b-f76063f8550d") },
                    { new Guid("52bd94e6-3848-f04a-3012-c028d0ea4283"), new Guid("052cfc28-9529-6f06-c04a-2bba2c496bf9"), new Guid("f42d2d0f-1395-7526-cb1b-0d295bdc5cc6"), new Guid("ae289c4d-42e5-335d-ee50-64e58d2d26c3") },
                    { new Guid("5a54aca9-3813-e4d6-4e2f-c49507f16b04"), new Guid("dc9c54c5-4aff-0def-4f79-2e35017cb1f1"), new Guid("eecbbbf5-c965-55e5-1dd0-fdb0a5f098d0"), new Guid("20a5f9c4-b49a-18c1-2670-506c9f9d194f") },
                    { new Guid("62bcddc8-4f71-8692-a809-54ba55c701b5"), new Guid("093d76aa-cbf6-0fd7-eff4-5a49bed9fc63"), new Guid("d7033ff4-c2da-93dd-8c73-7f775643a936"), new Guid("a4bbfad1-d333-1cd6-c682-71d32027607b") },
                    { new Guid("6ecf63d1-0c46-0523-42b7-e259f19f416e"), new Guid("5999ac9c-370b-6104-5209-c680f6bd67f3"), new Guid("f42d2d0f-1395-7526-cb1b-0d295bdc5cc6"), new Guid("e912ae02-f058-cd0a-07a4-568246d8edd7") },
                    { new Guid("7515bc7d-2a9f-e876-8d83-ad6136bc605b"), new Guid("dc9c54c5-4aff-0def-4f79-2e35017cb1f1"), new Guid("ec5e65f0-bcd3-0e8c-6470-28a9aac0c46d"), new Guid("7bf3f69f-804b-4385-0f43-a25a95b39460") },
                    { new Guid("80ebd375-dc0f-49f5-f53a-e030c0c8bb53"), new Guid("0bdee1d0-3fec-9cd7-fe82-843ff00a4bfb"), new Guid("f42d2d0f-1395-7526-cb1b-0d295bdc5cc6"), new Guid("20a5f9c4-b49a-18c1-2670-506c9f9d194f") },
                    { new Guid("81002514-dd06-ed0a-2680-6a0410315ebb"), new Guid("ab67e44a-91f9-6454-8967-37a384949956"), new Guid("ae676ffd-d4c4-6804-d08e-ae9b4f313f2d"), new Guid("c2683688-2c41-3772-6cee-62e0d37bab6c") },
                    { new Guid("823a492d-d155-64a0-6cf7-ee0b268a088e"), new Guid("84ca23da-f0da-2b9d-c67d-d87ce850ba1c"), new Guid("f2b6b89d-020d-7634-726b-47b53a88d7d1"), new Guid("4e5bc10b-c5ed-76cb-e848-c2d2bb6fd77a") },
                    { new Guid("82f5f10f-e929-2500-b586-c31b42f98661"), new Guid("ae6496b4-59c9-3b23-89d9-99ade1a1a5b1"), new Guid("7c75441f-d75b-fe25-026f-135094f36b4a"), new Guid("8c274a05-e36d-6707-834f-54b193ae6f38") },
                    { new Guid("84d7bd14-d1e1-4168-968f-ac199c614436"), new Guid("e76a3a39-8650-a082-8b1a-bc72abe2dc7a"), new Guid("23f6cd6f-fdcf-f841-1ecf-1c83eb57a6f8"), new Guid("8c954223-0a6a-a500-967b-60ee79d84c9e") },
                    { new Guid("8709d0fe-c180-08ec-5398-16b589629c28"), new Guid("2b412908-c9ae-5607-36c7-4ec2ed007981"), new Guid("b7cea934-b7c6-1c75-4fe4-65c077cea28b"), new Guid("64aa8d74-1c3f-ff11-2259-f67d4c833d89") },
                    { new Guid("96162bb0-c873-fe2e-e714-5af4571f4de1"), new Guid("5999ac9c-370b-6104-5209-c680f6bd67f3"), new Guid("f42d2d0f-1395-7526-cb1b-0d295bdc5cc6"), new Guid("f11dbc8e-7c17-4671-b527-1b07630dbcd0") },
                    { new Guid("9d66049a-69aa-ff0d-758f-f2702a68c8e2"), new Guid("57dc112c-f48a-2fee-567d-63937ce2fc88"), new Guid("f42d2d0f-1395-7526-cb1b-0d295bdc5cc6"), new Guid("8555674d-8844-8115-4d1b-f76063f8550d") },
                    { new Guid("a03e841a-0abf-8682-b9cd-9cba6e39b32f"), new Guid("e76a3a39-8650-a082-8b1a-bc72abe2dc7a"), new Guid("b8f4b8c4-d095-25d5-c7a2-49620b3b1842"), new Guid("fafd3deb-e8b4-46c0-6af7-8cbdbe15439e") },
                    { new Guid("abefb389-ecef-ce54-079c-82b4c2fb14e0"), new Guid("6c043937-816c-cc64-313b-8a0ada7510ec"), new Guid("7c75441f-d75b-fe25-026f-135094f36b4a"), new Guid("7965f8a3-6698-d7e4-e9f9-a2292e1db023") },
                    { new Guid("ad520608-6434-82ee-9dfb-d437a752b971"), new Guid("087b1479-549a-e6ef-cd8c-26905a30cf44"), new Guid("7c75441f-d75b-fe25-026f-135094f36b4a"), new Guid("7965f8a3-6698-d7e4-e9f9-a2292e1db023") },
                    { new Guid("b492577e-36d6-db9a-ca0c-d291c21a8a13"), new Guid("95f03a80-9d56-7196-f6dc-b62521dfdb22"), new Guid("84a02bb0-6f5b-9c6d-e2d4-5c756c27e68b"), new Guid("573e2542-cb93-7e8b-b478-9024ec62bb6d") },
                    { new Guid("bc552c5e-75f4-8d27-8799-3c0ee96598b9"), new Guid("ae6496b4-59c9-3b23-89d9-99ade1a1a5b1"), new Guid("603459c3-99a8-1940-3811-c739af6f6544"), new Guid("f11dbc8e-7c17-4671-b527-1b07630dbcd0") },
                    { new Guid("c50b8b4e-e6f2-f626-5cfe-5a7912935b53"), new Guid("f9443af2-7687-779f-86db-402613fef46b"), new Guid("44f80959-85a4-c8a0-05a2-7dfff8a1aec4"), new Guid("b451e2c7-3ce8-a5bf-5bb4-84c6f069fc0d") },
                    { new Guid("f205c41a-2862-6887-a0ee-129903335c86"), new Guid("11fadcd4-f585-862b-3a71-77a23586237a"), new Guid("0301eead-236e-4735-6129-e911bef45b78"), new Guid("f11dbc8e-7c17-4671-b527-1b07630dbcd0") },
                    { new Guid("fe76d441-b59a-43a5-a42c-cfb844d09cd9"), new Guid("0b318129-7fe5-606a-7e2e-4511a2717186"), new Guid("b8f4b8c4-d095-25d5-c7a2-49620b3b1842"), new Guid("f11dbc8e-7c17-4671-b527-1b07630dbcd0") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_ActorId",
                table: "MovieActors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_GenreId",
                table: "MovieGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservedSeats_ReservationId",
                table: "ReservedSeats",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservedSeats_ScreeningId",
                table: "ReservedSeats",
                column: "ScreeningId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservedSeats_SeatId",
                table: "ReservedSeats",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_MovieId",
                table: "Screenings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_RoomId",
                table: "Screenings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_RoomId",
                table: "Seats",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "ReservedSeats");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Screenings");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
