using SelecaoKey.Core.Base;
using SelecaoKey.Views.BusinessCrud;
using SelecaoKey.Views.BusinessList;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelecaoKey.Core.Business
{
    [Table("Movie")]
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public int IdStreaming { get; set; }
        public int Genre { get; set; }
        public DateTime? Release { get; set; }

        public ViewListMovie GetViewList()
        {
            return new ViewListMovie()
            {
                Id = Id,
                Name = Name
            };
        }

        public ViewCrudMovie GetViewCrud()
        {
            return new ViewCrudMovie()
            {
                Id = Id,
                Name = Name,
                Release = Release == null ? "" : Release.Value.ToString("MM/yyyy"),
                Genre = Genre,
                IdStreaming = IdStreaming
            };
        }

    }
}
