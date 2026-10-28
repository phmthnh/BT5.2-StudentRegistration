namespace BT5_2_StudentRegistration.Data;

internal sealed record RegistrationData(
    string FullName,
    DateTime BirthDate,
    string Phone,
    int CourseId,
    bool English,
    bool SoftSkills,
    bool OfficeIT);
