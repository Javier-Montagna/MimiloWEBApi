using Microsoft.EntityFrameworkCore;

namespace Mimilo.Database
{
    public static class TableCleaner
    {
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
}