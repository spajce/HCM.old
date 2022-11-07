namespace HCM.Application.Repositories.Employees;

public interface IEmployeeRepository
{
    //EmployeeRepository InitDbContext(HCMDbContext context);
    Task<int> PostAsync(EmployeeDto o);
    Task PutAsync(int id, EmployeeDto o);
    Task RemoveAsync(int id);
    Employee InitEntity(EmployeeDto o);
    IQueryable<EmployeeDto> GetEmployees();
    IQueryable<EmployeeDto> GetEmployees(string find);
    Task<PaginatedData<EmployeeDto>> GetEmployees(PaginationFilterModel request);

}

public class EmployeeRepository : IEmployeeRepository
{
    private readonly HCMDbContext _context;
    private readonly IAuditRepository _auditRepository;
    private readonly AuditX _audit;
    private readonly IMapper _mapper;

    public EmployeeRepository(HCMDbContext context,
        IAuditRepository auditRepository, IMapper mapper)
    {
        _context = context;
        _auditRepository = auditRepository;
        _audit = _auditRepository.Audit;
        _mapper = mapper;
    }

    //public EmployeeRepository InitDbContext(HCMDbContext context)
    //{
    //    _context = context;
    //    return this;
    //}

    public Employee InitEntity(EmployeeDto o)
    {
        var o1 = _mapper.Map<EmployeeDto, Employee>(o);
        return o1;
    }

    public async Task<int> PostAsync(EmployeeDto o)
    {
        o.CreateBy = _audit.CreatedBy;
        o.CreateAt = DateTime.Now;

        var o1 = InitEntity(o);
        await _context.AddAsync(o1);
        await _context.SaveChangesAsync(_audit);
        return o1.IdEmployee;
    }

    public async Task PutAsync(int id, EmployeeDto o)
    {
        o.UpdateBy = _audit.CreatedBy;
        o.UpdateAt = DateTime.Now;

        var o1 = InitEntity(o);

        var o2 = await _context.Employees.FindAsync(id);

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
        var o = await _context.Employees.FindAsync(id);
        if (o == null)
            throw new NullReferenceException(id.ToString());
        _context.Employees.Attach(o);
        _context.Employees.Remove(o);
        await _context.SaveChangesAsync(_audit);
    }

    public IQueryable<EmployeeDto> GetEmployees()
    {
        var q = (from o in _context.Employees
                 select o)
                 .Take(100)
                 .AsNoTracking()
                 .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider);
        return q;
    }

    public IQueryable<EmployeeDto> GetEmployees(string find)
    {
        var q = (from o in _context.Employees
                 where o.LastName.Contains(find) || o.FirstName.Contains(find) ||
                 o.MiddleName.Contains(find)
                 select o)
                 .Take(100)
                 .AsNoTracking()
                 .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider);
        return q;
    }

    public async Task<PaginatedData<EmployeeDto>> GetEmployees(PaginationFilterModel request)
    {
        if (string.IsNullOrEmpty(request.OrderBy) || string.IsNullOrWhiteSpace(request.OrderBy))
            request.OrderBy = _context.GetPrimaryKeyColumnName(typeof(Employee));

        var q = await _context.Employees
            .OrderBy($"{request.OrderBy} {request.SortDirection}")
            .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
            .PaginatedDataAsync(request.PageNumber, request.PageSize);

        return q;
    }
}
