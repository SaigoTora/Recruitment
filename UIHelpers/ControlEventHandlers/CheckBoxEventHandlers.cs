using Guna.UI2.WinForms;
using System;

namespace UIHelpers.ControlEventHandlers
{
	public class CheckBoxEventHandlers : ControlEventHandlers<Guna2CustomCheckBox>
	{
		#region CheckBox hover
		public void SubscribeToHoverShadow(params Guna2CustomCheckBox[] checkBoxes)
		{
			foreach (Guna2CustomCheckBox checkBox in checkBoxes)
			{
				if (controls.Contains(checkBox))
					throw new ArgumentException($"The CheckBox '{checkBox.Name}' " +
						$"is already subscribed.");

				checkBox.MouseEnter += CheckBoxShadow_MouseEnter;
				checkBox.MouseLeave += CheckBoxShadow_MouseLeave;
				controls.Add(checkBox);
			}
		}

		private void CheckBoxShadow_MouseEnter(object sender, EventArgs e)
		{
			if (!(sender is Guna2CustomCheckBox checkBox))
				return;

			checkBox.ShadowDecoration.Enabled = true;
		}
		private void CheckBoxShadow_MouseLeave(object sender, EventArgs e)
		{
			if (!(sender is Guna2CustomCheckBox checkBox))
				return;

			checkBox.ShadowDecoration.Enabled = false;
		}
		#endregion

		protected override void DefaultUnsubscribe(Guna2CustomCheckBox checkBox)
		{
			checkBox.MouseEnter -= CheckBoxShadow_MouseEnter;
			checkBox.MouseLeave -= CheckBoxShadow_MouseLeave;
		}
		public override void Unsubscribe(Guna2CustomCheckBox checkBox)
		{
			DefaultUnsubscribe(checkBox);
			controls.Remove(checkBox);
		}
		public override void UnsubscribeAll()
		{
			foreach (Guna2CustomCheckBox checkBox in controls)
				DefaultUnsubscribe(checkBox);
			controls.Clear();
		}
	}
}