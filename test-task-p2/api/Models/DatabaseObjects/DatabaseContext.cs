using Microsoft.EntityFrameworkCore;
using System;

namespace api.Models.DatabaseObjects
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().HasMany<WorkShift>().WithOne(x => x.Worker).HasForeignKey(x => x.WorkerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Worker>().HasMany<Specialty>().WithOne(x => x.Worker).HasForeignKey(x => x.WorkerId);
            modelBuilder.Entity<Profession>().HasMany<Specialty>().WithOne(x => x.Profession).HasForeignKey(x => x.ProfessionId);

            InitialData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        protected void InitialData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profession>().HasData(new Profession[]
           {
            new Profession
            {
                Id = 1,
                Name = "Терапевт",
                Description = "Терапевт"
            },
               new Profession
            {
                Id = 2,
                Name = "Кардиолог",
                Description = "Кардиолог"
            },
               new Profession
            {
                Id = 3,
                Name = "Офтальмолог",
                Description = "Офтальмолог"
            },
               new Profession
            {
                Id = 4,
                Name = "Аллерголог",
                Description = "Аллерголог"
            },
                new Profession
            {
                Id = 5,
                Name = "Водитель автобуса",
                Description = "Водитель автобуса"
            },
                new Profession
            {
                Id = 6,
                Name = "Пилот самолета",
                Description = "Пилот самолета"
            }});

            modelBuilder.Entity<Worker>().HasData(new Worker[]
          {
            new Worker
            {
                Id = 1,
                Surname = "Иванов",
                Name = "Иван",
                Thirdname = "Иванович",
                Birthday = DateTime.Now,
                Snils = "snils1"
            },
             new Worker
            {
                Id = 2,
                Surname = "Surname",
                Name = "Name",
                Thirdname = "Thirdname",
                Birthday = DateTime.Now,
                Snils = "snils1"
            },
              new Worker
            {
                Id = 3,
                Surname = "Doe",
                Name = "John",
                Thirdname = "Bismark",
                Birthday = DateTime.Now,
                Snils = "snils1"
            }
          });

            modelBuilder.Entity<WorkShift>().HasData(new WorkShift[]
          {
              new WorkShift {
                  Id = 1,
                  Name = "Смена 1",
                  Description = "Смена 1",
                  StartDate = DateTime.Now,
                  EndDate = DateTime.Now.AddHours(2),
                  WorkerId = 2
              },
              new WorkShift {
                  Id = 2,
                  Name = "Смена 2",
                  Description = "Смена 2",
                  StartDate = DateTime.Now.AddHours(3),
                  EndDate = DateTime.Now.AddHours(5),
                  WorkerId = 2
              },
              new WorkShift {
                  Id = 3,
                  Name = "Смена 3",
                  Description = "Смена 3",
                  StartDate = DateTime.Now,
                  EndDate = DateTime.Now.AddHours(2),
                  WorkerId = 2
              },
              new WorkShift {
                  Id = 4,
                  Name = "Смена 3",
                  Description = "Смена 3",
                  StartDate = DateTime.Now.AddHours(3),
                  EndDate = DateTime.Now.AddHours(5),
                  WorkerId = 2
              },
               new WorkShift {
                  Id = 5,
                  Name = "Смена 4",
                  Description = "Смена 4",
                  StartDate = DateTime.Now,
                  EndDate = DateTime.Now.AddHours(2),
                  WorkerId = 2
              },
              new WorkShift {
                  Id = 6,
                  Name = "Смена 5",
                  Description = "Смена 5",
                  StartDate = DateTime.Now.AddHours(3),
                  EndDate = DateTime.Now.AddHours(5),
                  WorkerId = 3
              }
          });

            modelBuilder.Entity<Specialty>().HasData(new Specialty[]
           {
               new Specialty {
                  Id = 1,
                  ProfessionId = 1,
                  WorkerId = 1
              },
                new Specialty {
                  Id = 2,
                  ProfessionId = 2,
                  WorkerId = 1
              },
                new Specialty {
                  Id = 3,
                  ProfessionId = 3,
                  WorkerId = 2
              },
                new Specialty {
                  Id = 4,
                  ProfessionId = 4,
                  WorkerId = 2
              },
                new Specialty {
                  Id = 5,
                  ProfessionId = 5,
                  WorkerId = 3
              },
                new Specialty {
                  Id = 6,
                  ProfessionId = 6,
                  WorkerId = 3
              }
           });
        }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<WorkShift> WorkShifts { get; set; }
        public DbSet<Worker> Workers { get; set; }
    }
}
