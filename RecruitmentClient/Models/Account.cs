using System;
using System.Runtime.Serialization;

using SharedModels.Models;
using UIHelpers.Themes;

namespace RecruitmentClient.Models
{
	[Serializable]
	internal class Account
	{
		internal Candidate Candidate;
		internal Theme Theme;
		[NonSerialized]
		private Candidate _tempCandidate;

		internal Account()
			=> Candidate = new Candidate();

		[OnSerializing]
		private void OnSerializing(StreamingContext context)
		{
			_tempCandidate = (Candidate)Candidate.Clone();
			string login = Candidate.Login, password = Candidate.Password;
			Candidate = new Candidate();
			Candidate.ChangeLoginPassword(login, password);
		}
		[OnSerialized]
		private void OnSerialized(StreamingContext context)
			=> Candidate = _tempCandidate;
	}
}