using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud.NorthW.App.SWApi.MVC.Models
{
    public class PeopleListView
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<PeopleView> results { get; set; }
    }
}