namespace AcaiStoreApi.Models;

public class AcaiStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string AcaisCollectionName { get; set; } = null!;
}