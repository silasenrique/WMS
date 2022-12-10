using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using WMS.Domain.Common.Models;
using WMS.Persistence.Configuration;

namespace WMS.Persistence.Common.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;

    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<ErrorOr<int>> SaveChangesAsync(CancellationToken cancellationToken)
    {
        TrackCreateRecords();
        TrackUpdateRecords();

        int affectedTransactions = 0;

        try
        {
            affectedTransactions = await _context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException v) when (v.InnerException is PostgresException postgresCodes)
        {
            switch (postgresCodes.SqlState)
            {
                case PostgresErrorCodes.UniqueViolation: return Error.Conflict("UniqueDatabaseViolation", postgresCodes.MessageText);
                default: throw;
            }
        }

        return affectedTransactions;
    }

    private void TrackCreateRecords()
    {
        var insertRecords = _context.ChangeTracker
            .Entries<IAudit>().Where(x => x.State == EntityState.Added);

        foreach (var insertRecord in insertRecords)
        {
            insertRecord.Property(r => r.DateCreated).CurrentValue = DateTime.Now;
            insertRecord.Property(r => r.DateUpdated).CurrentValue = DateTime.Now;
        }
    }

    private void TrackUpdateRecords()
    {
        var insertRecords = _context.ChangeTracker
            .Entries<IAudit>().Where(x => x.State == EntityState.Modified);

        foreach (var insertRecord in insertRecords)
        {
            insertRecord.Property(r => r.DateUpdated).CurrentValue = DateTime.Now;
        }
    }
}