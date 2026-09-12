# Graph Report - Trivo  (2026-09-11)

## Corpus Check
- 420 files · ~71,331 words
- Verdict: corpus is large enough that graph structure adds value.

## Summary
- 2945 nodes · 6779 edges · 158 communities (154 shown, 4 thin omitted)
- Extraction: 94% EXTRACTED · 6% INFERRED · 0% AMBIGUOUS · INFERRED: 418 edges (avg confidence: 0.84)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `67f00dd0`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- UserRepository
- Trivo.Application.Abstractions.Messages
- Message
- InterestCategory
- Trivo.Application.DTOs.Users
- Trivo.Domain.Models
- AuthenticationService
- Trivo.Infrastructure.Persistence.Configurations
- CreateAdminCommandHandler
- Trivo.Application.Interfaces.Services
- Trivo.Application.Interfaces.SignalR
- Expert
- UserController
- Trivo.Infrastructure.Persistence.Migrations
- Notification
- .Conflict
- BaseEntity
- .AddRepositories
- ChatDto
- Code
- Trivo.Domain.Enums
- MatchDetailsDto
- User
- Dependency Injection Patterns
- .Handle
- .AddServices
- AbstractValidator
- IQuery
- Recruiter
- AdministratorRepository
- .Handle
- .Failure
- AdminController
- NotificationNotifier
- Chat
- User
- IAdministratorRepository
- InterestRepository
- Entity Framework Core Patterns
- ExceptionHandlingMiddleware
- NotificationDto
- MessageDto
- .AddAiService
- .Handle
- Interest
- Trivo.API.csproj
- ResultT
- IInterestRepository
- MatchHub
- Public API Design and Compatibility
- .Handle
- IUserRepository
- .GetByCategoriesAsync
- ICacheService
- CreateSkillCommand
- .Handle
- .Handle
- .AddSkillsToUserAsync
- .GetRolesAsync
- Trivo.Infrastructure.Shared.csproj
- .CreateSkillAsync
- PagedResult
- Database Performance Patterns
- InterestWithIdDto
- TrivoContext
- CreateMatchingCommandHandler
- UserInterest
- Skill
- Slopwatch: LLM Anti-Cheat for .NET
- UserAiRecommendationDto
- .Validate
- UpdateInterestCommand
- Trivo.Application.DTOs.Administrator
- CacheEntryOptions
- GoogleGeminiEmbeddingService
- Módulo de Matchmaking con IA — Implementación
- Plan de implementación — Embeddings vía API externa para emparejamiento por afinidad
- IMatchRepository
- UserRecommendationHub
- Nullable Attributes Reference
- MatchRepository
- Modern C# Coding Standards
- Match
- .ValidateEmailAsync
- .Handle
- Plantillas copy-paste — feature CQRS de Trivo
- CloudinaryService
- SkillWithIdDto
- Polyfilling the nullable attributes for older target frameworks
- Administrator
- IRealTimeNotifier
- CreateInterestCategoryCommandHandler.cs
- .Handle
- Trivo.Application.csproj
- C# Nullable Reference Types
- IQueryHandler
- NRT Migration Playbook Reference
- .MapToInterests
- IChatHub
- Anti-Patterns to Avoid
- .Handle
- Report
- ChatHub
- IMatchHub
- ResultFilter
- Anti-Patterns and Reflection Avoidance
- .GetUserId
- Avoid Reflection-Based Metaprogramming
- Trivo
- .CreateMatchAsync
- Performance and API Design Patterns
- Value Objects and Pattern Matching
- IUserOwnedRequest
- GetLatestUsersPagedQueryHandler.cs
- MatchDto
- GetActiveUsersCountQueryHandler
- .Handle
- GetReportedUsersCountQueryHandler
- ICloudinaryService
- .GetExpertIdAsync
- .GetRecruiterIdAsync
- UserSkill
- EmailSetting
- Trivo.Infrastructure.Persistence.csproj
- The `field` Keyword (C# 14 / .NET 10) and Nullability
- MessageStatus
- Trivo.Domain.csproj
- OpenAiEmbeddingService
- .ToEntity
- UserMappingExtensions.cs
- SkillDto
- ErrorType
- NotificationType
- CustomUserIdProvider
- ExpertStatus
- Level
- MatchStatus
- MessageType
- RecruiterStatus
- UserStatus
- PaginationExtensions.cs
- ChatType
- MatchFault
- JwtSetting
- ReportStatus
- CodeGenerator.cs
- Core Nullability Model
- Arquitectura CQRS de Trivo — mandato para nuevas features
- Composition and Error Handling
- Language Patterns
- CacheProfiles
- AiSetting
- Known Static-Analysis Limitations and Safe Patterns
- Conditional postconditions: `NotNullWhen`, `MaybeNullWhen`, `NotNullIfNotNull`
- UserInterestConfig
- Preconditions: `AllowNull` and `DisallowNull`
- Performance Patterns
- CLAUDE.md

## God Nodes (most connected - your core abstractions)
1. `ResultT` - 136 edges
2. `Trivo.Application.Abstractions.Messages` - 110 edges
3. `Trivo.Domain.Models` - 92 edges
4. `Trivo.Application.Utils` - 86 edges
5. `Trivo.Application.Interfaces.Services` - 70 edges
6. `PagedResult` - 70 edges
7. `TrivoContext` - 61 edges
8. `IUserRepository` - 58 edges
9. `Trivo.Application.Pagination` - 57 edges
10. `Trivo.Application.Interfaces.Repository.Account` - 54 edges

## Surprising Connections (you probably didn't know these)
- `UserController` --references--> `ICodeService`  [EXTRACTED]
  src/API/Trivo.API/Controllers/V1/UserController.cs → src/Application/Trivo.Application/Interfaces/Services/ICodeService.cs
- `UserController` --references--> `IEmailValidationService`  [EXTRACTED]
  src/API/Trivo.API/Controllers/V1/UserController.cs → src/Application/Trivo.Application/Interfaces/Services/IEmailValidationService.cs
- `ICommand` --references--> `Result`  [EXTRACTED]
  src/Application/Trivo.Application/Abstractions/Messages/ICommand.cs → src/Application/Trivo.Application/Utils/Result.cs
- `ICommand` --references--> `ResultT`  [EXTRACTED]
  src/Application/Trivo.Application/Abstractions/Messages/ICommand.cs → src/Application/Trivo.Application/Utils/Result.cs
- `CreateAdminCommand` --implements--> `ICommand`  [EXTRACTED]
  src/Application/Trivo.Application/Features/Administrator/Commands/CreateAdministrator/CreateAdminCommand.cs → src/Application/Trivo.Application/Abstractions/Messages/ICommand.cs

## Import Cycles
- None detected.

## Communities (158 total, 4 thin omitted)

### Community 0 - "UserRepository"
Cohesion: 0.18
Nodes (14): Expression, Func, CancellationToken, Distance, Expert, Guid, IEnumerable, IReadOnlyList (+6 more)

### Community 1 - "Trivo.Application.Abstractions.Messages"
Cohesion: 0.08
Nodes (18): Trivo.Application.Features.Recruiters.Commands.UpdateRecruiter, Trivo.Application.Abstractions.Messages, Trivo.Application.Features.Users.Commands.UpdatePassword, Trivo.Application.Features.Users.Commands.CreateUser, Trivo.Application.Interfaces.UnitOfWork, Trivo.Application.DTOs.Expert, Trivo.Application.Utils, Trivo.Application.Features.Users.Commands.UpdateUser (+10 more)

### Community 2 - "Message"
Cohesion: 0.05
Nodes (48): Trivo.Application.Features.Reports.Commands.CreateReport, Trivo.Application.Features.Reports, Trivo.Application.DTOs.Reports, Authorize, CancellationToken, HttpPost, ISender, ProducesResponseType (+40 more)

### Community 3 - "InterestCategory"
Cohesion: 0.05
Nodes (41): Authorize, CancellationToken, HttpGet, HttpPost, ISender, ProducesResponseType, Task, InterestCategoryController (+33 more)

### Community 4 - "Trivo.Application.DTOs.Users"
Cohesion: 0.07
Nodes (15): Trivo.Application.Features.Skills.Query.GetSkillsPagination, Trivo.Application.Features.Interests.Commands.CreateInterest, Trivo.Application.Features.Users.Query.GetUserDetails, Trivo.Application.Features.Users.Query.GetUserInterests, Trivo.Application.Features.Interests.Query.GetInterestsByCategoryId, Trivo.Application.DTOs.Users, Trivo.Application.DTOs.Skills, Trivo.Application.Features.Skills.Query.SearchSkillsByName (+7 more)

### Community 5 - "Trivo.Domain.Models"
Cohesion: 0.12
Nodes (12): Trivo.Domain.Common, Trivo.Infrastructure.Persistence.Context, Trivo.Infrastructure.Persistence.Repository.Account, Trivo.Application.Interfaces.Repository.Base, Trivo.Infrastructure.Persistence.Repository, Trivo.Domain.Models, Trivo.Application.Interfaces.Repository, Trivo.Infrastructure.Persistence.Base (+4 more)

### Community 6 - "AuthenticationService"
Cohesion: 0.06
Nodes (32): ControllerBase, Trivo.Application.Features.Users.Commands.LoginUser, CancellationToken, HttpPost, ProducesResponseType, SwaggerOperation, Task, AuthController (+24 more)

### Community 7 - "Trivo.Infrastructure.Persistence.Configurations"
Cohesion: 0.05
Nodes (24): Trivo.Infrastructure.Persistence.Configurations, IEntityTypeConfiguration, EntityTypeBuilder, AdministratorConfig, EntityTypeBuilder, ChatConfig, EntityTypeBuilder, ChatUserConfig (+16 more)

### Community 8 - "CreateAdminCommandHandler"
Cohesion: 0.12
Nodes (12): Trivo.Application.Features.Administrator, DateTime, Guid, AdminDto, Administrator, AdminMapper, AdminMatchMapper, IFormFile (+4 more)

### Community 9 - "Trivo.Application.Interfaces.Services"
Cohesion: 0.09
Nodes (14): Trivo.API.Controllers.V1, Trivo.Application.DTOs.Email, Trivo.Infrastructure.Shared.Services, Trivo.Infrastructure.Persistence.Services, Trivo.Domain.Configurations, Trivo.Application.DTOs.Authentication, Trivo.Infrastructure.Shared, Trivo.Application.Behaviors (+6 more)

### Community 10 - "Trivo.Application.Interfaces.SignalR"
Cohesion: 0.07
Nodes (13): Trivo.Application.Features.Messages.Commands.SendImage, Trivo.Application.Features.Messages.Query.GetMessagePagination, Trivo.Application.Features.Chat.Query.GetChatPagination, Trivo.Application.Features.Chat, Trivo.Application.DTOs.Notifications, Trivo.Application.Features.Notifications, Trivo.Application.Interfaces.SignalR, Trivo.Application.Features.Chat.Commands.CreateChat (+5 more)

### Community 11 - "Expert"
Cohesion: 0.05
Nodes (46): Trivo.Application.Features.Experts.Commands.CreateExpert, Trivo.Application.Features.Experts, Authorize, CancellationToken, Guid, HttpPost, HttpPut, ISender (+38 more)

### Community 12 - "UserController"
Cohesion: 0.06
Nodes (40): ChangePasswordRequest, Guid, List, FilterUsersByInterestsAndSkillsRequest, UpdateBiographyRequest, UpdatePasswordRequest, IFormFile, UpdateProfilePictureRequest (+32 more)

### Community 13 - "Trivo.Infrastructure.Persistence.Migrations"
Cohesion: 0.05
Nodes (29): Trivo.Infrastructure.Persistence.Migrations, Migration, ModelSnapshot, DateTime, Guid, MigrationBuilder, Vector, DateTime (+21 more)

### Community 14 - "Notification"
Cohesion: 0.08
Nodes (29): CancellationToken, Expression, Func, Guid, Task, IGenericRepository, CancellationToken, Guid (+21 more)

### Community 15 - ".Conflict"
Cohesion: 0.08
Nodes (18): CancellationToken, Task, CancellationToken, Task, CancellationToken, Task, CancellationToken, Task (+10 more)

### Community 16 - "BaseEntity"
Cohesion: 0.13
Nodes (13): DateTime, Guid, BaseEntity, CreatedAt, Id, UpdatedAt, Guid, ICollection (+5 more)

### Community 17 - ".AddRepositories"
Cohesion: 0.18
Nodes (14): ILogger, CreateReportCommandHandler, IReportRepository, IGetExpertIdService, IGetRecruiterIdService, IUserRoleService, IConfiguration, IConnectionMultiplexer (+6 more)

### Community 18 - "ChatDto"
Cohesion: 0.08
Nodes (25): Authorize, CancellationToken, HttpPost, Task, DateTime, Guid, List, ChatDto (+17 more)

### Community 19 - "Code"
Cohesion: 0.11
Nodes (19): DateTime, Guid, Code, CodeId, CreatedAt, ExpiresAt, IsRevoked, IsUsed (+11 more)

### Community 20 - "Trivo.Domain.Enums"
Cohesion: 0.15
Nodes (7): Trivo.API.Filters, Trivo.Application.Features.Matching.Commands.UpdateMatch, Trivo.Application.Features.Matching.Commands.CreateMatch, Trivo.Domain.Enums, Trivo.Application.Features.Matching.Commands.CreateMatchRejection, Trivo.Application.Features.Matching.Query.GetMatchByUser, Trivo.Application.DTOs.Matching

### Community 21 - "MatchDetailsDto"
Cohesion: 0.12
Nodes (15): DateTime, Guid, MatchDetailsDto, Guid, UpdateMatchingCommand, Guid, ILogger, Task (+7 more)

### Community 22 - "User"
Cohesion: 0.07
Nodes (27): ICollection, Vector, User, Biography, ChatUsers, Codes, Email, Experts (+19 more)

### Community 23 - "Dependency Injection Patterns"
Cohesion: 0.05
Nodes (38): Advanced DI Patterns, Akka.DependencyInjection Reference, Akka.Hosting.TestKit, Akka.NET Actor Scope Management, Common Patterns, Conditional Registration, Contents, Factory-Based Registration (+30 more)

### Community 24 - ".Handle"
Cohesion: 0.15
Nodes (11): DateTime, Guid, AdminMatchDto, ExpertMatchDto, RecruiterMatchDto, GetLatestMatchesQuery, CancellationToken, ILogger (+3 more)

### Community 25 - ".AddServices"
Cohesion: 0.11
Nodes (23): DateTime, Guid, CodeDto, CancellationToken, Guid, Task, ICodeRepository, CancellationToken (+15 more)

### Community 26 - "AbstractValidator"
Cohesion: 0.06
Nodes (27): AbstractValidator, Trivo.Application.Features.Administrator.Commands.UnbanUser, Trivo.Application.Features.Skills.Commands.UpdateSkill, IBaseCommand, ICommand, Guid, BanUserCommand, BanUserValidator (+19 more)

### Community 27 - "IQuery"
Cohesion: 0.13
Nodes (17): IRequest, IQuery, Guid, UserDto, IEnumerable, GetLast10BannedUsersQuery, CancellationToken, IEnumerable (+9 more)

### Community 28 - "Recruiter"
Cohesion: 0.07
Nodes (40): Trivo.Application.Features.Recruiters, Trivo.Application.Features.Recruiters.Commands.CreateRecruiter, Authorize, CancellationToken, Guid, HttpPost, HttpPut, ISender (+32 more)

### Community 29 - "AdministratorRepository"
Cohesion: 0.23
Nodes (8): Administrator, CancellationToken, Guid, IEnumerable, Match, Task, User, AdministratorRepository

### Community 30 - ".Handle"
Cohesion: 0.08
Nodes (24): Trivo.Application.Features.Users.Commands.ForgotPassword, EmailResponseDto, Guid, IFormFile, List, CreateUserCommand, CancellationToken, ILogger (+16 more)

### Community 31 - ".Failure"
Cohesion: 0.20
Nodes (10): Guid, CreateNotificationDto, IEnumerable, List, NotificationMapper, CancellationToken, Guid, ILogger (+2 more)

### Community 32 - "AdminController"
Cohesion: 0.30
Nodes (11): Authorize, CancellationToken, Guid, HttpGet, HttpPost, HttpPut, IEnumerable, ISender (+3 more)

### Community 33 - "NotificationNotifier"
Cohesion: 0.24
Nodes (9): Guid, IEnumerable, Task, INotificationNotifier, Guid, IEnumerable, IHubContext, Task (+1 more)

### Community 34 - "Chat"
Cohesion: 0.08
Nodes (34): ILogger, CreateChatCommandHandler, CancellationToken, Task, CancellationToken, Guid, IEnumerable, IReadOnlyList (+26 more)

### Community 35 - "User"
Cohesion: 0.14
Nodes (11): Guid, List, ExpertAiRecommendationDto, Guid, List, RecruiterAiRecommendationDto, MatchMapper, UserHelper (+3 more)

### Community 36 - "IAdministratorRepository"
Cohesion: 0.26
Nodes (5): CancellationToken, Guid, IEnumerable, Task, IAdministratorRepository

### Community 37 - "InterestRepository"
Cohesion: 0.31
Nodes (7): CancellationToken, Guid, IEnumerable, Interest, List, Task, InterestRepository

### Community 38 - "Entity Framework Core Patterns"
Cohesion: 0.05
Nodes (38): 1. Forgetting to Update When NoTracking, 2. N+1 Query Problem, 3. Tracking Conflicts with Multiple DbContext Instances, 4. Not Using Async Consistently, 5. Querying Inside Loops, Actors / Long-Lived Objects (Factory Pattern), AppHost Configuration, Applying Migrations (+30 more)

### Community 39 - "ExceptionHandlingMiddleware"
Cohesion: 0.11
Nodes (13): Trivo.API.Middlewares, Trivo.API.Extensions, IApplicationBuilder, IEndpointRouteBuilder, IHostEnvironment, RequestDelegate, IConfiguration, IServiceCollection (+5 more)

### Community 40 - "NotificationDto"
Cohesion: 0.10
Nodes (24): HttpDelete, Authorize, CancellationToken, Guid, HttpPost, HttpPut, Task, NotificationController (+16 more)

### Community 41 - "MessageDto"
Cohesion: 0.11
Nodes (23): Authorize, CancellationToken, HttpPost, ISender, Task, MessageController, DateTime, Guid (+15 more)

### Community 42 - ".AddAiService"
Cohesion: 0.39
Nodes (4): JwtResponse, IConfiguration, IServiceCollection, DependencyInjection

### Community 43 - ".Handle"
Cohesion: 0.20
Nodes (9): Guid, IFormFile, SendImageCommand, UserId, CancellationToken, ILogger, Task, SendImageCommandHandler (+1 more)

### Community 44 - "Interest"
Cohesion: 0.09
Nodes (20): Guid, InterestByCategoryIdDto, Guid, InterestDetailsDto, Guid, CreateInterestCommand, CreateInterestValidator, Guid (+12 more)

### Community 45 - "Trivo.API.csproj"
Cohesion: 0.11
Nodes (17): Asp.Versioning.Mvc (8.1.0), AspNetCore.HealthChecks.Redis (9.0.0), Microsoft.AspNetCore.OpenApi (8.0.10), Microsoft.AspNetCore.SignalR.Core (1.2.0), Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore (8.0.10), Scalar.AspNetCore (2.17.1), Serilog.Enrichers.Environment (3.0.1), Serilog.Enrichers.Thread (4.0.0) (+9 more)

### Community 46 - "ResultT"
Cohesion: 0.04
Nodes (53): INotification, CancellationToken, Task, CancellationToken, Task, CancellationToken, Task, CancellationToken (+45 more)

### Community 47 - "IInterestRepository"
Cohesion: 0.34
Nodes (6): CancellationToken, Guid, IEnumerable, List, Task, IInterestRepository

### Community 48 - "MatchHub"
Cohesion: 0.29
Nodes (6): Hub, Exception, ILogger, IMediator, Task, MatchHub

### Community 49 - "Public API Design and Compatibility"
Cohesion: 0.06
Nodes (31): Anti-Patterns, API Approval Testing, API Change Guidelines, Benefits, Breaking Changes Disguised as Fixes, Chesterton's Fence, Deprecation Pattern, Encapsulation Patterns (+23 more)

### Community 50 - ".Handle"
Cohesion: 0.12
Nodes (13): Guid, IEnumerable, CacheKeys, List, ExpertDetailsDto, List, RecruiterDetailsDto, List (+5 more)

### Community 51 - "IUserRepository"
Cohesion: 0.22
Nodes (10): CancellationToken, Distance, Guid, IEnumerable, IReadOnlyList, List, Task, User (+2 more)

### Community 52 - ".GetByCategoriesAsync"
Cohesion: 0.23
Nodes (11): Authorize, CancellationToken, Guid, HttpGet, HttpPost, IEnumerable, ISender, List (+3 more)

### Community 53 - "ICacheService"
Cohesion: 0.08
Nodes (38): IRequestHandler, ICommandHandler, ILogger, BanUserCommandHandler, ILogger, UnbanUserCommandHandler, ILogger, UpdateExpertCommandHandler (+30 more)

### Community 54 - "CreateSkillCommand"
Cohesion: 0.23
Nodes (7): Trivo.Application.Features.Skills, Trivo.Application.Features.Skills.Commands.CreateSkill, Guid, CreateSkillCommand, CreateSkillValidator, Guid, SkillMapper

### Community 55 - ".Handle"
Cohesion: 0.19
Nodes (13): Guid, IEnumerable, GetMatchByUserQuery, CancellationToken, Dictionary, Func, Guid, IEnumerable (+5 more)

### Community 56 - ".Handle"
Cohesion: 0.09
Nodes (23): Candidates, HasOverlap, INotificationHandler, CancellationToken, ILogger, Task, UserProfileChangedEventHandler, Guid (+15 more)

### Community 57 - ".AddSkillsToUserAsync"
Cohesion: 0.19
Nodes (10): CancellationToken, Guid, List, Task, IUserSkillRepository, CancellationToken, Guid, List (+2 more)

### Community 58 - ".GetRolesAsync"
Cohesion: 0.14
Nodes (12): CancellationToken, Guid, IList, Task, Administrator, CancellationToken, Expert, Guid (+4 more)

### Community 59 - "Trivo.Infrastructure.Shared.csproj"
Cohesion: 0.15
Nodes (12): CloudinaryDotNet (1.27.0), MailKit (4.17.0), Microsoft.AspNetCore.Authentication.JwtBearer (8.0.10), Microsoft.AspNetCore.SignalR (1.2.0), Microsoft.Extensions.Options (10.0.3), Microsoft.Extensions.Options.ConfigurationExtensions (8.0.0), Microsoft.IdentityModel.Tokens (8.10.0), MimeKit (4.17.0) (+4 more)

### Community 60 - ".CreateSkillAsync"
Cohesion: 0.24
Nodes (9): Authorize, CancellationToken, HttpGet, HttpPost, IEnumerable, ISender, ProducesResponseType, Task (+1 more)

### Community 61 - "PagedResult"
Cohesion: 0.17
Nodes (12): Guid, IEnumerable, GetInterestsByCategoryIdQuery, ILogger, GetInterestsByCategoryIdQueryHandler, GetInterestsByCategoryIdValidator, IEnumerable, PagedResult (+4 more)

### Community 62 - "Database Performance Patterns"
Cohesion: 0.07
Nodes (26): Always Apply Row Limits, Architecture, AsNoTracking for Read Queries, Avoid Cartesian Explosions, Avoid N+1 Queries, Configure Default Behavior, Constrain Column Sizes, Core Principles (+18 more)

### Community 63 - "InterestWithIdDto"
Cohesion: 0.13
Nodes (15): Guid, InterestWithIdDto, IEnumerable, SearchInterestsByNameQuery, CancellationToken, IEnumerable, ILogger, Task (+7 more)

### Community 64 - "TrivoContext"
Cohesion: 0.08
Nodes (23): DbContext, DbContextOptions, DbSet, CancellationToken, ModelBuilder, Task, TrivoContext, Administrators (+15 more)

### Community 65 - "CreateMatchingCommandHandler"
Cohesion: 0.09
Nodes (22): Guid, CreateMatchingCommand, Dictionary, expertStatus, ILogger, recruiterStatus, CreateMatchingCommandHandler, Guid (+14 more)

### Community 66 - "UserInterest"
Cohesion: 0.15
Nodes (16): CancellationToken, Guid, List, Task, IUserInterestRepository, Guid, UserInterest, Interest (+8 more)

### Community 67 - "Skill"
Cohesion: 0.11
Nodes (22): ILogger, GetSkillsPaginationQueryHandler, CancellationToken, Guid, IEnumerable, List, Task, ISkillRepository (+14 more)

### Community 68 - "Slopwatch: LLM Anti-Cheat for .NET"
Cohesion: 0.09
Nodes (22): After Every Code Change, As a Global Tool, As a Local Tool (Recommended), Azure Pipelines, CI/CD Integration, Claude Code Hook Integration, Common Slop Patterns, Configuration (+14 more)

### Community 69 - "UserAiRecommendationDto"
Cohesion: 0.11
Nodes (23): Guid, List, UserAiRecommendationDto, Guid, List, GetUsersByInterestsAndSkillsQuery, CancellationToken, ILogger (+15 more)

### Community 70 - ".Validate"
Cohesion: 0.15
Nodes (10): CancellationToken, Expression, Func, Task, IValidation, CancellationToken, Expression, Func (+2 more)

### Community 71 - "UpdateInterestCommand"
Cohesion: 0.33
Nodes (5): Trivo.Application.Features.Interests.Commands.UpdateInterest, Guid, IReadOnlyList, UpdateInterestCommand, UpdateInterestValidator

### Community 72 - "Trivo.Application.DTOs.Administrator"
Cohesion: 0.18
Nodes (6): Trivo.Application.Features.Administrator.Query.GetCompletedMatchesCount, Trivo.Application.Features.Administrator.Query.GetLatestMatches, Trivo.Application.Features.Administrator.Commands.CreateAdministrator, Trivo.Application.Features.Administrator.Query.GetReportedUsersCount, Trivo.Application.Features.Administrator.Query.GetActiveUsersCount, Trivo.Application.DTOs.Administrator

### Community 73 - "CacheEntryOptions"
Cohesion: 0.16
Nodes (13): IDatabase, IReadOnlyList, CacheEntryOptions, AbsoluteExpiration, Tags, CancellationToken, Func, IConnectionMultiplexer (+5 more)

### Community 74 - "GoogleGeminiEmbeddingService"
Cohesion: 0.16
Nodes (14): ContentPart, EmbedContentResponse, EmbeddingValues, HttpClient, CancellationToken, ILogger, Task, ContentPart (+6 more)

### Community 75 - "Módulo de Matchmaking con IA — Implementación"
Cohesion: 0.14
Nodes (13): 1. Problema de negocio, 2.1 Abstracción del proveedor — `IEmbeddingService`, 2.2 Construcción del texto — `UserProfileTextBuilder`, 2.3 Cuándo se regenera el embedding — `UserProfileChangedEvent`, 2. Arquitectura, 3. Cambios de esquema (tablas), 4. El algoritmo de recomendación, 5. Qué NO se cachea, y por qué (+5 more)

### Community 76 - "Plan de implementación — Embeddings vía API externa para emparejamiento por afinidad"
Cohesion: 0.14
Nodes (13): 0. Decisión de proveedor y por qué la interfaz debe ser agnóstica, 10. Pruebas, 1. Infraestructura de base de datos (bloqueante, va primero), 2. Dominio (`Trivo.Domain`), 3. Application (`Trivo.Application`), 4. Infrastructure.Shared — implementación del proveedor, 5. Infrastructure.Persistence — columna, mapping e índice, 6. Cuándo se genera/regenera el embedding (+5 more)

### Community 77 - "IMatchRepository"
Cohesion: 0.32
Nodes (9): AcceptedIds, CancellationToken, Guid, IEnumerable, IReadOnlyList, Match, RejectedIds, Task (+1 more)

### Community 78 - "UserRecommendationHub"
Cohesion: 0.29
Nodes (5): Exception, ILogger, IMediator, Task, UserRecommendationHub

### Community 79 - "Nullable Attributes Reference"
Cohesion: 0.17
Nodes (12): Attribute Catalog, `[DoesNotReturn]`, `[DoesNotReturnIf(bool)]`, Helper methods: `MemberNotNull` and `MemberNotNullWhen`, `[MaybeNull]`, `[MemberNotNull]`, `[MemberNotNullWhen(bool)]`, `[NotNull]` (+4 more)

### Community 80 - "MatchRepository"
Cohesion: 0.34
Nodes (9): AcceptedIds, CancellationToken, Guid, IEnumerable, IReadOnlyList, Match, RejectedIds, Task (+1 more)

### Community 81 - "Modern C# Coding Standards"
Cohesion: 0.17
Nodes (12): Additional Resources, Avoid Reflection-Based Metaprogramming, Best Practices Summary, Code Organization, Composition Over Inheritance, Core Principles, DO's, DON'Ts (+4 more)

### Community 82 - "Match"
Cohesion: 0.18
Nodes (10): Guid, Match, Expert, ExpertId, ExpertStatus, MatchStatus, RecruiterId, RecruiterStatus (+2 more)

### Community 83 - ".ValidateEmailAsync"
Cohesion: 0.22
Nodes (8): IServiceCollection, CancellationToken, Task, IEmailValidationService, CancellationToken, ILogger, Task, EmailValidationService

### Community 84 - ".Handle"
Cohesion: 0.21
Nodes (8): Guid, InterestDto, GetInterestsPaginationQuery, CancellationToken, ILogger, Task, GetInterestsPaginationQueryHandler, GetInterestsPaginationValidator

### Community 85 - "Plantillas copy-paste — feature CQRS de Trivo"
Cohesion: 0.18
Nodes (10): 1. DTO, 2. Command (con respuesta) — ejemplo real: `CreateInterestCommand`, 3. Validator (co-ubicado con el Command), 4. Handler — orquesta repos + UnitOfWork, nunca lanza excepciones de negocio, 5. Query con paginación + cache — ejemplo real: `GetInterestsPaginationQuery`, 6. Mapper — extensiones estáticas, una clase por feature, 7. Repositorio — patrón MANDATORIO para entidades nuevas (extiende `IGenericRepository<T>`), 8. DI — registrar el repo nuevo (+2 more)

### Community 86 - "CloudinaryService"
Cohesion: 0.24
Nodes (8): CloudinarySetting, CloudinaryUrl, CancellationToken, IOptions, Stream, Task, CloudinaryService, Cloudinary

### Community 87 - "SkillWithIdDto"
Cohesion: 0.13
Nodes (16): Guid, SkillWithIdDto, IEnumerable, SearchSkillsByNameQuery, CancellationToken, IEnumerable, ILogger, Task (+8 more)

### Community 88 - "Polyfilling the nullable attributes for older target frameworks"
Cohesion: 0.20
Nodes (10): Candidate packages (evaluate, do not default to one), Decision rules, File-level `#nullable` directives, Incremental Adoption Strategy, Is a polyfill needed at all?, Options and tradeoffs, Polyfilling the nullable attributes for older target frameworks, Project-level (+2 more)

### Community 89 - "Administrator"
Cohesion: 0.20
Nodes (10): Administrator, Biography, Email, FirstName, IsActive, LastName, LinkedIn, PasswordHash (+2 more)

### Community 90 - "IRealTimeNotifier"
Cohesion: 0.24
Nodes (9): Guid, IEnumerable, Task, IRealTimeNotifier, Guid, IEnumerable, IHubContext, Task (+1 more)

### Community 91 - "CreateInterestCategoryCommandHandler.cs"
Cohesion: 0.27
Nodes (4): Trivo.Application.DTOs.InterestCategories, Trivo.Application.Features.InterestCategories.Commands.CreateInterestCategory, Trivo.Application.Features.InterestCategories.Query.GetPaginatedInterestCategories, Trivo.Application.Features.InterestCategories

### Community 92 - ".Handle"
Cohesion: 0.14
Nodes (12): IHttpContextAccessor, IPipelineBehavior, IValidator, CancellationToken, RequestHandlerDelegate, Task, AuthorizationBehavior, CancellationToken (+4 more)

### Community 93 - "Trivo.Application.csproj"
Cohesion: 0.20
Nodes (9): BCrypt.Net-Next (4.0.3), FluentValidation (11.10.0), FluentValidation.DependencyInjectionExtensions (11.10.0), Microsoft.Extensions.DependencyInjection.Abstractions (8.0.2), net8.0, MediatR (12.2.0), Microsoft.Extensions.Caching.StackExchangeRedis (8.0.10), Serilog.AspNetCore (8.0.0) (+1 more)

### Community 94 - "C# Nullable Reference Types"
Cohesion: 0.20
Nodes (10): API Design Rules (Signatures), C# Nullable Reference Types, Core Goals, Generation Checklist (Summary), Project Configuration, Public API compatibility for libraries, Reference Files, References (+2 more)

### Community 95 - "IQueryHandler"
Cohesion: 0.40
Nodes (5): IQueryHandler, ILogger, GetUserDetailsQueryHandler, ILogger, GetUserProfilePictureQueryHandler

### Community 96 - "NRT Migration Playbook Reference"
Cohesion: 0.22
Nodes (6): Full Generation Checklist, Gradual annotation of a library, Legacy and Unannotated API Interop, NRT Migration Playbook Reference, Trust annotated libraries, Wrapping unannotated or legacy APIs

### Community 97 - ".MapToInterests"
Cohesion: 0.47
Nodes (4): ICollection, List, User, UserMapper

### Community 98 - "IChatHub"
Cohesion: 0.33
Nodes (4): Guid, IEnumerable, Task, IChatHub

### Community 99 - "Anti-Patterns to Avoid"
Cohesion: 0.25
Nodes (8): Anti-Patterns to Avoid, Don't: Block on async code, Don't: Create deep inheritance hierarchies, Don't: Forget CancellationToken in async methods, Don't: Return List<T> when you mean IReadOnlyList<T>, Don't: Use byte[] when ReadOnlySpan<byte> works, Don't: Use classes for value objects, Don't: Use mutable DTOs

### Community 100 - ".Handle"
Cohesion: 0.29
Nodes (7): Guid, GetMessagePaginationQuery, CancellationToken, ILogger, Task, GetMessagePaginationQueryHandler, GetMessagePaginationValidator

### Community 101 - "Report"
Cohesion: 0.20
Nodes (9): Guid, Report, Message, MessageId, Note, ReportedById, ReportId, ReportStatus (+1 more)

### Community 102 - "ChatHub"
Cohesion: 0.28
Nodes (6): Exception, Guid, ILogger, IMediator, Task, ChatHub

### Community 103 - "IMatchHub"
Cohesion: 0.43
Nodes (4): Guid, IEnumerable, Task, IMatchHub

### Community 104 - "ResultFilter"
Cohesion: 0.25
Nodes (7): ActionExecutingContext, ActionExecutionDelegate, IAsyncActionFilter, ErrorType, ILogger, Task, ResultFilter

### Community 105 - "Anti-Patterns and Reflection Avoidance"
Cohesion: 0.29
Nodes (3): Anti-Patterns and Reflection Avoidance, Contents, UnsafeAccessorAttribute (.NET 8+)

### Community 106 - ".GetUserId"
Cohesion: 0.40
Nodes (3): Guid, HttpContext, AuthenticatedUserHelper

### Community 107 - "Avoid Reflection-Based Metaprogramming"
Cohesion: 0.29
Nodes (7): Avoid Reflection-Based Metaprogramming, Banned Libraries, Benefits of Explicit Mappings, Complex Mappings, Use Explicit Mapping Methods Instead, When Reflection is Acceptable, Why Reflection Mapping Fails

### Community 108 - "Trivo"
Cohesion: 0.20
Nodes (9): Building the Docker image, Health checks, Logging, Prerequisites, Project structure, Running locally, Running the full stack in "production" mode, Trivo (+1 more)

### Community 109 - ".CreateMatchAsync"
Cohesion: 0.36
Nodes (7): Authorize, CancellationToken, HttpPost, HttpPut, ISender, Task, MatchController

### Community 110 - "Performance and API Design Patterns"
Cohesion: 0.29
Nodes (6): Accept Abstractions, Return Appropriately Specific, API Design Principles, Contents, Method Signatures Best Practices, Performance and API Design Patterns, Span<T> and Memory<T> for Zero-Allocation Code

### Community 111 - "Value Objects and Pattern Matching"
Cohesion: 0.29
Nodes (7): Constraint-Enforcing Value Objects, Contents, No Implicit Conversions, Pattern Matching (C# 8-12), TypeConverter Support for Configuration Binding, Value Objects and Pattern Matching, Value Objects as readonly record struct

### Community 112 - "IUserOwnedRequest"
Cohesion: 0.10
Nodes (15): Trivo.Application.Features.Users.Commands.UpdateBiography, Trivo.Application.Features.Users.Commands.UpdateProfilePicture, Guid, IUserOwnedRequest, UserId, Guid, UpdateBiographyCommand, UpdateBiographyValidator (+7 more)

### Community 113 - "GetLatestUsersPagedQueryHandler.cs"
Cohesion: 0.29
Nodes (3): Trivo.Application.Features.Administrator.Query.GetLatestUsersPaged, Trivo.Application.Features.Users, Trivo.Application.Features.Matching

### Community 114 - "MatchDto"
Cohesion: 0.20
Nodes (12): DateTime, Guid, MatchDto, Guid, IEnumerable, Task, IMatchNotifier, Guid (+4 more)

### Community 115 - "GetActiveUsersCountQueryHandler"
Cohesion: 0.36
Nodes (6): ActiveUsersCountDto, GetActiveUsersCountQuery, CancellationToken, ILogger, Task, GetActiveUsersCountQueryHandler

### Community 116 - ".Handle"
Cohesion: 0.36
Nodes (6): CompletedMatchesCountDto, GetCompletedMatchesCountQuery, CancellationToken, ILogger, Task, GetCompletedMatchesCountQueryHandler

### Community 117 - "GetReportedUsersCountQueryHandler"
Cohesion: 0.36
Nodes (6): ReportedUsersCountDto, GetReportedUsersCountQuery, CancellationToken, ILogger, Task, GetReportedUsersCountQueryHandler

### Community 118 - "ICloudinaryService"
Cohesion: 0.43
Nodes (4): CancellationToken, Stream, Task, ICloudinaryService

### Community 119 - ".GetExpertIdAsync"
Cohesion: 0.25
Nodes (6): CancellationToken, Guid, Task, CancellationToken, Guid, Task

### Community 120 - ".GetRecruiterIdAsync"
Cohesion: 0.25
Nodes (6): CancellationToken, Guid, Task, CancellationToken, Guid, Task

### Community 121 - "UserSkill"
Cohesion: 0.29
Nodes (6): Guid, UserSkill, Skill, SkillId, User, UserId

### Community 122 - "EmailSetting"
Cohesion: 0.25
Nodes (7): EmailSetting, DisplayName, EmailFrom, SmtpHost, SmtpPassword, SmtpPort, SmtpUser

### Community 123 - "Trivo.Infrastructure.Persistence.csproj"
Cohesion: 0.22
Nodes (8): Microsoft.EntityFrameworkCore (8.0.10), Npgsql.EntityFrameworkCore.PostgreSQL (8.0.10), Pgvector.EntityFrameworkCore (0.2.2), StackExchange.Redis (2.7.27), net8.0, Microsoft.EntityFrameworkCore.Design (8.0.10), Microsoft.Extensions.Caching.StackExchangeRedis (8.0.10), Microsoft.NET.Sdk

### Community 124 - "The `field` Keyword (C# 14 / .NET 10) and Nullability"
Cohesion: 0.33
Nodes (6): Lazy-initialized property (null-resilient getter), Non-resilient getter escape hatch, Null-resilience, Other notes, Setter and constructor analysis, The `field` Keyword (C# 14 / .NET 10) and Nullability

### Community 125 - "MessageStatus"
Cohesion: 0.29
Nodes (6): MessageStatus, Deleted, Delivered, Seen, Sent, Updated

### Community 126 - "Trivo.Domain.csproj"
Cohesion: 0.29
Nodes (3): Pgvector (0.3.0), net8.0, Microsoft.NET.Sdk

### Community 127 - "OpenAiEmbeddingService"
Cohesion: 0.33
Nodes (5): EmbeddingClient, CancellationToken, ILogger, Task, OpenAiEmbeddingService

### Community 128 - ".ToEntity"
Cohesion: 0.33
Nodes (4): Trivo.Application.Features.Administrator.Commands.CreateAdministrator.Mappings, Administrator, CreateAdminCommand, AdminMappingExtensions

### Community 129 - "UserMappingExtensions.cs"
Cohesion: 0.33
Nodes (4): Trivo.Application.Features.Users.Commands.CreateUser.Mappings, CreateUserCommand, User, UserMappingExtensions

### Community 130 - "SkillDto"
Cohesion: 0.17
Nodes (8): DateTime, Guid, SkillDto, GetSkillsPaginationQuery, CancellationToken, Task, GetSkillsPaginationValidator, IEnumerable

### Community 131 - "ErrorType"
Cohesion: 0.33
Nodes (5): ErrorType, Conflict, Failure, NotFound, Unauthorized

### Community 132 - "NotificationType"
Cohesion: 0.33
Nodes (5): NotificationType, Alert, Match, Message, Reminder

### Community 133 - "CustomUserIdProvider"
Cohesion: 0.40
Nodes (3): HubConnectionContext, IUserIdProvider, CustomUserIdProvider

### Community 134 - "ExpertStatus"
Cohesion: 0.40
Nodes (4): ExpertStatus, Completed, Pending, Rejected

### Community 135 - "Level"
Cohesion: 0.40
Nodes (4): Level, Advanced, Basic, Intermediate

### Community 136 - "MatchStatus"
Cohesion: 0.40
Nodes (4): MatchStatus, Completed, Pending, Rejected

### Community 137 - "MessageType"
Cohesion: 0.40
Nodes (4): MessageType, File, Image, Text

### Community 138 - "RecruiterStatus"
Cohesion: 0.40
Nodes (4): RecruiterStatus, Completed, Pending, Rejected

### Community 139 - "UserStatus"
Cohesion: 0.40
Nodes (4): UserStatus, Active, Banned, Inactive

### Community 141 - "ChatType"
Cohesion: 0.50
Nodes (3): ChatType, Group, Private

### Community 142 - "MatchFault"
Cohesion: 0.50
Nodes (3): MatchFault, Expert, Recruiter

### Community 143 - "JwtSetting"
Cohesion: 0.33
Nodes (5): JwtSetting, Audience, DurationInMinutes, Issuer, Key

### Community 144 - "ReportStatus"
Cohesion: 0.50
Nodes (3): ReportStatus, Pending, Resolved

### Community 146 - "Core Nullability Model"
Cohesion: 0.40
Nodes (5): Core Nullability Model, Non-nullable vs nullable, Null-forgiving operator (`!`), Null-state analysis (flow), Reorganize code before suppressing warnings

### Community 147 - "Arquitectura CQRS de Trivo — mandato para nuevas features"
Cohesion: 0.40
Nodes (4): Arquitectura CQRS de Trivo — mandato para nuevas features, Checklist para agregar una feature nueva ("{Feature}" / "{Action}" / "{Entity}"), Flujo de referencia rápido, Reglas duras (no negociables)

### Community 148 - "Composition and Error Handling"
Cohesion: 0.40
Nodes (5): Composition and Error Handling, Composition Over Inheritance, Contents, Result Type Pattern, Testing Patterns

### Community 149 - "Language Patterns"
Cohesion: 0.40
Nodes (5): Language Patterns, Nullable Reference Types (C# 8+), Pattern Matching (C# 8-12), Records for Immutable Data (C# 9+), Value Objects as readonly record struct

### Community 150 - "CacheProfiles"
Cohesion: 0.40
Nodes (4): CacheProfiles, Cold, Hot, Warm

### Community 151 - "AiSetting"
Cohesion: 0.40
Nodes (4): AiSetting, ApiKey, EmbeddingModel, Provider

### Community 152 - "Known Static-Analysis Limitations and Safe Patterns"
Cohesion: 0.50
Nodes (4): Arrays and default values, Known Static-Analysis Limitations and Safe Patterns, Other limitations to keep in mind, Structs with non-nullable fields

### Community 153 - "Conditional postconditions: `NotNullWhen`, `MaybeNullWhen`, `NotNullIfNotNull`"
Cohesion: 0.50
Nodes (4): Conditional postconditions: `NotNullWhen`, `MaybeNullWhen`, `NotNullIfNotNull`, `[MaybeNullWhen(bool)]`, `[NotNullIfNotNull(string)]`, `[NotNullWhen(bool)]`

### Community 155 - "Preconditions: `AllowNull` and `DisallowNull`"
Cohesion: 0.67
Nodes (3): `[AllowNull]`, `[DisallowNull]`, Preconditions: `AllowNull` and `DisallowNull`

### Community 156 - "Performance Patterns"
Cohesion: 0.67
Nodes (3): Async/Await Best Practices, Performance Patterns, Span<T> and Memory<T>

## Knowledge Gaps
- **533 isolated node(s):** `net8.0`, `Asp.Versioning.Mvc (8.1.0)`, `AspNetCore.HealthChecks.Redis (9.0.0)`, `MediatR (12.2.0)`, `Microsoft.AspNetCore.OpenApi (8.0.10)` (+528 more)
  These have ≤1 connection - possible missing edges or undocumented components.
- **4 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `ResultT` connect `ResultT` to `Message`, `InterestCategory`, `SkillDto`, `AuthenticationService`, `Expert`, `UserController`, `.Conflict`, `ChatDto`, `.Handle`, `.AddServices`, `AbstractValidator`, `IQuery`, `Recruiter`, `.Handle`, `.Failure`, `AdminController`, `Chat`, `NotificationDto`, `MessageDto`, `.Handle`, `.Handle`, `.GetByCategoriesAsync`, `ICacheService`, `.Handle`, `.Handle`, `.CreateSkillAsync`, `InterestWithIdDto`, `UserAiRecommendationDto`, `.ValidateEmailAsync`, `.Handle`, `SkillWithIdDto`, `IQueryHandler`, `.Handle`, `.CreateMatchAsync`, `GetActiveUsersCountQueryHandler`, `.Handle`, `GetReportedUsersCountQueryHandler`?**
  _High betweenness centrality (0.148) - this node is a cross-community bridge._
- **Why does `TrivoContext` connect `TrivoContext` to `UserRepository`, `Trivo.Application.Abstractions.Messages`, `Message`, `InterestCategory`, `Expert`, `Notification`, `.AddRepositories`, `Code`, `Recruiter`, `AdministratorRepository`, `Chat`, `User`, `InterestRepository`, `ExceptionHandlingMiddleware`, `Interest`, `ICacheService`, `.AddSkillsToUserAsync`, `UserInterest`, `Skill`, `.Validate`, `MatchRepository`, `Match`, `Administrator`, `Report`, `UserSkill`?**
  _High betweenness centrality (0.059) - this node is a cross-community bridge._
- **Why does `Trivo.Domain.Models` connect `Trivo.Domain.Models` to `Trivo.Application.Abstractions.Messages`, `Message`, `InterestCategory`, `Trivo.Application.DTOs.Users`, `Trivo.Infrastructure.Persistence.Configurations`, `CreateAdminCommandHandler`, `Trivo.Application.Interfaces.Services`, `Trivo.Application.Interfaces.SignalR`, `Expert`, `Notification`, `BaseEntity`, `Code`, `Trivo.Domain.Enums`, `UserInterestConfig`, `Recruiter`, `Chat`, `User`, `CreateSkillCommand`, `.Handle`, `.AddSkillsToUserAsync`, `UserInterest`, `Skill`, `Match`, `CreateInterestCategoryCommandHandler.cs`, `Report`, `GetLatestUsersPagedQueryHandler.cs`, `UserSkill`?**
  _High betweenness centrality (0.058) - this node is a cross-community bridge._
- **What connects `net8.0`, `Asp.Versioning.Mvc (8.1.0)`, `AspNetCore.HealthChecks.Redis (9.0.0)` to the rest of the system?**
  _533 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Trivo.Application.Abstractions.Messages` be split into smaller, more focused modules?**
  _Cohesion score 0.08116883116883117 - nodes in this community are weakly interconnected._
- **Should `Message` be split into smaller, more focused modules?**
  _Cohesion score 0.05010351966873706 - nodes in this community are weakly interconnected._
- **Should `InterestCategory` be split into smaller, more focused modules?**
  _Cohesion score 0.05478750640040963 - nodes in this community are weakly interconnected._