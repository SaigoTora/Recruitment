using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;

using RecruitmentLibrary.Assignment;
using RecruitmentServer.Models;
using UIHelpers.Controls;
using UIHelpers.Forms;
using UIHelpers.Themes;

namespace RecruitmentServer.Forms.AssignmentSolver
{
	internal partial class AssignmentSolversEfficiencyForm : BaseForm, IThemeChange
	{
		private readonly Account _account;
		private readonly Random _random = new Random();

		internal AssignmentSolversEfficiencyForm(Account account)
		{
			InitializeComponent();

			customTitleBar = new CustomTitleBar(this, "Тестування ефективності алгоритмів " +
				"призначень", minimizeBox: false, maximizeBox: false);
			_account = account;
		}
		private void AssignmentSolversEfficiencyForm_Load(object sender, EventArgs e)
		{
			ClearResultLabels();
			SetTheme(_account.Theme);
		}
		private async void ButtonStart_Click(object sender, EventArgs e)
		{
			ClearResultLabels();
			buttonStart.Enabled = false;
			int[,] matrix = new int[(int)NUDCandidateCount.Value, (int)NUDVacancyCount.Value];
			int minPoints = radioButtonAllSubmittedYes.Checked ? 0 : -1;
			int maxPoints = (int)NUDMaxPoints.Value;
			bool findMax = radioButtonFindMaxYes.Checked;

			await Task.Run(() =>
			{
				FillMatrix(matrix, minPoints, maxPoints);
				TestMethods(matrix, findMax);
			});
		}
		private void ClearResultLabels()
		{
			labelResults.Text = string.Empty;
			labelHungarianResult.Text = string.Empty;
			labelAuctionResult.Text = string.Empty;

			labelHungarianResult.ForeColor = labelResults.ForeColor;
			labelAuctionResult.ForeColor = labelResults.ForeColor;
		}
		private void FillMatrix(int[,] matrix, int minValue, int maxValue)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
				for (int j = 0; j < matrix.GetLength(1); j++)
					matrix[i, j] = _random.Next(minValue, maxValue + 1);
		}
		private void TestMethods(int[,] matrix, bool findMax)
		{
			HungarianAssignmentSolver hungarianAssignmentSolver = new HungarianAssignmentSolver();
			AuctionAssignmentSolver auctionAssignmentSolver = new AuctionAssignmentSolver();
			var sw = new Stopwatch();
			sw.Start();
			hungarianAssignmentSolver.Solve(matrix, findMax);
			sw.Stop();
			labelResults.Text = "Результати:";
			labelHungarianResult.Text = $"Угорський алгоритм: {GetFormattedTime(sw.Elapsed)}";
			long hungarianTicks = sw.Elapsed.Ticks;

			sw.Restart();
			auctionAssignmentSolver.Solve(matrix, findMax);
			sw.Stop();
			labelAuctionResult.Text = $"Алгоритм аукціону: {GetFormattedTime(sw.Elapsed)}";
			long auctionTicks = sw.Elapsed.Ticks;
			if (hungarianTicks < auctionTicks)
			{
				labelHungarianResult.ForeColor = Color.Green;
				labelAuctionResult.ForeColor = Color.Red;
			}
			else
			{
				labelHungarianResult.ForeColor = Color.Red;
				labelAuctionResult.ForeColor = Color.Green;
			}
			buttonStart.Enabled = true;
		}
		private string GetFormattedTime(TimeSpan time)
		{
			string ticks = $"{time.Ticks:N0}".Replace(',', ' ');

			if (time.Ticks <= 100000)
				return $"{time:mm\\:ss\\:ff} (Часові тіки: {ticks})";
			else
				return $"{time:mm\\:ss\\:ff}";
		}

		#region Label focus event handlers
		private void LabelVacancyCount_Click(object sender, EventArgs e)
			=> NUDVacancyCount.Focus();
		private void LabelCandidateCount_Click(object sender, EventArgs e)
			=> NUDCandidateCount.Focus();
		private void LabelMaxPoints_Click(object sender, EventArgs e)
			=> NUDMaxPoints.Focus();

		private void LabelAllSubmittedNo_Click(object sender, EventArgs e)
			=> radioButtonAllSubmittedNo.Checked = true;
		private void LabelAllSubmittedYes_Click(object sender, EventArgs e)
			=> radioButtonAllSubmittedYes.Checked = true;

		private void LabelFindMaxNo_Click(object sender, EventArgs e)
			=> radioButtonFindMaxNo.Checked = true;
		private void LabelFindMaxYes_Click(object sender, EventArgs e)
			=> radioButtonFindMaxYes.Checked = true;
		#endregion

		public void SetTheme(Theme theme)
			=> ThemeControlManager.ChangeFormTheme(this, theme);
	}
}