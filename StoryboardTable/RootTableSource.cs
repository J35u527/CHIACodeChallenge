using System;
using UIKit;
using System.Drawing;
using Foundation;
using ChaiOne.AppNet.Core.Mappers;
using CoreGraphics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;

namespace StoryboardTable
{
	public class RootTableSource : UITableViewSource
	{

		Datum[] tableItems;
		string cellIdentifier = "taskcell";
		bool _checkForRefresh, _reloading;
		RefreshTableHeaderView _refreshHeaderView;
		UITableView _table;

		public RootTableSource (Datum[] items, UITableView table, RefreshTableHeaderView refreshHeaderView)
		{
			tableItems = items;
			_table = table;
			_refreshHeaderView = refreshHeaderView;
		}


		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return tableItems.Length;
		}

		public override void ScrolledToTop (UIScrollView scrollView)
		{
			throw new System.NotImplementedException ();
		}


		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			// in a Storyboard, Dequeue will ALWAYS return a cell,

			var cell = tableView.DequeueReusableCell (cellIdentifier) as CustomCell ?? new CustomCell ((NSString)cellIdentifier);
			var avatar = FromUrl (tableItems [indexPath.Row]?.user.avatar_image?.url);
			cell.SelectionStyle = UITableViewCellSelectionStyle.None;
			cell.Header = tableItems [indexPath.Row]?.user?.username;
			cell.Text = tableItems [indexPath.Row]?.user.description?.text;
			cell.UpdateCell (cell.Header, cell.Text, avatar);
			cell.SetNeedsUpdateConstraints ();
			cell.UpdateConstraintsIfNeeded ();

			return cell;
		}

		static UIImage FromUrl (string uri)
		{
			if (!String.IsNullOrEmpty (uri)) {
				using (var url = new NSUrl (uri))
				using (var data = NSData.FromUrl (url))
					return UIImage.LoadFromData (data);
			}

			return new UIImage ();
		
		}


		public Datum GetItem (int id)
		{
			return tableItems [id];
		}



		#region UIScrollViewDelegate

		public override void Scrolled (UIScrollView scrollView)
		{
			if (_checkForRefresh) {
				if (_refreshHeaderView.isFlipped && (_table.ContentOffset.Y > -65f) && (_table.ContentOffset.Y < 0f) && !_reloading) {
					_refreshHeaderView.FlipImageAnimated (true);
					_refreshHeaderView.SetStatus (RefreshTableHeaderView.RefreshStatus.PullToReloadStatus);
				} else if ((!_refreshHeaderView.isFlipped) && (_table.ContentOffset.Y < -65f)) {
					_refreshHeaderView.FlipImageAnimated (true);
					_refreshHeaderView.SetStatus (RefreshTableHeaderView.RefreshStatus.ReleaseToReloadStatus);
				}
			}
		}

		public override void WillEndDragging (UIScrollView scrollView, CoreGraphics.CGPoint velocity, ref CGPoint targetContentOffset)
		{
			if (_table.ContentOffset.Y <= -65f) {

				NSTimer.CreateScheduledTimer (TimeSpan.FromSeconds (2f), delegate {
					_reloading = false;
					_refreshHeaderView.FlipImageAnimated (false);
					_refreshHeaderView.ToggleActivityView ();
					UIView.BeginAnimations ("DoneReloadingData");
					UIView.SetAnimationDuration (0.3);
					_table.ContentInset = new UIEdgeInsets (0f, 0f, 0f, 0f);
					_refreshHeaderView.SetStatus (RefreshTableHeaderView.RefreshStatus.PullToReloadStatus);
					UIView.CommitAnimations ();
					_refreshHeaderView.SetCurrentDate ();
				});
				
				_reloading = true;
				_table.ReloadData ();
				_refreshHeaderView.ToggleActivityView ();
				UIView.BeginAnimations ("ReloadingData");
				UIView.SetAnimationDuration (0.2);
				_table.ContentInset = new UIEdgeInsets (60f, 0f, 0f, 0f);
				UIView.CommitAnimations ();
			}
			
			_checkForRefresh = false;
		}

		public override void DraggingStarted (UIScrollView scrollView)
		{
			_checkForRefresh = true;
		}


		#endregion

	}
}

