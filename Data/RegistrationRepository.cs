using System.Data;
using Microsoft.Data.SqlClient;

namespace BT5_2_StudentRegistration.Data;

internal sealed class RegistrationRepository
{
    internal Task InitializeAsync() => Task.Run(() =>
    {
        Database.EnsureCreated();
        using var connection = Database.OpenConnection();
        using var transaction = connection.BeginTransaction();
        using var command = connection.CreateCommand();
        command.Transaction = transaction;
        command.CommandText = Database.ReadSchema();
        command.ExecuteNonQuery();
        transaction.Commit();
    });

    internal Task<List<Course>> GetCoursesAsync() => Task.Run(() =>
    {
        using var connection = Database.OpenConnection();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, Name FROM Courses ORDER BY Id;";
        using var reader = command.ExecuteReader();
        var courses = new List<Course>();
        while (reader.Read()) courses.Add(new(reader.GetInt32(0), reader.GetString(1)));
        return courses;
    });

    internal Task<long> SaveAsync(RegistrationData registration) => Task.Run(() =>
    {
        if (string.IsNullOrWhiteSpace(registration.FullName) || registration.FullName.Trim().Length > 200)
            throw new ArgumentException("Họ tên phải có từ 1 đến 200 ký tự.");
        if (registration.Phone.Length != 10 || !registration.Phone.All(char.IsAsciiDigit))
            throw new ArgumentException("Điện thoại phải có đủ 10 chữ số.");

        using var connection = Database.OpenConnection();
        using var command = connection.CreateCommand();
        command.CommandText = """
            INSERT INTO Registrations
                (FullName, BirthDate, Phone, CourseId, English, SoftSkills, OfficeIT)
            OUTPUT INSERTED.Id
            VALUES (@name, @birthDate, @phone, @courseId, @english, @softSkills, @officeIT);
            """;
        command.Parameters.Add("@name", SqlDbType.NVarChar, 200).Value = registration.FullName.Trim();
        command.Parameters.Add("@birthDate", SqlDbType.Date).Value = registration.BirthDate.Date;
        command.Parameters.Add("@phone", SqlDbType.VarChar, 10).Value = registration.Phone;
        command.Parameters.Add("@courseId", SqlDbType.Int).Value = registration.CourseId;
        command.Parameters.Add("@english", SqlDbType.Bit).Value = registration.English;
        command.Parameters.Add("@softSkills", SqlDbType.Bit).Value = registration.SoftSkills;
        command.Parameters.Add("@officeIT", SqlDbType.Bit).Value = registration.OfficeIT;
        return (long)command.ExecuteScalar()!;
    });
}
