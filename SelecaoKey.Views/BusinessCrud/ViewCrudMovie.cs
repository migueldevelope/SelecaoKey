using SelecaoKey.Views.Enumns;
using System;

namespace SelecaoKey.Views.BusinessCrud
{
    public class ViewCrudMovie : ViewBase
    {
        public string Name { get; set; }
        public int IdStreaming { get; set; }
        public EnumGenre Genre { get; set; }
        public DateTime? Release { get; set; }

    }
}
