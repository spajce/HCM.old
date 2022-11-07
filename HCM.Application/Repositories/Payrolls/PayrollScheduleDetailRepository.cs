namespace HCM.Application.Repositories.Payrolls;

public interface IPayrollScheduleDetailRepository
{
    //PayrollScheduleDetailRepository InitDbContext(HCMDbContext context);
    Task<int> PostAsync(PayrollScheduleDetailDto o);
    Task PutAsync(int id, PayrollScheduleDetailDto o);
    Task RemoveAsync(int id);
    PayrollScheduleDetail InitEntity(PayrollScheduleDetailDto o);
    IQueryable<PayrollScheduleDetailDto> GetPayrollScheduleDetails(int idPayrollSchedule);

}

public class PayrollScheduleDetailRepository : IPayrollScheduleDetailRepository
{
    private readonly HCMDbContext _context;
    private readonly IAuditRepository _auditRepository;
    private readonly AuditX _audit;
    private readonly IMapper _mapper;

    public PayrollScheduleDetailRepository(HCMDbContext context,
        IAuditRepository auditRepository, IMapper mapper)
    {
        _context = context;
        _auditRepository = auditRepository;
        _audit = _auditRepository.Audit;
        _mapper = mapper;
    }

    //public PayrollScheduleDetailRepository InitDbContext(HCMDbContext context)
    //{
    //    _context = context;
    //    return this;
    //}

    public PayrollScheduleDetail InitEntity(PayrollScheduleDetailDto o)
    {
        var o1 = _mapper.Map<PayrollScheduleDetailDto, PayrollScheduleDetail>(o);
        return o1;
    }

    public async Task<int> PostAsync(PayrollScheduleDetailDto o)
    {
        var o1 = InitEntity(o);
        await _context.AddAsync(o1);
        await _context.SaveChangesAsync(_audit);
        return o1.IdPayrollScheduleDetail;
    }

    public async Task PutAsync(int id, PayrollScheduleDetailDto o)
    {
        var o1 = InitEntity(o);

        var o2 = await _context.PayrollScheduleDetails.FindAsync(id);

        if (o2 == null)
            throw new NullReferenceException(id.ToString());

        var entry = _context.Entry(o2);
        entry.CurrentValues.SetValues(o1);
        entry.State = EntityState.Modified;
        await _context.SaveChangesAsync(_audit);
    }

    public async Task RemoveAsync(int id)
    {
        var o = await _context.PayrollScheduleDetails.FindAsync(id);
        if (o == null)
            throw new NullReferenceException(id.ToString());
        _context.PayrollScheduleDetails.Attach(o);
        _context.PayrollScheduleDetails.Remove(o);
        await _context.SaveChangesAsync(_audit);
    }

    public IQueryable<PayrollScheduleDetailDto> GetPayrollScheduleDetails(int idPayrollSchedule)
    {
        var q = (from o in _context.PayrollScheduleDetails
                 where o.IdPayrollSchedule == idPayrollSchedule
                 select o)
                 .AsNoTracking()
                 .ProjectTo<PayrollScheduleDetailDto>(_mapper.ConfigurationProvider);
        return q;
    }
}
