using Flare.Data.Entities;
using Flare.Repo;
using Microsoft.EntityFrameworkCore;

namespace Flare.Service
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly AppDBContext _appDBContext;
        private DbSet<T> entities { get; set; }
        private DbSet<ReviewModel> review { get; set; }
        private DbSet<ListingModel> listing { get; set; }

        public Repository(AppDBContext appDBcontext)
        {
            this._appDBContext = appDBcontext;
            entities = appDBcontext.Set<T>();
            review = appDBcontext.Set<ReviewModel>();
            listing = appDBcontext.Set<ListingModel>();
        }

        public T Add(T model)
        {
            model.Id = Guid.NewGuid();
            model.CreatedAt = DateTime.Now;
            model.Modified = DateTime.Now;
            entities.Add(model);
            SaveChanges();
            return model;
        }

        public void Delete(Guid id)
        {
            var model = GetById(id);
            if (model != null)
            {
                entities.Remove(model);
            }
            SaveChanges();

        }

        public List<ReviewModel> GetReviewsByListing(Guid id)
        {
           
            var result = review.Where(x => x.ListingRefId == id).ToList();
            return result;
           // return entities.FirstOrDefault<T>((x) => x.Id == model.Id)!;

        }
        public List<ListingModel> GetListingByCategory(string categoryName)
        {

            var result = listing.Where(x => x.Category == categoryName).ToList();
            return result;
            // return entities.FirstOrDefault<T>((x) => x.Id == model.Id)!;

        }

        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public T GetById(Guid id)
        {
            return entities.FirstOrDefault(x => x.Id == id)!;
        }

        public T Update(T model)
        {
            if (model != null)
            {
                model.Modified = DateTime.Now;
                entities.Update(model);
                SaveChanges();

            }
            return model!;
        }
        public void SaveChanges()
        {
            _appDBContext.SaveChanges();
        }
    }
}