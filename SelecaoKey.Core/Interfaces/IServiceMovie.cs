using System.Collections.Generic;
using SelecaoKey.Views.BusinessCrud;
using SelecaoKey.Views.BusinessList;

namespace SelecaoKey.Core.Interfaces
{
    public interface IServiceMovie
    {
        public string New(ViewCrudMovie view);
        public string Update(ViewCrudMovie view);
        public ViewCrudMovie Get(int id);
        public List<ViewListMovie> List(int pageSize, int page, string filter);
        public string Delete(int id);
        public List<ViewListAverageMovieRating> AverageMovieRatings();
        public List<ViewListMovieRealease> MovieRealeases();
        public List<ViewListQuantityMovieStreamings> QuantityMovieStreamings();
        public List<ViewListMovie> ListFilterCommentsScore(int pageSize, int page, string commets, int score);

    }
}
