namespace HCM.Application.Repositories.EmployeePayments;

public interface IEmployeePaymentRepository
{
    //EmployeePaymentRepository InitDbContext(HCMDbContext context);
    Task<int> PostAsync(EmployeePaymentDto o);
    Task PutAsync(int id, EmployeePaymentDto o);
    Task RemoveAsync(int id);
    EmployeePayment InitEntity(EmployeePaymentDto o);
    IQueryable<EmployeePaymentDto> GetEmployeePayments(int idEmployee);

}

public class EmployeePaymentRepository : IEmployeePaymentRepository
{
    private readonly HCMDbContext _context;
    private readonly IAuditRepository _auditRepository;
    private readonly AuditX _audit;
    private readonly IMapper _mapper;

    public EmployeePaymentRepository(HCMDbContext context,
        IAuditRepository auditRepository, IMapper mapper)
    {
        _context = context;
        _auditRepository = auditRepository;
        _audit = _auditRepository.Audit;
        _mapper = mapper;
    }

    //public EmployeePaymentRepository InitDbContext(HCMDbContext context)
    //{
    //    _context = context;
    //    return this;
    //}

    public EmployeePayment InitEntity(EmployeePaymentDto o)
    {
        var o1 = _mapper.Map<EmployeePaymentDto, EmployeePayment>(o);
        return o1;
    }

    public async Task<int> PostAsync(EmployeePaymentDto o)
    {
        o.CreateBy = _audit.CreatedBy;
        o.CreateAt = DateTime.Now;

        var o1 = InitEntity(o);
        await _context.AddAsync(o1);
        await _context.SaveChangesAsync(_audit);
        return o1.IdEmployeePayment;
    }

    public async Task PutAsync(int id, EmployeePaymentDto o)
    {
        o.UpdateBy = _audit.CreatedBy;
        o.UpdateAt = DateTime.Now;

        var o1 = InitEntity(o);

        var o2 = await _context.EmployeePayments.FindAsync(id);

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
        var o = await _context.EmployeePayments.FindAsync(id);
        if (o == null)
            throw new NullReferenceException(id.ToString());
        _context.EmployeePayments.Attach(o);
        _context.EmployeePayments.Remove(o);
        await _context.SaveChangesAsync(_audit);
    }

    public IQueryable<EmployeePaymentDto> GetEmployeePayments()
    {
        var q = (from o in _context.EmployeePayments
                 select o)
                 .Take(100)
                 .AsNoTracking()
                 .ProjectTo<EmployeePaymentDto>(_mapper.ConfigurationProvider);
        return q;
    }

    public IQueryable<EmployeePaymentDto> GetEmployeePayments(int idEmployee)
    {
        var q = (from o in _context.EmployeePayments
                 where o.IdEmployee == idEmployee
                 select o)
                 .AsNoTracking()
                 .ProjectTo<EmployeePaymentDto>(_mapper.ConfigurationProvider);
        return q;
    }
}
