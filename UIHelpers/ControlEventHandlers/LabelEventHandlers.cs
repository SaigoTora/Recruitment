using System;
using System.Drawing;
using System.Windows.Forms;

namespace UIHelpers.ControlEventHandlers
{
	public class LabelEventHandlers : ControlEventHandlers<Label>
	{
		#region Label hover
		public void SubscribeToHoverUnderline(params Label[] labels)
		{
			foreach (Label label in labels)
			{
				if (controls.Contains(label))
					throw new ArgumentException($"The Label '{label.Name}' " +
						$"is already subscribed.");

				label.MouseEnter += LabelUnderline_MouseEnter;
				label.MouseLeave += LabelUnderline_MouseLeave;
				controls.Add(label);
			}
		}

		private void LabelUnderline_MouseEnter(object sender, EventArgs e)
		{
			if (!(sender is Label label))
				return;

			label.Font = new Font(label.Font, FontStyle.Underline);
		}
		private void LabelUnderline_MouseLeave(object sender, EventArgs e)
		{
			if (!(sender is Label label))
				return;

			label.Font = new Font(label.Font, FontStyle.Regular);
		}
		#endregion

		protected override void DefaultUnsubscribe(Label label)
		{
			label.MouseEnter -= LabelUnderline_MouseEnter;
			label.MouseLeave -= LabelUnderline_MouseLeave;
		}
		public override void Unsubscribe(Label label)
		{
			DefaultUnsubscribe(label);
			controls.Remove(label);
		}
		public override void UnsubscribeAll()
		{
			foreach (Label label in controls)
				DefaultUnsubscribe(label);
			controls.Clear();
		}
	}
}