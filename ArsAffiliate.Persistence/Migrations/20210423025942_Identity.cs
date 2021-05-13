using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArsAffiliate.Persistence.Migrations
{
    public partial class Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanName = table.Column<string>(nullable: true),
                    CoverageAmount = table.Column<decimal>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Affiliates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Nacionality = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: false),
                    IdentificationCard = table.Column<string>(nullable: true),
                    SocialSecurityNumber = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    AmountConsumed = table.Column<decimal>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    PlanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_affiliates_plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_affiliates_PlanId",
                table: "Affiliates",
                column: "PlanId");

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


            migrationBuilder.Sql(@"
-- Plan procedures

create proc ShowPlans
as
begin

	select * from Plans

end
go


create proc CreatePlan
@PlanName varchar(25),
@CoverageAmount decimal,
@RegistrationDate datetime,
@Status bit
as
begin

	Insert into Plans values (
	@PlanName,
	@CoverageAmount,
	@RegistrationDate,
	@Status)

end
go


create proc UpdatePlan 
@Id int,
@PlanName varchar(25),
@CoverageAmount decimal,
@RegistrationDate datetime,
@Status bit
as
begin

	Update Plans set
	PlanName = @PlanName,             
	CoverageAmount = @CoverageAmount,				
	RegistrationDate = @RegistrationDate ,		
	Status = @Status
	where  
	Id = @Id

end
go


CREATE proc SearchPlan @PlanName varchar(25)
as
begin

	select * from Plans where PlanName =  @PlanName

end


Create proc ChangeStatusPlan @Id int, @Status int
as
begin

	Update Plans set 
	Status = @Status
	where  
	Id = @Id

end
go


-- Affiliate procedures

create proc ShowAffiliate
as
begin

	select * from Affiliates as A 
	Join Plans as P on A.PlanId = P.Id;

end
go


create proc Createaffiliate
@Name              varchar(50),
@LastName			varchar(50),
@Date			DateTime,
@Nacionality 			varchar(25),
@Sex				char(1),
@IdentificationCard			char(11),
@SocialSecurityNumber	varchar(25),
@RegistrationDate		datetime,
@AmountConsumed		decimal,
@Status		int,
@PlanId			int
as
begin

	Insert into Affiliates values (
	 @Name             
	,@LastName			
	,@Date				
	,@Nacionality 		
	,@Sex					
	,@IdentificationCard
	,@SocialSecurityNumber
	,@RegistrationDate		
	,@AmountConsumed		
	,@Status			
	,@PlanId)

end
go


create proc UpdateAffiliate
@Id int,
@Name              varchar(50),
@LastName			varchar(50),
@Date			DateTime,
@Nacionality 			varchar(25),
@Sex				char(1),
@IdentificationCard			char(11),
@SocialSecurityNumber	varchar(25),
@RegistrationDate		datetime,
@AmountConsumed		decimal,
@Status		int,
@PlanId			int
as
begin

	Update Affiliates set
	Name= @Name,             
	LastName= @LastName,			
	Date= @Date	,			
	Nacionality= @Nacionality ,		
	Sex= @Sex	,			
	IdentificationCard= @IdentificationCard		,		
	SocialSecurityNumber= @SocialSecurityNumber	,
	RegistrationDate= @RegistrationDate		,
	AmountConsumed= @AmountConsumed	,	
	Status= @Status	,		
	PlanId= @PlanId	
	where  
	Id = @Id

end
go


create proc UpdateAmountAffiliate
@Id int,
@AmountConsumed		decimal
as
begin

	Update Affiliates set
	AmountConsumed = @AmountConsumed	
	where  
	Id = @Id

end
go


Create proc SearchAffiliate @IdentificationCard char(11)
as
begin

		select * from Affiliates as A 
		Join Plans as P on A.PlanId = P.Id 
		where 
		Name =  @Search or
		LastName =   @Search or
		IdentificationCard =  @IdentificationCard;

end
go


Create proc ChangeStatusAffiliate @IdentificationCard char(11), @Status int
as
begin

	Update Affiliates set 
	Status = @Status
	where  
	IdentificationCard = @IdentificationCard

end
go", true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Affiliates");

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
                name: "Plans");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
