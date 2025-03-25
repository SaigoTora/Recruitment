using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
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
		private int[,] matrix;
		private bool findMax;

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
			Cursor = Cursors.WaitCursor;
			matrix = new int[(int)NUDCandidateCount.Value, (int)NUDVacancyCount.Value];
			int minPoints = radioButtonAllSubmittedYes.Checked ? 0 : -1;
			int maxPoints = (int)NUDMaxPoints.Value;
			bool findMax = radioButtonFindMaxYes.Checked;

			await Task.Run(() =>
			{
				FillMatrix(minPoints, maxPoints);
				TestMethods();
			});
			Cursor = Cursors.Default;
			buttonStart.Enabled = true;
		}
		private void ClearResultLabels()
		{
			labelResults.Visible = false;
			labelHungarianResult.Visible = false;
			labelAuctionResult.Visible = false;
			labelHungarianTime.Text = string.Empty;
			labelHungarianMemory.Text = string.Empty;
			labelAuctionTime.Text = string.Empty;
			labelAuctionMemory.Text = string.Empty;

			labelHungarianResult.ForeColor = labelResults.ForeColor;
			labelAuctionResult.ForeColor = labelResults.ForeColor;
		}
		private void FillMatrix(int minValue, int maxValue)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
				for (int j = 0; j < matrix.GetLength(1); j++)
					matrix[i, j] = _random.Next(minValue, maxValue + 1);
		}
		private void TestMethods()
		{
			HungarianAssignmentSolver hungarianAssignmentSolver = new HungarianAssignmentSolver();
			TestMethod(hungarianAssignmentSolver, labelHungarianResult, labelHungarianTime,
				labelHungarianMemory);

			AuctionAssignmentSolver auctionAssignmentSolver = new AuctionAssignmentSolver();
			TestMethod(auctionAssignmentSolver, labelAuctionResult, labelAuctionTime,
				labelAuctionMemory);
		}
		private void TestMethod(IAssignmentSolver assignmentSolver, Label labelResultTitle,
			Label labelTime, Label labelMemory)
		{
			long memoryBefore = GC.GetTotalMemory(true), memoryAfter;

			var sw = new Stopwatch();
			sw.Start();
			assignmentSolver.Solve(matrix, findMax);
			sw.Stop();

			memoryAfter = GC.GetTotalMemory(false);
			long memoryUsed = memoryAfter - memoryBefore;
			labelResults.Visible = true;
			labelResultTitle.Visible = true;

			labelTime.Text = $"Час виконання: {GetFormattedTime(sw.Elapsed)}";
			labelMemory.Text = $"Використано пам'яті: {GetFormattedMemory(memoryUsed)}";
		}
		private string GetFormattedTime(TimeSpan time)
		{
			string ticks = $"{time.Ticks:N0}".Replace(',', ' ');

			if (time.Ticks <= 100000)
				return $"{time:mm\\:ss\\:ff} (Часові тіки: {ticks})";
			else
				return $"{time:mm\\:ss\\:ff}";
		}
		private string GetFormattedMemory(long memory)
		{
			string memoryResult;
			if (memory > 1024)
			{
				if (memory / 1024 > 1024)
					memoryResult = $"{(memory / 1024 / 1024).ToString("N0").Replace(',', ' ')} МБ.";
				else
					memoryResult = $"{(memory / 1024).ToString("N0").Replace(',', ' ')} КБ.";
			}
			else
				memoryResult = $"{memory.ToString("N0").Replace(',', ' ')} Б.";

			return memoryResult;
		}

		private void NUD_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				SelectNextControl(ActiveControl, true, true, true, false);
			}
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