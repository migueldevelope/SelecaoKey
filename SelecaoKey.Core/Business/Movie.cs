using SelecaoKey.Core.Base;
using SelecaoKey.Views.BusinessCrud;
using SelecaoKey.Views.BusinessList;
using SelecaoKey.Views.Enumns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SelecaoKey.Core.Business
{
    [Table("Movie")]
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public int IdStreaming { get; set; }
        public EnumGenre Genre { get; set; }
        public DateTime? Release { get; set; }

        // [ForeignKey("idMovie")]
        public ICollection<Rating> Ratings { get; set; }

        public ViewListMovie GetViewList()
        {
            return new ViewListMovie()
            {
                Id = Id,
                Name = Name,
                Release = Release == null ? "" : Release.Value.ToString("MM/yyyy"),
                Ratings = Ratings?.Select(p => p.GetViewList())?.ToList()
            };
        }

        public ViewCrudMovie GetViewCrud()
        {
            return new ViewCrudMovie()
            {
                Id = Id,
                Name = Name,
                Release = Release,
                Genre = Genre,
                IdStreaming = IdStreaming
            };
        }

    }
}
