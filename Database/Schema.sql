CREATE TABLE IF NOT EXISTS Courses (
    Id INTEGER PRIMARY KEY,
    Name TEXT NOT NULL
);

INSERT INTO Courses (Id, Name) VALUES
    (1, 'Lập trình C# cơ bản'),
    (2, 'Lập trình Web ASP.NET'),
    (3, 'Lập trình Mobile Xamarin'),
    (4, 'Cơ sở dữ liệu SQL Server'),
    (5, 'Trí tuệ nhân tạo Python')
ON CONFLICT(Id) DO NOTHING;

CREATE TABLE IF NOT EXISTS Registrations (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    FullName TEXT NOT NULL CHECK (length(trim(FullName)) BETWEEN 1 AND 200),
    BirthDate TEXT NOT NULL CHECK (length(BirthDate) = 10 AND date(BirthDate) IS NOT NULL),
    Phone TEXT NOT NULL CHECK (length(Phone) = 10 AND Phone NOT GLOB '*[^0-9]*'),
    CourseId INTEGER NOT NULL REFERENCES Courses(Id),
    English INTEGER NOT NULL CHECK (English IN (0, 1)),
    SoftSkills INTEGER NOT NULL CHECK (SoftSkills IN (0, 1)),
    OfficeIT INTEGER NOT NULL CHECK (OfficeIT IN (0, 1))
);
