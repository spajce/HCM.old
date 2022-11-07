using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class Tag
    {
        public int IdTag { get; set; }
        public string? TagName { get; set; }
        /// <summary>
        /// Employee
        /// </summary>
        public string? TagType { get; set; }
    }
}
