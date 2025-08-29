using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace T_Electronic.Logic.Migrations
{
    /// <inheritdoc />
    public partial class SecundayMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Computadoras" },
                    { 2, "Telefonos" },
                    { 3, "Televisor" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Categoria_Id", "Descripcion", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, 1, "La notebook Asus TUF Gaming F15 ofrece una experiencia visual excepcional con su pantalla de 15,6 pulgadas y resolución FHD (1920 x 1080), que proporciona imágenes nítidas y colores vibrantes.", "Notebook ASUS TUF Gaming", 200000m },
                    { 2, 2, "Chip A18 potencia funcionalidades de foto y video, lo hace todo con una eficiencia energética excepcional para extender la duración de la batería. Botón control de cámara, toma la foto perfecta con sólo levantar un dedo. Nueva cámara ultra gran angular.", "Apple iPhone 16 128GB Teal", 623000m },
                    { 3, 3, "Mediante sus entradas HDMI, con la TV Samsung Smart 55 pulgadas podés conectar reproductores de audio y video; consolas de juegos y notebooks", "Lenovo LOQ Gen 9 (15\" Intel) GeForce RTX™ 2050 ", 10000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
