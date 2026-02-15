using Trivo.Application.Interfaces.Repository;
using Trivo.Domain.Models;
using Trivo.Infrastructure.Persistence.Base;
using Trivo.Infrastructure.Persistence.Context;

namespace Trivo.Infrastructure.Persistence.Repository.Account;

public class ReportRepository(TrivoContext context) : GenericRepository<Report>(context), IReportRepository;