using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace CollectionView.iOS
{
	partial class CustomLabelCell : UITableViewCell
	{
		public CustomLabelCell (IntPtr handle) : base (handle)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Blue;
		}

		public void UpdateCell(string textValue)
		{
			this.CellLabel.Text = textValue;
		}
	}
}
