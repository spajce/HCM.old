namespace HCM.Application.Repositories.Jobs;

public interface IJobDepartmentRepository
{
    //JobDepartmentRepository InitDbContext(HCMDbContext context);
    Task<int> PostAsync(JobDepartmentDto o);
    Task PutAsync(int id, JobDepartmentDto o);
    Task RemoveAsync(int id);
    JobDepartment InitEntity(JobDepartmentDto o);
    IQueryable<JobDepartmentDto> GetJobDepartments();

}

public class JobDepartmentRepository : IJobDepartmentRepository
{
    private readonly HCMDbContext _context;
    private readonly IAuditRepository _auditRepository;
    private readonly AuditX _audit;
    private readonly IMapper _mapper;

    public JobDepartmentRepository(HCMDbContext context,
        IAuditRepository auditRepository, IMapper mapper)
    {
        _context = context;
        _auditRepository = auditRepository;
        _audit = _auditRepository.Audit;
        _mapper = mapper;
    }

    //public JobDepartmentRepository InitDbContext(HCMDbContext context)
    //{
    //    _context = context;
    //    return this;
    //}

    public JobDepartment InitEntity(JobDepartmentDto o)
    {
        var o1 = _mapper.Map<JobDepartmentDto, JobDepartment>(o);
        return o1;
    }

    public async Task<int> PostAsync(JobDepartmentDto o)
    {
        var o1 = InitEntity(o);
        await _context.AddAsync(o1);
        await _context.SaveChangesAsync(_audit);
        return o1.IdJobDepartment;
    }

    public async Task PutAsync(int id, JobDepartmentDto o)
    {
        var o1 = InitEntity(o);

        var o2 = await _context.JobDepartments.FindAsync(id);

        if (o2 == null)
            throw new NullReferenceException(id.ToString());

        var entry = _context.Entry(o2);
        entry.CurrentValues.SetValues(o1);
        entry.State = EntityState.Modified;
        await _context.SaveChangesAsync(_audit);
    }

    public async Task RemoveAsync(int id)
    {
        var o = await _context.JobDepartments.FindAsync(id);
        if (o == null)
            throw new NullReferenceException(id.ToString());
        _context.JobDepartments.Attach(o);
        _context.JobDepartments.Remove(o);
        await _context.SaveChangesAsync(_audit);
    }

    public IQueryable<JobDepartmentDto> GetJobDepartments()
    {
        var q = (from o in _context.JobDepartments
                 select o)
                 .AsNoTracking()
                 .ProjectTo<JobDepartmentDto>(_mapper.ConfigurationProvider);
        return q;
    }
}
