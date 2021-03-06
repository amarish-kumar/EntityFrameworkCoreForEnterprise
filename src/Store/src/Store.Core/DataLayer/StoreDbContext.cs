using Microsoft.EntityFrameworkCore;
using Store.Core.DataLayer.Mapping;

namespace Store.Core.DataLayer
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options, IEntityMapper entityMapper)
            : base(options)
        {
            EntityMapper = entityMapper;
        }

        public IEntityMapper EntityMapper { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Load all mappings for entities
            EntityMapper.MapEntities(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
