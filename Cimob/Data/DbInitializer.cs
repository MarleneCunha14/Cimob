using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cimob.Data;
using Cimob.Models;
using Cimob.Models.Candidatura;
using Cimob.Models.Utilizadores;

namespace TopCar.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (  !context.TipoDeUser.Any())
            {
                context.TipoDeUser.Add(new TipoDeUser { nomeTipo = "Estudante" });
                context.TipoDeUser.Add(new TipoDeUser { nomeTipo = "Docente" });
                context.SaveChanges();               
            }
            if (  !context.Pais.Any())
            {
                context.Pais.Add(new Pais {  NomePais = "Portugal" });
                context.Pais.Add(new Pais {  NomePais = "Brasil" });
                context.SaveChanges();
            }
            if (!context.TipoConcurso.Any())
            {
                context.TipoConcurso.Add(new TipoConcurso { Nome = "Vasco Da Gama", Descricao= "O programa Vasco da Gama é um programa de mobilidade de estudantes entre escolas do< br >ensino politécnico.< br >O intercâmbio de estudantes ao abrigo do programa implica um acordo prévio entre a instituição de origem e a instituição de acolhimento, assinado pelos respectivos responsáveis.< br >A mobilidade de estudantes abrange também os estágios, trabalhos de fim de curso ou projectos finais, desde que as referidas actividades integrem o plano curricular do curso na escola de origem.</ p > ", Imagem= "~/images/vascoGama.png" });        
                context.SaveChanges();
            }
            if (!context.Escola.Any())
            {
                context.Escola.Add(new Escola { Nome = "EST" , Url= "http://www.estsetubal.ips.pt/" , Descricao="é em setúbal", Imagem = "~/images/simboloIPS.png" , Pais="Portugal"});
                context.Escola.Add(new Escola { Nome = "Universidade de Évora", Url = "http://www.uevora.pt/", Descricao = "é em Évora", Imagem = "~/images/simboloIPS.png", Pais = "Portugal" });
                context.SaveChanges();
            }
            if (!context.Concurso.Any())
            {               
                context.Concurso.Add(new Concurso
                {
                    EscolaID = 1,
                    Descricao = "O programa Vasco da Gama é um programa de mobilidade de estudantes entre escolas do ensino politécnico.O intercâmbio de estudantes ao abrigo do programa implica um acordo prévio entre a instituição de origem e a instituição de acolhimento, assinado pelos respectivos responsáveis.A mobilidade de estudantes abrange também os estágios, trabalhos de fim de curso ou projectos finais, desde que as referidas actividades integrem o plano curricular do curso na escola de origem.",
                    Nome = "Vasco da Gama em Évora",
                    Prazo = DateTime.Today,
                    TipoDeUtilizadorId = 2,
                    TipoConcursoId = 1
                });
                context.SaveChanges();
            }
            if (!context.EstadoCandidatura.Any())
            {
                context.EstadoCandidatura.Add(new EstadoCandidatura { NomeEstado = "A aguardar aprovação" });
                context.SaveChanges();
            }
            
        }
    }
}
