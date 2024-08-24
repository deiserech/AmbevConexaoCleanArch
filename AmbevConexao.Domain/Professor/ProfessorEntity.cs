﻿using AmbevConexao.Domain.Common;
using AmbevConexao.Domain.Curso;

namespace AmbevConexao.Domain.Professor
{
    public class ProfessorEntity : IEntity
    {
        public int Id { get; set; }
        public string? Nome { get; private set; }
        public string? Email { get; private set; }
        public List<CursoEntity> Cursos { get; set; } = new List<CursoEntity>();

        public static ProfessorEntity NovoProfessor(string nome, string email)
        {
            var professor = new ProfessorEntity
            {
                Nome = nome,
                Email = email
            };

            return professor;
        }

        public ProfessorEntity AlterarNome(string novoNome)
        {
            Nome = novoNome;
            return this;
        }

        public ProfessorEntity AlterarEmail(string novoEmail)
        {
            Email = novoEmail;
            return this;
        }
    }
}
