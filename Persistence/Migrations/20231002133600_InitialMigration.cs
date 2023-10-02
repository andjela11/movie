using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true),
                    Genre = table.Column<string>(type: "longtext", nullable: true),
                    ImdbURL = table.Column<string>(type: "longtext", nullable: true),
                    ImdbRating = table.Column<float>(type: "float", nullable: false),
                    Synopsis = table.Column<string>(type: "longtext", nullable: true),
                    Released = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CreatedAt", "Genre", "ImdbRating", "ImdbURL", "Released", "Synopsis", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 18, 13, 24, 1, 732, DateTimeKind.Local).AddTicks(4857), "Blues,Soul,Rock", 7.4f, "98711 Horace Drive, Yasmeenberg, Honduras,5828 Jacobi Center, East Carlosbury, Netherlands,889 Kendrick Ramp, Naderburgh, Kyrgyz Republic", 2022, "Consectetur quia facilis perspiciatis dolore quos. Dolorum culpa distinctio esse quisquam eum sed illo tempore blanditiis. Quas et officia sunt non quidem dolor beatae.", "Kira", new DateTime(2023, 10, 2, 13, 35, 59, 946, DateTimeKind.Utc).AddTicks(4131) },
                    { 2, new DateTime(2023, 4, 10, 17, 6, 48, 659, DateTimeKind.Local).AddTicks(9212), "Reggae,Funk,World", 7.4f, "292 Destiney Cliffs, North Lourdes, Uganda,752 Marco Cove, Karlibury, Comoros,99280 Daniel Estates, Jeradberg, Bahrain", 2023, "Et veniam culpa quasi quo. Molestiae ullam quos voluptas omnis occaecati iste sequi. Eum cum hic est tempore sapiente maxime veniam. Qui tenetur eos neque magnam qui consequatur optio repellat. Nihil sed vel dolor magnam sit consequuntur. Officiis in enim porro quaerat voluptatum.", "Antonia", new DateTime(2023, 10, 2, 13, 35, 59, 947, DateTimeKind.Utc).AddTicks(5524) },
                    { 3, new DateTime(2022, 10, 8, 8, 24, 42, 481, DateTimeKind.Local).AddTicks(6962), "Blues,Classical,Non Music", 7.4f, "65817 Abshire Crest, North Celestinochester, French Guiana,981 Elroy Points, South Camila, Bolivia,36828 Maggie Burg, Dickinsonside, Sao Tome and Principe", 2023, "Veritatis laudantium ratione placeat delectus repudiandae est quis sint placeat. Aut harum officiis dolor nobis et perspiciatis et debitis. Sequi velit sequi enim voluptas. Quia eum dolor debitis dolores aut ut fuga maiores.", "Breana", new DateTime(2023, 10, 2, 13, 35, 59, 950, DateTimeKind.Utc).AddTicks(7251) },
                    { 4, new DateTime(2022, 10, 7, 22, 47, 26, 970, DateTimeKind.Local).AddTicks(4831), "Blues,Folk,Country", 7.4f, "629 Rolfson Cliffs, Port Trevaburgh, Saudi Arabia,640 Soledad Square, Kuhicside, New Zealand,57429 Pete Pines, North Declanfort, Oman", 2023, "Tempora soluta earum sit et. Et cumque necessitatibus. Ipsum id consequuntur eaque ipsam dolor. Voluptas saepe qui voluptates dolor est explicabo quo excepturi dolor. Sed aut et quas.", "Graham", new DateTime(2023, 10, 2, 13, 35, 59, 951, DateTimeKind.Utc).AddTicks(9757) },
                    { 5, new DateTime(2023, 6, 2, 10, 16, 48, 75, DateTimeKind.Local).AddTicks(8196), "Rock,Rock,Classical", 7.4f, "9401 Reggie Road, Boyerville, Finland,37953 Carson Keys, Keelingville, South Georgia and the South Sandwich Islands,3312 Esther Brook, East Salvatore, Romania", 2023, "Harum libero eum quae hic excepturi voluptatibus ad. Tempore ipsam omnis. Molestiae ad ut delectus. Doloremque in beatae. Est sed libero. Nihil similique delectus totam possimus modi.", "Sigurd", new DateTime(2023, 10, 2, 13, 35, 59, 953, DateTimeKind.Utc).AddTicks(934) },
                    { 6, new DateTime(2022, 12, 8, 0, 46, 9, 337, DateTimeKind.Local).AddTicks(1535), "Funk,Metal,Rock", 7.4f, "4421 Schumm Springs, Altenwerthberg, Montserrat,9999 Brock Coves, Aureliemouth, Macedonia,2363 Nathanial Keys, East Gustave, Zambia", 2022, "Culpa in nisi enim dolores eius molestiae natus nihil sed. Vel magnam rem omnis. Quo vel inventore quaerat sequi perspiciatis et harum. Veniam ratione et quidem vel vel omnis. Ducimus fuga cum eos et voluptatem quae consequatur quo.", "Destin", new DateTime(2023, 10, 2, 13, 35, 59, 954, DateTimeKind.Utc).AddTicks(1821) },
                    { 7, new DateTime(2023, 8, 30, 22, 20, 47, 687, DateTimeKind.Local).AddTicks(905), "Stage And Screen,Reggae,Stage And Screen", 7.4f, "53039 Welch Walk, Port Carolinefurt, Cape Verde,7651 Boehm Springs, South Mireille, China,171 Cassin Locks, Dooleyton, Solomon Islands", 2022, "Voluptatum praesentium voluptatem quia modi ducimus. Possimus voluptas est voluptatem aut incidunt. Odio ut consequatur qui aliquam. Est error numquam modi repudiandae explicabo.", "Rhianna", new DateTime(2023, 10, 2, 13, 35, 59, 955, DateTimeKind.Utc).AddTicks(2705) },
                    { 8, new DateTime(2023, 9, 16, 15, 41, 47, 653, DateTimeKind.Local).AddTicks(2362), "Metal,World,Hip Hop", 7.4f, "945 Carroll Place, Herzogfort, Colombia,9948 Jaylan Knolls, East Savannaborough, Brunei Darussalam,75398 Rocky Lakes, West Randall, Nigeria", 2022, "Voluptas accusantium quod deserunt iusto excepturi repudiandae. Ullam eum id. Dolorem perferendis illum ut est incidunt itaque et deserunt. Iste qui et quasi fugiat deserunt ut dolores.", "Gay", new DateTime(2023, 10, 2, 13, 35, 59, 956, DateTimeKind.Utc).AddTicks(4630) },
                    { 9, new DateTime(2023, 7, 10, 6, 4, 18, 383, DateTimeKind.Local).AddTicks(2840), "Non Music,Funk,Rap", 7.4f, "2708 Reichel Wall, Alanafort, China,7267 Isobel Ports, Schuppeland, Democratic People's Republic of Korea,204 Samanta Trace, East Hortense, Samoa", 2023, "Iure laudantium itaque accusamus alias consequatur odio dolore. Similique nobis dolores iste aut cumque ab velit. Incidunt qui vitae placeat eum sed consequatur explicabo. Corrupti soluta eaque accusamus autem iste in sed.", "Marquis", new DateTime(2023, 10, 2, 13, 35, 59, 957, DateTimeKind.Utc).AddTicks(6516) },
                    { 10, new DateTime(2023, 5, 24, 7, 20, 59, 659, DateTimeKind.Local).AddTicks(4911), "World,World,Latin", 7.4f, "1523 Yost Path, Port Joshua, Sri Lanka,13204 Heaney Lights, South Dan, Syrian Arab Republic,234 Glen Club, North Jaden, Christmas Island", 2023, "Impedit quia nam dolorum autem rerum modi. Ullam minus ex fuga cum. Quisquam nam reprehenderit. Ipsa distinctio velit.", "Stuart", new DateTime(2023, 10, 2, 13, 35, 59, 959, DateTimeKind.Utc).AddTicks(1384) },
                    { 11, new DateTime(2023, 2, 1, 14, 46, 20, 757, DateTimeKind.Local).AddTicks(1580), "Country,Blues,Latin", 7.4f, "392 Bruen Ridges, Gloverfort, Monaco,2483 Michel Stream, Welchburgh, Gambia,89795 Wintheiser Pass, East Andreannefort, New Zealand", 2022, "Ratione ipsum doloremque. Enim repellendus ipsam eos sequi sit nobis. Velit magnam ut.", "Roosevelt", new DateTime(2023, 10, 2, 13, 35, 59, 961, DateTimeKind.Utc).AddTicks(2310) },
                    { 12, new DateTime(2023, 9, 17, 9, 33, 4, 872, DateTimeKind.Local).AddTicks(4109), "Hip Hop,Hip Hop,Stage And Screen", 7.4f, "91622 Brent Island, Burniceborough, Nicaragua,18134 Junior Junction, Shannybury, Aruba,54611 Giovanni Corner, Rosalindfurt, Montenegro", 2023, "Quo asperiores adipisci dolorem at enim deserunt laudantium pariatur. Veniam perferendis at nesciunt sed voluptas et at. Eaque et sapiente iste.", "Ottis", new DateTime(2023, 10, 2, 13, 35, 59, 962, DateTimeKind.Utc).AddTicks(3587) },
                    { 13, new DateTime(2023, 8, 23, 5, 22, 39, 794, DateTimeKind.Local).AddTicks(8598), "Funk,Folk,Soul", 7.4f, "487 Paucek Square, East Orville, Falkland Islands (Malvinas),2584 Marks Islands, Pricebury, Burkina Faso,2888 Providenci Prairie, Lake Sasha, Bouvet Island (Bouvetoya)", 2023, "Aliquam in atque harum deleniti quod quidem voluptatibus debitis. Odio soluta assumenda in sapiente natus deleniti. Asperiores qui sunt et aut culpa deleniti quod. Rerum aliquam officiis ut. Alias enim molestiae ut labore est aliquid. Iste enim cumque rerum perspiciatis amet sunt.", "Jessy", new DateTime(2023, 10, 2, 13, 35, 59, 963, DateTimeKind.Utc).AddTicks(4682) },
                    { 14, new DateTime(2023, 3, 17, 9, 49, 14, 276, DateTimeKind.Local).AddTicks(8272), "Non Music,Jazz,Hip Hop", 7.4f, "33213 Krajcik Hills, Schulisttown, Sudan,156 Mia Passage, Rauville, Tunisia,92348 Willy Harbors, Kaylimouth, Georgia", 2022, "Vel deleniti incidunt est sit nihil odio animi qui ex. Asperiores quam doloribus ut accusantium repellat. Velit labore maiores et fugiat inventore qui sed qui sed. Nemo quasi nesciunt eum fugiat distinctio itaque ex.", "Cordie", new DateTime(2023, 10, 2, 13, 35, 59, 964, DateTimeKind.Utc).AddTicks(5594) },
                    { 15, new DateTime(2023, 2, 3, 21, 25, 43, 823, DateTimeKind.Local).AddTicks(2125), "World,Electronic,Classical", 7.4f, "438 Green Ridge, South King, Pitcairn Islands,12647 Schowalter Center, Boscotown, Isle of Man,058 West Ridge, North Salvatorechester, Saint Barthelemy", 2023, "Magni et qui veniam sed. Architecto aut corporis velit dolorem est. Hic ut quidem. Nesciunt repudiandae eaque rerum dolor non facilis laborum. Dicta ab consequatur inventore et.", "Caleb", new DateTime(2023, 10, 2, 13, 35, 59, 965, DateTimeKind.Utc).AddTicks(7856) },
                    { 16, new DateTime(2022, 11, 8, 1, 49, 22, 633, DateTimeKind.Local).AddTicks(8885), "Classical,Classical,Blues", 7.4f, "8231 Collier Crossing, Jerdeberg, Uganda,30178 Dooley Springs, Heidenreichburgh, Spain,37084 Jade Rapid, Swiftville, Reunion", 2023, "In dolores iure tempora. Fugit placeat eos atque a rem ut expedita officiis ex. Vitae dolore reprehenderit quis dolorem ipsum et laborum quia qui.", "Trevion", new DateTime(2023, 10, 2, 13, 35, 59, 966, DateTimeKind.Utc).AddTicks(9252) },
                    { 17, new DateTime(2022, 10, 8, 12, 56, 21, 873, DateTimeKind.Local).AddTicks(7259), "Rock,Folk,Stage And Screen", 7.4f, "7596 Frami Mountains, North Felipe, Mexico,649 Dayana Rapids, Kertzmannville, Nepal,743 Leo Course, Mitchellside, United Kingdom", 2022, "Fuga veniam atque ut non non in modi consequatur. Veritatis distinctio unde alias nihil at quia quisquam placeat. In sunt soluta omnis dolorem dolorem cumque. Deleniti et nihil. Perferendis explicabo natus dolor. Quod mollitia voluptatem magni rerum qui.", "Kellie", new DateTime(2023, 10, 2, 13, 35, 59, 968, DateTimeKind.Utc).AddTicks(302) },
                    { 18, new DateTime(2023, 9, 9, 13, 13, 9, 370, DateTimeKind.Local).AddTicks(6502), "Reggae,Soul,Classical", 7.4f, "953 Mateo Dale, Lake Garretthaven, Kuwait,434 Tom Road, East Rodger, Hungary,06132 Krajcik Pike, East Shemar, Paraguay", 2023, "Quaerat et dolor natus beatae aut voluptas qui rerum. Nulla eaque repellat ducimus quae nam laboriosam. Facilis dicta ipsa et. Et illum aliquam nulla ea. Vel et atque mollitia asperiores nihil.", "Granville", new DateTime(2023, 10, 2, 13, 35, 59, 969, DateTimeKind.Utc).AddTicks(4345) },
                    { 19, new DateTime(2023, 5, 20, 0, 24, 19, 788, DateTimeKind.Local).AddTicks(2370), "Jazz,Reggae,Soul", 7.4f, "749 Padberg Canyon, North Neva, Israel,74282 Denesik Manor, Huelsmouth, Ireland,32736 Edison Rest, Lake Maddison, Pitcairn Islands", 2023, "Molestiae nam quia totam. Earum perferendis velit. Alias sequi quis. Ipsa nobis non enim accusamus modi quisquam at aspernatur.", "Cristina", new DateTime(2023, 10, 2, 13, 35, 59, 972, DateTimeKind.Utc).AddTicks(2281) },
                    { 20, new DateTime(2023, 4, 11, 13, 13, 17, 210, DateTimeKind.Local).AddTicks(8140), "Latin,Hip Hop,World", 7.4f, "0089 Kemmer Island, New Tiara, Reunion,55335 Runolfsdottir Ville, Bodeton, Aruba,83175 Kertzmann Estates, North Addisonmouth, Greece", 2023, "Error nulla fugiat ut error illo voluptate voluptatibus. Dicta sequi et corrupti at exercitationem non. Quos nam minima. Ut molestias beatae ea.", "Emmie", new DateTime(2023, 10, 2, 13, 35, 59, 973, DateTimeKind.Utc).AddTicks(4127) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
