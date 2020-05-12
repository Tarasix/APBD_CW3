using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Cwicz_3.Models2
{
    public partial class s19461Context : DbContext
    {
        public s19461Context()
        {
        }

        public s19461Context(DbContextOptions<s19461Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Cinema> Cinema { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Dept> Dept { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Emp> Emp { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<FilmCustom> FilmCustom { get; set; }
        public virtual DbSet<Films> Films { get; set; }
        public virtual DbSet<Gotowanie> Gotowanie { get; set; }
        public virtual DbSet<Hall> Hall { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Medicament> Medicament { get; set; }
        public virtual DbSet<MenuJedzenia> MenuJedzenia { get; set; }
        public virtual DbSet<MenuPicia> MenuPicia { get; set; }
        public virtual DbSet<MenuRezerwacja> MenuRezerwacja { get; set; }
        public virtual DbSet<Opinia> Opinia { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Placa1> Placa1 { get; set; }
        public virtual DbSet<Pracownicy> Pracownicy { get; set; }
        public virtual DbSet<Prescription> Prescription { get; set; }
        public virtual DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }
        public virtual DbSet<Procedure> Procedure { get; set; }
        public virtual DbSet<ProcedureAnimal> ProcedureAnimal { get; set; }
        public virtual DbSet<Profession> Profession { get; set; }
        public virtual DbSet<Rezerwacja> Rezerwacja { get; set; }
        public virtual DbSet<Sala> Sala { get; set; }
        public virtual DbSet<Salgrade> Salgrade { get; set; }
        public virtual DbSet<SnackBar> SnackBar { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<StaffBar> StaffBar { get; set; }
        public virtual DbSet<StaffHall> StaffHall { get; set; }
        public virtual DbSet<Stanowisko> Stanowisko { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Studies> Studies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s19461;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.IdAnimal)
                    .HasName("Animal_pk");

                entity.Property(e => e.AdmissionDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.IdOwner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Animal_Owner");
            });

            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.HasKey(e => e.IdCinema)
                    .HasName("Cinema_pk");

                entity.Property(e => e.IdCinema)
                    .HasColumnName("id_cinema")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnName("adress")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.IdCustomer)
                    .HasName("Customers_pk");

                entity.Property(e => e.IdCustomer)
                    .HasColumnName("id_customer")
                    .ValueGeneratedNever();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DEPT");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Dname)
                    .HasColumnName("DNAME")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Loc)
                    .HasColumnName("LOC")
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("Doctor_pk");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EMP");

                entity.Property(e => e.Comm).HasColumnName("COMM");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Empno).HasColumnName("EMPNO");

                entity.Property(e => e.Ename)
                    .HasColumnName("ENAME")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hiredate)
                    .HasColumnName("HIREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Job)
                    .HasColumnName("JOB")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Mgr).HasColumnName("MGR");

                entity.Property(e => e.Sal).HasColumnName("SAL");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => e.IdEnrollment)
                    .HasName("Enrollment_pk");

                entity.Property(e => e.IdEnrollment).ValueGeneratedNever();

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.IdStudyNavigation)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.IdStudy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Enrollment_Studies");
            });

            modelBuilder.Entity<FilmCustom>(entity =>
            {
                entity.HasKey(e => new { e.IdFilm, e.IdCustomer })
                    .HasName("Film_Custom_pk");

                entity.ToTable("Film_Custom");

                entity.Property(e => e.IdFilm).HasColumnName("id_film");

                entity.Property(e => e.IdCustomer).HasColumnName("id_customer");

                entity.Property(e => e.EndingTime)
                    .HasColumnName("ending_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.StartingTime)
                    .HasColumnName("starting_time")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.FilmCustom)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("Film_Customer_Customers");

                entity.HasOne(d => d.IdFilmNavigation)
                    .WithMany(p => p.FilmCustom)
                    .HasForeignKey(d => d.IdFilm)
                    .HasConstraintName("Film_Customer_Films");
            });

            modelBuilder.Entity<Films>(entity =>
            {
                entity.HasKey(e => e.IdFilm)
                    .HasName("Films_pk");

                entity.Property(e => e.IdFilm)
                    .HasColumnName("id_film")
                    .ValueGeneratedNever();

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasColumnName("company")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasColumnName("genre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdCinema).HasColumnName("id_cinema");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.HasOne(d => d.IdCinemaNavigation)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.IdCinema)
                    .HasConstraintName("Films_Cinema");
            });

            modelBuilder.Entity<Gotowanie>(entity =>
            {
                entity.HasKey(e => e.IdGotowanie)
                    .HasName("Gotowanie_pk");

                entity.Property(e => e.IdGotowanie).ValueGeneratedNever();

                entity.HasOne(d => d.IdMenuRezNavigation)
                    .WithMany(p => p.Gotowanie)
                    .HasForeignKey(d => d.IdMenuRez)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Gotowanie_Menu_Rezerwacja");

                entity.HasOne(d => d.IdPracownikNavigation)
                    .WithMany(p => p.Gotowanie)
                    .HasForeignKey(d => d.IdPracownik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Gotowanie_Pracownicy");
            });

            modelBuilder.Entity<Hall>(entity =>
            {
                entity.HasKey(e => e.IdHall)
                    .HasName("Hall_pk");

                entity.Property(e => e.IdHall)
                    .HasColumnName("id_hall")
                    .ValueGeneratedNever();

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.IdCinema).HasColumnName("id_cinema");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RowCount).HasColumnName("row_count");

                entity.HasOne(d => d.IdCinemaNavigation)
                    .WithMany(p => p.Hall)
                    .HasForeignKey(d => d.IdCinema)
                    .HasConstraintName("Hall_Cinema");
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasKey(e => e.IdKlient)
                    .HasName("Klient_pk");

                entity.Property(e => e.IdKlient).ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefon)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament)
                    .HasName("Medicament_pk");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<MenuJedzenia>(entity =>
            {
                entity.HasKey(e => e.IdMenuJedz)
                    .HasName("Menu_Jedzenia_pk");

                entity.ToTable("Menu_Jedzenia");

                entity.Property(e => e.IdMenuJedz).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Typ)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuPicia>(entity =>
            {
                entity.HasKey(e => e.IdMenuPicia)
                    .HasName("Menu_Picia_pk");

                entity.ToTable("Menu_Picia");

                entity.Property(e => e.IdMenuPicia).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Typ)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuRezerwacja>(entity =>
            {
                entity.HasKey(e => e.IdMenuRez)
                    .HasName("Menu_Rezerwacja_pk");

                entity.ToTable("Menu_Rezerwacja");

                entity.Property(e => e.IdMenuRez).ValueGeneratedNever();

                entity.HasOne(d => d.IdMenuJedzNavigation)
                    .WithMany(p => p.MenuRezerwacja)
                    .HasForeignKey(d => d.IdMenuJedz)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Menu_Rezerwacja_Menu_Jedzenia");

                entity.HasOne(d => d.IdMenuPiciaNavigation)
                    .WithMany(p => p.MenuRezerwacja)
                    .HasForeignKey(d => d.IdMenuPicia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Menu_Rezerwacja_Menu_Picia");

                entity.HasOne(d => d.IdRezerwacjaNavigation)
                    .WithMany(p => p.MenuRezerwacja)
                    .HasForeignKey(d => d.IdRezerwacja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Menu_Rezerwacja_Rezerwacja");
            });

            modelBuilder.Entity<Opinia>(entity =>
            {
                entity.HasKey(e => e.IdOpinia)
                    .HasName("Opinia_pk");

                entity.Property(e => e.IdOpinia).ValueGeneratedNever();

                entity.Property(e => e.Recenzja)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRezerwacjaNavigation)
                    .WithMany(p => p.Opinia)
                    .HasForeignKey(d => d.IdRezerwacja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Opinia_Rezerwacja");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(e => e.IdOwner)
                    .HasName("Owner_pk");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient)
                    .HasName("Patient_pk");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Placa1>(entity =>
            {
                entity.HasKey(e => e.IdPlaca)
                    .HasName("PK__Placa1__7506E1A82580CE8F");

                entity.Property(e => e.IdPlaca)
                    .HasColumnName("Id_Placa")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdMenuRezNavigation)
                    .WithMany(p => p.Placa1)
                    .HasForeignKey(d => d.IdMenuRez)
                    .HasConstraintName("FK__Placa1__IdMenuRe__671F4F74");
            });

            modelBuilder.Entity<Pracownicy>(entity =>
            {
                entity.HasKey(e => e.IdPracownik)
                    .HasName("Pracownicy_pk");

                entity.Property(e => e.IdPracownik).ValueGeneratedNever();

                entity.Property(e => e.DataZatrud).HasColumnType("date");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdStanowiskoNavigation)
                    .WithMany(p => p.Pracownicy)
                    .HasForeignKey(d => d.IdStanowisko)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pracownicy_Stanowisko");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription)
                    .HasName("Prescription_pk");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Doctor");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Patient");
            });

            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.HasKey(e => new { e.IdMedicament, e.IdPrescription })
                    .HasName("Prescription_Medicament_pk");

                entity.ToTable("Prescription_Medicament");

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdMedicamentNavigation)
                    .WithMany(p => p.PrescriptionMedicament)
                    .HasForeignKey(d => d.IdMedicament)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Medicament_Medicament");

                entity.HasOne(d => d.IdPrescriptionNavigation)
                    .WithMany(p => p.PrescriptionMedicament)
                    .HasForeignKey(d => d.IdPrescription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Medicament_Prescription");
            });

            modelBuilder.Entity<Procedure>(entity =>
            {
                entity.HasKey(e => e.IdProcedure)
                    .HasName("Procedure_pk");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ProcedureAnimal>(entity =>
            {
                entity.HasKey(e => new { e.ProcedureIdProcedure, e.AnimalIdAnimal, e.Date })
                    .HasName("Procedure_Animal_pk");

                entity.ToTable("Procedure_Animal");

                entity.Property(e => e.ProcedureIdProcedure).HasColumnName("Procedure_IdProcedure");

                entity.Property(e => e.AnimalIdAnimal).HasColumnName("Animal_IdAnimal");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.AnimalIdAnimalNavigation)
                    .WithMany(p => p.ProcedureAnimal)
                    .HasForeignKey(d => d.AnimalIdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_3_Animal");

                entity.HasOne(d => d.ProcedureIdProcedureNavigation)
                    .WithMany(p => p.ProcedureAnimal)
                    .HasForeignKey(d => d.ProcedureIdProcedure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_3_Procedure");
            });

            modelBuilder.Entity<Profession>(entity =>
            {
                entity.HasKey(e => e.IdProfession)
                    .HasName("Profession_pk");

                entity.Property(e => e.IdProfession)
                    .HasColumnName("id_profession")
                    .ValueGeneratedNever();

                entity.Property(e => e.PositionName)
                    .IsRequired()
                    .HasColumnName("position_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rezerwacja>(entity =>
            {
                entity.HasKey(e => e.IdRezerwacja)
                    .HasName("Rezerwacja_pk");

                entity.Property(e => e.IdRezerwacja).ValueGeneratedNever();

                entity.Property(e => e.CzasRozp).HasColumnType("datetime");

                entity.Property(e => e.CzasZakon).HasColumnType("datetime");

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithMany(p => p.Rezerwacja)
                    .HasForeignKey(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rezerwacja_Klient");

                entity.HasOne(d => d.IdPracownikNavigation)
                    .WithMany(p => p.Rezerwacja)
                    .HasForeignKey(d => d.IdPracownik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rezerwacja_Pracownicy");

                entity.HasOne(d => d.IdSalaNavigation)
                    .WithMany(p => p.Rezerwacja)
                    .HasForeignKey(d => d.IdSala)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rezerwacja_Sala");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.HasKey(e => e.IdSala)
                    .HasName("Sala_pk");

                entity.Property(e => e.IdSala).ValueGeneratedNever();

                entity.Property(e => e.Typ)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Salgrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SALGRADE");

                entity.Property(e => e.Grade).HasColumnName("GRADE");

                entity.Property(e => e.Hisal).HasColumnName("HISAL");

                entity.Property(e => e.Losal).HasColumnName("LOSAL");
            });

            modelBuilder.Entity<SnackBar>(entity =>
            {
                entity.HasKey(e => e.IdSnackBar)
                    .HasName("Snack_Bar_pk");

                entity.ToTable("Snack_Bar");

                entity.Property(e => e.IdSnackBar)
                    .HasColumnName("id_snack_bar")
                    .ValueGeneratedNever();

                entity.Property(e => e.Drinks)
                    .IsRequired()
                    .HasColumnName("drinks")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdCinema).HasColumnName("id_cinema");

                entity.Property(e => e.Meals)
                    .IsRequired()
                    .HasColumnName("meals")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCinemaNavigation)
                    .WithMany(p => p.SnackBar)
                    .HasForeignKey(d => d.IdCinema)
                    .HasConstraintName("Snack_Bar_Cinema");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.IdStaff)
                    .HasName("Staff_pk");

                entity.Property(e => e.IdStaff)
                    .HasColumnName("id_staff")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdCinema).HasColumnName("id_cinema");

                entity.Property(e => e.IdProfession).HasColumnName("id_profession");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StaffBar>(entity =>
            {
                entity.HasKey(e => e.IdStaffBar)
                    .HasName("Staff_Bar_pk");

                entity.ToTable("Staff_Bar");

                entity.Property(e => e.IdStaffBar)
                    .HasColumnName("id_staff_bar")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdSnackBar).HasColumnName("id_snack_bar");

                entity.Property(e => e.IdStaff).HasColumnName("id_staff");

                entity.HasOne(d => d.IdSnackBarNavigation)
                    .WithMany(p => p.StaffBar)
                    .HasForeignKey(d => d.IdSnackBar)
                    .HasConstraintName("Staff_Bar_Snack_Bar");

                entity.HasOne(d => d.IdStaffNavigation)
                    .WithMany(p => p.StaffBar)
                    .HasForeignKey(d => d.IdStaff)
                    .HasConstraintName("Staff_Bar_Staff");
            });

            modelBuilder.Entity<StaffHall>(entity =>
            {
                entity.HasKey(e => e.IdStaffHall)
                    .HasName("Staff_Hall_pk");

                entity.ToTable("Staff_Hall");

                entity.Property(e => e.IdStaffHall)
                    .HasColumnName("id_staff_hall")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdHall).HasColumnName("id_hall");

                entity.Property(e => e.IdStaff).HasColumnName("id_staff");

                entity.HasOne(d => d.IdHallNavigation)
                    .WithMany(p => p.StaffHall)
                    .HasForeignKey(d => d.IdHall)
                    .HasConstraintName("Hall_Staff_Hall");

                entity.HasOne(d => d.IdStaffNavigation)
                    .WithMany(p => p.StaffHall)
                    .HasForeignKey(d => d.IdStaff)
                    .HasConstraintName("Hall_Staff_Staff");
            });

            modelBuilder.Entity<Stanowisko>(entity =>
            {
                entity.HasKey(e => e.IdStanowisko)
                    .HasName("Stanowisko_pk");

                entity.Property(e => e.IdStanowisko).ValueGeneratedNever();

                entity.Property(e => e.NazwaStan)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IndexNumber)
                    .HasName("Student_pk");

                entity.Property(e => e.IndexNumber).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdEnrollmentNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.IdEnrollment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Student_Enrollment");
            });

            modelBuilder.Entity<Studies>(entity =>
            {
                entity.HasKey(e => e.IdStudy)
                    .HasName("Studies_pk");

                entity.Property(e => e.IdStudy).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
