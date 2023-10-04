using SelecaoKey.Core.Base;
using SelecaoKey.Views.BusinessCrud;
using SelecaoKey.Views.BusinessList;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace SelecaoKey.Core.Business
{
    [Table("Rating")]
    public class Rating : BaseEntity
    {
        public int? IdUser { get; set; }
       
        public int? IdMovie { get; set; }
        public int Score { get; set; }
        
        public string Comments { get; set; }

        public ViewListRating GetViewList()
        {
            return new ViewListRating()
            {
                Id = Id,
                IdMovie = IdMovie,
                IdUser = IdUser,
                Score = Score,
                Comments = Comments
            };
        }

        public ViewCrudRating GetViewCrud()
        {
            return new ViewCrudRating()
            {
                Id = Id,
                IdMovie = IdMovie,
                IdUser = IdUser,
                Score = Score,
                Comments = Comments
            };
        }

    }
}
