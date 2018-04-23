using System.Windows;
using DevExpress.Xpf.PdfViewer;
using DevExpress.Xpf.Bars;

namespace PopupMenuShowing {

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            // Load a document.
            viewer.OpenDocument("..\\..\\Demo.pdf");
        }

        private void Viewer_PopupMenuShowing(DependencyObject d, PopupMenuShowingEventArgs e) {

            // Remove the Hand tool item from the page context popup menu.
            RemoveAction removeHandTool = new RemoveAction();
            removeHandTool.ElementName = DefaultPdfBarManagerItemNames.HandTool;
            e.Actions.Add(removeHandTool);

            // Remove the Select All item from the page context popup menu.
            RemoveAction removeSelectAll = new RemoveAction();
            removeSelectAll.ElementName = DefaultPdfBarManagerItemNames.SelectAll;
            e.Actions.Add(removeSelectAll);

            // Insert the "Save As..." item invoking the Save As dialog.
            BarButtonItem barButtonItem = new BarButtonItem();
            barButtonItem.Content = "Save As...";
            barButtonItem.Command = viewer.SaveAsCommand;
            InsertAction insertBarButtonItem = new InsertAction();
            insertBarButtonItem.ContainerName = DefaultPdfBarManagerItemNames.ContextMenu;
            insertBarButtonItem.Element = barButtonItem;
            e.Actions.Add(insertBarButtonItem);
        }
    }
}
