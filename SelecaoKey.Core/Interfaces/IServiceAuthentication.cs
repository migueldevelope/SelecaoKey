using SelecaoKey.Views.BusinessCrud;
using SelecaoKey.Views.BusinessList;

namespace SelecaoKey.Core.Interfaces
{
    public interface IServiceAuthentication
    {
        ViewListAuthentication Auth(ViewAuthentication view);
    }
}
