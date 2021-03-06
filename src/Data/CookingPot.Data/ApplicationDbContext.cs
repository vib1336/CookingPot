﻿namespace CookingPot.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using CookingPot.Data.Common.Models;
    using CookingPot.Data.Models;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Subcategory> Subcategories { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductRecipe> ProductRecipes { get; set; }

        public DbSet<Vote> Votes { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<ApprovalRecipe> ApprovalRecipes { get; set; }

        public DbSet<ViewCount> ViewCounts { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Set many-to-many
            builder.Entity<ProductRecipe>(entity =>
            {
                entity.HasKey(pr => new { pr.RecipeId, pr.ProductId });
            });
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
            => this.ChangeTracker
            .Entries()
            .ToList()
            .ForEach(entry =>
            {
                if (entry.Entity is IAuditInfo entity)
                {
                    if (entry.State == EntityState.Added && entity.CreatedOn == default)
                    {
                        entity.CreatedOn = DateTime.UtcNow;
                    }
                    else
                    {
                        entity.ModifiedOn = DateTime.UtcNow;
                    }
                }

                if (entry.Entity is IDeletableEntity deletableEntity)
                {
                    if (deletableEntity.IsDeleted)
                    {
                        deletableEntity.DeletedOn = DateTime.UtcNow;
                    }
                }
            });
    }
}
