using System;
using CoreGraphics;
using System.Collections.Generic;

using Foundation;
using UIKit;
using System.Linq;
using ChaiOne.AppNet.Core.Mappers;
using ChaiOne.AppNet.Core.Service;
using System.Threading.Tasks;

namespace StoryboardTable
{
	public partial class MasterViewController : UITableViewController
	{
		RefreshTableHeaderView _refreshHeaderView;
		RootObject rootObj;
		AppNetService service = AppNetService.Instance;

		public GrowRowTableDelegate TableDelegate {
			get { return TableView.Delegate as GrowRowTableDelegate; }
		}

		public MasterViewController (IntPtr handle) : base (handle)
		{
			Title = "App.net";

			_refreshHeaderView = new RefreshTableHeaderView ();

			_refreshHeaderView.BackgroundColor = new UIColor (226f, 231f, 237f, 1f);
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

		}

		public async override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		
			TableView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
		
			TableView.AddSubview (_refreshHeaderView);
			rootObj = await service.GetGlobalStream ();
			TableView.Source = new RootTableSource (rootObj.data.OrderByDescending (x => x.created_at).ToArray (), TableView, _refreshHeaderView);
			TableView.RowHeight = UITableView.AutomaticDimension;
			TableView.EstimatedRowHeight = 100;
			TableView.Delegate = new GrowRowTableDelegate (this);
		}



		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion

	}
}

