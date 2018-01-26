using Portal.CMS.Entities.Entities;
using System.Collections.Generic;

namespace Portal.CMS.Web.Areas.PageBuilder.ViewModels.Section
{
    public class AddViewModel
    {
        public int PageId { get; set; }

        public IEnumerable<PageSectionType> SectionTypeList { get; set; }
    }
}