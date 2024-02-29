using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Missile.Data;

public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
{
    public StoreContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<StoreContext>();

        optionBuilder.UseSqlite("Data Source=../Registrar.sqlite");

        return new StoreContext(optionBuilder.Options);
    }
}