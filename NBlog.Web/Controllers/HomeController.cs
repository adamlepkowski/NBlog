using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NBlog.Web.Application;
using NBlog.Web.Application.Infrastructure;
using NBlog.Web.Application.QueryObject;
using NBlog.Web.Application.Service;
using NBlog.Web.Application.Service.Entity;
using NBlog.Web.Controllers.Adapters;

namespace NBlog.Web.Controllers
{
    public partial class HomeController : LayoutController
    {
        public HomeController(IServices services) : base(services) { }

        [HttpGet]
        public ViewResult Index(int pageId = 1)
        {
            var entries = Services.Entry.GetList().OrderByDescending(e => e.DateCreated);

            IEnumerable<Entry> mainEntryList;
            PageList mainPageList = null;

            if (Services.Config.Current.IsPagingEnabled)
            {
                IEnumerable<Entry> list = entries;
                if (!Services.User.Current.IsAdmin)
                    list = entries.Where(x => x.IsPublished ?? true);
                int amount = list.Count();
                list = PaggingQuery<Entry>.ToPageList(list, Services.Config.Current.PageAmount, pageId);

                mainEntryList = list;
                mainPageList = new PageList(pageId, amount, Services.Config.Current.PageAmount);
            }
            else
            {
                mainEntryList = entries;
            }

            var model = new IndexModel()
                            {
                                Entries = mainEntryList.Select(EntrySummaryModelAdapter.Convert),
                                Pagging = mainPageList
                            };

            return View(model);
        }

        [HttpGet]
        public ViewResult Throw()
        {
            throw new NotImplementedException("Example exception for testing error handling.");
        }

        [HttpGet]
        public ActionResult WhoAmI()
        {
            return Content(User.Identity.Name.AsNullIfEmpty() ?? "Not logged in");
        }

        [HttpGet]
        public ActionResult WhatTimeIsIt()
        {
            return Content(DateTime.Now.ToString());
        }
    }
}
