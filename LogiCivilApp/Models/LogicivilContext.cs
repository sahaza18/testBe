using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LogiCivilApp.Models;

public partial class LogicivilContext : DbContext
{
    public LogicivilContext()
    {
    }

    public LogicivilContext(DbContextOptions<LogicivilContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Affaire> Affaires { get; set; }

    public virtual DbSet<Avocat> Avocats { get; set; }

    public virtual DbSet<DetailsRenvoie> DetailsRenvoies { get; set; }

    public virtual DbSet<DisponibiliteAudience> DisponibiliteAudiences { get; set; }

    public virtual DbSet<Enrolement> Enrolements { get; set; }

    public virtual DbSet<HistoriqueTraitementAffaire> HistoriqueTraitementAffaires { get; set; }

    public virtual DbSet<MotifRenvoie> MotifRenvoies { get; set; }

    public virtual DbSet<NatureAffaire> NatureAffaires { get; set; }

    public virtual DbSet<ParametrageAudience> ParametrageAudiences { get; set; }

    public virtual DbSet<Payement> Payements { get; set; }

    public virtual DbSet<Plumitif> Plumitifs { get; set; }

    public virtual DbSet<Profil> Profils { get; set; }

    public virtual DbSet<QuestionnairePlumitif> QuestionnairePlumitifs { get; set; }

    public virtual DbSet<Renvoie> Renvoies { get; set; }

    public virtual DbSet<SalleAudience> SalleAudiences { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<SousSection> SousSections { get; set; }

    public virtual DbSet<StandardServiceType> StandardServiceTypes { get; set; }

    public virtual DbSet<Statut> Statuts { get; set; }

    public virtual DbSet<TypeDossier> TypeDossiers { get; set; }

    public virtual DbSet<TypePayement> TypePayements { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    public virtual DbSet<Visa> Visas { get; set; }



    private static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseNpgsql("Host=localhost;Database=logicivil;Username=postgres;Password=root;").UseLoggerFactory(MyLoggerFactory);
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Affaire>(entity =>
        {
            entity.HasKey(e => e.IdAffaire).HasName("affaire_pkey");

            entity.ToTable("affaire");

            entity.Property(e => e.IdAffaire)
                .HasDefaultValueSql("('AFF'::text || nextval('affaire_seq'::regclass))")
                .HasColumnType("character varying")
                .HasColumnName("id_affaire");
            entity.Property(e => e.DateCloturationDossier).HasColumnName("date_cloturation_dossier");
            entity.Property(e => e.DateDemande).HasColumnName("date_demande");
            entity.Property(e => e.DateValidationProcureur).HasColumnName("date_validation_procureur");
            entity.Property(e => e.DescriptionAffaire)
                .HasColumnType("character varying")
                .HasColumnName("description_affaire");
            entity.Property(e => e.IdAvocatDefendeur)
                .HasColumnType("character varying")
                .HasColumnName("id_avocat_defendeur");
            entity.Property(e => e.IdAvocatDemandeur)
                .HasColumnType("character varying")
                .HasColumnName("id_avocat_demandeur");
            entity.Property(e => e.IdProcureur)
                .HasColumnType("character varying")
                .HasColumnName("id_procureur");
            entity.Property(e => e.IdStatut).HasColumnName("id_statut");
            entity.Property(e => e.IdUserValidateurCloturation)
                .HasColumnType("character varying")
                .HasColumnName("id_user_validateur_cloturation");
            entity.Property(e => e.IdUserValidateurDemande)
                .HasColumnType("character varying")
                .HasColumnName("id_user_validateur_demande");
            entity.Property(e => e.NomDefendeur)
                .HasMaxLength(100)
                .HasColumnName("nom_defendeur");
            entity.Property(e => e.NomDemandeur)
                .HasMaxLength(100)
                .HasColumnName("nom_demandeur");

            entity.HasOne(d => d.IdAvocatDefendeurNavigation).WithMany(p => p.AffaireIdAvocatDefendeurNavigations)
                .HasForeignKey(d => d.IdAvocatDefendeur)
                .HasConstraintName("affaire_id_avocat_defendeur_fkey");

            entity.HasOne(d => d.IdAvocatDemandeurNavigation).WithMany(p => p.AffaireIdAvocatDemandeurNavigations)
                .HasForeignKey(d => d.IdAvocatDemandeur)
                .HasConstraintName("affaire_id_avocat_demandeur_fkey");

            entity.HasOne(d => d.IdProcureurNavigation).WithMany(p => p.AffaireIdProcureurNavigations)
                .HasForeignKey(d => d.IdProcureur)
                .HasConstraintName("affaire_id_procureur_fkey");

            entity.HasOne(d => d.IdStatutNavigation).WithMany(p => p.Affaires)
                .HasForeignKey(d => d.IdStatut)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("affaire_id_statut_fkey");

            entity.HasOne(d => d.IdUserValidateurCloturationNavigation).WithMany(p => p.AffaireIdUserValidateurCloturationNavigations)
                .HasForeignKey(d => d.IdUserValidateurCloturation)
                .HasConstraintName("affaire_id_user_validateur_cloturation_fkey");

            entity.HasOne(d => d.IdUserValidateurDemandeNavigation).WithMany(p => p.AffaireIdUserValidateurDemandeNavigations)
                .HasForeignKey(d => d.IdUserValidateurDemande)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("affaire_id_user_validateur_demande_fkey");
        });

        modelBuilder.Entity<Avocat>(entity =>
        {
            entity.HasKey(e => e.IdAvocat).HasName("avocat_pkey");

            entity.ToTable("avocat");

            entity.Property(e => e.IdAvocat)
                .HasDefaultValueSql("('AVT'::text || nextval('avocat_seq'::regclass))")
                .HasColumnType("character varying")
                .HasColumnName("id_avocat");
            entity.Property(e => e.Adresse)
                .HasMaxLength(100)
                .HasColumnName("adresse");
            entity.Property(e => e.DateNaissance).HasColumnName("date_naissance");
            entity.Property(e => e.DateInscription).HasColumnName("date_inscription");
            entity.Property(e => e.DateValidationInscription).HasColumnName("date_validation_inscription");
            entity.Property(e => e.Etat).HasColumnName("etat");
            entity.Property(e => e.Genre).HasColumnName("genre");
            entity.Property(e => e.IdUtilisateurValidateur)
                .HasColumnType("character varying")
                .HasColumnName("id_utilisateur_validateur");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .HasColumnName("mail");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
            entity.Property(e => e.NumOrdre)
                .HasMaxLength(50)
                .HasColumnName("num_ordre");
            entity.Property(e => e.Password)
                .HasMaxLength(64)
                .HasColumnName("password");
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .HasColumnName("prenom");
            entity.Property(e => e.Telephone)
                .HasMaxLength(15)
                .HasColumnName("telephone");

            entity.HasOne(d => d.IdUtilisateurValidateurNavigation).WithMany(p => p.Avocats)
                .HasForeignKey(d => d.IdUtilisateurValidateur)
                .HasConstraintName("avocat_id_utilisateur_validateur_fkey");
        });

        modelBuilder.Entity<DetailsRenvoie>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("details_renvoie");

            entity.Property(e => e.IdMotifRenvoie).HasColumnName("id_motif_renvoie");
            entity.Property(e => e.IdRenvoie).HasColumnName("id_renvoie");

            entity.HasOne(d => d.IdMotifRenvoieNavigation).WithMany()
                .HasForeignKey(d => d.IdMotifRenvoie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("details_renvoie_id_motif_renvoie_fkey");

            entity.HasOne(d => d.IdRenvoieNavigation).WithMany()
                .HasForeignKey(d => d.IdRenvoie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("details_renvoie_id_renvoie_fkey");
        });

        modelBuilder.Entity<DisponibiliteAudience>(entity =>
        {
            entity.HasKey(e => e.IdDisponibiliteAudience).HasName("disponibilite_audience_pkey");

            entity.ToTable("disponibilite_audience");

            entity.Property(e => e.IdDisponibiliteAudience).HasColumnName("id_disponibilite_audience");
            entity.Property(e => e.HeureDebut).HasColumnName("heure_debut");
            entity.Property(e => e.IdSection).HasColumnName("id_section");
            entity.Property(e => e.JourSemaine).HasColumnName("jour_semaine");

            entity.HasOne(d => d.IdSectionNavigation).WithMany(p => p.DisponibiliteAudiences)
                .HasForeignKey(d => d.IdSection)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("disponibilite_audience_id_section_fkey");
        });

        modelBuilder.Entity<Enrolement>(entity =>
        {
            entity.HasKey(e => e.IdEnrolement).HasName("enrolement_pkey");

            entity.ToTable("enrolement");

            entity.Property(e => e.IdEnrolement)
                .HasDefaultValueSql("('ENR'::text || nextval('enrolement_seq'::regclass))")
                .HasColumnType("character varying")
                .HasColumnName("id_enrolement");
            entity.Property(e => e.DateEnrolement).HasColumnName("date_enrolement");
            entity.Property(e => e.IdAffaire)
                .HasColumnType("character varying")
                .HasColumnName("id_affaire");
            entity.Property(e => e.IdUserValidateur)
                .HasColumnType("character varying")
                .HasColumnName("id_user_validateur");

            entity.HasOne(d => d.IdAffaireNavigation).WithMany(p => p.Enrolements)
                .HasForeignKey(d => d.IdAffaire)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("enrolement_id_affaire_fkey");

            entity.HasOne(d => d.IdUserValidateurNavigation).WithMany(p => p.Enrolements)
                .HasForeignKey(d => d.IdUserValidateur)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("enrolement_id_user_validateur_fkey");
        });

        modelBuilder.Entity<HistoriqueTraitementAffaire>(entity =>
        {
            entity.HasKey(e => e.IdHistoriqueTraitementAffaire).HasName("historique_traitement_affaire_pkey");

            entity.ToTable("historique_traitement_affaire");

            entity.Property(e => e.IdHistoriqueTraitementAffaire)
                .HasDefaultValueSql("nextval('historique_traitement_affaire_id_historique_traitement_affa_seq'::regclass)")
                .HasColumnName("id_historique_traitement_affaire");
            entity.Property(e => e.DateChangement).HasColumnName("date_changement");
            entity.Property(e => e.IdAffaire)
                .HasColumnType("character varying")
                .HasColumnName("id_affaire");
            entity.Property(e => e.IdStatut).HasColumnName("id_statut");

            entity.HasOne(d => d.IdAffaireNavigation).WithMany(p => p.HistoriqueTraitementAffaires)
                .HasForeignKey(d => d.IdAffaire)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("historique_traitement_affaire_id_affaire_fkey");

            entity.HasOne(d => d.IdStatutNavigation).WithMany(p => p.HistoriqueTraitementAffaires)
                .HasForeignKey(d => d.IdStatut)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("historique_traitement_affaire_id_statut_fkey");
        });

        modelBuilder.Entity<MotifRenvoie>(entity =>
        {
            entity.HasKey(e => e.IdMotifRenvoie).HasName("motif_renvoie_pkey");

            entity.ToTable("motif_renvoie");

            entity.Property(e => e.IdMotifRenvoie).HasColumnName("id_motif_renvoie");
            entity.Property(e => e.Libelle)
                .HasMaxLength(500)
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<NatureAffaire>(entity =>
        {
            entity.HasKey(e => e.IdNatureAffaire).HasName("nature_affaire_pkey");

            entity.ToTable("nature_affaire");

            entity.Property(e => e.IdNatureAffaire).HasColumnName("id_nature_affaire");
            entity.Property(e => e.AffaireCommunicable).HasColumnName("affaire_communicable");
            entity.Property(e => e.Libelle)
                .HasMaxLength(500)
                .HasColumnName("libelle");
            entity.Property(e => e.PieceAfournir)
                .HasColumnType("character varying")
                .HasColumnName("piece_afournir");
            entity.Property(e => e.Prix).HasColumnName("prix");
        });

        modelBuilder.Entity<ParametrageAudience>(entity =>
        {
            entity.HasKey(e => e.IdParametrageAudience).HasName("parametrage_audience_pkey");

            entity.ToTable("parametrage_audience");

            entity.Property(e => e.IdParametrageAudience).HasColumnName("id_parametrage_audience");
            entity.Property(e => e.DateHeureAudienceAjour)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_heure_audience_ajour");
            entity.Property(e => e.HuisClos).HasColumnName("huis_clos");
            entity.Property(e => e.IdAffaire)
                .HasColumnType("character varying")
                .HasColumnName("id_affaire");
            entity.Property(e => e.IdUserValidateur)
                .HasColumnType("character varying")
                .HasColumnName("id_user_validateur");
            entity.Property(e => e.TypeAudience).HasColumnName("type_audience");

            entity.HasOne(d => d.IdAffaireNavigation).WithMany(p => p.ParametrageAudiences)
                .HasForeignKey(d => d.IdAffaire)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("parametrage_audience_id_affaire_fkey");

            entity.HasOne(d => d.IdUserValidateurNavigation).WithMany(p => p.ParametrageAudiences)
                .HasForeignKey(d => d.IdUserValidateur)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("parametrage_audience_id_user_validateur_fkey");
        });

        modelBuilder.Entity<Payement>(entity =>
        {
            entity.HasKey(e => e.IdPayement).HasName("payement_pkey");

            entity.ToTable("payement");

            entity.Property(e => e.IdPayement).HasColumnName("id_payement");
            entity.Property(e => e.DateValidation).HasColumnName("date_validation");
            entity.Property(e => e.IdAffaire)
                .HasColumnType("character varying")
                .HasColumnName("id_affaire");
            entity.Property(e => e.IdTypePayement).HasColumnName("id_type_payement");
            entity.Property(e => e.IdUserValidateur)
                .HasColumnType("character varying")
                .HasColumnName("id_user_validateur");
            entity.Property(e => e.MontantRecu).HasColumnName("montant_recu");

            entity.HasOne(d => d.IdAffaireNavigation).WithMany(p => p.Payements)
                .HasForeignKey(d => d.IdAffaire)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payement_id_affaire_fkey");

            entity.HasOne(d => d.IdTypePayementNavigation).WithMany(p => p.Payements)
                .HasForeignKey(d => d.IdTypePayement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payement_id_type_payement_fkey");

            entity.HasOne(d => d.IdUserValidateurNavigation).WithMany(p => p.Payements)
                .HasForeignKey(d => d.IdUserValidateur)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payement_id_user_validateur_fkey");
        });

        modelBuilder.Entity<Plumitif>(entity =>
        {
            entity.HasKey(e => e.IdPlumitif).HasName("plumitif_pkey");

            entity.ToTable("plumitif");

            entity.Property(e => e.IdPlumitif).HasColumnName("id_plumitif");
            entity.Property(e => e.DateRedaction).HasColumnName("date_redaction");
            entity.Property(e => e.DateValidation).HasColumnName("date_validation");
            entity.Property(e => e.IdAffaire)
                .HasColumnType("character varying")
                .HasColumnName("id_affaire");
            entity.Property(e => e.IdUserRedacteur)
                .HasColumnType("character varying")
                .HasColumnName("id_user_redacteur");
            entity.Property(e => e.IdUserValidateur)
                .HasColumnType("character varying")
                .HasColumnName("id_user_validateur");
            entity.Property(e => e.Jugement)
                .HasColumnType("character varying")
                .HasColumnName("jugement");

            entity.HasOne(d => d.IdAffaireNavigation).WithMany(p => p.Plumitifs)
                .HasForeignKey(d => d.IdAffaire)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("plumitif_id_affaire_fkey");

            entity.HasOne(d => d.IdUserRedacteurNavigation).WithMany(p => p.PlumitifIdUserRedacteurNavigations)
                .HasForeignKey(d => d.IdUserRedacteur)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("plumitif_id_user_redacteur_fkey");

            entity.HasOne(d => d.IdUserValidateurNavigation).WithMany(p => p.PlumitifIdUserValidateurNavigations)
                .HasForeignKey(d => d.IdUserValidateur)
                .HasConstraintName("plumitif_id_user_validateur_fkey");
        });

        modelBuilder.Entity<Profil>(entity =>
        {
            entity.HasKey(e => e.IdProfil).HasName("profil_pkey");

            entity.ToTable("profil");

            entity.Property(e => e.IdProfil).HasColumnName("id_profil");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<QuestionnairePlumitif>(entity =>
        {
            entity.HasKey(e => e.IdQuestionnairePlumitif).HasName("questionnaire_plumitif_pkey");

            entity.ToTable("questionnaire_plumitif");

            entity.Property(e => e.IdQuestionnairePlumitif).HasColumnName("id_questionnaire_plumitif");
            entity.Property(e => e.IdPlumitif).HasColumnName("id_plumitif");
            entity.Property(e => e.NomInterroger)
                .HasMaxLength(50)
                .HasColumnName("nom_interroger");
            entity.Property(e => e.Question)
                .HasColumnType("character varying")
                .HasColumnName("question");
            entity.Property(e => e.Reponse)
                .HasColumnType("character varying")
                .HasColumnName("reponse");

            entity.HasOne(d => d.IdPlumitifNavigation).WithMany(p => p.QuestionnairePlumitifs)
                .HasForeignKey(d => d.IdPlumitif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("questionnaire_plumitif_id_plumitif_fkey");
        });

        modelBuilder.Entity<Renvoie>(entity =>
        {
            entity.HasKey(e => e.IdRenvoie).HasName("renvoie_pkey");

            entity.ToTable("renvoie");

            entity.Property(e => e.IdRenvoie).HasColumnName("id_renvoie");
            entity.Property(e => e.DateRenvoie).HasColumnName("date_renvoie");
            entity.Property(e => e.IdAffaire)
                .HasColumnType("character varying")
                .HasColumnName("id_affaire");
            entity.Property(e => e.IdUserResponsable)
                .HasColumnType("character varying")
                .HasColumnName("id_user_responsable");

            entity.HasOne(d => d.IdAffaireNavigation).WithMany(p => p.Renvoies)
                .HasForeignKey(d => d.IdAffaire)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("renvoie_id_affaire_fkey");

            entity.HasOne(d => d.IdUserResponsableNavigation).WithMany(p => p.Renvoies)
                .HasForeignKey(d => d.IdUserResponsable)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("renvoie_id_user_responsable_fkey");
        });

        modelBuilder.Entity<SalleAudience>(entity =>
        {
            entity.HasKey(e => e.IdSalleAudience).HasName("salle_audience_pkey");

            entity.ToTable("salle_audience");

            entity.Property(e => e.IdSalleAudience).HasColumnName("id_salle_audience");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.IdSection).HasName("section_pkey");

            entity.ToTable("section");

            entity.HasIndex(e => e.IdSalleAudience, "section_id_salle_audience_key").IsUnique();

            entity.Property(e => e.IdSection).HasColumnName("id_section");
            entity.Property(e => e.IdSalleAudience).HasColumnName("id_salle_audience");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");

            entity.HasOne(d => d.IdSalleAudienceNavigation).WithOne(p => p.Section)
                .HasForeignKey<Section>(d => d.IdSalleAudience)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("section_id_salle_audience_fkey");
        });

        modelBuilder.Entity<SousSection>(entity =>
        {
            entity.HasKey(e => e.IdSousSection).HasName("sous_section_pkey");

            entity.ToTable("sous_section");

            entity.Property(e => e.IdSousSection).HasColumnName("id_sous_section");
            entity.Property(e => e.Etat).HasColumnName("etat");
            entity.Property(e => e.IdSection).HasColumnName("id_section");
            entity.Property(e => e.IdUserGreffierAudiencier)
                .HasColumnType("character varying")
                .HasColumnName("id_user_greffier_audiencier");
            entity.Property(e => e.IdUserJuge)
                .HasColumnType("character varying")
                .HasColumnName("id_user_juge");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");

            entity.HasOne(d => d.IdSectionNavigation).WithMany(p => p.SousSections)
                .HasForeignKey(d => d.IdSection)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sous_section_id_section_fkey");

            entity.HasOne(d => d.IdUserGreffierAudiencierNavigation).WithMany(p => p.SousSectionIdUserGreffierAudiencierNavigations)
                .HasForeignKey(d => d.IdUserGreffierAudiencier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sous_section_id_user_greffier_audiencier_fkey");

            entity.HasOne(d => d.IdUserJugeNavigation).WithMany(p => p.SousSectionIdUserJugeNavigations)
                .HasForeignKey(d => d.IdUserJuge)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sous_section_id_user_juge_fkey");
        });

        modelBuilder.Entity<StandardServiceType>(entity =>
        {
            entity.HasKey(e => e.IdStandardServiceType).HasName("standard_service_type_pkey");

            entity.ToTable("standard_service_type");

            entity.Property(e => e.IdStandardServiceType).HasColumnName("id_standard_service_type");
            entity.Property(e => e.AttenteParametrage).HasColumnName("attente_parametrage");
            entity.Property(e => e.AttenteValidationPlumitif).HasColumnName("attente_validation_plumitif");
            entity.Property(e => e.IdTypeDossier).HasColumnName("id_type_dossier");

            entity.HasOne(d => d.IdTypeDossierNavigation).WithMany(p => p.StandardServiceTypes)
                .HasForeignKey(d => d.IdTypeDossier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("standard_service_type_id_type_dossier_fkey");
        });

        modelBuilder.Entity<Statut>(entity =>
        {
            entity.HasKey(e => e.IdStatut).HasName("statut_pkey");

            entity.ToTable("statut");

            entity.Property(e => e.IdStatut).HasColumnName("id_statut");
            entity.Property(e => e.Nom)
                .HasMaxLength(500)
                .HasColumnName("nom");
            entity.Property(e => e.ValeurEtape).HasColumnName("valeur_etape");
        });

        modelBuilder.Entity<TypeDossier>(entity =>
        {
            entity.HasKey(e => e.IdTypeDossier).HasName("type_dossier_pkey");

            entity.ToTable("type_dossier");

            entity.Property(e => e.IdTypeDossier).HasColumnName("id_type_dossier");
            entity.Property(e => e.Libelle)
                .HasMaxLength(500)
                .HasColumnName("libelle");
            entity.Property(e => e.Prix).HasColumnName("prix");
        });

        modelBuilder.Entity<TypePayement>(entity =>
        {
            entity.HasKey(e => e.IdTypePayement).HasName("type_payement_pkey");

            entity.ToTable("type_payement");

            entity.Property(e => e.IdTypePayement).HasColumnName("id_type_payement");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.IdUtilisateur).HasName("utilisateur_pkey");

            entity.ToTable("utilisateur");

            entity.Property(e => e.IdUtilisateur)
                .HasDefaultValueSql("('USER'::text || nextval('utilisateur_seq'::regclass))")
                .HasColumnType("character varying")
                .HasColumnName("id_utilisateur");
            entity.Property(e => e.Adresse)
                .HasMaxLength(100)
                .HasColumnName("adresse");
            entity.Property(e => e.DateInscription).HasColumnName("date_inscription");
            entity.Property(e => e.DateNaissance).HasColumnName("date_naissance");
            entity.Property(e => e.Etat).HasColumnName("etat");
            entity.Property(e => e.Genre).HasColumnName("genre");
            entity.Property(e => e.IdProfil).HasColumnName("id_profil");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .HasColumnName("mail");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
            entity.Property(e => e.Password)
                .HasMaxLength(64)
                .HasColumnName("password");
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .HasColumnName("prenom");
            entity.Property(e => e.Telephone)
                .HasMaxLength(15)
                .HasColumnName("telephone");

            entity.HasOne(d => d.IdProfilNavigation).WithMany(p => p.Utilisateurs)
                .HasForeignKey(d => d.IdProfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("utilisateur_id_profil_fkey");
        });

        modelBuilder.Entity<Visa>(entity =>
        {
            entity.HasKey(e => e.IdVisa).HasName("visa_pkey");

            entity.ToTable("visa");

            entity.Property(e => e.IdVisa).HasColumnName("id_visa");
            entity.Property(e => e.DateCreation).HasColumnName("date_creation");
            entity.Property(e => e.DateHeureAudience)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_heure_audience");
            entity.Property(e => e.IdAffaire)
                .HasColumnType("character varying")
                .HasColumnName("id_affaire");
            entity.Property(e => e.IdNatureAffaire).HasColumnName("id_nature_affaire");
            entity.Property(e => e.IdSalleAudience).HasColumnName("id_salle_audience");
            entity.Property(e => e.IdSection).HasColumnName("id_section");
            entity.Property(e => e.IdSousSection).HasColumnName("id_sous_section");
            entity.Property(e => e.IdTypeDossier).HasColumnName("id_type_dossier");
            entity.Property(e => e.IdUserValidateur)
                .HasColumnType("character varying")
                .HasColumnName("id_user_validateur");

            entity.HasOne(d => d.IdAffaireNavigation).WithMany(p => p.Visas)
                .HasForeignKey(d => d.IdAffaire)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visa_id_affaire_fkey");

            entity.HasOne(d => d.IdNatureAffaireNavigation).WithMany(p => p.Visas)
                .HasForeignKey(d => d.IdNatureAffaire)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visa_id_nature_affaire_fkey");

            entity.HasOne(d => d.IdSalleAudienceNavigation).WithMany(p => p.Visas)
                .HasForeignKey(d => d.IdSalleAudience)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visa_id_salle_audience_fkey");

            entity.HasOne(d => d.IdSectionNavigation).WithMany(p => p.Visas)
                .HasForeignKey(d => d.IdSection)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visa_id_section_fkey");

            entity.HasOne(d => d.IdSousSectionNavigation).WithMany(p => p.Visas)
                .HasForeignKey(d => d.IdSousSection)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visa_id_sous_section_fkey");

            entity.HasOne(d => d.IdTypeDossierNavigation).WithMany(p => p.Visas)
                .HasForeignKey(d => d.IdTypeDossier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visa_id_type_dossier_fkey");

            entity.HasOne(d => d.IdUserValidateurNavigation).WithMany(p => p.Visas)
                .HasForeignKey(d => d.IdUserValidateur)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visa_id_user_validateur_fkey");
        });
        modelBuilder.HasSequence("affaire_seq");
        modelBuilder.HasSequence("avocat_seq");
        modelBuilder.HasSequence("enrolement_seq");
        modelBuilder.HasSequence("utilisateur_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
