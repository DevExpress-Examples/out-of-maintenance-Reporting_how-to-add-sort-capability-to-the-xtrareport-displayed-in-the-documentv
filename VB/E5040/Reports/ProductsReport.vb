Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports DevExpress.XtraReports.UI
Imports System.Collections.Generic
Imports System.Web

Namespace E5040.Reports
	Partial Public Class ProductsReport
		Inherits DevExpress.XtraReports.UI.XtraReport
		Private Const SortedColumnSuffix_Ascending As String = " ▼"
		Private Const SortedColumnSuffix_Descending As String = " ▲"
		Private Const SortedColumns_SessionKey As String = "ProductsReport_SortedColumns"

		Private Shared _sortedColumns As List(Of GroupField) = Nothing

		Public Shared ReadOnly Property SortedColumns() As List(Of GroupField)
			Get
				If _sortedColumns Is Nothing Then
					_sortedColumns = CType(HttpContext.Current.Session(SortedColumns_SessionKey), List(Of GroupField))
					If _sortedColumns Is Nothing Then
						_sortedColumns = New List(Of GroupField)()
						HttpContext.Current.Session(SortedColumns_SessionKey) = _sortedColumns
					End If
				End If
				Return _sortedColumns
			End Get
		End Property

		Public Sub New()
			InitializeComponent()
		End Sub

		Public Shared Sub SortBy(ByVal fieldName As String, ByVal isAdding As Boolean)
			If isAdding Then
                SortedColumns.ForEach(Sub(sortField)
                                          If sortField.FieldName = fieldName Then
                                              sortField.SortOrder = If((sortField.SortOrder = XRColumnSortOrder.Ascending), XRColumnSortOrder.Descending, XRColumnSortOrder.Ascending)
                                              Return
                                          End If
                                      End Sub)
			Else
				If SortedColumns.Count = 1 AndAlso SortedColumns(0).FieldName = fieldName Then
					SortedColumns(0).SortOrder = If((SortedColumns(0).SortOrder = XRColumnSortOrder.Ascending), XRColumnSortOrder.Descending, XRColumnSortOrder.Ascending)
				Else
					SortedColumns.Clear()
				End If
			End If
			SortedColumns.Add(New GroupField(fieldName, XRColumnSortOrder.Ascending))
        End Sub

		Private Sub ProductsReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
			Detail.SortFields.Clear()
			Detail.SortFields.AddRange(SortedColumns.ToArray())
		End Sub

		Private Sub HeaderCell_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles tcProductNameHeader.BeforePrint, tcCategoryNameHeader.BeforePrint, tcCompanyNameHeader.BeforePrint, tcContactNameHeader.BeforePrint, tcUnitPriceHeader.BeforePrint, tcUnitsInStockHeader.BeforePrint, tcUnitsOnOrderHeader.BeforePrint, tcDiscontinuedHeader.BeforePrint
			Dim headerCell As XRLabel = TryCast(sender, XRLabel)
			Dim fieldName As String = CStr(headerCell.Tag)
			Dim sort As GroupField = SortedColumns.Find(Function(sortField) sortField.FieldName = fieldName)

			headerCell.Text = headerCell.Text.Replace(SortedColumnSuffix_Ascending, "")
			headerCell.Text = headerCell.Text.Replace(SortedColumnSuffix_Descending, "")
			If sort IsNot Nothing Then
				headerCell.Text += If((sort.SortOrder = XRColumnSortOrder.Ascending), SortedColumnSuffix_Ascending, SortedColumnSuffix_Descending)
			End If
		End Sub

		Private Sub HeaderCell_HtmlItemCreated(ByVal sender As Object, ByVal e As HtmlEventArgs) Handles tcProductNameHeader.HtmlItemCreated, tcCategoryNameHeader.HtmlItemCreated, tcCompanyNameHeader.HtmlItemCreated, tcContactNameHeader.HtmlItemCreated, tcUnitPriceHeader.HtmlItemCreated, tcUnitsInStockHeader.HtmlItemCreated, tcUnitsOnOrderHeader.HtmlItemCreated, tcDiscontinuedHeader.HtmlItemCreated
			e.ContentCell.Attributes.Add("onclick", String.Format("parent.ProductsReport_HeaderClick(this, event, '{0}')", e.Brick.Value))
			e.ContentCell.Style.Add("cursor", "pointer")
		End Sub
	End Class
End Namespace
