# How to add sort capability to the XtraReport displayed in the DocumentViewer extension


<p>This example demonstrates how to add the preview sorting functionality to a report in the ASP.NET MVC Web application.</p><p>Some key points of this example:<br />
- Sorting is accomplished during the callback, which prevents full page post back (AJAX-orientired behavior).</p><p>- Callback raised from the client side by the ASPxClientCallbackPanel.PerformCallback method.</p><p>- FieldName of the column, on which the sorting action should take place and the Shift key pressed state is passed to the controller as a callback parameter.</p><p>- XtraReport.HtmlItemCreated event handled, in order to insert sorting option buttons to the report header via the HtmlEventArgs.ContentCell parameter.</p>

<br/>


