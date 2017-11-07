using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MimiloWEBApi.Migrations
{
    public partial class LineItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItem_Products_ProductId",
                table: "LineItem");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItem_ShoppingCarts_ShoppingCartId",
                table: "LineItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LineItem",
                table: "LineItem");

            migrationBuilder.RenameTable(
                name: "LineItem",
                newName: "LineItems");

            migrationBuilder.RenameIndex(
                name: "IX_LineItem_ShoppingCartId",
                table: "LineItems",
                newName: "IX_LineItems_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_LineItem_ProductId",
                table: "LineItems",
                newName: "IX_LineItems_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LineItems",
                table: "LineItems",
                column: "LineItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Products_ProductId",
                table: "LineItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_ShoppingCarts_ShoppingCartId",
                table: "LineItems",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "ShoppingCartId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Products_ProductId",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_ShoppingCarts_ShoppingCartId",
                table: "LineItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LineItems",
                table: "LineItems");

            migrationBuilder.RenameTable(
                name: "LineItems",
                newName: "LineItem");

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_ShoppingCartId",
                table: "LineItem",
                newName: "IX_LineItem_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_ProductId",
                table: "LineItem",
                newName: "IX_LineItem_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LineItem",
                table: "LineItem",
                column: "LineItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItem_Products_ProductId",
                table: "LineItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItem_ShoppingCarts_ShoppingCartId",
                table: "LineItem",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "ShoppingCartId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
