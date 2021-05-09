using DataAccess.Common.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Common
{
    /// <summary>
    /// MainContext
    /// </summary>
    public partial class MainContext : DbContext, IMainContext
    {
        public int NumberOfRecordPage { set; get; }


        public MainContext() { }
        public MainContext(string connectionString) : base(GetOptions(connectionString)) { }
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        public virtual DbSet<Flows> Flows { get; set; }
        public virtual DbSet<Steps> Steps { get; set; }
        public virtual DbSet<Fields> Fields { get; set; }
        public virtual DbSet<Secuences> Secuences { get; set; }
        public virtual DbSet<StepsNext> StepsNext { get; set; }
        public virtual DbSet<StepsInFields> StepsInFields { get; set; }


        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Flows>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasComment("Contains Identity Flow");

                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .HasComment("Contains  Name Flow")
                    .IsRequired(true);
            });

            modelBuilder.Entity<Steps>(entity =>
            {
                entity.Property(e => e.Id).HasComment("Contains Identity Steps");

                entity.Property(e => e.Code)
                    .IsUnicode(false)
                    .IsRequired(true)
                    .HasComment("Contains Code Step");

                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .IsRequired(true)
                    .HasComment("Contains Name Step");
            });

            modelBuilder.Entity<Fields>(entity =>
            {
                entity.Property(e => e.Id).HasComment("Contains Identity Fields");

                entity.Property(e => e.Code)
                    .IsUnicode(false)
                    .IsRequired(true)
                    .HasComment("Contains Code Fields");

                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .IsRequired(true)
                    .HasComment("Contains Name Fields");

                entity.HasOne(d => d.IdTypeFieldNavigation)
                    .WithMany(p => p.Fields)
                    .HasForeignKey(d => d.IdTypeField)
                    .IsRequired(true)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fields_TypeFields");
            });

            modelBuilder.Entity<FieldsByUser>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.IdField });

                entity.Property(e => e.Value)
                    .IsRequired(true)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFieldNavigation)
                    .WithMany(p => p.FieldsByUser)
                    .HasForeignKey(d => d.IdField)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FieldsByUser_Fields");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.FieldsByUser)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FieldsByUser_Users");
            });

            modelBuilder.Entity<Secuences>(entity =>
            {
                entity.HasKey(e => new { e.IdFlow, e.IdStep });

                entity.HasIndex(e => e.IdStep);

                entity.Property(e => e.IdFlow)
                    .HasComment("Contains Identity Flow");

                entity.Property(e => e.IdStep)
                    .HasComment("Contains Identity Steps");

                entity.Property(e => e.IsFirts)
                    .HasComment("Indicate is first");

                entity.HasOne(d => d.IdFlowNavigation)
                    .WithMany(p => p.Secuences)
                    .HasForeignKey(d => d.IdFlow)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Secuences_Flows");

                entity.HasOne(d => d.IdStepNavigation)
                    .WithMany(p => p.Secuences)
                    .HasForeignKey(d => d.IdStep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Secuences_Steps");
            });

            modelBuilder.Entity<StepsNext>(entity =>
            {
                entity.HasKey(e => new { e.IdFlow, e.IdStep, e.IdStepNext });

                entity.HasOne(d => d.IdStepNextNavigation)
                    .WithMany(p => p.StepsNext)
                    .HasForeignKey(d => d.IdStepNext)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StepsNext_Steps");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.StepsNext)
                    .HasForeignKey(d => new { d.IdFlow, d.IdStep })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StepsNext_Secuences");
            });

            modelBuilder.Entity<StepsInFields>(entity =>
            {
                entity.HasKey(e => new { e.IdStep, e.IdField });

                entity.HasIndex(e => e.IdField);

                entity.Property(e => e.IdStep)
                    .HasComment("Contains Identity Steps");

                entity.Property(e => e.IdField)
                    .HasComment("Contains Identity Fields");

                entity.HasOne(d => d.IdFieldNavigation)
                    .WithMany(p => p.StepsInFields)
                    .HasForeignKey(d => d.IdField)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StepsInFields_Fields");

                entity.HasOne(d => d.IdStepsNavigation)
                    .WithMany(p => p.StepsInFields)
                    .HasForeignKey(d => d.IdStep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StepsInFields_Steps");
            });

            modelBuilder.Entity<TypeFields>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasComment("Contains Identity TypeField");
                entity.Property(e => e.Name)
                    .IsRequired(true)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasComment("Contains Identity User");
                entity.Property(e => e.UserName)
                    .IsRequired(true)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Flows>()
            .HasData
            (
                new Flows()
                {
                    Id = 1,
                    Name = "Secuencial"
                },
                new Flows()
                {
                    Id = 2,
                    Name = "Simultáneo"
                }
            );

            modelBuilder.Entity<Steps>()
            .HasData
            (
                new Steps()
                {
                    Id = 1,
                    Code = "STP-0001",
                    Name = "Paso 1"
                },
                new Steps()
                {
                    Id = 2,
                    Code = "STP-0002",
                    Name = "Paso 2"
                },
                new Steps()
                {
                    Id = 3,
                    Code = "STP-0003",
                    Name = "Paso 3"
                },
                new Steps()
                {
                    Id = 4,
                    Code = "STP-0004",
                    Name = "Paso 4"
                }
                ,
                new Steps()
                {
                    Id = 5,
                    Code = "STP-000n",
                    Name = "Paso n"
                }
            );

            modelBuilder.Entity<Fields>()
            .HasData
            (
                new Fields()
                {
                    Id = 1,
                    Code = "F-0001",
                    Name = "Primer nombre",
                    IdTypeField = 1
                },
                new Fields()
                {
                    Id = 2,
                    Code = "F-0002",
                    Name = "Segundo nombre",
                    IdTypeField = 1
                },
                new Fields()
                {
                    Id = 3,
                    Code = "F-0003",
                    Name = "Primer apellido",
                    IdTypeField = 1
                },
                new Fields()
                {
                    Id = 4,
                    Code = "F-0004",
                    Name = "Segundo apellido",
                    IdTypeField = 1
                },
                new Fields()
                {
                    Id = 5,
                    Code = "F-0005",
                    Name = "Tipo de documento",
                    IdTypeField = 2
                },
                new Fields()
                {
                    Id = 6,
                    Code = "F-0006",
                    Name = "Número de documento",
                    IdTypeField = 1
                },
                new Fields()
                {
                    Id = 7,
                    Code = "F-000n",
                    Name = "xxxxxx",
                    IdTypeField = 3
                }

            );

            modelBuilder.Entity<Secuences>()
            .HasData
            (
                new Secuences()
                {
                    IdFlow = 1,
                    IdStep = 1,
                    IsFirts = true
                },
                new Secuences()
                {
                    IdFlow = 1,
                    IdStep = 2,
                    IsFirts = false
                },
                new Secuences()
                {
                    IdFlow = 1,
                    IdStep = 3,
                    IsFirts = false
                },
                new Secuences()
                {
                    IdFlow = 1,
                    IdStep = 4,
                    IsFirts = false
                },
                new Secuences()
                {
                    IdFlow = 1,
                    IdStep = 5,
                    IsFirts = false
                },
                new Secuences()
                {
                    IdFlow = 2,
                    IdStep = 1,
                    IsFirts = true
                },
                new Secuences()
                {
                    IdFlow = 2,
                    IdStep = 2,
                    IsFirts = false
                },
                new Secuences()
                {
                    IdFlow = 2,
                    IdStep = 3,
                    IsFirts = false
                },
                new Secuences()
                {
                    IdFlow = 2,
                    IdStep = 4,
                    IsFirts = false
                },
                new Secuences()
                {
                    IdFlow = 2,
                    IdStep = 5,
                    IsFirts = false
                }
            );

            modelBuilder.Entity<StepsNext>()
            .HasData
            (
                new StepsNext()
                {
                    IdFlow = 1,
                    IdStep = 1,
                    IdStepNext = 2
                },
                new StepsNext()
                {
                    IdFlow = 1,
                    IdStep = 2,
                    IdStepNext = 3
                },
                new StepsNext()
                {
                    IdFlow = 1,
                    IdStep = 3,
                    IdStepNext = 4
                },
                new StepsNext()
                {
                    IdFlow = 1,
                    IdStep = 4,
                    IdStepNext = 5
                },
                new StepsNext()
                {
                    IdFlow = 2,
                    IdStep = 1,
                    IdStepNext = 2
                },
                new StepsNext()
                {
                    IdFlow = 2,
                    IdStep = 1,
                    IdStepNext = 3
                },
                new StepsNext()
                {
                    IdFlow = 2,
                    IdStep = 1,
                    IdStepNext = 4
                },
                ///
                new StepsNext()
                {
                    IdFlow = 2,
                    IdStep = 2,
                    IdStepNext = 5
                },
                new StepsNext()
                {
                    IdFlow = 2,
                    IdStep = 3,
                    IdStepNext = 5
                },
                new StepsNext()
                {
                    IdFlow = 2,
                    IdStep = 4,
                    IdStepNext = 5
                }
            );

            modelBuilder.Entity<StepsInFields>()
           .HasData
           (
               new StepsInFields()
               {
                   IdField = 1,
                   IdStep = 1
               },
               new StepsInFields()
               {
                   IdField = 2,
                   IdStep = 2
               },
               new StepsInFields()
               {
                   IdField = 3,
                   IdStep = 3
               },
               new StepsInFields()
               {
                   IdField = 4,
                   IdStep = 4
               },
               new StepsInFields()
               {
                   IdField = 5,
                   IdStep = 5
               },
               new StepsInFields()
               {
                   IdField = 6,
                   IdStep = 5
               },
               new StepsInFields()
               {
                   IdField = 7,
                   IdStep = 5
               }
           );

            modelBuilder.Entity<Users>()
            .HasData
            (
                new Users()
                {
                    Id = 1,
                    UserName = "bruce.wayne@sinmail.com"
                },
                new Users()
                {
                    Id = 2,
                    UserName = "arthur.fleck@sinmail.com"
                },
                new Users()
                {
                    Id = 3,
                    UserName = "diana.prince@sinmail.com" 
                },
                new Users()
                {
                    Id = 4,
                    UserName = "barry.allen@sinmail.com"
                },
                new Users()
                {
                    Id = 5,
                    UserName = "luisa.lane@sinmail.com"
                },
                new Users()
                {
                    Id = 6,
                    UserName = "clark.kent@sinmail.com"
                }
            );
            modelBuilder.Entity<TypeFields>()
           .HasData
           (
               new TypeFields()
               {
                   Id = 1,
                   Name = "string"
               },
               new TypeFields()
               {
                   Id = 2,
                   Name = "int"
               },
                new TypeFields()
                {
                    Id = 3,
                    Name = "decimal"
                }
           );
           modelBuilder.Entity<FieldsByUser>()
          .HasData
          (
              new FieldsByUser()
              {
                  IdUser = 1,
                  IdField = 1,
                  Value = "APROBADO"
              },
              new FieldsByUser()
              {
                  IdUser = 1,
                  IdField = 5,
                  Value = "1"
              },
              new FieldsByUser()
              {
                  IdUser = 1,
                  IdField = 6,
                  Value = "80113781"
              },
              new FieldsByUser()
              {
                  IdUser = 1,
                  IdField = 7,
                  Value = "xxxx"
              },
              new FieldsByUser()
              {
                  IdUser = 2,
                  IdField = 2,
                  Value = "8"
              },
              new FieldsByUser()
              {
                  IdUser = 2,
                  IdField = 3,
                  Value = "8.8"
              }, 
              new FieldsByUser()
              {
                  IdUser = 2,
                  IdField = 5,
                  Value = "1"
              },
              new FieldsByUser()
              {
                  IdUser = 2,
                  IdField = 6,
                  Value = "80113781"
              }
          );


            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
