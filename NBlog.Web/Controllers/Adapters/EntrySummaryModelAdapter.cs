using NBlog.Web.Application.Infrastructure;
using NBlog.Web.Application.Service.Entity;

namespace NBlog.Web.Controllers.Adapters
{
    public static class EntrySummaryModelAdapter
    {
        public static HomeController.EntrySummaryModel Convert(Entry entry)
        {
            return new HomeController.EntrySummaryModel()
                       {
                           Key = entry.Slug,
                           Title = entry.Title,
                           Date = entry.DateCreated.ToDateString(),
                           PrettyDate = entry.DateCreated.ToPrettyDate(),
                           IsPublished = entry.IsPublished ?? true
                       };
        }
    }
}