using CodeFirstTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTest
{
    class LibraryDbContext : DbContext
    {
        public LibraryDbContext() : base("LibraryCloudConnection")
        {
        }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.OnGenreModelCreating(modelBuilder);
            this.OnAutorModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder); // always call this at the end
        }

        private void OnAutorModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasKey(genre => genre.Id);

            modelBuilder.Entity<Genre>()
                .Property(genre => genre.Name)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Name") { IsUnique = true }));
        }

        private void OnGenreModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
