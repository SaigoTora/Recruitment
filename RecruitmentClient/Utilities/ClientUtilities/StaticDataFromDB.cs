using System.Linq;
using System.Threading.Tasks;

using SharedModels.Models;

namespace RecruitmentClient.Utilities.ClientUtilities
{
	internal static class StaticDataFromDB
	{
		private static FamilyStatus[] _familyStatuses;
		private static BusinessTripOpportunity[] _businessTripOpportunities;

		internal static void SetData()
		{
			if (_familyStatuses == null && _businessTripOpportunities == null)
			{
				Task.Run(async () =>
				{
					_familyStatuses = await Program.Client.GetFamilyStatusesAsync();
					_businessTripOpportunities =
					await Program.Client.GetBusinessTripOpportunitiesAsync();
				}).Wait();
			}
		}

		internal static string[] GetFamilyStatuses()
			=> _familyStatuses.Select(fs => fs.Status).ToArray();
		internal static string[] GetBusinessTripOpportunities()
			=> _businessTripOpportunities.Select(bto => bto.Opportunity).ToArray();
	}
}