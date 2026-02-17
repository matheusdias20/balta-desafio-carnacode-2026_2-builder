using System;
using System.Collections.Generic;

namespace DesignPatternChallenge
{
    public class SalesReportBuilder
    {
        private SalesReport _report;

        public SalesReportBuilder()
        {
            _report = new SalesReport();
            // Initialize defaults
            _report.Columns = new List<string>();
            _report.Filters = new List<string>();
            _report.StartDate = DateTime.Now;
            _report.EndDate = DateTime.Now;
            _report.IncludeHeader = false;
            _report.IncludeFooter = false;
            _report.IncludeCharts = false;
            _report.IncludeSummary = false;
            _report.IncludeTotals = false;
            _report.IncludePageNumbers = false;
        }

        public SalesReportBuilder WithTitle(string title)
        {
            _report.Title = title;
            return this;
        }

        public SalesReportBuilder WithFormat(string format)
        {
            _report.Format = format;
            return this;
        }

        public SalesReportBuilder WithDateRange(DateTime startDate, DateTime endDate)
        {
            _report.StartDate = startDate;
            _report.EndDate = endDate;
            return this;
        }

        public SalesReportBuilder IncludeHeader(string headerText)
        {
            _report.IncludeHeader = true;
            _report.HeaderText = headerText;
            return this;
        }

        public SalesReportBuilder IncludeFooter(string footerText)
        {
            _report.IncludeFooter = true;
            _report.FooterText = footerText;
            return this;
        }

        public SalesReportBuilder IncludeCharts(string chartType)
        {
            _report.IncludeCharts = true;
            _report.ChartType = chartType;
            return this;
        }

        public SalesReportBuilder IncludeSummary()
        {
            _report.IncludeSummary = true;
            return this;
        }

        public SalesReportBuilder AddColumn(string column)
        {
            _report.Columns.Add(column);
            return this;
        }

        public SalesReportBuilder AddColumns(params string[] columns)
        {
            _report.Columns.AddRange(columns);
            return this;
        }

        public SalesReportBuilder AddFilter(string filter)
        {
            _report.Filters.Add(filter);
            return this;
        }

        public SalesReportBuilder SortBy(string sortBy)
        {
            _report.SortBy = sortBy;
            return this;
        }

        public SalesReportBuilder GroupBy(string groupBy)
        {
            _report.GroupBy = groupBy;
            return this;
        }

        public SalesReportBuilder IncludeTotals()
        {
            _report.IncludeTotals = true;
            return this;
        }

        public SalesReportBuilder SetOrientation(string orientation)
        {
            _report.Orientation = orientation;
            return this;
        }

        public SalesReportBuilder SetPageSize(string pageSize)
        {
            _report.PageSize = pageSize;
            return this;
        }

        public SalesReportBuilder IncludePageNumbers()
        {
            _report.IncludePageNumbers = true;
            return this;
        }

        public SalesReportBuilder SetCompanyLogo(string logoPath)
        {
            _report.CompanyLogo = logoPath;
            return this;
        }

        public SalesReportBuilder SetWaterMark(string watermark)
        {
            _report.WaterMark = watermark;
            return this;
        }

        public SalesReport Build()
        {
            // Validation logic can go here (e.g., Title is mandatory)
            if (string.IsNullOrEmpty(_report.Title))
            {
                // Assign a default or throw exception
                _report.Title = "Untitled Report";
            }
             if (string.IsNullOrEmpty(_report.Format))
            {
                // Assign a default or throw exception
                _report.Format = "PDF";
            }

            return _report;
        }
    }
}
