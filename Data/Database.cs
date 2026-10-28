using Microsoft.Data.Sqlite;

namespace BT5_2_StudentRegistration.Data;

internal static class Database
{
    internal static string FilePath => Path.GetFullPath(
        Environment.GetEnvironmentVariable("BT52_DATABASE_PATH") is { Length: > 0 } custom
            ? custom
            : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "LTNET", "BT52-StudentRegistration", "registrations.db"));

    internal static SqliteConnection OpenConnection()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);
        var connection = new SqliteConnection(new SqliteConnectionStringBuilder
        {
            DataSource = FilePath,
            Mode = SqliteOpenMode.ReadWriteCreate,
            ForeignKeys = true,
            DefaultTimeout = 10
        }.ToString());
        try { connection.Open(); return connection; }
        catch { connection.Dispose(); throw; }
    }

    internal static string ReadSchema()
    {
        using var stream = typeof(Database).Assembly.GetManifestResourceStream("DatabaseSchema.sql")
            ?? throw new InvalidOperationException("Không tìm thấy SQL khởi tạo cơ sở dữ liệu.");
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
