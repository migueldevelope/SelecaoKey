using SelecaoKey.Core.Base;
using SelecaoKey.Views.BusinessCrud;
using SelecaoKey.Views.BusinessList;
using SelecaoKey.Views.Enumns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SelecaoKey.Core.Business
{
    [Table("MovieStreaming")]
    public class MovieStreaming : BaseEntity
    {
        public int IdStreaming { get; set; }
        public int IdMovie { get; set; }        
        public ViewListMovieStreaming GetViewList()
        {
            return new ViewListMovieStreaming()
            {
                Id = Id,
                IdStreaming = IdStreaming,
                IdMovie = IdMovie
            };
        }

        public ViewCrudMovieStreaming GetViewCrud()
        {
            return new ViewCrudMovieStreaming()
            {
                Id = Id,
                IdMovie = IdMovie,
                IdStreaming = IdStreaming
            };
        }

    }
}
