using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace HCM.Application.Repositories.Audits
{
    public interface IAuditRepository
    {
        AuditX Audit { get; }
        Task BulkDeleteThenAuditAsync(IEnumerable<object> entities);
        Task BulkInsertThenAuditAsync(IEnumerable<object> entities);
        Task BulkUpdateThenAuditAsync(IEnumerable<object> entities);
    }

    public class AuditRepository : IAuditRepository
    {

        private readonly HCMDbContext _context;
        private readonly AuditX _audit;
        private readonly AuditDbContext _auditContext;

        public AuditRepository(
            HCMDbContext context,
            AuditDbContext auditContext,
            IHttpContextAccessor httpContext,
            ILoggerFactory loggerFactory
            )
        {
            _context = context;
            _auditContext = auditContext;

            var logger = loggerFactory.CreateLogger("AuditDbContextLog");
            string userName = string.Empty;

            var claim = httpContext.HttpContext.User.FindFirst(ClaimTypes.Name);

            if (claim != null)
                userName = claim.Value;
            else
                userName = "Anonymous";

            _audit = new AuditX
            {
                CreatedBy = userName,
            };

            AuditManager.DefaultConfiguration.AutoSavePreAction = (context, audit) =>
           {
               try
               {
                   var customAuditEntries = audit.Entries.Select(AuditEFHelpers.Import);
                   auditContext.AddRange(customAuditEntries);
                   auditContext.SaveChanges();
               }
               catch (DbUpdateException ex)
               {
                   // Todo: Write the changes in log file if error happen
                   logger.LogError(ex, "{Message}\n{InnerException}", ex.Message, ex.InnerException?.Message);
               }
               catch (ObjectDisposedException ex)
               {
                   if (ex.ObjectName == nameof(HCMDbContext))
                   {
                       logger.LogError(ex, "{ObjectName}", ex.ObjectName);
                   }
               }
           };

            AuditManager.DefaultConfiguration.ExcludeProperty<Employee>(x => new { x.Photo, x.CreateAt, x.CreateBy, x.UpdateAt, x.UpdateBy });
            //AuditManager.DefaultConfiguration.ExcludeProperty<ContractLaborDetail>(x => new { x.CreateAt, x.CreateBy, x.UpdateAt, x.UpdateBy });
            //AuditManager.DefaultConfiguration.ExcludeProperty<ContractLabor>(x => new { x.CreateAt, x.CreateBy, x.UpdateAt, x.UpdateBy });
            //AuditManager.DefaultConfiguration.ExcludeProperty<FileInfo>(x => new { x.Size, x.HasPreviewImage, x.MiniPreview, x.Width, x.Height, x.Extension, x.VisibleToClient, x.CreateAt, x.CreateBy, x.UpdateAt, x.UpdateBy });
            //AuditManager.DefaultConfiguration.ExcludeProperty<LaborPresetDetail>(x => new { x.QrCodeImage, x.CreateAt, x.CreateBy, x.UpdateAt, x.UpdateBy });
            //AuditManager.DefaultConfiguration.Format<LaborPresetDetail>(x =>
            //                                                     new
            //                                                     {
            //                                                         x.Cost,
            //                                                     }, x => ((decimal?)x)?.ToString("#,#0.00"));
            //AuditManager.DefaultConfiguration.ExcludeProperty<LaborPreset>(x => new { x.CreateAt, x.CreateBy, x.UpdateAt, x.UpdateBy });
            //AuditManager.DefaultConfiguration.ExcludeProperty<PaymentDetail>(x => new { x.CreateAt, x.CreateBy, x.UpdateAt, x.UpdateBy });
            //AuditManager.DefaultConfiguration.Format<PaymentDetail>(x =>
            //                                                        new
            //                                                        {
            //                                                            x.Cost,
            //                                                            x.PaymentCostCurrent,
            //                                                            x.PaymentCost,
            //                                                        }, x => ((decimal?)x)?.ToString("#,#0.00"));
            //AuditManager.DefaultConfiguration.ExcludeProperty<Payment>(x => new { x.CreateAt, x.CreateBy, x.UpdateAt, x.UpdateBy });
            //AuditManager.DefaultConfiguration.Format<Payment>(x =>
            //                                                        new
            //                                                        {
            //                                                            x.PostingDate,
            //                                                            x.DocDate,
            //                                                        }, x => ((DateOnly?)x)?.ToString("dd/MM/yyy"));
            //AuditManager.DefaultConfiguration.ExcludeProperty<SapJournalVoucherEntry>(x => new { x.CreateAt, x.CreateBy, x.UpdateAt, x.UpdateBy });
            //AuditManager.DefaultConfiguration.ExcludeProperty<SapJournalVoucherEntryDetail>(x => new { x.CreateAt, x.CreateBy, x.UpdateAt, x.UpdateBy });
            //AuditManager.DefaultConfiguration.ExcludeProperty<User>(x => new { x.Password, x.CreateAt, x.CreateBy, x.UpdateAt, x.UpdateBy });
            //AuditManager.DefaultConfiguration.ExcludeProperty<WorkAppraisalDetail>(x => new { x.CreateAt, x.CreateBy, x.UpdateAt, x.UpdateBy });
            //AuditManager.DefaultConfiguration.ExcludeProperty<WorkAppraisal>(x => new { x.CreateAt, x.CreateBy, x.UpdateAt, x.UpdateBy });
            //AuditManager.DefaultConfiguration.Format<WorkAppraisal>(x =>
            //                                                       new
            //                                                       {
            //                                                           x.PostingDate,
            //                                                           x.DocDate,
            //                                                       }, x => ((DateOnly?)x)?.ToString("dd/MM/yyy"));
            //AuditManager.DefaultConfiguration.ExcludeProperty<WorkScope>(x => new { x.CreateAt, x.CreateBy, x.UpdateAt, x.UpdateBy });

        }

        public AuditX Audit => _audit;

        public async Task BulkDeleteThenAuditAsync(IEnumerable<object> entities)
        {
            var auditEntries = new List<Z.BulkOperations.AuditEntry>();
            await _context.BulkDeleteAsync(entities, opt =>
            {
                opt.UseAudit = true;
                opt.AuditEntries = auditEntries;
            });

            await BulkAuditChanges(auditEntries);
        }

        public async Task BulkInsertThenAuditAsync(IEnumerable<object> entities)
        {
            var auditEntries = new List<Z.BulkOperations.AuditEntry>();
            await _context.BulkInsertAsync(entities, opt =>
            {
                opt.UseAudit = true;
                opt.AuditEntries = auditEntries;
            });

            await BulkAuditChanges(auditEntries);
        }

        public async Task BulkUpdateThenAuditAsync(IEnumerable<object> entities)
        {
            var auditEntries = new List<Z.BulkOperations.AuditEntry>();
            await _context.BulkUpdateAsync(entities, opt =>
            {
                opt.UseAudit = true;
                opt.AuditEntries = auditEntries;
            });

            await BulkAuditChanges(auditEntries);
        }

        private async Task BulkAuditChanges(List<Z.BulkOperations.AuditEntry> auditEntries)
        {
            List<AuditLog> auditLogs = new List<AuditLog>();

            foreach (var auditEntry in auditEntries)
            {
                AuditLog log = new AuditLog();



                log.Action = auditEntry.Action.ToString();
                log.TableName = auditEntry.TableName;
                log.Values = string.Join("|", auditEntry.Values.Select(x => x.ColumnName + ";" + (x.OldValue ?? "") + ";" + (x.NewValue ?? "")));
                log.Date = auditEntry.Date;
                log.UserId = _audit.CreatedBy;
                auditLogs.Add(log);
            }

            // REF: https://entityframework-extensions.net/save-audit-history-in-a-database
            // we turn off `AutoMapOutputDirection` as we don't need to return the identity values
            await _auditContext.BulkInsertAsync(auditLogs, options => options.AutoMapOutputDirection = false);
        }
    }

    public static class AuditEFHelpers
    {
        public static Audit.Domain.Entities.AuditEntry Import(Z.EntityFramework.Plus.AuditEntry entry)
        {
            var customAuditEntry = new Audit.Domain.Entities.AuditEntry
            {
                EntitySetName = entry.EntitySetName,
                EntityTypeName = entry.EntityTypeName,
                State = (int)entry.State,
                StateName = entry.StateName,
                CreatedBy = entry.CreatedBy,
                CreatedDate = entry.CreatedDate,
            };

            var ent = entry.Properties.Select(Import)/*.Where(x => x != null)*/.ToList();
            customAuditEntry.AuditentryProperties = ent;

            return customAuditEntry;
        }

        public static Audit.Domain.Entities.AuditEntryProperty Import(Z.EntityFramework.Plus.AuditEntryProperty property)
        {
            var customAuditEntry = new Audit.Domain.Entities.AuditEntryProperty
            {
                RelationName = property.RelationName,
                PropertyName = property.PropertyName,
                OldValue = property.OldValueFormatted,
                NewValue = property.NewValueFormatted,
            };
            return customAuditEntry;
        }
    }
}
