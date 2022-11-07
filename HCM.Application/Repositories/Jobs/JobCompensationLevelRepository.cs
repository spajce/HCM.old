namespace HCM.Application.Repositories.Jobs;

public interface IJobCompensationLevelRepository
{
    //JobCompensationLevelRepository InitDbContext(HCMDbContext context);
    Task<int> PostAsync(JobCompensationLevelDto o);
    Task PutAsync(int id, JobCompensationLevelDto o);
    Task RemoveAsync(int id);
    JobCompensationLevel InitEntity(JobCompensationLevelDto o);
    IQueryable<JobCompensationLevelDto> GetJobCompensationLevels();

}

public class JobCompensationLevelRepository : IJobCompensationLevelRepository
{
    private readonly HCMDbContext _context;
    private readonly IAuditRepository _auditRepository;
    private readonly AuditX _audit;
    private readonly IMapper _mapper;

    public JobCompensationLevelRepository(HCMDbContext context,
        IAuditRepository auditRepository, IMapper mapper)
    {
        _context = context;
        _auditRepository = auditRepository;
        _audit = _auditRepository.Audit;
        _mapper = mapper;
    }

    //public JobCompensationLevelRepository InitDbContext(HCMDbContext context)
    //{
    //    _context = context;
    //    return this;
    //}

    public JobCompensationLevel InitEntity(JobCompensationLevelDto o)
    {
        var o1 = _mapper.Map<JobCompensationLevelDto, JobCompensationLevel>(o);
        return o1;
    }

    public async Task<int> PostAsync(JobCompensationLevelDto o)
    {
        var o1 = InitEntity(o);
        await _context.AddAsync(o1);
        await _context.SaveChangesAsync(_audit);
        return o1.IdJobCompensationLevel;
    }

    public async Task PutAsync(int id, JobCompensationLevelDto o)
    {
        var o1 = InitEntity(o);

        var o2 = await _context.JobCompensationLevels.FindAsync(id);

        if (o2 == null)
            throw new NullReferenceException(id.ToString());

        var entry = _context.Entry(o2);
        entry.CurrentValues.SetValues(o1);
        entry.State = EntityState.Modified;
        await _context.SaveChangesAsync(_audit);
    }

    public async Task RemoveAsync(int id)
    {
        var o = await _context.JobCompensationLevels.FindAsync(id);
        if (o == null)
            throw new NullReferenceException(id.ToString());
        _context.JobCompensationLevels.Attach(o);
        _context.JobCompensationLevels.Remove(o);
        await _context.SaveChangesAsync(_audit);
    }

    public IQueryable<JobCompensationLevelDto> GetJobCompensationLevels()
    {
        var q = (from o in _context.JobCompensationLevels
                 select o)
                 .AsNoTracking()
                 .ProjectTo<JobCompensationLevelDto>(_mapper.ConfigurationProvider);
        return q;
    }
}
