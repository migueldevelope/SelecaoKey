
using System;

namespace SelecaoKey.Views.BusinessCrud
{
    public class ViewCrudRating : ViewBase
    {
        public int? IdUser { get; set; }
        public int? IdMovie { get; set; }
        public int Score { get; set; }
        public string Comments { get; set; }
    }
}
