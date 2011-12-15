using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace Tang_s_Tools
{
    class MyComparer : IComparer
    {
        private int columnIndex = 0;
        private bool isNumericColumn = false;

        public MyComparer(int columnIndex, bool isNumericColumn)
        {
            this.columnIndex = columnIndex;
            this.isNumericColumn = isNumericColumn;
        }

        public int Compare(object x, object y)
        {
            ListViewItem item = (ListViewItem)x;
            ListViewItem item2 = (ListViewItem)y;
            if (this.isNumericColumn)
            {
                if (int.Parse(item.SubItems[this.columnIndex].Text) > int.Parse(item2.SubItems[this.columnIndex].Text))
                {
                    return 1;
                }
                if (int.Parse(item.SubItems[this.columnIndex].Text) < int.Parse(item2.SubItems[this.columnIndex].Text))
                {
                    return -1;
                }
                return 0;
            }
            return string.Compare(item.SubItems[this.columnIndex].Text, item2.SubItems[this.columnIndex].Text);
        }
    }
}
