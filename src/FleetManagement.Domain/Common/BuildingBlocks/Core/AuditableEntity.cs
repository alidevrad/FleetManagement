namespace FleetManagement.Domain.Common.BuildingBlocks.Core;

public abstract class AuditableEntity<TKey> : IEntity,
    IEquatable<AuditableEntity<TKey>> where TKey : IEquatable<TKey>
{
    #region Properties

    public TKey Id { get; protected set; }
    public byte[] RowVersion { get; protected set; }
    public DateTime CreationDateTime { get; protected set; }
    public DateTime? LastUpdateDateTime { get; private set; }
    public DateTime? DeleteDateTime { get; private set; }
    public bool? IsDeleted { get; private set; }

    #endregion

    #region Constructors

    protected AuditableEntity()
    {
        IsDeleted = false;
        CreationDateTime = DateTime.UtcNow;
    }

    #endregion

    #region Methods

    public void MarkAsUpdated()
    {
        LastUpdateDateTime = DateTime.UtcNow;
    }

    public void MarkAsDeleted()
    {
        IsDeleted = true;
        DeleteDateTime = DateTime.UtcNow;
    }
    public override bool Equals(object obj)
    {
        return obj is AuditableEntity<TKey> other && Equals(other);
    }

    public bool Equals(AuditableEntity<TKey> other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        if (EqualityComparer<TKey>.Default.Equals(Id, default) ||
            EqualityComparer<TKey>.Default.Equals(other.Id, default))
            return false;

        return EqualityComparer<TKey>.Default.Equals(Id, other.Id);
    }

    public override int GetHashCode()
    {
        return EqualityComparer<TKey>.Default.GetHashCode(Id);
    }

    public static bool operator ==(AuditableEntity<TKey> left, AuditableEntity<TKey> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(AuditableEntity<TKey> left, AuditableEntity<TKey> right)
    {
        return !Equals(left, right);
    }
    #endregion
}