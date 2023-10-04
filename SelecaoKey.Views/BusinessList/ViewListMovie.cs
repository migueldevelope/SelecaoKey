
using System;
using System.Collections.Generic;

namespace SelecaoKey.Views.BusinessList
{
    public class ViewListMovie : ViewBase
    {
        public string Name { get; set; }
        public string Release { get; set; }

        public ICollection<ViewListRating> Ratings { get; set; }
    }
}
