﻿using System;
using UIKit;

namespace StoryboardTable
{
	public class GrowRowTableDelegate : UITableViewDelegate
	{
		#region Private Variables

		//		private MasterViewController Controller;

		#endregion

		#region Constructors

		public GrowRowTableDelegate ()
		{
		}

		public GrowRowTableDelegate (MasterViewController controller)
		{
			// Initialize
//			this.Controller = controller;
		}

		#endregion

		#region Override Methods

		public override nfloat EstimatedHeight (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			return 40f;
		}

		public override void RowSelected (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			// Output selected row
			Console.WriteLine ("Row selected: {0}", indexPath.Row);
		}

		#endregion
	}
}

