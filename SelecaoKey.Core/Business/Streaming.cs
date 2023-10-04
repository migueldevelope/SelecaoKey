using SelecaoKey.Core.Base;
using SelecaoKey.Views.BusinessCrud;
using SelecaoKey.Views.BusinessList;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelecaoKey.Core.Business
{

    [Table("Streaming")]
    public class Streaming : BaseEntity
    {
        public string Name { get; set; }

        public ViewListStreaming GetViewList()
        {
            return new ViewListStreaming()
            {
                Id = Id,
                Name = Name
            };
        }

        public ViewCrudStreaming GetViewCrud()
        {
            return new ViewCrudStreaming()
            {
                Id = Id,
                Name = Name
            };
        }

    }
}
