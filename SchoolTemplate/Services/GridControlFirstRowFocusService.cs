// Developer Express Code Central Example:
// How to: Create a Custom Service
// 
// This example demonstrates how to create a custom service (a ServiceBase
// descendant).
// Review this documentation topic
// (https://documentation.devexpress.com/#WPF/CustomDocument16920) to learn more.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E5093

using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Grid;
using System.Windows;

namespace Example.Service
{
    public class GridControlFirstRowFocusService : ServiceBase, IGridControlFirstRowFocusService
    {
       
        void IGridControlFirstRowFocusService.FocusFirstRow()
        {
            ((GridControl)AssociatedObject).View.FocusedRowHandle = 0;
            //MessageBox.Show(Message);
        }
    }
}
