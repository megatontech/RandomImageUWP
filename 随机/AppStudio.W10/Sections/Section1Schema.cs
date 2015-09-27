using System;
using AppStudio.DataProviders;

namespace AppStudio.Sections
{
    /// <summary>
    /// Implementation of the Section1Schema class.
    /// </summary>
    public class Section1Schema : SchemaBase
    {

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
