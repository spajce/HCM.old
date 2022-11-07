namespace HCM.Application.Repositories.Jobs;

public interface IJobPositionRepository
{
    //JobPositionRepository InitDbContext(HCMDbContext context);
    Task<int> PostAsync(JobPositionDto o);
    Task PutAsync(int id, JobPositionDto o);
    Task RemoveAsync(int id);
    JobPosition InitEntity(JobPositionDto o);
    IQueryable<JobPositionDto> GetJobPositions();

}

public class JobPositionRepository : IJobPositionRepository
{
    private readonly HCMDbContext _context;
    private readonly IAuditRepository _auditRepository;
    private readonly AuditX _audit;
    private readonly IMapper _mapper;

    public JobPositionRepository(HCMDbContext context,
        IAuditRepository auditRepository, IMapper mapper)
    {
        _context = context;
        _auditRepository = auditRepository;
        _audit = _auditRepository.Audit;
        _mapper = mapper;
    }

    //public JobPositionRepository InitDbContext(HCMDbContext context)
    //{
    //    _context = context;
    //    return this;
    //}

    public JobPosition InitEntity(JobPositionDto o)
    {
        var o1 = _mapper.Map<JobPositionDto, JobPosition>(o);
        return o1;
    }

    public async Task<int> PostAsync(JobPositionDto o)
    {
        var o1 = InitEntity(o);
        await _context.AddAsync(o1);
        await _context.SaveChangesAsync(_audit);
        return o1.IdJobPosition;
    }

    public async Task PutAsync(int id, JobPositionDto o)
    {
        var o1 = InitEntity(o);

        var o2 = await _context.JobPositions.FindAsync(id);

        if (o2 == null)
            throw new NullReferenceException(id.ToString());

        var entry = _context.Entry(o2);
        entry.CurrentValues.SetValues(o1);
        entry.State = EntityState.Modified;
        await _context.SaveChangesAsync(_audit);
    }

    public async Task RemoveAsync(int id)
    {
        var o = await _context.JobPositions.FindAsync(id);
        if (o == null)
            throw new NullReferenceException(id.ToString());
        _context.JobPositions.Attach(o);
        _context.JobPositions.Remove(o);
        await _context.SaveChangesAsync(_audit);
    }

    public IQueryable<JobPositionDto> GetJobPositions()
    {
        var q = (from o in _context.JobPositions
                 select o)
                 .AsNoTracking()
                 .ProjectTo<JobPositionDto>(_mapper.ConfigurationProvider);
        return q;
    }
}
