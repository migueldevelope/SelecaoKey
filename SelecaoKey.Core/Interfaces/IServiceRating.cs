using System.Collections.Generic;
using SelecaoKey.Views.BusinessCrud;
using SelecaoKey.Views.BusinessList;

namespace SelecaoKey.Core.Interfaces
{
    public interface IServiceRating
    {
        public string New(ViewCrudRating view);
        public string Update(ViewCrudRating view);
        public ViewCrudRating Get(int id);
        public List<ViewListRating> List(int pageSize, int page, string filter);
        public string Delete(int id);
    }
}
