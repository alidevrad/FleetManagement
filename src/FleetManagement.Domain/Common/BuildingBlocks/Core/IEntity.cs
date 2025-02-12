namespace FleetManagement.Domain.Common.BuildingBlocks.Core;

public interface IEntity
{
    bool? IsDeleted { get; }
    void MarkAsUpdated();
    void MarkAsDeleted();
}


