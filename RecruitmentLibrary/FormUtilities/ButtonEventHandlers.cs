using System;
using System.Windows.Forms;

namespace RecruitmentLibrary.FormUtilities
{
	public class ButtonEventHandlers : ControlEventHandlers<Button>
	{
		private const byte BUTTON_SIZE_PERCENT_SCALER = 4;
		private const byte BUTTON_FONT_SCALER = 2;

		#region ButtonHover
		public void SubscribeToHover(params Button[] buttons)
		{
			foreach (Button button in buttons)
			{
				if (controls.Contains(button))
					throw new ArgumentException($"The Button '{button.Name}' is already subscribed.");

				button.MouseEnter += Button_MouseEnter;
				button.MouseLeave += Button_MouseLeave;
				controls.Add(button);
			}
		}

		private void Button_MouseEnter(object sender, EventArgs e)
		{
			if (!(sender is Button button) || isControlIncreased)
				return;

			ResizeControl(button, BUTTON_SIZE_PERCENT_SCALER, true);
			ResizeFont(button, BUTTON_FONT_SCALER, true);
			isControlIncreased = true;
		}
		private void Button_MouseLeave(object sender, EventArgs e)
		{
			if (!(sender is Button button) || !isControlIncreased)
				return;

			ResizeControl(button, BUTTON_SIZE_PERCENT_SCALER, false);
			ResizeFont(button, BUTTON_FONT_SCALER, false);
			isControlIncreased = false;
		}
		#endregion

		protected override void DefaultUnsubscribe(Button button)
		{
			button.MouseEnter -= Button_MouseEnter;
			button.MouseLeave -= Button_MouseLeave;
		}
		public override void Unsubscribe(Button button)
		{
			DefaultUnsubscribe(button);
			controls.Remove(button);
		}
		public override void UnsubscribeAll()
		{
			foreach (Button button in controls)
				DefaultUnsubscribe(button);
			controls.Clear();
		}
	}
}