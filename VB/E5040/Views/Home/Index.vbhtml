@Code
    ViewBag.Title = "Home Page"
End Code
<script type="text/javascript">
    function ProductsReport_HeaderClick(s, e, fieldName) {
        CallbackPanel.PerformCallback({ FieldName: fieldName, IsShiftKeyPressed: e.shiftKey });
    }
</script>
@Html.Partial("_CallbackPanelPartial")
