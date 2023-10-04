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
using System.Security.Cryptography;

namespace SelecaoKey.Services.Business
{
    public class ServiceMovie : IServiceMovie
    {
        private readonly Repository<Movie> service;
        private readonly Repository<Rating> serviceRating;
        private readonly Repository<MovieStreaming> serviceMovieStreaming;

        #region constructor
        public ServiceMovie(DataContext context)
        {
            service = new Repository<Movie>(context);
            serviceRating = new Repository<Rating>(context);
            serviceMovieStreaming = new Repository<MovieStreaming>(context);
        }

        public List<ViewListAverageMovieRating> AverageMovieRatings()
        {
            var ratings = serviceRating.Get();
            var list = service.Get().Select(p => new ViewListAverageMovieRating()
            {
                Movie = p.Name,
                Rating = ratings.Where(c => c.IdMovie == p.Id).Count() == 0 ? 0 : (int)Math.Round(ratings.Where(c => c.IdMovie == p.Id).Average(p => p.Score), 0)
            }).ToList();

            return list;
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

        public List<ViewListMovie> ListFilterCommentsScore(int pageSize, int page, string commets, int score)
        {
            var ids = serviceRating.Get(p => p.Comments.ToUpper().Contains(commets.ToUpper())).Select(p => p.GetViewList())
                 .OrderBy(o => o.Score).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            if (score > 0)
            {
                ids = ids.Where(p => p.Score == score).ToList();
            }
            return service.Get().Where(p => ids.Select(c => c.Id).Contains(p.Id)).Select(p => p.GetViewList()).ToList();
        }

        public List<ViewListMovieRealease> MovieRealeases()
        {
            var list = (from mov in service.Get()
                        group mov by mov.Release.Value.Year into movs
                        select new ViewListMovieRealease()
                        {
                            Year = movs.Key,
                            Quantity = movs.Count(),
                            Movies = movs.Select(p => p.Name).ToList()
                        }).ToList();

            return list;

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
                    Release = view.Release

                });
                return "Movie04";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<ViewListQuantityMovieStreamings> QuantityMovieStreamings()
        {
            var list = (from mov in service.Get()
                        from movStream in serviceMovieStreaming.Get(p => p.IdMovie == mov.Id)
                        group mov by mov.Name into grpMov
                        select new ViewListQuantityMovieStreamings()
                        {
                            Movie = grpMov.Key,
                            Quantity = grpMov.Count()
                        }).ToList();
            return list;
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
                    throw new Exception("Movie03");
                }
                service.Update(model);
                return "Movie05";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}
