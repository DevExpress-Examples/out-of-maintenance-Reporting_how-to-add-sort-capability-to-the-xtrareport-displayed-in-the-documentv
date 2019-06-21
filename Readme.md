<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/E5040/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/E5040/Controllers/HomeController.vb))
* [ProductsReport.cs](./CS/E5040/Reports/ProductsReport.cs) (VB: [ProductsReport.vb](./VB/E5040/Reports/ProductsReport.vb))
* [_CallbackPanelPartial.cshtml](./CS/E5040/Views/Home/_CallbackPanelPartial.cshtml)
* [_DocumentViewerPartial.cshtml](./CS/E5040/Views/Home/_DocumentViewerPartial.cshtml)
* **[Index.cshtml](./CS/E5040/Views/Home/Index.cshtml)**
<!-- default file list end -->
# How to add sort capability to the XtraReport displayed in the DocumentViewer extension
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e5040)**
<!-- run online end -->


<p>This example demonstrates how to add the preview sorting functionality to a report in the ASP.NET MVC Web application.</p><p>Some key points of this example:<br />
- Sorting is accomplished during the callback, which prevents full page post back (AJAX-orientired behavior).</p><p>- Callback raised from the client side by the ASPxClientCallbackPanel.PerformCallback method.</p><p>- FieldName of the column, on which the sorting action should take place and the Shift key pressed state is passed to the controller as a callback parameter.</p><p>- XtraReport.HtmlItemCreated event handled, in order to insert sorting option buttons to the report header via the HtmlEventArgs.ContentCell parameter.</p>

<br/>


