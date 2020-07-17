using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Model.Models
{
    public partial class SchoolDBContext : DbContext
    {
        public SchoolDBContext()
        {
        }

        public SchoolDBContext(DbContextOptions<SchoolDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnnéeUniversitaire> AnnéeUniversitaire { get; set; }
        public virtual DbSet<AssociationGroupeProf> AssociationGroupeProf { get; set; }
        public virtual DbSet<AssociationSalleGroupe> AssociationSalleGroupe { get; set; }
        public virtual DbSet<AssociationSeanceGroupe> AssociationSeanceGroupe { get; set; }
        public virtual DbSet<AssociationSeanceProfesseur> AssociationSeanceProfesseur { get; set; }
        public virtual DbSet<AssociationSeanceSalle> AssociationSeanceSalle { get; set; }
        public virtual DbSet<Classroom> Classroom { get; set; }
        public virtual DbSet<Ecole> Ecole { get; set; }
        public virtual DbSet<Etudient> Etudient { get; set; }
        public virtual DbSet<Filiere> Filiere { get; set; }
        public virtual DbSet<Formation> Formation { get; set; }
        public virtual DbSet<Groupe> Groupe { get; set; }
        public virtual DbSet<Matiere> Matiere { get; set; }
        public virtual DbSet<MatrielsPedagogique> MatrielsPedagogique { get; set; }
        public virtual DbSet<NiveauFormation> NiveauFormation { get; set; }
        public virtual DbSet<Professeur> Professeur { get; set; }
        public virtual DbSet<Salle> Salle { get; set; }
        public virtual DbSet<Seance> Seance { get; set; }
        public virtual DbSet<Semestre> Semestre { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-LK2SEPN;Database=SchoolDB;Trusted_Connection=true;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnnéeUniversitaire>(entity =>
            {
                entity.HasKey(e => e.IdAnneeUn);

                entity.ToTable("Année_universitaire");

                entity.Property(e => e.IdAnneeUn).HasColumnName("Id_Annee_Un");

                entity.Property(e => e.IdEcole).HasColumnName("Id_Ecole");

                entity.Property(e => e.NomAnneeUn)
                    .HasColumnName("Nom_Annee_Un")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdEcoleNavigation)
                    .WithMany(p => p.AnnéeUniversitaire)
                    .HasForeignKey(d => d.IdEcole)
                    .HasConstraintName("FK_Année_universitaire_Ecole");
            });

            modelBuilder.Entity<AssociationGroupeProf>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Association_Groupe_Prof");

                entity.Property(e => e.IdGroupe).HasColumnName("Id_Groupe");

                entity.Property(e => e.IdProf).HasColumnName("Id_Prof");

                entity.HasOne(d => d.IdGroupeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdGroupe)
                    .HasConstraintName("FK_Association_Groupe_Prof_Groupe");

                entity.HasOne(d => d.IdProfNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProf)
                    .HasConstraintName("FK_Association_Groupe_Prof_Professeur");
            });

            modelBuilder.Entity<AssociationSalleGroupe>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Association_Salle_Groupe");

                entity.Property(e => e.IdGroupe).HasColumnName("Id_Groupe");

                entity.Property(e => e.IdSalle).HasColumnName("Id_Salle");

                entity.Property(e => e.Observations).HasMaxLength(350);

                entity.HasOne(d => d.IdGroupeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdGroupe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Association_Salle_Groupe_Groupe");

                entity.HasOne(d => d.IdSalleNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Association_Salle_Groupe_Salle");
            });

            modelBuilder.Entity<AssociationSeanceGroupe>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Association_Seance_Groupe");

                entity.Property(e => e.IdGroupe).HasColumnName("Id_Groupe");

                entity.Property(e => e.IdSeance).HasColumnName("Id_Seance");

                entity.HasOne(d => d.IdGroupeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdGroupe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Association_Seance_Groupe_Groupe");

                entity.HasOne(d => d.IdSeanceNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSeance)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Association_Seance_Groupe_Seance");
            });

            modelBuilder.Entity<AssociationSeanceProfesseur>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Association_Seance_Professeur");

                entity.Property(e => e.IdProf).HasColumnName("Id_Prof");

                entity.Property(e => e.IdSeance).HasColumnName("Id_Seance");

                entity.HasOne(d => d.IdProfNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Association_Seance_Professeur_Professeur");

                entity.HasOne(d => d.IdSeanceNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSeance)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Association_Seance_Professeur_Seance");
            });

            modelBuilder.Entity<AssociationSeanceSalle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Association_Seance_Salle");

                entity.Property(e => e.IdSalle).HasColumnName("Id_Salle");

                entity.Property(e => e.IdSeance).HasColumnName("Id_Seance");

                entity.HasOne(d => d.IdSalleNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Association_Seance_Salle_Salle");

                entity.HasOne(d => d.IdSeanceNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSeance)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Association_Seance_Salle_Seance");
            });

            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CapaciterSalle)
                    .IsRequired()
                    .HasColumnName("Capaciter_Salle")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.IdSalle)
                    .HasColumnName("Id_Salle")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NomSalle)
                    .IsRequired()
                    .HasColumnName("Nom_Salle")
                    .HasMaxLength(50);

                entity.Property(e => e.TypeSalle)
                    .IsRequired()
                    .HasColumnName("Type_Salle")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Ecole>(entity =>
            {
                entity.HasKey(e => e.IdEcole);

                entity.Property(e => e.IdEcole).HasColumnName("Id_Ecole");

                entity.Property(e => e.LogoEcole)
                    .HasColumnName("Logo_Ecole")
                    .HasMaxLength(150);

                entity.Property(e => e.NomEcole)
                    .HasColumnName("Nom_Ecole")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Etudient>(entity =>
            {
                entity.HasKey(e => e.IdEtudient)
                    .HasName("PK_Student");

                entity.Property(e => e.IdEtudient).HasColumnName("Id_Etudient");

                entity.Property(e => e.IdGroupe).HasColumnName("Id_Groupe");

                entity.Property(e => e.NomEtudient)
                    .IsRequired()
                    .HasColumnName("Nom_Etudient")
                    .HasMaxLength(100);

                entity.Property(e => e.NumeroInscription).HasColumnName("Numero_Inscription");

                entity.Property(e => e.PrenomEtudient)
                    .IsRequired()
                    .HasColumnName("Prenom_Etudient")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdGroupeNavigation)
                    .WithMany(p => p.Etudient)
                    .HasForeignKey(d => d.IdGroupe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Etudient_Groupe");
            });

            modelBuilder.Entity<Filiere>(entity =>
            {
                entity.HasKey(e => e.IdFiliere);

                entity.Property(e => e.IdFiliere).HasColumnName("Id_Filiere");

                entity.Property(e => e.IdNiveau).HasColumnName("Id_Niveau");

                entity.Property(e => e.NomFiliere)
                    .HasColumnName("Nom_Filiere")
                    .HasMaxLength(150);

                entity.HasOne(d => d.IdNiveauNavigation)
                    .WithMany(p => p.Filiere)
                    .HasForeignKey(d => d.IdNiveau)
                    .HasConstraintName("FK_Filiere_Niveau_Formation");
            });

            modelBuilder.Entity<Formation>(entity =>
            {
                entity.HasKey(e => e.IdFormation);

                entity.Property(e => e.IdFormation).HasColumnName("Id_Formation");

                entity.Property(e => e.DureeFormation)
                    .HasColumnName("Duree_Formation")
                    .HasMaxLength(50);

                entity.Property(e => e.IdEcole).HasColumnName("Id_Ecole");

                entity.Property(e => e.NomFormation)
                    .HasColumnName("Nom_Formation")
                    .HasMaxLength(100);

                entity.Property(e => e.TypeFormation)
                    .HasColumnName("Type_Formation")
                    .HasMaxLength(150);

                entity.HasOne(d => d.IdEcoleNavigation)
                    .WithMany(p => p.Formation)
                    .HasForeignKey(d => d.IdEcole)
                    .HasConstraintName("FK_Formation_Ecole1");
            });

            modelBuilder.Entity<Groupe>(entity =>
            {
                entity.HasKey(e => e.IdGroupe);

                entity.Property(e => e.IdGroupe).HasColumnName("Id_Groupe");

                entity.Property(e => e.IdFiliere).HasColumnName("Id_Filiere");

                entity.Property(e => e.NomGroupe)
                    .IsRequired()
                    .HasColumnName("Nom_Groupe")
                    .HasMaxLength(150);

                entity.Property(e => e.NombreGroupe).HasColumnName("Nombre_Groupe");

                entity.HasOne(d => d.IdFiliereNavigation)
                    .WithMany(p => p.Groupe)
                    .HasForeignKey(d => d.IdFiliere)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Groupe_Filiere");
            });

            modelBuilder.Entity<Matiere>(entity =>
            {
                entity.HasKey(e => e.IdMatiere);

                entity.Property(e => e.IdMatiere).HasColumnName("Id_Matiere");

                entity.Property(e => e.IdFiliere).HasColumnName("Id_Filiere");

                entity.Property(e => e.NomMatiere)
                    .HasColumnName("Nom_Matiere")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<MatrielsPedagogique>(entity =>
            {
                entity.HasKey(e => e.IdMatriel);

                entity.ToTable("Matriels_Pedagogique");

                entity.Property(e => e.IdMatriel).HasColumnName("Id_Matriel");

                entity.Property(e => e.IdSalle).HasColumnName("Id_Salle");

                entity.Property(e => e.NomMatriel)
                    .HasColumnName("Nom_Matriel")
                    .HasMaxLength(150);

                entity.Property(e => e.NombreMatriel).HasColumnName("Nombre_Matriel");

                entity.Property(e => e.RefMatriel)
                    .HasColumnName("Ref_Matriel")
                    .HasMaxLength(150);

                entity.HasOne(d => d.IdSalleNavigation)
                    .WithMany(p => p.MatrielsPedagogique)
                    .HasForeignKey(d => d.IdSalle)
                    .HasConstraintName("FK_Matriels_Pedagogique_Salle");
            });

            modelBuilder.Entity<NiveauFormation>(entity =>
            {
                entity.HasKey(e => e.IdNiveau);

                entity.ToTable("Niveau_Formation");

                entity.Property(e => e.IdNiveau).HasColumnName("Id_Niveau");

                entity.Property(e => e.IdFormation).HasColumnName("Id_Formation");

                entity.Property(e => e.NomNiveau)
                    .HasColumnName("Nom_Niveau")
                    .HasMaxLength(150);

                entity.HasOne(d => d.IdFormationNavigation)
                    .WithMany(p => p.NiveauFormation)
                    .HasForeignKey(d => d.IdFormation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Niveau_Formation_Formation");
            });

            modelBuilder.Entity<Professeur>(entity =>
            {
                entity.HasKey(e => e.IdProf)
                    .HasName("PK_Teacher");

                entity.Property(e => e.IdProf).HasColumnName("Id_Prof");

                entity.Property(e => e.NomProf)
                    .IsRequired()
                    .HasColumnName("Nom_Prof")
                    .HasMaxLength(100);

                entity.Property(e => e.PrenomProf)
                    .IsRequired()
                    .HasColumnName("Prenom_Prof")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Salle>(entity =>
            {
                entity.HasKey(e => e.IdSalle);

                entity.Property(e => e.IdSalle).HasColumnName("Id_Salle");

                entity.Property(e => e.CapaciterSalle)
                    .IsRequired()
                    .HasColumnName("Capaciter_Salle")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.NomSalle)
                    .IsRequired()
                    .HasColumnName("Nom_Salle")
                    .HasMaxLength(50);

                entity.Property(e => e.TypeSalle)
                    .IsRequired()
                    .HasColumnName("Type_Salle")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Seance>(entity =>
            {
                entity.HasKey(e => e.IdSeance);

                entity.Property(e => e.IdSeance).HasColumnName("Id_Seance");

                entity.Property(e => e.ObservationSeance)
                    .HasColumnName("Observation_Seance")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Semestre>(entity =>
            {
                entity.HasKey(e => e.IdSemestre);

                entity.Property(e => e.IdSemestre).HasColumnName("Id_Semestre");

                entity.Property(e => e.IdAnneeUn).HasColumnName("Id_Annee_Un");

                entity.Property(e => e.NomSemestre)
                    .HasColumnName("Nom_Semestre")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdAnneeUnNavigation)
                    .WithMany(p => p.Semestre)
                    .HasForeignKey(d => d.IdAnneeUn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Semestre_Année_universitaire");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
