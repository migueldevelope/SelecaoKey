using System;
using System.Collections.Generic;
using System.Text;
using SelecaoKey.Core.Business;
using SelecaoKey.Core.Interfaces;
using SelecaoKey.Data;
using SelecaoKey.Views.BusinessCrud;
using System.Linq;
using SelecaoKey.Views.BusinessList;
using Tools;

namespace SelecaoKey.Services.Business
{
    public class ServiceStreaming : IServiceStreaming
    {
        private readonly Repository<Streaming> service;

        #region constructor
        public ServiceStreaming(DataContext context)
        {
            service = new Repository<Streaming>(context);
        }
        #endregion

        #region crud
        public string Delete(int id)
        {
            try
            {
                service.Delete(id);
                return "Streaming01";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ViewCrudStreaming Get(int id)
        {
            try
            {
                return service.GetByID(id).GetViewCrud();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<ViewListStreaming> List(int pageSize, int page, string filter)
        {
            try
            {
                return service.Get(p => p.Name.ToUpper().Contains(filter.ToUpper())).Select(p => p.GetViewList())
                  .OrderBy(o => o.Name).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string New(ViewCrudStreaming view)
        {
            try
            {
                if (string.IsNullOrEmpty(view.Name))
                {
                    throw new Exception("Streaming02");
                }
                service.Insert(new Streaming()
                {
                    Name = view.Name
                });
                return "Streaming04";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string Update(ViewCrudStreaming view)
        {
            try
            {
                if (string.IsNullOrEmpty(view.Name))
                {
                    throw new Exception("Streaming02");
                }
                Streaming model = service.GetByID(view.Id);
                if (model == null)
                {
                    throw new Exception("Streaming03");
                }
                service.Update(model);
                return "Streaming05";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}
