using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cinema.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    { new Guid("022dd690-6067-c12b-8240-942fd8858fd1"), "Veritatis molestiae delectus enim nulla voluptate nostrum numquam.\nMolestias laborum exercitationem est ad sed aliquam labore quo voluptatem.", "Ian Stanton", "http://ines.net" },
                    { new Guid("082090a8-4838-4af4-ffc9-e64e678afdb7"), "Ullam itaque et impedit distinctio.\nDignissimos possimus minima qui.", "Mallie Ullrich", "http://cyrus.com" },
                    { new Guid("146949eb-24c9-337d-1239-2fb4f2d0ff20"), "Odit maiores possimus cumque recusandae hic.\nPariatur molestiae eum nobis autem sunt.\nRerum recusandae sunt molestiae odio non odit.\nNulla minima magni perferendis in corporis rerum.\nQuia iste distinctio voluptatem assumenda.\nIpsa iste et quia nobis ut distinctio vel voluptas.", "Chet Dare", "http://gina.net" },
                    { new Guid("2759da22-c046-fd6c-c66f-24460126c58d"), "Explicabo quis aliquam est explicabo ad.\nEos doloribus cupiditate unde omnis voluptas quia.\nError aliquid et in ducimus nesciunt quis eum.\nMollitia aut id at doloremque.", "Rebeka Will", "http://wendy.net" },
                    { new Guid("346f5b73-e5ee-615b-1d67-45be53932778"), "Ut sit odio voluptatem quaerat inventore aut eaque distinctio nisi.\nEt expedita et qui placeat ut repudiandae beatae.\nSaepe et impedit quas qui optio error tempore.\nExcepturi inventore est eos temporibus.", "Candelario Collier", "http://lucile.info" },
                    { new Guid("3e917211-b06a-9650-60d6-8771a407e56b"), "Est voluptatibus dolorum totam non tempora dolorem labore.\nQuibusdam consequatur accusamus voluptas voluptas aut.\nEt consequuntur voluptas ut dicta recusandae.\nFugit in id est et similique dolorem.", "Michaela Kub", "https://dwight.com" },
                    { new Guid("4a8603e2-0438-49d8-55b7-514c0571d2bc"), "Nostrum impedit ut maiores.\nDolorum possimus odio soluta.", "Jeromy Kertzmann", "http://aglae.net" },
                    { new Guid("4d945959-f7ac-88dc-d88c-a306aa321798"), "Laudantium voluptatum qui at.\nOfficia quo est qui itaque voluptatem impedit aut nihil.\nAtque unde id veritatis ut.\nUt libero exercitationem.\nVel ut architecto tenetur.\nSimilique optio debitis tempore cumque.", "Audra McKenzie", "https://dina.info" },
                    { new Guid("566550bf-ce44-c98d-7bff-8bf8aa679028"), "Rerum ut eos autem animi libero qui qui est.\nSequi sapiente sit eligendi ad qui voluptatem optio.\nId blanditiis sequi rerum repudiandae et culpa magni nam.\nNulla sunt suscipit.\nA odit et pariatur omnis ipsum laudantium doloribus ducimus.", "Kirk Gottlieb", "http://rachel.net" },
                    { new Guid("59556a4a-274c-5717-f4e4-fa9242c74036"), "Fugiat repellendus blanditiis.\nVoluptatem eos corrupti qui cumque asperiores numquam aperiam.", "Pascale Wunsch", "http://kayden.info" },
                    { new Guid("5cf0d979-d039-6a35-f8f6-92e0f59bd8db"), "Iusto eligendi excepturi perspiciatis.\nProvident odit dolorum beatae id sit vero recusandae quaerat.\nVoluptatibus corrupti minus dolores aut.", "Rose Towne", "https://evelyn.com" },
                    { new Guid("63909af8-0955-7c4c-c6b0-6ae2bee3e4b0"), "Odit sunt suscipit mollitia dolores voluptatem repellat autem.\nVoluptatem vel eaque pariatur dolore qui at repellat non.\nLaborum sit est.\nEa molestias aut corrupti vel voluptatem odio nam officiis.", "Chester Doyle", "https://charles.org" },
                    { new Guid("6ef51afc-95e6-9dc2-1366-60febfc27a7b"), "Minima quia doloremque illum et dolorem quas eum quo.\nVero molestias rerum.\nEa error facilis tempore ab.\nPraesentium excepturi id deleniti magni.", "Imani Leuschke", "http://wyman.com" },
                    { new Guid("7b358c8a-40cf-173f-c84c-9cc9536a8a85"), "Ut accusamus quae totam ut et officiis vitae.\nOmnis ut alias eligendi earum itaque nesciunt consequatur consequuntur.\nSit placeat distinctio explicabo est veniam consequatur.\nDoloremque cumque aut.\nSoluta qui officiis aliquam dolores aut blanditiis.\nAtque illum vero fugiat sint doloremque.", "Tia Lesch", "http://elwyn.name" },
                    { new Guid("80e4e246-c0d6-81d9-1371-a669e6f91281"), "Ratione totam ut hic veniam iusto occaecati quae.\nIpsam dolorum voluptas.\nOfficiis nemo ea quas et magnam laboriosam.\nQui unde nam.\nQuis accusamus fugiat nihil et qui.", "Gloria Connelly", "http://moshe.org" },
                    { new Guid("85d6efba-d60f-0172-91f1-090f9e09fee2"), "Occaecati vitae itaque et excepturi provident laborum eius.\nRerum dolorem et distinctio quasi est fuga rerum porro in.\nDignissimos et expedita excepturi voluptas accusantium dolores.\nEa voluptatem rerum tempore vel aut quasi.\nEa quisquam vel modi hic.", "Hattie Collins", "https://monroe.org" },
                    { new Guid("9df502fb-c8b1-f021-155a-9b6d5551ba1e"), "Libero error sint fuga beatae.\nQuia quia ut voluptas quidem.", "Virginia Moen", "http://ines.net" },
                    { new Guid("9e7d44ec-b06b-4de1-a084-3f3926c86639"), "Possimus consequatur et iusto qui voluptatem.\nEst explicabo aut aliquid dolorem est animi nam vel velit.\nEveniet sit quisquam ut voluptatum.\nMolestiae et et omnis est mollitia sed facilis dicta inventore.", "Vida Thiel", "http://marcia.net" },
                    { new Guid("a3d2a9fc-8026-c1e0-7fe0-e501a1d2137a"), "Quis minima tempore ratione id culpa fugit rerum voluptatem.\nQuo tempora ullam dolores sint facilis nulla vel.\nEt ullam natus.\nOmnis ex vel necessitatibus magni.\nVelit aperiam repellat voluptatem veniam dicta voluptatum nihil tenetur vero.\nMollitia cumque vitae.", "Maritza Nienow", "http://elsie.name" },
                    { new Guid("a82aabd5-3eaf-845a-b06b-b00e32816281"), "Ab omnis quos consequatur facilis.\nDoloremque quam natus.\nDistinctio amet voluptas dicta qui doloribus.\nCulpa rerum quaerat.\nRecusandae eos aliquam quia aperiam amet ipsum consequatur.\nAnimi enim quidem.", "Paula Weber", "https://eloy.info" },
                    { new Guid("a9f5a33d-b01e-bf2c-1126-c4f6704ea8a5"), "Et modi omnis.\nEligendi modi illum iure corporis enim exercitationem.", "Kim Thiel", "https://aric.name" },
                    { new Guid("aabb6fb8-22c2-af5a-dfff-e4f694ea36c0"), "Nulla iusto consequatur sit repudiandae sapiente nam.\nEt a hic explicabo veniam.", "Cedrick Schumm", "https://abdiel.net" },
                    { new Guid("c4f73873-9eb9-d5f1-572c-6d3094626a55"), "Nostrum repellendus nulla aut aut modi architecto.\nDistinctio optio tempore.\nMolestias aliquam aliquid atque illo pariatur doloremque est.\nUt quia id eum culpa doloribus esse nihil.\nEst temporibus unde.", "Alison Lueilwitz", "https://irma.com" },
                    { new Guid("cf89d64e-f3be-30c8-d10b-9c11a986504d"), "Minus aut quos.\nDelectus ab similique consequuntur aperiam.\nVoluptas perferendis expedita.\nEx optio sunt commodi fugiat mollitia vitae qui maxime dignissimos.\nCorrupti aliquam non nihil sed optio sit quis dolorem.\nIn tempora doloribus.", "Rebeca Gerhold", "https://louvenia.biz" },
                    { new Guid("e5f9b899-ec07-a65f-d44b-a7868c74918c"), "Quod voluptatem eius.\nDebitis architecto corporis quas nemo et unde consequatur sint amet.\nConsequatur magnam eum sequi ex.\nHic repudiandae vero ullam et reprehenderit voluptas.\nDignissimos fugit distinctio consequatur dicta tenetur et.", "Lysanne Denesik", "https://isom.org" },
                    { new Guid("e8d1d5d1-b0dc-4d66-be3b-64c75e29b877"), "Vel minima ex sequi nesciunt id officia sit autem officia.\nDignissimos consectetur fugit quo praesentium ut.\nOptio corrupti praesentium.\nQuam perspiciatis ab nam quia deserunt officia et corporis debitis.", "Duane Padberg", "https://franco.net" },
                    { new Guid("f24236de-90a5-c1d7-b5f8-75512207906e"), "Deleniti nemo quisquam.\nAutem voluptatum doloribus blanditiis sed recusandae.\nOdit neque quia natus.\nDolores cumque omnis aliquam.\nEt libero eos molestiae perferendis magnam vero.\nEt quo atque provident in unde blanditiis ipsum qui eum.", "Donnell Rogahn", "http://maud.net" },
                    { new Guid("f5bf80da-e397-34b1-76f0-906608f6c511"), "Fugit quasi sit qui tempore quia.\nDignissimos laboriosam minus alias eum sit est et.", "Donato Lubowitz", "https://darrell.com" },
                    { new Guid("f91511db-fdc5-f283-bd02-c7b89e8878a9"), "Eum officiis laborum ex et doloribus unde tempore dicta eum.\nAliquam autem sunt necessitatibus.\nQuasi sint earum consequatur occaecati porro labore eligendi libero at.\nEa pariatur qui fugiat earum voluptatem possimus.\nDolorem reprehenderit sed.\nQuia debitis in quia ab impedit autem eum.", "Ernestina Christiansen", "http://margaretta.org" },
                    { new Guid("faee8cea-8813-5934-d186-d7865be917f7"), "Repellat eaque blanditiis maxime ut est.\nItaque impedit dolorem.", "Magdalena Ruecker", "http://conor.info" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { new Guid("08be4357-6f7e-5516-6f0d-c7db8f01f65a"), "Hip Hop" },
                    { new Guid("10cb8272-8fc9-31ed-c51d-cf3318d2be2d"), "Blues" },
                    { new Guid("131348ea-c2c2-5256-9101-45d134817851"), "Reggae" },
                    { new Guid("174cceb8-34ea-c8bd-4871-a56e358a279f"), "Funk" },
                    { new Guid("26743426-fdca-ec19-2730-6959c424bbcd"), "Funk" },
                    { new Guid("2ac7a2a4-91ab-1168-0e28-b0a471aec43c"), "Latin" },
                    { new Guid("2b681309-1363-e630-a2b8-72a090d20431"), "Rock" },
                    { new Guid("31e37187-bf61-d36e-3b46-86bfbef69d2b"), "Non Music" },
                    { new Guid("33e37f51-7804-2805-c50e-292ff754914e"), "World" },
                    { new Guid("4a628deb-8d52-b9ec-605a-88f707f9ec8c"), "Non Music" },
                    { new Guid("4fa22bc4-a756-5bc2-c37b-df3a84735f68"), "Jazz" },
                    { new Guid("52a615a1-6cb8-bfce-acb8-77fa62c89f44"), "Latin" },
                    { new Guid("60f86033-abf2-42f5-c9fc-9b6e7530a1ba"), "Jazz" },
                    { new Guid("759bd1e6-5d46-e5de-6bdd-dd15a28659b4"), "Soul" },
                    { new Guid("769674f9-1e58-05ee-3571-0b5131eb40d7"), "Hip Hop" },
                    { new Guid("77bf61e6-4dbf-bc62-9c3e-03ed38a01316"), "Blues" },
                    { new Guid("886c3eab-8664-0ded-0618-70df9515e4f5"), "Folk" },
                    { new Guid("8d187872-35da-51fe-157a-56a86988b6b7"), "Folk" },
                    { new Guid("91bc04e3-f3f6-dfc3-eb1d-50e178559c1e"), "Soul" },
                    { new Guid("9511c5f6-396c-fcc2-02b1-4f6fb2e77d78"), "Metal" },
                    { new Guid("99065fc2-7e8f-cbd5-7d6c-c3fbd4ac0f3a"), "Classical" },
                    { new Guid("9935b1a0-54d3-8d34-3f16-6675bf349f48"), "Metal" },
                    { new Guid("9f0ca13b-ae6d-b46a-5065-8ccaebf81eea"), "Hip Hop" },
                    { new Guid("a383f980-311c-535d-4cf8-bf3cec6e5415"), "World" },
                    { new Guid("a89ddd73-684d-d101-a34f-9c795d914f48"), "Electronic" },
                    { new Guid("ccd004c5-9e28-9bd6-d08c-6ce433c0305b"), "Metal" },
                    { new Guid("d13db6ba-d13d-ee39-4f6c-74254c4f2065"), "World" },
                    { new Guid("d4d35fbd-b662-3139-e5bc-19b0de85138c"), "Classical" },
                    { new Guid("dd1940db-f0ad-187c-3cc0-c6204aec9498"), "World" },
                    { new Guid("e46eec5e-9d47-6571-f445-3887f7b708b4"), "Funk" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Duration", "EndAiringDate", "Name", "Photo", "Rating", "ReleaseDate", "StartAiringDate", "Trailer" },
                values: new object[,]
                {
                    { new Guid("0d60199b-904d-8105-f3b1-b489995c08e9"), "Natus accusamus et perferendis omnis tempora aut est commodi eos.\nSimilique sequi dolorem iure fuga qui similique.\nAut officiis nulla delectus quas recusandae et explicabo eum.\nCulpa omnis quia sed molestias eos voluptatem laboriosam vel.", new TimeOnly(17, 41, 51, 823).Add(TimeSpan.FromTicks(4485)), new DateOnly(2025, 4, 14), "Nakfa", "https://ludwig.name", 6.0, new DateOnly(2024, 1, 22), new DateOnly(2023, 7, 3), "http://esperanza.org" },
                    { new Guid("1676ae13-247f-863c-c97b-e14bfe2fc31e"), "Magnam sapiente nostrum eos impedit quia rem neque consectetur facilis.\nIpsam voluptas vitae totam magnam.\nFuga earum corporis.\nEa sequi quis inventore id placeat sit.", new TimeOnly(18, 12, 2, 997).Add(TimeSpan.FromTicks(5544)), new DateOnly(2025, 3, 1), "incubate", "https://devonte.name", 5.0, new DateOnly(2023, 7, 1), new DateOnly(2024, 3, 19), "https://lisette.com" },
                    { new Guid("230031c8-b1d8-546b-93a8-f81cb081c5bf"), "Occaecati soluta ratione et dignissimos deserunt et velit amet ut.\nConsequatur ab dicta culpa et velit pariatur commodi impedit.", new TimeOnly(18, 9, 40, 637).Add(TimeSpan.FromTicks(4912)), new DateOnly(2024, 6, 26), "Syrian Pound", "https://jamaal.org", 10.0, new DateOnly(2024, 3, 20), new DateOnly(2024, 5, 2), "http://melvina.info" },
                    { new Guid("2b933515-6dc4-95d3-e95e-9ffefcc87327"), "Ut qui facere.\nTemporibus et sint commodi laboriosam placeat saepe eos aspernatur.\nIpsa sapiente mollitia dolores vel ullam dignissimos rem.\nRem ab qui esse voluptate et nemo velit.\nSint placeat est id dolorum ex quis nam magnam.", new TimeOnly(17, 59, 30, 94).Add(TimeSpan.FromTicks(5348)), new DateOnly(2024, 11, 18), "Personal Loan Account", "https://palma.info", 8.0, new DateOnly(2024, 2, 26), new DateOnly(2023, 5, 23), "http://jazlyn.net" },
                    { new Guid("2d51bb94-6b36-a78f-ccf6-4c36cbb9cebb"), "Ullam et eum rerum vitae est aut dolorum aut.\nQui adipisci et sit voluptas quaerat veritatis exercitationem exercitationem.", new TimeOnly(18, 33, 50, 302).Add(TimeSpan.FromTicks(378)), new DateOnly(2024, 6, 29), "Berkshire", "http://libbie.org", 3.0, new DateOnly(2024, 3, 29), new DateOnly(2024, 5, 10), "http://clifford.name" },
                    { new Guid("3c3f9a72-1b65-b3ce-9a23-726d476704f3"), "Minima maiores voluptatem asperiores illum occaecati.\nNihil eligendi perspiciatis laboriosam voluptas rerum esse qui consectetur quis.\nSuscipit consectetur nihil doloribus et temporibus at omnis.", new TimeOnly(18, 3, 56, 605).Add(TimeSpan.FromTicks(4452)), new DateOnly(2024, 6, 1), "Guadeloupe", "https://katlynn.name", 7.0, new DateOnly(2024, 5, 5), new DateOnly(2024, 4, 5), "https://jeromy.name" },
                    { new Guid("5e5e96b7-f133-a30a-36f1-c8cbcd2b398d"), "Repellendus est soluta earum sint quis.\nQui ex iusto perspiciatis.\nNisi enim neque ad et quas nihil.\nNatus veritatis ut sapiente repudiandae facere ipsam et.\nAdipisci rerum ipsum.", new TimeOnly(17, 45, 9, 285).Add(TimeSpan.FromTicks(4075)), new DateOnly(2024, 7, 16), "turquoise", "http://orrin.name", 1.0, new DateOnly(2024, 4, 5), new DateOnly(2023, 11, 29), "https://verla.net" },
                    { new Guid("684034ed-2fde-17ad-0dda-f7bd3eca5ca4"), "Omnis et debitis eveniet repellat autem esse quaerat.\nAut assumenda molestiae eos iusto voluptatum non.\nEligendi esse veniam distinctio non at ut tempora voluptas modi.", new TimeOnly(17, 55, 48, 840).Add(TimeSpan.FromTicks(9496)), new DateOnly(2025, 1, 12), "Metical", "https://kasandra.com", 8.0, new DateOnly(2023, 7, 19), new DateOnly(2024, 3, 17), "https://kennedi.biz" },
                    { new Guid("6e5f33af-eeb1-62a0-7972-14d03e1dcd3e"), "Similique reprehenderit ipsum sit voluptas consequatur et quia soluta.\nSed labore perferendis eos pariatur eos a.", new TimeOnly(17, 57, 10, 85).Add(TimeSpan.FromTicks(8878)), new DateOnly(2024, 7, 9), "e-tailers", "https://cary.info", 8.0, new DateOnly(2023, 11, 21), new DateOnly(2023, 6, 6), "http://elyssa.info" },
                    { new Guid("833f3cf1-acae-07b3-462a-77f9f99063dc"), "Quasi vel aut quia temporibus vitae totam nobis.\nQuia fuga voluptatibus in.\nFugit consequuntur atque consequuntur.", new TimeOnly(18, 13, 10, 843).Add(TimeSpan.FromTicks(4553)), new DateOnly(2024, 5, 25), "Small", "http://janis.com", 2.0, new DateOnly(2023, 12, 21), new DateOnly(2023, 12, 31), "https://edd.org" },
                    { new Guid("846b3280-8f50-fe85-a931-bdb592ef7506"), "Cum ut fugit consequuntur sint.\nArchitecto velit ducimus maxime ratione.", new TimeOnly(18, 27, 12, 456).Add(TimeSpan.FromTicks(1948)), new DateOnly(2024, 5, 19), "communities", "http://ashtyn.info", 9.0, new DateOnly(2023, 10, 11), new DateOnly(2023, 8, 25), "https://lazaro.net" },
                    { new Guid("89563d90-d66e-7f8c-8edc-4088d8a5e607"), "Eaque facilis rerum dolorum unde cum eos quas.\nAccusantium et ex sit.\nEt facilis qui amet dicta neque enim possimus sed ut.", new TimeOnly(18, 29, 51, 302).Add(TimeSpan.FromTicks(5330)), new DateOnly(2025, 3, 1), "Sports & Sports", "http://rex.name", 9.0, new DateOnly(2023, 8, 1), new DateOnly(2023, 5, 20), "http://randi.org" },
                    { new Guid("9444e14f-2558-f3e6-e400-0db22ca1f167"), "Odio sit voluptates aliquid at voluptatibus.\nExplicabo sed qui consequatur suscipit tempore beatae voluptatem et.\nNon et vel qui.\nVel temporibus repellendus modi ea soluta ad animi.\nRecusandae recusandae et quia consectetur.", new TimeOnly(17, 51, 17, 537).Add(TimeSpan.FromTicks(7036)), new DateOnly(2025, 4, 29), "Rial Omani", "https://erwin.com", 4.0, new DateOnly(2023, 9, 4), new DateOnly(2024, 5, 1), "http://monserrat.info" },
                    { new Guid("97e3c58f-421c-4887-9263-104a164cbfad"), "Est consectetur et aut consectetur.\nModi et dicta quia voluptatem provident.\nIn voluptas aut repellendus.\nExplicabo hic provident aut doloribus ut.\nImpedit enim minima quidem distinctio.", new TimeOnly(17, 45, 26, 634).Add(TimeSpan.FromTicks(2990)), new DateOnly(2025, 1, 9), "Inverse", "http://elva.name", 5.0, new DateOnly(2023, 12, 30), new DateOnly(2023, 12, 23), "http://art.org" },
                    { new Guid("9e78d36f-0878-86b9-1a3f-939eb63147f1"), "Rerum et ea possimus.\nQuisquam nesciunt autem dolorem qui.\nOmnis voluptatibus dolorem incidunt nobis vel illo.\nId labore facilis officia aut.\nConsequatur sunt aut.\nNobis tempora aspernatur consequatur.", new TimeOnly(18, 18, 34, 890).Add(TimeSpan.FromTicks(1193)), new DateOnly(2025, 2, 15), "lavender", "https://francesco.biz", 0.0, new DateOnly(2024, 1, 5), new DateOnly(2024, 1, 13), "http://angie.net" },
                    { new Guid("a8992b67-3835-60d4-f242-4c55aedd559a"), "Dolore sit cum distinctio minima sed.\nFacilis et sunt.\nFacilis voluptas labore minus.", new TimeOnly(18, 30, 33, 556).Add(TimeSpan.FromTicks(8283)), new DateOnly(2025, 4, 6), "Electronics, Baby & Industrial", "https://veronica.com", 4.0, new DateOnly(2023, 8, 11), new DateOnly(2024, 1, 15), "https://clifford.biz" },
                    { new Guid("b0aa54c1-f7cf-eb9f-d557-5cb98d59db91"), "Nihil voluptates cumque nemo qui harum.\nEt quam non nobis atque velit.", new TimeOnly(18, 35, 37, 749).Add(TimeSpan.FromTicks(9507)), new DateOnly(2024, 12, 27), "Plastic", "http://federico.com", 5.0, new DateOnly(2024, 1, 28), new DateOnly(2023, 10, 26), "https://cornelius.info" },
                    { new Guid("be1f8c86-98a8-cbce-80fa-6612c4bc58a0"), "Qui voluptatibus cumque quia ut amet et aut voluptatem est.\nNisi et cupiditate necessitatibus adipisci eligendi aut praesentium eum.\nQui omnis et quae voluptatem voluptatem similique voluptatem ut id.\nCupiditate quo quo officia doloremque aut et ex cupiditate consequatur.\nIllo ducimus ut.", new TimeOnly(18, 12, 34, 447).Add(TimeSpan.FromTicks(3295)), new DateOnly(2024, 5, 13), "Investment Account", "https://kurtis.com", 7.0, new DateOnly(2023, 7, 25), new DateOnly(2024, 4, 13), "https://mose.org" },
                    { new Guid("c289e28c-6afe-a337-753f-155da66ebfff"), "Nesciunt et dolorum.\nAut aut incidunt praesentium nesciunt voluptatem at.\nFacere qui dolore itaque.\nDolor omnis voluptate et a eum accusantium voluptatem corporis ipsam.\nEt perferendis sit recusandae voluptate qui et quos est possimus.\nQuaerat minus id non culpa voluptatem.", new TimeOnly(17, 45, 14, 546).Add(TimeSpan.FromTicks(798)), new DateOnly(2025, 4, 29), "Ergonomic Concrete Shirt", "http://billie.com", 1.0, new DateOnly(2024, 1, 12), new DateOnly(2024, 3, 2), "http://emiliano.com" },
                    { new Guid("ca039d74-e3ac-780b-00fe-e053f740c7c2"), "Laudantium et cupiditate itaque.\nDelectus quia tempore iure repellendus sint autem iste voluptatum cum.\nMaiores modi facilis aspernatur asperiores hic nisi qui.", new TimeOnly(18, 25, 43, 408).Add(TimeSpan.FromTicks(9507)), new DateOnly(2024, 12, 26), "Coordinator", "http://lauriane.biz", 9.0, new DateOnly(2024, 3, 20), new DateOnly(2023, 10, 12), "http://mattie.name" },
                    { new Guid("d0bbbab0-5e91-7170-cc70-b48248465d09"), "Unde ad dolore aut et veritatis vel vero enim.\nQui rerum ab.\nVelit culpa sapiente nihil perferendis nesciunt dignissimos illum.\nAut dolorem laboriosam est.\nUllam dicta dicta accusamus id aut incidunt.\nSed sequi ducimus.", new TimeOnly(17, 39, 1, 935).Add(TimeSpan.FromTicks(1681)), new DateOnly(2024, 10, 25), "Pines", "http://hollie.net", 9.0, new DateOnly(2023, 6, 6), new DateOnly(2023, 10, 11), "https://lucienne.name" },
                    { new Guid("d33f936d-5623-1292-f7ee-e78e7933aab3"), "Aut repellendus inventore a fuga numquam.\nCommodi tempore neque illo.\nHic velit voluptates fugit hic natus aut.", new TimeOnly(17, 59, 36, 739).Add(TimeSpan.FromTicks(6872)), new DateOnly(2025, 2, 9), "Handcrafted Soft Pants", "http://reta.biz", 9.0, new DateOnly(2023, 10, 10), new DateOnly(2024, 4, 22), "http://rosie.net" },
                    { new Guid("d8107a13-b02b-cb95-5161-fca416cc38e6"), "Voluptate eum et maxime impedit et vitae.\nSoluta sapiente perspiciatis earum et culpa velit.\nMinus et illo incidunt molestias nisi neque aut exercitationem esse.\nEt laudantium soluta aspernatur in neque est quibusdam tempora mollitia.\nNemo ullam voluptates et officia quis quas quia voluptatem laborum.", new TimeOnly(17, 41, 44, 437).Add(TimeSpan.FromTicks(3170)), new DateOnly(2024, 6, 12), "Libyan Arab Jamahiriya", "http://dorian.net", 4.0, new DateOnly(2023, 5, 30), new DateOnly(2023, 9, 13), "http://ferne.org" },
                    { new Guid("e4aae398-1937-cd9a-a9c5-f82532a9e362"), "Provident eos et asperiores earum error et necessitatibus.\nVoluptatibus ut sapiente voluptatem.\nPariatur sed molestiae nesciunt sunt harum ex accusamus.\nVeritatis ducimus quaerat saepe rem.", new TimeOnly(17, 51, 32, 516).Add(TimeSpan.FromTicks(5927)), new DateOnly(2024, 10, 15), "secondary", "http://nelda.org", 6.0, new DateOnly(2024, 2, 1), new DateOnly(2023, 10, 10), "https://isidro.biz" },
                    { new Guid("ecdd69bb-801c-8674-00ab-82fbb993d0c7"), "Eaque ea ea eos ea necessitatibus quis consectetur.\nDolore modi quasi autem atque non.\nMaiores fugit quis iusto est sint.\nIste praesentium mollitia odio quia qui error.\nVoluptatem molestiae in dolores qui id voluptatem officiis.\nDoloremque nesciunt sint fuga maiores quidem alias nam labore aut.", new TimeOnly(18, 32, 40, 857).Add(TimeSpan.FromTicks(6139)), new DateOnly(2024, 8, 26), "Lodge", "http://jerry.com", 0.0, new DateOnly(2024, 1, 26), new DateOnly(2023, 5, 22), "https://candido.org" },
                    { new Guid("f2924e34-fad9-3611-3e27-af1b37425eb1"), "Non fuga voluptas molestias odio.\nCupiditate omnis tenetur.\nSuscipit voluptate voluptatibus dolorem sed sit sed et sit.", new TimeOnly(18, 31, 37, 630).Add(TimeSpan.FromTicks(2607)), new DateOnly(2024, 7, 15), "Tasty Soft Tuna", "http://hector.info", 0.0, new DateOnly(2023, 6, 29), new DateOnly(2023, 8, 4), "https://amara.info" },
                    { new Guid("f9f9a515-16e9-a868-bbdc-ba9d568ff55e"), "Ut consequuntur aspernatur sapiente iste.\nAut modi quibusdam reprehenderit impedit officiis et doloremque id consequatur.", new TimeOnly(17, 42, 59, 865).Add(TimeSpan.FromTicks(5304)), new DateOnly(2024, 7, 25), "reintermediate", "https://carrie.com", 1.0, new DateOnly(2023, 12, 22), new DateOnly(2023, 12, 10), "http://rhea.com" },
                    { new Guid("fae6e04e-77b7-925e-4712-537f0de53104"), "Cupiditate voluptatem placeat fugit ullam aut quidem sit.\nInventore tempora tenetur quia odit et at et.", new TimeOnly(18, 23, 5, 99).Add(TimeSpan.FromTicks(1601)), new DateOnly(2025, 3, 18), "Coordinator", "http://crystal.org", 1.0, new DateOnly(2024, 5, 6), new DateOnly(2024, 3, 20), "https://scotty.name" },
                    { new Guid("fd7f69fd-fd90-daf3-b85a-c43d6d44b6d8"), "Omnis eveniet maxime consequatur qui deserunt.\nSaepe repudiandae quaerat sed quia repudiandae.\nEius maxime impedit aspernatur maiores itaque eveniet provident.\nFugit consequatur molestiae error ullam laudantium unde et omnis libero.\nRerum aut qui quo incidunt quas laudantium fugiat.", new TimeOnly(17, 38, 13, 663).Add(TimeSpan.FromTicks(9371)), new DateOnly(2024, 9, 22), "Refined Frozen Gloves", "http://stephanie.com", 9.0, new DateOnly(2023, 8, 25), new DateOnly(2023, 12, 24), "http://lane.info" },
                    { new Guid("fe91acc1-f8ec-0588-0e93-e01df7a87356"), "Alias a perspiciatis assumenda repellat.\nFacilis corporis nihil quos voluptatum unde laudantium nulla.\nQuae tempore est repellat deleniti eligendi omnis.", new TimeOnly(18, 26, 59, 179).Add(TimeSpan.FromTicks(7183)), new DateOnly(2024, 5, 15), "River", "http://reuben.org", 7.0, new DateOnly(2023, 8, 7), new DateOnly(2023, 10, 14), "http://pearlie.com" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("8a6cdc83-191e-45b5-afc8-952d9810c348"), null, "user", null },
                    { new Guid("b0f1f17b-6573-4c8e-8531-bc9cf3cc4ec8"), null, "admin", null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "NumberOfSeats", "RoomName" },
                values: new object[,]
                {
                    { new Guid("01668f2d-b644-238c-0eb1-fff5fb68d789"), -1624756269, "tempore" },
                    { new Guid("08191363-ba6e-7bf5-960e-78b2b8a6d280"), -1526209309, "maxime" },
                    { new Guid("17dc7664-7286-adc1-4a28-4345701edbc9"), 847697594, "illo" },
                    { new Guid("1de9e739-0104-dc9c-a77e-3d3d266c20dd"), -2141761597, "sapiente" },
                    { new Guid("24544eb9-1dbc-c418-7c53-5c252c31675f"), -1150293185, "et" },
                    { new Guid("266cbf9a-3286-2647-e7d5-806bc0c3ee1c"), -2118363113, "nihil" },
                    { new Guid("2ba399c7-07dd-cde9-dfd9-a654811ebe23"), 1579307077, "libero" },
                    { new Guid("2d7b0498-a5ec-b462-3630-4cb2ad5fd5a0"), -510945462, "sed" },
                    { new Guid("3b655625-224d-afa7-2300-c7cb1ce17ae7"), -1812790116, "incidunt" },
                    { new Guid("4c9f5b65-7f8a-7efd-ebb3-f2fcc5ddeabf"), 1297279271, "ipsa" },
                    { new Guid("4d6ed134-bc58-685e-857e-09a549b95a7f"), 254885532, "aut" },
                    { new Guid("59808c8c-ca5e-75ee-9d48-21b405d6fe6e"), 1942366689, "consequatur" },
                    { new Guid("6250feeb-a7b0-3b0c-30f2-9ca5e6a01aa2"), -1953006027, "minima" },
                    { new Guid("67ba2bb9-1936-97d9-8b43-552b1e8235da"), -104704913, "incidunt" },
                    { new Guid("6dd79a1b-4c46-9840-d1d2-be471412ffd3"), -730612995, "ipsam" },
                    { new Guid("8236b45b-d7f1-7844-3e60-c3e97b29e34b"), 1133121295, "fugiat" },
                    { new Guid("a168df14-1c42-45bb-6bbe-1a9c762956a7"), -423070018, "eos" },
                    { new Guid("a2c435c2-f4ce-94ca-7c83-30d0c560291e"), -2084447279, "minus" },
                    { new Guid("a353c63b-65ec-daa7-1d3c-10317cd20d48"), 854438958, "quas" },
                    { new Guid("a3adcf6a-1332-975a-fd95-b87328ade533"), 425985043, "eum" },
                    { new Guid("a9a5c618-cff3-f24a-131c-c5197ff58cb4"), -1067976061, "ex" },
                    { new Guid("af3a5cd8-ac55-0622-b16a-8fc8aa03dddf"), -154627654, "sapiente" },
                    { new Guid("b1a910c4-82d5-2363-4849-343de7c8ea24"), -1059386586, "asperiores" },
                    { new Guid("b67ae0a5-1288-c191-7a48-5c670162f488"), 1638245789, "deleniti" },
                    { new Guid("b9ab5cd3-e27f-6411-f674-a7b09c4555dc"), -1762118691, "libero" },
                    { new Guid("c9245a8e-8281-28c6-b418-ea12b7d57399"), -349684435, "consequatur" },
                    { new Guid("d2331a5e-9200-bbbc-3941-2c1c791e39a4"), -1438030675, "ea" },
                    { new Guid("d87374e9-3e1d-1714-da1d-7dddc8d599b7"), 1522173037, "autem" },
                    { new Guid("e2a565e4-3373-e06a-cff5-1ab63b53cb28"), -1219822655, "tenetur" },
                    { new Guid("ec848c17-a2fd-e941-d331-632f4e3e5610"), 1397433943, "rerum" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("172e2525-5d47-db3f-17c4-9028589f828c"), 0, "3c70da8b-464a-4fd8-9a18-27e08ce878e4", "Shanon.Reynolds@gmail.com", false, false, null, null, null, "D2ZjYefBAa", "(346) 696-2643", false, null, false, "Chadrick_Hegmann" },
                    { new Guid("1b8ce57a-006c-5290-5400-2bebb972303e"), 0, "965f7260-ca59-47c2-a5d1-4cc674ef6c20", "Marcos.Weimann@hotmail.com", false, false, null, null, null, "fyqRXzd4lz", "761.417.5208", false, null, false, "Verlie.Kunze" },
                    { new Guid("22a45f42-0db9-e089-7620-373a5c548a9a"), 0, "91411133-64d0-42ae-9fd3-92737207ab67", "Orrin14@hotmail.com", false, false, null, null, null, "TzqmuJXMio", "446-741-9081", false, null, false, "Ashton.Goldner48" },
                    { new Guid("26151abe-f8c2-2b76-b3eb-6c2d985ba1bc"), 0, "e17c06da-461a-4047-bcd4-394594904a9f", "Josiane.Kuhlman@gmail.com", false, false, null, null, null, "t7wcssgeYa", "647-329-8970 x7857", false, null, false, "Granville.Schuppe18" },
                    { new Guid("30e563e1-3455-a5d1-2ddd-d12011c6527e"), 0, "d0a4ffa7-2f62-484d-9dac-2d1ac0cf6b05", "Trisha_Fadel@hotmail.com", false, false, null, null, null, "9y_HSUAS5f", "809.312.5742 x299", false, null, false, "Lilyan.Doyle" },
                    { new Guid("3375b9d6-46ac-d681-cf12-16211992092f"), 0, "75d5ea05-a7b9-422a-8c27-d5969fc2fb1e", "Hailie.Kuphal82@yahoo.com", false, false, null, null, null, "6pK0KfG4nR", "(640) 644-2477", false, null, false, "Robert.Harvey" },
                    { new Guid("3b278273-5cd1-b7a2-aed3-2174a080233e"), 0, "18ac39a3-41a5-4036-b907-a3d209749c1d", "Fay.Considine@hotmail.com", false, false, null, null, null, "ndoIETNm0B", "(481) 658-2435 x9012", false, null, false, "Sally.Will" },
                    { new Guid("43908764-e2f0-3994-8603-ad18bcaa57c1"), 0, "68612f94-2ca3-407a-b60c-c85eb3fa7e78", "Aracely.Huel@yahoo.com", false, false, null, null, null, "G8wts_55xD", "(870) 694-7076", false, null, false, "Dessie_Mertz82" },
                    { new Guid("5b6d839c-485d-31f9-221a-0992eea96ba8"), 0, "d3a7da33-7b38-4972-966c-e74fc306f1a4", "Billy.Nader61@yahoo.com", false, false, null, null, null, "4cTg3HRhHA", "491.680.3192 x80262", false, null, false, "Emerson40" },
                    { new Guid("78d3f68f-3ba7-9fd1-ac7c-5b6f71226234"), 0, "01a98eee-fc0b-4b7e-901e-22a8bf636a62", "Ewell.Yundt@yahoo.com", false, false, null, null, null, "nH3rguJUPH", "805-231-1298 x015", false, null, false, "Holden.Wolff21" },
                    { new Guid("7e20e9db-301c-881e-3923-ca59188eb2cb"), 0, "abbedad9-4917-477e-a816-734a224a4e7e", "Cierra_Kovacek@gmail.com", false, false, null, null, null, "e30W6MJcCv", "693-750-4365 x49575", false, null, false, "Marcelo.Rice89" },
                    { new Guid("8763dd78-a521-6cf8-a97f-564335f6311c"), 0, "88d9c475-0b54-43b3-8894-f413e331af72", "Eileen_Trantow33@gmail.com", false, false, null, null, null, "n11fJ6VgHs", "(352) 360-3173", false, null, false, "Aylin_Aufderhar88" },
                    { new Guid("8e9069f0-db9b-c38a-80d2-cb6ad13fa59a"), 0, "db5628e8-c0b8-4a6e-8035-0eb37a13a5d0", "Mariane43@gmail.com", false, false, null, null, null, "Tlro3v3zva", "286-225-1687", false, null, false, "Audra_Medhurst" },
                    { new Guid("a1013b4a-d587-45cb-7e49-be6d13376ae0"), 0, "1659eaae-bf2d-4366-a914-15260ffc9669", "Myrtle41@gmail.com", false, false, null, null, null, "2yAvEQGOZF", "(369) 763-6252", false, null, false, "Jarret30" },
                    { new Guid("a1fd4884-87cc-ca9f-990a-9bc15384ee92"), 0, "1f63a827-ab4f-4fe1-909f-6a16639b6fd5", "Aric.Graham7@yahoo.com", false, false, null, null, null, "x2iJdVpBgh", "858.744.3296 x36804", false, null, false, "Tre_Gerhold" },
                    { new Guid("adb50e8d-ae66-5caf-c8f0-d5ae36a6d373"), 0, "2a26c6c4-2788-4a00-af05-c5a17bffe128", "Brittany39@hotmail.com", false, false, null, null, null, "Tphjc4fk47", "607-414-2051", false, null, false, "Nelda.Vandervort" },
                    { new Guid("ae53c07d-e585-d5e1-2bad-66f3e40da6ff"), 0, "facc6def-2337-42ce-b901-3e7cb8914dfd", "Bo89@gmail.com", false, false, null, null, null, "dJ6Czl5M1d", "431.877.6321", false, null, false, "Benedict.Miller70" },
                    { new Guid("af90d80c-4bf8-45a2-14b9-dad72c66e305"), 0, "c93d87c6-2d60-4397-a39d-1e9c48a18a7a", "Karli_Watsica@hotmail.com", false, false, null, null, null, "9sO7XcAt5f", "(933) 683-0904", false, null, false, "Mckenna69" },
                    { new Guid("afd2c0fd-cd94-a1ab-1a27-faca46f673b4"), 0, "e9062963-7145-4c51-93d4-8e538d6b8f72", "Rick.Ratke@gmail.com", false, false, null, null, null, "_1OyO1fKc_", "259.397.2863 x4097", false, null, false, "Jonatan_Buckridge48" },
                    { new Guid("c03dcf69-f545-e02a-8f6d-3b7799ea9f90"), 0, "b3e1b239-db52-46e6-b96c-02dd04595910", "Montana_VonRueden@hotmail.com", false, false, null, null, null, "5ZgXc9t6lx", "816-560-9356 x2929", false, null, false, "Leonardo41" },
                    { new Guid("c0468e4f-3c79-0ed2-8478-f0f37ff02135"), 0, "3d9ad499-3ef3-4812-b61e-a8f217c4199f", "Anastasia42@yahoo.com", false, false, null, null, null, "DKQeXpBQvh", "(882) 208-9316 x968", false, null, false, "Carley.Grady" },
                    { new Guid("c18ece92-0453-9a62-249d-7c59edfca699"), 0, "95a3981c-30f4-4075-88c1-a9ca911ad61d", "Marisa.Kling13@yahoo.com", false, false, null, null, null, "OxHZjrEaSB", "561-336-4836 x360", false, null, false, "Eugenia_Mills" },
                    { new Guid("c4b18077-73c6-27a7-48a6-8817bbc820bd"), 0, "21f97391-4cd6-4a24-b0ec-38d7814ac42c", "Cullen40@gmail.com", false, false, null, null, null, "RhiBdagbPR", "1-845-762-8995 x4052", false, null, false, "Vicky.Kunze73" },
                    { new Guid("c9c7a328-4ec7-13f5-2574-6fdf80022530"), 0, "c9a23f2f-b5eb-4598-b912-1f3b84e34e59", "Ivah77@hotmail.com", false, false, null, null, null, "MxbYZCQcIF", "(719) 591-8421 x76587", false, null, false, "Noelia95" },
                    { new Guid("c9dcd9b5-3beb-c91d-bf94-b3d7ad91ba86"), 0, "dccb3067-fda6-47e2-bb7f-5700dda648a6", "Candelario.Denesik22@gmail.com", false, false, null, null, null, "N9blCPbplH", "920.986.6029", false, null, false, "Keaton.Schoen40" },
                    { new Guid("d905d62f-08a6-e7b3-c4e1-d16dfc8f8537"), 0, "7446890c-6845-48a4-a7d1-e2e61c20c8eb", "Pinkie32@yahoo.com", false, false, null, null, null, "7QrOnTmc6f", "798-870-4373", false, null, false, "Kirk58" },
                    { new Guid("e1c4d36d-35af-2876-52ec-5183ad05af30"), 0, "7588ea32-6ae0-45e0-a8cd-b69c67d0643a", "Brock.Hammes@hotmail.com", false, false, null, null, null, "O7mfPOmh25", "439.867.7527", false, null, false, "Joelle.Schowalter81" },
                    { new Guid("f4a8ff5e-cd16-1f77-748e-61f2a04ca7bc"), 0, "50a615f9-6154-4b29-bbce-313a4b82519a", "Lois90@yahoo.com", false, false, null, null, null, "OyeOKDpfsG", "(675) 503-8642 x84194", false, null, false, "Thurman_Towne39" },
                    { new Guid("f8b25c57-4478-4141-7ff5-c50e2a212d86"), 0, "14e5dc72-b948-4fbe-8f05-85026c2a980b", "Eveline_Effertz60@yahoo.com", false, false, null, null, null, "FPqB6TH2z8", "247-356-6520 x859", false, null, false, "Adrianna_McGlynn" },
                    { new Guid("fcadccb2-96ce-e247-d514-79cef1540f9d"), 0, "68ea7443-261f-410c-8f41-0908a2ea3b6d", "Collin_Lang@gmail.com", false, false, null, null, null, "7MCALKxHIY", "480-489-8401 x75629", false, null, false, "Tressa78" }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("346f5b73-e5ee-615b-1d67-45be53932778"), new Guid("0d60199b-904d-8105-f3b1-b489995c08e9") },
                    { new Guid("85d6efba-d60f-0172-91f1-090f9e09fee2"), new Guid("1676ae13-247f-863c-c97b-e14bfe2fc31e") },
                    { new Guid("7b358c8a-40cf-173f-c84c-9cc9536a8a85"), new Guid("230031c8-b1d8-546b-93a8-f81cb081c5bf") },
                    { new Guid("f5bf80da-e397-34b1-76f0-906608f6c511"), new Guid("2b933515-6dc4-95d3-e95e-9ffefcc87327") },
                    { new Guid("59556a4a-274c-5717-f4e4-fa9242c74036"), new Guid("2d51bb94-6b36-a78f-ccf6-4c36cbb9cebb") },
                    { new Guid("c4f73873-9eb9-d5f1-572c-6d3094626a55"), new Guid("3c3f9a72-1b65-b3ce-9a23-726d476704f3") },
                    { new Guid("4a8603e2-0438-49d8-55b7-514c0571d2bc"), new Guid("5e5e96b7-f133-a30a-36f1-c8cbcd2b398d") },
                    { new Guid("faee8cea-8813-5934-d186-d7865be917f7"), new Guid("684034ed-2fde-17ad-0dda-f7bd3eca5ca4") },
                    { new Guid("a9f5a33d-b01e-bf2c-1126-c4f6704ea8a5"), new Guid("6e5f33af-eeb1-62a0-7972-14d03e1dcd3e") },
                    { new Guid("a3d2a9fc-8026-c1e0-7fe0-e501a1d2137a"), new Guid("833f3cf1-acae-07b3-462a-77f9f99063dc") },
                    { new Guid("aabb6fb8-22c2-af5a-dfff-e4f694ea36c0"), new Guid("846b3280-8f50-fe85-a931-bdb592ef7506") },
                    { new Guid("4d945959-f7ac-88dc-d88c-a306aa321798"), new Guid("89563d90-d66e-7f8c-8edc-4088d8a5e607") },
                    { new Guid("082090a8-4838-4af4-ffc9-e64e678afdb7"), new Guid("9444e14f-2558-f3e6-e400-0db22ca1f167") },
                    { new Guid("9e7d44ec-b06b-4de1-a084-3f3926c86639"), new Guid("97e3c58f-421c-4887-9263-104a164cbfad") },
                    { new Guid("f24236de-90a5-c1d7-b5f8-75512207906e"), new Guid("9e78d36f-0878-86b9-1a3f-939eb63147f1") },
                    { new Guid("a82aabd5-3eaf-845a-b06b-b00e32816281"), new Guid("a8992b67-3835-60d4-f242-4c55aedd559a") },
                    { new Guid("3e917211-b06a-9650-60d6-8771a407e56b"), new Guid("b0aa54c1-f7cf-eb9f-d557-5cb98d59db91") },
                    { new Guid("022dd690-6067-c12b-8240-942fd8858fd1"), new Guid("be1f8c86-98a8-cbce-80fa-6612c4bc58a0") },
                    { new Guid("63909af8-0955-7c4c-c6b0-6ae2bee3e4b0"), new Guid("c289e28c-6afe-a337-753f-155da66ebfff") },
                    { new Guid("146949eb-24c9-337d-1239-2fb4f2d0ff20"), new Guid("ca039d74-e3ac-780b-00fe-e053f740c7c2") },
                    { new Guid("5cf0d979-d039-6a35-f8f6-92e0f59bd8db"), new Guid("d0bbbab0-5e91-7170-cc70-b48248465d09") },
                    { new Guid("f91511db-fdc5-f283-bd02-c7b89e8878a9"), new Guid("d33f936d-5623-1292-f7ee-e78e7933aab3") },
                    { new Guid("cf89d64e-f3be-30c8-d10b-9c11a986504d"), new Guid("d8107a13-b02b-cb95-5161-fca416cc38e6") },
                    { new Guid("e5f9b899-ec07-a65f-d44b-a7868c74918c"), new Guid("e4aae398-1937-cd9a-a9c5-f82532a9e362") },
                    { new Guid("9df502fb-c8b1-f021-155a-9b6d5551ba1e"), new Guid("ecdd69bb-801c-8674-00ab-82fbb993d0c7") },
                    { new Guid("80e4e246-c0d6-81d9-1371-a669e6f91281"), new Guid("f2924e34-fad9-3611-3e27-af1b37425eb1") },
                    { new Guid("6ef51afc-95e6-9dc2-1366-60febfc27a7b"), new Guid("f9f9a515-16e9-a868-bbdc-ba9d568ff55e") },
                    { new Guid("2759da22-c046-fd6c-c66f-24460126c58d"), new Guid("fae6e04e-77b7-925e-4712-537f0de53104") },
                    { new Guid("e8d1d5d1-b0dc-4d66-be3b-64c75e29b877"), new Guid("fd7f69fd-fd90-daf3-b85a-c43d6d44b6d8") },
                    { new Guid("566550bf-ce44-c98d-7bff-8bf8aa679028"), new Guid("fe91acc1-f8ec-0588-0e93-e01df7a87356") }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("4a628deb-8d52-b9ec-605a-88f707f9ec8c"), new Guid("0d60199b-904d-8105-f3b1-b489995c08e9") },
                    { new Guid("10cb8272-8fc9-31ed-c51d-cf3318d2be2d"), new Guid("1676ae13-247f-863c-c97b-e14bfe2fc31e") },
                    { new Guid("8d187872-35da-51fe-157a-56a86988b6b7"), new Guid("230031c8-b1d8-546b-93a8-f81cb081c5bf") },
                    { new Guid("9511c5f6-396c-fcc2-02b1-4f6fb2e77d78"), new Guid("2b933515-6dc4-95d3-e95e-9ffefcc87327") },
                    { new Guid("ccd004c5-9e28-9bd6-d08c-6ce433c0305b"), new Guid("2d51bb94-6b36-a78f-ccf6-4c36cbb9cebb") },
                    { new Guid("2ac7a2a4-91ab-1168-0e28-b0a471aec43c"), new Guid("3c3f9a72-1b65-b3ce-9a23-726d476704f3") },
                    { new Guid("e46eec5e-9d47-6571-f445-3887f7b708b4"), new Guid("5e5e96b7-f133-a30a-36f1-c8cbcd2b398d") },
                    { new Guid("08be4357-6f7e-5516-6f0d-c7db8f01f65a"), new Guid("684034ed-2fde-17ad-0dda-f7bd3eca5ca4") },
                    { new Guid("31e37187-bf61-d36e-3b46-86bfbef69d2b"), new Guid("6e5f33af-eeb1-62a0-7972-14d03e1dcd3e") },
                    { new Guid("60f86033-abf2-42f5-c9fc-9b6e7530a1ba"), new Guid("833f3cf1-acae-07b3-462a-77f9f99063dc") },
                    { new Guid("886c3eab-8664-0ded-0618-70df9515e4f5"), new Guid("846b3280-8f50-fe85-a931-bdb592ef7506") },
                    { new Guid("91bc04e3-f3f6-dfc3-eb1d-50e178559c1e"), new Guid("89563d90-d66e-7f8c-8edc-4088d8a5e607") },
                    { new Guid("2b681309-1363-e630-a2b8-72a090d20431"), new Guid("9444e14f-2558-f3e6-e400-0db22ca1f167") },
                    { new Guid("a383f980-311c-535d-4cf8-bf3cec6e5415"), new Guid("97e3c58f-421c-4887-9263-104a164cbfad") },
                    { new Guid("99065fc2-7e8f-cbd5-7d6c-c3fbd4ac0f3a"), new Guid("9e78d36f-0878-86b9-1a3f-939eb63147f1") },
                    { new Guid("52a615a1-6cb8-bfce-acb8-77fa62c89f44"), new Guid("a8992b67-3835-60d4-f242-4c55aedd559a") },
                    { new Guid("769674f9-1e58-05ee-3571-0b5131eb40d7"), new Guid("b0aa54c1-f7cf-eb9f-d557-5cb98d59db91") },
                    { new Guid("d4d35fbd-b662-3139-e5bc-19b0de85138c"), new Guid("be1f8c86-98a8-cbce-80fa-6612c4bc58a0") },
                    { new Guid("131348ea-c2c2-5256-9101-45d134817851"), new Guid("c289e28c-6afe-a337-753f-155da66ebfff") },
                    { new Guid("26743426-fdca-ec19-2730-6959c424bbcd"), new Guid("ca039d74-e3ac-780b-00fe-e053f740c7c2") },
                    { new Guid("d13db6ba-d13d-ee39-4f6c-74254c4f2065"), new Guid("d0bbbab0-5e91-7170-cc70-b48248465d09") },
                    { new Guid("33e37f51-7804-2805-c50e-292ff754914e"), new Guid("d33f936d-5623-1292-f7ee-e78e7933aab3") },
                    { new Guid("9935b1a0-54d3-8d34-3f16-6675bf349f48"), new Guid("d8107a13-b02b-cb95-5161-fca416cc38e6") },
                    { new Guid("a89ddd73-684d-d101-a34f-9c795d914f48"), new Guid("e4aae398-1937-cd9a-a9c5-f82532a9e362") },
                    { new Guid("9f0ca13b-ae6d-b46a-5065-8ccaebf81eea"), new Guid("ecdd69bb-801c-8674-00ab-82fbb993d0c7") },
                    { new Guid("759bd1e6-5d46-e5de-6bdd-dd15a28659b4"), new Guid("f2924e34-fad9-3611-3e27-af1b37425eb1") },
                    { new Guid("174cceb8-34ea-c8bd-4871-a56e358a279f"), new Guid("f9f9a515-16e9-a868-bbdc-ba9d568ff55e") },
                    { new Guid("dd1940db-f0ad-187c-3cc0-c6204aec9498"), new Guid("fae6e04e-77b7-925e-4712-537f0de53104") },
                    { new Guid("77bf61e6-4dbf-bc62-9c3e-03ed38a01316"), new Guid("fd7f69fd-fd90-daf3-b85a-c43d6d44b6d8") },
                    { new Guid("4fa22bc4-a756-5bc2-c37b-df3a84735f68"), new Guid("fe91acc1-f8ec-0588-0e93-e01df7a87356") }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "IsActive", "IsPaid", "Reserved", "UserId" },
                values: new object[,]
                {
                    { new Guid("088feb2d-51d7-a814-3bb0-6b22826070de"), false, false, true, new Guid("af90d80c-4bf8-45a2-14b9-dad72c66e305") },
                    { new Guid("0bf5d7a8-33c8-463a-7929-18d81ba3ce92"), true, true, false, new Guid("c9c7a328-4ec7-13f5-2574-6fdf80022530") },
                    { new Guid("0dd3de2c-84bf-eed1-cd34-94d528b0fd35"), true, false, false, new Guid("c03dcf69-f545-e02a-8f6d-3b7799ea9f90") },
                    { new Guid("104242f3-9361-16c9-831c-63eea95f067c"), false, false, true, new Guid("78d3f68f-3ba7-9fd1-ac7c-5b6f71226234") },
                    { new Guid("17263ae5-8e95-ce90-9cff-199adb3b820c"), true, false, true, new Guid("adb50e8d-ae66-5caf-c8f0-d5ae36a6d373") },
                    { new Guid("18004b78-b4d8-0fa8-0ff0-06f1d1e55422"), true, false, true, new Guid("8763dd78-a521-6cf8-a97f-564335f6311c") },
                    { new Guid("233970b3-5a92-7b19-d442-ffde3117b775"), true, true, true, new Guid("c0468e4f-3c79-0ed2-8478-f0f37ff02135") },
                    { new Guid("31c9bce6-f96a-e636-c110-5cd0b7e61ff7"), true, true, false, new Guid("f4a8ff5e-cd16-1f77-748e-61f2a04ca7bc") },
                    { new Guid("34e7da10-9dbe-b111-a0e7-7fa35eb0b1da"), false, true, false, new Guid("22a45f42-0db9-e089-7620-373a5c548a9a") },
                    { new Guid("3680624b-dfda-4dce-693c-5f8bd0af79d8"), true, true, true, new Guid("1b8ce57a-006c-5290-5400-2bebb972303e") },
                    { new Guid("404bbcb6-1130-525f-28aa-547c7fe9946c"), false, false, true, new Guid("8e9069f0-db9b-c38a-80d2-cb6ad13fa59a") },
                    { new Guid("40a7da69-ed85-0dcf-262f-2380fea815f4"), false, true, true, new Guid("8e9069f0-db9b-c38a-80d2-cb6ad13fa59a") },
                    { new Guid("4790f40d-bf8b-d874-b3a8-78f15ebce75b"), false, false, false, new Guid("f8b25c57-4478-4141-7ff5-c50e2a212d86") },
                    { new Guid("6277d7b0-7571-673e-4f72-7d62f8d3d567"), false, true, false, new Guid("8763dd78-a521-6cf8-a97f-564335f6311c") },
                    { new Guid("6627f908-016f-db02-b1eb-8e2ec89d67f9"), false, true, false, new Guid("7e20e9db-301c-881e-3923-ca59188eb2cb") },
                    { new Guid("7e6c9f56-07c2-1990-862c-f3cdaa34d913"), false, true, true, new Guid("3375b9d6-46ac-d681-cf12-16211992092f") },
                    { new Guid("8bb3a05c-b4d7-3f58-5067-317896de43ce"), false, true, true, new Guid("fcadccb2-96ce-e247-d514-79cef1540f9d") },
                    { new Guid("95f1648a-1390-f74b-80e3-ba3bf1486b71"), false, true, false, new Guid("8e9069f0-db9b-c38a-80d2-cb6ad13fa59a") },
                    { new Guid("b8405617-f297-3f85-4853-3af33e16fde0"), false, true, true, new Guid("a1fd4884-87cc-ca9f-990a-9bc15384ee92") },
                    { new Guid("b9d3684d-cc13-0216-f5e9-3c870768bd00"), true, false, true, new Guid("5b6d839c-485d-31f9-221a-0992eea96ba8") },
                    { new Guid("be3b2a9b-010c-62c9-85af-8784c425cb4f"), true, true, true, new Guid("a1013b4a-d587-45cb-7e49-be6d13376ae0") },
                    { new Guid("d5ebed4c-b7d8-23c8-db53-43a183d8cb18"), false, false, false, new Guid("d905d62f-08a6-e7b3-c4e1-d16dfc8f8537") },
                    { new Guid("d85a3231-3e63-870e-0151-b5bd1d26e421"), false, false, true, new Guid("c9dcd9b5-3beb-c91d-bf94-b3d7ad91ba86") },
                    { new Guid("d966483f-5d60-2c6d-850f-4f2ab0a43d04"), false, false, false, new Guid("7e20e9db-301c-881e-3923-ca59188eb2cb") },
                    { new Guid("e61e9b08-5a06-bf90-f54e-46822e18e19b"), false, true, true, new Guid("c0468e4f-3c79-0ed2-8478-f0f37ff02135") },
                    { new Guid("f093ca07-99c6-4de6-6ec7-da8574a4923d"), false, true, true, new Guid("8e9069f0-db9b-c38a-80d2-cb6ad13fa59a") },
                    { new Guid("f36d418b-0c67-41b3-0e43-cabf2c03b366"), true, false, false, new Guid("d905d62f-08a6-e7b3-c4e1-d16dfc8f8537") },
                    { new Guid("f729d6f8-488a-3324-d2cf-02787b7b2d44"), true, false, false, new Guid("f8b25c57-4478-4141-7ff5-c50e2a212d86") },
                    { new Guid("f72e676a-2e17-cc2d-a11e-324fad5c43e5"), true, true, false, new Guid("43908764-e2f0-3994-8603-ad18bcaa57c1") },
                    { new Guid("fe483473-8bbe-2ff5-e074-84491c0e8dd6"), true, true, true, new Guid("c4b18077-73c6-27a7-48a6-8817bbc820bd") }
                });

            migrationBuilder.InsertData(
                table: "Screenings",
                columns: new[] { "Id", "MovieId", "Price", "RoomId", "StartDateTime" },
                values: new object[,]
                {
                    { new Guid("0d745786-c2c8-2600-b28d-bfd3f6be88ba"), new Guid("e4aae398-1937-cd9a-a9c5-f82532a9e362"), 0.80170466454177525, new Guid("4c9f5b65-7f8a-7efd-ebb3-f2fcc5ddeabf"), new DateTime(2024, 4, 24, 23, 34, 5, 50, DateTimeKind.Unspecified).AddTicks(458) },
                    { new Guid("1edd184e-f1d3-51a6-9ea6-fa25a3be5b5d"), new Guid("89563d90-d66e-7f8c-8edc-4088d8a5e607"), 0.11000126122109388, new Guid("d2331a5e-9200-bbbc-3941-2c1c791e39a4"), new DateTime(2024, 5, 13, 20, 54, 44, 248, DateTimeKind.Unspecified).AddTicks(3466) },
                    { new Guid("2046c6a7-c067-e6fd-d9e3-2cec6bcb9cc7"), new Guid("1676ae13-247f-863c-c97b-e14bfe2fc31e"), 0.99053306481623937, new Guid("b67ae0a5-1288-c191-7a48-5c670162f488"), new DateTime(2024, 7, 9, 5, 18, 8, 46, DateTimeKind.Unspecified).AddTicks(3538) },
                    { new Guid("2482ded3-9a39-af55-2cb3-9e90f1eede76"), new Guid("846b3280-8f50-fe85-a931-bdb592ef7506"), 0.75476199944130973, new Guid("c9245a8e-8281-28c6-b418-ea12b7d57399"), new DateTime(2024, 6, 21, 22, 48, 33, 919, DateTimeKind.Unspecified).AddTicks(7609) },
                    { new Guid("36e39a3f-4d7d-8534-776d-bdd9595b039a"), new Guid("846b3280-8f50-fe85-a931-bdb592ef7506"), 0.81368760205189605, new Guid("e2a565e4-3373-e06a-cff5-1ab63b53cb28"), new DateTime(2024, 4, 26, 13, 47, 4, 837, DateTimeKind.Unspecified).AddTicks(7602) },
                    { new Guid("3a9256ce-7c36-9828-ac2c-2a8b5f355592"), new Guid("684034ed-2fde-17ad-0dda-f7bd3eca5ca4"), 0.84270615710236774, new Guid("266cbf9a-3286-2647-e7d5-806bc0c3ee1c"), new DateTime(2024, 5, 10, 11, 50, 2, 734, DateTimeKind.Unspecified).AddTicks(6933) },
                    { new Guid("4d5ed225-42aa-871a-a2db-7443c2e318cd"), new Guid("be1f8c86-98a8-cbce-80fa-6612c4bc58a0"), 0.065027703135644987, new Guid("2d7b0498-a5ec-b462-3630-4cb2ad5fd5a0"), new DateTime(2024, 6, 16, 1, 9, 16, 282, DateTimeKind.Unspecified).AddTicks(7663) },
                    { new Guid("4f5137cc-116a-19db-70eb-fbf9926bb9b5"), new Guid("1676ae13-247f-863c-c97b-e14bfe2fc31e"), 0.21535744593327288, new Guid("af3a5cd8-ac55-0622-b16a-8fc8aa03dddf"), new DateTime(2024, 5, 17, 5, 29, 8, 145, DateTimeKind.Unspecified).AddTicks(1323) },
                    { new Guid("4fcd2bd0-dbc8-8178-4bae-726d0e146368"), new Guid("6e5f33af-eeb1-62a0-7972-14d03e1dcd3e"), 0.022293634488625869, new Guid("266cbf9a-3286-2647-e7d5-806bc0c3ee1c"), new DateTime(2024, 6, 12, 17, 31, 40, 669, DateTimeKind.Unspecified).AddTicks(3279) },
                    { new Guid("65a0d01a-ae96-1bc2-d063-b9083bbee8cc"), new Guid("f9f9a515-16e9-a868-bbdc-ba9d568ff55e"), 0.71917314851532732, new Guid("b67ae0a5-1288-c191-7a48-5c670162f488"), new DateTime(2024, 4, 16, 3, 35, 1, 372, DateTimeKind.Unspecified).AddTicks(7149) },
                    { new Guid("6646fb5a-8a0a-2309-85a0-83b1e45ff414"), new Guid("f9f9a515-16e9-a868-bbdc-ba9d568ff55e"), 0.48207555919387024, new Guid("6dd79a1b-4c46-9840-d1d2-be471412ffd3"), new DateTime(2024, 6, 23, 15, 59, 56, 734, DateTimeKind.Unspecified).AddTicks(2287) },
                    { new Guid("67600984-2658-0c07-2d5c-facf56e55e5e"), new Guid("5e5e96b7-f133-a30a-36f1-c8cbcd2b398d"), 0.75762235263151745, new Guid("a168df14-1c42-45bb-6bbe-1a9c762956a7"), new DateTime(2024, 7, 6, 20, 43, 11, 612, DateTimeKind.Unspecified).AddTicks(8760) },
                    { new Guid("6f924018-04bc-fe07-0a86-fa27704a54a3"), new Guid("e4aae398-1937-cd9a-a9c5-f82532a9e362"), 0.10990113233933607, new Guid("2ba399c7-07dd-cde9-dfd9-a654811ebe23"), new DateTime(2024, 5, 23, 18, 46, 59, 191, DateTimeKind.Unspecified).AddTicks(4802) },
                    { new Guid("70528493-2046-8c5e-9a94-52e5343759f2"), new Guid("9e78d36f-0878-86b9-1a3f-939eb63147f1"), 0.81466190939618288, new Guid("4c9f5b65-7f8a-7efd-ebb3-f2fcc5ddeabf"), new DateTime(2024, 6, 4, 18, 51, 27, 461, DateTimeKind.Unspecified).AddTicks(3919) },
                    { new Guid("82c98e96-ef66-62b7-5add-26cf32bb61d7"), new Guid("5e5e96b7-f133-a30a-36f1-c8cbcd2b398d"), 0.20936843917559189, new Guid("08191363-ba6e-7bf5-960e-78b2b8a6d280"), new DateTime(2024, 6, 10, 23, 16, 25, 61, DateTimeKind.Unspecified).AddTicks(7629) },
                    { new Guid("8b352acd-cb50-12b7-888b-994decebdc96"), new Guid("e4aae398-1937-cd9a-a9c5-f82532a9e362"), 0.85270139702889625, new Guid("a168df14-1c42-45bb-6bbe-1a9c762956a7"), new DateTime(2024, 6, 16, 11, 43, 56, 633, DateTimeKind.Unspecified).AddTicks(6594) },
                    { new Guid("a6b4e8ba-39c6-fe0a-5703-8162ffe81e95"), new Guid("e4aae398-1937-cd9a-a9c5-f82532a9e362"), 0.48994141045795259, new Guid("67ba2bb9-1936-97d9-8b43-552b1e8235da"), new DateTime(2024, 4, 15, 19, 16, 23, 711, DateTimeKind.Unspecified).AddTicks(9329) },
                    { new Guid("ac27c6fd-68da-6fc6-4ab7-55cb257c58ca"), new Guid("89563d90-d66e-7f8c-8edc-4088d8a5e607"), 0.84616798875605681, new Guid("b9ab5cd3-e27f-6411-f674-a7b09c4555dc"), new DateTime(2024, 5, 17, 0, 7, 51, 222, DateTimeKind.Unspecified).AddTicks(9771) },
                    { new Guid("b0c1f202-64f0-5422-b67d-4bf75fbcb08e"), new Guid("6e5f33af-eeb1-62a0-7972-14d03e1dcd3e"), 0.39192407841654686, new Guid("c9245a8e-8281-28c6-b418-ea12b7d57399"), new DateTime(2024, 6, 9, 0, 20, 48, 254, DateTimeKind.Unspecified).AddTicks(5753) },
                    { new Guid("b6965c17-9647-7093-b86b-0a2cb21d3ca0"), new Guid("d8107a13-b02b-cb95-5161-fca416cc38e6"), 0.32968384777578164, new Guid("08191363-ba6e-7bf5-960e-78b2b8a6d280"), new DateTime(2024, 5, 28, 23, 11, 50, 490, DateTimeKind.Unspecified).AddTicks(2869) },
                    { new Guid("b8ad79c6-2746-9a6a-4f26-d41967f2719e"), new Guid("ca039d74-e3ac-780b-00fe-e053f740c7c2"), 0.71396567155771984, new Guid("af3a5cd8-ac55-0622-b16a-8fc8aa03dddf"), new DateTime(2024, 6, 30, 2, 13, 9, 947, DateTimeKind.Unspecified).AddTicks(6266) },
                    { new Guid("ba9e901b-5d59-4ce2-6541-e01f75ba7438"), new Guid("3c3f9a72-1b65-b3ce-9a23-726d476704f3"), 0.9496271444168507, new Guid("59808c8c-ca5e-75ee-9d48-21b405d6fe6e"), new DateTime(2024, 7, 6, 4, 41, 46, 568, DateTimeKind.Unspecified).AddTicks(7567) },
                    { new Guid("be447d74-a79d-1d69-a5ba-9077f5b6b53d"), new Guid("fae6e04e-77b7-925e-4712-537f0de53104"), 0.70862443467842673, new Guid("2d7b0498-a5ec-b462-3630-4cb2ad5fd5a0"), new DateTime(2024, 6, 17, 22, 29, 39, 993, DateTimeKind.Unspecified).AddTicks(9999) },
                    { new Guid("c2c46ede-c522-5b16-be6e-ff4b54c15a67"), new Guid("6e5f33af-eeb1-62a0-7972-14d03e1dcd3e"), 0.94567282197908853, new Guid("c9245a8e-8281-28c6-b418-ea12b7d57399"), new DateTime(2024, 7, 4, 18, 47, 3, 664, DateTimeKind.Unspecified).AddTicks(4596) },
                    { new Guid("c498335d-c613-8812-25a8-babd48e4dfef"), new Guid("fe91acc1-f8ec-0588-0e93-e01df7a87356"), 0.67703927427301347, new Guid("1de9e739-0104-dc9c-a77e-3d3d266c20dd"), new DateTime(2024, 5, 2, 5, 23, 52, 765, DateTimeKind.Unspecified).AddTicks(2912) },
                    { new Guid("cc9440ae-c1fc-2868-ff28-3df51406a34f"), new Guid("97e3c58f-421c-4887-9263-104a164cbfad"), 0.64463906667581905, new Guid("ec848c17-a2fd-e941-d331-632f4e3e5610"), new DateTime(2024, 5, 4, 12, 27, 19, 320, DateTimeKind.Unspecified).AddTicks(6802) },
                    { new Guid("d30f8bb3-2f76-dca8-335a-95c2449c954c"), new Guid("9e78d36f-0878-86b9-1a3f-939eb63147f1"), 0.19675378689534706, new Guid("a353c63b-65ec-daa7-1d3c-10317cd20d48"), new DateTime(2024, 5, 1, 17, 10, 27, 677, DateTimeKind.Unspecified).AddTicks(3703) },
                    { new Guid("db00668e-9227-7899-6a93-103c00a32da0"), new Guid("d33f936d-5623-1292-f7ee-e78e7933aab3"), 0.8833590692819151, new Guid("6dd79a1b-4c46-9840-d1d2-be471412ffd3"), new DateTime(2024, 7, 6, 9, 4, 18, 627, DateTimeKind.Unspecified).AddTicks(9843) },
                    { new Guid("db792c21-a58c-3c1f-52ef-203953cbee92"), new Guid("c289e28c-6afe-a337-753f-155da66ebfff"), 0.24168551305717012, new Guid("01668f2d-b644-238c-0eb1-fff5fb68d789"), new DateTime(2024, 4, 15, 1, 26, 24, 708, DateTimeKind.Unspecified).AddTicks(8516) },
                    { new Guid("eafa23f8-70d5-716f-7ad1-351612eabc5e"), new Guid("2d51bb94-6b36-a78f-ccf6-4c36cbb9cebb"), 0.63121290904052219, new Guid("a353c63b-65ec-daa7-1d3c-10317cd20d48"), new DateTime(2024, 6, 30, 17, 13, 0, 35, DateTimeKind.Unspecified).AddTicks(7541) }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Number", "RoomId", "Row" },
                values: new object[,]
                {
                    { new Guid("04d6a8c7-c5ef-b6e1-9fd7-9d7433891fa1"), 816130579, new Guid("e2a565e4-3373-e06a-cff5-1ab63b53cb28"), -1572442505 },
                    { new Guid("05158ccb-c584-f72a-3660-2d8cd42aa8b6"), 1319680670, new Guid("17dc7664-7286-adc1-4a28-4345701edbc9"), -143271828 },
                    { new Guid("0bc90fe3-d047-2e5a-83b4-331cceff4a21"), 1686538477, new Guid("6250feeb-a7b0-3b0c-30f2-9ca5e6a01aa2"), 1494205037 },
                    { new Guid("21d0fb52-adc2-6419-f0ed-b635b349dbdb"), -392080038, new Guid("3b655625-224d-afa7-2300-c7cb1ce17ae7"), 730667533 },
                    { new Guid("364e859a-56fd-2b57-9072-24e2ac6159c4"), -1230027936, new Guid("01668f2d-b644-238c-0eb1-fff5fb68d789"), -517757663 },
                    { new Guid("3c26fc17-da96-4344-b411-d6eea9914b05"), 1735156829, new Guid("ec848c17-a2fd-e941-d331-632f4e3e5610"), -1944369156 },
                    { new Guid("4a27bd6c-6a64-272a-64ca-eb5b5553da45"), 1254129457, new Guid("a9a5c618-cff3-f24a-131c-c5197ff58cb4"), 511676207 },
                    { new Guid("4b56fb38-71bd-2dd6-3f03-610c96867185"), 1404777632, new Guid("266cbf9a-3286-2647-e7d5-806bc0c3ee1c"), -103301713 },
                    { new Guid("574ad8ee-28c4-539b-8160-a928ee6891e1"), -369782348, new Guid("ec848c17-a2fd-e941-d331-632f4e3e5610"), 599536610 },
                    { new Guid("6423121c-6075-5b29-9564-5d8dcadc7aad"), 408577376, new Guid("e2a565e4-3373-e06a-cff5-1ab63b53cb28"), 331217612 },
                    { new Guid("656c90c2-d791-9f55-e9fb-815df4d26c4e"), -1417479186, new Guid("b67ae0a5-1288-c191-7a48-5c670162f488"), -1979233771 },
                    { new Guid("72129c87-2163-5d55-fc9b-60c12f1667b8"), -786199078, new Guid("d2331a5e-9200-bbbc-3941-2c1c791e39a4"), 380828099 },
                    { new Guid("760932a8-bfd3-e70a-1d46-36c0d28f4730"), 934451949, new Guid("08191363-ba6e-7bf5-960e-78b2b8a6d280"), -1942262464 },
                    { new Guid("7ce5d841-cf35-b120-fd6a-11cf998d68b4"), 725052717, new Guid("4d6ed134-bc58-685e-857e-09a549b95a7f"), 915502135 },
                    { new Guid("86709eff-7041-30fc-89d2-4c9f935c88d0"), 1293277078, new Guid("d87374e9-3e1d-1714-da1d-7dddc8d599b7"), -205303581 },
                    { new Guid("982a51fa-b426-a3bb-8178-bda1fcc168b6"), -1157909999, new Guid("266cbf9a-3286-2647-e7d5-806bc0c3ee1c"), -965769843 },
                    { new Guid("9c8507ab-3006-84df-2d6d-bf02be36514c"), -1756718873, new Guid("59808c8c-ca5e-75ee-9d48-21b405d6fe6e"), -728437549 },
                    { new Guid("a94f250f-0845-9361-6188-cc02f5c25f59"), -726693579, new Guid("24544eb9-1dbc-c418-7c53-5c252c31675f"), -149958580 },
                    { new Guid("c7e5b726-ca6d-3ac7-c230-964967ca593e"), 1719500722, new Guid("a168df14-1c42-45bb-6bbe-1a9c762956a7"), -1245506649 },
                    { new Guid("cdf908d2-63c3-3e6a-1c16-5d73df67c19a"), 475200435, new Guid("1de9e739-0104-dc9c-a77e-3d3d266c20dd"), -390998613 },
                    { new Guid("ceda2854-8ac7-b6a2-dc16-1e5fed80e5a4"), 64898816, new Guid("6dd79a1b-4c46-9840-d1d2-be471412ffd3"), 1857468232 },
                    { new Guid("d0723fee-7ebc-5f48-0f33-a184bb1f4153"), 194320242, new Guid("2ba399c7-07dd-cde9-dfd9-a654811ebe23"), 1429594265 },
                    { new Guid("d5104e06-58f3-28be-5cd1-42fb7880d16a"), 397267264, new Guid("c9245a8e-8281-28c6-b418-ea12b7d57399"), 315476783 },
                    { new Guid("d909c9b4-8938-8fb7-da95-e397a8baf4d7"), -1273664886, new Guid("b9ab5cd3-e27f-6411-f674-a7b09c4555dc"), 1189469077 },
                    { new Guid("d9f34ac2-cbcf-17b4-78e6-e372e1294462"), -1485480109, new Guid("24544eb9-1dbc-c418-7c53-5c252c31675f"), 420326089 },
                    { new Guid("e527a988-a5b7-194f-c10d-0a8bfe9ba330"), -1640501101, new Guid("01668f2d-b644-238c-0eb1-fff5fb68d789"), 1599094944 },
                    { new Guid("e919e49e-4d2f-54e4-a19e-4eb0fa7ab8ef"), 890522548, new Guid("2ba399c7-07dd-cde9-dfd9-a654811ebe23"), 1750353009 },
                    { new Guid("f06a5136-b0ee-fe56-04f9-a522e17a9514"), 976745667, new Guid("6250feeb-a7b0-3b0c-30f2-9ca5e6a01aa2"), -324927413 },
                    { new Guid("f63e37e1-8c06-7701-49c2-1b6e9cae3c06"), -1945504384, new Guid("6250feeb-a7b0-3b0c-30f2-9ca5e6a01aa2"), 886502709 },
                    { new Guid("f974bef7-c940-1bda-638e-212beae6bf88"), 626317836, new Guid("4d6ed134-bc58-685e-857e-09a549b95a7f"), 448343452 }
                });

            migrationBuilder.InsertData(
                table: "ReservedSeats",
                columns: new[] { "Id", "ReservationId", "ScreeningId", "SeatId" },
                values: new object[,]
                {
                    { new Guid("023ad67c-fcca-fa26-9471-272e59b69929"), new Guid("f36d418b-0c67-41b3-0e43-cabf2c03b366"), new Guid("db00668e-9227-7899-6a93-103c00a32da0"), new Guid("e919e49e-4d2f-54e4-a19e-4eb0fa7ab8ef") },
                    { new Guid("08ebadc8-2533-b823-ac56-788e640f1cc3"), new Guid("104242f3-9361-16c9-831c-63eea95f067c"), new Guid("70528493-2046-8c5e-9a94-52e5343759f2"), new Guid("e919e49e-4d2f-54e4-a19e-4eb0fa7ab8ef") },
                    { new Guid("0f00fc9e-fdaf-d17b-7f29-c5f05cd933cd"), new Guid("7e6c9f56-07c2-1990-862c-f3cdaa34d913"), new Guid("0d745786-c2c8-2600-b28d-bfd3f6be88ba"), new Guid("4a27bd6c-6a64-272a-64ca-eb5b5553da45") },
                    { new Guid("1243aa8c-d2f2-ba01-880e-9b2526d80cdd"), new Guid("31c9bce6-f96a-e636-c110-5cd0b7e61ff7"), new Guid("eafa23f8-70d5-716f-7ad1-351612eabc5e"), new Guid("ceda2854-8ac7-b6a2-dc16-1e5fed80e5a4") },
                    { new Guid("1708fc47-96bd-a155-e161-f14121081121"), new Guid("b9d3684d-cc13-0216-f5e9-3c870768bd00"), new Guid("4d5ed225-42aa-871a-a2db-7443c2e318cd"), new Guid("ceda2854-8ac7-b6a2-dc16-1e5fed80e5a4") },
                    { new Guid("1bc48004-bbd8-647a-4f1b-de3f4eeeab91"), new Guid("8bb3a05c-b4d7-3f58-5067-317896de43ce"), new Guid("67600984-2658-0c07-2d5c-facf56e55e5e"), new Guid("a94f250f-0845-9361-6188-cc02f5c25f59") },
                    { new Guid("1fb48424-d4a9-e607-db47-b94db087dd25"), new Guid("18004b78-b4d8-0fa8-0ff0-06f1d1e55422"), new Guid("ba9e901b-5d59-4ce2-6541-e01f75ba7438"), new Guid("656c90c2-d791-9f55-e9fb-815df4d26c4e") },
                    { new Guid("1fea5a78-4636-73be-a653-951a11b4b890"), new Guid("f729d6f8-488a-3324-d2cf-02787b7b2d44"), new Guid("4d5ed225-42aa-871a-a2db-7443c2e318cd"), new Guid("86709eff-7041-30fc-89d2-4c9f935c88d0") },
                    { new Guid("27d972a7-98fe-238f-f2ff-f00bb876db9a"), new Guid("31c9bce6-f96a-e636-c110-5cd0b7e61ff7"), new Guid("d30f8bb3-2f76-dca8-335a-95c2449c954c"), new Guid("760932a8-bfd3-e70a-1d46-36c0d28f4730") },
                    { new Guid("29300eaf-0b28-b843-6c1c-3ccdd94d596f"), new Guid("0dd3de2c-84bf-eed1-cd34-94d528b0fd35"), new Guid("0d745786-c2c8-2600-b28d-bfd3f6be88ba"), new Guid("e527a988-a5b7-194f-c10d-0a8bfe9ba330") },
                    { new Guid("30f19b78-6f5d-4393-60e5-72e793b7d5b2"), new Guid("18004b78-b4d8-0fa8-0ff0-06f1d1e55422"), new Guid("ac27c6fd-68da-6fc6-4ab7-55cb257c58ca"), new Guid("04d6a8c7-c5ef-b6e1-9fd7-9d7433891fa1") },
                    { new Guid("3a9cf7be-a5d2-8dc3-6f7a-0842bc987ef6"), new Guid("18004b78-b4d8-0fa8-0ff0-06f1d1e55422"), new Guid("d30f8bb3-2f76-dca8-335a-95c2449c954c"), new Guid("364e859a-56fd-2b57-9072-24e2ac6159c4") },
                    { new Guid("43bcd8c1-244b-39ff-3cc3-c3f104943e3c"), new Guid("3680624b-dfda-4dce-693c-5f8bd0af79d8"), new Guid("3a9256ce-7c36-9828-ac2c-2a8b5f355592"), new Guid("982a51fa-b426-a3bb-8178-bda1fcc168b6") },
                    { new Guid("496a6c6b-c170-a43f-0a7f-df28f405d837"), new Guid("95f1648a-1390-f74b-80e3-ba3bf1486b71"), new Guid("67600984-2658-0c07-2d5c-facf56e55e5e"), new Guid("d5104e06-58f3-28be-5cd1-42fb7880d16a") },
                    { new Guid("5274c576-16b1-388b-4cc6-b0f823a57424"), new Guid("18004b78-b4d8-0fa8-0ff0-06f1d1e55422"), new Guid("be447d74-a79d-1d69-a5ba-9077f5b6b53d"), new Guid("6423121c-6075-5b29-9564-5d8dcadc7aad") },
                    { new Guid("5d9e08ea-d916-1c3e-6cd7-44607ac1bad0"), new Guid("34e7da10-9dbe-b111-a0e7-7fa35eb0b1da"), new Guid("36e39a3f-4d7d-8534-776d-bdd9595b039a"), new Guid("c7e5b726-ca6d-3ac7-c230-964967ca593e") },
                    { new Guid("7fcd6f8c-5e59-d8b5-4fad-df2534d6b239"), new Guid("3680624b-dfda-4dce-693c-5f8bd0af79d8"), new Guid("db00668e-9227-7899-6a93-103c00a32da0"), new Guid("ceda2854-8ac7-b6a2-dc16-1e5fed80e5a4") },
                    { new Guid("8af5986f-dbb3-7d27-eab0-c0658537c9d0"), new Guid("e61e9b08-5a06-bf90-f54e-46822e18e19b"), new Guid("cc9440ae-c1fc-2868-ff28-3df51406a34f"), new Guid("d0723fee-7ebc-5f48-0f33-a184bb1f4153") },
                    { new Guid("90304400-bbb6-b437-37a0-26742c3a483f"), new Guid("f72e676a-2e17-cc2d-a11e-324fad5c43e5"), new Guid("70528493-2046-8c5e-9a94-52e5343759f2"), new Guid("3c26fc17-da96-4344-b411-d6eea9914b05") },
                    { new Guid("9c428e45-9f52-bac5-5333-eae2fd32e3e5"), new Guid("f729d6f8-488a-3324-d2cf-02787b7b2d44"), new Guid("d30f8bb3-2f76-dca8-335a-95c2449c954c"), new Guid("656c90c2-d791-9f55-e9fb-815df4d26c4e") },
                    { new Guid("a56a84a2-fd85-7fd7-27d5-d20425a3128e"), new Guid("088feb2d-51d7-a814-3bb0-6b22826070de"), new Guid("a6b4e8ba-39c6-fe0a-5703-8162ffe81e95"), new Guid("f974bef7-c940-1bda-638e-212beae6bf88") },
                    { new Guid("b2d80f35-5f10-b111-30cf-be6dab55f049"), new Guid("b9d3684d-cc13-0216-f5e9-3c870768bd00"), new Guid("b0c1f202-64f0-5422-b67d-4bf75fbcb08e"), new Guid("d9f34ac2-cbcf-17b4-78e6-e372e1294462") },
                    { new Guid("b805e235-19f9-4bb8-6d37-8b7885af1642"), new Guid("f093ca07-99c6-4de6-6ec7-da8574a4923d"), new Guid("db792c21-a58c-3c1f-52ef-203953cbee92"), new Guid("0bc90fe3-d047-2e5a-83b4-331cceff4a21") },
                    { new Guid("c0505f0a-5f3a-da17-0989-a25ac8da18a2"), new Guid("95f1648a-1390-f74b-80e3-ba3bf1486b71"), new Guid("cc9440ae-c1fc-2868-ff28-3df51406a34f"), new Guid("86709eff-7041-30fc-89d2-4c9f935c88d0") },
                    { new Guid("c574783e-5945-078e-bc29-6aec12ab849a"), new Guid("40a7da69-ed85-0dcf-262f-2380fea815f4"), new Guid("67600984-2658-0c07-2d5c-facf56e55e5e"), new Guid("9c8507ab-3006-84df-2d6d-bf02be36514c") },
                    { new Guid("d28ae2ff-9d64-1fac-b469-86febc802687"), new Guid("d5ebed4c-b7d8-23c8-db53-43a183d8cb18"), new Guid("2046c6a7-c067-e6fd-d9e3-2cec6bcb9cc7"), new Guid("9c8507ab-3006-84df-2d6d-bf02be36514c") },
                    { new Guid("d4162db2-242e-c081-0e1e-5b9a021b8953"), new Guid("104242f3-9361-16c9-831c-63eea95f067c"), new Guid("ba9e901b-5d59-4ce2-6541-e01f75ba7438"), new Guid("d909c9b4-8938-8fb7-da95-e397a8baf4d7") },
                    { new Guid("dc6719bd-c76e-1f5f-d52d-c89d7d8b1049"), new Guid("b9d3684d-cc13-0216-f5e9-3c870768bd00"), new Guid("0d745786-c2c8-2600-b28d-bfd3f6be88ba"), new Guid("d9f34ac2-cbcf-17b4-78e6-e372e1294462") },
                    { new Guid("eae35c32-ed26-39e2-91e1-dd35455cac2d"), new Guid("7e6c9f56-07c2-1990-862c-f3cdaa34d913"), new Guid("65a0d01a-ae96-1bc2-d063-b9083bbee8cc"), new Guid("f63e37e1-8c06-7701-49c2-1b6e9cae3c06") },
                    { new Guid("f6d07bcb-aa24-c778-c2ec-5e41b07e14cc"), new Guid("3680624b-dfda-4dce-693c-5f8bd0af79d8"), new Guid("4fcd2bd0-dbc8-8178-4bae-726d0e146368"), new Guid("f06a5136-b0ee-fe56-04f9-a522e17a9514") }
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
