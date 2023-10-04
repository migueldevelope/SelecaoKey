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
    public class ServiceMovieStreaming : IServiceMovieStreaming
    {
        private readonly Repository<MovieStreaming> service;
        
        #region constructor
        public ServiceMovieStreaming(DataContext context)
        {
            service = new Repository<MovieStreaming>(context);
        }

        #endregion

        #region crud
        public string Delete(int id)
        {
            try
            {
                service.Delete(id);
                return "MovieStreaming01";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ViewCrudMovieStreaming Get(int id)
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


        public List<ViewListMovieStreaming> List(int pageSize, int page, string filter)
        {
            try
            {
                return service.Get(p => p.Id.ToString().ToUpper().Contains(filter.ToUpper())).Select(p => p.GetViewList())
                  .OrderBy(o => o.Id).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public string New(ViewCrudMovieStreaming view)
        {
            try
            {
                service.Insert(new MovieStreaming()
                {
                    IdStreaming = view.IdStreaming,
                    IdMovie = view.IdMovie

                });
                return "MovieStreaming04";
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public string Update(ViewCrudMovieStreaming view)
        {
            try
            {
                MovieStreaming model = service.GetByID(view.Id);
                if (model == null)
                {
                    throw new Exception("MovieStreaming03");
                }
                service.Update(model);
                return "MovieStreaming05";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}
