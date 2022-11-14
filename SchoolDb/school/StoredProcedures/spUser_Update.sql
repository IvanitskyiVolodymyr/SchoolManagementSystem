CREATE PROCEDURE [dbo].[spUser_Update]
	@UserId INT,
    @FirstName NVARCHAR (20),
    @RoleId INT,
    @MiddleName NVARCHAR (20),
    @LastName NVARCHAR (20),
    @Gender NVARCHAR (1),
    @PhoneNumber NVARCHAR (20),
    @Email NVARCHAR (20),
    @Address NVARCHAR (100),
    @PasswordSalt NVARCHAR (100),
    @BirthDate DATE,
    @JoinDate DATE,
    @AvatarUrl NVARCHAR (255)
AS
BEGIN
    UPDATE school.Users
    SET
    FirstName = @FirstName,
    RoleId = @RoleId,
    MiddleName = @MiddleName,
    LastName = @LastName,
    Gender = @Gender,
    PhoneNumber = @PhoneNumber,
    Email = @Email,
    Address = @Address,
    PasswordSalt = @PasswordSalt,
    BirthDate = @BirthDate,
    JoinDate = @JoinDate,
    AvatarUrl = @AvatarUrl

    WHERE UserId = @UserId
END
