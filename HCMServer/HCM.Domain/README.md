# Markdown File

dotnet ef dbcontext scaffold "Server=localhost;Database=hcm_dbase_devel;User=root;Password=X09z7jTeHIq@22;TreatTinyAsBoolean=false;port=3308;" "Pomelo.EntityFrameworkCore.MySql" --context-dir HCM --context HCMDbContext --context-namespace HCM.Domain --namespace HCM.Domain.Entities -o HCM\Entities -f --no-onconfiguring --use-database-names

### Replace Contractor of DbContext


        //protected HCMDbContext(DbContextOptions options)
        //            : base(options)
        //{
        //}

        public HCMDbContext(DbContextOptions<HCMDbContext> options)
            : base(options)
        {
        }

### Mapster
REF: https://github.com/MapsterMapper/Mapster/wiki/Mapster.Tool