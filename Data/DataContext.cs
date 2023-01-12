using Microsoft.EntityFrameworkCore;

namespace EFAPIRelationships.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

    }
}
