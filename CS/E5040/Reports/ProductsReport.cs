using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Web;

namespace E5040.Reports {
    public partial class ProductsReport : DevExpress.XtraReports.UI.XtraReport {
        const string SortedColumnSuffix_Ascending = " ▼";
        const string SortedColumnSuffix_Descending = " ▲";
        const string SortedColumns_SessionKey = "ProductsReport_SortedColumns";

        private static List<GroupField> _sortedColumns = null;

        public static List<GroupField> SortedColumns {
            get {
                if (_sortedColumns == null) {
                    _sortedColumns = (List<GroupField>) HttpContext.Current.Session[SortedColumns_SessionKey];
                    if (_sortedColumns == null) {
                        _sortedColumns = new List<GroupField>();
                        HttpContext.Current.Session[SortedColumns_SessionKey] = _sortedColumns;
                    }
                }
                return _sortedColumns;
            }
        }

        public ProductsReport() {
            InitializeComponent();
        }

        public static void SortBy(string fieldName, bool isAdding) {
            if (isAdding) {
                SortedColumns.ForEach(sortField => {
                    if (sortField.FieldName == fieldName) {
                        sortField.SortOrder = (sortField.SortOrder == XRColumnSortOrder.Ascending) ? XRColumnSortOrder.Descending : XRColumnSortOrder.Ascending;
                        return;
                    }
                });
            }
            else {
                if (SortedColumns.Count == 1 && SortedColumns[0].FieldName == fieldName) {
                    SortedColumns[0].SortOrder = (SortedColumns[0].SortOrder == XRColumnSortOrder.Ascending) ? XRColumnSortOrder.Descending : XRColumnSortOrder.Ascending;
                }
                else {
                    SortedColumns.Clear();
                }
            }
            SortedColumns.Add(new GroupField(fieldName, XRColumnSortOrder.Ascending));
        }

        private void ProductsReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
            Detail.SortFields.Clear();
            Detail.SortFields.AddRange(SortedColumns.ToArray());
        }

        private void HeaderCell_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
            XRLabel headerCell = sender as XRLabel;
            string fieldName = (string) headerCell.Tag;
            GroupField sort = SortedColumns.Find(sortField => sortField.FieldName == fieldName);

            headerCell.Text = headerCell.Text.Replace(SortedColumnSuffix_Ascending, "");
            headerCell.Text = headerCell.Text.Replace(SortedColumnSuffix_Descending, "");
            if (sort != null) {
                headerCell.Text += (sort.SortOrder == XRColumnSortOrder.Ascending)
                    ? SortedColumnSuffix_Ascending
                    : SortedColumnSuffix_Descending;
            }
        }

        private void HeaderCell_HtmlItemCreated(object sender, HtmlEventArgs e) {
            e.ContentCell.Attributes.Add("onclick", String.Format("parent.ProductsReport_HeaderClick(this, event, '{0}')", e.Brick.Value));
            e.ContentCell.Style.Add("cursor", "pointer");
        }   
    }
}
