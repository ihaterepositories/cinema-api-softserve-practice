using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cinema.DAL.Migrations
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
                    StartDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
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
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsPaid = table.Column<bool>(type: "INTEGER", nullable: false)
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
                    ScreeningId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsReserved = table.Column<bool>(type: "INTEGER", nullable: false)
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
                    { new Guid("18db48e5-67ab-0257-f3c5-67a4e4edf917"), "Nesciunt qui consequuntur.\nNemo quidem beatae incidunt tempore ducimus.\nEsse voluptatem sit beatae est.", "Joey Brakus", "http://lula.com" },
                    { new Guid("25ff30a1-b041-cf49-2306-677828e96604"), "Sapiente quas non voluptatem laudantium et labore unde dolorem hic.\nLaboriosam necessitatibus aut rerum consectetur dicta vel non.\nEt nesciunt est vel nesciunt consectetur voluptas eum.", "Susana Hegmann", "http://arvilla.net" },
                    { new Guid("28a37c20-d73c-88cd-53c1-3cbffeb51c17"), "Maxime soluta sunt eum.\nEst dolores saepe non perferendis non quia numquam et cupiditate.", "Serenity Williamson", "http://jean.name" },
                    { new Guid("40defcb6-bd96-0d22-9dc9-6cfbf9aea068"), "Itaque eius rerum.\nLaboriosam vero cumque velit omnis cupiditate non et.\nIn voluptatem quibusdam reprehenderit praesentium occaecati quae et adipisci praesentium.", "Jasper Jerde", "https://brayan.com" },
                    { new Guid("4389a4f3-0e10-3b14-6147-1b76875f79cb"), "Autem quia architecto praesentium et eos vero.\nEt iusto omnis consequatur beatae odit.\nPariatur labore in quam.\nIn sed veniam.", "Brennon Windler", "https://kailey.net" },
                    { new Guid("48da9995-067e-e188-572f-e90fb110dbed"), "Quaerat repellendus sit.\nAt voluptas assumenda.\nUt commodi maiores omnis cupiditate dolores.", "Bill Toy", "http://everett.info" },
                    { new Guid("50aa9838-31f3-d65c-4cb7-5e71fb127b99"), "Fugiat optio nam ut impedit deleniti et nesciunt nostrum.\nImpedit eum harum consequatur unde cumque.\nLibero quo quia possimus.\nVoluptas eos sunt ut aperiam itaque reprehenderit explicabo.\nQuo voluptatem nostrum odio quidem.\nReiciendis ratione voluptate et.", "Jany Lesch", "http://wyman.org" },
                    { new Guid("5a0063ff-80ca-8782-7d23-410297f3033a"), "Ut voluptatem eveniet deserunt quas id sed.\nEt impedit maxime eum ipsum officiis ex eos.", "Tiana Beier", "https://lambert.biz" },
                    { new Guid("5b28b195-0667-c561-5bc7-43229b7d36dc"), "Qui reiciendis vero iste eaque maxime numquam incidunt qui vitae.\nBeatae vitae dolor quo sequi occaecati occaecati provident enim sed.\nMinus repudiandae consequatur aut.\nPerspiciatis amet eveniet et tempora ut quia dolorem quis sapiente.", "Charlie Mitchell", "http://kara.info" },
                    { new Guid("5c38f0f4-9c06-e566-94f0-5306ac2d1bde"), "Ducimus voluptas aut laudantium repellat dolores quam distinctio error quidem.\nDolores doloremque quam perspiciatis cum et aut alias.\nVeritatis sequi possimus nemo.", "Graciela Crona", "https://keon.net" },
                    { new Guid("5cb2d94e-1941-3efd-9006-c7f7c127c33a"), "Omnis mollitia aut ratione ipsa rerum officiis ut eveniet.\nDolores voluptatem dicta adipisci facilis.\nQuisquam est occaecati dolorum ab iste corrupti.\nEt culpa esse voluptatem ullam accusamus iure.", "Erich Haag", "https://peter.org" },
                    { new Guid("61f8fc5c-c892-ba8a-03b9-746d3283b5ca"), "Quis reprehenderit ut omnis repellat soluta quia nam nisi dolore.\nLibero atque earum quam laudantium sint occaecati est labore et.\nEt consequatur quae.\nSapiente qui minus quia natus quis perspiciatis et maiores.", "Harley Altenwerth", "http://donnie.com" },
                    { new Guid("622dbb41-751c-a03c-c669-b92fa35336d9"), "Aut deleniti ex.\nIpsam distinctio fugit deserunt quia aut saepe.\nQui non reiciendis.\nEum non ducimus.\nMinus corporis debitis laudantium.\nEum quasi repellendus aliquam voluptates nam et.", "Lorenzo Predovic", "http://elmo.org" },
                    { new Guid("63e9676a-d28e-0a22-d0bb-3660d309ed3b"), "At expedita velit corporis aliquam.\nIpsum enim est quae ab et.", "Myrtice Senger", "http://elliott.net" },
                    { new Guid("6805c441-682f-f6b2-b905-ab66af49f5d3"), "Dolor rerum autem.\nSuscipit distinctio odio consequatur cumque dolore laudantium.", "Maria Jenkins", "http://janie.com" },
                    { new Guid("6f597be6-9525-a6f7-c023-6af2d3ec46b7"), "Quas eligendi labore et.\nQuis qui provident dolores.\nCupiditate ducimus totam autem quo provident rerum.", "Alfonso Rodriguez", "http://heath.biz" },
                    { new Guid("7a320366-8215-55af-445e-7ad6e2a454e6"), "Deleniti sit aut assumenda et quas aut magnam sed saepe.\nAut aut eveniet necessitatibus molestiae temporibus.\nCulpa quis deserunt eos.\nQuia quo laudantium.", "Jasper Cole", "https://alicia.com" },
                    { new Guid("9772e030-4279-2df3-a745-4c592cbccf0a"), "Consequatur aliquid sit aliquam id ipsum adipisci commodi voluptate.\nBlanditiis vitae quae nobis ut asperiores dolorem.", "Ivy Nolan", "https://dimitri.name" },
                    { new Guid("982f5f1d-7b3e-1ce9-24e6-326b6201870b"), "Laboriosam nobis quam.\nA rerum recusandae.", "Leopold Konopelski", "https://elliott.com" },
                    { new Guid("99540b23-2e38-39f0-490f-9f98f0148d03"), "Laborum eius consectetur quaerat blanditiis consequatur non nihil.\nAtque soluta est non consequatur laboriosam expedita aut et.\nConsequatur accusamus libero illum.\nSed odio enim reiciendis et laudantium unde ipsa.\nNostrum velit praesentium et autem maiores doloremque et.\nDicta voluptatem explicabo laboriosam non saepe voluptas sed.", "Rosalinda McLaughlin", "https://maurine.net" },
                    { new Guid("9c2cfac9-09c2-d5b6-eae1-f230f0bfe836"), "Ea odio excepturi aperiam dolores ipsum exercitationem ipsum.\nProvident velit omnis eos aut distinctio a molestias.\nAb nesciunt voluptatem aut delectus facere velit.\nDolorem quaerat sunt aliquam modi voluptatem perspiciatis adipisci ex.", "Berenice Kshlerin", "http://alta.net" },
                    { new Guid("b1707a99-5f65-07f2-3789-e9bd57247045"), "Id consectetur inventore rerum consequatur libero assumenda officia dolores.\nEum laborum fuga qui hic amet sit commodi consectetur.\nAut qui voluptatem ut.\nAnimi vel sit dolore amet.\nQui aut soluta repudiandae sequi expedita aut blanditiis et.", "Keara Breitenberg", "http://freddie.name" },
                    { new Guid("b6bc8e8d-996a-76ae-0fae-d575d02edbc6"), "Sapiente cumque autem.\nEst dolores et amet dolores reiciendis repellat nisi itaque eligendi.\nAd quia dolorem.\nVel ea eos ipsam esse.\nDignissimos sint facilis iusto nemo qui consequatur cum.\nNihil excepturi voluptatem.", "Daniela Brekke", "http://roma.info" },
                    { new Guid("b9d7366b-53f3-c3b4-15da-c064fcef82d2"), "Impedit autem et.\nFugit nihil aut quod ex.\nCorrupti aut repellat et aperiam.\nConsequatur totam ipsum sit et voluptate consequuntur vel dolorem adipisci.\nAdipisci officiis laboriosam quasi temporibus veritatis beatae enim quo voluptas.\nAliquid aut dolorem.", "Gaetano West", "http://augustus.org" },
                    { new Guid("d08b2aa0-a1d0-7943-9170-c33f2a0d6b71"), "Veritatis libero nobis dolore quo ullam.\nUllam sed dolor aut nostrum molestias ducimus quia.", "Charlotte Labadie", "https://maddison.org" },
                    { new Guid("d0cabe5c-ed7f-05d1-abab-6335590cf775"), "Mollitia voluptates inventore nulla molestias dolores.\nEnim impedit in eligendi qui ipsa sed quos ea doloribus.\nPerferendis excepturi vitae quas minima voluptatem mollitia id sequi.", "Eleanore Rogahn", "https://marianne.info" },
                    { new Guid("d7183597-f883-8142-ae41-a68bc1820c2a"), "Sint sapiente iusto eius qui rerum nulla.\nError non minus velit sequi iste rerum repellendus fuga.\nVelit alias explicabo odit.\nDistinctio ipsum placeat iste saepe eius est.\nHic possimus aut sed sed.\nNihil id voluptatem sed perferendis dicta.", "Angela Stoltenberg", "http://terrell.biz" },
                    { new Guid("e074bce8-3b65-56d8-3bb9-1b1bbec75166"), "Velit voluptatem eum quibusdam sed quam deleniti illum temporibus.\nDeserunt sed assumenda nisi esse libero.\nEst ducimus harum voluptatem et.\nSimilique perspiciatis ad et.\nNeque autem et beatae vel dolor quae temporibus et.", "Beulah Roob", "https://citlalli.org" },
                    { new Guid("fcdae6a3-ed4a-dc84-c981-e5d77c38a59f"), "Nisi aut dignissimos aut praesentium sint.\nLaudantium autem quos dignissimos.\nQuaerat laudantium neque iste omnis.\nVoluptatem quia blanditiis mollitia nulla.\nAdipisci esse est deleniti.\nAlias non consequatur doloremque non dolor laboriosam explicabo.", "Domenick O'Hara", "https://elnora.biz" },
                    { new Guid("ffa074da-0d13-0320-6053-faf58b0bfaaf"), "Aut consequatur debitis nam maxime consequatur.\nNon consequuntur expedita.\nOdio voluptates error.\nDolore ea doloremque earum qui rem quis ut omnis.\nNulla ut repellendus exercitationem eligendi officiis qui aut et autem.", "Haven Stanton", "http://ayden.biz" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { new Guid("1a2c192c-4799-6a76-5201-3a7f9e4bf521"), "Folk" },
                    { new Guid("243e6871-56eb-fcf0-6615-b131f850196c"), "World" },
                    { new Guid("365c4d6b-58bf-5e84-c5ea-0487181a84d4"), "Classical" },
                    { new Guid("43a5389b-eb04-12e7-6794-b77875babf74"), "Latin" },
                    { new Guid("45b047af-85b7-485b-099e-d6f1a4f29a0e"), "Non Music" },
                    { new Guid("48359aba-8363-9470-7b00-908704415477"), "Hip Hop" },
                    { new Guid("4a3c2702-cdd9-0667-c1ff-7a4b3565a07f"), "Soul" },
                    { new Guid("50a0784e-421d-0016-f38a-ce156ad77ddd"), "Non Music" },
                    { new Guid("6dc13a26-1cd4-a4f5-f769-05e1a66fadfd"), "Reggae" },
                    { new Guid("7438d8ff-de03-021d-df78-6f88ca80ffa9"), "Metal" },
                    { new Guid("78fa6db5-6406-2d29-0824-713965033682"), "Stage And Screen" },
                    { new Guid("87058da2-9753-58c9-2d6e-fd1b4df1678d"), "Folk" },
                    { new Guid("8b389b2f-7953-497b-194a-49814a1f3072"), "Rap" },
                    { new Guid("93535c8e-aed2-5c82-7606-9f4c27203842"), "Electronic" },
                    { new Guid("9b797336-85ce-c187-e965-bd67c9e67ab2"), "Folk" },
                    { new Guid("9dcba494-afe3-5a3e-c2b8-b91405fbd0f8"), "Rock" },
                    { new Guid("a00e371c-4dac-1781-5568-e67553b5ce9a"), "Soul" },
                    { new Guid("b0916ecc-2f9a-f984-b164-5eb1dc1075d8"), "Latin" },
                    { new Guid("baebbde1-574f-86ed-306f-dfe736a2938d"), "Metal" },
                    { new Guid("baf966ae-eb3a-e05b-5095-ccf1c146518c"), "Jazz" },
                    { new Guid("be9df0c8-9bda-bf3d-bb6d-c13df9b40e78"), "Pop" },
                    { new Guid("c66b9cec-7b4a-aaab-0b3b-39d2ce183e54"), "World" },
                    { new Guid("ceba2a4a-5681-09c4-7b61-a60d60e80b8d"), "Electronic" },
                    { new Guid("d0d6e994-89f7-c30b-0eb1-4bd605634faa"), "Metal" },
                    { new Guid("d808841f-14bc-7cd2-a203-d91758f1e6da"), "Non Music" },
                    { new Guid("dc3ccb97-904e-a64c-85b8-f259f0636a84"), "Folk" },
                    { new Guid("dd8203a3-d058-7473-77ff-f243ef0b24cc"), "Hip Hop" },
                    { new Guid("f0084c1a-6d9e-49ea-ce83-1e0994653070"), "Stage And Screen" },
                    { new Guid("f1fb20af-7875-545e-bd60-f0a96f63645f"), "Stage And Screen" },
                    { new Guid("f7ab27f8-e865-e23e-48c0-04c23c622714"), "Rap" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Duration", "EndAiringDate", "Name", "Photo", "Rating", "ReleaseDate", "StartAiringDate", "Trailer" },
                values: new object[,]
                {
                    { new Guid("00115cf6-cba0-6fe1-2f19-c9e65f092476"), "Officia ut rerum et possimus saepe fuga.\nLaborum et voluptas.\nNam accusamus odio tempore praesentium.", new TimeOnly(12, 44, 10, 516).Add(TimeSpan.FromTicks(9976)), new DateOnly(2024, 6, 30), "digital", "https://garett.net", 1.0, new DateOnly(2023, 11, 19), new DateOnly(2023, 11, 26), "https://rolando.info" },
                    { new Guid("014b69c6-e373-6781-8eb2-f4898b34957f"), "Velit vero aliquid dolor necessitatibus sit aut tenetur at quam.\nConsequatur error praesentium eos maiores aut natus adipisci.\nEt voluptas perferendis id odit ea quo ab numquam.\nVoluptatum et accusantium blanditiis.", new TimeOnly(13, 34, 54, 535).Add(TimeSpan.FromTicks(1179)), new DateOnly(2024, 9, 20), "connecting", "https://talia.org", 2.0, new DateOnly(2023, 12, 7), new DateOnly(2024, 1, 9), "http://rashawn.com" },
                    { new Guid("03513d02-6403-2d4c-a0ef-2887137b3a2f"), "Magni temporibus dicta.\nNam fuga dolorem cum.", new TimeOnly(12, 54, 48, 115).Add(TimeSpan.FromTicks(568)), new DateOnly(2025, 5, 6), "Buckinghamshire", "http://dana.org", 8.0, new DateOnly(2023, 10, 1), new DateOnly(2024, 3, 9), "http://bessie.biz" },
                    { new Guid("08baf875-2d19-a090-7e12-256c680bab58"), "Ut reiciendis repellendus consectetur sed et labore sunt at quisquam.\nDolorem quis minima.\nItaque omnis laboriosam et ut quibusdam sed commodi iusto magnam.\nVoluptatibus doloremque accusantium facilis quas culpa quibusdam ad.\nVoluptate itaque dolore iure et aut est ullam quae.\nAsperiores est dolor nobis.", new TimeOnly(13, 19, 58, 237).Add(TimeSpan.FromTicks(4805)), new DateOnly(2025, 2, 11), "programming", "http://wilmer.com", 4.0, new DateOnly(2024, 2, 12), new DateOnly(2024, 3, 29), "http://karlie.net" },
                    { new Guid("0a26ceda-7cb4-2137-2874-fead2083f432"), "Temporibus qui ipsam et.\nDolorem nesciunt dicta corrupti alias quia fugiat.\nPerspiciatis minima incidunt aliquam.\nLabore corrupti optio odit ipsum fugit vel ut.", new TimeOnly(13, 34, 59, 754).Add(TimeSpan.FromTicks(9201)), new DateOnly(2024, 11, 25), "Administrator", "http://adolph.biz", 9.0, new DateOnly(2023, 11, 30), new DateOnly(2023, 7, 3), "https://zachary.info" },
                    { new Guid("0da4b527-d9fd-db6a-5c17-6d59559d1fe2"), "Ut mollitia vel aliquid enim ratione amet.\nAut officiis officiis id quidem.\nUllam nesciunt sunt dolor consequatur dolor praesentium voluptas et velit.", new TimeOnly(13, 7, 21, 596).Add(TimeSpan.FromTicks(5276)), new DateOnly(2024, 10, 10), "one-to-one", "https://alda.net", 1.0, new DateOnly(2024, 2, 29), new DateOnly(2024, 1, 29), "https://graham.name" },
                    { new Guid("0dfcff25-3bbe-2b5c-f7b6-cf4eda1bb52c"), "Id fuga expedita ipsum aut vel itaque.\nVoluptas libero esse rerum dolorem non quae ut.\nUt saepe ea illo est qui in velit numquam.\nAliquam et et.\nReiciendis facilis quis est doloribus facere et.", new TimeOnly(12, 54, 47, 165).Add(TimeSpan.FromTicks(212)), new DateOnly(2025, 4, 11), "Rest", "http://michel.org", 2.0, new DateOnly(2024, 4, 25), new DateOnly(2023, 9, 29), "https://yasmin.org" },
                    { new Guid("1b3f1c4f-6a5e-72b9-3ca2-449ef10b8b93"), "Quidem facilis ea dolore eligendi deleniti.\nExpedita fuga molestias adipisci.\nEligendi vel asperiores dolore non vel autem.\nProvident in et tempore fugiat dolores aliquid sequi ratione est.\nDoloremque nostrum rerum aperiam vel.\nSoluta odit praesentium aliquid odit exercitationem architecto architecto voluptate.", new TimeOnly(12, 51, 9, 255).Add(TimeSpan.FromTicks(4562)), new DateOnly(2024, 8, 31), "Refined", "https://monica.org", 10.0, new DateOnly(2023, 6, 29), new DateOnly(2023, 8, 8), "https://vito.biz" },
                    { new Guid("2b91c83e-88b5-9098-b8eb-56d79c4da3d2"), "Natus est voluptatibus magnam et dolor beatae error voluptatum voluptas.\nUt error ut.\nOfficiis tempora cupiditate.\nVeniam ea enim illo veritatis veritatis cum.\nAssumenda blanditiis ut harum sit minus.", new TimeOnly(13, 15, 42, 197).Add(TimeSpan.FromTicks(33)), new DateOnly(2024, 6, 30), "Practical Soft Salad", "http://demetris.info", 0.0, new DateOnly(2023, 6, 19), new DateOnly(2023, 10, 26), "http://reva.biz" },
                    { new Guid("4aef5eba-5f79-e9f7-3317-c48377a11b93"), "At harum repudiandae aliquid aut molestiae.\nFacilis qui consequuntur recusandae ut.", new TimeOnly(13, 5, 42, 461).Add(TimeSpan.FromTicks(3811)), new DateOnly(2024, 8, 27), "USB", "https://rico.biz", 10.0, new DateOnly(2024, 2, 2), new DateOnly(2023, 9, 28), "http://clint.org" },
                    { new Guid("4ce9501c-e757-92f0-b975-439dc365aba9"), "Atque non dolore.\nNemo eveniet beatae.", new TimeOnly(12, 50, 15, 133).Add(TimeSpan.FromTicks(3950)), new DateOnly(2025, 2, 6), "feed", "https://rosina.org", 4.0, new DateOnly(2024, 1, 23), new DateOnly(2024, 2, 6), "http://bailey.info" },
                    { new Guid("5e8f08d6-9ae7-6536-9782-b6a801316d8a"), "Tempore cumque asperiores assumenda ea.\nMollitia quisquam dolorem sapiente explicabo velit iste.", new TimeOnly(13, 13, 20, 322).Add(TimeSpan.FromTicks(2627)), new DateOnly(2024, 5, 17), "reboot", "http://ellis.biz", 8.0, new DateOnly(2023, 11, 6), new DateOnly(2023, 8, 24), "http://norris.org" },
                    { new Guid("62f5e1c9-3d68-18bc-2516-1465dbfb2e3c"), "Ea nihil qui pariatur nobis voluptatem odit recusandae.\nNulla mollitia hic soluta nostrum eveniet dolorem illum numquam.\nEum voluptate repellendus fuga vero eaque tenetur optio et ipsam.\nAut qui magni dolorum debitis quia.\nEa et necessitatibus.", new TimeOnly(13, 38, 45, 884).Add(TimeSpan.FromTicks(5435)), new DateOnly(2024, 10, 27), "Platinum", "http://vicenta.name", 0.0, new DateOnly(2023, 8, 21), new DateOnly(2023, 8, 5), "http://lois.net" },
                    { new Guid("9109e66f-ef19-234d-0ede-b0e9534f3f1d"), "In aspernatur commodi ab cumque voluptatem placeat sint consequuntur mollitia.\nOptio iste excepturi aut sit sint.\nDignissimos rerum velit.\nOfficiis dolore assumenda sint qui.\nIllum adipisci ea culpa molestias tempora.\nEaque delectus aperiam ut provident vitae commodi rerum.", new TimeOnly(13, 6, 25, 844).Add(TimeSpan.FromTicks(5671)), new DateOnly(2025, 1, 29), "Licensed Rubber Chips", "https://dortha.net", 5.0, new DateOnly(2023, 7, 25), new DateOnly(2023, 12, 8), "https://caroline.info" },
                    { new Guid("9243bd2b-5eab-1633-8c2c-fdd2550926cb"), "Tempora ex nihil consectetur illo.\nQuam sequi quo maxime ut amet odio voluptatum excepturi.\nRecusandae qui nulla velit sed aut ratione animi.\nQuae commodi autem reprehenderit ut praesentium harum quidem unde laudantium.\nQuo temporibus occaecati et non.\nLibero tempore numquam odio saepe repellat eveniet velit reprehenderit vel.", new TimeOnly(13, 1, 54, 603).Add(TimeSpan.FromTicks(1701)), new DateOnly(2025, 4, 7), "Connecticut", "https://casper.net", 9.0, new DateOnly(2023, 10, 15), new DateOnly(2024, 1, 25), "http://otilia.net" },
                    { new Guid("9d133761-6fc5-b6b2-17bb-c8409c887229"), "Omnis in aut occaecati illo et sint velit ut.\nEt ad quia.\nQuae repellendus natus quod omnis dolor nihil autem.\nDebitis necessitatibus rem quia suscipit molestiae laborum voluptates consequatur nulla.\nRem vel assumenda commodi.", new TimeOnly(13, 14, 50, 4).Add(TimeSpan.FromTicks(7464)), new DateOnly(2024, 12, 1), "Producer", "http://colby.info", 8.0, new DateOnly(2023, 12, 14), new DateOnly(2023, 12, 1), "https://jarrell.org" },
                    { new Guid("a4cbc3fe-e0bd-0f9a-739b-96fa9d2afd7f"), "Qui similique inventore et nam exercitationem ut dolores autem corporis.\nHarum explicabo iure.\nNeque ut velit qui repellat modi et pariatur aut pariatur.\nAt nobis esse vitae et enim id.\nIpsam ut deserunt sequi eius quos quia.\nSoluta omnis qui.", new TimeOnly(13, 6, 31, 509).Add(TimeSpan.FromTicks(1265)), new DateOnly(2025, 3, 30), "Fantastic Metal Chair", "http://ayla.com", 8.0, new DateOnly(2023, 12, 2), new DateOnly(2024, 4, 7), "https://litzy.com" },
                    { new Guid("a82d9a59-603b-5df0-7131-27b9a1cfc269"), "Aut dolores at delectus dolorem.\nEt at sunt laudantium.\nIllo unde aut porro qui delectus sit nihil ab ex.\nNumquam nobis sequi necessitatibus magnam natus ut nam et.", new TimeOnly(13, 23, 15, 817).Add(TimeSpan.FromTicks(8611)), new DateOnly(2025, 5, 11), "sensor", "https://orin.biz", 8.0, new DateOnly(2024, 4, 14), new DateOnly(2024, 2, 28), "https://kevin.com" },
                    { new Guid("aa0ed374-c49e-6925-a53b-d6400a6b0954"), "Corrupti qui eos dolor necessitatibus molestiae numquam et sapiente voluptas.\nDolore eum repudiandae nulla quo quod dignissimos illum.\nAut velit impedit laudantium quo unde officiis sapiente quisquam.\nQuae qui veniam et deserunt consequatur nihil praesentium.\nDistinctio corporis quas.\nUt et dolorem eum aut facilis quia perferendis aut quae.", new TimeOnly(13, 18, 50, 931).Add(TimeSpan.FromTicks(1353)), new DateOnly(2024, 5, 31), "District", "https://sammie.net", 1.0, new DateOnly(2023, 10, 23), new DateOnly(2023, 5, 24), "https://rusty.name" },
                    { new Guid("c33b839a-2c85-f4b9-117a-3be873adc26e"), "Impedit dolores enim recusandae qui.\nVoluptas est nostrum itaque.\nBeatae dolorem nesciunt qui ullam.\nSaepe veniam facere ut ullam incidunt.\nVoluptatem molestiae occaecati dignissimos non odio atque.", new TimeOnly(13, 43, 18, 743).Add(TimeSpan.FromTicks(8178)), new DateOnly(2025, 2, 5), "SCSI", "http://jedediah.biz", 6.0, new DateOnly(2024, 1, 24), new DateOnly(2024, 5, 10), "http://giovanna.org" },
                    { new Guid("c73060fe-3c96-0b22-3d02-47a283cff1b6"), "Exercitationem delectus laborum delectus sunt.\nIllo totam enim.\nNesciunt accusamus qui sunt libero aut id sed.\nEt mollitia ut dolores quasi consequuntur reiciendis nesciunt et non.", new TimeOnly(13, 4, 56, 585).Add(TimeSpan.FromTicks(9495)), new DateOnly(2024, 10, 16), "Dynamic", "http://vena.biz", 8.0, new DateOnly(2024, 1, 24), new DateOnly(2023, 12, 24), "https://bobby.org" },
                    { new Guid("c7fdb6f9-bb6f-342d-584a-fcac0571fb10"), "Fugit tempora suscipit exercitationem officiis rem.\nEa dolor vero amet sapiente.\nEt in et.\nVeritatis temporibus eligendi.", new TimeOnly(13, 42, 20, 383).Add(TimeSpan.FromTicks(9286)), new DateOnly(2024, 5, 21), "Music, Home & Baby", "https://dwight.info", 4.0, new DateOnly(2023, 6, 26), new DateOnly(2023, 7, 8), "https://mckenzie.net" },
                    { new Guid("d442d1df-85e9-de7d-854a-58aaf7501e0f"), "Excepturi dolorum non accusantium ducimus vel in harum.\nMinima neque sed quo omnis ratione eaque voluptatem ab eaque.\nHic amet temporibus qui.\nQuia iusto voluptas et reprehenderit doloremque aperiam nobis enim.", new TimeOnly(12, 51, 40, 748).Add(TimeSpan.FromTicks(7266)), new DateOnly(2025, 1, 15), "superstructure", "http://brennan.info", 1.0, new DateOnly(2024, 3, 1), new DateOnly(2023, 8, 14), "http://tiana.org" },
                    { new Guid("d8026b84-ff1c-4b76-2738-8664d4a8f969"), "Dolorem aliquam veniam ea officia sint animi dolor hic quam.\nQuas est recusandae perferendis non qui repudiandae.\nOmnis itaque laudantium placeat vel non sint velit tempore.\nHic sit ut quis itaque quia sunt perferendis repudiandae assumenda.", new TimeOnly(13, 38, 26, 55).Add(TimeSpan.FromTicks(1693)), new DateOnly(2024, 10, 23), "projection", "https://ludie.info", 2.0, new DateOnly(2023, 11, 11), new DateOnly(2023, 6, 9), "https://rowena.info" },
                    { new Guid("d9baf1e9-79f6-13be-a3ab-f43c853617f5"), "Saepe occaecati quis iure dolores qui at beatae sit suscipit.\nRepudiandae nihil aut quas repellat ut inventore aperiam.\nDolorem harum modi.\nQuaerat consequatur vitae.\nEligendi aliquam magnam expedita expedita provident natus.\nMolestiae consequatur laborum debitis debitis.", new TimeOnly(13, 4, 51, 136).Add(TimeSpan.FromTicks(6544)), new DateOnly(2024, 10, 4), "Response", "http://nelson.com", 10.0, new DateOnly(2023, 11, 11), new DateOnly(2023, 10, 13), "https://hillard.com" },
                    { new Guid("dfbd9623-f9f5-3b6d-166c-145a3a671ef8"), "Perferendis sit animi optio voluptatem non dolores fugiat ipsum.\nPraesentium ut adipisci.\nArchitecto provident corrupti.\nError earum alias mollitia.", new TimeOnly(12, 48, 47, 974).Add(TimeSpan.FromTicks(3231)), new DateOnly(2025, 2, 17), "white", "http://pierce.net", 2.0, new DateOnly(2023, 6, 8), new DateOnly(2024, 3, 19), "https://lilliana.name" },
                    { new Guid("f2408d05-a79a-c753-dfe6-b1a32b76ccef"), "Eveniet sed necessitatibus aut.\nVoluptate nemo alias vero ea qui.\nOfficiis quia aperiam ut incidunt laboriosam harum laudantium.\nUt non et impedit qui autem autem.\nDignissimos nostrum maiores maxime molestiae repellendus odit rerum.", new TimeOnly(12, 52, 47, 782).Add(TimeSpan.FromTicks(7567)), new DateOnly(2024, 11, 2), "Buckinghamshire", "http://gladyce.org", 2.0, new DateOnly(2024, 4, 7), new DateOnly(2023, 8, 6), "https://kari.org" },
                    { new Guid("f8ac4b67-8a53-36c7-d65f-2c933c48a1cc"), "Eius et unde et sunt.\nUt possimus in maxime dignissimos vel.\nNeque maxime voluptatem non omnis ut cumque.\nDoloribus nisi aut corrupti esse cupiditate nihil et ipsum harum.", new TimeOnly(12, 59, 5, 631).Add(TimeSpan.FromTicks(248)), new DateOnly(2024, 8, 19), "functionalities", "http://gia.org", 2.0, new DateOnly(2024, 1, 1), new DateOnly(2024, 3, 21), "http://giovanni.name" },
                    { new Guid("fa83a77e-fd88-0bd3-a27a-75317f90f9e9"), "Doloremque est magni.\nQuibusdam quo ipsa voluptates perspiciatis ea facere.", new TimeOnly(12, 44, 20, 636).Add(TimeSpan.FromTicks(6936)), new DateOnly(2025, 4, 22), "Junctions", "http://ursula.name", 5.0, new DateOnly(2024, 5, 5), new DateOnly(2024, 2, 4), "https://ivah.com" },
                    { new Guid("fadb37f2-dbaf-1d08-64f7-f6916b849f71"), "Non et omnis repellat ab ducimus nisi aspernatur dolorem et.\nNisi voluptas quidem sed quisquam voluptatem.\nQuia nihil repellendus praesentium voluptas sit natus.\nAtque quis excepturi pariatur voluptas doloremque similique.\nIllum ad facilis aperiam quam.\nAut et sint animi unde.", new TimeOnly(12, 54, 40, 623).Add(TimeSpan.FromTicks(7846)), new DateOnly(2024, 9, 13), "maximize", "http://brandy.net", 2.0, new DateOnly(2023, 6, 18), new DateOnly(2024, 1, 14), "http://litzy.com" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("78d794e6-9a2c-4a9f-85a8-0914207f95e5"), null, "admin", null },
                    { new Guid("fac297bb-b40a-4959-8450-319e837549a2"), null, "user", null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "NumberOfSeats", "RoomName" },
                values: new object[,]
                {
                    { new Guid("007a3945-c1e3-5aeb-5786-f80afee41b1c"), 1304001354, "ipsam" },
                    { new Guid("01ca2a71-e689-7ebc-9cbb-9de170a28371"), 462788320, "vel" },
                    { new Guid("03ba482f-dc31-97d5-b082-279d026c9833"), -256698084, "commodi" },
                    { new Guid("0926686f-e663-072f-2349-2bb37cde4de6"), -921823743, "et" },
                    { new Guid("0ae843dd-f647-6c0a-5937-788fc7978759"), -1005416809, "neque" },
                    { new Guid("0e152451-379a-5dde-0141-cdfbb3f7e466"), -239050881, "rerum" },
                    { new Guid("19b3da00-1461-5f95-be3b-93296f3d2492"), -2018754795, "sint" },
                    { new Guid("2883287e-72b1-f213-99c3-00ad5216b083"), -874511334, "consequuntur" },
                    { new Guid("36f4164b-ec5d-040a-5516-ff8b1ec66e7d"), -1355685501, "cumque" },
                    { new Guid("44799495-79a1-3c0a-35e3-6e0582f48e8f"), -1198357063, "ea" },
                    { new Guid("48879393-2a9f-1913-26fd-8f600be5b1fc"), -1861319901, "quia" },
                    { new Guid("5048eb6c-b54b-f349-621b-1d15641f34c0"), 315118664, "quos" },
                    { new Guid("5990b547-f708-7e59-7b5e-1b8df500e192"), -1484505789, "est" },
                    { new Guid("5fd53818-33e7-5e1d-8224-ab3c8ef2fe91"), 626930056, "animi" },
                    { new Guid("61a33d14-d4aa-2828-5116-d187ca7e6f9f"), -1653041260, "aperiam" },
                    { new Guid("62b9c08e-77f6-464f-ea7c-b79a986f4ab2"), 597287901, "voluptatem" },
                    { new Guid("7ed02121-610f-94b7-d78c-ecea96386d0e"), 1300064051, "atque" },
                    { new Guid("863a087d-7241-d1df-c35f-49c5703ce41f"), -391987835, "quas" },
                    { new Guid("9a2ff284-9950-7f81-303b-5389e8fb8f70"), 1438340801, "cum" },
                    { new Guid("a6ea9776-d918-dfaa-37b7-9e55ceb21aa1"), -1687403541, "eligendi" },
                    { new Guid("b08d786c-48e0-137b-c032-ea2c436abe41"), 527868451, "dolorum" },
                    { new Guid("b62b0a4b-7f88-b08c-54f2-f585daef823d"), -1411282387, "veniam" },
                    { new Guid("ba61a61d-d025-d117-fcd2-831cfcaa8d2f"), 628356685, "accusamus" },
                    { new Guid("c6e2c8ce-6a57-ad01-d2e5-ac96cc6c6210"), 1186145060, "quibusdam" },
                    { new Guid("c9e0fb54-4ffc-bb78-4871-52f370d1277b"), 15926020, "autem" },
                    { new Guid("cdd1ddd9-ba6e-5c32-6093-37434d5dda7c"), 686719608, "eaque" },
                    { new Guid("d994cf69-76ab-5927-5b36-46867ae6518c"), -428404155, "temporibus" },
                    { new Guid("db86801c-12a7-9340-6002-10168168b409"), 595804687, "tempore" },
                    { new Guid("e1e64e08-88e1-4048-5ae0-7650ef69b4ad"), -478414112, "ducimus" },
                    { new Guid("e43d248d-b22e-6a62-5050-227afe3033a5"), 1149467661, "quia" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("047b73f2-d095-496c-d34d-4e8d27da3ae5"), 0, "0af0961a-3e3c-4a7c-bd59-3e055acb6c00", "Alisha_Walsh@gmail.com", false, false, null, null, null, "ZlLTiZqc95", "1-244-346-2086 x677", false, null, false, "Hattie_Kutch34" },
                    { new Guid("07a71f91-37a4-49cb-64fb-ee4a26939476"), 0, "fc4dfd44-5ab6-430d-847d-2f6c4a970f5b", "Julius69@hotmail.com", false, false, null, null, null, "LHgVAXsUK1", "1-623-562-3619 x434", false, null, false, "William.Kihn45" },
                    { new Guid("197e5c7a-9c8f-14d6-6e80-2c3be7d682a6"), 0, "9f4c16c6-eec2-4b12-929e-a3ebcf0858bb", "Jesse_Pfeffer72@hotmail.com", false, false, null, null, null, "9sAxU2qgxQ", "1-660-597-4730 x772", false, null, false, "Jackie91" },
                    { new Guid("26e5d66f-6585-22e0-094d-fb5b85f2e212"), 0, "5fdb757e-d835-4792-832b-098a92d3a249", "Bryana76@hotmail.com", false, false, null, null, null, "dLMFVTALql", "304-533-3698 x1715", false, null, false, "Breana.Reilly33" },
                    { new Guid("333873c2-a49b-44bc-cb58-4f9ea9eb9a0a"), 0, "18065fc3-1fc3-4e73-8253-94e9995b5c9f", "Velma_Reilly@gmail.com", false, false, null, null, null, "AKWLL9ilBw", "321-518-3240", false, null, false, "Vallie.Crooks" },
                    { new Guid("352f4ad7-bd62-829c-9ac9-77c70036b70f"), 0, "5a3031d8-3d2b-4a39-9d40-086627e3d64c", "Nelle.Zieme19@gmail.com", false, false, null, null, null, "94eaK9Ysai", "710.591.9943", false, null, false, "Antwan75" },
                    { new Guid("46c6f57b-3c76-23f5-3df5-2210bb3230f1"), 0, "5796354c-ad0d-4333-a6f4-d7bf1b12aeb6", "Mona.McGlynn@yahoo.com", false, false, null, null, null, "gnrJkcb3uD", "850.781.2398", false, null, false, "Amir_Trantow" },
                    { new Guid("483f32d1-1c52-ed00-6615-1083d954ba1f"), 0, "c6fe032c-e9a3-4216-8cad-43b9c4b0fbcf", "Moses15@yahoo.com", false, false, null, null, null, "lG7JjEVkI5", "1-635-724-7467", false, null, false, "Susan.Emmerich71" },
                    { new Guid("4e9127b6-50a6-aaba-aa62-0af8c32e5099"), 0, "ebea79b2-42a0-46f8-9dd3-94dc35a48872", "Chloe.Reichert72@yahoo.com", false, false, null, null, null, "Jr0Okl9JxV", "630.204.1873 x04995", false, null, false, "Kassandra.Wehner62" },
                    { new Guid("4f26070a-c609-5798-2999-6049edbaf85c"), 0, "d1f15364-53ff-4e00-afe4-eae8abe8e09f", "Vanessa77@gmail.com", false, false, null, null, null, "fVUwgnmlgA", "(520) 465-4182 x514", false, null, false, "Mariam.Mraz41" },
                    { new Guid("53241cf7-b572-ec38-0ad5-141389409a83"), 0, "e3c357ab-b19e-46f5-b7f5-e009b4e658f2", "Dandre83@hotmail.com", false, false, null, null, null, "9nceHwqFXz", "(965) 854-6079", false, null, false, "Naomie62" },
                    { new Guid("55f3f4fc-5ee6-b27b-1753-a10d465d8772"), 0, "442398a6-98f8-46af-a31c-cde38c70d6e0", "Dejuan55@hotmail.com", false, false, null, null, null, "seMdciehNa", "775.415.3023 x8276", false, null, false, "Ayana14" },
                    { new Guid("597e2ad8-e1b1-14b1-a362-87d255039ba2"), 0, "6f9a2166-7c19-4e99-8542-7754a475638e", "Monique.Watsica96@yahoo.com", false, false, null, null, null, "pLFEUglAgN", "(573) 712-4956", false, null, false, "Joelle71" },
                    { new Guid("62312625-5485-46b7-3c47-22122e57cb13"), 0, "3b2e9ff2-eac9-4240-bc9b-b62b77578994", "Katlyn_Weissnat77@gmail.com", false, false, null, null, null, "OrARaFb1Tg", "1-355-207-2793 x0889", false, null, false, "Calista25" },
                    { new Guid("67e128a6-a09e-51d1-cc4b-fbbd53be3d6e"), 0, "c93bcda7-3d5d-43c3-8a16-89295687d42c", "Macy_Daniel@gmail.com", false, false, null, null, null, "LirgfEXgAG", "(550) 761-9739", false, null, false, "Aurelie.Rath" },
                    { new Guid("6ed18f69-138a-cf92-b5c7-01c29c62f66a"), 0, "0c37143e-441c-4b0e-9b7c-4449d74c43ce", "Kendrick.Toy44@hotmail.com", false, false, null, null, null, "jA2O9tI5Rk", "635-936-7543", false, null, false, "Charley_Harber64" },
                    { new Guid("70cedaaf-9bd4-b5d7-64ac-b6c7d797e44c"), 0, "d9ecf85f-212a-42d4-9aa1-8d00f36978c0", "Edward_Cole@yahoo.com", false, false, null, null, null, "cu6oCQeBDv", "(438) 339-1066", false, null, false, "Salvador40" },
                    { new Guid("8978a029-840f-1331-1dab-44b2ec74f431"), 0, "23bfa6f5-3b37-4d1b-82f4-9d64b3a6729a", "Cheyanne63@yahoo.com", false, false, null, null, null, "gqu0rm4JGX", "1-428-870-6385 x6674", false, null, false, "Walton.Schinner" },
                    { new Guid("a58f24e2-49e1-9cd7-25bc-fafe81741329"), 0, "d677023e-6473-4f56-a1a9-46477bcbaf44", "Willie_Kreiger@yahoo.com", false, false, null, null, null, "1LI_PF6JGZ", "(316) 231-6703 x54557", false, null, false, "Ronny91" },
                    { new Guid("a77c439d-c24a-e099-cb92-fc123a902a00"), 0, "b88d78f4-6f6d-4e0c-9b08-7209ca4dbbea", "Nadia.Parker@gmail.com", false, false, null, null, null, "OYFXwEYrGt", "1-202-497-3606 x117", false, null, false, "Lilla.Swaniawski43" },
                    { new Guid("af70607f-adef-06e2-822d-4f2753ac835e"), 0, "37ed5b76-7f85-40fd-8795-2d018c4c5db4", "Ebony51@hotmail.com", false, false, null, null, null, "9xBDS2nnqC", "504.469.0892 x69461", false, null, false, "Janet38" },
                    { new Guid("b3e46965-6bec-4060-88f1-9e670b8968e7"), 0, "5443910a-5ce1-457e-8de9-6c793941a429", "Alex35@hotmail.com", false, false, null, null, null, "rig9pB0V3n", "612.817.8059 x93190", false, null, false, "Elijah_Bayer90" },
                    { new Guid("b5c6238c-183a-3cb7-8693-934145fc950a"), 0, "2278cd6c-4ca0-41fa-84dc-f8faacbc17d3", "Tressa_Satterfield70@yahoo.com", false, false, null, null, null, "en88vOs2k6", "517.877.7761 x46932", false, null, false, "Reyna_Gusikowski93" },
                    { new Guid("b91361ae-b211-5dbc-7be3-8bb1c8288813"), 0, "9d19517d-dac2-4273-8675-5c9550d9eac7", "Lisa83@hotmail.com", false, false, null, null, null, "kXOFuHY6Cj", "(888) 777-8783 x50460", false, null, false, "Olen_Boyle35" },
                    { new Guid("c3c131c5-43fe-beb6-0cf9-66e6702680a2"), 0, "32647dd8-bfbf-4cdc-917c-f00bb92cdbc6", "Sonia_Beatty@yahoo.com", false, false, null, null, null, "q29Z18ssvd", "442.711.2825", false, null, false, "Valerie_Connelly" },
                    { new Guid("d2546772-b9cb-122b-32cc-8db2caea3a8c"), 0, "a9b0b919-c172-4406-af03-5858fe5ab993", "Kelsie_Glover@gmail.com", false, false, null, null, null, "enErf30hiJ", "(715) 325-7925 x3737", false, null, false, "Fabiola50" },
                    { new Guid("d7f2287b-f27e-c18b-bdb9-11a6bfefd0fc"), 0, "37300760-c5a6-438a-856f-fdf692198699", "Rod80@yahoo.com", false, false, null, null, null, "Qs3wfQI16g", "(474) 700-4014 x78020", false, null, false, "Eden.Rowe96" },
                    { new Guid("e0099be6-e534-ac73-fa06-c1ed910570de"), 0, "257300ac-e2f3-438a-92d7-b52404435eef", "Easter.Stokes@yahoo.com", false, false, null, null, null, "EIrdfTMoLh", "711-771-1086", false, null, false, "Vickie.Block" },
                    { new Guid("e281dcb5-a732-75f3-46c4-5a84c1403170"), 0, "2d4af94f-3a4b-4a8c-8698-30706fe9cbfc", "Rebeca69@gmail.com", false, false, null, null, null, "jnh0Ccvi8b", "1-726-418-7804", false, null, false, "Hubert.Sauer" },
                    { new Guid("f55548b4-0f64-226c-818d-e0bace48cfd6"), 0, "01e83801-89a4-46ed-a588-f96b9ff299bf", "Lonie_Strosin43@gmail.com", false, false, null, null, null, "AbrEmxaJN1", "1-819-970-5885 x117", false, null, false, "Celia.Keeling" }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("4389a4f3-0e10-3b14-6147-1b76875f79cb"), new Guid("00115cf6-cba0-6fe1-2f19-c9e65f092476") },
                    { new Guid("7a320366-8215-55af-445e-7ad6e2a454e6"), new Guid("014b69c6-e373-6781-8eb2-f4898b34957f") },
                    { new Guid("e074bce8-3b65-56d8-3bb9-1b1bbec75166"), new Guid("03513d02-6403-2d4c-a0ef-2887137b3a2f") },
                    { new Guid("d08b2aa0-a1d0-7943-9170-c33f2a0d6b71"), new Guid("08baf875-2d19-a090-7e12-256c680bab58") },
                    { new Guid("48da9995-067e-e188-572f-e90fb110dbed"), new Guid("0a26ceda-7cb4-2137-2874-fead2083f432") },
                    { new Guid("6f597be6-9525-a6f7-c023-6af2d3ec46b7"), new Guid("0da4b527-d9fd-db6a-5c17-6d59559d1fe2") },
                    { new Guid("18db48e5-67ab-0257-f3c5-67a4e4edf917"), new Guid("0dfcff25-3bbe-2b5c-f7b6-cf4eda1bb52c") },
                    { new Guid("40defcb6-bd96-0d22-9dc9-6cfbf9aea068"), new Guid("1b3f1c4f-6a5e-72b9-3ca2-449ef10b8b93") },
                    { new Guid("6805c441-682f-f6b2-b905-ab66af49f5d3"), new Guid("2b91c83e-88b5-9098-b8eb-56d79c4da3d2") },
                    { new Guid("9c2cfac9-09c2-d5b6-eae1-f230f0bfe836"), new Guid("4aef5eba-5f79-e9f7-3317-c48377a11b93") },
                    { new Guid("ffa074da-0d13-0320-6053-faf58b0bfaaf"), new Guid("4ce9501c-e757-92f0-b975-439dc365aba9") },
                    { new Guid("d7183597-f883-8142-ae41-a68bc1820c2a"), new Guid("5e8f08d6-9ae7-6536-9782-b6a801316d8a") },
                    { new Guid("d0cabe5c-ed7f-05d1-abab-6335590cf775"), new Guid("62f5e1c9-3d68-18bc-2516-1465dbfb2e3c") },
                    { new Guid("99540b23-2e38-39f0-490f-9f98f0148d03"), new Guid("9109e66f-ef19-234d-0ede-b0e9534f3f1d") },
                    { new Guid("5c38f0f4-9c06-e566-94f0-5306ac2d1bde"), new Guid("9243bd2b-5eab-1633-8c2c-fdd2550926cb") },
                    { new Guid("b1707a99-5f65-07f2-3789-e9bd57247045"), new Guid("9d133761-6fc5-b6b2-17bb-c8409c887229") },
                    { new Guid("fcdae6a3-ed4a-dc84-c981-e5d77c38a59f"), new Guid("a4cbc3fe-e0bd-0f9a-739b-96fa9d2afd7f") },
                    { new Guid("982f5f1d-7b3e-1ce9-24e6-326b6201870b"), new Guid("a82d9a59-603b-5df0-7131-27b9a1cfc269") },
                    { new Guid("9772e030-4279-2df3-a745-4c592cbccf0a"), new Guid("aa0ed374-c49e-6925-a53b-d6400a6b0954") },
                    { new Guid("622dbb41-751c-a03c-c669-b92fa35336d9"), new Guid("c33b839a-2c85-f4b9-117a-3be873adc26e") },
                    { new Guid("25ff30a1-b041-cf49-2306-677828e96604"), new Guid("c73060fe-3c96-0b22-3d02-47a283cff1b6") },
                    { new Guid("5a0063ff-80ca-8782-7d23-410297f3033a"), new Guid("c7fdb6f9-bb6f-342d-584a-fcac0571fb10") },
                    { new Guid("5cb2d94e-1941-3efd-9006-c7f7c127c33a"), new Guid("d442d1df-85e9-de7d-854a-58aaf7501e0f") },
                    { new Guid("61f8fc5c-c892-ba8a-03b9-746d3283b5ca"), new Guid("d8026b84-ff1c-4b76-2738-8664d4a8f969") },
                    { new Guid("b6bc8e8d-996a-76ae-0fae-d575d02edbc6"), new Guid("d9baf1e9-79f6-13be-a3ab-f43c853617f5") },
                    { new Guid("b9d7366b-53f3-c3b4-15da-c064fcef82d2"), new Guid("dfbd9623-f9f5-3b6d-166c-145a3a671ef8") },
                    { new Guid("63e9676a-d28e-0a22-d0bb-3660d309ed3b"), new Guid("f2408d05-a79a-c753-dfe6-b1a32b76ccef") },
                    { new Guid("5b28b195-0667-c561-5bc7-43229b7d36dc"), new Guid("f8ac4b67-8a53-36c7-d65f-2c933c48a1cc") },
                    { new Guid("50aa9838-31f3-d65c-4cb7-5e71fb127b99"), new Guid("fa83a77e-fd88-0bd3-a27a-75317f90f9e9") },
                    { new Guid("28a37c20-d73c-88cd-53c1-3cbffeb51c17"), new Guid("fadb37f2-dbaf-1d08-64f7-f6916b849f71") }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("c66b9cec-7b4a-aaab-0b3b-39d2ce183e54"), new Guid("00115cf6-cba0-6fe1-2f19-c9e65f092476") },
                    { new Guid("dc3ccb97-904e-a64c-85b8-f259f0636a84"), new Guid("014b69c6-e373-6781-8eb2-f4898b34957f") },
                    { new Guid("48359aba-8363-9470-7b00-908704415477"), new Guid("03513d02-6403-2d4c-a0ef-2887137b3a2f") },
                    { new Guid("be9df0c8-9bda-bf3d-bb6d-c13df9b40e78"), new Guid("08baf875-2d19-a090-7e12-256c680bab58") },
                    { new Guid("6dc13a26-1cd4-a4f5-f769-05e1a66fadfd"), new Guid("0a26ceda-7cb4-2137-2874-fead2083f432") },
                    { new Guid("43a5389b-eb04-12e7-6794-b77875babf74"), new Guid("0da4b527-d9fd-db6a-5c17-6d59559d1fe2") },
                    { new Guid("a00e371c-4dac-1781-5568-e67553b5ce9a"), new Guid("0dfcff25-3bbe-2b5c-f7b6-cf4eda1bb52c") },
                    { new Guid("87058da2-9753-58c9-2d6e-fd1b4df1678d"), new Guid("1b3f1c4f-6a5e-72b9-3ca2-449ef10b8b93") },
                    { new Guid("9dcba494-afe3-5a3e-c2b8-b91405fbd0f8"), new Guid("2b91c83e-88b5-9098-b8eb-56d79c4da3d2") },
                    { new Guid("dd8203a3-d058-7473-77ff-f243ef0b24cc"), new Guid("4aef5eba-5f79-e9f7-3317-c48377a11b93") },
                    { new Guid("baf966ae-eb3a-e05b-5095-ccf1c146518c"), new Guid("4ce9501c-e757-92f0-b975-439dc365aba9") },
                    { new Guid("50a0784e-421d-0016-f38a-ce156ad77ddd"), new Guid("5e8f08d6-9ae7-6536-9782-b6a801316d8a") },
                    { new Guid("365c4d6b-58bf-5e84-c5ea-0487181a84d4"), new Guid("62f5e1c9-3d68-18bc-2516-1465dbfb2e3c") },
                    { new Guid("f0084c1a-6d9e-49ea-ce83-1e0994653070"), new Guid("9109e66f-ef19-234d-0ede-b0e9534f3f1d") },
                    { new Guid("d808841f-14bc-7cd2-a203-d91758f1e6da"), new Guid("9243bd2b-5eab-1633-8c2c-fdd2550926cb") },
                    { new Guid("7438d8ff-de03-021d-df78-6f88ca80ffa9"), new Guid("9d133761-6fc5-b6b2-17bb-c8409c887229") },
                    { new Guid("ceba2a4a-5681-09c4-7b61-a60d60e80b8d"), new Guid("a4cbc3fe-e0bd-0f9a-739b-96fa9d2afd7f") },
                    { new Guid("b0916ecc-2f9a-f984-b164-5eb1dc1075d8"), new Guid("a82d9a59-603b-5df0-7131-27b9a1cfc269") },
                    { new Guid("243e6871-56eb-fcf0-6615-b131f850196c"), new Guid("aa0ed374-c49e-6925-a53b-d6400a6b0954") },
                    { new Guid("8b389b2f-7953-497b-194a-49814a1f3072"), new Guid("c33b839a-2c85-f4b9-117a-3be873adc26e") },
                    { new Guid("f7ab27f8-e865-e23e-48c0-04c23c622714"), new Guid("c73060fe-3c96-0b22-3d02-47a283cff1b6") },
                    { new Guid("f1fb20af-7875-545e-bd60-f0a96f63645f"), new Guid("c7fdb6f9-bb6f-342d-584a-fcac0571fb10") },
                    { new Guid("d0d6e994-89f7-c30b-0eb1-4bd605634faa"), new Guid("d442d1df-85e9-de7d-854a-58aaf7501e0f") },
                    { new Guid("baebbde1-574f-86ed-306f-dfe736a2938d"), new Guid("d8026b84-ff1c-4b76-2738-8664d4a8f969") },
                    { new Guid("9b797336-85ce-c187-e965-bd67c9e67ab2"), new Guid("d9baf1e9-79f6-13be-a3ab-f43c853617f5") },
                    { new Guid("4a3c2702-cdd9-0667-c1ff-7a4b3565a07f"), new Guid("dfbd9623-f9f5-3b6d-166c-145a3a671ef8") },
                    { new Guid("78fa6db5-6406-2d29-0824-713965033682"), new Guid("f2408d05-a79a-c753-dfe6-b1a32b76ccef") },
                    { new Guid("45b047af-85b7-485b-099e-d6f1a4f29a0e"), new Guid("f8ac4b67-8a53-36c7-d65f-2c933c48a1cc") },
                    { new Guid("93535c8e-aed2-5c82-7606-9f4c27203842"), new Guid("fa83a77e-fd88-0bd3-a27a-75317f90f9e9") },
                    { new Guid("1a2c192c-4799-6a76-5201-3a7f9e4bf521"), new Guid("fadb37f2-dbaf-1d08-64f7-f6916b849f71") }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "IsPaid", "UserId" },
                values: new object[,]
                {
                    { new Guid("097992f7-e23e-44f9-6786-7215b0382ee1"), true, new Guid("26e5d66f-6585-22e0-094d-fb5b85f2e212") },
                    { new Guid("178db81e-bb29-5937-1335-48bd55f5fd6d"), false, new Guid("53241cf7-b572-ec38-0ad5-141389409a83") },
                    { new Guid("1e5257b9-959f-ef5f-b31b-afe6863ccbd2"), true, new Guid("597e2ad8-e1b1-14b1-a362-87d255039ba2") },
                    { new Guid("215d7c2d-30dc-a2d3-e3fe-1212cd3edff6"), false, new Guid("597e2ad8-e1b1-14b1-a362-87d255039ba2") },
                    { new Guid("289259ce-cbd8-6868-7de8-ffe1b1188a61"), true, new Guid("6ed18f69-138a-cf92-b5c7-01c29c62f66a") },
                    { new Guid("29901c5c-1c08-b2e4-7904-dea2bc686848"), true, new Guid("197e5c7a-9c8f-14d6-6e80-2c3be7d682a6") },
                    { new Guid("2b8ff4b3-9a3c-df68-3818-ba225372914e"), true, new Guid("67e128a6-a09e-51d1-cc4b-fbbd53be3d6e") },
                    { new Guid("2ce3db04-495b-ab8c-2d9c-a078643b47e4"), false, new Guid("6ed18f69-138a-cf92-b5c7-01c29c62f66a") },
                    { new Guid("36182bcf-05ca-dd2e-49cd-af5afee3e1db"), false, new Guid("b5c6238c-183a-3cb7-8693-934145fc950a") },
                    { new Guid("3623bab2-8fea-dbdf-0523-50c2fb7598e6"), false, new Guid("352f4ad7-bd62-829c-9ac9-77c70036b70f") },
                    { new Guid("3b530bd2-d731-ea99-1e97-6f41cf329bf0"), false, new Guid("70cedaaf-9bd4-b5d7-64ac-b6c7d797e44c") },
                    { new Guid("3dc3fe2f-b4aa-69f3-fe39-0fa9c3cb6ea1"), true, new Guid("55f3f4fc-5ee6-b27b-1753-a10d465d8772") },
                    { new Guid("3ffab9a1-d223-7bc5-a41e-4192f650a7c1"), true, new Guid("46c6f57b-3c76-23f5-3df5-2210bb3230f1") },
                    { new Guid("64c94b77-74c7-d3e2-f26f-90e5cb8d48da"), true, new Guid("b3e46965-6bec-4060-88f1-9e670b8968e7") },
                    { new Guid("8c54d6e5-3a68-dc91-6c4d-00b4851f89a1"), false, new Guid("197e5c7a-9c8f-14d6-6e80-2c3be7d682a6") },
                    { new Guid("90e37276-d0ee-6f21-3608-d8554f70786b"), false, new Guid("af70607f-adef-06e2-822d-4f2753ac835e") },
                    { new Guid("91a10cac-5e27-87bb-d8c5-c0dc7980f015"), false, new Guid("e281dcb5-a732-75f3-46c4-5a84c1403170") },
                    { new Guid("aa71e6fb-15a8-367a-6526-ecbe9854ffa8"), false, new Guid("4f26070a-c609-5798-2999-6049edbaf85c") },
                    { new Guid("afdace3c-cd39-b309-2908-0dad296622ea"), true, new Guid("597e2ad8-e1b1-14b1-a362-87d255039ba2") },
                    { new Guid("b48e63d2-03ae-a1ed-920f-57a210529dc7"), false, new Guid("46c6f57b-3c76-23f5-3df5-2210bb3230f1") },
                    { new Guid("b5110586-0251-a51f-7306-99667151e48e"), true, new Guid("e0099be6-e534-ac73-fa06-c1ed910570de") },
                    { new Guid("c00a2105-d8c1-aeb6-56b1-e51c68e2b464"), true, new Guid("b5c6238c-183a-3cb7-8693-934145fc950a") },
                    { new Guid("c4b24734-7bbe-cca6-a946-dc43923d193e"), true, new Guid("6ed18f69-138a-cf92-b5c7-01c29c62f66a") },
                    { new Guid("d0cb2b04-36a0-a92c-5542-fa296d666fc9"), true, new Guid("b3e46965-6bec-4060-88f1-9e670b8968e7") },
                    { new Guid("d972daee-a575-8475-a605-87dfcafc0c6e"), true, new Guid("67e128a6-a09e-51d1-cc4b-fbbd53be3d6e") },
                    { new Guid("e082cfb5-7299-aa11-ff41-08b1ff169303"), false, new Guid("b3e46965-6bec-4060-88f1-9e670b8968e7") },
                    { new Guid("e09aa51f-fc6d-74d0-bdd5-e025ac93056d"), true, new Guid("b3e46965-6bec-4060-88f1-9e670b8968e7") },
                    { new Guid("e138c571-9c1e-d25f-c5a3-df253a1cafde"), true, new Guid("b5c6238c-183a-3cb7-8693-934145fc950a") },
                    { new Guid("ece6c3fb-478d-b1bd-5beb-9020e60e785e"), true, new Guid("d2546772-b9cb-122b-32cc-8db2caea3a8c") },
                    { new Guid("ed896325-3f59-4b6c-a12a-f3903ba60a36"), false, new Guid("67e128a6-a09e-51d1-cc4b-fbbd53be3d6e") }
                });

            migrationBuilder.InsertData(
                table: "Screenings",
                columns: new[] { "Id", "MovieId", "Price", "RoomId", "StartDateTime" },
                values: new object[,]
                {
                    { new Guid("0da410de-42ef-1cab-eede-6a33a4330cab"), new Guid("1b3f1c4f-6a5e-72b9-3ca2-449ef10b8b93"), 0.052826608784066531, new Guid("c9e0fb54-4ffc-bb78-4871-52f370d1277b"), new DateTime(2024, 6, 22, 11, 36, 30, 685, DateTimeKind.Unspecified).AddTicks(9295) },
                    { new Guid("1a9ddcd6-f4e1-5f18-5cbf-04037d771d1e"), new Guid("03513d02-6403-2d4c-a0ef-2887137b3a2f"), 0.92012156430048553, new Guid("cdd1ddd9-ba6e-5c32-6093-37434d5dda7c"), new DateTime(2024, 6, 4, 23, 57, 45, 529, DateTimeKind.Unspecified).AddTicks(2746) },
                    { new Guid("1d7ee9e3-7b17-cab7-bc65-47089bec5089"), new Guid("9109e66f-ef19-234d-0ede-b0e9534f3f1d"), 0.36860421043252367, new Guid("2883287e-72b1-f213-99c3-00ad5216b083"), new DateTime(2024, 7, 7, 10, 39, 5, 53, DateTimeKind.Unspecified).AddTicks(8768) },
                    { new Guid("274903b1-3097-f142-1c1a-7a635176ac30"), new Guid("4aef5eba-5f79-e9f7-3317-c48377a11b93"), 0.43563442390089802, new Guid("03ba482f-dc31-97d5-b082-279d026c9833"), new DateTime(2024, 7, 1, 17, 39, 28, 496, DateTimeKind.Unspecified).AddTicks(3018) },
                    { new Guid("2ba7698b-6c7d-4158-527f-85c0bfe8ff4b"), new Guid("0dfcff25-3bbe-2b5c-f7b6-cf4eda1bb52c"), 0.54112019659977106, new Guid("61a33d14-d4aa-2828-5116-d187ca7e6f9f"), new DateTime(2024, 6, 10, 21, 49, 46, 548, DateTimeKind.Unspecified).AddTicks(5457) },
                    { new Guid("308c1da4-9bb0-c4d8-b7cd-951313625355"), new Guid("0da4b527-d9fd-db6a-5c17-6d59559d1fe2"), 0.61194777093114805, new Guid("e1e64e08-88e1-4048-5ae0-7650ef69b4ad"), new DateTime(2024, 4, 24, 16, 39, 19, 748, DateTimeKind.Unspecified).AddTicks(1037) },
                    { new Guid("3b81fd19-d13f-8339-c0b7-7b3b24836584"), new Guid("9243bd2b-5eab-1633-8c2c-fdd2550926cb"), 0.029701960400383309, new Guid("c6e2c8ce-6a57-ad01-d2e5-ac96cc6c6210"), new DateTime(2024, 5, 31, 3, 18, 54, 241, DateTimeKind.Unspecified).AddTicks(5388) },
                    { new Guid("4a7b7601-9fbb-e2f3-ad6d-b8c83501cbaf"), new Guid("0a26ceda-7cb4-2137-2874-fead2083f432"), 0.58433974554446966, new Guid("5fd53818-33e7-5e1d-8224-ab3c8ef2fe91"), new DateTime(2024, 4, 21, 6, 36, 48, 403, DateTimeKind.Unspecified).AddTicks(6636) },
                    { new Guid("4c8272a6-4111-1028-dd73-6068b32189de"), new Guid("d9baf1e9-79f6-13be-a3ab-f43c853617f5"), 0.80933164869433261, new Guid("61a33d14-d4aa-2828-5116-d187ca7e6f9f"), new DateTime(2024, 5, 7, 1, 49, 28, 46, DateTimeKind.Unspecified).AddTicks(3756) },
                    { new Guid("4ef18333-5066-aacc-6336-465e1b715eba"), new Guid("c33b839a-2c85-f4b9-117a-3be873adc26e"), 0.074500707842578229, new Guid("36f4164b-ec5d-040a-5516-ff8b1ec66e7d"), new DateTime(2024, 6, 6, 5, 42, 50, 76, DateTimeKind.Unspecified).AddTicks(683) },
                    { new Guid("592ac1d1-abea-3902-bc8a-af0fda114d3e"), new Guid("5e8f08d6-9ae7-6536-9782-b6a801316d8a"), 0.86703881958219597, new Guid("03ba482f-dc31-97d5-b082-279d026c9833"), new DateTime(2024, 4, 25, 14, 0, 32, 873, DateTimeKind.Unspecified).AddTicks(8026) },
                    { new Guid("59708d5d-dceb-ed86-c6ba-691855dd8a65"), new Guid("9d133761-6fc5-b6b2-17bb-c8409c887229"), 0.080191480273032023, new Guid("5fd53818-33e7-5e1d-8224-ab3c8ef2fe91"), new DateTime(2024, 7, 9, 20, 44, 7, 695, DateTimeKind.Unspecified).AddTicks(4103) },
                    { new Guid("5d70f594-f6f6-e04a-49a2-a2b5d2b6a32e"), new Guid("08baf875-2d19-a090-7e12-256c680bab58"), 0.5242361783034396, new Guid("b08d786c-48e0-137b-c032-ea2c436abe41"), new DateTime(2024, 5, 6, 18, 44, 5, 58, DateTimeKind.Unspecified).AddTicks(9721) },
                    { new Guid("6aae516d-0415-8e1e-aab3-4c7c57f3359a"), new Guid("2b91c83e-88b5-9098-b8eb-56d79c4da3d2"), 0.24706501378850199, new Guid("0926686f-e663-072f-2349-2bb37cde4de6"), new DateTime(2024, 5, 22, 1, 22, 56, 30, DateTimeKind.Unspecified).AddTicks(3508) },
                    { new Guid("7e9c0c62-2b30-92ff-5964-29c38ac811a1"), new Guid("d8026b84-ff1c-4b76-2738-8664d4a8f969"), 0.66186031050150307, new Guid("0926686f-e663-072f-2349-2bb37cde4de6"), new DateTime(2024, 5, 5, 16, 26, 26, 243, DateTimeKind.Unspecified).AddTicks(8230) },
                    { new Guid("8f2b7767-0232-bb29-f28e-92680e0f56a4"), new Guid("9109e66f-ef19-234d-0ede-b0e9534f3f1d"), 0.4305059070419478, new Guid("b62b0a4b-7f88-b08c-54f2-f585daef823d"), new DateTime(2024, 5, 28, 21, 35, 11, 202, DateTimeKind.Unspecified).AddTicks(5352) },
                    { new Guid("95dadf44-abb2-ae7c-aadc-d5a5e5e17654"), new Guid("62f5e1c9-3d68-18bc-2516-1465dbfb2e3c"), 0.54172771958769628, new Guid("03ba482f-dc31-97d5-b082-279d026c9833"), new DateTime(2024, 5, 16, 11, 28, 49, 865, DateTimeKind.Unspecified).AddTicks(6917) },
                    { new Guid("9acc9bb3-d7b3-9fea-da53-149b2bcc91b1"), new Guid("4ce9501c-e757-92f0-b975-439dc365aba9"), 0.27679763260694923, new Guid("c9e0fb54-4ffc-bb78-4871-52f370d1277b"), new DateTime(2024, 5, 10, 11, 5, 3, 403, DateTimeKind.Unspecified).AddTicks(7340) },
                    { new Guid("9bf72316-d25d-e3e7-ae3d-45eb7106dc3a"), new Guid("0da4b527-d9fd-db6a-5c17-6d59559d1fe2"), 0.76864185216812608, new Guid("0e152451-379a-5dde-0141-cdfbb3f7e466"), new DateTime(2024, 6, 14, 1, 12, 51, 124, DateTimeKind.Unspecified).AddTicks(2946) },
                    { new Guid("9c0f8b63-28e9-45fa-efaa-48b2ecf2166c"), new Guid("c33b839a-2c85-f4b9-117a-3be873adc26e"), 0.29341509160442103, new Guid("9a2ff284-9950-7f81-303b-5389e8fb8f70"), new DateTime(2024, 5, 27, 20, 2, 56, 194, DateTimeKind.Unspecified).AddTicks(8069) },
                    { new Guid("9fd8f490-cc4f-54ba-397c-5cafdb331c73"), new Guid("aa0ed374-c49e-6925-a53b-d6400a6b0954"), 0.14775826713770612, new Guid("0ae843dd-f647-6c0a-5937-788fc7978759"), new DateTime(2024, 4, 25, 1, 29, 12, 460, DateTimeKind.Unspecified).AddTicks(8807) },
                    { new Guid("a98e3692-1ad1-97cc-5e7a-6862bbeee7bd"), new Guid("d8026b84-ff1c-4b76-2738-8664d4a8f969"), 0.16940768759316049, new Guid("7ed02121-610f-94b7-d78c-ecea96386d0e"), new DateTime(2024, 5, 20, 19, 12, 38, 223, DateTimeKind.Unspecified).AddTicks(1518) },
                    { new Guid("b23146f5-1260-0282-e688-360ed26a40c4"), new Guid("f2408d05-a79a-c753-dfe6-b1a32b76ccef"), 0.68426531673414281, new Guid("01ca2a71-e689-7ebc-9cbb-9de170a28371"), new DateTime(2024, 5, 29, 18, 49, 20, 990, DateTimeKind.Unspecified).AddTicks(3907) },
                    { new Guid("bfd94b66-4d7a-81ae-627c-dda0e81c8730"), new Guid("03513d02-6403-2d4c-a0ef-2887137b3a2f"), 0.85420815854891619, new Guid("e43d248d-b22e-6a62-5050-227afe3033a5"), new DateTime(2024, 5, 29, 8, 51, 12, 379, DateTimeKind.Unspecified).AddTicks(5924) },
                    { new Guid("c360043c-d7a9-e7ab-8d45-51a93c35a34c"), new Guid("03513d02-6403-2d4c-a0ef-2887137b3a2f"), 0.83339138236811139, new Guid("d994cf69-76ab-5927-5b36-46867ae6518c"), new DateTime(2024, 4, 30, 1, 4, 7, 575, DateTimeKind.Unspecified).AddTicks(6210) },
                    { new Guid("e7bb4d67-c52d-ce51-ff44-54b3c672548b"), new Guid("4aef5eba-5f79-e9f7-3317-c48377a11b93"), 0.50204458908671323, new Guid("cdd1ddd9-ba6e-5c32-6093-37434d5dda7c"), new DateTime(2024, 5, 17, 8, 21, 55, 821, DateTimeKind.Unspecified).AddTicks(8860) },
                    { new Guid("eb98b458-10af-f29f-4f79-d13eaf423667"), new Guid("0dfcff25-3bbe-2b5c-f7b6-cf4eda1bb52c"), 0.28858653697440872, new Guid("0926686f-e663-072f-2349-2bb37cde4de6"), new DateTime(2024, 5, 21, 8, 39, 14, 569, DateTimeKind.Unspecified).AddTicks(9178) },
                    { new Guid("fc5feba4-2370-1922-07ca-e3b2753bcb43"), new Guid("c33b839a-2c85-f4b9-117a-3be873adc26e"), 0.38450714304706679, new Guid("44799495-79a1-3c0a-35e3-6e0582f48e8f"), new DateTime(2024, 5, 17, 4, 18, 45, 75, DateTimeKind.Unspecified).AddTicks(2537) },
                    { new Guid("fcb43b06-a9f9-613f-d4e9-2fbbe82fe855"), new Guid("0da4b527-d9fd-db6a-5c17-6d59559d1fe2"), 0.31028602581940756, new Guid("44799495-79a1-3c0a-35e3-6e0582f48e8f"), new DateTime(2024, 4, 28, 21, 8, 19, 222, DateTimeKind.Unspecified).AddTicks(6017) },
                    { new Guid("ff01df4a-1974-bbb2-8a5e-6aacae34a740"), new Guid("dfbd9623-f9f5-3b6d-166c-145a3a671ef8"), 0.30596586959229399, new Guid("a6ea9776-d918-dfaa-37b7-9e55ceb21aa1"), new DateTime(2024, 4, 29, 3, 51, 47, 440, DateTimeKind.Unspecified).AddTicks(9216) }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Number", "RoomId", "Row" },
                values: new object[,]
                {
                    { new Guid("02ef6b00-c554-30c0-1a89-d9a8ba665218"), 151240738, new Guid("36f4164b-ec5d-040a-5516-ff8b1ec66e7d"), -99060386 },
                    { new Guid("03228cba-cddb-48e6-8fb6-0275a8c1362d"), 656529081, new Guid("5fd53818-33e7-5e1d-8224-ab3c8ef2fe91"), 839399097 },
                    { new Guid("0c43f851-3ee1-b0a1-3a15-a463073c6ea4"), -1317908966, new Guid("0e152451-379a-5dde-0141-cdfbb3f7e466"), -1504911146 },
                    { new Guid("1cca84eb-c4b8-fd9e-bdd6-6ea4992837f0"), 1300082934, new Guid("e1e64e08-88e1-4048-5ae0-7650ef69b4ad"), 519770180 },
                    { new Guid("2f0a324b-973f-71a1-5fd1-2a30519fa80e"), 1382801572, new Guid("03ba482f-dc31-97d5-b082-279d026c9833"), -2032178134 },
                    { new Guid("3032c27e-d751-6efb-1c70-4fd9bae632ec"), -967604434, new Guid("d994cf69-76ab-5927-5b36-46867ae6518c"), 1562025880 },
                    { new Guid("31658ba5-2334-a9cb-09ee-b5a3486231d8"), -744085551, new Guid("863a087d-7241-d1df-c35f-49c5703ce41f"), 819403816 },
                    { new Guid("32391039-0556-ef76-2bc1-f1c6a64215ae"), -1014396619, new Guid("5fd53818-33e7-5e1d-8224-ab3c8ef2fe91"), 434752551 },
                    { new Guid("3509dafc-96e0-a7aa-2d52-864197ece7d6"), -711236965, new Guid("5990b547-f708-7e59-7b5e-1b8df500e192"), -1867284206 },
                    { new Guid("3ebf1911-0b5d-e7f8-b02b-e639565009c1"), 150310420, new Guid("d994cf69-76ab-5927-5b36-46867ae6518c"), -792265462 },
                    { new Guid("4b4d7384-d393-3e9d-6b82-ba06149f01c6"), -546541983, new Guid("863a087d-7241-d1df-c35f-49c5703ce41f"), -656337484 },
                    { new Guid("4c85d275-1271-f6a7-eef1-625cf18a859a"), -2031446528, new Guid("03ba482f-dc31-97d5-b082-279d026c9833"), 1203891281 },
                    { new Guid("51f264a9-1cff-673c-3059-a1e28b48d056"), 1623410550, new Guid("0e152451-379a-5dde-0141-cdfbb3f7e466"), -992268859 },
                    { new Guid("6192d709-2130-0d31-a8a4-d03108975407"), -1375755576, new Guid("61a33d14-d4aa-2828-5116-d187ca7e6f9f"), 1789012856 },
                    { new Guid("6305336b-b22e-ef3d-0902-e285b431e241"), -2075824669, new Guid("cdd1ddd9-ba6e-5c32-6093-37434d5dda7c"), 1031354407 },
                    { new Guid("651b5977-0092-5eba-1027-0b318e24b52e"), -1180546722, new Guid("ba61a61d-d025-d117-fcd2-831cfcaa8d2f"), -1388615203 },
                    { new Guid("6bbe96db-e850-c8f2-835d-5531455feac8"), 403077793, new Guid("ba61a61d-d025-d117-fcd2-831cfcaa8d2f"), -1160880884 },
                    { new Guid("6e379e86-37e4-919f-78c8-1b424962a88b"), -984767156, new Guid("c6e2c8ce-6a57-ad01-d2e5-ac96cc6c6210"), -1740962108 },
                    { new Guid("881b68ea-75ab-c750-9173-37f0770f1d9c"), 428185843, new Guid("d994cf69-76ab-5927-5b36-46867ae6518c"), -1756923658 },
                    { new Guid("8e0c3fc3-a54b-b56f-3b93-38cb6de900a7"), 69446467, new Guid("a6ea9776-d918-dfaa-37b7-9e55ceb21aa1"), -1381194114 },
                    { new Guid("90a57eac-b662-1861-b127-3cc5dad9b19b"), -1920415453, new Guid("36f4164b-ec5d-040a-5516-ff8b1ec66e7d"), 1072564515 },
                    { new Guid("a228ebe7-92bf-d616-5f31-f83693030f6a"), -158900303, new Guid("2883287e-72b1-f213-99c3-00ad5216b083"), 82944819 },
                    { new Guid("a2fad4ff-dcf8-d7de-9412-5b6ea9e3b906"), 1035472759, new Guid("a6ea9776-d918-dfaa-37b7-9e55ceb21aa1"), 928138991 },
                    { new Guid("b0c5582c-6178-167a-5b26-1672236520eb"), 886691973, new Guid("c9e0fb54-4ffc-bb78-4871-52f370d1277b"), 233356786 },
                    { new Guid("b27e43bc-5420-667c-4555-7524ca16f216"), 2107086621, new Guid("a6ea9776-d918-dfaa-37b7-9e55ceb21aa1"), -1127748259 },
                    { new Guid("ebe4d1b9-f49e-749b-0fc6-1b5b916621cf"), 1092949738, new Guid("7ed02121-610f-94b7-d78c-ecea96386d0e"), 1670998715 },
                    { new Guid("efd52258-fa58-5a4e-ca12-4b11dac1fde3"), 1175601179, new Guid("db86801c-12a7-9340-6002-10168168b409"), 1851741729 },
                    { new Guid("f7a363a2-bd32-2fb2-8fa4-9e6fe82f3cb8"), -918895148, new Guid("b08d786c-48e0-137b-c032-ea2c436abe41"), 1660428931 },
                    { new Guid("fc2bc8cf-d82e-4426-67d1-c30c4a077016"), -861983620, new Guid("03ba482f-dc31-97d5-b082-279d026c9833"), 1126434678 },
                    { new Guid("ff91741c-f9d5-d9f6-c4b7-74196ca83d7c"), -788579345, new Guid("62b9c08e-77f6-464f-ea7c-b79a986f4ab2"), -1483342317 }
                });

            migrationBuilder.InsertData(
                table: "ReservedSeats",
                columns: new[] { "Id", "IsReserved", "ReservationId", "ScreeningId", "SeatId" },
                values: new object[,]
                {
                    { new Guid("002940ec-6c75-5d6a-eb21-7e71d87649fb"), true, new Guid("d972daee-a575-8475-a605-87dfcafc0c6e"), new Guid("0da410de-42ef-1cab-eede-6a33a4330cab"), new Guid("3ebf1911-0b5d-e7f8-b02b-e639565009c1") },
                    { new Guid("15c83080-5dcf-2abc-4a17-e5d2b8c2f538"), true, new Guid("c00a2105-d8c1-aeb6-56b1-e51c68e2b464"), new Guid("fcb43b06-a9f9-613f-d4e9-2fbbe82fe855"), new Guid("b27e43bc-5420-667c-4555-7524ca16f216") },
                    { new Guid("16237c1d-4907-127a-38e9-9d88904ee532"), true, new Guid("8c54d6e5-3a68-dc91-6c4d-00b4851f89a1"), new Guid("fcb43b06-a9f9-613f-d4e9-2fbbe82fe855"), new Guid("6305336b-b22e-ef3d-0902-e285b431e241") },
                    { new Guid("1c29b58f-763c-26c3-2b07-12c73e95c1ff"), false, new Guid("64c94b77-74c7-d3e2-f26f-90e5cb8d48da"), new Guid("4c8272a6-4111-1028-dd73-6068b32189de"), new Guid("02ef6b00-c554-30c0-1a89-d9a8ba665218") },
                    { new Guid("1d266ed5-e4eb-10ef-39f2-3a83d3a75db8"), false, new Guid("c00a2105-d8c1-aeb6-56b1-e51c68e2b464"), new Guid("fcb43b06-a9f9-613f-d4e9-2fbbe82fe855"), new Guid("ff91741c-f9d5-d9f6-c4b7-74196ca83d7c") },
                    { new Guid("33b0aac2-ac50-f396-2c06-b778adc2da6f"), true, new Guid("178db81e-bb29-5937-1335-48bd55f5fd6d"), new Guid("e7bb4d67-c52d-ce51-ff44-54b3c672548b"), new Guid("03228cba-cddb-48e6-8fb6-0275a8c1362d") },
                    { new Guid("3595dbc0-8f90-6a1f-e74e-c0992ce56d7e"), true, new Guid("91a10cac-5e27-87bb-d8c5-c0dc7980f015"), new Guid("5d70f594-f6f6-e04a-49a2-a2b5d2b6a32e"), new Guid("ebe4d1b9-f49e-749b-0fc6-1b5b916621cf") },
                    { new Guid("479715a2-afe2-9eb5-1870-e737e5f34041"), true, new Guid("2b8ff4b3-9a3c-df68-3818-ba225372914e"), new Guid("9fd8f490-cc4f-54ba-397c-5cafdb331c73"), new Guid("881b68ea-75ab-c750-9173-37f0770f1d9c") },
                    { new Guid("559b6bb2-b2c6-4bae-59db-4779e65d1571"), true, new Guid("b48e63d2-03ae-a1ed-920f-57a210529dc7"), new Guid("0da410de-42ef-1cab-eede-6a33a4330cab"), new Guid("6bbe96db-e850-c8f2-835d-5531455feac8") },
                    { new Guid("563e9c2c-7961-221b-fc99-7c1575703c41"), true, new Guid("64c94b77-74c7-d3e2-f26f-90e5cb8d48da"), new Guid("4a7b7601-9fbb-e2f3-ad6d-b8c83501cbaf"), new Guid("32391039-0556-ef76-2bc1-f1c6a64215ae") },
                    { new Guid("57c9f4c9-5638-05fa-52d1-12915864d387"), false, new Guid("aa71e6fb-15a8-367a-6526-ecbe9854ffa8"), new Guid("fc5feba4-2370-1922-07ca-e3b2753bcb43"), new Guid("6192d709-2130-0d31-a8a4-d03108975407") },
                    { new Guid("5cc655e5-8411-fd7c-90ca-d2451844133a"), false, new Guid("3b530bd2-d731-ea99-1e97-6f41cf329bf0"), new Guid("2ba7698b-6c7d-4158-527f-85c0bfe8ff4b"), new Guid("ebe4d1b9-f49e-749b-0fc6-1b5b916621cf") },
                    { new Guid("639f9389-4046-1d2d-0e1f-8b206563c058"), false, new Guid("3ffab9a1-d223-7bc5-a41e-4192f650a7c1"), new Guid("95dadf44-abb2-ae7c-aadc-d5a5e5e17654"), new Guid("32391039-0556-ef76-2bc1-f1c6a64215ae") },
                    { new Guid("6baeb269-1c6b-e845-6da5-634f3960f1d6"), false, new Guid("36182bcf-05ca-dd2e-49cd-af5afee3e1db"), new Guid("eb98b458-10af-f29f-4f79-d13eaf423667"), new Guid("6e379e86-37e4-919f-78c8-1b424962a88b") },
                    { new Guid("7362ab84-2af5-902d-f106-7f94349a47ca"), false, new Guid("289259ce-cbd8-6868-7de8-ffe1b1188a61"), new Guid("bfd94b66-4d7a-81ae-627c-dda0e81c8730"), new Guid("3ebf1911-0b5d-e7f8-b02b-e639565009c1") },
                    { new Guid("79c9553a-6ef4-3bd0-771d-0a216416d24d"), false, new Guid("afdace3c-cd39-b309-2908-0dad296622ea"), new Guid("3b81fd19-d13f-8339-c0b7-7b3b24836584"), new Guid("1cca84eb-c4b8-fd9e-bdd6-6ea4992837f0") },
                    { new Guid("7ea0b763-5b91-612c-c5d9-d4e5dab0c5be"), true, new Guid("097992f7-e23e-44f9-6786-7215b0382ee1"), new Guid("c360043c-d7a9-e7ab-8d45-51a93c35a34c"), new Guid("6e379e86-37e4-919f-78c8-1b424962a88b") },
                    { new Guid("83d0ee58-267f-dd01-d18a-c1dd2b9647dc"), true, new Guid("aa71e6fb-15a8-367a-6526-ecbe9854ffa8"), new Guid("9c0f8b63-28e9-45fa-efaa-48b2ecf2166c"), new Guid("90a57eac-b662-1861-b127-3cc5dad9b19b") },
                    { new Guid("9a75ee4b-4bbe-0e7f-1fb7-f16777a78df9"), true, new Guid("36182bcf-05ca-dd2e-49cd-af5afee3e1db"), new Guid("5d70f594-f6f6-e04a-49a2-a2b5d2b6a32e"), new Guid("31658ba5-2334-a9cb-09ee-b5a3486231d8") },
                    { new Guid("a0684a64-2e33-fd46-7e06-0c61eafaf850"), true, new Guid("90e37276-d0ee-6f21-3608-d8554f70786b"), new Guid("3b81fd19-d13f-8339-c0b7-7b3b24836584"), new Guid("03228cba-cddb-48e6-8fb6-0275a8c1362d") },
                    { new Guid("a1c5bb8e-831e-3f12-28e0-e40bc6c6ae95"), true, new Guid("e082cfb5-7299-aa11-ff41-08b1ff169303"), new Guid("8f2b7767-0232-bb29-f28e-92680e0f56a4"), new Guid("4b4d7384-d393-3e9d-6b82-ba06149f01c6") },
                    { new Guid("bdff6944-e0de-7e93-740c-66008520106e"), false, new Guid("e09aa51f-fc6d-74d0-bdd5-e025ac93056d"), new Guid("95dadf44-abb2-ae7c-aadc-d5a5e5e17654"), new Guid("32391039-0556-ef76-2bc1-f1c6a64215ae") },
                    { new Guid("c098eefa-395f-a0df-56d7-2b46e7152004"), true, new Guid("ece6c3fb-478d-b1bd-5beb-9020e60e785e"), new Guid("9c0f8b63-28e9-45fa-efaa-48b2ecf2166c"), new Guid("efd52258-fa58-5a4e-ca12-4b11dac1fde3") },
                    { new Guid("cf6d460f-9e11-05be-5d06-afd1a856ba0d"), false, new Guid("c00a2105-d8c1-aeb6-56b1-e51c68e2b464"), new Guid("9c0f8b63-28e9-45fa-efaa-48b2ecf2166c"), new Guid("ff91741c-f9d5-d9f6-c4b7-74196ca83d7c") },
                    { new Guid("d1a7b142-63fd-6201-ed8c-1a049dcd950c"), false, new Guid("3dc3fe2f-b4aa-69f3-fe39-0fa9c3cb6ea1"), new Guid("eb98b458-10af-f29f-4f79-d13eaf423667"), new Guid("3ebf1911-0b5d-e7f8-b02b-e639565009c1") },
                    { new Guid("d7541664-fa3a-d902-da8a-0c2f2cfe0a81"), true, new Guid("2ce3db04-495b-ab8c-2d9c-a078643b47e4"), new Guid("1a9ddcd6-f4e1-5f18-5cbf-04037d771d1e"), new Guid("6bbe96db-e850-c8f2-835d-5531455feac8") },
                    { new Guid("dba3cdb8-4dac-630d-e0c4-6403080cd5e2"), false, new Guid("2b8ff4b3-9a3c-df68-3818-ba225372914e"), new Guid("a98e3692-1ad1-97cc-5e7a-6862bbeee7bd"), new Guid("31658ba5-2334-a9cb-09ee-b5a3486231d8") },
                    { new Guid("de36b689-1d8f-04e9-e4da-fc7f72dd0e1e"), false, new Guid("e138c571-9c1e-d25f-c5a3-df253a1cafde"), new Guid("c360043c-d7a9-e7ab-8d45-51a93c35a34c"), new Guid("6305336b-b22e-ef3d-0902-e285b431e241") },
                    { new Guid("f02f32eb-fcb8-3ca1-bf0f-a9e7b474b7d0"), true, new Guid("3b530bd2-d731-ea99-1e97-6f41cf329bf0"), new Guid("bfd94b66-4d7a-81ae-627c-dda0e81c8730"), new Guid("03228cba-cddb-48e6-8fb6-0275a8c1362d") },
                    { new Guid("f1409a1e-4691-bff3-bc89-3ae92586f101"), false, new Guid("d0cb2b04-36a0-a92c-5542-fa296d666fc9"), new Guid("274903b1-3097-f142-1c1a-7a635176ac30"), new Guid("1cca84eb-c4b8-fd9e-bdd6-6ea4992837f0") }
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
