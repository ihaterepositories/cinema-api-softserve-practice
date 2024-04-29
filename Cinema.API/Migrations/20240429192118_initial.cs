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
                    ScreeningStart = table.Column<TimeOnly>(type: "TEXT", nullable: false)
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
                    { new Guid("05b2496d-4b97-5d66-a4f4-1589711598fb"), "Ut praesentium doloribus consequatur aut sit atque dicta sunt.\nFuga mollitia quia.\nAmet perferendis magni nam explicabo.\nDistinctio iusto praesentium doloremque laborum quos culpa rem.\nQui placeat voluptas neque qui reiciendis quae ea sed.\nA ut velit.", "Lora Bauch", "http://vella.com" },
                    { new Guid("0fa6342a-f7b5-7274-e60d-e9240daf336d"), "Ut quaerat architecto sed quis illo sit aut debitis dignissimos.\nEnim dolorem qui earum.\nEaque placeat doloremque omnis et nobis tempore eum.", "Darian Reinger", "https://myrl.net" },
                    { new Guid("1053d85b-216d-9cf5-4d13-c39be47b2f72"), "Voluptatem accusamus aut ea ut earum similique minima.\nConsequatur qui eos porro et dolore aut molestiae repellat.\nLaborum odio sint rerum perferendis deleniti in.", "Austin Boehm", "https://marcelle.com" },
                    { new Guid("1f0ad875-3db2-655a-d520-53ee05aa03b4"), "Labore quo soluta voluptate et fugit tenetur odio quis quisquam.\nSequi natus cupiditate tenetur natus exercitationem doloribus.\nEt sit aut.\nVelit illum accusantium quasi sapiente minima ullam quia.\nVoluptas est pariatur unde autem odit et odit eos perspiciatis.\nNihil aut dolorum et.", "Walker Kuhic", "https://courtney.net" },
                    { new Guid("24d00437-ebdb-5d94-79b1-64b9c886f803"), "Exercitationem ratione molestiae quis et aspernatur est rerum ad voluptas.\nFacere explicabo delectus eveniet molestiae omnis ipsa praesentium.\nRepellendus iusto ipsum et quis et nihil.\nEt aliquid et sapiente non sint amet laborum optio.\nQuidem assumenda hic.\nVoluptas blanditiis est excepturi maxime libero non excepturi perspiciatis.", "Thad Jacobs", "http://rickey.net" },
                    { new Guid("258b488c-ff1d-2f7a-6683-ac21a784240f"), "Aut qui aut sit at odio et exercitationem totam et.\nQuae ipsa qui dicta molestiae unde facere commodi deleniti.\nAnimi illum rerum deserunt architecto cupiditate omnis tempora expedita.\nAccusamus numquam fugit veniam velit iste eius.\nPraesentium et fugit assumenda qui suscipit quos quis id.", "Presley Schaefer", "https://maida.name" },
                    { new Guid("3cd64297-02fb-acf2-ed5f-44301d3bf0bd"), "Vitae eum perferendis.\nVeritatis autem et corporis explicabo itaque dolorum velit ullam.\nCulpa ducimus tenetur sit eum.\nEt beatae cumque est repellat nemo.\nFuga ab veniam voluptate unde.\nNecessitatibus ut enim dolores.", "Alexie Parker", "https://colten.name" },
                    { new Guid("410bc498-59e2-abe2-c266-897e09fef780"), "Labore accusantium commodi.\nNesciunt unde omnis nisi veniam.\nEt qui voluptas illo.", "Amber Kling", "http://gus.name" },
                    { new Guid("474552fe-7778-2f52-a1b7-fefc8e63b5fd"), "Et exercitationem nihil error.\nSunt debitis et tempora sed architecto officiis suscipit dolor.\nEius assumenda blanditiis libero et qui et exercitationem.\nNostrum rerum iste nostrum et reiciendis.\nTenetur consectetur unde omnis quasi repellat aut quo et.\nOfficia tenetur non culpa laudantium quasi dignissimos.", "Flossie Crist", "http://christelle.biz" },
                    { new Guid("542451ec-3906-95c7-204d-2c5f6519b52f"), "Debitis eligendi suscipit atque.\nQuibusdam atque voluptatem ut nulla soluta itaque hic voluptas optio.\nEt consequuntur error.\nSint dolorem cumque similique optio.\nQui est cumque alias adipisci amet consequatur aliquid.\nConsectetur iusto beatae commodi quod.", "Eloise Kris", "https://baby.name" },
                    { new Guid("65e17b23-7648-af09-f1e6-c16640060fed"), "Dolorum consequatur esse voluptate.\nIllum vel pariatur enim blanditiis officiis.", "Rashawn Macejkovic", "https://lukas.org" },
                    { new Guid("71757008-286e-b029-7484-a90072c7d2e3"), "Non quod sit esse rerum reiciendis facere tempore corporis.\nMagnam tempore et animi possimus porro autem sit distinctio veritatis.\nAut mollitia earum et ex quia officiis explicabo soluta.", "Jeff Veum", "https://antoinette.biz" },
                    { new Guid("82608cf2-2bfd-15db-2f96-8883d60cd483"), "Blanditiis autem enim veritatis.\nNulla harum ut perferendis et quia dicta et perspiciatis nobis.\nHarum minus libero.\nVoluptates maxime natus pariatur.\nCorrupti repellat sunt soluta itaque animi nostrum aliquam qui in.\nOdio et sunt maiores omnis.", "Raoul Ortiz", "http://danny.net" },
                    { new Guid("8af418f7-c702-d12c-e426-1e8f5c2e4a37"), "Voluptatem error enim architecto non accusantium pariatur est.\nEligendi eaque incidunt eius occaecati sit amet dicta.\nSunt nihil omnis saepe magni.\nEt amet illo quia dolore omnis.\nFuga quasi facilis amet recusandae quam aut et eveniet.", "Bo Donnelly", "http://deshawn.org" },
                    { new Guid("9a1d547e-5c57-9497-aa7f-51b8703035c6"), "Hic animi porro odit et earum sit illum suscipit et.\nA ut aliquam aut ipsum iste vel et quo.\nOptio modi ipsum ducimus eos est necessitatibus enim fugit deleniti.\nDolores esse dignissimos aperiam et distinctio sit natus.", "Darrin Steuber", "https://josiane.name" },
                    { new Guid("9c5aa587-4bdc-6e39-1025-a1d754208223"), "Quis fugit sunt odio.\nLaborum blanditiis sit.\nQuasi velit voluptatibus.\nRerum consequatur nostrum numquam voluptate.\nUt accusantium autem odit necessitatibus et nihil tenetur.", "Jada Corwin", "https://salvador.net" },
                    { new Guid("9d601d84-d56d-a5a2-a274-6ce4d8337fd5"), "Officiis sit inventore quod reiciendis eius fugiat repellendus optio.\nEum quos non aspernatur.", "Johnathon Deckow", "https://vivianne.info" },
                    { new Guid("9db732c1-1f29-3c58-0851-993ce39174b9"), "Accusamus et aut impedit est.\nEt perspiciatis consectetur blanditiis rerum voluptates voluptas laudantium vero.\nNeque quibusdam temporibus ipsum similique harum distinctio in.\nAlias ut qui itaque officiis.", "Zora Hayes", "http://wyman.info" },
                    { new Guid("a695090c-7dd3-0ab7-5b8a-eac5e812abf6"), "Est ea ipsam.\nDeserunt velit voluptatem aut accusantium voluptatum.\nNisi et maiores dolor alias rerum nobis.\nTenetur pariatur earum.\nRecusandae natus officia culpa voluptatum inventore.\nDoloremque quibusdam accusantium dicta illum cupiditate.", "Aubree Romaguera", "https://pierre.net" },
                    { new Guid("a8455337-7760-de54-1ee2-30a00af525b6"), "Enim itaque quas.\nExercitationem et nostrum blanditiis odio qui fugiat.\nSoluta vitae distinctio.\nRerum eum omnis commodi fugiat incidunt a explicabo.", "Marianne Davis", "https://clyde.net" },
                    { new Guid("ac51fd1b-5a9e-7e9c-b15a-00516f250498"), "Ut molestiae animi laboriosam ipsa sunt ut.\nVoluptas harum sed ut odit odit voluptatum eos est.\nAut eum corporis maiores molestiae consequatur aut quia dolores facere.\nAsperiores et consequatur.\nAperiam sed nobis non ut.\nPariatur eveniet doloribus consectetur dolore ducimus.", "Clark Kessler", "https://antonietta.com" },
                    { new Guid("accff0b4-8f4b-e442-672a-eaa92d575f00"), "Aut odio non maiores porro aut officia.\nOfficiis aliquam ab facere impedit dicta deserunt qui dolores in.\nQuas atque itaque.\nVoluptatem totam exercitationem placeat libero et ut quaerat provident.\nHarum quo non.\nSed est ut occaecati.", "Otha Schulist", "http://bethany.name" },
                    { new Guid("b6770afb-b32e-2947-fb63-71fe5cf6c6f9"), "Id odit sunt quia sit ullam ea.\nMinus laudantium reprehenderit rerum ullam.\nTempora doloremque itaque qui porro assumenda cum a.", "Blanche Bosco", "http://avis.name" },
                    { new Guid("b8e73814-b3fd-9891-63f4-b9437945cb0d"), "Iste dolorem facilis vel itaque velit.\nSed omnis ut eaque neque.", "Sheldon Raynor", "https://sydnee.org" },
                    { new Guid("bb487666-61ea-8e47-6aa4-bcf56ad1409f"), "Id corporis quae qui distinctio minus illo.\nDolor quo cupiditate tenetur sed dolor qui tempora.\nVero cumque id eveniet minus impedit.\nVoluptate alias ut similique deleniti.\nVel autem sint consequatur quae eaque veritatis.", "Toy Buckridge", "https://florencio.org" },
                    { new Guid("dab5a86a-b551-d87e-b824-9becabe5d6e8"), "Quo facere possimus aut dolore.\nUt ipsum facere non.\nEos libero autem suscipit.\nQuo est debitis accusamus voluptates tenetur non.\nIpsam eos optio aut inventore sed.\nHarum est aut eum sequi illum.", "Deontae Oberbrunner", "https://charlie.net" },
                    { new Guid("e11657ba-c2b3-8816-df4b-48961c744e6c"), "Voluptates quia quos eos maiores aut modi veniam laboriosam sit.\nAutem fugit consequatur voluptatem et voluptatem nihil quis aut dolorum.\nOmnis est consequatur.\nOmnis et quia.\nVeniam sed dicta rerum eligendi a aut molestias ut.", "Katheryn Reilly", "https://keira.org" },
                    { new Guid("e5d45d01-7550-f076-cab0-123006c6b80d"), "Aut est est deleniti rerum placeat tenetur sed quibusdam.\nAut nulla doloribus quia dolorem.", "Jadon Labadie", "http://tod.net" },
                    { new Guid("eeb5edb0-85f1-0bbd-f6cc-b94dbcf2f2fa"), "Delectus minima nemo minus esse quo nesciunt cupiditate sapiente.\nDolore nisi sunt et.", "Alta Hegmann", "http://gay.name" },
                    { new Guid("f6dec917-d6cf-c291-55d1-38236943acb1"), "Molestiae eos eos consectetur ea soluta voluptatem.\nCum impedit ab autem.", "Rita Casper", "http://danial.org" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { new Guid("1d7c4f34-3c9f-b048-efc6-eb8a830f8e80"), "Rap" },
                    { new Guid("27c0c216-9ff0-3e55-142a-15b371bc8601"), "Non Music" },
                    { new Guid("2ce8ba98-e9b4-6317-a0cb-7dbdc26ed9f3"), "Funk" },
                    { new Guid("2d5fd0af-bbe4-fc58-cf69-b321cf67080c"), "Reggae" },
                    { new Guid("2df48875-02d3-b88d-79c6-a641203144e8"), "Reggae" },
                    { new Guid("318c2817-8cda-dc6f-c0ba-8b12a5cf2b50"), "Rap" },
                    { new Guid("4081adaf-2988-ddd3-9958-d68ab3771976"), "Pop" },
                    { new Guid("462b82e1-ffca-41ee-1f2d-8cdb01e7c4b9"), "Rock" },
                    { new Guid("52ad612f-0ba0-8a59-8655-481e200df338"), "Pop" },
                    { new Guid("61ba5681-384a-3513-c82d-b2cd6fcf7baa"), "Non Music" },
                    { new Guid("6b699313-51e5-e3d3-f6e7-cacf33f689e9"), "Electronic" },
                    { new Guid("6c233a33-76a5-2ef0-9481-d41f3e611e8c"), "Electronic" },
                    { new Guid("6d02218e-12cf-9f67-bc25-d36cd5cf2492"), "Country" },
                    { new Guid("6e35ea7b-3046-53cc-5654-f440a75cd534"), "Reggae" },
                    { new Guid("772c6425-8d07-2953-43e4-f7a87836092c"), "Non Music" },
                    { new Guid("7b7dfc93-d37e-a88e-09ee-c48fdda6cf5b"), "Non Music" },
                    { new Guid("7d9f768d-6557-3272-a72f-286e7dd555e6"), "Reggae" },
                    { new Guid("807bc7d0-7795-add0-b9d3-23c4ca0c55fa"), "Soul" },
                    { new Guid("857a79c3-db39-50b3-12ad-57e55b94d482"), "Blues" },
                    { new Guid("8d45ddf6-4a9b-d79d-9f00-497367179f85"), "Funk" },
                    { new Guid("94149291-7a66-c8c9-ec13-b1ccda4a61eb"), "Rap" },
                    { new Guid("b1f6260c-2ad4-6782-a80e-de0e41731686"), "Rock" },
                    { new Guid("c2d37ba8-8834-df3c-e3f8-4cecb9cabc87"), "Reggae" },
                    { new Guid("cf061f7c-9a75-3c4b-795d-1011e7c27eb5"), "Rap" },
                    { new Guid("e38d779f-2a67-3bd0-a3ae-a64064fe89a0"), "Jazz" },
                    { new Guid("e6f573b7-2faf-f5ba-8d4b-1551263643bd"), "Classical" },
                    { new Guid("ec5290b8-2ac7-e38b-75d9-d2c7da9625e6"), "Non Music" },
                    { new Guid("ed4d130d-3cb2-b3b6-e69b-cea25f50d9fd"), "World" },
                    { new Guid("f1b413e6-66a4-4140-d27b-279035984bd1"), "World" },
                    { new Guid("f37f99b0-77dd-3158-107e-808b21ed2831"), "Electronic" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Duration", "EndAiringDate", "Name", "Photo", "Rating", "ReleaseDate", "StartAiringDate", "Trailer" },
                values: new object[,]
                {
                    { new Guid("2099f552-ffdb-26fe-1794-dbf93c54c5ff"), "Laudantium id consequatur.\nAsperiores inventore et distinctio numquam vel distinctio perspiciatis.\nQuod rerum ipsam doloremque deserunt porro.\nTempora labore esse dolores reiciendis.\nLibero accusantium eligendi neque ipsam praesentium veniam.\nAnimi qui atque.", new TimeOnly(22, 20, 48, 432).Add(TimeSpan.FromTicks(6799)), new DateOnly(2024, 12, 10), "Practical Steel Tuna", "http://murray.net", 5.0, new DateOnly(2024, 2, 29), new DateOnly(2023, 5, 7), "http://jaeden.com" },
                    { new Guid("289c2d25-c7a0-77ff-183e-18a7125a2f29"), "Aut ut voluptatem.\nFacere reiciendis at temporibus aperiam consectetur fugit qui.\nFuga sunt at dolor dolores molestiae et.\nVoluptatem eligendi voluptatibus deleniti nihil enim doloremque corrupti consequatur.\nVoluptas voluptatum totam debitis labore nesciunt ab consequatur non ipsam.\nSimilique dignissimos nostrum qui fugit sunt ut ut odit laboriosam.", new TimeOnly(22, 14, 28, 448).Add(TimeSpan.FromTicks(1918)), new DateOnly(2025, 1, 15), "EXE", "http://damian.info", 0.0, new DateOnly(2024, 1, 2), new DateOnly(2023, 6, 14), "https://miles.biz" },
                    { new Guid("34cb91cc-6c3d-d537-a40d-fa22b0961c42"), "Sapiente ex enim provident itaque aut.\nEx quae itaque harum sit facilis et ullam eius.\nTempore voluptas id perferendis earum tenetur voluptatem voluptatem.", new TimeOnly(22, 18, 57, 912).Add(TimeSpan.FromTicks(2440)), new DateOnly(2024, 11, 23), "application", "https://lowell.biz", 1.0, new DateOnly(2023, 9, 19), new DateOnly(2024, 2, 18), "http://ana.net" },
                    { new Guid("34f188c1-c8b9-91f8-ae65-9bf2d6c89690"), "Eum iure magnam molestias omnis aut qui soluta.\nQuia harum alias eos perferendis esse.\nEst ut similique error numquam delectus.\nMinus voluptatibus est rerum aliquam ea alias iure praesentium.", new TimeOnly(21, 38, 21, 132).Add(TimeSpan.FromTicks(1653)), new DateOnly(2024, 8, 22), "Gorgeous Soft Towels", "https://macie.org", 2.0, new DateOnly(2023, 5, 18), new DateOnly(2023, 9, 29), "http://ned.biz" },
                    { new Guid("3e334911-cf3b-2628-5870-44044d7d64a7"), "Ducimus aut soluta veniam sequi ad.\nVelit natus et alias possimus earum esse.\nPossimus iste illum ratione.\nReprehenderit maiores esse voluptatem excepturi.\nFugit libero soluta dolores reiciendis.\nQuia numquam dolorum vel.", new TimeOnly(21, 23, 10, 542).Add(TimeSpan.FromTicks(5660)), new DateOnly(2025, 1, 24), "Groves", "http://alba.biz", 3.0, new DateOnly(2023, 8, 19), new DateOnly(2023, 10, 16), "http://lelah.net" },
                    { new Guid("44cead50-4140-c036-26d2-6578e1f71843"), "Earum dolores voluptatem quibusdam sed quaerat praesentium placeat.\nEt illo corrupti voluptate optio.\nVeritatis culpa et vero ut voluptatem expedita a eaque harum.\nAmet est et.\nQuae architecto ex id officia qui.\nVitae unde aut reprehenderit ex qui aliquid molestias commodi repellendus.", new TimeOnly(22, 14, 19, 109).Add(TimeSpan.FromTicks(4836)), new DateOnly(2024, 7, 30), "navigating", "https://jena.net", 2.0, new DateOnly(2023, 9, 25), new DateOnly(2024, 1, 24), "http://trystan.biz" },
                    { new Guid("4766c4a0-154f-e1e6-a0d3-ed17ec86ba85"), "Incidunt id aut maxime et est fuga.\nVoluptas dolorum qui iure doloremque voluptate iure.\nQuia natus praesentium velit omnis voluptatibus.\nNumquam et eligendi unde est autem laudantium quibusdam qui numquam.", new TimeOnly(22, 17, 0, 611).Add(TimeSpan.FromTicks(1940)), new DateOnly(2024, 11, 29), "Supervisor", "https://jevon.info", 0.0, new DateOnly(2024, 2, 4), new DateOnly(2023, 7, 2), "https://dave.name" },
                    { new Guid("4844c0f9-54ac-9679-988f-d0c51581b5e6"), "Architecto dicta cum quisquam qui.\nUt nihil aliquam mollitia voluptatem.\nVoluptas dolorem veritatis molestias.\nOptio sed provident voluptatum pariatur odit assumenda velit.\nSequi vel et aliquid.", new TimeOnly(22, 19, 57, 59).Add(TimeSpan.FromTicks(3132)), new DateOnly(2024, 5, 20), "Florida", "https://madonna.name", 4.0, new DateOnly(2024, 1, 11), new DateOnly(2024, 2, 3), "https://tracy.biz" },
                    { new Guid("48492d38-0885-7ba0-1d88-2c62c9beda75"), "Quisquam soluta inventore sequi maxime a mollitia dolores ut quis.\nEt quod ut possimus aperiam illum amet saepe.\nMaiores temporibus error.\nVoluptate nihil velit.\nItaque et voluptas officiis dolore assumenda.\nUt illo et distinctio.", new TimeOnly(22, 7, 25, 947).Add(TimeSpan.FromTicks(3249)), new DateOnly(2024, 9, 1), "Applications", "https://price.name", 3.0, new DateOnly(2024, 1, 3), new DateOnly(2023, 8, 16), "https://bud.net" },
                    { new Guid("66e84d42-5fb3-4210-d5b0-73ff8241ded4"), "Repudiandae qui ipsa id occaecati.\nQuae maiores quis mollitia voluptas facilis voluptates pariatur.\nMagni porro voluptatum.\nRerum ad fugiat doloribus perferendis dicta fugit ea dignissimos.", new TimeOnly(22, 9, 49, 815).Add(TimeSpan.FromTicks(8747)), new DateOnly(2025, 2, 19), "Switzerland", "https://margret.name", 3.0, new DateOnly(2023, 7, 18), new DateOnly(2024, 4, 1), "http://bethel.org" },
                    { new Guid("83bfc387-1e48-6a4e-16f3-e7624e540b5f"), "Repellat quae id modi distinctio corporis quasi.\nQuos vel explicabo molestiae asperiores quidem aliquam dolor provident.\nMinus repudiandae et cum illum ut.\nQuasi nemo corrupti eligendi nihil voluptas perspiciatis iusto.\nDolore neque aut.", new TimeOnly(21, 53, 33, 321).Add(TimeSpan.FromTicks(7579)), new DateOnly(2025, 3, 15), "Implemented", "http://catalina.name", 10.0, new DateOnly(2023, 8, 7), new DateOnly(2023, 9, 7), "https://edgardo.info" },
                    { new Guid("8c3e9843-3144-e8fa-81a6-4f66b6579c8b"), "Molestias iste sit quia eius eos.\nSit tenetur provident.\nItaque labore reprehenderit quis pariatur aliquid placeat voluptas quia ipsam.", new TimeOnly(21, 57, 1, 681).Add(TimeSpan.FromTicks(8706)), new DateOnly(2025, 1, 11), "index", "http://columbus.info", 5.0, new DateOnly(2023, 6, 8), new DateOnly(2023, 5, 3), "https://danial.info" },
                    { new Guid("94d03a65-a553-25b5-d0eb-11b374a82fce"), "At quae quis sed quo.\nOptio dignissimos sit eveniet magnam in facere.\nExpedita voluptas possimus cupiditate facilis adipisci rerum praesentium aut similique.\nVoluptates illum iste.\nNon et laborum.", new TimeOnly(21, 59, 59, 521).Add(TimeSpan.FromTicks(7738)), new DateOnly(2024, 8, 28), "Generic Fresh Computer", "https://marilie.net", 2.0, new DateOnly(2023, 5, 23), new DateOnly(2024, 2, 16), "https://miracle.biz" },
                    { new Guid("97fc08c0-3d15-bff0-1be3-c6b21bdb4b11"), "Ut est atque molestias id.\nIste dignissimos vel possimus deleniti beatae.\nTemporibus quae excepturi hic sint quibusdam sit ut facilis mollitia.\nLaudantium aut corrupti aut et voluptatibus animi eos.\nAutem excepturi in autem ullam sed laboriosam qui eos ipsa.\nEaque ex qui et dolorem.", new TimeOnly(21, 36, 34, 376).Add(TimeSpan.FromTicks(7035)), new DateOnly(2024, 8, 3), "vortals", "http://shanelle.net", 8.0, new DateOnly(2024, 3, 4), new DateOnly(2023, 5, 30), "https://brooke.com" },
                    { new Guid("a750a6dd-f450-3766-a4a7-de59a5993cbf"), "Iure enim quisquam possimus sint cumque totam.\nOmnis saepe eius molestiae eligendi quia exercitationem explicabo dignissimos dolores.\nPerferendis veritatis consectetur quis soluta dolor.", new TimeOnly(22, 12, 10, 616).Add(TimeSpan.FromTicks(624)), new DateOnly(2024, 12, 2), "vortals", "http://bartholome.name", 1.0, new DateOnly(2023, 11, 11), new DateOnly(2023, 6, 11), "http://diego.org" },
                    { new Guid("abf03c0a-d1d1-66b7-4eea-66f7f2a13d47"), "Sunt architecto fuga vitae sunt voluptatem temporibus reiciendis molestias error.\nExcepturi corrupti neque quam est dolor consequuntur.\nSunt quisquam voluptatem ut nam dolor libero animi voluptatum adipisci.", new TimeOnly(21, 59, 9, 501).Add(TimeSpan.FromTicks(2731)), new DateOnly(2025, 1, 20), "Investment Account", "http://freida.net", 3.0, new DateOnly(2023, 12, 30), new DateOnly(2023, 10, 3), "http://joan.info" },
                    { new Guid("b5df1a76-8009-916f-5976-2501c4022fca"), "Sit molestiae tenetur cum magni vel.\nMagni magnam vel.\nNecessitatibus cum impedit nihil a voluptatem aut qui facilis nesciunt.\nAperiam quia et accusantium maxime.", new TimeOnly(21, 33, 45, 953).Add(TimeSpan.FromTicks(7644)), new DateOnly(2025, 1, 20), "Optimization", "http://devyn.name", 6.0, new DateOnly(2023, 5, 20), new DateOnly(2023, 5, 9), "http://jonathon.org" },
                    { new Guid("b668ab4e-4f9e-31b8-bd88-42209b49913c"), "Occaecati in dolorum quaerat dolorem fuga velit qui dolore rerum.\nRerum aspernatur quisquam eaque ad unde exercitationem vel totam.\nVoluptatem incidunt qui in ad.\nEos et eveniet suscipit possimus accusamus.\nQui inventore suscipit expedita dolores dolorem aperiam.", new TimeOnly(21, 32, 40, 422).Add(TimeSpan.FromTicks(5946)), new DateOnly(2024, 10, 21), "Tools, Electronics & Beauty", "https://tyler.org", 2.0, new DateOnly(2023, 5, 5), new DateOnly(2023, 5, 22), "http://antonietta.biz" },
                    { new Guid("b9aa809c-09da-32e2-5b8e-cd5def532e7c"), "Ducimus sed eos mollitia.\nVoluptatem ut sit voluptas aut veritatis maiores itaque.\nFuga voluptas pariatur reprehenderit.\nIllo velit distinctio quae repellendus ut laboriosam omnis consequatur.\nAut aut rem provident beatae rerum quas corrupti.\nDeleniti animi facere sit.", new TimeOnly(21, 33, 27, 719).Add(TimeSpan.FromTicks(1619)), new DateOnly(2025, 3, 5), "North Dakota", "http://carol.name", 10.0, new DateOnly(2023, 8, 19), new DateOnly(2024, 3, 16), "http://tremayne.biz" },
                    { new Guid("c1082a57-8437-459f-365d-139761feb6c8"), "Et minus enim autem dolorem exercitationem ut.\nDolores pariatur omnis et.\nVeniam et maiores architecto.\nQui fugiat qui odit consectetur.\nRerum sunt nobis non quidem ullam reiciendis illo minima.", new TimeOnly(22, 14, 33, 953).Add(TimeSpan.FromTicks(1565)), new DateOnly(2024, 9, 13), "navigating", "http://dawn.name", 3.0, new DateOnly(2024, 3, 8), new DateOnly(2024, 1, 22), "http://athena.name" },
                    { new Guid("c32a08ce-8bed-425b-253e-cbee0b095431"), "Quasi ut et est eum explicabo.\nEa beatae cupiditate labore perferendis id pariatur totam ut et.", new TimeOnly(21, 51, 11, 146).Add(TimeSpan.FromTicks(1624)), new DateOnly(2024, 12, 1), "Analyst", "http://darrin.biz", 9.0, new DateOnly(2024, 3, 25), new DateOnly(2023, 8, 23), "https://antoinette.net" },
                    { new Guid("cbf10dfe-24f7-55f1-0299-ff0ef73449e1"), "Dicta qui ullam occaecati enim.\nPariatur ab maiores placeat.\nNisi aspernatur ullam.", new TimeOnly(21, 41, 4, 860).Add(TimeSpan.FromTicks(3955)), new DateOnly(2025, 4, 8), "optical", "http://amos.biz", 0.0, new DateOnly(2023, 9, 6), new DateOnly(2023, 7, 16), "https://kaya.com" },
                    { new Guid("e1686571-1067-e6af-2041-dad3bb63d618"), "Eum incidunt enim labore.\nCum culpa velit molestiae consequatur corrupti.\nIpsam sed labore et libero.\nItaque maiores laboriosam ipsa asperiores ipsam.\nEst nam ducimus vitae sit fugiat non quia velit voluptates.", new TimeOnly(21, 42, 42, 764).Add(TimeSpan.FromTicks(4391)), new DateOnly(2024, 6, 24), "Optimization", "https://justus.biz", 7.0, new DateOnly(2023, 11, 15), new DateOnly(2024, 4, 19), "https://jaunita.biz" },
                    { new Guid("e540d6c1-d622-4d61-a54d-8d24c19427d9"), "Culpa libero veritatis illo tenetur est consequuntur.\nAutem molestiae quod eum facilis est.", new TimeOnly(21, 49, 57, 622).Add(TimeSpan.FromTicks(4141)), new DateOnly(2024, 5, 24), "Steel", "http://eino.org", 10.0, new DateOnly(2023, 7, 17), new DateOnly(2023, 8, 12), "http://rex.biz" },
                    { new Guid("ec9b031c-16b5-0042-f02e-51f902d4d858"), "Sed quia voluptatum assumenda nesciunt velit soluta ut aut rerum.\nUt accusamus et quasi illo harum sunt qui quos deleniti.\nIllum vero assumenda sunt facilis voluptas doloribus.", new TimeOnly(22, 8, 51, 550).Add(TimeSpan.FromTicks(4925)), new DateOnly(2024, 11, 24), "South Carolina", "https://melyna.biz", 8.0, new DateOnly(2023, 5, 7), new DateOnly(2023, 10, 21), "http://helena.name" },
                    { new Guid("edca8efc-66f9-19f0-a40c-1a9269f702c7"), "Veritatis dolorum esse et qui cupiditate qui rerum.\nFacilis id omnis qui quaerat nihil saepe error.\nQuod itaque illo qui illum qui.\nTempora suscipit adipisci.", new TimeOnly(21, 48, 52, 100).Add(TimeSpan.FromTicks(6674)), new DateOnly(2024, 6, 15), "rich", "http://ahmed.info", 9.0, new DateOnly(2024, 2, 19), new DateOnly(2023, 11, 24), "http://tate.info" },
                    { new Guid("ef1ab6f5-8933-2069-ac83-bf1b51b6f0ce"), "Ut voluptatibus ut ex labore.\nNumquam exercitationem praesentium dolorem nesciunt dolorem consequatur quia aut.\nSit explicabo ullam quo explicabo.\nEos voluptas et laborum dolor perspiciatis aliquid eligendi.", new TimeOnly(21, 51, 18, 658).Add(TimeSpan.FromTicks(5285)), new DateOnly(2024, 6, 14), "cross-platform", "https://dorcas.name", 7.0, new DateOnly(2024, 1, 16), new DateOnly(2024, 2, 21), "https://augusta.info" },
                    { new Guid("faff0461-a967-d0c2-8a12-8c5f49b96d3e"), "Voluptas suscipit unde rerum.\nVoluptas hic ex fuga veritatis sequi alias.\nNemo ratione corporis mollitia labore sint.\nEsse eos aut fuga in modi reiciendis non dolores.\nVoluptas nesciunt velit.\nDolores et explicabo quos quia ratione reiciendis possimus.", new TimeOnly(22, 20, 29, 799).Add(TimeSpan.FromTicks(7626)), new DateOnly(2024, 11, 13), "Gateway", "https://zack.net", 4.0, new DateOnly(2023, 8, 14), new DateOnly(2023, 5, 18), "https://elfrieda.name" },
                    { new Guid("fe0b3b43-a5c1-7eda-f8f6-8609e7a904ca"), "Aut accusamus temporibus.\nQuo aperiam voluptatum harum.\nQui iure et consequuntur.\nQuia error officiis quas quo et.", new TimeOnly(21, 35, 0, 91).Add(TimeSpan.FromTicks(1589)), new DateOnly(2024, 8, 15), "customized", "http://audreanne.name", 2.0, new DateOnly(2023, 11, 25), new DateOnly(2024, 3, 3), "http://whitney.net" },
                    { new Guid("ff04ff94-51ba-2f0d-80fc-a0ed8044c523"), "Quisquam qui laboriosam.\nSit repudiandae quas.\nMaxime deleniti dolor sapiente ipsa id voluptate sequi dignissimos ut.", new TimeOnly(22, 19, 6, 500).Add(TimeSpan.FromTicks(3307)), new DateOnly(2024, 11, 7), "Refined Metal Car", "http://courtney.net", 2.0, new DateOnly(2023, 11, 6), new DateOnly(2023, 10, 9), "http://lenora.com" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("ba92aa79-53f7-4386-8318-52730f5cd062"), null, "admin", null },
                    { new Guid("bd8f4d50-0b70-4484-84fa-743f6b39cb3f"), null, "user", null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "NumberOfSeats", "RoomName" },
                values: new object[,]
                {
                    { new Guid("1b7bc9e8-4016-b024-b403-4c40dbc12959"), -1972318105, "impedit" },
                    { new Guid("1c1fbeff-4bde-3cfe-9996-3b7ceebbc512"), -496344607, "illo" },
                    { new Guid("1ed7ce11-edef-300c-202c-bdd8e0b75427"), 573772124, "reiciendis" },
                    { new Guid("1f82f418-710b-38d8-c552-cc1bc4987269"), 1601336302, "ratione" },
                    { new Guid("25ba8f9f-213b-c92f-e5b8-592b89d8b748"), -1990669988, "ea" },
                    { new Guid("41b831cd-1c74-a013-f156-61b204bf3723"), -2039826584, "blanditiis" },
                    { new Guid("42c6a36b-1406-020c-ef8f-55d16fe5c3ee"), 404179306, "tempora" },
                    { new Guid("46b288c1-a2bb-3822-0c8e-acaa557e221d"), -414069075, "beatae" },
                    { new Guid("55063b0a-3164-2d1e-f9c6-8764e0fa8f08"), -1773488298, "quia" },
                    { new Guid("740413b7-63dc-4cbe-bc2e-4fde0b25d689"), 1544859053, "nam" },
                    { new Guid("789026d4-f6ad-a9ed-179e-bfd0b3b20085"), 1679807992, "porro" },
                    { new Guid("7ea05b04-e8b1-d3f2-90b2-c51c550417ec"), -1526402007, "et" },
                    { new Guid("8bf79c03-c104-2455-2685-943044ccfe94"), -1925777693, "quibusdam" },
                    { new Guid("8f664c66-fca9-4f9e-e435-b291afa08c84"), -362042461, "odio" },
                    { new Guid("912d048f-5d9e-6af0-1fcb-ad3ccb8be6b7"), 1272431960, "iusto" },
                    { new Guid("9b963b4a-69b0-b7a5-200e-98257b33325a"), 65602508, "dolores" },
                    { new Guid("9f5628c1-6892-9ebb-3700-3f1191fd7382"), 1850821384, "sit" },
                    { new Guid("aee15233-2afb-7164-f481-c7e3e2a0e84a"), -1215692466, "corrupti" },
                    { new Guid("b08d4b84-32c3-dbd2-5c11-2ad01f6ff2bf"), 1538830536, "neque" },
                    { new Guid("b4f6a130-823b-093b-7581-2e7361d2583f"), -191034494, "molestias" },
                    { new Guid("bbf25e92-556d-5268-c922-7cce610fc9e7"), 1316353010, "placeat" },
                    { new Guid("c6fc2914-9ec2-7eec-fa69-0ebff49c9e90"), -988889289, "sunt" },
                    { new Guid("cdca2681-c2b3-333d-0714-9b2d24e549ba"), 428761940, "veritatis" },
                    { new Guid("de2d916c-7588-11be-95c5-ab2750ed62ce"), -345322311, "quia" },
                    { new Guid("deb684ea-1168-c3d9-01d7-e3cb8f345e90"), 1197493784, "quia" },
                    { new Guid("ee397787-1c08-7738-6075-e36e42b18a9e"), 240136091, "ratione" },
                    { new Guid("efb5ab4e-bc4f-6303-1f0f-75484f43ada4"), -1377185900, "sunt" },
                    { new Guid("f5caee8c-e02f-2576-25ff-af5242b5daf4"), 1040124291, "enim" },
                    { new Guid("f8c22bf5-8cb8-7e19-be69-5243072025b7"), 1691121532, "provident" },
                    { new Guid("fda90c93-c015-b2e9-2966-75756d16bcc6"), -2115901808, "explicabo" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0128417b-7e6b-f459-ca04-7c86bfbc930a"), 0, "4a1e4d51-41b5-4e8a-b2d7-dd284b32cfe4", "Sandy.Kiehn65@gmail.com", false, false, null, null, null, "c13g4XJceH", "(589) 782-7211", false, null, false, "Ron.Beahan" },
                    { new Guid("07969861-f952-7db7-5a45-67cec06173a0"), 0, "0e18db6d-6aee-4a88-a60f-19ed4ba0b3fb", "Isidro.Leffler42@hotmail.com", false, false, null, null, null, "NitLhKTGpv", "(379) 447-8507", false, null, false, "Deonte.Ryan" },
                    { new Guid("2987d029-4252-4c79-f04a-80909b109331"), 0, "802e8144-9ca1-4668-b7ed-3ef849dc96f7", "Kelli.Spinka51@hotmail.com", false, false, null, null, null, "SAWMGrETXX", "(362) 255-5141 x7320", false, null, false, "Bradley96" },
                    { new Guid("37e54cf5-9238-22d4-38e8-afc8f7816363"), 0, "a87a77aa-91da-44ae-933f-fbdb78c77068", "Leo_Bogisich@hotmail.com", false, false, null, null, null, "HmHIo3dUF0", "(613) 553-1237 x45235", false, null, false, "Jeffery.Hoppe1" },
                    { new Guid("3842a9f0-d9bf-0aa1-cc85-ba2dd070a999"), 0, "35cfd663-cc4c-43eb-b35b-de167575fcaa", "Maud12@yahoo.com", false, false, null, null, null, "q98jVAJ3Yt", "438-281-9515 x258", false, null, false, "Diana_Schumm" },
                    { new Guid("4bc02641-5034-7a8d-5e15-6e0cb0011ffb"), 0, "b7679e2e-fcfd-4a06-8670-8aeee1461dd3", "Justen7@gmail.com", false, false, null, null, null, "2TnTuJTvu8", "909-866-7459 x41069", false, null, false, "Courtney_Tremblay89" },
                    { new Guid("5982c69d-d336-ff62-7ec4-4847b7b9b7e5"), 0, "0143bf28-2cd1-49bd-8285-33e1ff1c1f97", "Chauncey_Roberts@hotmail.com", false, false, null, null, null, "4VuTnn7Qog", "885.843.6922", false, null, false, "Archibald.Stanton" },
                    { new Guid("6b480acf-39d0-ef67-eb41-498ed84f530e"), 0, "db9e6ec1-5649-467e-bc3d-83790a81bbcf", "Sibyl28@hotmail.com", false, false, null, null, null, "rMh5zHM0NS", "426-853-5658 x3640", false, null, false, "Carley91" },
                    { new Guid("708a16d8-910d-2543-db7d-32594ba47c6f"), 0, "4ddc5260-d437-471b-95ef-6e413dd96231", "Ayana15@yahoo.com", false, false, null, null, null, "POQaWq6JJf", "448.807.8159 x24782", false, null, false, "Edyth.Mills95" },
                    { new Guid("72575831-a746-e226-14ca-0f76060b08b0"), 0, "3704c1f8-9720-4b9f-b91c-47471091abdc", "Kaden.Bednar@yahoo.com", false, false, null, null, null, "4bASlCyb_I", "(332) 805-2029 x281", false, null, false, "Neva.Stracke" },
                    { new Guid("72640f98-cf6f-e877-52d3-e0098abba5f9"), 0, "edd620e3-a644-4b7a-9ac0-9511b801f253", "Dakota_OKeefe@yahoo.com", false, false, null, null, null, "4rfYe31xqk", "964-783-3948 x07690", false, null, false, "Alvena.Rogahn" },
                    { new Guid("72a66c5f-b855-a55f-af7d-91658af4d4c4"), 0, "58307365-0eb3-4fe3-b46c-bcea24e06b97", "Chase.Pouros7@gmail.com", false, false, null, null, null, "50rCsg9A7G", "(751) 517-4915 x3044", false, null, false, "Keanu_Mraz10" },
                    { new Guid("79b3c809-c487-ca58-a065-fb662c1d856b"), 0, "c7714442-1e8c-4805-8dcd-b1871a886ede", "Abbie.Hegmann95@gmail.com", false, false, null, null, null, "7EfufuO7ja", "969-352-7704", false, null, false, "Oran.Feil28" },
                    { new Guid("80443df9-c356-72bf-b39e-28daea1b3679"), 0, "3285fc19-7684-48af-b183-43934cd1e220", "Jaylon.Mayert74@yahoo.com", false, false, null, null, null, "m7roKZwCu6", "1-284-333-8299 x616", false, null, false, "Renee.Gleichner" },
                    { new Guid("8800543c-5af6-0644-03c0-e54cf488aba3"), 0, "c0945fdd-85d3-4121-bf20-572d90ab2876", "Estelle_Zboncak@gmail.com", false, false, null, null, null, "3jFzHwkjQu", "939-960-3505 x00889", false, null, false, "Amiya.Fahey60" },
                    { new Guid("8f1830c0-9b8c-bf07-813f-25739cf26f90"), 0, "44fe6687-a64a-49c2-ba39-6b2d61a8163e", "Mylene_Kling@hotmail.com", false, false, null, null, null, "RssACTIwwr", "(446) 541-8099", false, null, false, "Adelbert.McKenzie9" },
                    { new Guid("aaf95722-04a7-d426-3cc4-e97e8904fafa"), 0, "00bf89f2-2749-4d24-b230-35e0dacb7848", "Ethan.McClure@gmail.com", false, false, null, null, null, "C8W98F50tM", "1-902-243-1030 x14877", false, null, false, "King_McClure" },
                    { new Guid("ade592e2-9f63-0659-03dc-07b81d319272"), 0, "b157e76a-8516-4b0a-b310-40bebcd47178", "Addie_Ernser33@yahoo.com", false, false, null, null, null, "z2Kd6hl3yl", "1-857-870-4459", false, null, false, "Christiana69" },
                    { new Guid("aef1daba-2b62-0ca0-6c72-1a5cbdd58546"), 0, "485a2640-10e7-41b2-a066-7a1443091b3b", "Keon.Cummerata39@gmail.com", false, false, null, null, null, "_AdDLOdDhs", "1-504-335-7255", false, null, false, "Agnes98" },
                    { new Guid("b09cd1d5-5cad-df24-ca13-563649dc2b80"), 0, "3f0f6ffc-3f58-4387-8d3d-e039d7cc6c0b", "Sallie_Berge@yahoo.com", false, false, null, null, null, "_3sMXn4tsA", "(207) 926-8487 x8159", false, null, false, "Vinnie.Collier50" },
                    { new Guid("b4ef1c35-ce95-197d-05a8-127f369b6e48"), 0, "a9f763da-2959-4e25-a848-49ea29a414bf", "Devonte.Simonis@gmail.com", false, false, null, null, null, "VykZca7ok7", "982-522-1288", false, null, false, "Kelsi.Wyman" },
                    { new Guid("bce6fea0-426d-9cda-ebcf-49c53e7b3d64"), 0, "81658594-5ecd-4e97-b73a-681f61f9a1d6", "Allene38@hotmail.com", false, false, null, null, null, "zdDZ_ch8Nn", "562-895-4107 x599", false, null, false, "Vivienne39" },
                    { new Guid("c4cbb5ec-2e63-31ec-c980-59f551535590"), 0, "f2f4ea3c-cac7-4440-9263-40b3cfbe0c2c", "Kamren.Nienow@yahoo.com", false, false, null, null, null, "DFk0GoPt_t", "1-682-857-7698 x9424", false, null, false, "Josefa.Rosenbaum79" },
                    { new Guid("d9d3273e-4740-d5e2-1429-56d08962a37d"), 0, "115af326-7aa3-4908-90f7-b4ccc9156429", "Ari26@yahoo.com", false, false, null, null, null, "x7RYrTviIp", "549.661.3712 x936", false, null, false, "Gabrielle.Bashirian79" },
                    { new Guid("eab7e2f7-096b-24cc-b6cf-bdbb2d21bcb7"), 0, "23c387ef-b07c-4c5f-8022-2e1c67210776", "Oleta.Powlowski@gmail.com", false, false, null, null, null, "1baQj4yX5h", "(201) 448-1667", false, null, false, "Summer_Crist51" },
                    { new Guid("eefdad93-f330-d940-5715-a5661b17d7ed"), 0, "ab117271-5910-4127-881e-bd968315f29d", "Makayla59@hotmail.com", false, false, null, null, null, "UnjZUcvcoa", "(748) 528-5848 x97095", false, null, false, "Devin_Nitzsche70" },
                    { new Guid("f01a84f4-6dfe-2407-f6af-c71b68974173"), 0, "96c8d609-7d64-4499-bd0d-576f3357272e", "Torrance43@gmail.com", false, false, null, null, null, "sUHNa3GQMR", "(301) 661-6830", false, null, false, "Nicholaus_Kassulke" },
                    { new Guid("f2b09370-3b2c-c912-f76c-eaa4c8bbcec8"), 0, "2b4d0f58-17f3-432d-ac04-6921d664e659", "Sammy_Wilderman27@gmail.com", false, false, null, null, null, "e0zwwDxgBC", "257-427-0546", false, null, false, "Francesco8" },
                    { new Guid("f5504543-2259-27b6-9e19-7c1099b4eb17"), 0, "18cb7927-e365-4674-8f5a-6297a4a853f8", "Salma_Konopelski@gmail.com", false, false, null, null, null, "8RKPQYAeBd", "(612) 556-2924", false, null, false, "Stanford_Hackett91" },
                    { new Guid("f8711858-2b14-fea2-71be-a21a9018d64e"), 0, "8d36457a-47b7-4149-8d23-1d5ae13bfe38", "Guido.Hand@yahoo.com", false, false, null, null, null, "PQMyqzUVqr", "558.649.2523", false, null, false, "Dennis.Koch" }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("a8455337-7760-de54-1ee2-30a00af525b6"), new Guid("2099f552-ffdb-26fe-1794-dbf93c54c5ff") },
                    { new Guid("a695090c-7dd3-0ab7-5b8a-eac5e812abf6"), new Guid("289c2d25-c7a0-77ff-183e-18a7125a2f29") },
                    { new Guid("accff0b4-8f4b-e442-672a-eaa92d575f00"), new Guid("34cb91cc-6c3d-d537-a40d-fa22b0961c42") },
                    { new Guid("e11657ba-c2b3-8816-df4b-48961c744e6c"), new Guid("34f188c1-c8b9-91f8-ae65-9bf2d6c89690") },
                    { new Guid("05b2496d-4b97-5d66-a4f4-1589711598fb"), new Guid("3e334911-cf3b-2628-5870-44044d7d64a7") },
                    { new Guid("b8e73814-b3fd-9891-63f4-b9437945cb0d"), new Guid("44cead50-4140-c036-26d2-6578e1f71843") },
                    { new Guid("9a1d547e-5c57-9497-aa7f-51b8703035c6"), new Guid("4766c4a0-154f-e1e6-a0d3-ed17ec86ba85") },
                    { new Guid("ac51fd1b-5a9e-7e9c-b15a-00516f250498"), new Guid("4844c0f9-54ac-9679-988f-d0c51581b5e6") },
                    { new Guid("24d00437-ebdb-5d94-79b1-64b9c886f803"), new Guid("48492d38-0885-7ba0-1d88-2c62c9beda75") },
                    { new Guid("f6dec917-d6cf-c291-55d1-38236943acb1"), new Guid("66e84d42-5fb3-4210-d5b0-73ff8241ded4") },
                    { new Guid("1f0ad875-3db2-655a-d520-53ee05aa03b4"), new Guid("83bfc387-1e48-6a4e-16f3-e7624e540b5f") },
                    { new Guid("410bc498-59e2-abe2-c266-897e09fef780"), new Guid("8c3e9843-3144-e8fa-81a6-4f66b6579c8b") },
                    { new Guid("1053d85b-216d-9cf5-4d13-c39be47b2f72"), new Guid("94d03a65-a553-25b5-d0eb-11b374a82fce") },
                    { new Guid("dab5a86a-b551-d87e-b824-9becabe5d6e8"), new Guid("97fc08c0-3d15-bff0-1be3-c6b21bdb4b11") },
                    { new Guid("eeb5edb0-85f1-0bbd-f6cc-b94dbcf2f2fa"), new Guid("a750a6dd-f450-3766-a4a7-de59a5993cbf") },
                    { new Guid("bb487666-61ea-8e47-6aa4-bcf56ad1409f"), new Guid("abf03c0a-d1d1-66b7-4eea-66f7f2a13d47") },
                    { new Guid("542451ec-3906-95c7-204d-2c5f6519b52f"), new Guid("b5df1a76-8009-916f-5976-2501c4022fca") },
                    { new Guid("474552fe-7778-2f52-a1b7-fefc8e63b5fd"), new Guid("b668ab4e-4f9e-31b8-bd88-42209b49913c") },
                    { new Guid("b6770afb-b32e-2947-fb63-71fe5cf6c6f9"), new Guid("b9aa809c-09da-32e2-5b8e-cd5def532e7c") },
                    { new Guid("9c5aa587-4bdc-6e39-1025-a1d754208223"), new Guid("c1082a57-8437-459f-365d-139761feb6c8") },
                    { new Guid("3cd64297-02fb-acf2-ed5f-44301d3bf0bd"), new Guid("c32a08ce-8bed-425b-253e-cbee0b095431") },
                    { new Guid("8af418f7-c702-d12c-e426-1e8f5c2e4a37"), new Guid("cbf10dfe-24f7-55f1-0299-ff0ef73449e1") },
                    { new Guid("9d601d84-d56d-a5a2-a274-6ce4d8337fd5"), new Guid("e1686571-1067-e6af-2041-dad3bb63d618") },
                    { new Guid("71757008-286e-b029-7484-a90072c7d2e3"), new Guid("e540d6c1-d622-4d61-a54d-8d24c19427d9") },
                    { new Guid("9db732c1-1f29-3c58-0851-993ce39174b9"), new Guid("ec9b031c-16b5-0042-f02e-51f902d4d858") },
                    { new Guid("0fa6342a-f7b5-7274-e60d-e9240daf336d"), new Guid("edca8efc-66f9-19f0-a40c-1a9269f702c7") },
                    { new Guid("258b488c-ff1d-2f7a-6683-ac21a784240f"), new Guid("ef1ab6f5-8933-2069-ac83-bf1b51b6f0ce") },
                    { new Guid("82608cf2-2bfd-15db-2f96-8883d60cd483"), new Guid("faff0461-a967-d0c2-8a12-8c5f49b96d3e") },
                    { new Guid("65e17b23-7648-af09-f1e6-c16640060fed"), new Guid("fe0b3b43-a5c1-7eda-f8f6-8609e7a904ca") },
                    { new Guid("e5d45d01-7550-f076-cab0-123006c6b80d"), new Guid("ff04ff94-51ba-2f0d-80fc-a0ed8044c523") }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("462b82e1-ffca-41ee-1f2d-8cdb01e7c4b9"), new Guid("2099f552-ffdb-26fe-1794-dbf93c54c5ff") },
                    { new Guid("ec5290b8-2ac7-e38b-75d9-d2c7da9625e6"), new Guid("289c2d25-c7a0-77ff-183e-18a7125a2f29") },
                    { new Guid("1d7c4f34-3c9f-b048-efc6-eb8a830f8e80"), new Guid("34cb91cc-6c3d-d537-a40d-fa22b0961c42") },
                    { new Guid("c2d37ba8-8834-df3c-e3f8-4cecb9cabc87"), new Guid("34f188c1-c8b9-91f8-ae65-9bf2d6c89690") },
                    { new Guid("6e35ea7b-3046-53cc-5654-f440a75cd534"), new Guid("3e334911-cf3b-2628-5870-44044d7d64a7") },
                    { new Guid("6b699313-51e5-e3d3-f6e7-cacf33f689e9"), new Guid("44cead50-4140-c036-26d2-6578e1f71843") },
                    { new Guid("e38d779f-2a67-3bd0-a3ae-a64064fe89a0"), new Guid("4766c4a0-154f-e1e6-a0d3-ed17ec86ba85") },
                    { new Guid("94149291-7a66-c8c9-ec13-b1ccda4a61eb"), new Guid("4844c0f9-54ac-9679-988f-d0c51581b5e6") },
                    { new Guid("6c233a33-76a5-2ef0-9481-d41f3e611e8c"), new Guid("48492d38-0885-7ba0-1d88-2c62c9beda75") },
                    { new Guid("e6f573b7-2faf-f5ba-8d4b-1551263643bd"), new Guid("66e84d42-5fb3-4210-d5b0-73ff8241ded4") },
                    { new Guid("772c6425-8d07-2953-43e4-f7a87836092c"), new Guid("83bfc387-1e48-6a4e-16f3-e7624e540b5f") },
                    { new Guid("7d9f768d-6557-3272-a72f-286e7dd555e6"), new Guid("8c3e9843-3144-e8fa-81a6-4f66b6579c8b") },
                    { new Guid("8d45ddf6-4a9b-d79d-9f00-497367179f85"), new Guid("94d03a65-a553-25b5-d0eb-11b374a82fce") },
                    { new Guid("ed4d130d-3cb2-b3b6-e69b-cea25f50d9fd"), new Guid("97fc08c0-3d15-bff0-1be3-c6b21bdb4b11") },
                    { new Guid("f37f99b0-77dd-3158-107e-808b21ed2831"), new Guid("a750a6dd-f450-3766-a4a7-de59a5993cbf") },
                    { new Guid("2ce8ba98-e9b4-6317-a0cb-7dbdc26ed9f3"), new Guid("abf03c0a-d1d1-66b7-4eea-66f7f2a13d47") },
                    { new Guid("f1b413e6-66a4-4140-d27b-279035984bd1"), new Guid("b5df1a76-8009-916f-5976-2501c4022fca") },
                    { new Guid("61ba5681-384a-3513-c82d-b2cd6fcf7baa"), new Guid("b668ab4e-4f9e-31b8-bd88-42209b49913c") },
                    { new Guid("27c0c216-9ff0-3e55-142a-15b371bc8601"), new Guid("b9aa809c-09da-32e2-5b8e-cd5def532e7c") },
                    { new Guid("6d02218e-12cf-9f67-bc25-d36cd5cf2492"), new Guid("c1082a57-8437-459f-365d-139761feb6c8") },
                    { new Guid("b1f6260c-2ad4-6782-a80e-de0e41731686"), new Guid("c32a08ce-8bed-425b-253e-cbee0b095431") },
                    { new Guid("807bc7d0-7795-add0-b9d3-23c4ca0c55fa"), new Guid("cbf10dfe-24f7-55f1-0299-ff0ef73449e1") },
                    { new Guid("7b7dfc93-d37e-a88e-09ee-c48fdda6cf5b"), new Guid("e1686571-1067-e6af-2041-dad3bb63d618") },
                    { new Guid("2df48875-02d3-b88d-79c6-a641203144e8"), new Guid("e540d6c1-d622-4d61-a54d-8d24c19427d9") },
                    { new Guid("318c2817-8cda-dc6f-c0ba-8b12a5cf2b50"), new Guid("ec9b031c-16b5-0042-f02e-51f902d4d858") },
                    { new Guid("52ad612f-0ba0-8a59-8655-481e200df338"), new Guid("edca8efc-66f9-19f0-a40c-1a9269f702c7") },
                    { new Guid("cf061f7c-9a75-3c4b-795d-1011e7c27eb5"), new Guid("ef1ab6f5-8933-2069-ac83-bf1b51b6f0ce") },
                    { new Guid("857a79c3-db39-50b3-12ad-57e55b94d482"), new Guid("faff0461-a967-d0c2-8a12-8c5f49b96d3e") },
                    { new Guid("2d5fd0af-bbe4-fc58-cf69-b321cf67080c"), new Guid("fe0b3b43-a5c1-7eda-f8f6-8609e7a904ca") },
                    { new Guid("4081adaf-2988-ddd3-9958-d68ab3771976"), new Guid("ff04ff94-51ba-2f0d-80fc-a0ed8044c523") }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "IsActive", "IsPaid", "Reserved", "UserId" },
                values: new object[,]
                {
                    { new Guid("0a8c938b-3608-0246-7add-9982fddec864"), true, false, true, new Guid("8f1830c0-9b8c-bf07-813f-25739cf26f90") },
                    { new Guid("0dc7f4d9-4135-4dcb-ddb5-56569df9e90d"), true, true, true, new Guid("f01a84f4-6dfe-2407-f6af-c71b68974173") },
                    { new Guid("12769ff8-3a2d-cfd8-c754-da9075116ed6"), false, false, true, new Guid("f01a84f4-6dfe-2407-f6af-c71b68974173") },
                    { new Guid("1b2bedf5-4940-41fa-861c-1d6857e4b943"), true, false, false, new Guid("708a16d8-910d-2543-db7d-32594ba47c6f") },
                    { new Guid("201ec8ad-7cb9-9096-4b21-021a4be1e78f"), true, false, true, new Guid("c4cbb5ec-2e63-31ec-c980-59f551535590") },
                    { new Guid("2c866731-b98e-9ef2-43f0-1cda284f6ac3"), false, false, true, new Guid("3842a9f0-d9bf-0aa1-cc85-ba2dd070a999") },
                    { new Guid("411a1820-da59-096f-d1cd-77dfcb2e2585"), false, true, false, new Guid("2987d029-4252-4c79-f04a-80909b109331") },
                    { new Guid("4a8ca3c1-b0bd-0531-6136-6c346e3aa6b8"), false, true, false, new Guid("0128417b-7e6b-f459-ca04-7c86bfbc930a") },
                    { new Guid("4aff2649-cabf-7645-195c-b1fbf961023b"), false, false, true, new Guid("72640f98-cf6f-e877-52d3-e0098abba5f9") },
                    { new Guid("4bedebb0-915d-705f-ec9b-92e5a4d77eb4"), true, false, false, new Guid("708a16d8-910d-2543-db7d-32594ba47c6f") },
                    { new Guid("4c801acf-8d41-dc12-0bcb-4c3b3b24602d"), true, true, true, new Guid("8800543c-5af6-0644-03c0-e54cf488aba3") },
                    { new Guid("4cf2a8ab-bfd8-dcad-1261-732387f10534"), false, false, false, new Guid("b09cd1d5-5cad-df24-ca13-563649dc2b80") },
                    { new Guid("510908c2-d9c4-890d-3ee2-9ac4d5038d9b"), false, true, false, new Guid("2987d029-4252-4c79-f04a-80909b109331") },
                    { new Guid("56855211-2c40-d366-2bcf-dafd78381a0e"), false, true, false, new Guid("b4ef1c35-ce95-197d-05a8-127f369b6e48") },
                    { new Guid("76a8a284-61da-2ddb-d3a8-0589bab13380"), true, true, false, new Guid("80443df9-c356-72bf-b39e-28daea1b3679") },
                    { new Guid("80ed8fd6-7a8a-e4c8-6f6a-997c9231b3e9"), true, true, true, new Guid("aaf95722-04a7-d426-3cc4-e97e8904fafa") },
                    { new Guid("843df682-51c8-0b05-6ef1-0abbd324736a"), false, true, true, new Guid("eefdad93-f330-d940-5715-a5661b17d7ed") },
                    { new Guid("96d910ff-2a01-ff4e-6a9e-16bfe618ac6e"), false, true, true, new Guid("0128417b-7e6b-f459-ca04-7c86bfbc930a") },
                    { new Guid("a072b38c-eade-7de3-a319-a44ecde93eac"), true, true, false, new Guid("72a66c5f-b855-a55f-af7d-91658af4d4c4") },
                    { new Guid("a33a81b2-b7db-8dc5-23cf-659a9bced113"), true, true, true, new Guid("6b480acf-39d0-ef67-eb41-498ed84f530e") },
                    { new Guid("ab02eb2d-67dc-855a-f702-0935ec578ab8"), true, true, true, new Guid("8f1830c0-9b8c-bf07-813f-25739cf26f90") },
                    { new Guid("af0bbbfd-5b44-e573-06bd-e432b9a04861"), false, true, false, new Guid("07969861-f952-7db7-5a45-67cec06173a0") },
                    { new Guid("b4bfbf75-d644-2e3a-ddf6-3b7accb7f833"), false, true, false, new Guid("8800543c-5af6-0644-03c0-e54cf488aba3") },
                    { new Guid("b67d7947-1da0-e7be-2f1a-c0e0cf202f79"), true, false, true, new Guid("f2b09370-3b2c-c912-f76c-eaa4c8bbcec8") },
                    { new Guid("c779a084-572d-860c-4102-43bf1bb392df"), false, false, true, new Guid("37e54cf5-9238-22d4-38e8-afc8f7816363") },
                    { new Guid("d6103ab9-965c-d998-d7a4-5eedd82807a0"), true, false, false, new Guid("6b480acf-39d0-ef67-eb41-498ed84f530e") },
                    { new Guid("df8169ad-3900-8698-93b7-4331a716af3f"), false, false, true, new Guid("4bc02641-5034-7a8d-5e15-6e0cb0011ffb") },
                    { new Guid("e74ed0b0-38c4-f83d-14dd-24c480bfb420"), true, true, false, new Guid("ade592e2-9f63-0659-03dc-07b81d319272") },
                    { new Guid("ec43ce9f-b3fd-2598-d23c-f08841179eca"), false, false, false, new Guid("5982c69d-d336-ff62-7ec4-4847b7b9b7e5") },
                    { new Guid("fe836d30-b52a-c9d7-d120-cc80f23d9edc"), true, false, true, new Guid("37e54cf5-9238-22d4-38e8-afc8f7816363") }
                });

            migrationBuilder.InsertData(
                table: "Screenings",
                columns: new[] { "Id", "MovieId", "RoomId", "ScreeningStart" },
                values: new object[,]
                {
                    { new Guid("01e6c056-d47f-5fe2-440b-622ea1ca242c"), new Guid("ef1ab6f5-8933-2069-ac83-bf1b51b6f0ce"), new Guid("f8c22bf5-8cb8-7e19-be69-5243072025b7"), new TimeOnly(21, 24, 23, 934).Add(TimeSpan.FromTicks(454)) },
                    { new Guid("029e19fd-c7b0-3a96-298d-058c0d72a9e6"), new Guid("e540d6c1-d622-4d61-a54d-8d24c19427d9"), new Guid("41b831cd-1c74-a013-f156-61b204bf3723"), new TimeOnly(22, 2, 25, 601).Add(TimeSpan.FromTicks(4580)) },
                    { new Guid("087f873b-538f-81c4-279d-819caacdd1a7"), new Guid("a750a6dd-f450-3766-a4a7-de59a5993cbf"), new Guid("f8c22bf5-8cb8-7e19-be69-5243072025b7"), new TimeOnly(21, 27, 11, 230).Add(TimeSpan.FromTicks(9701)) },
                    { new Guid("0962d22a-b8a5-b715-6bbf-0d8e94ca8ffe"), new Guid("97fc08c0-3d15-bff0-1be3-c6b21bdb4b11"), new Guid("8f664c66-fca9-4f9e-e435-b291afa08c84"), new TimeOnly(21, 35, 30, 220).Add(TimeSpan.FromTicks(1752)) },
                    { new Guid("0d865be7-8aa4-39ac-20fe-f8911717a592"), new Guid("ef1ab6f5-8933-2069-ac83-bf1b51b6f0ce"), new Guid("1ed7ce11-edef-300c-202c-bdd8e0b75427"), new TimeOnly(21, 37, 46, 64).Add(TimeSpan.FromTicks(4477)) },
                    { new Guid("1bd03ec6-936c-d9d7-59bd-3fe1ca6bba94"), new Guid("e540d6c1-d622-4d61-a54d-8d24c19427d9"), new Guid("efb5ab4e-bc4f-6303-1f0f-75484f43ada4"), new TimeOnly(21, 34, 28, 702).Add(TimeSpan.FromTicks(6345)) },
                    { new Guid("3b6c24dd-e6c5-f149-461b-20288a9eec0d"), new Guid("34cb91cc-6c3d-d537-a40d-fa22b0961c42"), new Guid("46b288c1-a2bb-3822-0c8e-acaa557e221d"), new TimeOnly(22, 19, 28, 457).Add(TimeSpan.FromTicks(1359)) },
                    { new Guid("4108330c-dfb0-5499-5a8c-69d121a7f625"), new Guid("34f188c1-c8b9-91f8-ae65-9bf2d6c89690"), new Guid("ee397787-1c08-7738-6075-e36e42b18a9e"), new TimeOnly(22, 20, 22, 967).Add(TimeSpan.FromTicks(3936)) },
                    { new Guid("4727efaf-ee01-8ede-cdd1-43dd0d152cae"), new Guid("83bfc387-1e48-6a4e-16f3-e7624e540b5f"), new Guid("1ed7ce11-edef-300c-202c-bdd8e0b75427"), new TimeOnly(22, 18, 6, 402).Add(TimeSpan.FromTicks(381)) },
                    { new Guid("563a4f26-5e7e-c59a-2a6b-1fa2575907f6"), new Guid("66e84d42-5fb3-4210-d5b0-73ff8241ded4"), new Guid("1c1fbeff-4bde-3cfe-9996-3b7ceebbc512"), new TimeOnly(22, 16, 43, 906).Add(TimeSpan.FromTicks(934)) },
                    { new Guid("5723651b-3f05-e02a-57ea-f37744e12db9"), new Guid("ef1ab6f5-8933-2069-ac83-bf1b51b6f0ce"), new Guid("41b831cd-1c74-a013-f156-61b204bf3723"), new TimeOnly(21, 26, 30, 435).Add(TimeSpan.FromTicks(9648)) },
                    { new Guid("5b7edd50-bfa0-1bca-3e91-896e97ace20e"), new Guid("b5df1a76-8009-916f-5976-2501c4022fca"), new Guid("b4f6a130-823b-093b-7581-2e7361d2583f"), new TimeOnly(21, 59, 39, 726).Add(TimeSpan.FromTicks(7664)) },
                    { new Guid("694c053b-9293-af5e-2293-86201fffd652"), new Guid("abf03c0a-d1d1-66b7-4eea-66f7f2a13d47"), new Guid("8bf79c03-c104-2455-2685-943044ccfe94"), new TimeOnly(22, 13, 54, 64).Add(TimeSpan.FromTicks(8569)) },
                    { new Guid("698e76a8-27ca-8f41-c7b5-59088c63eb93"), new Guid("b668ab4e-4f9e-31b8-bd88-42209b49913c"), new Guid("1b7bc9e8-4016-b024-b403-4c40dbc12959"), new TimeOnly(22, 20, 22, 457).Add(TimeSpan.FromTicks(8776)) },
                    { new Guid("75347e5e-f022-6d11-14f3-c60a2800a55f"), new Guid("3e334911-cf3b-2628-5870-44044d7d64a7"), new Guid("1b7bc9e8-4016-b024-b403-4c40dbc12959"), new TimeOnly(21, 28, 57, 406).Add(TimeSpan.FromTicks(7325)) },
                    { new Guid("7f4b4446-cc64-0bf6-2c39-9d88e0fed4f0"), new Guid("abf03c0a-d1d1-66b7-4eea-66f7f2a13d47"), new Guid("1b7bc9e8-4016-b024-b403-4c40dbc12959"), new TimeOnly(21, 26, 10, 555).Add(TimeSpan.FromTicks(8210)) },
                    { new Guid("802221b2-7704-d265-5b47-eb06c866522f"), new Guid("fe0b3b43-a5c1-7eda-f8f6-8609e7a904ca"), new Guid("8f664c66-fca9-4f9e-e435-b291afa08c84"), new TimeOnly(22, 1, 40, 641).Add(TimeSpan.FromTicks(6086)) },
                    { new Guid("86b5f11c-76d6-3f89-9b69-3652801099db"), new Guid("e1686571-1067-e6af-2041-dad3bb63d618"), new Guid("9b963b4a-69b0-b7a5-200e-98257b33325a"), new TimeOnly(22, 18, 42, 814).Add(TimeSpan.FromTicks(21)) },
                    { new Guid("8b75fbd2-f214-eea8-44b2-4d0d737a8935"), new Guid("b5df1a76-8009-916f-5976-2501c4022fca"), new Guid("740413b7-63dc-4cbe-bc2e-4fde0b25d689"), new TimeOnly(21, 56, 26, 992).Add(TimeSpan.FromTicks(4045)) },
                    { new Guid("8b908ec7-8e3f-5d96-5847-f4c383e6714a"), new Guid("34f188c1-c8b9-91f8-ae65-9bf2d6c89690"), new Guid("fda90c93-c015-b2e9-2966-75756d16bcc6"), new TimeOnly(21, 51, 4, 540).Add(TimeSpan.FromTicks(3884)) },
                    { new Guid("a533fe97-f0db-10df-0028-cb14cd3479e2"), new Guid("e1686571-1067-e6af-2041-dad3bb63d618"), new Guid("1c1fbeff-4bde-3cfe-9996-3b7ceebbc512"), new TimeOnly(21, 25, 20, 976).Add(TimeSpan.FromTicks(6366)) },
                    { new Guid("aac99327-d13f-8d81-dedd-eae676ca34b6"), new Guid("ef1ab6f5-8933-2069-ac83-bf1b51b6f0ce"), new Guid("1f82f418-710b-38d8-c552-cc1bc4987269"), new TimeOnly(21, 49, 18, 216).Add(TimeSpan.FromTicks(5207)) },
                    { new Guid("af6c9e9b-01f1-96c1-09e6-70a9f49f46ff"), new Guid("abf03c0a-d1d1-66b7-4eea-66f7f2a13d47"), new Guid("8f664c66-fca9-4f9e-e435-b291afa08c84"), new TimeOnly(21, 50, 51, 374).Add(TimeSpan.FromTicks(3161)) },
                    { new Guid("b0425d5c-7c26-b35a-a34b-a51a27509119"), new Guid("97fc08c0-3d15-bff0-1be3-c6b21bdb4b11"), new Guid("c6fc2914-9ec2-7eec-fa69-0ebff49c9e90"), new TimeOnly(22, 17, 21, 836).Add(TimeSpan.FromTicks(8556)) },
                    { new Guid("c08f8d7e-8e29-0dad-fbe9-f7a813bc1d3d"), new Guid("34f188c1-c8b9-91f8-ae65-9bf2d6c89690"), new Guid("789026d4-f6ad-a9ed-179e-bfd0b3b20085"), new TimeOnly(21, 24, 53, 905).Add(TimeSpan.FromTicks(2947)) },
                    { new Guid("d4a5010f-e362-6130-8098-0b1f650270c7"), new Guid("44cead50-4140-c036-26d2-6578e1f71843"), new Guid("f5caee8c-e02f-2576-25ff-af5242b5daf4"), new TimeOnly(22, 20, 1, 655).Add(TimeSpan.FromTicks(7189)) },
                    { new Guid("d595d0ec-8a95-7511-6fc4-62a715b59264"), new Guid("2099f552-ffdb-26fe-1794-dbf93c54c5ff"), new Guid("8bf79c03-c104-2455-2685-943044ccfe94"), new TimeOnly(21, 43, 29, 4).Add(TimeSpan.FromTicks(3562)) },
                    { new Guid("dcdb6e66-17ae-6154-58e5-452501baa206"), new Guid("e540d6c1-d622-4d61-a54d-8d24c19427d9"), new Guid("de2d916c-7588-11be-95c5-ab2750ed62ce"), new TimeOnly(21, 34, 25, 557).Add(TimeSpan.FromTicks(7662)) },
                    { new Guid("e105f973-fbe0-025d-0446-97628d214087"), new Guid("e540d6c1-d622-4d61-a54d-8d24c19427d9"), new Guid("42c6a36b-1406-020c-ef8f-55d16fe5c3ee"), new TimeOnly(22, 17, 58, 923).Add(TimeSpan.FromTicks(8991)) },
                    { new Guid("f0f46b55-e529-7755-cf89-6a2dee8c3406"), new Guid("ff04ff94-51ba-2f0d-80fc-a0ed8044c523"), new Guid("912d048f-5d9e-6af0-1fcb-ad3ccb8be6b7"), new TimeOnly(21, 49, 20, 161).Add(TimeSpan.FromTicks(9321)) }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Number", "RoomId", "Row" },
                values: new object[,]
                {
                    { new Guid("03aa9997-4248-7c77-e2d6-db7a2897911e"), 1647788660, new Guid("8f664c66-fca9-4f9e-e435-b291afa08c84"), 1267777459 },
                    { new Guid("0a3f502a-2951-9adc-8c76-1e3edd741a68"), 2059508805, new Guid("aee15233-2afb-7164-f481-c7e3e2a0e84a"), 738576920 },
                    { new Guid("0d0ca35b-5383-a945-e23e-719e2e06c323"), 706195001, new Guid("f8c22bf5-8cb8-7e19-be69-5243072025b7"), 599285139 },
                    { new Guid("13b53e7e-0540-e204-add1-5498ec80343e"), -612974523, new Guid("1c1fbeff-4bde-3cfe-9996-3b7ceebbc512"), 1631887362 },
                    { new Guid("2fee94d2-c528-8bea-b633-1b71c2f6c446"), -1571241619, new Guid("b08d4b84-32c3-dbd2-5c11-2ad01f6ff2bf"), 935716325 },
                    { new Guid("384f2b65-d35b-bad3-1921-89c2f4e93c52"), -2050863111, new Guid("ee397787-1c08-7738-6075-e36e42b18a9e"), 79808503 },
                    { new Guid("417d4ee5-1c11-f125-58b4-68686c7af6c2"), 1275093376, new Guid("efb5ab4e-bc4f-6303-1f0f-75484f43ada4"), -1208413500 },
                    { new Guid("42c54497-8900-340e-8cfc-535b241c5b91"), -950278619, new Guid("912d048f-5d9e-6af0-1fcb-ad3ccb8be6b7"), -1036149524 },
                    { new Guid("59a8ba14-df02-bd05-0fcc-34af1cea972a"), -1203192874, new Guid("c6fc2914-9ec2-7eec-fa69-0ebff49c9e90"), -1900397031 },
                    { new Guid("5b2e2d9f-fc05-2dec-e34d-53f451702a00"), -564092701, new Guid("9b963b4a-69b0-b7a5-200e-98257b33325a"), 1231164916 },
                    { new Guid("5ec0c7a5-86e6-5029-55e2-888ef239a00b"), -1369967746, new Guid("fda90c93-c015-b2e9-2966-75756d16bcc6"), 656225273 },
                    { new Guid("60639cc0-2988-ff78-33c0-e4994cee3954"), -2138658213, new Guid("de2d916c-7588-11be-95c5-ab2750ed62ce"), -1919602934 },
                    { new Guid("618290f3-6104-4eff-a93b-4a47e832d87a"), 938195446, new Guid("912d048f-5d9e-6af0-1fcb-ad3ccb8be6b7"), 534068366 },
                    { new Guid("67b26774-1d95-6ec1-58a7-ccc9ae3298d9"), 1646647463, new Guid("de2d916c-7588-11be-95c5-ab2750ed62ce"), 1018114214 },
                    { new Guid("6c385d75-2fc9-ed78-3eff-c49f86123f72"), -1484758729, new Guid("ee397787-1c08-7738-6075-e36e42b18a9e"), -416821329 },
                    { new Guid("7a49cc73-0560-35e5-3931-6754923c52a1"), 1842112607, new Guid("55063b0a-3164-2d1e-f9c6-8764e0fa8f08"), 1218227057 },
                    { new Guid("83e1cbfe-e753-8bbc-7e26-4032c6e5f2a4"), 1454444153, new Guid("42c6a36b-1406-020c-ef8f-55d16fe5c3ee"), 1549638069 },
                    { new Guid("8735681b-f863-f42b-f43d-050c233ada8e"), -1069380838, new Guid("789026d4-f6ad-a9ed-179e-bfd0b3b20085"), 1042959654 },
                    { new Guid("b405b81f-1959-a430-c2e1-68647f2a8c12"), -963931330, new Guid("8bf79c03-c104-2455-2685-943044ccfe94"), -1282024039 },
                    { new Guid("b494197b-d97b-6f60-dccb-a498aa18c2f3"), -943153500, new Guid("8f664c66-fca9-4f9e-e435-b291afa08c84"), -975560780 },
                    { new Guid("b4c8d48e-c12b-d25d-5f03-3b19c5c5a652"), -272973675, new Guid("b08d4b84-32c3-dbd2-5c11-2ad01f6ff2bf"), 390291545 },
                    { new Guid("bae7cca1-a6d6-62d0-ee24-925c590adcab"), 1806306974, new Guid("f5caee8c-e02f-2576-25ff-af5242b5daf4"), 1644474476 },
                    { new Guid("bb35082f-f86a-c71e-27a9-a084c943a1f2"), 415412039, new Guid("b08d4b84-32c3-dbd2-5c11-2ad01f6ff2bf"), -1071197871 },
                    { new Guid("c21cea26-15ee-650c-b8ca-4ea563347dfe"), 555466122, new Guid("7ea05b04-e8b1-d3f2-90b2-c51c550417ec"), -1273628679 },
                    { new Guid("cef48df8-05d5-2b1f-7b3d-311c1ce6c382"), -544223226, new Guid("9b963b4a-69b0-b7a5-200e-98257b33325a"), 1511898212 },
                    { new Guid("d1b27c3a-eb45-e7e4-9582-90ed3f34fd7c"), -2056178624, new Guid("fda90c93-c015-b2e9-2966-75756d16bcc6"), 2110235062 },
                    { new Guid("d2534579-ee6e-d0df-4a8c-b88b4515cf3b"), 81268021, new Guid("cdca2681-c2b3-333d-0714-9b2d24e549ba"), -127012851 },
                    { new Guid("eca214b5-d869-6ede-01f8-829119ced79c"), 1907953259, new Guid("cdca2681-c2b3-333d-0714-9b2d24e549ba"), 480044020 },
                    { new Guid("f42f0c80-5931-073a-93da-4d7c5ba9a697"), 497168330, new Guid("f8c22bf5-8cb8-7e19-be69-5243072025b7"), 1265199178 },
                    { new Guid("fce9129c-e731-b863-d277-d64d8898532c"), -1920609982, new Guid("b08d4b84-32c3-dbd2-5c11-2ad01f6ff2bf"), 1161273758 }
                });

            migrationBuilder.InsertData(
                table: "ReservedSeats",
                columns: new[] { "Id", "ReservationId", "ScreeningId", "SeatId" },
                values: new object[,]
                {
                    { new Guid("04d7607e-a1a9-2177-0933-b4edcc739729"), new Guid("af0bbbfd-5b44-e573-06bd-e432b9a04861"), new Guid("01e6c056-d47f-5fe2-440b-622ea1ca242c"), new Guid("0d0ca35b-5383-a945-e23e-719e2e06c323") },
                    { new Guid("11df8346-9238-0067-aa1e-83af95933d76"), new Guid("a33a81b2-b7db-8dc5-23cf-659a9bced113"), new Guid("75347e5e-f022-6d11-14f3-c60a2800a55f"), new Guid("42c54497-8900-340e-8cfc-535b241c5b91") },
                    { new Guid("172cfff4-d42e-7d38-002c-155be1439aa0"), new Guid("a072b38c-eade-7de3-a319-a44ecde93eac"), new Guid("4727efaf-ee01-8ede-cdd1-43dd0d152cae"), new Guid("384f2b65-d35b-bad3-1921-89c2f4e93c52") },
                    { new Guid("1c6c17c7-373f-2b26-0520-5cf41a649fbc"), new Guid("ec43ce9f-b3fd-2598-d23c-f08841179eca"), new Guid("694c053b-9293-af5e-2293-86201fffd652"), new Guid("f42f0c80-5931-073a-93da-4d7c5ba9a697") },
                    { new Guid("2b803de8-ba1c-90b1-4e65-5f806e0cd02f"), new Guid("76a8a284-61da-2ddb-d3a8-0589bab13380"), new Guid("a533fe97-f0db-10df-0028-cb14cd3479e2"), new Guid("5ec0c7a5-86e6-5029-55e2-888ef239a00b") },
                    { new Guid("4fd76bd0-7f14-8d6f-ee98-cdaad2863354"), new Guid("4cf2a8ab-bfd8-dcad-1261-732387f10534"), new Guid("a533fe97-f0db-10df-0028-cb14cd3479e2"), new Guid("5b2e2d9f-fc05-2dec-e34d-53f451702a00") },
                    { new Guid("5dcfb1e6-3d67-99e6-676b-dc851ddf84cb"), new Guid("2c866731-b98e-9ef2-43f0-1cda284f6ac3"), new Guid("563a4f26-5e7e-c59a-2a6b-1fa2575907f6"), new Guid("5ec0c7a5-86e6-5029-55e2-888ef239a00b") },
                    { new Guid("672866bd-8aab-4ae0-9120-e28ccda938ed"), new Guid("1b2bedf5-4940-41fa-861c-1d6857e4b943"), new Guid("75347e5e-f022-6d11-14f3-c60a2800a55f"), new Guid("5ec0c7a5-86e6-5029-55e2-888ef239a00b") },
                    { new Guid("75484819-3bd1-9f9c-bee8-a3489851add2"), new Guid("4aff2649-cabf-7645-195c-b1fbf961023b"), new Guid("b0425d5c-7c26-b35a-a34b-a51a27509119"), new Guid("d2534579-ee6e-d0df-4a8c-b88b4515cf3b") },
                    { new Guid("7a2e1cf2-c09b-56e8-b86c-ccfd9ad734ac"), new Guid("4cf2a8ab-bfd8-dcad-1261-732387f10534"), new Guid("af6c9e9b-01f1-96c1-09e6-70a9f49f46ff"), new Guid("d2534579-ee6e-d0df-4a8c-b88b4515cf3b") },
                    { new Guid("7a67ef29-3456-3721-b6b3-4349f74105c2"), new Guid("b67d7947-1da0-e7be-2f1a-c0e0cf202f79"), new Guid("75347e5e-f022-6d11-14f3-c60a2800a55f"), new Guid("5b2e2d9f-fc05-2dec-e34d-53f451702a00") },
                    { new Guid("7c195ea9-a102-a0dc-7621-b0161815c43a"), new Guid("ab02eb2d-67dc-855a-f702-0935ec578ab8"), new Guid("4108330c-dfb0-5499-5a8c-69d121a7f625"), new Guid("6c385d75-2fc9-ed78-3eff-c49f86123f72") },
                    { new Guid("85391fb0-2536-c1e6-b216-e7aa52320cbc"), new Guid("a33a81b2-b7db-8dc5-23cf-659a9bced113"), new Guid("01e6c056-d47f-5fe2-440b-622ea1ca242c"), new Guid("83e1cbfe-e753-8bbc-7e26-4032c6e5f2a4") },
                    { new Guid("87825b8c-779e-0226-333c-5aff49278795"), new Guid("510908c2-d9c4-890d-3ee2-9ac4d5038d9b"), new Guid("b0425d5c-7c26-b35a-a34b-a51a27509119"), new Guid("f42f0c80-5931-073a-93da-4d7c5ba9a697") },
                    { new Guid("97c0d830-1fa1-f693-b6fe-e531fc8ac4be"), new Guid("4c801acf-8d41-dc12-0bcb-4c3b3b24602d"), new Guid("c08f8d7e-8e29-0dad-fbe9-f7a813bc1d3d"), new Guid("6c385d75-2fc9-ed78-3eff-c49f86123f72") },
                    { new Guid("9926eb49-bf2c-9b13-eabc-395b272d2658"), new Guid("4aff2649-cabf-7645-195c-b1fbf961023b"), new Guid("d595d0ec-8a95-7511-6fc4-62a715b59264"), new Guid("0d0ca35b-5383-a945-e23e-719e2e06c323") },
                    { new Guid("a153a215-8bad-fe7c-3c75-b7694b516c01"), new Guid("b4bfbf75-d644-2e3a-ddf6-3b7accb7f833"), new Guid("698e76a8-27ca-8f41-c7b5-59088c63eb93"), new Guid("5b2e2d9f-fc05-2dec-e34d-53f451702a00") },
                    { new Guid("b66806bb-30b1-2c77-5e86-2ed8096d60c2"), new Guid("ab02eb2d-67dc-855a-f702-0935ec578ab8"), new Guid("8b908ec7-8e3f-5d96-5847-f4c383e6714a"), new Guid("03aa9997-4248-7c77-e2d6-db7a2897911e") },
                    { new Guid("c529b8dd-3196-4df2-519c-f1cdff46d794"), new Guid("a33a81b2-b7db-8dc5-23cf-659a9bced113"), new Guid("af6c9e9b-01f1-96c1-09e6-70a9f49f46ff"), new Guid("5b2e2d9f-fc05-2dec-e34d-53f451702a00") },
                    { new Guid("c9bb1b9b-f598-be4d-014e-b97caf56fdf7"), new Guid("fe836d30-b52a-c9d7-d120-cc80f23d9edc"), new Guid("802221b2-7704-d265-5b47-eb06c866522f"), new Guid("13b53e7e-0540-e204-add1-5498ec80343e") },
                    { new Guid("cacda5af-4ef3-a603-99e7-3b4e4a324cad"), new Guid("b67d7947-1da0-e7be-2f1a-c0e0cf202f79"), new Guid("c08f8d7e-8e29-0dad-fbe9-f7a813bc1d3d"), new Guid("59a8ba14-df02-bd05-0fcc-34af1cea972a") },
                    { new Guid("d53839fb-6fe0-2aaa-576c-e2cd8f543072"), new Guid("ec43ce9f-b3fd-2598-d23c-f08841179eca"), new Guid("4108330c-dfb0-5499-5a8c-69d121a7f625"), new Guid("618290f3-6104-4eff-a93b-4a47e832d87a") },
                    { new Guid("d5493e88-cea8-afb2-8ca4-a67fa8c23205"), new Guid("4c801acf-8d41-dc12-0bcb-4c3b3b24602d"), new Guid("087f873b-538f-81c4-279d-819caacdd1a7"), new Guid("c21cea26-15ee-650c-b8ca-4ea563347dfe") },
                    { new Guid("d646b571-67f9-26ba-b852-956caae6fca8"), new Guid("fe836d30-b52a-c9d7-d120-cc80f23d9edc"), new Guid("698e76a8-27ca-8f41-c7b5-59088c63eb93"), new Guid("618290f3-6104-4eff-a93b-4a47e832d87a") },
                    { new Guid("dd5ba946-57f1-3711-46b1-ea5c3f951dd2"), new Guid("4cf2a8ab-bfd8-dcad-1261-732387f10534"), new Guid("8b908ec7-8e3f-5d96-5847-f4c383e6714a"), new Guid("60639cc0-2988-ff78-33c0-e4994cee3954") },
                    { new Guid("e2479093-4b85-2269-4cb2-e65329f058c1"), new Guid("1b2bedf5-4940-41fa-861c-1d6857e4b943"), new Guid("86b5f11c-76d6-3f89-9b69-3652801099db"), new Guid("5ec0c7a5-86e6-5029-55e2-888ef239a00b") },
                    { new Guid("ef25cfbb-8871-56c9-044e-6f5690f55431"), new Guid("4a8ca3c1-b0bd-0531-6136-6c346e3aa6b8"), new Guid("d4a5010f-e362-6130-8098-0b1f650270c7"), new Guid("b494197b-d97b-6f60-dccb-a498aa18c2f3") },
                    { new Guid("f46d29e2-87d7-088d-627a-f60259e8f0ab"), new Guid("2c866731-b98e-9ef2-43f0-1cda284f6ac3"), new Guid("7f4b4446-cc64-0bf6-2c39-9d88e0fed4f0"), new Guid("b405b81f-1959-a430-c2e1-68647f2a8c12") },
                    { new Guid("fbd03803-dac9-283a-76a7-fa51075fb894"), new Guid("201ec8ad-7cb9-9096-4b21-021a4be1e78f"), new Guid("4727efaf-ee01-8ede-cdd1-43dd0d152cae"), new Guid("2fee94d2-c528-8bea-b633-1b71c2f6c446") },
                    { new Guid("fda2df4e-3512-667b-a2a6-3262feb9088f"), new Guid("2c866731-b98e-9ef2-43f0-1cda284f6ac3"), new Guid("7f4b4446-cc64-0bf6-2c39-9d88e0fed4f0"), new Guid("6c385d75-2fc9-ed78-3eff-c49f86123f72") }
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
