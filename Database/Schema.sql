IF OBJECT_ID(N'dbo.Courses', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Courses (Id int NOT NULL PRIMARY KEY, Name nvarchar(200) NOT NULL);
END;

INSERT INTO dbo.Courses (Id, Name)
SELECT seed.Id, seed.Name
FROM (VALUES
    (1, N'Lập trình C# cơ bản'),
    (2, N'Lập trình Web ASP.NET'),
    (3, N'Lập trình Mobile Xamarin'),
    (4, N'Cơ sở dữ liệu SQL Server'),
    (5, N'Trí tuệ nhân tạo Python')
) AS seed(Id, Name)
WHERE NOT EXISTS (SELECT 1 FROM dbo.Courses WITH (UPDLOCK, HOLDLOCK) WHERE Id = seed.Id);

IF OBJECT_ID(N'dbo.Registrations', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Registrations (
        Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
        FullName nvarchar(200) NOT NULL CHECK (LEN(LTRIM(RTRIM(FullName))) BETWEEN 1 AND 200),
        BirthDate date NOT NULL,
        Phone varchar(10) NOT NULL CHECK (DATALENGTH(Phone) = 10 AND Phone COLLATE Latin1_General_100_BIN2 NOT LIKE '%[^0-9]%'),
        CourseId int NOT NULL REFERENCES dbo.Courses(Id),
        English bit NOT NULL,
        SoftSkills bit NOT NULL,
        OfficeIT bit NOT NULL
    );
END;
