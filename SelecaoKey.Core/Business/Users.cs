using SelecaoKey.Core.Base;
using SelecaoKey.Views.BusinessCrud;
using SelecaoKey.Views.BusinessList;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelecaoKey.Core.Business
{

    [Table("Users")]
    public class Users : BaseEntity
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        public ViewListUser GetViewList()
        {
            return new ViewListUser()
            {
                Id = Id,
                Name = Name
            };
        }

        public ViewCrudUser GetViewCrud()
        {
            return new ViewCrudUser()
            {
                Id = Id,
                Name = Name,
                Mail = Mail
            };
        }

    }
}
