using RecruitmentClient.Models;

namespace RecruitmentClient.Utilities.ClientUtilities
{
	internal static class StaticDataFromDB
	{
		internal static string[] FamilyStatuses { get; private set; }
		internal static string[] BusinessTripOpportunities { get; private set; }

		internal static void SetData()
		{
			if (FamilyStatuses == null && BusinessTripOpportunities == null)
			{
				FamilyStatuses = Client.GetFamilyStatuses();
				BusinessTripOpportunities = Client.GetBusinessTripOpportunities();
			}
		}
	}
}