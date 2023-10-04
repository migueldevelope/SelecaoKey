
using System;

namespace SelecaoKey.Views.BusinessList
{
    public class ViewListRating : ViewBase
    {
        public int IdUser { get; set; }
        public int IdMovie { get; set; }
        public int Score { get; set; }
        public string Comments { get; set; }
    }
}
