using Flare.Data.Entities;

namespace Flare.Service
{
    public interface IRepository<T>
    {
        T Add(T model);
        T GetById(Guid id);
        List<ReviewModel> GetReviewsByListing(Guid id);
        List<ListingModel> GetListingByCategory(string categoryName);
        IEnumerable<T> GetAll();
        T Update(T model);
        void Delete(Guid id);
        void SaveChanges();
    }
}
