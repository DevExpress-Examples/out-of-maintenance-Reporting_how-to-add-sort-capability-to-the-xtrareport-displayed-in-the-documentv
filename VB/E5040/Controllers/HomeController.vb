Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports E5040.Reports

Namespace E5040.Controllers
	Public Class HomeController
		Inherits Controller
		Public Function Index() As ActionResult
			ViewBag.Message = "Welcome to DevExpress Extensions for ASP.NET MVC!"

			Return View()
		End Function

		Public Function CallbackPanelPartial(ByVal fieldName As String, ByVal isShiftKeyPressed As Boolean) As ActionResult
			ProductsReport.SortBy(fieldName, isShiftKeyPressed)
			Return PartialView("_CallbackPanelPartial")
		End Function

		Public Function DocumentViewerPartial() As ActionResult
			Dim report As New ProductsReport()
			Return PartialView("_DocumentViewerPartial", report)
		End Function

		Public Function DocumentViewerExport() As ActionResult
			Dim report As New ProductsReport()
			Return ReportViewerExtension.ExportTo(report)
		End Function
	End Class
End Namespace