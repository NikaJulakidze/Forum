using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Models
{
    public class PagingSettings
    {
        public PagingSettings(int CurrentPage,int PerPage)
        {
            this.CurrentPage = CurrentPage;
            this.PerPage = PerPage;
        }

        public int CurrentPage { get; set; }
        public int PerPage { get; set; }
        public int TotalPage { get; set; }
        public int PageCount { get; set; }

        public static PagingSettings CreateSettings(int CurrentPage,int Perpage) => new PagingSettings(CurrentPage,Perpage) {CurrentPage=CurrentPage,PerPage=Perpage };
    }
}
