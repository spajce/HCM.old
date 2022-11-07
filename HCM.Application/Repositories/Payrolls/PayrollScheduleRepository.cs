namespace HCM.Application.Repositories.Payrolls;

public interface IPayrollScheduleRepository
{
    //PayrollScheduleRepository InitDbContext(HCMDbContext context);
    Task<int> PostAsync(PayrollScheduleDto o);
    Task PutAsync(int id, PayrollScheduleDto o);
    Task RemoveAsync(int id);
    PayrollSchedule InitEntity(PayrollScheduleDto o);
    IQueryable<PayrollScheduleDto> GetPayrollSchedules();

}

public class PayrollScheduleRepository : IPayrollScheduleRepository
{
    private readonly HCMDbContext _context;
    private readonly IAuditRepository _auditRepository;
    private readonly AuditX _audit;
    private readonly IMapper _mapper;

    public PayrollScheduleRepository(HCMDbContext context,
        IAuditRepository auditRepository, IMapper mapper)
    {
        _context = context;
        _auditRepository = auditRepository;
        _audit = _auditRepository.Audit;
        _mapper = mapper;
    }

    //public PayrollScheduleRepository InitDbContext(HCMDbContext context)
    //{
    //    _context = context;
    //    return this;
    //}

    public PayrollSchedule InitEntity(PayrollScheduleDto o)
    {
        var o1 = _mapper.Map<PayrollScheduleDto, PayrollSchedule>(o);
        return o1;
    }

    public async Task<int> PostAsync(PayrollScheduleDto o)
    {
        var o1 = InitEntity(o);
        await _context.AddAsync(o1);
        await _context.SaveChangesAsync(_audit);
        return o1.IdPayrollSchedule;
    }

    public async Task PutAsync(int id, PayrollScheduleDto o)
    {
        var o1 = InitEntity(o);

        var o2 = await _context.PayrollSchedules.FindAsync(id);

        if (o2 == null)
            throw new NullReferenceException(id.ToString());

        var entry = _context.Entry(o2);
        entry.CurrentValues.SetValues(o1);
        entry.State = EntityState.Modified;
        await _context.SaveChangesAsync(_audit);
    }

    public async Task RemoveAsync(int id)
    {
        var o = await _context.PayrollSchedules.FindAsync(id);
        if (o == null)
            throw new NullReferenceException(id.ToString());
        _context.PayrollSchedules.Attach(o);
        _context.PayrollSchedules.Remove(o);
        await _context.SaveChangesAsync(_audit);
    }

    public IQueryable<PayrollScheduleDto> GetPayrollSchedules()
    {
        var q = (from o in _context.PayrollSchedules
                 select o)
                 .AsNoTracking()
                 .ProjectTo<PayrollScheduleDto>(_mapper.ConfigurationProvider);
        return q;
    }
}
