Imports System.Windows
Imports DevExpress.Xpf.PdfViewer
Imports DevExpress.Xpf.Bars

Namespace PopupMenuShowing

    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()

            ' Load a document.
            viewer.OpenDocument("..\..\Demo.pdf")
        End Sub

        Private Sub Viewer_PopupMenuShowing(ByVal d As DependencyObject, ByVal e As PopupMenuShowingEventArgs)

            ' Remove the Hand tool item from the page context popup menu.
            Dim removeHandTool As New RemoveAction()
            removeHandTool.ElementName = DefaultPdfBarManagerItemNames.HandTool
            e.Actions.Add(removeHandTool)

            ' Remove the Select All item from the page context popup menu.
            Dim removeSelectAll As New RemoveAction()
            removeSelectAll.ElementName = DefaultPdfBarManagerItemNames.SelectAll
            e.Actions.Add(removeSelectAll)

            ' Insert the "Save As..." item invoking the Save As dialog.
            Dim barButtonItem As New BarButtonItem()
            barButtonItem.Content = "Save As..."
            barButtonItem.Command = viewer.SaveAsCommand
            Dim insertBarButtonItem As New InsertAction()
            insertBarButtonItem.ContainerName = DefaultPdfBarManagerItemNames.ContextMenu
            insertBarButtonItem.Element = barButtonItem
            e.Actions.Add(insertBarButtonItem)
        End Sub
    End Class
End Namespace
