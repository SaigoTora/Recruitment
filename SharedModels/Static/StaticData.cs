using System.Linq;
using System.Threading.Tasks;

using SharedModels.Models;

namespace SharedModels.Static
{
	public static class StaticData
	{
		private static FamilyStatus[] _familyStatuses;
		private static BusinessTripOpportunity[] _businessTripOpportunities;
		public static bool IsEmpty = true;

		public static void SetData(FamilyStatus[] familyStatuses,
			BusinessTripOpportunity[] businessTripOpportunities)
		{
			_familyStatuses = familyStatuses;
			_businessTripOpportunities = businessTripOpportunities;

			IsEmpty = false;
		}

		public static string[] GetFamilyStatuses()
			=> _familyStatuses.OrderBy(fs => fs.Id).Select(fs => fs.Status).ToArray();
		public static string[] GetBusinessTripOpportunities()
			=> _businessTripOpportunities.OrderBy(bto => bto.Id)
				.Select(bto => bto.Opportunity).ToArray();
	}
}