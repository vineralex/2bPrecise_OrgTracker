namespace OrgTracker.API.Entities
{
	/// <summary>
	/// A base abstract class for entities in the OrgTracker application.
	/// </summary>
	public abstract class BaseEntity
	{
		/// <summary>
		/// Gets or sets the unique identifier for the entity.
		/// </summary>
		public int Id { get; set; }

		public override bool Equals(object? obj)
		{
			return obj is BaseEntity entity &&
				   Id == entity.Id;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Id);
		}
	}
}
