using System;
using RecruitmentLibrary.PersonInfo;
using UIHelpers.Themes;

namespace RecruitmentClient.Models
{
	[Serializable]
	public class Account
	{
		[NonSerialized]
		public Candidate candidate;
		public Theme Theme;
		public string Login { get; private set; }
		public string Password { get; private set; }

		public Account() { }

		public void SetLoginPassword(string login, string password)
		{
			Login = login;
			Password = password;
		}
	}
}