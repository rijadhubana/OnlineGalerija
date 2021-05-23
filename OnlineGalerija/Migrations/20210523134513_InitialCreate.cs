using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OnlineGalerija.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hashtag",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hashtag", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "reaction",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reaction_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    reaction_image_data = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reaction", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    password_hash = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    name_surname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    profile_photo_data = table.Column<byte[]>(type: "bytea", nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: true),
                    role_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "date", nullable: true),
                    updated_at = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "users_role_id_fkey",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    text = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "date", nullable: true),
                    updated_at = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.id);
                    table.ForeignKey(
                        name: "post_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_follower",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    follower_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_follower_pkey", x => new { x.user_id, x.follower_id });
                    table.ForeignKey(
                        name: "user_follower_follower_id_fkey",
                        column: x => x.follower_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "user_follower_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                    post_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.id);
                    table.ForeignKey(
                        name: "comment_post_id_fkey",
                        column: x => x.post_id,
                        principalTable: "post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "comment_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "image",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    image_data = table.Column<byte[]>(type: "bytea", nullable: true),
                    post_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_image", x => x.id);
                    table.ForeignKey(
                        name: "image_post_id_fkey",
                        column: x => x.post_id,
                        principalTable: "post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "post_hashtag",
                columns: table => new
                {
                    post_id = table.Column<int>(type: "integer", nullable: false),
                    hashtag_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("post_hashtag_pkey", x => new { x.post_id, x.hashtag_id });
                    table.ForeignKey(
                        name: "post_hashtag_hashtag_id_fkey",
                        column: x => x.hashtag_id,
                        principalTable: "hashtag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "post_hashtag_post_id_fkey",
                        column: x => x.post_id,
                        principalTable: "post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_reaction_post",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    post_id = table.Column<int>(type: "integer", nullable: false),
                    reaction_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_reaction_post_pkey", x => new { x.user_id, x.post_id });
                    table.ForeignKey(
                        name: "user_reaction_post_post_id_fkey",
                        column: x => x.post_id,
                        principalTable: "post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "user_reaction_post_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_reaction_comment",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    comment_id = table.Column<int>(type: "integer", nullable: false),
                    reaction_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_reaction_comment_pkey", x => new { x.user_id, x.comment_id });
                    table.ForeignKey(
                        name: "user_reaction_comment_comment_id_fkey",
                        column: x => x.comment_id,
                        principalTable: "comment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "user_reaction_comment_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comment_post_id",
                table: "comment",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_user_id",
                table: "comment",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_image_post_id",
                table: "image",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_post_user_id",
                table: "post",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_post_hashtag_hashtag_id",
                table: "post_hashtag",
                column: "hashtag_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_follower_follower_id",
                table: "user_follower",
                column: "follower_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_reaction_comment_comment_id",
                table: "user_reaction_comment",
                column: "comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_reaction_post_post_id",
                table: "user_reaction_post",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                table: "users",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "image");

            migrationBuilder.DropTable(
                name: "post_hashtag");

            migrationBuilder.DropTable(
                name: "reaction");

            migrationBuilder.DropTable(
                name: "user_follower");

            migrationBuilder.DropTable(
                name: "user_reaction_comment");

            migrationBuilder.DropTable(
                name: "user_reaction_post");

            migrationBuilder.DropTable(
                name: "hashtag");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
