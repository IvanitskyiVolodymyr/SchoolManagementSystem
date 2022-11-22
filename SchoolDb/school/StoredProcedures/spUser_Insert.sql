CREATE PROCEDURE [dbo].[spUser_Insert]
    @FirstName NVARCHAR (20),
    @MiddleName NVARCHAR (20),
    @LastName NVARCHAR (20),
    @Gender NVARCHAR (1),
    @PhoneNumber NVARCHAR (20),
    @Email NVARCHAR (20),
    @Address NVARCHAR (100),
    @PasswordSalt NVARCHAR (100),
    @PasswordHash NVARCHAR (100),
    @BirthDate DATE,
    @JoinDate DATE,
    @AvatarUrl NVARCHAR (255)
AS
BEGIN
    INSERT INTO school.Users
    (
    FirstName,
    MiddleName,
    LastName,
    Gender,
    PhoneNumber,
    Email,
    Address,
    PasswordSalt,
    PasswordHash,
    BirthDate,
    JoinDate,
    AvatarUrl)
    OUTPUT INSERTED.UserId
    VALUES
    (@FirstName,
    @MiddleName,
    @LastName,
    @Gender,
    @PhoneNumber,
    @Email,
    @Address,
    @PasswordSalt,
    @PasswordHash,
    @BirthDate,
    @JoinDate,
    @AvatarUrl);
END
