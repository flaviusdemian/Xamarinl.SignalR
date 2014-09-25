using System;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SignalRDemo.iOS.TableHelpers
{
    public class TableSource : UITableViewSource
    {
        public static List<String> tableItems;
        private string cellIdentifier = "TableCell";

        public TableSource(List<String> items)
        {
            tableItems = items;
        }

        /// <summary>
        ///     Called by the TableView to determine how many cells to create for that particular section.
        /// </summary>
        public override int RowsInSection(UITableView tableview, int section)
        {
            return tableItems.Count;
        }

        /// <summary>
        ///     Called by the TableView to get the actual UITableViewCell to render for the particular row
        /// </summary>
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // request a recycled cell to save memory
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
            // if there are no cells to reuse, create a new one
            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
            cell.TextLabel.Text = tableItems[indexPath.Row];
            return cell;
        }
    }
}