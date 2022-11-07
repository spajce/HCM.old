namespace HCM.Application.Repositories.Jobs;

public interface IJobPositionParentRepository
{
    //JobPositionParentRepository InitDbContext(HCMDbContext context);
    Task<int> PostAsync(JobPositionParentDto o);
    Task PutAsync(int id, JobPositionParentDto o);
    Task RemoveAsync(int id);
    JobPositionParent InitEntity(JobPositionParentDto o);
    IQueryable<JobPositionParentDto> GetJobPositionParents();

}

public class JobPositionParentRepository : IJobPositionParentRepository
{
    private readonly HCMDbContext _context;
    private readonly IAuditRepository _auditRepository;
    private readonly AuditX _audit;
    private readonly IMapper _mapper;

    public JobPositionParentRepository(HCMDbContext context,
        IAuditRepository auditRepository, IMapper mapper)
    {
        _context = context;
        _auditRepository = auditRepository;
        _audit = _auditRepository.Audit;
        _mapper = mapper;
    }

    //public JobPositionParentRepository InitDbContext(HCMDbContext context)
    //{
    //    _context = context;
    //    return this;
    //}

    public JobPositionParent InitEntity(JobPositionParentDto o)
    {
        var o1 = _mapper.Map<JobPositionParentDto, JobPositionParent>(o);
        return o1;
    }

    public async Task<int> PostAsync(JobPositionParentDto o)
    {
        var o1 = InitEntity(o);
        await _context.AddAsync(o1);
        await _context.SaveChangesAsync(_audit);
        return o1.IdJobPositionParent;
    }

    public async Task PutAsync(int id, JobPositionParentDto o)
    {
        var o1 = InitEntity(o);

        var o2 = await _context.JobPositionParents.FindAsync(id);

        if (o2 == null)
            throw new NullReferenceException(id.ToString());

        var entry = _context.Entry(o2);
        entry.CurrentValues.SetValues(o1);
        entry.State = EntityState.Modified;
        await _context.SaveChangesAsync(_audit);
    }

    public async Task RemoveAsync(int id)
    {
        var o = await _context.JobPositionParents.FindAsync(id);
        if (o == null)
            throw new NullReferenceException(id.ToString());
        _context.JobPositionParents.Attach(o);
        _context.JobPositionParents.Remove(o);
        await _context.SaveChangesAsync(_audit);
    }

    public IQueryable<JobPositionParentDto> GetJobPositionParents()
    {
        var q = (from o in _context.JobPositionParents
                 select o)
                 .AsNoTracking()
                 .ProjectTo<JobPositionParentDto>(_mapper.ConfigurationProvider);
        return q;
    }
}
