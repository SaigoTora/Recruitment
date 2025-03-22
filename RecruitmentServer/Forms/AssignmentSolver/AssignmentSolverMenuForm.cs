using System;

using RecruitmentLibrary.Assignment;
using RecruitmentServer.Models;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;

namespace RecruitmentServer.Forms.AssignmentSolver
{
	internal partial class AssignmentSolverMenuForm : BaseForm, IThemeChange
	{
		private readonly Account _account;
		private readonly Action<EventArgs> _refreshMainForm;

		internal AssignmentSolverMenuForm(Account account, Action<EventArgs> refreshMainForm)
		{
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, "Розподіл кандидатів",
				minimizeBox: false, maximizeBox: false);
			_account = account;
			_refreshMainForm = refreshMainForm;
		}
		private void AssignmentSolverMenu_Load(object sender, EventArgs e)
			=> SetTheme(_account.Theme);

		public void SetTheme(Theme theme)
			=> ThemeControlManager.ChangeFormTheme(this, theme);

		private void ButtonHungarianSolver_Click(object sender, EventArgs e)
			=> OpenAssignmentSolverForm(new HungarianAssignmentSolver());
		private void ButtonAuctionSolver_Click(object sender, EventArgs e)
			=> OpenAssignmentSolverForm(new AuctionAssignmentSolver());

		private void OpenAssignmentSolverForm(IAssignmentSolver assignmentSolver)
		{
			AssignmentSolverForm assignmentSolverForm = new AssignmentSolverForm(_account, _refreshMainForm, assignmentSolver);
			assignmentSolverForm.ShowDialog();
		}
	}
}