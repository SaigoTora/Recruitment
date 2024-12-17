using Guna.UI2.WinForms;
using System;

namespace UIHelpers.ControlEventHandlers
{
	public class ButtonEventHandlers : ControlEventHandlers<Guna2GradientButton>
	{
		private const byte BUTTON_SIZE_PERCENT_SCALER = 3;
		private const byte BUTTON_FONT_SCALER = 1;

		#region Button hover
		public void SubscribeToHover(params Guna2GradientButton[] buttons)
		{
			foreach (Guna2GradientButton button in buttons)
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
			if (!(sender is Guna2GradientButton button) || isControlIncreased)
				return;

			ResizeControl(button, BUTTON_SIZE_PERCENT_SCALER, true);
			ResizeFont(button, BUTTON_FONT_SCALER, true);
			isControlIncreased = true;
		}
		private void Button_MouseLeave(object sender, EventArgs e)
		{
			if (!(sender is Guna2GradientButton button) || !isControlIncreased)
				return;

			ResizeControl(button, BUTTON_SIZE_PERCENT_SCALER, false);
			ResizeFont(button, BUTTON_FONT_SCALER, false);
			isControlIncreased = false;
		}
		#endregion

		protected override void DefaultUnsubscribe(Guna2GradientButton button)
		{
			button.MouseEnter -= Button_MouseEnter;
			button.MouseLeave -= Button_MouseLeave;
		}
		public override void Unsubscribe(Guna2GradientButton button)
		{
			DefaultUnsubscribe(button);
			controls.Remove(button);
		}
		public override void UnsubscribeAll()
		{
			foreach (Guna2GradientButton button in controls)
				DefaultUnsubscribe(button);
			controls.Clear();
		}
	}
}