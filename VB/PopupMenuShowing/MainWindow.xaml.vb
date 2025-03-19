Imports System.Windows
Imports DevExpress.Xpf.PdfViewer
Imports DevExpress.Xpf.Bars

Namespace PopupMenuShowing

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            ' Load a document.
            Me.viewer.OpenDocument("..\..\Demo.pdf")
        End Sub

        Private Sub Viewer_PopupMenuShowing(ByVal d As DependencyObject, ByVal e As PopupMenuShowingEventArgs)
            ' Remove the Hand tool item from the page context popup menu.
            Dim removeHandTool As RemoveAction = New RemoveAction()
            removeHandTool.ElementName = DefaultPdfBarManagerItemNames.HandTool
            e.Actions.Add(removeHandTool)
            ' Remove the Select All item from the page context popup menu.
            Dim removeSelectAll As RemoveAction = New RemoveAction()
            removeSelectAll.ElementName = DefaultPdfBarManagerItemNames.SelectAll
            e.Actions.Add(removeSelectAll)
            ' Insert the "Save As..." item invoking the Save As dialog.
            Dim barButtonItem As BarButtonItem = New BarButtonItem()
            barButtonItem.Content = "Save As..."
            barButtonItem.Command = Me.viewer.SaveAsCommand
            Dim insertBarButtonItem As InsertAction = New InsertAction()
            insertBarButtonItem.ContainerName = DefaultPdfBarManagerItemNames.ContextMenu
            insertBarButtonItem.Element = barButtonItem
            e.Actions.Add(insertBarButtonItem)
        End Sub
    End Class
End Namespace
