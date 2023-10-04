using System.Collections.Generic;
using SelecaoKey.Views.BusinessCrud;
using SelecaoKey.Views.BusinessList;

namespace SelecaoKey.Core.Interfaces
{
    public interface IServiceMovieStreaming
    {
        public string New(ViewCrudMovieStreaming view);
        public string Update(ViewCrudMovieStreaming view);
        public ViewCrudMovieStreaming Get(int id);
        public List<ViewListMovieStreaming> List(int pageSize, int page, string filter);
        public string Delete(int id);

    }
}
