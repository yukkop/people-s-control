using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DataBase
{
    public interface IWebContext
    {
        //blue
        public DbSet<HCS> HCSs { get; set; }
        public DbSet<HCSByProblemCategory> HCSsByProblemCategories { get; set; }
        public DbSet<HCSByRegion> HCSsByRegions { get; set; }
        public DbSet<HCSTask> HCSTasks { get; set; }
        public DbSet<HCSType> HCSTypes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<HCSTaskType> HCSTaskTypes { get; set; }

        //gray
        public DbSet<ActionMeta> ActionMeta { get; set; }
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
        public DbSet<UserProfile> UsersProfiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }
        //yellow
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverOnRoute> DriversOnRoutes { get; set; }
        public DbSet<StopOnRoute> StopsOnRoutes { get; set; }
        public DbSet<TransportCompany> TransportCompanies { get; set; }
        public DbSet<TransportRoute> TransportRoutes { get; set; }
        public DbSet<TransportStop> TransportStops { get; set; }
        public DbSet<TransportStopAction> TransportStopActions { get; set; }
        public System.Threading.Tasks.Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
        public Exception SaveChanges();
        public bool Update<TEntity>(TEntity entity);

    }
}
