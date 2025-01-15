using SharedModels.Models.Base;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace RecruitmentServer.Models.DataBase
{
	internal static class DataBaseInitializer
	{
		public static void Initialize(RecruitmentEntities context)
		{
			if (ShouldSeedDatabase())
			{
				ClearDatabase(context);
				SeedDatabase();
			}
		}

		private static bool ShouldSeedDatabase()
		{
#if DEBUG
			return true;
#else
			return Debugger.IsAttached && IsRunningFromDevelopmentEnvironment();
#endif
		}

		private static bool IsRunningFromDevelopmentEnvironment()
		{
			string exePath = Process.GetCurrentProcess().MainModule?.FileName ?? string.Empty;
			string devPath = Path.Combine(Directory.GetCurrentDirectory(), "bin");
			return exePath.Contains(devPath);
		}
		private static void ClearDatabase(RecruitmentEntities context)
		{
			var dbSetProperties = context.GetType().GetProperties().
				Where(p => p.PropertyType.IsGenericType
				&& p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>)
				&& p.PropertyType.GetGenericArguments()[0].IsSubclassOf(typeof(EntityBase)))
				.ToList();

			foreach (dynamic property in dbSetProperties)
			{
				var dbSet = property.GetValue(context);
				dbSet.RemoveRange(dbSet);
				context.SaveChanges();
			}
		}
		private static void SeedDatabase()
		{

		}
	}
}
