using OrgTracker.API.Entities;

namespace OrgTracker.API.DbContexts
{
	/// <summary>
	/// A class that initializes the database with sample employee data.
	/// </summary>
	public class DbInitializer
	{
		/// <summary>
		/// Ensures the database is created and initialized with sample employee data.
		/// </summary>
		/// <param name="context">The database context to be initialized.</param>
		public static void Initialize(OrgTrackerDbContext context)
		{
			context.Database.EnsureCreated();

			if (context.Employees.Any())
			{
				return;
			}

			var ceo = new Employee() { FirstName = "Jennifer", LastName = "Davis", Position = "CEO" };
			var vpProdDev = new Employee() { FirstName = "Michael", LastName = "Johnson", Position = "VP Product Development Manager" };
			var prodDev1 = new Employee() { FirstName = "David", LastName = "Brown", Position = "Product Development" };
			var prodDev2 = new Employee() { FirstName = "Sarah", LastName = "Miller", Position = "Product Development" };
			var prodDev3 = new Employee() { FirstName = "Christopher", LastName = "Wilson", Position = "Product Development" };
			var vpSales = new Employee() { FirstName = "Rebecca", LastName = "Jones", Position = "VP Sales Manager" };
			var sale1 = new Employee() { FirstName = "Matthew", LastName = "Taylor", Position = "Sales Manager" };
			var sale2 = new Employee() { FirstName = "Amanda", LastName = "Clark", Position = "Sales Manager" };
			var sale3 = new Employee() { FirstName = "Robert", LastName = "Lee", Position = "Sales Manager" };
			var vpRND = new Employee() { FirstName = "Stephanie", LastName = "Martin", Position = "VP R&D" };
			var qaManager = new Employee() { FirstName = "Lisa", LastName = "Scott", Position = "QA Manager" };
			var qa1 = new Employee() { FirstName = "Brian", LastName = "Thompson", Position = "QA" };
			var qa2 = new Employee() { FirstName = "Kevin", LastName = "Baker", Position = "QA" };
			var qa3 = new Employee() { FirstName = "Laura", LastName = "White", Position = "QA" };
			var architect = new Employee() { FirstName = "William", LastName = "Jackson", Position = "Architect" };
			var techLead = new Employee() { FirstName = "Melissa", LastName = "Garcia", Position = "Tech Leader" };
			var teamLead = new Employee() { FirstName = "Elizabeth", LastName = "Young", Position = "Team Leader" };
			var developer = new Employee() { FirstName = "Daniel", LastName = "Davis", Position = "Full Stack Developer" };

			var employees = new Employee[] {
				ceo, vpProdDev, vpSales, vpRND,
				prodDev1, prodDev2, prodDev3,
				sale1, sale2, sale3,
				qaManager, qa1, qa2, qa3,
				architect, techLead, teamLead, developer
			};

			foreach ( var employee in employees )
			{
				context.Employees.Add( employee );
			}
			context.SaveChanges();

			ceo.Subordinates = new Employee[] { vpProdDev, vpSales, vpRND };
			vpProdDev.Subordinates = new Employee[] { prodDev1, prodDev2, prodDev3 };
			vpSales.Subordinates = new Employee[] { sale1, sale2, sale3 };
			vpRND.Subordinates = new Employee[] { qaManager, architect, teamLead };
			qaManager.Subordinates = new Employee[] {qa1, qa2, qa3 };
			architect.Subordinates = new Employee[] { techLead };
			teamLead.Subordinates = new Employee[] { developer };

			context.SaveChanges();
		}
	}
}
