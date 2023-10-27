using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.CompanyContext.BookEntryRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;
using OnlineMuhasebeServer.Persistance.Context;

namespace OnlineMuhasebeServer.Persistance.Services.CompanyService;

public class BookEntryService : IBookEntryService
{
    private CompanyDbContext _context;
    private readonly IContextService _contextService;
    private readonly IBookEntryCommandRepository _bookEntryCommandRepository;
    private readonly IBookEntryQueryRepository _bookEntryQueryRepository;
    private readonly ICompanyDbUnitOfWork _companyDbUnitOfWork;

    public BookEntryService(ICompanyDbUnitOfWork companyDbUnitOfWork, IBookEntryQueryRepository bookEntryQueryRepository, IBookEntryCommandRepository bookEntryCommandRepository, IContextService contextService)
    {
        _companyDbUnitOfWork = companyDbUnitOfWork;
        _bookEntryQueryRepository = bookEntryQueryRepository;
        _bookEntryCommandRepository = bookEntryCommandRepository;
        _contextService = contextService;
    }

    public async Task AddAsync(string companyId, BookEntry bookEntry, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _bookEntryCommandRepository.SetDbContexInstance(_context);
        _companyDbUnitOfWork.SetDbContexInstance(_context);

        await _bookEntryCommandRepository.AddAsync(bookEntry, cancellationToken);
        await _companyDbUnitOfWork.SaveChangesAsync();
    }

    public async Task<string> GetNewBookEntryNumber(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _bookEntryQueryRepository.SetDbContexInstance(_context);

        BookEntry lastbookEntry = await _bookEntryQueryRepository.GetAll().OrderByDescending(x => x.CreatedDate).FirstOrDefaultAsync();

        if (lastbookEntry is null)
        {
            return "0000000000000001";
        }

        long lastbookEntryNumber = Convert.ToInt64(lastbookEntry.BookEntryNumber);
        lastbookEntryNumber++;
        string newBookEntryNumber = lastbookEntryNumber.ToString();

        for (int i = newBookEntryNumber.Length; i < 16; i++)
        {
            newBookEntryNumber = "0" + newBookEntryNumber;
        }
        return newBookEntryNumber;
    }

    public async Task<PaginationResult<BookEntry>> GetAllAsync(string companyId, int pageNumber, int pageSize)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _bookEntryQueryRepository.SetDbContexInstance(_context);

        return await _bookEntryQueryRepository.GetAll(false).OrderByDescending(x=>x.Date).ToPagedListAsync(pageNumber,pageSize);
    }

    public int GetCount(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _bookEntryQueryRepository.SetDbContexInstance(_context);

        return _bookEntryQueryRepository.GetAll().Count();
    }
}
