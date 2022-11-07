namespace HCM.Application.Repositories.Payments;

public interface IPaymentParticularRepository
{
    //PaymentParticularRepository InitDbContext(HCMDbContext context);
    Task<int> PostAsync(PaymentParticularDto o);
    Task PutAsync(int id, PaymentParticularDto o);
    Task RemoveAsync(int id);
    PaymentParticular InitEntity(PaymentParticularDto o);
    IQueryable<PaymentParticularDto> GetPaymentParticulars();

}

public class PaymentParticularRepository : IPaymentParticularRepository
{
    private readonly HCMDbContext _context;
    private readonly IAuditRepository _auditRepository;
    private readonly AuditX _audit;
    private readonly IMapper _mapper;

    public PaymentParticularRepository(HCMDbContext context,
        IAuditRepository auditRepository, IMapper mapper)
    {
        _context = context;
        _auditRepository = auditRepository;
        _audit = _auditRepository.Audit;
        _mapper = mapper;
    }

    //public PaymentParticularRepository InitDbContext(HCMDbContext context)
    //{
    //    _context = context;
    //    return this;
    //}

    public PaymentParticular InitEntity(PaymentParticularDto o)
    {
        var o1 = _mapper.Map<PaymentParticularDto, PaymentParticular>(o);
        return o1;
    }

    public async Task<int> PostAsync(PaymentParticularDto o)
    {
        var o1 = InitEntity(o);
        await _context.AddAsync(o1);
        await _context.SaveChangesAsync(_audit);
        return o1.IdPaymentParticular;
    }

    public async Task PutAsync(int id, PaymentParticularDto o)
    {
        var o1 = InitEntity(o);

        var o2 = await _context.PaymentParticulars.FindAsync(id);

        if (o2 == null)
            throw new NullReferenceException(id.ToString());

        var entry = _context.Entry(o2);
        entry.CurrentValues.SetValues(o1);
        entry.State = EntityState.Modified;
        await _context.SaveChangesAsync(_audit);
    }

    public async Task RemoveAsync(int id)
    {
        var o = await _context.PaymentParticulars.FindAsync(id);
        if (o == null)
            throw new NullReferenceException(id.ToString());
        _context.PaymentParticulars.Attach(o);
        _context.PaymentParticulars.Remove(o);
        await _context.SaveChangesAsync(_audit);
    }

    public IQueryable<PaymentParticularDto> GetPaymentParticulars()
    {
        var q = (from o in _context.PaymentParticulars
                 select o)
                 .AsNoTracking()
                 .ProjectTo<PaymentParticularDto>(_mapper.ConfigurationProvider);
        return q;
    }
}
