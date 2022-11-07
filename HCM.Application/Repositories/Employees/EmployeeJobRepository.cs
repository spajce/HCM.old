namespace HCM.Application.Repositories.EmployeeJobs;

public interface IEmployeeJobRepository
{
    //EmployeeJobRepository InitDbContext(HCMDbContext context);
    Task<int> PostAsync(EmployeeJobDto o);
    Task PutAsync(int id, EmployeeJobDto o);
    Task RemoveAsync(int id);
    EmployeeJob InitEntity(EmployeeJobDto o);
    IQueryable<EmployeeJobDto> GetEmployeeJobs(int idEmployee);

}

public class EmployeeJobRepository : IEmployeeJobRepository
{
    private readonly HCMDbContext _context;
    private readonly IAuditRepository _auditRepository;
    private readonly AuditX _audit;
    private readonly IMapper _mapper;

    public EmployeeJobRepository(HCMDbContext context,
        IAuditRepository auditRepository, IMapper mapper)
    {
        _context = context;
        _auditRepository = auditRepository;
        _audit = _auditRepository.Audit;
        _mapper = mapper;
    }

    //public EmployeeJobRepository InitDbContext(HCMDbContext context)
    //{
    //    _context = context;
    //    return this;
    //}

    public EmployeeJob InitEntity(EmployeeJobDto o)
    {
        var o1 = _mapper.Map<EmployeeJobDto, EmployeeJob>(o);
        return o1;
    }

    public async Task<int> PostAsync(EmployeeJobDto o)
    {
        o.CreateBy = _audit.CreatedBy;
        o.CreateAt = DateTime.Now;

        var o1 = InitEntity(o);
        await _context.AddAsync(o1);
        await _context.SaveChangesAsync(_audit);
        return o1.IdEmployeeJob;
    }

    public async Task PutAsync(int id, EmployeeJobDto o)
    {
        o.UpdateBy = _audit.CreatedBy;
        o.UpdateAt = DateTime.Now;

        var o1 = InitEntity(o);

        var o2 = await _context.EmployeeJobs.FindAsync(id);

        if (o2 == null)
            throw new NullReferenceException(id.ToString());

        o1.CreateBy = o2.CreateBy;
        o1.CreateAt = o2.CreateAt;

        var entry = _context.Entry(o2);
        entry.CurrentValues.SetValues(o1);
        entry.State = EntityState.Modified;
        await _context.SaveChangesAsync(_audit);
    }

    public async Task RemoveAsync(int id)
    {
        var o = await _context.EmployeeJobs.FindAsync(id);
        if (o == null)
            throw new NullReferenceException(id.ToString());
        _context.EmployeeJobs.Attach(o);
        _context.EmployeeJobs.Remove(o);
        await _context.SaveChangesAsync(_audit);
    }

    public IQueryable<EmployeeJobDto> GetEmployeeJobs()
    {
        var q = (from o in _context.EmployeeJobs
                 select o)
                 .Take(100)
                 .AsNoTracking()
                 .ProjectTo<EmployeeJobDto>(_mapper.ConfigurationProvider);
        return q;
    }

    public IQueryable<EmployeeJobDto> GetEmployeeJobs(int idEmployee)
    {
        var q = (from o in _context.EmployeeJobs
                 where o.IdEmployee == idEmployee
                 select o)
                 .AsNoTracking()
                 .ProjectTo<EmployeeJobDto>(_mapper.ConfigurationProvider);
        return q;
    }
}
