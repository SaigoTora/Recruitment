using System;
using System.Windows.Forms;

namespace RecruitmentLibrary.FormUtilities
{
	public class PictureBoxEventHandlers : ControlEventHandlers<PictureBox>
	{
		private const byte PICTURE_SIZE_PERCENT_SCALER = 7;

		#region PictureBoxHover
		public void SubscribeToHover(params PictureBox[] pictureBoxes)
		{
			foreach (PictureBox pictureBox in pictureBoxes)
			{
				if (controls.Contains(pictureBox))
					throw new ArgumentException($"The PictureBox '{pictureBox.Name}' is already subscribed.");

				pictureBox.MouseEnter += PictureBox_MouseEnter;
				pictureBox.MouseLeave += PictureBox_MouseLeave;
				controls.Add(pictureBox);
			}
		}

		private void PictureBox_MouseEnter(object sender, EventArgs e)
		{
			if (!(sender is PictureBox picture) || isControlIncreased)
				return;

			ResizeControl(picture, PICTURE_SIZE_PERCENT_SCALER, true);
			isControlIncreased = true;
		}
		private void PictureBox_MouseLeave(object sender, EventArgs e)
		{
			if (!(sender is PictureBox picture) || !isControlIncreased)
				return;

			ResizeControl(picture, PICTURE_SIZE_PERCENT_SCALER, false);
			isControlIncreased = false;
		}
		#endregion

		protected override void DefaultUnsubscribe(PictureBox pictureBox)
		{
			pictureBox.MouseEnter -= PictureBox_MouseEnter;
			pictureBox.MouseLeave -= PictureBox_MouseLeave;
		}
		public override void Unsubscribe(PictureBox pictureBox)
		{
			DefaultUnsubscribe(pictureBox);
			controls.Remove(pictureBox);
		}
		public override void UnsubscribeAll()
		{
			foreach (PictureBox pictureBox in controls)
				DefaultUnsubscribe(pictureBox);
			controls.Clear();
		}
	}
}