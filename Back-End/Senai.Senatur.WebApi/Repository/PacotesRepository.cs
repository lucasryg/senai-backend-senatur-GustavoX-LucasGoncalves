
using Senai.Senatur.WebApi.DataBaseFirst.Interfaces;
using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.DataBaseFirst.Repository
{
    public class PacotesRepository : IPacotesRepository
    {
        SenaturContext ctx = new SenaturContext();

        public void Atualizar(int id, Pacotes pacoteAtualizado)
        {
            Pacotes pacoteBuscado = ctx.Pacotes.Find(id);

            pacoteBuscado.NomePacote = pacoteAtualizado.NomePacote;
            pacoteBuscado.Descricao = pacoteAtualizado.Descricao;
            pacoteBuscado.DataIda = pacoteAtualizado.DataIda;
            pacoteBuscado.DataVolta = pacoteAtualizado.DataVolta;
            pacoteBuscado.Valor = pacoteAtualizado.Valor;
            pacoteBuscado.Ativo = pacoteAtualizado.Ativo;
            pacoteBuscado.NomeCidade = pacoteAtualizado.NomeCidade;


            ctx.Pacotes.Update(pacoteBuscado);


            ctx.SaveChanges();
        }

        public Pacotes BuscarPorId(int id)
        {
            return ctx.Pacotes.FirstOrDefault(p => p.IdPacote == id);
        }

        public void Cadastrar(Pacotes pacotes)
        {
            ctx.Pacotes.Add(pacotes);


            ctx.SaveChanges();

        }

        public Pacotes Cidades(string cidade)
        {
            return ctx.Pacotes.FirstOrDefault(p => p.NomeCidade == cidade);
        }

        public List<Pacotes> Listar()
        {
            return ctx.Pacotes.ToList();
        }

        public List<Pacotes> PacotesAtivos()
        {
            throw new NotImplementedException();
        }

        public List<Pacotes> PacotesInativos()
        {
            throw new NotImplementedException();
        }

        public List<Pacotes> PorPreco(int preco)
        {
            throw new NotImplementedException();
        }

    }
}
