using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using DataBase.Models;

namespace DataBase
{
    public class Context : DbContext
    {
        string _connectionString;
        public Context(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public Context(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }
        //blue
        public DbSet<HCS> HCSs { get; set; }
        public DbSet<HCSByProblemCategory> HCSsByProblemCategories { get; set; }
        public DbSet<HCSByRegion> HCSsByRegions { get; set; }
        public DbSet<HCSTask> HCSTasks { get; set; }
        public DbSet<HCSType> HCSTypes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<SupportedRegion> SupportedRegions { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }

        //gray
        public DbSet<ActionMeta> ActionsMeta { get; set; }
        //green
        public DbSet<MailingQueue> MailingQueues { get; set; }
        public DbSet<MailingStatus> MailingStatuses { get; set; }

        //magenta
        public DbSet<DraftReport> DraftReports { get; set; }
        public DbSet<DraftReportByProblemCategory> DraftReportsByProblemCategories { get; set; }
        public DbSet<MediaData> MediaDatas { get; set; }
        public DbSet<MediaDataType> MediaDataTypes { get; set; }
        public DbSet<ProblemCategory> ProblemCategories { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportByProblemCategory> ReportsByProblemCategories { get; set; }
        public DbSet<ReportStatus> ReportStatuses { get; set; }
        public DbSet<ReportView> ReportsViews { get; set; }
        //purple
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }
        //yellow
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverRoute> DriversRoutes { get; set; }
        public DbSet<StopOnRoute> StopsOnRoutes { get; set; }
        public DbSet<TransportCompany> TransportCompanies { get; set; }
        public DbSet<TransportRoute> TransportRoutes { get; set; }
        public DbSet<TransportStop> TransportStops { get; set; }
        public DbSet<TransportStopAction> TransportStopActions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        public async System.Threading.Tasks.Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                //handle with some logger
                return false;
            }

            return true;
        }
        public bool SaveChanges()
        {
            try
            {
                base.SaveChanges();
            }
            catch (Exception e)
            {
                //handle with some logger
                Console.WriteLine(e);
                return false;
            }

            return true;
        }
        public bool Update<TEntity>(TEntity entity)
        {
            try
            {
                base.Update(entity);
            }
            catch (Exception e)
            {
                //handle with some logger
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
