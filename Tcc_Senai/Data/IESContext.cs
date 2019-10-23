using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_Senai.Models;
using static System.Collections.Immutable.ImmutableArray<Tcc_Senai.Models.ProfessorCurso>;

namespace Tcc_Senai.Data
{
    public class IESContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<ProfessorCurso>().HasKey(sc => new { sc.IdCurso, sc.IdProfessor });

        }
        public IESContext(DbContextOptions<IESContext> options) : base(options)
        {
        }

        public DbSet<Professor> Professores { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }
        public DbSet<Coordenador> Coordenadores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<GerarCurso> GerarCursos { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Pedagogo> Pedagogos { get; set; }
        public DbSet<Semestre> Semestres { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<UnidadeCurricular> UnidadeCurriculares { get; set; }
        public DbSet<ProfessorCurso> ProfessorCursos { get; set; }




    }
}
