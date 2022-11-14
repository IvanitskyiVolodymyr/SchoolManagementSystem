CREATE PROCEDURE [dbo].[spUser_Insert]
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
    INSERT INTO school.Users
    (UserId,
    FirstName,
    RoleId,
    MiddleName,
    LastName,
    Gender,
    PhoneNumber,
    Email,
    Address,
    PasswordSalt,
    BirthDate,
    JoinDate,
    AvatarUrl)
    VALUES
    (@UserId,
    @FirstName,
    @RoleId,
    @MiddleName,
    @LastName,
    @Gender,
    @PhoneNumber,
    @Email,
    @Address,
    @PasswordSalt,
    @BirthDate,
    @JoinDate,
    @AvatarUrl);
END
