using System.Globalization;
using Microsoft.Data.Sqlite;

namespace BT5_2_StudentRegistration.Data;

internal sealed class RegistrationRepository
{
    internal Task InitializeAsync() => Task.Run(() =>
    {
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
            VALUES ($name, $birthDate, $phone, $courseId, $english, $softSkills, $officeIT)
            RETURNING Id;
            """;
        command.Parameters.Add("$name", SqliteType.Text).Value = registration.FullName.Trim();
        command.Parameters.Add("$birthDate", SqliteType.Text).Value = registration.BirthDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        command.Parameters.Add("$phone", SqliteType.Text).Value = registration.Phone;
        command.Parameters.Add("$courseId", SqliteType.Integer).Value = registration.CourseId;
        command.Parameters.Add("$english", SqliteType.Integer).Value = registration.English;
        command.Parameters.Add("$softSkills", SqliteType.Integer).Value = registration.SoftSkills;
        command.Parameters.Add("$officeIT", SqliteType.Integer).Value = registration.OfficeIT;
        return (long)command.ExecuteScalar()!;
    });
}
