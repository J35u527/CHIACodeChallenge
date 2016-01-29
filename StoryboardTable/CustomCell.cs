using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;
using Praeclarum.UI;
using CoreGraphics;

namespace StoryboardTable
{
	public class CustomCell : UITableViewCell
	{
		public const string Identifier = "Reuse";

		private bool didUpdateConstraints = false;
		private UIImageView avatarImage;

		private UILabel headerLabel;
		private UILabel textLabel;
		private UIView seperator;

		protected internal CustomCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			headerLabel = new UILabel ();
			headerLabel.TextColor = UIColor.Black;
			headerLabel.Font = UIFont.SystemFontOfSize (18);

			textLabel = new UILabel ();
			textLabel.TextColor = UIColor.Black;

			textLabel.Lines = 0;
			textLabel.LineBreakMode = UILineBreakMode.WordWrap;
			textLabel.Font = UIFont.SystemFontOfSize (14);

			seperator = new UIView ();
			seperator.BackgroundColor = UIColor.FromRGB (211, 211, 211);

			avatarImage = new UIImageView ();
			//Each cell should contain the user’s avatar (bonus if the corners are rounded)
			avatarImage.Layer.MasksToBounds = true;
			avatarImage.Layer.CornerRadius = (nfloat)5.0;

			ContentView.AddSubviews (headerLabel, textLabel, seperator, avatarImage);
		}



		public string Header {
			get { return headerLabel.Text; }
			set { headerLabel.Text = value; }
		}

		public string Text {
			get { return textLabel.Text; }
			set { textLabel.Text = value; }
		}

		public void UpdateCell (string caption, string subtitle, UIImage image)
		{
			avatarImage.Image = image;
			headerLabel.Text = caption;
			textLabel.Text = subtitle;
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			avatarImage.Frame = new CGRect (0, 5, 33, 33);
			//Each cell should contain the user’s avatar (bonus if the corners are rounded)
			avatarImage.Layer.MasksToBounds = true;
			avatarImage.Layer.CornerRadius = (nfloat)5.0;
		}


		public override void UpdateConstraints ()
		{
			base.UpdateConstraints ();

			headerLabel.SetContentCompressionResistancePriority (1000, UILayoutConstraintAxis.Vertical);
			textLabel.SetContentCompressionResistancePriority (1000, UILayoutConstraintAxis.Vertical);
			seperator.SetContentCompressionResistancePriority (1000, UILayoutConstraintAxis.Vertical);

			if (!didUpdateConstraints) {
				ContentView.ConstrainLayout (() =>

					avatarImage.Frame.Top == ContentView.Frame.Top + 5
				&& avatarImage.Frame.Left == ContentView.Frame.Left + 8
				&& avatarImage.Frame.Right == ContentView.Frame.Right - 8

				&& headerLabel.Frame.Top == ContentView.Frame.Top + 5
				&& headerLabel.Frame.Left == ContentView.Frame.Left + 48
				&& headerLabel.Frame.Right == ContentView.Frame.Right - 8

				&& textLabel.Frame.Top == headerLabel.Frame.Bottom + 8
				&& textLabel.Frame.Left == ContentView.Frame.Left + 8
				&& textLabel.Frame.Right == ContentView.Frame.Right - 8

				&& seperator.Frame.Top == textLabel.Frame.Bottom + 10
				&& seperator.Frame.Left == ContentView.Frame.Left + 8
				&& seperator.Frame.Right == ContentView.Frame.Right - 8
				&& seperator.Frame.Height == 1
				&& seperator.Frame.Bottom == ContentView.Frame.Bottom - 5);

				didUpdateConstraints = true;
			}
		}
	}
}

