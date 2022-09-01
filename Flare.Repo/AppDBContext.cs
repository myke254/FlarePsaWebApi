using Flare.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flare.Repo
{
    public class AppDBContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }
        public DbSet<ListingModel>? ListingModel { get; set; }
        public DbSet<CategoryModel>? CategoryModel { get; set; }
        public DbSet<ReviewModel>? ReviewModel { get; set; }
        public DbSet<UserModel> UserModel { get; set; }
    }
}
