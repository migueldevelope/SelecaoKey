﻿using System;
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
    public class ServiceRating : IServiceRating
    {
        private readonly Repository<Rating> service;

        #region constructor
        public ServiceRating(DataContext context)
        {
            service = new Repository<Rating>(context);
        }
        #endregion

        #region crud
        public string Delete(int id)
        {
            try
            {
                service.Delete(id);
                return "Rating01";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ViewCrudRating Get(int id)
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

        public List<ViewListRating> List(int pageSize, int page, string filter)
        {
            try
            {
                return service.Get(p => p.Comments.ToUpper().Contains(filter.ToUpper())).Select(p => p.GetViewList())
                  .OrderBy(o => o.Comments).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string New(ViewCrudRating view)
        {
            try
            {
                if (view.IdUser == null)
                {
                    throw new Exception("Rating02");
                }
                if (view.IdMovie == null)
                {
                    throw new Exception("Rating03");
                }
                if ((view.Score < 1)|| (view.Score > 5))
                {
                    throw new Exception("Rating04");
                }
                service.Insert(new Rating()
                {
                    Comments = view.Comments,
                    IdMovie = view.IdMovie,
                    IdUser = view.IdUser,
                    Score = view.Score
                });
                return "Rating05";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string Update(ViewCrudRating view)
        {
            try
            {

                if (view.IdUser == null)
                {
                    throw new Exception("Rating02");
                }
                if (view.IdMovie == null)
                {
                    throw new Exception("Rating03");
                }
                if ((view.Score < 1) || (view.Score > 5))
                {
                    throw new Exception("Rating04");
                }
                Rating model = service.GetByID(view.Id);
                if (model == null)
                {
                    throw new Exception("Rating06");
                }
                service.Update(model);
                return "Rating07";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}
