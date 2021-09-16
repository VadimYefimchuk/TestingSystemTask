using Microsoft.EntityFrameworkCore.Migrations;

namespace TestTask.Data.Migrations
{
    public partial class AddTestsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(nullable: true),
                    TestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerText = table.Column<string>(nullable: true),
                    IsCorrect = table.Column<bool>(nullable: false),
                    QuestionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                column: "TestId");

            migrationBuilder.Sql(@"
                INSERT INTO [Tests] ([TestName], [Description], [ImageUrl]) VALUES ('Game of Thrones', 'Game of Thrones is an HBO series that tells the story of a medieval countrys civil war', 'https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/game-of-thrones-illustration-sean-longmore-1598631176.jpeg?crop=0.669xw:1.00xh;0.0896xw,0&resize=640:*');
                INSERT INTO [Tests] ([TestName], [Description], [ImageUrl]) VALUES ('Math', 'This is simple math test', 'https://miro.medium.com/max/1400/1*L76A5gL6176UbMgn7q4Ybg.jpeg');
                INSERT INTO [Tests] ([TestName], [Description], [ImageUrl]) VALUES ('Cars', 'Do you know cars story from?', 'https://www.thevehiclewrappingcentre.com/wp-content/uploads/2019-alpina-xd3-500x500.jpg');
                INSERT INTO [Tests] ([TestName], [Description], [ImageUrl]) VALUES ('The Lord of the Rings', 'The Lord of the Rings is a series of three epic fantasy adventure films directed by Peter Jackson, based on the novel written by J. R. R. Tolkien.', 'https://images.genius.com/4218472effa0cd4d6dd469811c805c7f.900x900x1.png');
                INSERT INTO [Tests] ([TestName], [Description], [ImageUrl]) VALUES ('Guess the person', 'Guess who the person is by profession, nationality', 'https://kenyanmagazine.co.ke/wp-content/uploads/2021/07/IMG_20210714_122050_218.jpg');
            ");

            migrationBuilder.Sql(@"
                INSERT INTO [Questions] ([QuestionText], [TestId]) VALUES ('Who was the best character on the serial? (She had three dragons)', 1);
                INSERT INTO [Questions] ([QuestionText], [TestId]) VALUES ('Which eyes color in Daenerys Targaryen? (Book version)', 1);
                INSERT INTO [Questions] ([QuestionText], [TestId]) VALUES ('Who killed Joffrey Baratheon?', 1);
                INSERT INTO [Questions] ([QuestionText], [TestId]) VALUES ('What name has Jon Snows wolf?', 1);
                INSERT INTO [Questions] ([QuestionText], [TestId]) VALUES ('2+2 ?', 2);
                INSERT INTO [Questions] ([QuestionText], [TestId]) VALUES ('5*5 ?', 2);
                INSERT INTO [Questions] ([QuestionText], [TestId]) VALUES ('(5+5)*5 ?', 2);
                INSERT INTO [Questions] ([QuestionText], [TestId]) VALUES ('How many wheels does a classic car ride on?', 3);
                INSERT INTO [Questions] ([QuestionText], [TestId]) VALUES ('Who Invented the Diesel Engine?', 3);
                INSERT INTO [Questions] ([QuestionText], [TestId]) VALUES ('What country was the inventor of the ICE?', 3);
                INSERT INTO [Questions] ([QuestionText], [TestId]) VALUES ('Who is Legolas?', 4);
                INSERT INTO [Questions] ([QuestionText], [TestId]) VALUES ('Who is Aragorn?', 4);
                INSERT INTO [Questions] ([QuestionText], [TestId]) VALUES ('Who is Gimli?', 4);
                INSERT INTO [Questions] ([QuestionText], [TestId]) VALUES ('Who is Gandalf?', 4);
                INSERT INTO [Questions] ([QuestionText], [TestId]) VALUES ('Who is Bill Gates?', 5);
                INSERT INTO [Questions] ([QuestionText], [TestId]) VALUES ('Who is Einstein?', 5);
                INSERT INTO [Questions] ([QuestionText], [TestId]) VALUES ('Who is Klitschko?', 5);
            ");

            migrationBuilder.Sql(@"
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Daenerys Targaryen', 'True',1);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Jaime Lannister', 'False',1);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Jon Snow', 'False',1);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Purple', 'True',2);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Green', 'False',2);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Blue', 'False',2);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Olenna Tyrell', 'True',3);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Jon Snow', 'False',3);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Daenerys Targaryen', 'False',3);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Ghost', 'True',4);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Summer', 'False',4);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Rhaegal', 'False',4);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('4', 'True',5);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('5', 'False',5);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('6', 'False',5);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('25', 'True',6);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('15', 'False',6);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('85', 'False',6);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('54', 'False',7);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('50', 'True',7);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('85', 'False',7);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('4', 'True',8);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('5', 'False',8);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('3', 'False',8);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Rudolf Diesel', 'True',9);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Nikolaus Otto', 'False',9);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Etienne Lenoir', 'False',9);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Germany', 'True',10);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('France', 'False',10);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Spain', 'False',10);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Elf', 'True',11);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Gnome', 'False',11);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Man', 'False',11);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Man', 'True',12);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Elf', 'False',12);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Gnome', 'False',12);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Gnome', 'True',13);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Elf', 'False',13);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Wizard', 'False',13);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Wizard', 'True',14);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Elf', 'False',14);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Orc', 'False',14);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Founder of Microsoft', 'True',15);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Boxer', 'False',15);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Scientist', 'False',15);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Scientist', 'True',16);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Boxer', 'False',16);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Founder of Microsoft', 'False',16);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Founder of Microsoft', 'False',17);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Boxer', 'True',17);
                INSERT INTO [Answers] ([AnswerText], [IsCorrect], [QuestionId]) VALUES ('Scientist', 'False',17);
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
