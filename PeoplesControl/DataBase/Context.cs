using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using DataBase.Models;

namespace DataBase
{
    public class Context: DbContext, IWebContext
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
            //HCS
            modelBuilder.Entity<HCS>(entity =>
            {
                entity.HasOne(d => d.ResponsiblePerson)
                    .WithMany()
                    .HasForeignKey(d => d.ResponsiblePersonId); 
                
                entity.HasOne(d => d.Avatar)
                    .WithMany()
                    .HasForeignKey(d => d.AvatarId);

                entity.HasOne(d => d.HCSType)
                    .WithMany()
                    .HasForeignKey(d => d.HCSTypeId);
            });
            
            modelBuilder.Entity<HCSByProblemCategory>(entity =>
            {
                entity.HasOne(d => d.HCS)
                    .WithMany()
                    .HasForeignKey(d => d.HCSId); 
                
                entity.HasOne(d => d.ProblemCategory)
                    .WithMany()
                    .HasForeignKey(d => d.ProblemCategoryId);
            });

            modelBuilder.Entity<HCSByRegion>(entity =>
            {
                entity.HasOne(d => d.HCS)
                    .WithMany()
                    .HasForeignKey(d => d.HCSId); 
                
                entity.HasOne(d => d.Region)
                    .WithMany()
                    .HasForeignKey(d => d.RegionId);
            });

            modelBuilder.Entity<HCSTask>(entity =>
            {
                entity.HasOne(d => d.HCS)
                    .WithMany()
                    .HasForeignKey(d => d.HCSId); 
                
                entity.HasOne(d => d.HCSTaskType)
                    .WithMany()
                    .HasForeignKey(d => d.HCSTaskTypeId); 
                
                entity.HasOne(d => d.Report)
                    .WithMany()
                    .HasForeignKey(d => d.ReportId);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasOne(d => d.City)
                    .WithMany()
                    .HasForeignKey(d => d.CityId);
            });

            // Mailing
            modelBuilder.Entity<MailingQueue>(entity =>
            {
                entity.HasOne(d => d.MailingStatus)
                    .WithMany()
                    .HasForeignKey(d => d.MailingStatusId);
            });

            // Reports
            modelBuilder.Entity<DraftReport>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<DraftReportByProblemCategory>(entity =>
            {
                entity.HasOne(d => d.DraftReport)
                    .WithMany()
                    .HasForeignKey(d => d.DraftReportId);

                entity.HasOne(d => d.ProblemCategory)
                    .WithMany()
                    .HasForeignKey(d => d.ProblemCategoryId);
            });

            modelBuilder.Entity<MediaData>(entity =>
            {
                entity.HasOne(d => d.Type)
                    .WithMany()
                    .HasForeignKey(d => d.TypeId);

                entity.HasOne(d => d.Report)
                    .WithMany()
                    .HasForeignKey(d => d.ReportId);

                entity.HasOne(d => d.DraftReport)
                    .WithMany()
                    .HasForeignKey(d => d.DraftReportId);
            });
            
            modelBuilder.Entity<ProblemCategory>(entity =>
            {
                entity.HasOne(d => d.Avatar)
                    .WithMany()
                    .HasForeignKey(d => d.AvatarId);
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasOne(d => d.Moderator)
                    .WithMany()
                    .HasForeignKey(d => d.ModeratorId);

                entity.HasOne(d => d.RelationReport)
                    .WithMany()
                    .HasForeignKey(d => d.RelationReportId);

                entity.HasOne(d => d.Status)
                    .WithMany()
                    .HasForeignKey(d => d.StatusId);

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<ReportByProblemCategory>(entity =>
            {
                entity.HasOne(d => d.ProblemCategory)
                    .WithMany()
                    .HasForeignKey(d => d.ProblemCategoryId);

                entity.HasOne(d => d.Report)
                    .WithMany()
                    .HasForeignKey(d => d.ReportId);
            });

            modelBuilder.Entity<ReportView>(entity =>
            {
                entity.HasOne(d => d.Report)
                    .WithMany()
                    .HasForeignKey(d => d.ReportId);

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId);
            });

            // Транспорт
            modelBuilder.Entity<DriverOnRoute>(entity =>
            {
                entity.HasOne(d => d.Driver)
                    .WithMany()
                    .HasForeignKey(d => d.DriverId);

                entity.HasOne(d => d.TransportRoute)
                    .WithMany()
                    .HasForeignKey(d => d.TransportRouteId);
            });

            modelBuilder.Entity<StopOnRoute>(entity =>
            {
                entity.HasOne(d => d.TransportStop)
                    .WithMany()
                    .HasForeignKey(d => d.TransportStopId);

                entity.HasOne(d => d.TransportRoute)
                    .WithMany()
                    .HasForeignKey(d => d.TransportRouteId);
            });

            modelBuilder.Entity<TransportStop>(entity =>
            {
                entity.HasOne(d => d.TransportCompany)
                    .WithMany()
                    .HasForeignKey(d => d.TransportCompanyId);

                entity.HasOne(d => d.City)
                    .WithMany()
                    .HasForeignKey(d => d.CityId);
            });
            modelBuilder.Entity<TransportStopAction>(entity =>
            {
                entity.HasOne(d => d.StopOnRoute)
                    .WithMany()
                    .HasForeignKey(d => d.StopOnRouteId);
            });
            //User
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasOne(d => d.City)
                    .WithMany()
                    .HasForeignKey(d => d.CityId);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId);

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasOne(d => d.District)
                    .WithMany()
                    .HasForeignKey(d => d.DistrictId);

                entity.HasOne(d => d.Creation)
                    .WithMany()
                    .HasForeignKey(d => d.CreationId);
            });

            modelBuilder.Entity<ActionMeta>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(d => d.UserProfile)
                    .WithMany()
                    .HasForeignKey(d => d.UserProfileId);
            });

            modelBuilder.Entity<City>().HasData(
                new City[] {
                    new City() 
                    {
                        Id = 1, 
                        Name = "Донецк" 
                    },
                    new City() 
                    { 
                        Id = 2, 
                        Name = "Макеевка" 
                    }
                }
            );

            modelBuilder.Entity<District>().HasData(
                    new District() 
                    { 
                        Id = 1, 
                        Name = "Червоногвардейка",
                        CityId = 2
                    }
            );

            // Создание Супер Аккаунта

            ActionMeta SupperCreation = new ActionMeta()
            {
                Id = 1,
                UserId = null,
                Date = DateTime.Now
            };

            UserProfile SupperProfile = new UserProfile()
            {
                Id = 1,
                Name = "Supper",
                Surname = "Account",
                CreationId = 1,
                IsBlock = false,
                NotifyByEmail = false,
                NotifyBySMS = false,
                RequestAnonymity = false,
                DistrictId = 1
            };

            User SupperUser = new User()
            {
                Id = 1,
                UserProfileId = 1,
                Login = "supper",
                SaltPassword = Properties.Resources.SaltPassword,
                SaltValue = Properties.Resources.SaltValue
            };

            modelBuilder.Entity<ActionMeta>().HasData(
                SupperCreation
            );

            modelBuilder.Entity<UserProfile>().HasData(
                SupperProfile
            );

            modelBuilder.Entity<User>().HasData(
                SupperUser
            );
        }
    }
}
