using System.Collections.Generic;
using SelecaoKey.Views.BusinessCrud;
using SelecaoKey.Views.BusinessList;

namespace SelecaoKey.Core.Interfaces
{
    public interface IServiceStreaming
    {
        public string New(ViewCrudStreaming view);
        public string Update(ViewCrudStreaming view);
        public ViewCrudStreaming Get(int id);
        public List<ViewListStreaming> List(int pageSize, int page, string filter);
        public string Delete(int id);
    }
}
