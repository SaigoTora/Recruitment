using Guna.UI2.WinForms;
using System;

namespace UIHelpers.ControlEventHandlers
{
	public class RadioButtonEventHandlers : ControlEventHandlers<Guna2CustomRadioButton>
	{
		#region RadioButton hover
		public void SubscribeToHoverShadow(params Guna2CustomRadioButton[] radioButtons)
		{
			foreach (Guna2CustomRadioButton radioButton in radioButtons)
			{
				if (controls.Contains(radioButton))
					throw new ArgumentException($"The RadioButton '{radioButton.Name}' " +
						$"is already subscribed.");

				radioButton.MouseEnter += RadioButtonShadow_MouseEnter;
				radioButton.MouseLeave += RadioButtonShadow_MouseLeave;
				controls.Add(radioButton);
			}
		}

		private void RadioButtonShadow_MouseEnter(object sender, EventArgs e)
		{
			if (!(sender is Guna2CustomRadioButton radioButton))
				return;

			radioButton.ShadowDecoration.Enabled = true;
		}
		private void RadioButtonShadow_MouseLeave(object sender, EventArgs e)
		{
			if (!(sender is Guna2CustomRadioButton radioButton))
				return;

			radioButton.ShadowDecoration.Enabled = false;
		}
		#endregion

		protected override void DefaultUnsubscribe(Guna2CustomRadioButton radioButton)
		{
			radioButton.MouseEnter -= RadioButtonShadow_MouseEnter;
			radioButton.MouseLeave -= RadioButtonShadow_MouseLeave;
		}
		public override void Unsubscribe(Guna2CustomRadioButton radioButton)
		{
			DefaultUnsubscribe(radioButton);
			controls.Remove(radioButton);
		}
		public override void UnsubscribeAll()
		{
			foreach (Guna2CustomRadioButton radioButton in controls)
				DefaultUnsubscribe(radioButton);
			controls.Clear();
		}
	}
}