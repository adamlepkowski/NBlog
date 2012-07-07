﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NBlog.Web.Application;
using NBlog.Web.Application.Infrastructure;

namespace NBlog.Web.Controllers
{
    public partial class HomeController
    {
        public class IndexModel : LayoutModel
        {
            public IEnumerable<EntrySummaryModel> Entries { get; set; }
            public PageList Pagging { get; set; }
        }

        public class EntrySummaryModel
        {
            public string Key { get; set; }
            public string Title { get; set; }
            public string Date{ get; set; }
            public string PrettyDate { get; set; }
            public bool IsPublished { get; set; }
        }

        public class PageList
        {
            public PageList(int currentPage, int rowsAmount, int pageAmount)
            {
                CurrentPage = currentPage;
                RowsAmount = rowsAmount;
                PageAmount = pageAmount;
            }

            public int CurrentPage { get; set; }
            public int RowsAmount { get; set; }
            public int PageAmount { get; set; }
        }
    }
}