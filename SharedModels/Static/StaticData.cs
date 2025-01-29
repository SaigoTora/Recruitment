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
		[JsonProperty]
		private readonly EducationDegree[] _educationDegrees;
		[JsonProperty]
		private readonly EducationForm[] _educationForms;

		[JsonConstructor]
		public StaticData(FamilyStatus[] familyStatuses,
			BusinessTripOpportunity[] businessTripOpportunities,
			EducationDegree[] educationDegrees, EducationForm[] educationForms)
		{
			_familyStatuses = familyStatuses;
			_businessTripOpportunities = businessTripOpportunities;
			_educationDegrees = educationDegrees;
			_educationForms = educationForms;
		}

		public string[] GetFamilyStatuses()
			=> _familyStatuses.OrderBy(fs => fs.Id).Select(fs => fs.Status).ToArray();
		public string[] GetBusinessTripOpportunities()
			=> _businessTripOpportunities.OrderBy(bto => bto.Id)
				.Select(bto => bto.Opportunity).ToArray();
		public string[] GetEducationDegrees()
			=> _educationDegrees.OrderBy(ed => ed.Id).Select(ed => ed.Degree).ToArray();
		public string[] GetEducationForms()
			=> _educationForms.OrderBy(ef => ef.Id).Select(ef => ef.Form).ToArray();
	}
}