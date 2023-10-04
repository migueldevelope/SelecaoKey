using System;

namespace SelecaoKey.Views.BusinessCrud
{
    public class ViewCrudMovie : ViewBase
    {
        public string Name { get; set; }
        public int IdStreaming { get; set; }
        public int Genre { get; set; }
        public DateTime? Release { get; set; }
    }
}
