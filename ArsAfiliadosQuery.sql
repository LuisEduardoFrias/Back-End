Create database ArsAfiliados
go

use  ArsAfiliados
go


----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

-- Plan table

Create table Planes
(
	Id int primary key identity not null,
	PlanName varchar(25) not null,
	CoverageAmount decimal not null,
	RegistrationDate datetime not null,
	Status bit not null,
)
Go


-- Plan procedures

create proc ShowPlans
as
begin

	select * from Planes

end
go

create proc CreatePlan
@PlanName varchar(25),
@CoverageAmount decimal,
@RegistrationDate datetime,
@Status bit
as
begin

	Insert into Planes values (
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

	Update Planes set
	PlanName = @PlanName,             
	CoverageAmount = @CoverageAmount,				
	RegistrationDate = @RegistrationDate ,		
	Status = @Status
	where  
	Id = @Id

end
go

create proc SearchPlan @Id int
as
begin

	select * from Planes where Id = @Id

end
go

Create proc ChangeStatusPlan @Id int, @Status int
as
begin

	Update Planes set 
	Status = @Status
	where  
	Id = @Id

end
go

----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

-- Affiliate table

Create table Affiliates
(
	Id int primary key identity not null,
	Name              varchar(50) not null, 
	LastName			varchar(50) not null,
	Date				DateTime not null,
	Nacionality 			varchar(25) not null,
	Sex				char(1) not null,
	IdentificationCard	char(11) not null,
	SocialSecurityNumber	varchar(25) not null,
	RegistrationDate		datetime not null,
	AmountConsumed		decimal not null,
	Status			bit not null,
	PlanId				int not null,
	foreign key (PlanId) references Planes(Id)
)
go

-- Affiliate procedures

create proc ShowAffiliate
as
begin

	select * from Affiliates as A 
	Join Planes as P on A.PlanId = P.Id;

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


Create proc SearchAffiliate @Search varchar(50)
as
begin

		select * from Affiliates as A 
		Join Planes as P on A.PlanId = P.Id 
		where 
		Name =  @Search or
		LastName =   @Search or
		IdentificationCard =  @Search;

end
go

Create proc ChangeStatus @IdentificationCard char(11), @Status int
as
begin

	Update Affiliates set 
	Status = @Status
	where  
	IdentificationCard = @IdentificationCard

end
go