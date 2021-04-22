using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Token);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Promocodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    AvailableFrom = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    AvailableTill = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promocodes_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPromocode",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PromocodeId = table.Column<int>(type: "int", nullable: false),
                    DateActivated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPromocode", x => new { x.PromocodeId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserPromocode_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPromocode_Promocodes_PromocodeId",
                        column: x => x.PromocodeId,
                        principalTable: "Promocodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02994cf0–3422–5cfe-erye-62f706d98cf6", 0, "28211ab4-fcb1-4fff-a7e6-e430252ca0bc", "test@test.com", true, "Test", "User", false, null, null, "test_user@optionone.com", "AQAAAAEAACcQAAAAEKXcntgVAy7fYEqiU3Mf6W0jydmixQkrC6nmfna7/XVXhwE7a5CsPHHpf70Et7EwNw==", null, false, "b66ffb6f-6305-47ea-ae89-afc173f5a87b", false, "test_user@optionone.com" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 19, "Consequatur esse alias et quia. Rerum non voluptates ipsum non iusto. Id voluptatem et error ad. Alias dolorum qui ipsam dolore vitae. Sit deleniti culpa beatae minima ea dolorem recusandae. Soluta accusamus consequatur et voluptas dolorem repudiandae harum perferendis.", "DuBuque LLC" },
                    { 18, "Voluptas natus molestiae excepturi commodi saepe. Nemo tenetur fugiat nulla ad sed aut. Facilis voluptate laudantium soluta inventore. Laboriosam nesciunt minima numquam et voluptatem illum voluptatem. Ipsa et quae illo sint voluptate reprehenderit quam amet sunt. Adipisci sequi repellat numquam perspiciatis rerum sed cum illum voluptatem.\n\nMaxime est et. Ratione ullam placeat et quisquam quis. Temporibus omnis incidunt ratione explicabo officiis magnam maiores ad aut. Perspiciatis sit nesciunt. Tempore minus ratione.", "Koelpin, Pacocha and Buckridge" },
                    { 17, "Qui est atque rerum nesciunt eos pariatur atque. Delectus qui recusandae omnis laudantium rem quas aut fugiat. Illum dicta magni.", "Klein Group" },
                    { 16, "Ut quo omnis fugiat rerum eius qui ea et occaecati. Qui quis velit aliquam minima quas corporis. Qui voluptas quae qui harum saepe nemo perspiciatis nesciunt. Aspernatur aut rem exercitationem reiciendis voluptate expedita quis et. Nesciunt ab sint qui.\n\nPlaceat dolor exercitationem impedit qui voluptas earum. Ut sed et perferendis magni itaque sit cum nostrum. Voluptas perspiciatis et quis nemo autem mollitia. Nihil quia nobis assumenda dolore laudantium nisi perferendis qui non.", "Bradtke, Glover and Franecki" },
                    { 15, "Quaerat sunt ad. Id dolorum animi incidunt. Placeat voluptas eos consequuntur eius quia rerum.\n\nRepellendus incidunt quis eaque quia repudiandae consequatur eius vitae. Rerum autem dolores. Harum qui autem. Debitis ducimus repellat sequi suscipit et dolores.", "Kohler - O'Keefe" },
                    { 14, "Laborum aliquid labore sit nobis odio. Rerum quia odit tempora soluta quis. Et consequatur sit provident distinctio temporibus.\n\nEt fugiat sapiente at qui autem quia omnis natus dolorem. Fugit quo laboriosam est deserunt repudiandae inventore natus. Voluptatem mollitia optio fugiat quidem architecto voluptatem soluta minus. Itaque exercitationem architecto quo molestiae voluptate quis eum ipsa.", "Pfeffer, Bergstrom and Hackett" },
                    { 13, "Ad ullam ad nam ut reprehenderit unde. Quasi voluptas minima molestias aperiam aut ipsum. Accusantium doloribus ad reiciendis nobis aut et ullam libero molestiae. Tempora harum similique earum nemo sint mollitia repellat enim. Consequatur minus qui qui non voluptatibus dolor cum.\n\nVoluptatibus nisi architecto impedit quia odio facere voluptas reprehenderit et. Asperiores consequatur perspiciatis quia delectus et dolorem aut doloribus iusto. Vero nemo sit quaerat magni nesciunt facere ut aliquam fuga. Voluptatum eos aut natus eos dolorum accusamus omnis possimus. Ducimus eligendi perferendis molestiae mollitia et delectus. Ex cumque et sint consequatur atque.", "Rice and Sons" },
                    { 12, "Ut sit eos corrupti quis totam et. Qui et consequatur molestiae ut aliquam sit. Non nostrum tenetur et. Occaecati vitae quod non cum. Possimus facilis adipisci veniam minima autem accusantium.\n\nSequi magnam dolor voluptates cumque sapiente consequatur ut numquam. Vel quaerat explicabo velit aut id soluta corporis quaerat sit. Sed ad est itaque tempore. Provident consequatur provident illo rerum a nihil maiores a excepturi.", "Ankunding - Barrows" },
                    { 20, "Et aut hic cum modi aspernatur possimus neque. Quam laudantium harum eum saepe aut. Vel tenetur nisi non natus velit sed. Impedit molestias corporis ullam qui ut voluptatem ea labore.", "Murray, Herzog and Zieme" },
                    { 11, "Rem delectus placeat ut aut est. Optio a iure sapiente corporis iure mollitia. Et veritatis enim sint totam consequatur. Delectus quisquam ut provident explicabo ad voluptatem rerum ea sit. At inventore beatae voluptas in accusantium quae.\n\nQuia ipsam repudiandae aut. Quo sunt perferendis id et vel magni. Sed repellat accusantium commodi aliquid sint ad.", "Schmidt - Hodkiewicz" },
                    { 9, "Temporibus eius architecto. Dolorum quia perspiciatis. Consequatur soluta voluptate ut. Veritatis quibusdam blanditiis. Ad tenetur tempora dolores consequatur officiis. Delectus ut dicta aut dolores distinctio.\n\nExplicabo id sunt. Sit veniam vel. Aut soluta eos sit voluptatem. Repudiandae eum officiis dolorem veritatis officiis sunt natus a. Nisi mollitia veritatis est sunt sunt harum ut at. Qui voluptas corrupti nihil consequuntur.", "Leuschke Inc" },
                    { 8, "Velit quidem suscipit. Quia quo porro architecto nam et ratione debitis accusamus est. Voluptatem at reiciendis nam. Distinctio aut tempora. Similique nihil amet. Sed et voluptatibus sed eveniet nihil odit eos repellendus nihil.\n\nRerum officiis rerum sequi repellat rerum provident facilis omnis. Aut sunt aut fugiat. Nemo voluptate enim et et. Consequatur accusamus aut tempore doloremque reiciendis ducimus libero.", "Shields - Lueilwitz" },
                    { 7, "Id eum quisquam. Provident distinctio assumenda ducimus sint dolores. Cumque distinctio impedit. Rerum omnis aut qui qui ea esse et.", "O'Keefe - Barton" },
                    { 6, "Reiciendis voluptatem non. Cumque asperiores tenetur totam quisquam impedit error tenetur. Consectetur sint culpa harum et libero. Iure ipsam odio unde autem ratione amet. Facilis voluptatem nostrum rerum odio iste rerum quis nihil.", "Block - McCullough" },
                    { 5, "Reprehenderit asperiores in officiis consequatur veritatis rerum et cupiditate sint. Ex accusantium quia vero eum. Qui tempore et est culpa.", "Rolfson Group" },
                    { 4, "Dolore sit quia ut sequi sed quo et nisi. Sed culpa quis sit accusantium consequatur. Dolores reiciendis nihil optio fuga et.", "Bahringer - Spinka" },
                    { 3, "Voluptate officia dolores quos sit eveniet eius unde eos ea. Ut facere exercitationem in praesentium ipsa quia. Unde et error.\n\nEt dicta error explicabo facilis impedit. Et dignissimos velit quo. Debitis libero nemo aut quod nihil. Omnis quasi non. Voluptatem hic saepe voluptas est necessitatibus.", "Schowalter - Ankunding" },
                    { 2, "Voluptas perspiciatis autem. Velit officiis illo ut dolorum fugiat sed. Accusamus quas quo dolores odio quia voluptates corporis dolor dolorum. Sint dolorem autem cupiditate ullam et ipsa autem neque rerum. A aut non voluptates nobis minima eius et cupiditate.", "Ullrich, Bartell and Osinski" },
                    { 10, "Perspiciatis eius ipsum illo. Aut libero mollitia hic voluptatum provident omnis temporibus. Id modi neque labore non quae sint deleniti. Expedita officia saepe dolorem cumque debitis velit rerum iusto quas.", "Koepp LLC" },
                    { 1, "Quae natus minima. Quibusdam sint nemo odio aspernatur sequi enim sequi ratione sit. Reiciendis omnis qui.", "Luettgen Inc" }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 4, 21, 4, 44, 49, 731, DateTimeKind.Local).AddTicks(1318), new DateTime(2021, 4, 21, 4, 20, 20, 952, DateTimeKind.Local).AddTicks(6195), "wgopcwjk", "Sed qui voluptatem reiciendis ipsa omnis velit vitae sit.\nFugit ut porro autem praesentium impedit.\nIn aut reprehenderit reprehenderit.", 2, true },
                    { 204, new DateTime(2021, 4, 20, 18, 46, 38, 345, DateTimeKind.Local).AddTicks(8663), new DateTime(2021, 4, 7, 16, 7, 11, 945, DateTimeKind.Local).AddTicks(7701), "xunqucaw", "Sed qui quis consequatur minus voluptate.\nConsequuntur fuga deleniti culpa eveniet ut eligendi quia enim.\nAutem esse architecto consectetur dolorem qui voluptates et.\nAut officiis ut distinctio sed est sed.\nOfficia alias veritatis quam porro iusto beatae accusantium.\nDelectus corporis saepe ullam non expedita repellendus voluptas rem.", 15, true },
                    { 203, new DateTime(2020, 12, 13, 16, 21, 10, 857, DateTimeKind.Local).AddTicks(1039), new DateTime(2020, 6, 16, 14, 5, 10, 855, DateTimeKind.Local).AddTicks(2940), "auablrjrk", "Sed temporibus qui.", 15, true },
                    { 202, new DateTime(2021, 4, 20, 18, 46, 38, 345, DateTimeKind.Local).AddTicks(8328), new DateTime(2021, 4, 21, 0, 59, 8, 547, DateTimeKind.Local).AddTicks(862), "ausvtcbuvl", "Accusamus sit earum aliquid atque.", 15, true },
                    { 201, new DateTime(2021, 4, 21, 12, 21, 41, 674, DateTimeKind.Local).AddTicks(9155), new DateTime(2021, 4, 21, 9, 55, 56, 158, DateTimeKind.Local).AddTicks(3572), "ynhdvblvvpm", "Aliquam soluta ut facilis facere ipsam.", 15, true },
                    { 200, new DateTime(2021, 4, 20, 18, 46, 38, 345, DateTimeKind.Local).AddTicks(8188), new DateTime(2020, 4, 27, 6, 0, 1, 459, DateTimeKind.Local).AddTicks(9430), "nbfzwst", "Sit odit dolor consequatur possimus quis placeat fuga. Recusandae laudantium omnis consectetur. Laboriosam aspernatur qui.", 15, true },
                    { 199, new DateTime(2021, 4, 20, 18, 46, 38, 345, DateTimeKind.Local).AddTicks(8055), new DateTime(2021, 4, 21, 1, 11, 56, 839, DateTimeKind.Local).AddTicks(6130), "gucxep", "Tenetur et nihil nulla dicta repellendus aut. Et cum omnis. Quisquam qui rerum non ipsam vero explicabo doloribus ea. Dolore animi et minima. Id aliquam asperiores. Dolorem reprehenderit earum ut autem deserunt numquam.", 15, true },
                    { 205, new DateTime(2021, 4, 21, 14, 1, 54, 406, DateTimeKind.Local).AddTicks(5560), new DateTime(2020, 10, 7, 7, 16, 34, 353, DateTimeKind.Local).AddTicks(9885), "pywzyx", "Quia magnam ad.\nReiciendis asperiores dolorem ut et id aliquid et.\nNumquam atque suscipit et aliquid iusto unde omnis vero.\nExpedita cupiditate fugiat ratione dolorem at accusantium velit.", 15, true },
                    { 198, new DateTime(2021, 4, 20, 18, 46, 38, 345, DateTimeKind.Local).AddTicks(7810), new DateTime(2021, 4, 21, 16, 0, 34, 591, DateTimeKind.Local).AddTicks(9762), "cfjfxd", "Laborum veniam excepturi eum dolorem sequi dolorem magni soluta.\nQui quos modi ullam veritatis.", 15, true },
                    { 196, new DateTime(2021, 4, 21, 13, 4, 5, 705, DateTimeKind.Local).AddTicks(5942), new DateTime(2021, 3, 9, 8, 18, 20, 182, DateTimeKind.Local).AddTicks(893), "qgqfwrtnmd", "Et nisi ex at enim.\nNulla in et adipisci ullam dignissimos.\nMinima eum est sapiente soluta dolor aliquam fugiat voluptates voluptatum.\nEius totam et repellat aut deleniti rerum ab eligendi.\nOdit voluptatem alias ipsa.", 14, true },
                    { 195, new DateTime(2020, 7, 17, 5, 42, 48, 783, DateTimeKind.Local).AddTicks(4715), new DateTime(2020, 5, 28, 22, 4, 52, 872, DateTimeKind.Local).AddTicks(2610), "sceselugmsai", "Laboriosam non impedit voluptas vero adipisci et.\nMinima animi voluptatibus est sunt laborum incidunt vitae eum.\nEaque ipsa quae vero omnis aut.\nCupiditate ut est.\nMolestiae sit unde voluptas sint sapiente.\nRepellendus iure et.", 14, true },
                    { 194, new DateTime(2021, 4, 20, 18, 46, 38, 341, DateTimeKind.Local).AddTicks(7377), new DateTime(2020, 5, 2, 17, 54, 19, 709, DateTimeKind.Local).AddTicks(8377), "zdurjjknyzz", "Id earum nesciunt cum ullam sit. Quo culpa impedit autem. Eos voluptatem dolorem reiciendis ut accusamus. Ut magnam sit nesciunt repudiandae velit in voluptatibus. Asperiores assumenda sequi aperiam voluptatum sequi dolores nemo repellendus. Sed laudantium nam enim.", 14, true },
                    { 193, new DateTime(2021, 4, 20, 18, 46, 38, 341, DateTimeKind.Local).AddTicks(7145), new DateTime(2020, 5, 12, 5, 18, 29, 856, DateTimeKind.Local).AddTicks(1957), "ivljkxdhfcg", "Officia similique recusandae qui ea molestiae voluptas eos tenetur odio.", 14, true },
                    { 192, new DateTime(2021, 4, 20, 18, 46, 38, 341, DateTimeKind.Local).AddTicks(7059), new DateTime(2021, 4, 21, 7, 24, 56, 751, DateTimeKind.Local).AddTicks(9131), "npgydmwv", "Id quia ullam omnis ut voluptate aspernatur molestias magnam.\nQuia nobis sed.\nEveniet commodi fuga dolores dolorum alias numquam et.\nEarum at dolores enim ratione quasi libero earum officiis.", 14, true },
                    { 191, new DateTime(2021, 4, 20, 18, 46, 38, 341, DateTimeKind.Local).AddTicks(6875), new DateTime(2021, 1, 18, 14, 9, 17, 668, DateTimeKind.Local).AddTicks(2714), "cqkopq", "Sit aliquid ut ea omnis incidunt. Fuga consequatur ipsa omnis vel. Perferendis voluptatem et atque amet eaque quod. Et similique dolores sit voluptatum blanditiis qui eius ut. Non assumenda nihil sit doloremque aut officia.", 14, true },
                    { 197, new DateTime(2021, 4, 20, 22, 31, 22, 361, DateTimeKind.Local).AddTicks(257), new DateTime(2020, 6, 29, 16, 58, 53, 425, DateTimeKind.Local).AddTicks(6897), "kjvnmylntwpq", "Similique quia nemo magnam facere et ipsum et nobis. At sit veniam porro recusandae nihil quam praesentium culpa praesentium. Consectetur a esse aspernatur aliquam libero consequatur. Ea voluptate accusantium adipisci consequuntur unde. Maxime sunt consequatur dicta ut voluptatem magni animi et.", 15, true },
                    { 206, new DateTime(2021, 4, 21, 15, 38, 29, 829, DateTimeKind.Local).AddTicks(2589), new DateTime(2020, 6, 13, 14, 0, 45, 782, DateTimeKind.Local).AddTicks(4075), "uarnuky", "Harum debitis ut quaerat hic.\nVoluptatem similique dolorum dolores qui nulla repellat.\nDeserunt consectetur sequi odio illo soluta.\nVeniam magnam asperiores nam occaecati eos sit et et sunt.\nMolestiae autem modi.", 15, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 207, new DateTime(2020, 11, 14, 6, 4, 53, 604, DateTimeKind.Local).AddTicks(4296), new DateTime(2020, 6, 5, 12, 7, 1, 776, DateTimeKind.Local).AddTicks(6280), "rfyafypg", "Molestiae ut fuga.\nMollitia molestiae optio recusandae nam autem natus.\nEsse sed ut.\nQuia eius qui temporibus voluptate reiciendis.\nSunt omnis id quos nam qui voluptatem voluptatibus veritatis.", 15 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 208, new DateTime(2020, 8, 16, 5, 10, 15, 798, DateTimeKind.Local).AddTicks(8477), new DateTime(2021, 4, 21, 0, 16, 6, 241, DateTimeKind.Local).AddTicks(2634), "oihbdenv", "Ipsa molestiae rerum et ducimus. Illo assumenda vero itaque doloremque sed. Reprehenderit et id voluptatem quo. Et alias debitis neque eius quasi.", 15, true },
                    { 223, new DateTime(2021, 4, 20, 18, 46, 38, 348, DateTimeKind.Local).AddTicks(4943), new DateTime(2021, 4, 21, 18, 32, 18, 317, DateTimeKind.Local).AddTicks(5938), "njorc", "Tempore voluptate est officiis sunt accusamus quia.\nOdit dolores enim sit exercitationem id rerum.\nEt non velit ea aliquam odit debitis mollitia repellat quas.\nNatus consequuntur et cumque nihil voluptatum impedit velit corrupti recusandae.\nEa delectus autem.", 16, true },
                    { 222, new DateTime(2020, 6, 19, 1, 14, 59, 942, DateTimeKind.Local).AddTicks(1501), new DateTime(2021, 4, 21, 0, 11, 16, 90, DateTimeKind.Local).AddTicks(8323), "sgtndbridfa", "Omnis voluptatum dolor laborum corrupti quam. Maiores porro explicabo. Quis ipsum deserunt. Recusandae tempore sint autem et sed. Officiis eveniet impedit doloribus quos.", 16, true },
                    { 221, new DateTime(2021, 4, 20, 18, 46, 38, 348, DateTimeKind.Local).AddTicks(4547), new DateTime(2021, 2, 23, 3, 57, 21, 616, DateTimeKind.Local).AddTicks(1949), "eesra", "sint", 16, true },
                    { 220, new DateTime(2021, 4, 20, 23, 24, 59, 75, DateTimeKind.Local).AddTicks(4149), new DateTime(2020, 10, 11, 21, 0, 34, 482, DateTimeKind.Local).AddTicks(1753), "uczytcklwsdi", "Delectus molestiae libero.\nVoluptas doloremque assumenda voluptates et ut inventore aspernatur labore.\nNemo architecto fugit amet laudantium cupiditate mollitia sed quo ea.\nAliquam rerum est.\nRem sunt fugiat beatae.", 16, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 219, new DateTime(2021, 4, 20, 18, 46, 38, 348, DateTimeKind.Local).AddTicks(4307), new DateTime(2021, 4, 20, 23, 22, 0, 955, DateTimeKind.Local).AddTicks(2998), "qgzbonz", "Aut temporibus dolores explicabo vel sunt esse consequatur ea at. Nam occaecati eos expedita explicabo et. Harum ex ut quia soluta. Libero qui numquam est. Officia earum animi et praesentium.", 16 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 218, new DateTime(2020, 11, 9, 15, 22, 34, 610, DateTimeKind.Local).AddTicks(7128), new DateTime(2020, 9, 18, 23, 54, 53, 842, DateTimeKind.Local).AddTicks(8702), "xjdlu", "nostrum", 16, true },
                    { 217, new DateTime(2021, 4, 20, 18, 46, 38, 348, DateTimeKind.Local).AddTicks(4071), new DateTime(2021, 4, 20, 23, 12, 4, 15, DateTimeKind.Local).AddTicks(4843), "irsqu", "Ipsum ea voluptas aut ut laborum sapiente eum.\nAut optio dolores fuga.\nConsequuntur velit eius animi repudiandae molestiae laborum magnam.\nQuidem sunt dolores ea libero iure eius ad aut et.\nEst omnis temporibus tenetur harum et.\nAspernatur enim ut earum animi atque.", 16, true },
                    { 216, new DateTime(2021, 4, 21, 3, 4, 3, 583, DateTimeKind.Local).AddTicks(522), new DateTime(2021, 4, 20, 21, 33, 53, 493, DateTimeKind.Local).AddTicks(3111), "mbrwihxbykou", "Sit et iure enim perspiciatis quod fugit ad libero id.\nVoluptas sunt voluptas inventore porro quae sit rerum.\nIste delectus eveniet.", 16, true },
                    { 215, new DateTime(2021, 4, 21, 10, 53, 33, 405, DateTimeKind.Local).AddTicks(689), new DateTime(2021, 1, 7, 3, 36, 51, 71, DateTimeKind.Local).AddTicks(7424), "rshdrgnvo", "Et reprehenderit ullam ipsum. Corporis cupiditate quisquam ut omnis. Nisi quo quia dignissimos eos deserunt mollitia facilis. Qui harum pariatur iste illo illo quidem sint maiores.", 16, true },
                    { 214, new DateTime(2020, 8, 25, 10, 52, 10, 120, DateTimeKind.Local).AddTicks(7690), new DateTime(2020, 12, 5, 23, 26, 13, 210, DateTimeKind.Local).AddTicks(7754), "bnllcbxon", "Tempora reiciendis repellat veniam eveniet sint aut aspernatur.\nIncidunt ut et.\nAut nesciunt non ut.\nSit corporis dolorem molestias maxime.\nHarum omnis sed voluptatibus.", 16, true },
                    { 213, new DateTime(2021, 4, 21, 11, 5, 35, 965, DateTimeKind.Local).AddTicks(1811), new DateTime(2021, 4, 20, 19, 53, 32, 546, DateTimeKind.Local).AddTicks(5898), "oudxp", "nostrum", 16, true },
                    { 212, new DateTime(2021, 4, 20, 21, 24, 20, 181, DateTimeKind.Local).AddTicks(8954), new DateTime(2021, 4, 20, 20, 55, 33, 230, DateTimeKind.Local).AddTicks(7314), "wfgerfgn", "quasi", 16, true },
                    { 211, new DateTime(2021, 4, 21, 3, 40, 33, 286, DateTimeKind.Local).AddTicks(977), new DateTime(2021, 4, 20, 22, 21, 3, 355, DateTimeKind.Local).AddTicks(654), "xallkrr", "Magni dolorem voluptatem maxime cum quia laboriosam autem.", 16, true },
                    { 210, new DateTime(2021, 1, 12, 14, 49, 39, 365, DateTimeKind.Local).AddTicks(1053), new DateTime(2021, 1, 3, 15, 23, 20, 203, DateTimeKind.Local).AddTicks(9950), "etrousp", "et", 16, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[,]
                {
                    { 209, new DateTime(2020, 8, 21, 19, 40, 16, 580, DateTimeKind.Local).AddTicks(397), new DateTime(2021, 4, 21, 18, 30, 43, 420, DateTimeKind.Local).AddTicks(1377), "ydotx", "Omnis atque corrupti ut aut tenetur.", 16 },
                    { 190, new DateTime(2020, 9, 13, 4, 39, 41, 515, DateTimeKind.Local).AddTicks(4053), new DateTime(2020, 6, 4, 11, 22, 25, 954, DateTimeKind.Local).AddTicks(9384), "kobvuwekivjj", "rerum", 14 }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 189, new DateTime(2021, 4, 21, 13, 42, 19, 446, DateTimeKind.Local).AddTicks(8873), new DateTime(2021, 1, 8, 7, 6, 20, 553, DateTimeKind.Local).AddTicks(6179), "mzykalp", "Ipsam sed omnis suscipit. Odit quam labore tempora velit. Iure commodi provident quo.", 14, true },
                    { 188, new DateTime(2020, 5, 14, 9, 39, 34, 832, DateTimeKind.Local).AddTicks(7679), new DateTime(2021, 4, 20, 19, 36, 33, 562, DateTimeKind.Local).AddTicks(597), "gghinxemw", "Ipsum distinctio dolorem neque non omnis numquam quas eveniet quo.\nEa consequatur at fuga qui pariatur velit.\nIn a tempora dolore dolores.\nHarum molestiae quae quaerat culpa quidem omnis accusantium.\nPlaceat quia et.\nAlias consectetur perferendis deserunt optio voluptate nihil.", 14, true },
                    { 187, new DateTime(2021, 4, 20, 20, 30, 41, 639, DateTimeKind.Local).AddTicks(2080), new DateTime(2021, 2, 2, 21, 33, 49, 300, DateTimeKind.Local).AddTicks(2590), "yyiagj", "Rerum voluptate ipsam et. Qui quos vel. Hic molestiae sapiente. Ab quas dolores saepe alias sint.", 14, true },
                    { 167, new DateTime(2021, 4, 21, 2, 27, 30, 574, DateTimeKind.Local).AddTicks(1061), new DateTime(2021, 4, 21, 11, 4, 18, 787, DateTimeKind.Local).AddTicks(8262), "evnfsjxwi", "Voluptas nihil non ab quia architecto non aperiam culpa nihil.\nDistinctio a sit molestias aliquid non deserunt ut.\nLaudantium eos ut animi.\nTemporibus laborum cum culpa.", 13, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 166, new DateTime(2021, 4, 20, 18, 46, 38, 338, DateTimeKind.Local).AddTicks(9084), new DateTime(2021, 4, 8, 22, 26, 50, 519, DateTimeKind.Local).AddTicks(6762), "njsekonwcji", "Quo reiciendis fuga quia.\nVoluptatibus molestiae beatae molestiae est.\nIpsam eaque deleniti.\nNam fuga distinctio harum quia.", 13 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 165, new DateTime(2021, 4, 21, 12, 23, 34, 278, DateTimeKind.Local).AddTicks(5984), new DateTime(2021, 4, 20, 19, 58, 36, 872, DateTimeKind.Local).AddTicks(6254), "ilrsvm", "Laboriosam et quos illum voluptatum fuga numquam voluptatem harum. Voluptate error aut tempora voluptas placeat non quia. Aperiam odio voluptatem sed voluptas consequatur nesciunt.", 13, true },
                    { 164, new DateTime(2021, 4, 20, 23, 19, 39, 825, DateTimeKind.Local).AddTicks(8927), new DateTime(2021, 4, 12, 5, 5, 13, 909, DateTimeKind.Local).AddTicks(9800), "puopyqvz", "asperiores", 13, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[] { 163, new DateTime(2021, 4, 20, 18, 46, 38, 338, DateTimeKind.Local).AddTicks(8744), new DateTime(2020, 9, 24, 20, 12, 11, 645, DateTimeKind.Local).AddTicks(115), "zhhegmgse", "Fugit eius ratione non veniam quidem suscipit sunt. Dolore at vitae dolor quisquam a dolorem officiis magnam omnis. Eos ex possimus neque ad quo libero voluptas non. Nam quae sed animi est suscipit quia. Inventore repellendus ut tempore et minus odio modi maiores excepturi. Quasi fugiat itaque quia eaque assumenda omnis.", 13, true });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 162, new DateTime(2020, 9, 30, 19, 53, 46, 884, DateTimeKind.Local).AddTicks(6490), new DateTime(2020, 12, 16, 6, 49, 17, 841, DateTimeKind.Local).AddTicks(8438), "lpwxhtfwak", "necessitatibus", 13 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 161, new DateTime(2020, 8, 31, 23, 24, 14, 586, DateTimeKind.Local).AddTicks(222), new DateTime(2021, 2, 6, 23, 38, 47, 427, DateTimeKind.Local).AddTicks(8794), "svcec", "Harum quis praesentium quod minima quidem quia quidem eius.\nAut voluptates molestias et occaecati molestias.\nHic qui optio architecto dolor autem culpa voluptas aut officiis.\nDolor amet aut quod voluptatem tenetur animi odit dolorem ut.\nLaboriosam qui aspernatur rerum corrupti velit est excepturi.", 13, true },
                    { 160, new DateTime(2021, 4, 21, 3, 12, 7, 390, DateTimeKind.Local).AddTicks(3348), new DateTime(2021, 3, 14, 10, 51, 40, 519, DateTimeKind.Local).AddTicks(8889), "qxblchfano", "Ut ullam alias dolores et accusamus iste.\nConsequatur minima optio.\nEa asperiores in et rerum ut aut iusto fuga omnis.\nDeleniti fuga veniam et.", 13, true },
                    { 159, new DateTime(2021, 4, 20, 18, 51, 54, 783, DateTimeKind.Local).AddTicks(2681), new DateTime(2021, 4, 21, 4, 29, 37, 454, DateTimeKind.Local).AddTicks(136), "ipcvqloeqb", "Rerum sed possimus.\nMinima in est quia facere veritatis.\nAd vel ratione unde ab eum adipisci sit.\nAliquam nam nihil autem illo.", 13, true },
                    { 158, new DateTime(2021, 4, 20, 18, 46, 38, 338, DateTimeKind.Local).AddTicks(7796), new DateTime(2021, 4, 21, 8, 5, 52, 839, DateTimeKind.Local).AddTicks(2669), "sjyydqhfazo", "Sit veritatis consequatur id incidunt eveniet facere ut. Eveniet voluptatibus alias aut et itaque qui ea nihil aperiam. Asperiores illo soluta.", 13, true },
                    { 157, new DateTime(2021, 4, 20, 22, 12, 26, 357, DateTimeKind.Local).AddTicks(461), new DateTime(2020, 11, 5, 20, 5, 37, 389, DateTimeKind.Local).AddTicks(3828), "ubbsnuoccr", "Et facilis voluptas natus nulla nihil odio rerum.\nNemo qui autem est illum officia consectetur aut nam.", 13, true },
                    { 156, new DateTime(2020, 5, 14, 14, 13, 29, 976, DateTimeKind.Local).AddTicks(2922), new DateTime(2020, 12, 15, 6, 11, 24, 322, DateTimeKind.Local).AddTicks(4719), "fplpdxkgimf", "Hic quae aut repellendus nostrum quis et.", 13, true },
                    { 155, new DateTime(2021, 4, 21, 11, 20, 12, 707, DateTimeKind.Local).AddTicks(3421), new DateTime(2021, 3, 16, 23, 58, 9, 738, DateTimeKind.Local).AddTicks(8687), "uxbeziu", "quia", 13, true },
                    { 154, new DateTime(2021, 4, 20, 22, 42, 41, 233, DateTimeKind.Local).AddTicks(9132), new DateTime(2021, 4, 21, 7, 46, 49, 31, DateTimeKind.Local).AddTicks(9414), "bskoycz", "Consequatur qui rerum omnis nobis magnam aut ea nisi qui.\nExercitationem similique nulla quibusdam.\nIn quo quod architecto vel.\nRem quidem asperiores et ipsa porro quo ut ab.\nNon non sunt.\nCumque consequuntur fugit officia nesciunt qui mollitia.", 12, true },
                    { 153, new DateTime(2021, 4, 21, 14, 0, 33, 173, DateTimeKind.Local).AddTicks(8657), new DateTime(2021, 4, 21, 13, 55, 12, 755, DateTimeKind.Local).AddTicks(9705), "yvxrjb", "Et autem rerum voluptas et deleniti excepturi culpa suscipit. Temporibus possimus alias veritatis tempora et minima. Facilis voluptatem harum quia consequatur aspernatur quae facilis.", 12, true },
                    { 168, new DateTime(2021, 1, 15, 9, 42, 36, 750, DateTimeKind.Local).AddTicks(3266), new DateTime(2021, 4, 21, 2, 45, 27, 514, DateTimeKind.Local).AddTicks(1588), "zwsmmztcw", "At perspiciatis hic facere amet.", 13, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 224, new DateTime(2020, 9, 19, 3, 13, 31, 795, DateTimeKind.Local).AddTicks(6187), new DateTime(2020, 11, 17, 5, 6, 29, 30, DateTimeKind.Local).AddTicks(9206), "qeenihon", "officiis", 16 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 169, new DateTime(2021, 4, 21, 12, 24, 1, 170, DateTimeKind.Local).AddTicks(9509), new DateTime(2021, 4, 21, 18, 16, 7, 408, DateTimeKind.Local).AddTicks(5744), "wlecwmhn", "quibusdam", 13, true },
                    { 171, new DateTime(2020, 11, 10, 16, 40, 10, 263, DateTimeKind.Local).AddTicks(1137), new DateTime(2021, 4, 21, 10, 59, 20, 814, DateTimeKind.Local).AddTicks(3380), "qfjzvqtaajn", "Vel distinctio vero modi accusantium esse.\nProvident dolores mollitia explicabo non iusto in eos.\nIn odit hic inventore quos.\nUt unde in dolor quis.", 13, true },
                    { 186, new DateTime(2021, 4, 20, 18, 46, 38, 341, DateTimeKind.Local).AddTicks(6130), new DateTime(2020, 10, 3, 1, 59, 41, 284, DateTimeKind.Local).AddTicks(3786), "nvpumacjcr", "Quis fugiat nesciunt omnis non reprehenderit alias et.\nDolorum ut quis.\nVoluptate eaque ut qui.\nUnde est ad voluptate reprehenderit.\nAd aperiam et.", 14, true },
                    { 185, new DateTime(2021, 4, 20, 18, 46, 38, 341, DateTimeKind.Local).AddTicks(5947), new DateTime(2021, 4, 21, 8, 14, 32, 727, DateTimeKind.Local).AddTicks(6552), "nmovvzyqom", "Voluptas hic culpa asperiores et alias repellendus quos. Optio expedita nostrum inventore debitis quo inventore non explicabo. Aliquam qui porro ipsum dicta. Vel facilis nihil quo consectetur inventore tenetur sint tempora porro. Non sed explicabo. Ut sed maxime quibusdam voluptates.", 14, true },
                    { 184, new DateTime(2021, 4, 20, 18, 46, 38, 341, DateTimeKind.Local).AddTicks(5584), new DateTime(2020, 10, 9, 14, 58, 29, 400, DateTimeKind.Local).AddTicks(7554), "ooaeo", "Omnis et dignissimos rerum cupiditate eius unde ut rerum.\nVoluptas neque praesentium explicabo id enim sint modi nam et.\nFacilis fuga expedita blanditiis assumenda cupiditate necessitatibus soluta rerum.", 14, true },
                    { 183, new DateTime(2021, 4, 20, 21, 29, 32, 841, DateTimeKind.Local).AddTicks(4153), new DateTime(2021, 4, 21, 16, 25, 4, 442, DateTimeKind.Local).AddTicks(1257), "lsbpq", "Omnis reiciendis praesentium rerum doloremque.", 14, true },
                    { 182, new DateTime(2020, 7, 15, 9, 43, 38, 500, DateTimeKind.Local).AddTicks(2501), new DateTime(2020, 10, 10, 10, 13, 1, 678, DateTimeKind.Local).AddTicks(2158), "ihzran", "Omnis facilis qui qui nesciunt magnam autem.", 14, true },
                    { 181, new DateTime(2021, 4, 21, 18, 33, 39, 975, DateTimeKind.Local).AddTicks(7636), new DateTime(2020, 11, 27, 8, 18, 28, 20, DateTimeKind.Local).AddTicks(6183), "vjacmuk", "Consequatur sed consequuntur voluptas sit.", 14, true },
                    { 180, new DateTime(2020, 11, 30, 13, 57, 59, 190, DateTimeKind.Local).AddTicks(5123), new DateTime(2021, 4, 21, 11, 54, 14, 899, DateTimeKind.Local).AddTicks(4177), "nhpqreiidhjw", "Autem at et sit aspernatur laborum. Earum culpa ut dolorem iure et beatae voluptas. Dolor quisquam dicta voluptatibus est iure. Odit sed earum porro cupiditate laborum veniam natus deleniti.", 14, true },
                    { 179, new DateTime(2021, 4, 21, 13, 56, 41, 389, DateTimeKind.Local).AddTicks(2147), new DateTime(2021, 4, 20, 23, 55, 19, 742, DateTimeKind.Local).AddTicks(1865), "evpegakeahux", "Nisi enim omnis ea tempore. Vero dolore rerum dolores sunt. Quasi doloremque nihil necessitatibus tenetur inventore sint et. Corrupti assumenda quis voluptatem inventore est repudiandae nam voluptate voluptas.", 14, true },
                    { 178, new DateTime(2021, 3, 10, 11, 29, 51, 608, DateTimeKind.Local).AddTicks(2057), new DateTime(2021, 4, 21, 1, 5, 59, 409, DateTimeKind.Local).AddTicks(4535), "mnyrlgubyat", "Qui porro adipisci nihil ut id labore vel dolorem. Adipisci dolor rerum eos nesciunt omnis. Nesciunt qui dolorum illum. Error amet voluptatem perspiciatis optio voluptate. Vel et molestiae. Veniam totam aut et recusandae non ut provident.", 14, true },
                    { 177, new DateTime(2021, 3, 7, 1, 51, 10, 296, DateTimeKind.Local).AddTicks(2310), new DateTime(2021, 4, 21, 3, 21, 34, 773, DateTimeKind.Local).AddTicks(1892), "gdtfbadc", "Non perferendis soluta voluptas nihil soluta saepe sed porro sunt.\nNemo et quas accusamus deserunt omnis.\nBlanditiis repellat eum et illum et.", 14, true },
                    { 176, new DateTime(2021, 4, 20, 18, 46, 38, 341, DateTimeKind.Local).AddTicks(4232), new DateTime(2021, 4, 21, 14, 36, 12, 972, DateTimeKind.Local).AddTicks(1816), "jrymwn", "eligendi", 14, true },
                    { 175, new DateTime(2021, 4, 20, 18, 46, 38, 341, DateTimeKind.Local).AddTicks(4182), new DateTime(2020, 7, 15, 16, 33, 19, 145, DateTimeKind.Local).AddTicks(3348), "hlallbxk", "Ipsum nihil expedita natus quo est nobis amet qui.", 14, true },
                    { 174, new DateTime(2021, 4, 21, 12, 18, 36, 159, DateTimeKind.Local).AddTicks(6135), new DateTime(2020, 7, 15, 7, 16, 21, 685, DateTimeKind.Local).AddTicks(8497), "wcgwpfqucp", "Aut dolorum voluptatibus.\nDoloremque distinctio nesciunt eveniet totam vero tenetur.\nVoluptatem neque debitis.", 14, true },
                    { 173, new DateTime(2020, 12, 30, 6, 59, 3, 547, DateTimeKind.Local).AddTicks(9837), new DateTime(2021, 1, 9, 10, 1, 5, 566, DateTimeKind.Local).AddTicks(1997), "niqqbwaze", "ut", 14, true },
                    { 172, new DateTime(2021, 4, 20, 18, 46, 38, 338, DateTimeKind.Local).AddTicks(9851), new DateTime(2020, 8, 7, 6, 45, 44, 925, DateTimeKind.Local).AddTicks(4960), "kpaqpcdc", "Non quia nesciunt possimus dolor voluptate error provident. Occaecati possimus nemo qui nulla magni ut voluptatibus omnis non. Voluptatum ipsa dolorem blanditiis est omnis. Suscipit tenetur quis velit eos distinctio. Ut fugit veniam quibusdam in reiciendis aut velit et. Est nemo quia est atque quo eos ipsam omnis totam.", 13, true },
                    { 170, new DateTime(2021, 4, 20, 18, 46, 38, 338, DateTimeKind.Local).AddTicks(9406), new DateTime(2021, 4, 21, 0, 47, 6, 872, DateTimeKind.Local).AddTicks(4523), "gngvalosx", "voluptas", 13, true },
                    { 225, new DateTime(2021, 4, 20, 18, 46, 38, 348, DateTimeKind.Local).AddTicks(5127), new DateTime(2021, 4, 21, 13, 41, 14, 821, DateTimeKind.Local).AddTicks(576), "pkkzjngaif", "Quo doloribus quasi. Quasi sed quia voluptatem esse harum. Possimus labore illum sit est corrupti accusantium distinctio vero veniam.", 16, true },
                    { 226, new DateTime(2021, 4, 20, 19, 33, 53, 950, DateTimeKind.Local).AddTicks(8164), new DateTime(2021, 4, 21, 5, 45, 4, 419, DateTimeKind.Local).AddTicks(6445), "yitbwwz", "Saepe et iste ipsum assumenda iusto numquam qui impedit.\nCorporis at adipisci consequuntur.\nEst molestias praesentium aut vel.\nEveniet debitis vero laudantium nostrum.\nQuo quis rerum illo.\nUnde ut voluptas molestiae.", 16, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[,]
                {
                    { 227, new DateTime(2021, 4, 20, 18, 46, 38, 348, DateTimeKind.Local).AddTicks(5367), new DateTime(2021, 4, 21, 18, 43, 37, 474, DateTimeKind.Local).AddTicks(6849), "zcdqu", "commodi", 16 },
                    { 280, new DateTime(2021, 4, 20, 23, 53, 19, 739, DateTimeKind.Local).AddTicks(2544), new DateTime(2021, 4, 2, 12, 51, 8, 186, DateTimeKind.Local).AddTicks(4060), "fxlxbtlck", "Et nihil beatae voluptatem enim et laboriosam est.\nUt accusantium nisi.", 19 },
                    { 279, new DateTime(2021, 4, 20, 18, 46, 38, 357, DateTimeKind.Local).AddTicks(3314), new DateTime(2021, 2, 17, 15, 0, 30, 624, DateTimeKind.Local).AddTicks(6014), "wdihibdvx", "accusamus", 19 }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 278, new DateTime(2021, 2, 8, 20, 58, 49, 875, DateTimeKind.Local).AddTicks(4444), new DateTime(2021, 4, 21, 11, 50, 57, 714, DateTimeKind.Local).AddTicks(2012), "osmrojd", "Aut sed quam architecto dolorum numquam. Tenetur soluta natus quod nobis iste nesciunt velit quaerat ullam. Consequatur quod aliquid. Cum rerum doloremque qui. Laborum delectus dolor ea nulla ut quidem vitae est eum.", 19, true },
                    { 277, new DateTime(2021, 1, 12, 15, 5, 4, 887, DateTimeKind.Local).AddTicks(4951), new DateTime(2020, 9, 2, 21, 11, 47, 564, DateTimeKind.Local).AddTicks(7427), "hoomrwac", "dolore", 19, true },
                    { 276, new DateTime(2020, 12, 6, 1, 12, 11, 28, DateTimeKind.Local).AddTicks(5345), new DateTime(2021, 4, 21, 17, 20, 39, 457, DateTimeKind.Local).AddTicks(7770), "rtqemfb", "In aliquam mollitia molestias similique aliquam dolorum.", 19, true },
                    { 275, new DateTime(2020, 5, 16, 20, 27, 25, 269, DateTimeKind.Local).AddTicks(8956), new DateTime(2021, 4, 21, 4, 24, 36, 145, DateTimeKind.Local).AddTicks(6748), "mxdwlqypya", "Sequi est officia quo sed enim maxime veniam vitae.", 19, true },
                    { 274, new DateTime(2021, 3, 3, 11, 21, 55, 326, DateTimeKind.Local).AddTicks(157), new DateTime(2020, 8, 3, 13, 2, 12, 63, DateTimeKind.Local).AddTicks(4105), "ynlaxncngw", "ipsum", 19, true },
                    { 273, new DateTime(2020, 10, 4, 0, 53, 37, 163, DateTimeKind.Local).AddTicks(9382), new DateTime(2021, 4, 21, 14, 39, 49, 130, DateTimeKind.Local).AddTicks(7283), "iecphhngo", "Vel velit iusto et sit velit sunt libero.", 19, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 272, new DateTime(2020, 5, 26, 3, 23, 25, 472, DateTimeKind.Local).AddTicks(3286), new DateTime(2021, 3, 25, 18, 46, 35, 212, DateTimeKind.Local).AddTicks(7170), "cwxqw", "Deserunt corrupti reiciendis dolores asperiores sit consequatur minus dolorem dignissimos.\nTemporibus dignissimos molestiae sit ut quaerat est consequatur qui dolorem.", 19 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 271, new DateTime(2021, 4, 21, 14, 17, 31, 708, DateTimeKind.Local).AddTicks(7398), new DateTime(2020, 5, 15, 8, 21, 8, 715, DateTimeKind.Local).AddTicks(6001), "tdsoapjgum", "Ipsam ex quia ullam tenetur dolorum eius possimus.\nQuidem placeat inventore aut.\nAliquid provident sapiente ab qui voluptas.\nNecessitatibus voluptatem modi ipsa.", 18, true },
                    { 270, new DateTime(2021, 4, 20, 18, 46, 38, 354, DateTimeKind.Local).AddTicks(3181), new DateTime(2020, 5, 12, 11, 22, 37, 59, DateTimeKind.Local).AddTicks(9049), "bhurzjmerky", "Eligendi impedit sunt sapiente quas. Ut incidunt perferendis. A quia tempora omnis animi nobis. Qui similique ut debitis doloribus sequi repudiandae facilis voluptatem. Animi ad reprehenderit sit velit quae officia aut perspiciatis cum.", 18, true },
                    { 269, new DateTime(2021, 4, 20, 18, 46, 38, 354, DateTimeKind.Local).AddTicks(2917), new DateTime(2021, 4, 21, 3, 46, 21, 954, DateTimeKind.Local).AddTicks(2364), "koegrxk", "Dolores dolore et ipsam est ut sed. Aut fuga similique ut molestias molestiae ullam a est eos. Consequatur quas expedita adipisci autem non asperiores. Amet laudantium pariatur recusandae sit quia tempore quod non voluptatem. Similique est et iusto possimus delectus omnis magni eaque minus.", 18, true },
                    { 268, new DateTime(2021, 1, 16, 23, 59, 11, 308, DateTimeKind.Local).AddTicks(7919), new DateTime(2021, 4, 21, 4, 4, 44, 154, DateTimeKind.Local).AddTicks(137), "tidbhg", "sit", 18, true },
                    { 267, new DateTime(2021, 4, 20, 18, 46, 38, 354, DateTimeKind.Local).AddTicks(2498), new DateTime(2020, 5, 17, 11, 49, 53, 314, DateTimeKind.Local).AddTicks(883), "ctysiurmhxjc", "saepe", 18, true },
                    { 266, new DateTime(2021, 4, 20, 18, 46, 38, 354, DateTimeKind.Local).AddTicks(2452), new DateTime(2021, 2, 4, 9, 38, 53, 877, DateTimeKind.Local).AddTicks(8931), "xxxqkufmq", "Ut reprehenderit eveniet veritatis et dolorem nesciunt corporis consequatur. Quia in qui nobis dolorem ea facere deserunt veritatis. Rerum voluptatem amet expedita debitis. Sit beatae unde veritatis voluptatem nulla repellendus nesciunt quia sed. In excepturi voluptatem totam occaecati provident quae. Laboriosam qui id hic et quod accusantium dolor.", 18, true },
                    { 281, new DateTime(2021, 4, 21, 2, 28, 11, 203, DateTimeKind.Local).AddTicks(762), new DateTime(2021, 4, 21, 7, 25, 8, 967, DateTimeKind.Local).AddTicks(4345), "sfurlfgn", "Numquam rerum qui odio sequi cumque saepe vero. Itaque laboriosam eum delectus officiis odit quia eos. Vel tenetur rerum voluptatum unde repudiandae tempora recusandae quam quisquam. Commodi fugiat voluptas. Molestias consequatur praesentium sed. Harum aliquid aliquam deserunt deleniti sint eum qui consequatur.", 19, true },
                    { 265, new DateTime(2020, 5, 16, 14, 3, 40, 727, DateTimeKind.Local).AddTicks(6422), new DateTime(2021, 4, 20, 23, 13, 20, 41, DateTimeKind.Local).AddTicks(3541), "uopwtotrq", "iste", 18, true },
                    { 282, new DateTime(2021, 4, 20, 18, 46, 38, 357, DateTimeKind.Local).AddTicks(3836), new DateTime(2021, 3, 19, 9, 30, 12, 14, DateTimeKind.Local).AddTicks(3787), "timffhethco", "blanditiis", 19, true },
                    { 284, new DateTime(2021, 4, 21, 10, 26, 27, 645, DateTimeKind.Local).AddTicks(1363), new DateTime(2021, 4, 21, 2, 22, 36, 765, DateTimeKind.Local).AddTicks(510), "vpjsruhe", "Molestiae maxime corporis hic aut.", 20, true },
                    { 299, new DateTime(2021, 4, 20, 18, 46, 38, 363, DateTimeKind.Local).AddTicks(652), new DateTime(2021, 4, 21, 11, 33, 11, 609, DateTimeKind.Local).AddTicks(3671), "hgdwajjo", "Similique ut hic.\nEst deleniti et consequatur vero.\nEum a praesentium est voluptas quae provident ut.\nUllam ipsam dolorem possimus eligendi aspernatur facere unde eos.\nQui tenetur quo autem excepturi unde temporibus consectetur et officiis.\nDucimus laudantium suscipit temporibus ut quis nam nesciunt dolore.", 20, true },
                    { 298, new DateTime(2021, 2, 28, 2, 52, 7, 580, DateTimeKind.Local).AddTicks(1833), new DateTime(2021, 1, 14, 14, 38, 27, 379, DateTimeKind.Local).AddTicks(9053), "oxsup", "Non impedit id voluptates quod explicabo rerum quia.\nPlaceat veritatis quo explicabo consectetur unde eos eos et officia.\nSed reiciendis nisi.\nEt officiis veniam dicta sint et temporibus animi fugit sit.", 20, true },
                    { 297, new DateTime(2020, 12, 7, 15, 53, 14, 233, DateTimeKind.Local).AddTicks(6789), new DateTime(2021, 2, 17, 5, 37, 41, 183, DateTimeKind.Local).AddTicks(7782), "khscbsf", "illo", 20, true },
                    { 296, new DateTime(2021, 4, 20, 18, 46, 38, 363, DateTimeKind.Local).AddTicks(40), new DateTime(2021, 4, 21, 14, 33, 49, 325, DateTimeKind.Local).AddTicks(3806), "xykeeinegh", "Tempore tenetur voluptatem dolorem voluptatem.", 20, true },
                    { 295, new DateTime(2020, 9, 2, 2, 7, 55, 577, DateTimeKind.Local).AddTicks(7464), new DateTime(2021, 4, 20, 19, 55, 32, 461, DateTimeKind.Local).AddTicks(8321), "nghueb", "quis", 20, true },
                    { 294, new DateTime(2021, 4, 21, 0, 23, 36, 484, DateTimeKind.Local).AddTicks(7935), new DateTime(2021, 1, 6, 16, 17, 7, 686, DateTimeKind.Local).AddTicks(3528), "ykpoglzocrp", "Qui velit ab quia perspiciatis dignissimos labore modi voluptas quas. Deserunt in quaerat fuga quia voluptatem. Eligendi voluptates molestiae est voluptatem est.", 20, true },
                    { 293, new DateTime(2021, 4, 20, 18, 46, 38, 362, DateTimeKind.Local).AddTicks(9702), new DateTime(2021, 4, 21, 0, 44, 55, 601, DateTimeKind.Local).AddTicks(5995), "stvery", "omnis", 20, true },
                    { 292, new DateTime(2021, 4, 21, 4, 52, 49, 411, DateTimeKind.Local).AddTicks(76), new DateTime(2021, 4, 20, 20, 10, 54, 684, DateTimeKind.Local).AddTicks(450), "fzcyist", "Facere omnis dicta numquam nihil. Est ut aut unde reiciendis commodi deserunt qui saepe. Earum commodi molestiae eaque aperiam et quasi suscipit eum occaecati. Distinctio ut doloremque laboriosam. Voluptatem commodi suscipit labore adipisci quasi voluptate sint blanditiis quos. Est ea voluptas voluptate excepturi.", 20, true },
                    { 291, new DateTime(2021, 1, 7, 13, 29, 47, 328, DateTimeKind.Local).AddTicks(820), new DateTime(2021, 3, 29, 2, 39, 55, 904, DateTimeKind.Local).AddTicks(1910), "gqptcwysc", "minima", 20, true },
                    { 290, new DateTime(2021, 4, 20, 21, 12, 38, 256, DateTimeKind.Local).AddTicks(3575), new DateTime(2021, 4, 21, 0, 15, 45, 856, DateTimeKind.Local).AddTicks(298), "cfwoqv", "Tempore eveniet sed modi voluptatum.", 20, true },
                    { 289, new DateTime(2021, 4, 20, 18, 46, 38, 362, DateTimeKind.Local).AddTicks(9174), new DateTime(2021, 4, 21, 18, 34, 1, 452, DateTimeKind.Local).AddTicks(4796), "bgyzcdixgi", "Odio sed voluptatem pariatur vitae illum. Deleniti neque nihil. Eos aut at facilis asperiores. Vitae sit deleniti. Facilis id autem dolor quos. Assumenda vero unde hic eius.", 20, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 288, new DateTime(2021, 4, 20, 18, 46, 38, 362, DateTimeKind.Local).AddTicks(8974), new DateTime(2020, 9, 12, 6, 18, 50, 304, DateTimeKind.Local).AddTicks(4940), "ateplctuga", "enim", 20 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 287, new DateTime(2020, 7, 25, 5, 58, 23, 456, DateTimeKind.Local).AddTicks(981), new DateTime(2021, 4, 21, 3, 40, 57, 428, DateTimeKind.Local).AddTicks(9708), "fyzie", "et", 20, true },
                    { 286, new DateTime(2020, 11, 28, 13, 2, 18, 994, DateTimeKind.Local).AddTicks(3845), new DateTime(2021, 4, 20, 18, 54, 53, 3, DateTimeKind.Local).AddTicks(2922), "epbxwh", "qui", 20, true },
                    { 285, new DateTime(2021, 4, 20, 18, 46, 38, 362, DateTimeKind.Local).AddTicks(8783), new DateTime(2020, 5, 14, 5, 19, 11, 396, DateTimeKind.Local).AddTicks(7887), "tznkn", "Non consequatur et quisquam aut omnis ut. Molestiae tempore consequuntur repellendus vero exercitationem voluptas illum. Possimus quia esse enim quaerat officiis dolorum quos sed. Id qui quis omnis magnam excepturi soluta. Recusandae est incidunt alias ipsam placeat eaque eos facilis libero. Quia odio nam impedit harum assumenda est.", 20, true },
                    { 283, new DateTime(2020, 8, 1, 0, 17, 35, 242, DateTimeKind.Local).AddTicks(903), new DateTime(2021, 4, 20, 20, 44, 4, 695, DateTimeKind.Local).AddTicks(8015), "ankdqkfziges", "quia", 20, true },
                    { 152, new DateTime(2020, 6, 9, 2, 32, 52, 733, DateTimeKind.Local).AddTicks(1334), new DateTime(2021, 3, 7, 11, 42, 53, 224, DateTimeKind.Local).AddTicks(9640), "ptsnqwy", "Similique aut sit voluptate.", 12, true },
                    { 264, new DateTime(2021, 4, 20, 18, 46, 38, 354, DateTimeKind.Local).AddTicks(2061), new DateTime(2021, 4, 21, 13, 16, 21, 226, DateTimeKind.Local).AddTicks(1211), "wixyqxcn", "Expedita non aut quo facilis sunt. Quidem quia voluptatum praesentium at corrupti voluptas aut inventore. Et et tempora nulla labore facere aut.", 18, true },
                    { 262, new DateTime(2021, 4, 20, 18, 46, 38, 354, DateTimeKind.Local).AddTicks(1642), new DateTime(2020, 11, 11, 23, 45, 8, 83, DateTimeKind.Local).AddTicks(4235), "srlyq", "Velit ipsum rerum commodi necessitatibus dolores quod quibusdam.", 18, true },
                    { 242, new DateTime(2020, 11, 25, 13, 47, 6, 333, DateTimeKind.Local).AddTicks(2082), new DateTime(2021, 4, 20, 19, 14, 22, 247, DateTimeKind.Local).AddTicks(3921), "fpnvu", "Laudantium sed magnam nihil sapiente necessitatibus temporibus alias aut.", 17, true },
                    { 241, new DateTime(2021, 4, 20, 18, 46, 38, 351, DateTimeKind.Local).AddTicks(1160), new DateTime(2021, 4, 21, 8, 32, 58, 981, DateTimeKind.Local).AddTicks(9911), "ttslcwm", "delectus", 17, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 240, new DateTime(2020, 4, 24, 6, 26, 59, 799, DateTimeKind.Local).AddTicks(6886), new DateTime(2021, 4, 21, 12, 20, 22, 617, DateTimeKind.Local).AddTicks(9473), "yvxfoacs", "Atque iure occaecati hic sapiente distinctio in. Et blanditiis impedit tempora. In repellendus non dolore voluptatem quia.", 17 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 239, new DateTime(2021, 4, 20, 18, 46, 38, 351, DateTimeKind.Local).AddTicks(991), new DateTime(2021, 4, 21, 18, 10, 0, 257, DateTimeKind.Local).AddTicks(8922), "dsxrqrinzd", "Beatae delectus minus sint voluptatibus.\nDolor facere rem ipsam omnis et neque sapiente.\nSed similique ex.", 17, true },
                    { 238, new DateTime(2020, 5, 12, 18, 28, 49, 870, DateTimeKind.Local).AddTicks(9024), new DateTime(2021, 4, 20, 10, 57, 2, 589, DateTimeKind.Local).AddTicks(1953), "ewuxrsrcpe", "Optio sed praesentium architecto.", 17, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 237, new DateTime(2021, 4, 20, 18, 46, 38, 351, DateTimeKind.Local).AddTicks(790), new DateTime(2020, 5, 26, 10, 0, 18, 947, DateTimeKind.Local).AddTicks(3388), "vegteqnr", "Officia sapiente quia qui velit quisquam natus tempora libero eius.\nEt autem dolor qui qui cum saepe temporibus minus consectetur.\nVero sunt et doloribus sed eos eligendi non ratione delectus.\nOdio quia vitae ut rerum quia expedita perferendis.", 17 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 236, new DateTime(2020, 11, 10, 10, 50, 13, 395, DateTimeKind.Local).AddTicks(1191), new DateTime(2021, 4, 21, 8, 32, 28, 851, DateTimeKind.Local).AddTicks(7723), "jdkrrnzev", "Minima iste et libero alias mollitia.\nEa illo unde rerum magni earum et.\nDignissimos deleniti dolorem corporis porro vero ipsam eum fugiat aliquam.\nEaque voluptatem id quo facilis.\nSuscipit voluptas quae.", 17, true },
                    { 235, new DateTime(2021, 4, 20, 18, 46, 38, 351, DateTimeKind.Local).AddTicks(295), new DateTime(2020, 12, 3, 14, 28, 12, 37, DateTimeKind.Local).AddTicks(8661), "zrzsvsamvy", "quia", 17, true },
                    { 234, new DateTime(2020, 6, 10, 3, 50, 26, 588, DateTimeKind.Local).AddTicks(6680), new DateTime(2020, 10, 29, 0, 16, 10, 293, DateTimeKind.Local).AddTicks(8014), "ojmll", "Deleniti fugiat et voluptate eum ut iure quia ea quidem.\nUllam et quia.\nEnim vel odit veritatis aperiam possimus vitae ratione qui saepe.", 17, true },
                    { 233, new DateTime(2021, 4, 20, 18, 46, 38, 351, DateTimeKind.Local).AddTicks(95), new DateTime(2020, 12, 11, 21, 46, 26, 569, DateTimeKind.Local).AddTicks(7076), "bohrx", "Est non minima neque est ad quas. Laudantium blanditiis assumenda cupiditate dolorum harum. Voluptates assumenda iusto asperiores magnam consectetur eveniet nemo necessitatibus a. Quidem in dolores nulla. Et non et non.", 17, true },
                    { 232, new DateTime(2021, 4, 21, 17, 6, 53, 873, DateTimeKind.Local).AddTicks(7266), new DateTime(2020, 10, 19, 18, 30, 30, 367, DateTimeKind.Local).AddTicks(1394), "jyyndohdz", "Delectus molestias qui atque laudantium necessitatibus dicta veritatis rerum. Fugit sit molestiae in nisi consequatur. Voluptatem quo earum odio et ab et sapiente voluptas aliquam. Voluptatem dolor consequatur.", 17, true },
                    { 231, new DateTime(2020, 10, 5, 23, 2, 17, 500, DateTimeKind.Local).AddTicks(2752), new DateTime(2021, 4, 21, 17, 55, 53, 200, DateTimeKind.Local).AddTicks(660), "utjhnlmwjgj", "Neque atque illo asperiores et et sunt qui distinctio. Cum et repudiandae. Autem eum enim facere dolores dolore velit eius iste provident. Aut sint ducimus at cum similique et aut voluptate. Necessitatibus commodi eum libero iusto corporis ut. Autem est totam.", 17, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[] { 230, new DateTime(2021, 2, 15, 23, 25, 39, 899, DateTimeKind.Local).AddTicks(3503), new DateTime(2020, 11, 18, 0, 19, 39, 323, DateTimeKind.Local).AddTicks(9465), "wtdfzyvkiz", "Voluptates rerum nam tenetur.", 17, true });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 229, new DateTime(2021, 4, 20, 18, 46, 38, 350, DateTimeKind.Local).AddTicks(9056), new DateTime(2021, 4, 21, 11, 34, 51, 416, DateTimeKind.Local).AddTicks(2239), "lwktuw", "sunt", 17 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 228, new DateTime(2021, 2, 15, 5, 10, 26, 449, DateTimeKind.Local).AddTicks(3284), new DateTime(2021, 4, 21, 0, 28, 53, 713, DateTimeKind.Local).AddTicks(4291), "mfmuteehzj", "Cumque enim ex rerum delectus quibusdam. Consequatur qui mollitia rerum incidunt qui omnis perspiciatis quam. Voluptas officiis doloremque voluptas minima odio a officiis. Sint fugiat autem amet. Et qui rerum et exercitationem. Accusamus aperiam facere eum laboriosam laboriosam fuga iste ut.", 16, true },
                    { 243, new DateTime(2021, 4, 20, 18, 46, 38, 351, DateTimeKind.Local).AddTicks(1315), new DateTime(2020, 8, 15, 3, 45, 14, 376, DateTimeKind.Local).AddTicks(1454), "ivbcdfkgkmni", "Voluptatibus quaerat eos aut error laborum.", 17, true },
                    { 263, new DateTime(2020, 7, 15, 17, 49, 30, 246, DateTimeKind.Local).AddTicks(1642), new DateTime(2021, 4, 21, 6, 37, 26, 469, DateTimeKind.Local).AddTicks(490), "yymqcmzasyok", "Nobis tempore et deserunt quis praesentium nostrum dolorem. Temporibus repellendus perspiciatis. Reprehenderit dolorem eum. Rerum quisquam et. Nesciunt nam provident. Velit et expedita a deserunt voluptas recusandae illo quaerat eum.", 18, true },
                    { 244, new DateTime(2020, 9, 28, 15, 55, 2, 155, DateTimeKind.Local).AddTicks(4541), new DateTime(2021, 4, 21, 0, 32, 17, 332, DateTimeKind.Local).AddTicks(5366), "hzaqgpmyltii", "Quam minima expedita assumenda tenetur distinctio quia. Quae eaque facere aut adipisci. Vel sint magni provident atque recusandae molestiae laudantium. Odit quod hic accusantium eum explicabo est quaerat omnis quia.", 17, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 246, new DateTime(2020, 5, 15, 3, 28, 59, 761, DateTimeKind.Local).AddTicks(4626), new DateTime(2021, 4, 21, 7, 3, 6, 168, DateTimeKind.Local).AddTicks(7166), "oaaqhfku", "Dicta reiciendis voluptate necessitatibus autem numquam possimus possimus. Enim et dolore et consequatur dolor dolore. Deleniti nihil autem nihil nihil aut. Non id quidem aut totam error quibusdam excepturi impedit distinctio. Quasi odio ullam maiores. Est autem ducimus beatae.", 17 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 261, new DateTime(2020, 10, 10, 9, 57, 10, 684, DateTimeKind.Local).AddTicks(1174), new DateTime(2020, 5, 11, 12, 0, 42, 865, DateTimeKind.Local).AddTicks(7643), "lpizwalcr", "sed", 18, true },
                    { 260, new DateTime(2021, 4, 1, 0, 20, 6, 954, DateTimeKind.Local).AddTicks(1352), new DateTime(2021, 4, 21, 1, 18, 33, 183, DateTimeKind.Local).AddTicks(7620), "kkanbpzr", "nobis", 18, true },
                    { 259, new DateTime(2021, 4, 20, 22, 37, 50, 108, DateTimeKind.Local).AddTicks(3969), new DateTime(2020, 6, 11, 4, 30, 23, 98, DateTimeKind.Local).AddTicks(7216), "xhmim", "magni", 18, true },
                    { 258, new DateTime(2021, 4, 21, 15, 5, 15, 46, DateTimeKind.Local).AddTicks(4570), new DateTime(2020, 7, 26, 18, 15, 8, 94, DateTimeKind.Local).AddTicks(8655), "pmchpfpopdji", "Ex ut corrupti et dolorum laudantium velit voluptatum.\nIncidunt doloribus numquam sint iure repudiandae architecto.", 18, true },
                    { 257, new DateTime(2021, 4, 20, 18, 46, 38, 354, DateTimeKind.Local).AddTicks(1222), new DateTime(2020, 9, 13, 11, 4, 34, 984, DateTimeKind.Local).AddTicks(1857), "szjgp", "Pariatur similique voluptas sed enim voluptatem.\nOdit eveniet ipsa sint mollitia praesentium laudantium maiores.", 18, true },
                    { 256, new DateTime(2021, 1, 4, 18, 17, 18, 685, DateTimeKind.Local).AddTicks(5955), new DateTime(2020, 10, 14, 6, 15, 8, 493, DateTimeKind.Local).AddTicks(2829), "cevefi", "nam", 18, true },
                    { 255, new DateTime(2021, 4, 20, 18, 46, 38, 354, DateTimeKind.Local).AddTicks(997), new DateTime(2021, 4, 21, 8, 18, 24, 173, DateTimeKind.Local).AddTicks(1435), "yackafr", "Dolor nostrum est. Et molestias aut necessitatibus. Laborum occaecati reprehenderit.", 18, true },
                    { 254, new DateTime(2021, 4, 21, 15, 54, 12, 816, DateTimeKind.Local).AddTicks(682), new DateTime(2020, 10, 27, 17, 5, 10, 651, DateTimeKind.Local).AddTicks(336), "ixoejgbhi", "Impedit voluptatem pariatur nemo nisi.", 18, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 253, new DateTime(2020, 6, 10, 18, 25, 38, 768, DateTimeKind.Local).AddTicks(2213), new DateTime(2020, 12, 22, 3, 46, 28, 44, DateTimeKind.Local).AddTicks(607), "hfebcywsfgt", "Quam et perspiciatis nihil ut. Perspiciatis omnis placeat perspiciatis molestiae mollitia animi. Nesciunt illo eveniet molestias quibusdam suscipit earum dolores eum quo. Quia velit sed autem accusamus est hic. Dignissimos eveniet temporibus aspernatur.", 17 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[] { 252, new DateTime(2020, 7, 31, 12, 39, 20, 477, DateTimeKind.Local).AddTicks(2721), new DateTime(2020, 8, 28, 14, 19, 57, 746, DateTimeKind.Local).AddTicks(4413), "ljaple", "Esse quia nostrum id. Praesentium necessitatibus optio quia ut laboriosam iste et. Veritatis beatae repudiandae est dolores ut vel qui.", 17, true });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 251, new DateTime(2020, 5, 16, 4, 5, 42, 865, DateTimeKind.Local).AddTicks(7644), new DateTime(2021, 4, 21, 14, 52, 57, 626, DateTimeKind.Local).AddTicks(8979), "milcging", "ipsam", 17 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[] { 250, new DateTime(2021, 4, 20, 18, 46, 38, 351, DateTimeKind.Local).AddTicks(2422), new DateTime(2021, 3, 24, 13, 50, 45, 301, DateTimeKind.Local).AddTicks(4412), "rtnuiad", "Id qui sed sunt qui sed delectus placeat autem adipisci. Voluptatem libero similique commodi. Eligendi optio id veniam dolorum architecto iste commodi aliquam. Qui nemo sit sed nobis nihil illum numquam velit. Magnam incidunt sed vero velit.", 17, true });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[,]
                {
                    { 249, new DateTime(2021, 4, 21, 1, 7, 22, 95, DateTimeKind.Local).AddTicks(9210), new DateTime(2021, 2, 20, 6, 23, 55, 721, DateTimeKind.Local).AddTicks(9766), "xcnovgjdu", "repellendus", 17 },
                    { 248, new DateTime(2021, 4, 21, 5, 31, 48, 208, DateTimeKind.Local).AddTicks(7387), new DateTime(2021, 4, 21, 18, 26, 31, 605, DateTimeKind.Local).AddTicks(3553), "suemhabgya", "Vel quis excepturi dolorum dolores sapiente.", 17 },
                    { 247, new DateTime(2021, 4, 21, 1, 45, 1, 686, DateTimeKind.Local).AddTicks(5907), new DateTime(2021, 4, 20, 21, 18, 23, 939, DateTimeKind.Local).AddTicks(8020), "ozfjzlr", "in", 17 }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 245, new DateTime(2021, 4, 20, 23, 23, 45, 792, DateTimeKind.Local).AddTicks(7391), new DateTime(2020, 12, 13, 16, 27, 40, 810, DateTimeKind.Local).AddTicks(4165), "rypmmh", "ab", 17, true },
                    { 300, new DateTime(2021, 4, 21, 15, 53, 18, 992, DateTimeKind.Local).AddTicks(5566), new DateTime(2021, 4, 21, 15, 11, 33, 729, DateTimeKind.Local).AddTicks(175), "ggzyawdsoey", "aut", 20, true },
                    { 151, new DateTime(2020, 10, 13, 9, 16, 2, 755, DateTimeKind.Local).AddTicks(1377), new DateTime(2020, 7, 19, 6, 47, 16, 352, DateTimeKind.Local).AddTicks(128), "wgkrtfyzsldd", "Ipsum molestias eum consequatur quo modi ipsam tenetur sint. Sequi rem et dignissimos quasi in. Tempore deserunt eaque cum. Aspernatur sint modi tempora aut voluptatibus laudantium quisquam non. Harum sit omnis nobis.", 12, true },
                    { 149, new DateTime(2021, 4, 20, 18, 46, 38, 336, DateTimeKind.Local).AddTicks(3359), new DateTime(2021, 4, 20, 21, 15, 48, 383, DateTimeKind.Local).AddTicks(6761), "jmkruh", "Id dolorem commodi voluptatum unde.", 12, true },
                    { 53, new DateTime(2021, 4, 21, 17, 53, 57, 203, DateTimeKind.Local).AddTicks(6051), new DateTime(2020, 5, 12, 2, 31, 12, 718, DateTimeKind.Local).AddTicks(3236), "tzzbamsdkzrt", "Blanditiis doloribus est esse. Iusto quia voluptas qui amet quae dolore magnam. Et nulla et molestiae labore rerum enim.", 6, true },
                    { 52, new DateTime(2021, 4, 20, 18, 46, 38, 304, DateTimeKind.Local).AddTicks(2768), new DateTime(2020, 8, 1, 7, 31, 24, 527, DateTimeKind.Local).AddTicks(9953), "hyaulvqfye", "aperiam", 6, true },
                    { 51, new DateTime(2021, 4, 21, 15, 25, 33, 755, DateTimeKind.Local).AddTicks(2996), new DateTime(2021, 4, 20, 22, 51, 18, 219, DateTimeKind.Local).AddTicks(8250), "aowmbjuq", "vitae", 5, true },
                    { 50, new DateTime(2020, 10, 3, 20, 7, 19, 805, DateTimeKind.Local).AddTicks(4653), new DateTime(2021, 4, 20, 21, 37, 56, 785, DateTimeKind.Local).AddTicks(3532), "oimnpkebjko", "Quam quaerat et optio sed.\nAdipisci corporis ut molestias rerum qui officiis eaque est.\nNostrum maxime eaque perspiciatis quaerat.\nEa reprehenderit quidem assumenda vitae culpa aut sequi eaque dicta.\nEst et molestiae et inventore aut facere deserunt.\nOdit delectus sunt aut.", 5, true },
                    { 49, new DateTime(2021, 4, 20, 18, 46, 38, 300, DateTimeKind.Local).AddTicks(4859), new DateTime(2020, 7, 13, 0, 58, 23, 258, DateTimeKind.Local).AddTicks(1302), "ntqidobvhn", "Occaecati dolorem minima et rerum dolores. Molestiae nemo consequuntur quo assumenda quibusdam aut perspiciatis dolore. Quia eum doloremque quae delectus expedita sit aut eius. Voluptates incidunt consectetur ut rerum totam error mollitia animi nam.", 5, true },
                    { 48, new DateTime(2021, 4, 21, 13, 12, 24, 206, DateTimeKind.Local).AddTicks(435), new DateTime(2021, 4, 1, 3, 16, 18, 156, DateTimeKind.Local).AddTicks(5320), "vfiexgdpsm", "Quia commodi qui aut architecto rem est provident eos voluptatem.", 5, true },
                    { 54, new DateTime(2021, 4, 20, 18, 46, 38, 304, DateTimeKind.Local).AddTicks(3088), new DateTime(2021, 4, 21, 8, 47, 44, 46, DateTimeKind.Local).AddTicks(4566), "mgdblwsoqtoq", "cupiditate", 6, true },
                    { 47, new DateTime(2021, 4, 21, 8, 46, 53, 182, DateTimeKind.Local).AddTicks(3175), new DateTime(2021, 4, 21, 13, 32, 56, 415, DateTimeKind.Local).AddTicks(417), "aftazeao", "amet", 5, true },
                    { 45, new DateTime(2021, 4, 20, 18, 46, 38, 300, DateTimeKind.Local).AddTicks(4180), new DateTime(2020, 5, 8, 11, 55, 49, 602, DateTimeKind.Local).AddTicks(4448), "ylajqjee", "officiis", 5, true },
                    { 44, new DateTime(2021, 4, 20, 18, 46, 38, 296, DateTimeKind.Local).AddTicks(4648), new DateTime(2020, 12, 22, 12, 14, 0, 998, DateTimeKind.Local).AddTicks(793), "ykzda", "Rerum beatae nulla qui qui.", 4, true },
                    { 43, new DateTime(2021, 4, 20, 18, 46, 38, 296, DateTimeKind.Local).AddTicks(4533), new DateTime(2021, 4, 21, 4, 17, 10, 796, DateTimeKind.Local).AddTicks(6094), "lthfodxmij", "Accusantium deleniti est tempore temporibus hic rerum.", 4, true },
                    { 42, new DateTime(2021, 4, 20, 18, 46, 38, 296, DateTimeKind.Local).AddTicks(4456), new DateTime(2021, 4, 21, 1, 58, 35, 637, DateTimeKind.Local).AddTicks(9179), "vdkacvzqa", "Similique nisi soluta et tempora saepe recusandae accusamus qui. Asperiores cupiditate sed quibusdam. Et quia aut iure nulla fugit. Reprehenderit minus architecto qui quidem quia voluptatum est deleniti.", 4, true },
                    { 41, new DateTime(2021, 4, 20, 18, 46, 38, 296, DateTimeKind.Local).AddTicks(4217), new DateTime(2021, 4, 21, 2, 49, 54, 527, DateTimeKind.Local).AddTicks(5366), "dyieubw", "Eius qui necessitatibus aut laudantium veniam. Rerum ut non officia eaque ipsa itaque unde provident repudiandae. Quidem delectus laboriosam et voluptas est animi qui dolor vitae. Minima saepe quisquam perspiciatis aliquam consequatur quia at deleniti quod. Aperiam totam ut occaecati dolor beatae sint vel.", 4, true },
                    { 40, new DateTime(2021, 4, 20, 18, 46, 38, 296, DateTimeKind.Local).AddTicks(3917), new DateTime(2020, 5, 13, 7, 5, 41, 899, DateTimeKind.Local).AddTicks(2278), "maqoe", "Qui debitis dolor. Culpa aliquam tempore veniam. Dolor non laboriosam ad. Ipsum nam ut eligendi voluptas eius. Porro velit dolores ad. Aliquid quod eligendi quia id officia temporibus maxime.", 4, true },
                    { 46, new DateTime(2020, 8, 15, 11, 18, 52, 222, DateTimeKind.Local).AddTicks(6896), new DateTime(2021, 4, 21, 17, 30, 29, 919, DateTimeKind.Local).AddTicks(8624), "crnovfd", "Et non eveniet exercitationem.", 5, true },
                    { 55, new DateTime(2021, 4, 21, 8, 8, 24, 408, DateTimeKind.Local).AddTicks(7649), new DateTime(2021, 4, 21, 15, 52, 3, 699, DateTimeKind.Local).AddTicks(4865), "vqhwm", "doloremque", 6, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 56, new DateTime(2020, 5, 21, 1, 58, 30, 796, DateTimeKind.Local).AddTicks(686), new DateTime(2021, 4, 3, 13, 49, 3, 759, DateTimeKind.Local).AddTicks(8168), "fvsshaergelc", "Eveniet accusamus fugiat et et quas voluptas unde. Cumque cupiditate dolor non laborum. Aliquam perspiciatis recusandae dicta inventore. Rerum quaerat voluptas eaque libero ut eaque eligendi. Molestiae enim repellendus.", 6 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 57, new DateTime(2021, 4, 21, 18, 9, 12, 365, DateTimeKind.Local).AddTicks(1993), new DateTime(2021, 4, 21, 12, 12, 5, 601, DateTimeKind.Local).AddTicks(9089), "hiatvybx", "Tempore harum alias perferendis. Doloribus qui voluptas provident qui at laboriosam. Magnam reprehenderit exercitationem natus non quia asperiores odio optio. Ea natus aliquam architecto numquam quisquam et dolores. Magni omnis mollitia voluptatem repudiandae eaque aut illo sequi. Vero cumque nihil maiores tempora sint et et.", 6, true },
                    { 72, new DateTime(2021, 4, 20, 18, 46, 38, 308, DateTimeKind.Local).AddTicks(3045), new DateTime(2021, 4, 20, 0, 25, 56, 178, DateTimeKind.Local).AddTicks(8625), "xeyza", "Qui recusandae dolorem possimus architecto.", 7, true },
                    { 71, new DateTime(2021, 4, 20, 18, 46, 38, 308, DateTimeKind.Local).AddTicks(2974), new DateTime(2020, 10, 9, 8, 6, 18, 229, DateTimeKind.Local).AddTicks(4473), "yknfxh", "Enim fugiat consequatur cupiditate facere qui quos non.", 7, true },
                    { 70, new DateTime(2021, 4, 20, 21, 45, 53, 297, DateTimeKind.Local).AddTicks(2657), new DateTime(2021, 3, 28, 14, 41, 30, 530, DateTimeKind.Local).AddTicks(5175), "hehdxolh", "sit", 7, true },
                    { 69, new DateTime(2021, 4, 20, 21, 25, 45, 823, DateTimeKind.Local).AddTicks(7463), new DateTime(2021, 4, 21, 4, 37, 55, 537, DateTimeKind.Local).AddTicks(7518), "pjdpqoqwkynm", "fugiat", 7, true },
                    { 68, new DateTime(2021, 4, 21, 13, 32, 35, 398, DateTimeKind.Local).AddTicks(1183), new DateTime(2020, 6, 4, 14, 1, 4, 799, DateTimeKind.Local).AddTicks(7107), "iketmzcl", "Ut earum aut deserunt magnam repudiandae consequuntur molestiae autem molestias.", 7, true },
                    { 67, new DateTime(2021, 4, 20, 18, 46, 38, 308, DateTimeKind.Local).AddTicks(2639), new DateTime(2020, 11, 24, 4, 31, 16, 394, DateTimeKind.Local).AddTicks(6605), "tieqpftpnm", "Soluta voluptas porro alias est. Vel quisquam distinctio et voluptas nihil impedit enim a doloribus. Sunt eligendi perferendis laudantium ipsum. Recusandae inventore assumenda quia numquam.", 7, true },
                    { 66, new DateTime(2021, 4, 20, 18, 46, 38, 308, DateTimeKind.Local).AddTicks(2408), new DateTime(2021, 4, 21, 14, 31, 12, 280, DateTimeKind.Local).AddTicks(787), "expdsjkzwfuf", "ex", 7, true },
                    { 65, new DateTime(2021, 4, 20, 18, 46, 38, 308, DateTimeKind.Local).AddTicks(2259), new DateTime(2021, 4, 4, 17, 44, 9, 592, DateTimeKind.Local).AddTicks(1678), "fchjkcvm", "Dolore reprehenderit fugit laudantium sed rerum corporis explicabo inventore.\nPariatur quas in cum.\nEx omnis saepe non eveniet aut.\nAut tempora ullam fuga aperiam dolor eum cum repellendus.\nEt quia rerum sed voluptas nihil deserunt consequatur voluptas.\nDoloremque ipsam ex mollitia rerum optio maiores minus.", 7, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 64, new DateTime(2021, 4, 20, 18, 46, 38, 308, DateTimeKind.Local).AddTicks(1696), new DateTime(2021, 4, 20, 22, 16, 15, 671, DateTimeKind.Local).AddTicks(1822), "obajrxoeqel", "Dolor maiores soluta amet necessitatibus perspiciatis. Dignissimos illo necessitatibus error in molestiae consequatur quasi ut. Sit quibusdam nam accusantium sed ipsa voluptates itaque dolores. In et velit officia rem occaecati. Sint similique hic magni deserunt.", 7 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 63, new DateTime(2021, 4, 21, 12, 41, 52, 823, DateTimeKind.Local).AddTicks(1713), new DateTime(2020, 9, 30, 16, 10, 11, 576, DateTimeKind.Local).AddTicks(234), "pchpkaonp", "ea", 6, true },
                    { 62, new DateTime(2021, 4, 21, 9, 47, 49, 23, DateTimeKind.Local).AddTicks(7647), new DateTime(2021, 4, 21, 6, 45, 29, 652, DateTimeKind.Local).AddTicks(3981), "xyayvm", "Dolor provident consectetur.\nPorro itaque quis enim dicta harum et.\nIpsam molestiae tempore et sunt omnis veritatis.\nTemporibus ullam perspiciatis odio reiciendis et et et id quia.", 6, true },
                    { 61, new DateTime(2020, 12, 25, 19, 2, 17, 453, DateTimeKind.Local).AddTicks(9289), new DateTime(2021, 4, 21, 6, 44, 5, 736, DateTimeKind.Local).AddTicks(4352), "ugvcebe", "Provident et aspernatur vitae cupiditate nam quibusdam dolor vel quia.\nNulla tenetur iste aut sed et error.\nVeniam voluptatem est voluptatem.", 6, true },
                    { 60, new DateTime(2021, 4, 20, 21, 29, 30, 875, DateTimeKind.Local).AddTicks(8823), new DateTime(2020, 9, 20, 14, 0, 30, 978, DateTimeKind.Local).AddTicks(4611), "vpuvspuki", "Voluptatem deleniti vitae sunt.", 6, true },
                    { 59, new DateTime(2021, 4, 20, 21, 18, 55, 163, DateTimeKind.Local).AddTicks(6126), new DateTime(2021, 4, 20, 19, 7, 1, 458, DateTimeKind.Local).AddTicks(4350), "ufwehzw", "Eos quasi cumque.\nSit commodi qui aut tempora et quae doloribus aut aperiam.", 6, true },
                    { 58, new DateTime(2021, 4, 20, 18, 46, 38, 304, DateTimeKind.Local).AddTicks(4039), new DateTime(2020, 4, 29, 15, 36, 43, 382, DateTimeKind.Local).AddTicks(3806), "ljxebqpcfa", "Occaecati quia voluptatem quo impedit quo.\nItaque in accusantium iste repellendus quasi in neque quae eius.\nDolorum voluptatem ad.", 6, true },
                    { 39, new DateTime(2020, 11, 29, 19, 38, 1, 453, DateTimeKind.Local).AddTicks(57), new DateTime(2021, 4, 21, 12, 31, 52, 243, DateTimeKind.Local).AddTicks(6651), "vtiuxopufcu", "non", 4, true },
                    { 38, new DateTime(2021, 4, 21, 2, 57, 43, 964, DateTimeKind.Local).AddTicks(3895), new DateTime(2021, 3, 22, 23, 28, 40, 597, DateTimeKind.Local).AddTicks(1756), "jclparcybqgm", "dolorum", 4, true },
                    { 37, new DateTime(2021, 4, 20, 18, 46, 38, 296, DateTimeKind.Local).AddTicks(3515), new DateTime(2020, 6, 25, 14, 13, 45, 979, DateTimeKind.Local).AddTicks(9191), "hpkggambkkv", "Consequatur qui quia et et ut quae praesentium.\nVeniam voluptatem et rerum eaque et consequatur.\nPorro minus mollitia doloremque fugit molestiae aut veniam.\nNatus quaerat eum molestiae rerum praesentium.\nAut ad odit officia.", 4, true },
                    { 36, new DateTime(2020, 7, 11, 16, 44, 8, 98, DateTimeKind.Local).AddTicks(6502), new DateTime(2021, 4, 21, 11, 35, 38, 11, DateTimeKind.Local).AddTicks(3941), "onahuvt", "omnis", 4, true },
                    { 16, new DateTime(2021, 4, 20, 18, 46, 38, 290, DateTimeKind.Local).AddTicks(7844), new DateTime(2021, 4, 21, 12, 8, 52, 612, DateTimeKind.Local).AddTicks(2175), "blstwsgapx", "Ut ut id perferendis repellat libero.\nQuis omnis omnis.\nSunt eligendi dolor ab velit dicta fugiat perspiciatis voluptatum cumque.\nNihil repellat cupiditate est exercitationem deserunt ut.\nDolorum autem qui dicta quia eos expedita officia dolores eaque.", 3, true },
                    { 15, new DateTime(2021, 4, 20, 18, 46, 38, 290, DateTimeKind.Local).AddTicks(7302), new DateTime(2021, 4, 20, 21, 58, 26, 719, DateTimeKind.Local).AddTicks(862), "oawjonm", "atque", 3, true },
                    { 14, new DateTime(2021, 4, 20, 18, 46, 38, 286, DateTimeKind.Local).AddTicks(8576), new DateTime(2021, 4, 21, 4, 15, 26, 31, DateTimeKind.Local).AddTicks(1948), "horwrjh", "Quia ducimus aut praesentium.", 2, true },
                    { 13, new DateTime(2021, 4, 21, 15, 27, 16, 525, DateTimeKind.Local).AddTicks(1736), new DateTime(2020, 5, 15, 13, 41, 7, 940, DateTimeKind.Local).AddTicks(4831), "pwsksjksexbe", "corrupti", 2, true },
                    { 12, new DateTime(2020, 6, 7, 12, 43, 4, 410, DateTimeKind.Local).AddTicks(7492), new DateTime(2020, 12, 1, 14, 35, 13, 783, DateTimeKind.Local).AddTicks(6673), "borqatawxeq", "doloribus", 2, true },
                    { 11, new DateTime(2021, 4, 20, 23, 47, 21, 325, DateTimeKind.Local).AddTicks(8534), new DateTime(2020, 6, 17, 16, 37, 38, 936, DateTimeKind.Local).AddTicks(8999), "svwnxp", "Et ut magni est.\nIn quo ut earum sapiente fugiat aut necessitatibus temporibus enim.\nQuaerat culpa ut et qui sit architecto excepturi nihil a.\nAt cupiditate natus tenetur omnis dolorem tenetur.\nIusto sit accusamus accusamus.", 2, true },
                    { 10, new DateTime(2021, 4, 21, 17, 14, 33, 386, DateTimeKind.Local).AddTicks(7416), new DateTime(2020, 9, 22, 17, 45, 42, 662, DateTimeKind.Local).AddTicks(1004), "zufuqrjtb", "Non vel velit sed tempore enim voluptatum.", 2, true },
                    { 9, new DateTime(2021, 4, 21, 16, 33, 48, 699, DateTimeKind.Local).AddTicks(3473), new DateTime(2021, 2, 11, 20, 20, 18, 436, DateTimeKind.Local).AddTicks(7069), "ygptlzkn", "temporibus", 2, true },
                    { 8, new DateTime(2021, 4, 20, 18, 46, 38, 286, DateTimeKind.Local).AddTicks(6962), new DateTime(2020, 10, 22, 7, 38, 19, 981, DateTimeKind.Local).AddTicks(5426), "clmvnxnzwd", "Mollitia repellendus dicta.\nNihil perferendis velit dolorem quia et quod.\nOptio consequatur ut sit expedita laboriosam.\nAutem id et.", 2, true },
                    { 7, new DateTime(2021, 4, 4, 12, 12, 35, 878, DateTimeKind.Local).AddTicks(8785), new DateTime(2021, 4, 21, 12, 50, 24, 994, DateTimeKind.Local).AddTicks(7966), "ssiby", "eos", 2, true },
                    { 6, new DateTime(2021, 4, 21, 6, 6, 7, 84, DateTimeKind.Local).AddTicks(9558), new DateTime(2021, 4, 20, 21, 17, 28, 986, DateTimeKind.Local).AddTicks(914), "gddlniyhlvlp", "Atque non harum magnam perspiciatis quod.\nQuia sunt voluptas quibusdam.\nId incidunt dolores placeat sunt similique itaque consectetur.\nMinus consequuntur dolores occaecati odio ipsam.\nEt iste velit quis nam id sunt qui.", 2, true },
                    { 5, new DateTime(2020, 12, 18, 2, 11, 6, 730, DateTimeKind.Local).AddTicks(7338), new DateTime(2021, 4, 21, 16, 51, 41, 794, DateTimeKind.Local).AddTicks(1301), "lnwoqwjqciz", "aut", 2, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 4, new DateTime(2021, 4, 21, 14, 7, 49, 8, DateTimeKind.Local).AddTicks(4918), new DateTime(2021, 1, 19, 22, 56, 24, 418, DateTimeKind.Local).AddTicks(6176), "bjyfcsu", "Quos blanditiis sed repudiandae magnam sed quo nihil. Sint autem adipisci autem nostrum. Minus aut soluta atque qui. Sint sed alias suscipit et veniam fugit repudiandae. Quaerat rerum beatae aliquid est.", 2 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 3, new DateTime(2021, 4, 21, 6, 46, 11, 805, DateTimeKind.Local).AddTicks(7605), new DateTime(2021, 3, 3, 15, 15, 27, 463, DateTimeKind.Local).AddTicks(9391), "gzwoutvej", "Beatae sit vel vero tempora enim aut. Ab odio autem. Ut ducimus aut.", 2, true },
                    { 2, new DateTime(2021, 4, 20, 18, 46, 38, 286, DateTimeKind.Local).AddTicks(4568), new DateTime(2020, 11, 14, 17, 26, 49, 742, DateTimeKind.Local).AddTicks(2843), "bddlseelhz", "Eum sint omnis veniam voluptas.\nExpedita eos dolores voluptatem animi saepe velit architecto est.\nAt rerum sit mollitia consequatur.\nEa voluptatibus perspiciatis aut est corporis minima earum quam cupiditate.\nAperiam numquam et aut voluptas iste ut.\nIn voluptates explicabo provident.", 2, true },
                    { 17, new DateTime(2020, 8, 24, 0, 4, 37, 45, DateTimeKind.Local).AddTicks(8986), new DateTime(2021, 4, 21, 11, 30, 21, 924, DateTimeKind.Local).AddTicks(545), "fvnbddsagpmi", "Itaque quibusdam sequi sed quidem id.", 3, true },
                    { 73, new DateTime(2020, 6, 30, 7, 38, 6, 432, DateTimeKind.Local).AddTicks(4589), new DateTime(2021, 1, 15, 14, 50, 0, 801, DateTimeKind.Local).AddTicks(7480), "hmpvqqzwz", "Reiciendis esse ad porro commodi dignissimos distinctio qui omnis. Officia qui aut quam laboriosam alias. Corporis dolorem et vel repellendus consequatur odio laborum. Laboriosam vel totam. Animi ipsum deserunt voluptates aspernatur blanditiis.", 7, true },
                    { 18, new DateTime(2021, 4, 12, 14, 1, 25, 526, DateTimeKind.Local).AddTicks(971), new DateTime(2021, 4, 21, 9, 2, 48, 178, DateTimeKind.Local).AddTicks(9374), "gbhwnjk", "Libero nemo eum sed mollitia quae aspernatur.\nDistinctio ea totam dolores quos occaecati consequatur culpa veniam.\nQuis aut commodi.\nRem voluptate voluptas non suscipit est aut.", 3, true },
                    { 20, new DateTime(2021, 4, 21, 8, 49, 27, 74, DateTimeKind.Local).AddTicks(1096), new DateTime(2021, 4, 21, 17, 42, 24, 176, DateTimeKind.Local).AddTicks(8818), "aqhbexzr", "Molestiae temporibus laborum dolores voluptas sequi qui sit.", 3, true },
                    { 35, new DateTime(2021, 4, 21, 6, 27, 30, 340, DateTimeKind.Local).AddTicks(3841), new DateTime(2021, 4, 21, 2, 1, 28, 367, DateTimeKind.Local).AddTicks(6522), "kdgoktru", "Atque quaerat adipisci minima ut dolorum quasi natus rerum quod.\nEius dolor voluptatem voluptates voluptatibus numquam et sit.\nHarum earum facere nesciunt aut laudantium.\nCorporis iusto odit delectus explicabo quisquam totam ducimus eos.\nAliquid incidunt voluptate quae iure soluta quisquam soluta non beatae.", 4, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 34, new DateTime(2021, 3, 3, 14, 59, 29, 330, DateTimeKind.Local).AddTicks(96), new DateTime(2021, 4, 20, 21, 34, 6, 32, DateTimeKind.Local).AddTicks(3768), "xqswnuuiozm", "Aut assumenda facere libero molestias in quo harum vitae corporis. Nulla delectus quae. Culpa quas numquam in consequuntur quisquam aliquid. Consectetur repellendus assumenda voluptas dolores qui recusandae qui.", 4 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 33, new DateTime(2021, 4, 20, 18, 50, 58, 296, DateTimeKind.Local).AddTicks(6149), new DateTime(2021, 4, 21, 0, 25, 25, 167, DateTimeKind.Local).AddTicks(1416), "ozpzkb", "Harum quo aut et accusamus ut aperiam.", 4, true },
                    { 32, new DateTime(2021, 4, 15, 22, 53, 26, 381, DateTimeKind.Local).AddTicks(2917), new DateTime(2021, 4, 2, 9, 48, 9, 504, DateTimeKind.Local).AddTicks(7090), "dqhyssmq", "Ut molestiae asperiores ut ab excepturi numquam. Velit esse provident. Debitis aut in neque nulla autem quo qui. Suscipit reprehenderit similique delectus dolorem vel reiciendis quae. Omnis rerum alias quia.", 4, true },
                    { 31, new DateTime(2020, 12, 1, 5, 17, 27, 329, DateTimeKind.Local).AddTicks(4014), new DateTime(2020, 7, 7, 22, 6, 40, 693, DateTimeKind.Local).AddTicks(9653), "ltrtremrs", "corporis", 4, true },
                    { 30, new DateTime(2021, 4, 21, 9, 41, 46, 434, DateTimeKind.Local).AddTicks(4487), new DateTime(2021, 4, 20, 21, 14, 37, 322, DateTimeKind.Local).AddTicks(429), "sgqlhrovtu", "Fugiat odit asperiores voluptatem aut. Doloribus explicabo qui non sunt culpa repellat illo vero ut. Alias nesciunt molestiae vero architecto esse dolore laboriosam. Totam suscipit iure laboriosam modi nihil error dolores ut ut. Rerum animi sit exercitationem culpa magni nihil unde eos.", 4, true },
                    { 29, new DateTime(2021, 4, 20, 18, 57, 23, 831, DateTimeKind.Local).AddTicks(1499), new DateTime(2021, 4, 21, 11, 47, 7, 752, DateTimeKind.Local).AddTicks(8603), "dwfcao", "autem", 4, true },
                    { 28, new DateTime(2021, 3, 3, 3, 14, 24, 730, DateTimeKind.Local).AddTicks(3216), new DateTime(2021, 4, 21, 10, 21, 24, 840, DateTimeKind.Local).AddTicks(9778), "zhukopv", "Quidem impedit aperiam architecto nesciunt maiores qui repellendus corporis.\nBeatae fugiat voluptate.\nIpsam excepturi alias minus eum et facere.\nAut voluptas aspernatur accusamus enim cum omnis nam nam temporibus.\nEt qui natus quo.", 4, true },
                    { 27, new DateTime(2021, 2, 4, 4, 48, 54, 743, DateTimeKind.Local).AddTicks(7564), new DateTime(2021, 2, 11, 6, 12, 19, 543, DateTimeKind.Local).AddTicks(468), "fcivebs", "Dicta dicta sunt et.\nVoluptate rerum et consequatur ut placeat.", 4, true },
                    { 26, new DateTime(2020, 10, 3, 9, 9, 10, 715, DateTimeKind.Local).AddTicks(8988), new DateTime(2021, 4, 20, 19, 36, 14, 710, DateTimeKind.Local).AddTicks(4353), "yuwot", "Sequi laborum doloribus aliquam libero sunt dolor recusandae atque.\nAutem ipsum voluptate omnis deleniti temporibus architecto.\nAperiam reprehenderit quis et in et tempore voluptate ea soluta.\nLibero enim minus voluptatum repellendus cumque quia.\nDoloribus et temporibus repudiandae delectus perspiciatis hic cumque.\nDistinctio voluptatem ipsam architecto deleniti debitis.", 4, true },
                    { 25, new DateTime(2021, 4, 21, 11, 28, 41, 253, DateTimeKind.Local).AddTicks(9911), new DateTime(2021, 4, 10, 22, 0, 9, 483, DateTimeKind.Local).AddTicks(1430), "mhmlfc", "Facilis at recusandae eligendi dolore totam.", 4, true },
                    { 24, new DateTime(2021, 4, 20, 18, 46, 38, 296, DateTimeKind.Local).AddTicks(394), new DateTime(2021, 1, 11, 12, 32, 21, 559, DateTimeKind.Local).AddTicks(9842), "dofiwd", "Laborum rerum iste et. Eos quaerat iure impedit. Odit et illo harum velit deleniti voluptatem.", 4, true },
                    { 23, new DateTime(2021, 4, 21, 0, 4, 34, 951, DateTimeKind.Local).AddTicks(8805), new DateTime(2021, 1, 5, 12, 35, 43, 84, DateTimeKind.Local).AddTicks(1565), "zjyrebycpcs", "Hic maxime quo earum amet consequatur temporibus qui. Fugiat explicabo maiores qui. Aut et ipsa. Adipisci veritatis dolorem ducimus animi at soluta. Aut quia quis non omnis laudantium sunt dolore maxime.", 4, true },
                    { 22, new DateTime(2020, 5, 1, 18, 33, 27, 587, DateTimeKind.Local).AddTicks(4017), new DateTime(2020, 5, 15, 6, 16, 24, 926, DateTimeKind.Local).AddTicks(9114), "esnkyhegal", "Qui illo est perspiciatis qui necessitatibus. Corporis modi vel ab vero aut minima aut corporis. Quaerat optio voluptas suscipit unde. Aperiam id aut dolorem vel iste molestias officiis et quae. Aut facilis rem enim enim.", 4, true },
                    { 21, new DateTime(2021, 4, 20, 19, 19, 36, 929, DateTimeKind.Local).AddTicks(960), new DateTime(2021, 4, 21, 14, 17, 7, 94, DateTimeKind.Local).AddTicks(4420), "kmmgefuxwfa", "Voluptas sed natus quia recusandae odio nulla cumque. Nobis reprehenderit sit quod quia. Eos nobis laborum at ullam et quas dolor fugit. Tempora alias nihil est natus eos aut. Reiciendis qui provident quia harum possimus.", 3, true },
                    { 19, new DateTime(2021, 4, 20, 20, 1, 40, 308, DateTimeKind.Local).AddTicks(5750), new DateTime(2020, 4, 29, 19, 35, 18, 707, DateTimeKind.Local).AddTicks(1756), "opmkww", "Maxime error facere officiis et et commodi incidunt praesentium.", 3, true },
                    { 74, new DateTime(2021, 4, 20, 18, 46, 38, 308, DateTimeKind.Local).AddTicks(3347), new DateTime(2021, 3, 13, 20, 55, 37, 499, DateTimeKind.Local).AddTicks(3529), "xzvfhzeryda", "est", 7, true },
                    { 75, new DateTime(2021, 4, 20, 18, 46, 38, 308, DateTimeKind.Local).AddTicks(3720), new DateTime(2020, 11, 22, 14, 50, 26, 462, DateTimeKind.Local).AddTicks(8055), "kzbiwferowj", "Dolorum minima consequuntur explicabo corrupti labore molestiae.\nDucimus debitis et pariatur.\nIusto reprehenderit nesciunt nostrum odit recusandae ipsa rem alias dolor.\nEa repellendus aut aut autem quis soluta deleniti distinctio veniam.\nDelectus reiciendis consectetur accusamus ut eveniet.\nUnde sit esse aperiam.", 7, true },
                    { 76, new DateTime(2021, 4, 20, 18, 46, 38, 308, DateTimeKind.Local).AddTicks(3773), new DateTime(2021, 3, 15, 1, 39, 51, 830, DateTimeKind.Local).AddTicks(4765), "cqmgrsfxwefl", "eligendi", 7, true },
                    { 129, new DateTime(2021, 2, 21, 10, 32, 12, 161, DateTimeKind.Local).AddTicks(3845), new DateTime(2021, 4, 21, 6, 45, 49, 376, DateTimeKind.Local).AddTicks(7548), "ogfntioez", "repellendus", 10, true },
                    { 128, new DateTime(2021, 4, 20, 22, 4, 31, 912, DateTimeKind.Local).AddTicks(9514), new DateTime(2021, 4, 21, 18, 29, 13, 750, DateTimeKind.Local).AddTicks(4662), "ndzirkr", "Voluptatem repudiandae aliquam.\nDignissimos et laudantium quia.\nQuibusdam molestias velit officia illum.\nQui quidem non molestiae enim.\nQui sit iste quas.\nIpsam dolores minima est dolorem illum.", 10, true },
                    { 127, new DateTime(2021, 3, 28, 1, 32, 30, 626, DateTimeKind.Local).AddTicks(522), new DateTime(2021, 4, 21, 8, 54, 29, 303, DateTimeKind.Local).AddTicks(2689), "swjhtjmuap", "Hic et at quia ut labore odit ea et.", 10, true },
                    { 126, new DateTime(2021, 4, 21, 10, 22, 4, 14, DateTimeKind.Local).AddTicks(8128), new DateTime(2021, 4, 21, 14, 36, 52, 990, DateTimeKind.Local).AddTicks(297), "uthhk", "Voluptates a vitae et sapiente voluptates aut commodi sed.\nEos aut eos nam ea inventore quia.\nNeque enim ad.", 10, true },
                    { 125, new DateTime(2021, 4, 20, 18, 46, 38, 331, DateTimeKind.Local).AddTicks(3101), new DateTime(2021, 2, 12, 4, 34, 18, 53, DateTimeKind.Local).AddTicks(4143), "jcpobacys", "Aut voluptatem tenetur officia fuga quaerat ducimus rerum rerum sunt.", 10, true },
                    { 124, new DateTime(2020, 6, 27, 8, 45, 4, 158, DateTimeKind.Local).AddTicks(815), new DateTime(2021, 4, 21, 15, 13, 26, 634, DateTimeKind.Local).AddTicks(331), "mactxpmj", "qui", 10, true },
                    { 123, new DateTime(2021, 4, 20, 18, 46, 38, 331, DateTimeKind.Local).AddTicks(2974), new DateTime(2021, 4, 20, 19, 13, 49, 976, DateTimeKind.Local).AddTicks(6437), "kbgchxzct", "Quis blanditiis illum quis tempore ad incidunt repellat quo qui.", 10, true },
                    { 122, new DateTime(2021, 4, 20, 18, 46, 38, 331, DateTimeKind.Local).AddTicks(2888), new DateTime(2020, 6, 15, 16, 53, 4, 651, DateTimeKind.Local).AddTicks(6079), "pectroriy", "vitae", 10, true },
                    { 121, new DateTime(2021, 4, 20, 18, 46, 38, 331, DateTimeKind.Local).AddTicks(2842), new DateTime(2021, 3, 13, 5, 22, 41, 775, DateTimeKind.Local).AddTicks(3987), "gmitjdjyeic", "voluptas", 10, true },
                    { 120, new DateTime(2021, 4, 20, 20, 22, 31, 991, DateTimeKind.Local).AddTicks(4047), new DateTime(2021, 4, 21, 17, 2, 7, 766, DateTimeKind.Local).AddTicks(4973), "rtaklj", "id", 10, true },
                    { 119, new DateTime(2021, 4, 20, 18, 46, 38, 331, DateTimeKind.Local).AddTicks(2762), new DateTime(2021, 4, 21, 2, 13, 23, 152, DateTimeKind.Local).AddTicks(1837), "btozqmvkjsc", "ratione", 10, true },
                    { 118, new DateTime(2021, 4, 20, 22, 54, 34, 82, DateTimeKind.Local).AddTicks(5381), new DateTime(2021, 4, 21, 10, 5, 38, 648, DateTimeKind.Local).AddTicks(9523), "rxpkgcvounca", "quos", 10, true },
                    { 117, new DateTime(2021, 4, 20, 18, 46, 38, 331, DateTimeKind.Local).AddTicks(2680), new DateTime(2021, 4, 20, 20, 9, 18, 38, DateTimeKind.Local).AddTicks(6687), "bdlluyvwppuk", "Repellat consectetur voluptas doloremque officia.", 10, true },
                    { 116, new DateTime(2021, 4, 20, 18, 46, 38, 331, DateTimeKind.Local).AddTicks(2615), new DateTime(2021, 4, 21, 8, 45, 11, 244, DateTimeKind.Local).AddTicks(6265), "xynvdixtpb", "eum", 10, true },
                    { 115, new DateTime(2021, 4, 20, 18, 46, 38, 331, DateTimeKind.Local).AddTicks(2571), new DateTime(2021, 4, 21, 15, 8, 30, 25, DateTimeKind.Local).AddTicks(5392), "ynercocrk", "Vel ut sunt et non. Aut ipsa nostrum ipsa. In rerum ipsa consectetur recusandae et ratione commodi nulla. Quaerat quia sit corporis aspernatur quod sunt explicabo.", 10, true },
                    { 130, new DateTime(2020, 9, 17, 22, 16, 17, 436, DateTimeKind.Local).AddTicks(2489), new DateTime(2020, 6, 3, 18, 6, 28, 671, DateTimeKind.Local).AddTicks(1157), "ozbrqrclaxmt", "Et laborum tempore vel sit non ratione non.\nEt consequatur et.\nQuia quis porro nostrum velit recusandae sit.", 11, true },
                    { 114, new DateTime(2020, 4, 29, 17, 34, 27, 13, DateTimeKind.Local).AddTicks(171), new DateTime(2021, 4, 21, 11, 28, 9, 552, DateTimeKind.Local).AddTicks(2914), "uvredpdk", "blanditiis", 10, true },
                    { 131, new DateTime(2021, 3, 30, 3, 11, 11, 295, DateTimeKind.Local).AddTicks(9976), new DateTime(2021, 4, 7, 13, 49, 4, 92, DateTimeKind.Local).AddTicks(2047), "btanfv", "rerum", 11, true },
                    { 133, new DateTime(2021, 4, 20, 18, 46, 38, 333, DateTimeKind.Local).AddTicks(7331), new DateTime(2021, 4, 21, 12, 15, 20, 884, DateTimeKind.Local).AddTicks(2408), "pmvwsivgdnfk", "Sequi nihil accusamus et laboriosam occaecati voluptas vero quibusdam quisquam. Laudantium nisi sed nesciunt ut voluptatibus et omnis nihil consequatur. Qui repellat voluptas officia iure veniam sit eligendi. Nesciunt cupiditate omnis aspernatur. Possimus temporibus illo autem.", 11, true },
                    { 148, new DateTime(2021, 4, 20, 18, 46, 38, 333, DateTimeKind.Local).AddTicks(9682), new DateTime(2020, 6, 18, 4, 45, 39, 826, DateTimeKind.Local).AddTicks(5853), "tpsklnvi", "Animi quod ut corrupti ea minus et eum. Repellat sunt pariatur delectus quis et dolores. Error facere totam sed molestiae autem atque beatae quisquam recusandae. Doloremque quia quaerat placeat corrupti corrupti qui et vel cumque. Est nam odit cupiditate ducimus quia id quod.", 11, true },
                    { 147, new DateTime(2021, 4, 20, 18, 46, 38, 333, DateTimeKind.Local).AddTicks(9437), new DateTime(2020, 12, 3, 7, 22, 2, 642, DateTimeKind.Local).AddTicks(8619), "dofevbrxppc", "Voluptatem nulla sequi nam magni autem accusantium cupiditate qui. Libero molestiae voluptas nihil. Perferendis culpa sed perferendis incidunt quam ex.", 11, true },
                    { 146, new DateTime(2021, 2, 11, 16, 7, 56, 81, DateTimeKind.Local).AddTicks(481), new DateTime(2021, 4, 21, 18, 30, 17, 754, DateTimeKind.Local).AddTicks(5376), "tmpmwfikhheo", "Ratione error omnis adipisci sit dolor qui. Mollitia sunt rerum iusto non nulla. Quia voluptas sint. Aut reiciendis similique blanditiis. Alias perspiciatis sint omnis nisi non odio sunt voluptate nobis. Eos blanditiis ut.", 11, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 145, new DateTime(2021, 4, 20, 18, 46, 38, 333, DateTimeKind.Local).AddTicks(9077), new DateTime(2020, 11, 16, 13, 57, 45, 889, DateTimeKind.Local).AddTicks(5905), "hbevukvqp", "Aut corporis excepturi sed in non.\nLabore quia nobis officia suscipit quidem praesentium.\nSint ex nihil.\nQuae fuga dignissimos.\nRerum possimus quia debitis.\nNulla fuga sunt sit iure.", 11 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 144, new DateTime(2021, 4, 21, 17, 13, 58, 880, DateTimeKind.Local).AddTicks(5968), new DateTime(2020, 10, 20, 16, 34, 36, 813, DateTimeKind.Local).AddTicks(3438), "xgtnjiaas", "Aut et necessitatibus vel ea numquam.\nQuaerat quisquam corrupti qui sed molestiae voluptas.\nId accusantium molestiae voluptatem itaque quae.\nQuod et quaerat tempore et dolore dolorum quaerat.", 11, true },
                    { 143, new DateTime(2021, 4, 21, 15, 45, 28, 544, DateTimeKind.Local).AddTicks(6249), new DateTime(2021, 4, 21, 1, 48, 22, 421, DateTimeKind.Local).AddTicks(8192), "jtkna", "Deserunt veritatis saepe aut. Sed modi dolores et perferendis eligendi. Ea accusamus autem explicabo deleniti asperiores inventore ipsam optio ratione. Et repudiandae perferendis dolor. Iste est exercitationem. Totam labore rerum est.", 11, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 142, new DateTime(2021, 4, 21, 7, 8, 25, 332, DateTimeKind.Local).AddTicks(4544), new DateTime(2021, 4, 21, 7, 28, 51, 813, DateTimeKind.Local).AddTicks(6326), "rttud", "Voluptatibus aspernatur inventore. Soluta ut voluptas voluptate ab. Nesciunt ex modi eum deserunt voluptatem quo magnam. Consequuntur iste omnis. Sequi quia doloribus ipsam voluptate sed tempore ut cum ea.", 11, true },
                    { 141, new DateTime(2021, 4, 21, 15, 53, 11, 576, DateTimeKind.Local).AddTicks(1504), new DateTime(2021, 4, 20, 19, 45, 1, 519, DateTimeKind.Local).AddTicks(1766), "pfpnnai", "Nihil repellat doloribus quia minima qui nobis sunt aut.\nDolores asperiores et accusamus veniam.", 11, true },
                    { 140, new DateTime(2020, 5, 12, 11, 25, 44, 83, DateTimeKind.Local).AddTicks(4516), new DateTime(2020, 12, 24, 14, 29, 50, 680, DateTimeKind.Local).AddTicks(682), "mhjkqmajyjr", "Et perspiciatis aspernatur debitis quae soluta modi.", 11, true },
                    { 139, new DateTime(2021, 4, 20, 18, 46, 38, 333, DateTimeKind.Local).AddTicks(8107), new DateTime(2021, 4, 21, 16, 45, 8, 854, DateTimeKind.Local).AddTicks(9404), "eojgkmcjefm", "Nihil facilis quia consequatur soluta nesciunt et et. Dolorem consequatur et commodi. Quia quos doloribus cupiditate. Vel consequatur aut voluptate.", 11, true },
                    { 138, new DateTime(2021, 4, 20, 18, 46, 38, 333, DateTimeKind.Local).AddTicks(7957), new DateTime(2020, 8, 20, 6, 26, 42, 259, DateTimeKind.Local).AddTicks(3946), "jrontyloa", "Pariatur quis iure et.", 11, true },
                    { 137, new DateTime(2021, 2, 7, 19, 55, 38, 84, DateTimeKind.Local).AddTicks(7831), new DateTime(2020, 12, 27, 14, 10, 1, 928, DateTimeKind.Local).AddTicks(6505), "phirueghqv", "Saepe debitis ea a voluptas sunt.\nUt voluptatibus labore.\nVoluptate odit vel ut.\nRepellendus harum maiores fugit.", 11, true },
                    { 136, new DateTime(2020, 12, 16, 10, 2, 31, 351, DateTimeKind.Local).AddTicks(6446), new DateTime(2021, 1, 21, 11, 58, 34, 138, DateTimeKind.Local).AddTicks(1831), "yovrija", "consequatur", 11, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 135, new DateTime(2021, 3, 16, 18, 24, 6, 591, DateTimeKind.Local).AddTicks(9560), new DateTime(2021, 4, 20, 20, 49, 36, 765, DateTimeKind.Local).AddTicks(68), "lzpeoewtp", "Sed distinctio quia aut rem praesentium est provident nesciunt qui. Necessitatibus error corporis dolore laboriosam recusandae itaque tempore voluptates recusandae. Nostrum reiciendis culpa doloremque numquam quaerat aut pariatur molestiae exercitationem. Magnam quidem rem nesciunt nam harum doloremque.", 11 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[] { 134, new DateTime(2021, 4, 21, 6, 20, 2, 723, DateTimeKind.Local).AddTicks(3014), new DateTime(2021, 4, 21, 6, 28, 55, 440, DateTimeKind.Local).AddTicks(4693), "zefulzpnhw", "facere", 11, true });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 132, new DateTime(2021, 4, 20, 18, 46, 38, 333, DateTimeKind.Local).AddTicks(7065), new DateTime(2021, 4, 21, 9, 53, 3, 713, DateTimeKind.Local).AddTicks(2965), "qlogteeosid", "Omnis reiciendis fugiat aut qui exercitationem quo rem voluptatem.\nDolor in expedita voluptate cumque eveniet dolorum ratione.", 11 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 150, new DateTime(2021, 4, 20, 21, 25, 42, 748, DateTimeKind.Local).AddTicks(6496), new DateTime(2021, 2, 9, 5, 4, 34, 450, DateTimeKind.Local).AddTicks(7880), "yhizxkajmslh", "Nostrum perferendis pariatur iure facere sequi impedit aliquid autem voluptatem.\nVoluptatem saepe similique necessitatibus recusandae quaerat.\nUt odio dolor et cumque saepe accusamus suscipit alias.", 12, true },
                    { 113, new DateTime(2020, 9, 2, 1, 12, 28, 256, DateTimeKind.Local).AddTicks(395), new DateTime(2020, 5, 27, 7, 48, 0, 285, DateTimeKind.Local).AddTicks(2839), "rgkboldmott", "Ut non eligendi. Harum saepe enim asperiores unde modi nihil. Eveniet aut quibusdam dolores dolorem et enim.", 10, true },
                    { 111, new DateTime(2020, 12, 17, 9, 19, 42, 355, DateTimeKind.Local).AddTicks(6817), new DateTime(2021, 4, 20, 18, 59, 34, 281, DateTimeKind.Local).AddTicks(477), "pmokydn", "quae", 10, true },
                    { 91, new DateTime(2021, 4, 21, 9, 58, 15, 480, DateTimeKind.Local).AddTicks(8750), new DateTime(2021, 4, 21, 17, 2, 32, 530, DateTimeKind.Local).AddTicks(5763), "uhuzivxja", "Quibusdam est velit aliquid unde expedita suscipit culpa quis quis.\nDicta perferendis ut vel ullam ut praesentium eum.\nQui iusto eaque eaque quis nemo est corrupti qui neque.", 8, true },
                    { 90, new DateTime(2021, 4, 20, 18, 46, 38, 324, DateTimeKind.Local).AddTicks(4035), new DateTime(2021, 1, 23, 19, 35, 58, 474, DateTimeKind.Local).AddTicks(8757), "zimnniy", "est", 8, true },
                    { 89, new DateTime(2021, 4, 20, 18, 46, 38, 324, DateTimeKind.Local).AddTicks(3980), new DateTime(2020, 5, 12, 4, 49, 52, 519, DateTimeKind.Local).AddTicks(8894), "mfnnlquqhhgm", "Aliquid necessitatibus corrupti recusandae incidunt.\nNihil ratione laudantium et quia culpa quasi nihil aperiam aspernatur.\nFuga veniam dolorem illo iure.\nAlias voluptate cumque animi totam beatae id.\nCupiditate molestias fugiat dolorum expedita et.\nIllum asperiores ipsa vitae architecto qui aut ipsa cumque.", 8, true },
                    { 88, new DateTime(2021, 4, 20, 22, 52, 55, 509, DateTimeKind.Local).AddTicks(7190), new DateTime(2021, 4, 21, 8, 2, 27, 76, DateTimeKind.Local).AddTicks(8623), "slbgrpqb", "Veniam molestiae aspernatur molestiae doloremque.\nEius voluptas ex alias sint magni.", 8, true },
                    { 87, new DateTime(2021, 4, 21, 16, 42, 23, 146, DateTimeKind.Local).AddTicks(385), new DateTime(2020, 8, 8, 3, 19, 15, 436, DateTimeKind.Local).AddTicks(8400), "wrahwy", "Aut enim fuga minima.", 8, true },
                    { 86, new DateTime(2021, 4, 21, 11, 47, 4, 156, DateTimeKind.Local).AddTicks(7572), new DateTime(2021, 4, 21, 10, 29, 9, 43, DateTimeKind.Local).AddTicks(6709), "nqhibytu", "provident", 8, true },
                    { 85, new DateTime(2021, 4, 20, 18, 46, 38, 324, DateTimeKind.Local).AddTicks(3420), new DateTime(2020, 5, 17, 3, 19, 17, 827, DateTimeKind.Local).AddTicks(7234), "fqfif", "Eum temporibus quibusdam est reprehenderit dolorem aperiam et.\nSed omnis quam.", 8, true },
                    { 84, new DateTime(2021, 4, 20, 18, 46, 38, 324, DateTimeKind.Local).AddTicks(3313), new DateTime(2020, 4, 24, 5, 14, 16, 757, DateTimeKind.Local).AddTicks(9482), "xaqeysu", "Praesentium consequuntur incidunt iure qui et. Vel reiciendis aut dolorem aliquid aut. Perspiciatis est consequatur culpa labore non. Harum suscipit iusto laborum alias aut iusto blanditiis. Est reprehenderit non quo atque cupiditate quibusdam voluptatem ad.", 8, true },
                    { 83, new DateTime(2021, 4, 20, 18, 46, 38, 324, DateTimeKind.Local).AddTicks(3075), new DateTime(2021, 4, 21, 9, 0, 4, 22, DateTimeKind.Local).AddTicks(6917), "pesnbqq", "Quos ipsam rerum explicabo rerum est doloremque.", 8, true },
                    { 82, new DateTime(2021, 4, 20, 23, 22, 39, 567, DateTimeKind.Local).AddTicks(7712), new DateTime(2021, 4, 21, 0, 45, 16, 543, DateTimeKind.Local).AddTicks(4221), "ukuazzict", "Voluptatem possimus ut odit voluptatem autem nobis.\nAb deleniti possimus optio inventore ipsam.\nVoluptates iusto nihil sunt omnis ut exercitationem deleniti asperiores et.", 8, true },
                    { 81, new DateTime(2021, 4, 20, 18, 46, 38, 324, DateTimeKind.Local).AddTicks(2819), new DateTime(2020, 8, 29, 1, 19, 7, 116, DateTimeKind.Local).AddTicks(2985), "hkwjescjhrr", "laboriosam", 8, true },
                    { 80, new DateTime(2020, 11, 23, 3, 38, 19, 890, DateTimeKind.Local).AddTicks(2619), new DateTime(2021, 4, 20, 20, 43, 55, 717, DateTimeKind.Local).AddTicks(4921), "eqjqrv", "Doloribus doloremque exercitationem.\nIn provident voluptate in ea repellendus velit quis dolorem expedita.", 8, true },
                    { 79, new DateTime(2021, 4, 5, 2, 57, 40, 110, DateTimeKind.Local).AddTicks(6346), new DateTime(2021, 4, 21, 17, 30, 14, 783, DateTimeKind.Local).AddTicks(1965), "bqjmckfc", "Hic reprehenderit deleniti error ea ut est veniam impedit vel. Nostrum et exercitationem omnis necessitatibus et doloribus hic corporis excepturi. Dignissimos ut facere ut consequatur. Et illo eligendi aut id enim sed repellendus vero sed. Omnis est aut. Eaque sed nisi eos velit sit dolores quisquam aut.", 8, true },
                    { 78, new DateTime(2021, 4, 21, 2, 52, 48, 752, DateTimeKind.Local).AddTicks(8735), new DateTime(2020, 11, 15, 15, 48, 21, 850, DateTimeKind.Local).AddTicks(3267), "nanwtgly", "Sunt voluptatibus dolor accusantium est quibusdam ducimus tenetur. Ut quam ipsa nobis. Temporibus et earum iure mollitia eos aspernatur quis ad quibusdam. Et ullam voluptatem.", 7, true },
                    { 77, new DateTime(2020, 9, 13, 14, 52, 38, 406, DateTimeKind.Local).AddTicks(5986), new DateTime(2021, 2, 20, 22, 22, 38, 500, DateTimeKind.Local).AddTicks(7577), "lpmjoht", "Cumque omnis sed et rem quod. Dolorem tempore voluptatibus suscipit reprehenderit maiores doloribus. Non est pariatur tempora laudantium aut placeat omnis et. Eveniet omnis voluptatem eos. Sit necessitatibus iusto omnis quisquam molestiae corrupti dicta tenetur odio.", 7, true },
                    { 92, new DateTime(2021, 4, 20, 18, 46, 38, 328, DateTimeKind.Local).AddTicks(5085), new DateTime(2021, 4, 21, 4, 52, 17, 926, DateTimeKind.Local).AddTicks(1537), "lblfnqszzl", "Eos sit possimus commodi similique nesciunt voluptatibus.\nConsequatur pariatur asperiores consequuntur.\nEaque nisi nulla quam quidem optio dolore est in.", 9, true },
                    { 112, new DateTime(2021, 2, 25, 0, 43, 14, 634, DateTimeKind.Local).AddTicks(9965), new DateTime(2021, 2, 26, 5, 48, 33, 220, DateTimeKind.Local).AddTicks(5373), "uhxvzpgkkx", "et", 10, true },
                    { 93, new DateTime(2021, 4, 20, 18, 46, 38, 328, DateTimeKind.Local).AddTicks(5329), new DateTime(2020, 12, 10, 10, 15, 8, 716, DateTimeKind.Local).AddTicks(1446), "aztzukkoel", "Velit praesentium explicabo omnis in ex.\nPerspiciatis qui ut.\nAssumenda laudantium dolores et.\nAb quod nemo saepe.", 9, true },
                    { 95, new DateTime(2020, 8, 15, 8, 41, 18, 251, DateTimeKind.Local).AddTicks(3813), new DateTime(2020, 8, 26, 11, 10, 49, 489, DateTimeKind.Local).AddTicks(3082), "ixikds", "Aut autem qui minus repellat enim molestiae.", 9, true },
                    { 110, new DateTime(2020, 7, 21, 5, 7, 56, 215, DateTimeKind.Local).AddTicks(326), new DateTime(2021, 4, 21, 12, 55, 15, 970, DateTimeKind.Local).AddTicks(8235), "ytjcfooummq", "iure", 10, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 109, new DateTime(2021, 4, 20, 18, 46, 38, 331, DateTimeKind.Local).AddTicks(1705), new DateTime(2021, 4, 20, 21, 42, 8, 986, DateTimeKind.Local).AddTicks(7564), "vbyjpdl", "Voluptas quo est magnam officia maxime aliquid. Delectus aperiam in. Repellat maxime vel veritatis voluptatem sapiente. Ipsa ea blanditiis sapiente quaerat temporibus. Doloribus voluptas rem harum iusto beatae ut laborum autem.", 10 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 108, new DateTime(2021, 1, 8, 17, 11, 8, 510, DateTimeKind.Local).AddTicks(2237), new DateTime(2021, 4, 21, 0, 16, 5, 672, DateTimeKind.Local).AddTicks(5622), "zouamx", "Quia unde a est saepe. A eos quasi nam ullam. Corrupti cum unde ipsum est et deserunt illo incidunt. Consectetur nisi est praesentium voluptas enim. Incidunt hic in dolorum. Recusandae adipisci dicta possimus accusamus sit qui incidunt harum vel.", 9, true },
                    { 107, new DateTime(2020, 7, 16, 16, 28, 13, 479, DateTimeKind.Local).AddTicks(3849), new DateTime(2021, 3, 17, 12, 38, 0, 103, DateTimeKind.Local).AddTicks(5695), "ojprmbfto", "Ea repellendus debitis fuga laboriosam qui consequatur sed. Molestias repellendus autem optio itaque quis non aliquam nam. Mollitia quia vitae ut et at ducimus officiis quae aliquam. Nulla atque quas quia quaerat quod ipsa provident.", 9, true },
                    { 106, new DateTime(2021, 4, 20, 18, 46, 38, 328, DateTimeKind.Local).AddTicks(6687), new DateTime(2021, 4, 21, 5, 4, 47, 918, DateTimeKind.Local).AddTicks(3382), "paqccfoy", "Praesentium molestiae itaque eius vitae aut aliquid dolorem voluptas.\nFuga dolorem maiores.\nDolorem inventore rem dolores fugit mollitia veniam.\nVeritatis ea sed animi vel magni velit assumenda enim qui.\nQui temporibus quis et magni ex aut.\nAtque ea ad maiores quo nam.", 9, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 105, new DateTime(2020, 12, 7, 19, 18, 10, 454, DateTimeKind.Local).AddTicks(6918), new DateTime(2021, 4, 21, 14, 40, 6, 992, DateTimeKind.Local).AddTicks(2500), "gxfqiguij", "quo", 9 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 104, new DateTime(2020, 5, 16, 11, 29, 28, 652, DateTimeKind.Local).AddTicks(686), new DateTime(2020, 5, 14, 17, 12, 27, 809, DateTimeKind.Local).AddTicks(9799), "lemsy", "Autem quae nesciunt aut illo quaerat dolorem dolor voluptatem.\nSunt culpa sunt sunt aliquid culpa enim odit.\nDolor qui odio ea porro ipsa excepturi consequatur sint.\nQuidem in at est incidunt quisquam aut accusamus et possimus.\nTemporibus similique temporibus tempore laboriosam.\nMolestias ex qui aut nihil qui.", 9, true },
                    { 103, new DateTime(2021, 4, 21, 9, 36, 37, 472, DateTimeKind.Local).AddTicks(8311), new DateTime(2021, 4, 2, 1, 15, 43, 545, DateTimeKind.Local).AddTicks(9101), "jkdmvdbplcli", "Distinctio ab explicabo voluptatem accusantium repudiandae consequatur.", 9, true },
                    { 102, new DateTime(2020, 8, 30, 20, 24, 7, 136, DateTimeKind.Local).AddTicks(9919), new DateTime(2021, 4, 21, 6, 47, 14, 26, DateTimeKind.Local).AddTicks(4368), "mbgsqrbwwb", "Et accusamus ullam inventore facilis quo repudiandae est deserunt architecto.", 9, true },
                    { 101, new DateTime(2021, 4, 21, 2, 33, 55, 36, DateTimeKind.Local).AddTicks(7615), new DateTime(2021, 4, 21, 2, 0, 9, 742, DateTimeKind.Local).AddTicks(6169), "ctmfepy", "sapiente", 9, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[,]
                {
                    { 100, new DateTime(2020, 8, 25, 0, 17, 37, 730, DateTimeKind.Local).AddTicks(9569), new DateTime(2021, 3, 2, 4, 59, 15, 17, DateTimeKind.Local).AddTicks(7888), "geqdny", "quis", 9, true },
                    { 99, new DateTime(2021, 4, 21, 3, 24, 33, 402, DateTimeKind.Local).AddTicks(2103), new DateTime(2020, 7, 1, 15, 10, 0, 220, DateTimeKind.Local).AddTicks(2839), "zafsfl", "amet", 9, true },
                    { 98, new DateTime(2021, 4, 21, 5, 35, 3, 197, DateTimeKind.Local).AddTicks(773), new DateTime(2021, 1, 1, 9, 28, 26, 543, DateTimeKind.Local).AddTicks(1371), "hemzfvik", "sed", 9, true },
                    { 97, new DateTime(2020, 10, 17, 8, 13, 34, 518, DateTimeKind.Local).AddTicks(4905), new DateTime(2020, 6, 6, 0, 46, 21, 706, DateTimeKind.Local).AddTicks(5079), "xxtnzljk", "Aut sunt cum.\nAnimi inventore facilis provident consequatur odit aut.\nVoluptas quos est possimus dolores tenetur qui inventore.", 9, true },
                    { 96, new DateTime(2021, 4, 20, 18, 46, 38, 328, DateTimeKind.Local).AddTicks(5600), new DateTime(2021, 4, 21, 4, 1, 6, 528, DateTimeKind.Local).AddTicks(4944), "vahxzrepyto", "Dignissimos laboriosam unde. Assumenda accusamus quaerat. Iure possimus provident rerum omnis qui pariatur et ut.", 9, true }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId" },
                values: new object[] { 94, new DateTime(2021, 4, 20, 18, 46, 38, 328, DateTimeKind.Local).AddTicks(5377), new DateTime(2021, 2, 28, 18, 29, 50, 900, DateTimeKind.Local).AddTicks(1663), "wmgnizqg", "possimus", 9 });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "AvailableFrom", "AvailableTill", "Code", "Description", "ServiceId", "Status" },
                values: new object[] { 301, new DateTime(2021, 4, 21, 16, 19, 8, 609, DateTimeKind.Local).AddTicks(6240), new DateTime(2020, 11, 10, 5, 5, 14, 693, DateTimeKind.Local).AddTicks(2142), "uvckpqxybctu", "non", 20, true });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Promocodes_ServiceId",
                table: "Promocodes",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPromocode_UserId",
                table: "UserPromocode",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "UserPromocode");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Promocodes");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
