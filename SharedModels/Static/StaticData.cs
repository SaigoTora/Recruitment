using Newtonsoft.Json;
using System;
using System.Linq;

using SharedModels.Models;

namespace SharedModels.Static
{
	[Serializable]
	public class StaticData
	{
		[JsonProperty]
		private readonly FamilyStatus[] _familyStatuses;
		[JsonProperty]
		private readonly BusinessTripOpportunity[] _businessTripOpportunities;

		[JsonConstructor]
		public StaticData(FamilyStatus[] familyStatuses,
			BusinessTripOpportunity[] businessTripOpportunities)
		{
			_familyStatuses = familyStatuses;
			_businessTripOpportunities = businessTripOpportunities;
		}

		public string[] GetFamilyStatuses()
			=> _familyStatuses.OrderBy(fs => fs.Id).Select(fs => fs.Status).ToArray();
		public string[] GetBusinessTripOpportunities()
			=> _businessTripOpportunities.OrderBy(bto => bto.Id)
				.Select(bto => bto.Opportunity).ToArray();
	}
}