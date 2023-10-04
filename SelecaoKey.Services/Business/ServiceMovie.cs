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
    public class ServiceMovie : IServiceMovie
    {
        private readonly Repository<Movie> service;

        #region constructor
        public ServiceMovie(DataContext context)
        {
            service = new Repository<Movie>(context);
        }
        #endregion

        #region crud
        public string Delete(int id)
        {
            try
            {
                service.Delete(id);
                return "Movie01";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ViewCrudMovie Get(int id)
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

        public List<ViewListMovie> List(int pageSize, int page, string filter)
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

        public string New(ViewCrudMovie view)
        {
            try
            {
                if (string.IsNullOrEmpty(view.Name))
                {
                    throw new Exception("Movie02");
                }
                service.Insert(new Movie()
                {
                    Name = view.Name,
                    Genre = view.Genre,
                    IdStreaming = view.IdStreaming,
                    Release = view.Release

                });
                return "Movie04";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string Update(ViewCrudMovie view)
        {
            try
            {
                if (string.IsNullOrEmpty(view.Name))
                {
                    throw new Exception("Movie02");
                }
                Movie model = service.GetByID(view.Id);
                if (model == null)
                {
                    throw new Exception("Movie05");
                }
                service.Update(model);
                return "Movie06";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}
