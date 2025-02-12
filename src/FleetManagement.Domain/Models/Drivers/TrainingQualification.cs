namespace FleetManagement.Domain.Models.Drivers;

public class TrainingQualification
{
    public string QualificationName { get; private set; }
    public DateTime? ObtainedDate { get; private set; }
    public DateTime? ExpirationDate { get; private set; }

    protected TrainingQualification() { }

    public TrainingQualification(string qualificationName,
                                 DateTime? obtainedDate = null,
                                 DateTime? expirationDate = null)
    {
        QualificationName = qualificationName;
        ObtainedDate = obtainedDate;
        ExpirationDate = expirationDate;
    }
}
