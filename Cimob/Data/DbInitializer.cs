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
            if (!context.Documentacao.Any())
            {
                //Regulamentos
                context.Documentacao.Add(new Documentacao { Descricao = "Regulamento do Processo de Registo de Diplomas Estrangeiros.", Nome= "Portaria n.º 292008, de 10 de Janeiro (PDF | 1.213KB)", Caminho= "~/Regulamentos/Portaria.pdf" });
                context.Documentacao.Add(new Documentacao { Descricao = "Modelos de impressos de requerimento ao abrigo deste regime jurídico.", Nome = "Portaria n.º 107183, de 29 de Dezembro (PDF | 183KB)", Caminho = "~/Regulamentos/Portaria2.pdf" });
                context.Documentacao.Add(new Documentacao { Descricao = "que implementa o Processo de Bolonha em Portugal", Nome = "Decreto-Lei n.º 422005, de 22 de Fevereiro (PDF | 66KB)", Caminho = "~/Regulamentos/DecretoLei.pdf" });
                context.Documentacao.Add(new Documentacao { Descricao = "que introduz alterações devido à implementação do Processo de Bolonha.", Nome = "Decreto-Lei n.º 1072008, de 25 de Junho (PDF | 274KB)", Caminho = "~/Regulamentos/DecretoLei2.pdf" });
                //Bolsas
                context.Documentacao.Add(new Documentacao { Descricao = "valores disponíveis para o ano lectivo corrente.", Nome = "Bolsas de Mobilidade (PDF | 98KB)", Caminho = "~/Bolsas/Tabela_Bolsas_2017_035338.pdf" });
                context.Documentacao.Add(new Documentacao { Descricao = "o Art.º 23º do Regulamento de Atribuição de Bolsas de Estudo a Estudantes do Ensino Superior possui os critérios para o cálculo do complemento mensal.", Nome = "Despacho n.º 7031-B/2015, de 24 de junho de 2015 (PDF | 296KB)", Caminho = "~/Bolsas/Regulamento_Bolsas_2015.pdf" });
                context.SaveChanges();
            }
            if (!context.Concurso_Bolsa.Any())
            {
                  //Bolsas
                context.Concurso_Bolsa.Add(new Concurso_Bolsa { ConcursoId=1, DocumentacaoId=5});
                context.Concurso_Bolsa.Add(new Concurso_Bolsa { ConcursoId = 1, DocumentacaoId = 6 });
                context.SaveChanges();
            }
            if (!context.Concurso_Regulamento.Any())
            {
                //Bolsas
                context.Concurso_Regulamento.Add(new Concurso_Regulamento { ConcursoId = 1, DocumentacaoId = 5 });
                context.Concurso_Regulamento.Add(new Concurso_Regulamento { ConcursoId = 1, DocumentacaoId = 6 });
                context.SaveChanges();
            }
        }
    }
}
