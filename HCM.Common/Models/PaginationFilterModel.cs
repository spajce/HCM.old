using System;
using System.Collections.Generic;

namespace HCM.Common.Models
{
    public partial class PaginationFilterModel : BaseFilterModel
    {
        /// <summary>
        /// Default: 1
        /// </summary>
        public int PageNumber { get; set; } = 1;
        /// <summary>
        /// Default: 15
        /// </summary>
        public int PageSize { get; set; } = 15;
        /// <summary>
        /// If null, the system will get the primary column name by default
        /// </summary>
        public string OrderBy { get; set; }
        /// <summary>
        /// Default: Ascending
        /// Option: Descending
        /// </summary>
        public string SortDirection { get; set; } = "Ascending";

        public override string ToString() => $"PageNumber:{PageNumber},PageSize:{PageSize},OrderBy:{OrderBy},SortDirection:{SortDirection},Keyword:{Keyword}";
    }

    public class BaseFilterModel
    {
        public Search AdvancedSearch { get; set; }

        public string Keyword { get; set; } = string.Empty;
    }

    public partial class Search
    {
        public List<string> Fields { get; set; } = new List<string>();
        public string Keyword { get; set; } = string.Empty;
    }
}
