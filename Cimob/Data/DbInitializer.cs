using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cimob.Data;
using Cimob.Models;
using Cimob.Models.Candidatura;
using Cimob.Models.PontosInteresse;
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
                    EscolaID = 2,
                    Descricao = "O programa Vasco da Gama é um programa de mobilidade entre escolas do ensino politécnico.O intercâmbio de estudantes ao abrigo do programa implica um acordo prévio entre a instituição de origem e a instituição de acolhimento, assinado pelos respectivos responsáveis.A mobilidade de estudantes abrange também os estágios, trabalhos de fim de curso ou projectos finais, desde que as referidas actividades integrem o plano curricular do curso na escola de origem.",
                    Nome = "Vasco da Gama em Évora",
                    Prazo = DateTime.Today,
                    TipoDeUtilizadorId = 2,
                    TipoConcursoId = 1
                });
                context.Concurso.Add(new Concurso
                {
                    EscolaID = 2,
                    Descricao = "O programa Vasco da Gama é um programa de mobilidade entre escolas do ensino politécnico.O intercâmbio de estudantes ao abrigo do programa implica um acordo prévio entre a instituição de origem e a instituição de acolhimento, assinado pelos respectivos responsáveis.A mobilidade de estudantes abrange também os estágios, trabalhos de fim de curso ou projectos finais, desde que as referidas actividades integrem o plano curricular do curso na escola de origem.",
                    Nome = "Vasco da Gama em Évora",
                    Prazo = DateTime.Today,
                    TipoDeUtilizadorId = 1,
                    TipoConcursoId = 1
                });
                context.SaveChanges();
            }
            if (!context.EstadoCandidatura.Any())
            {
                context.EstadoCandidatura.Add(new EstadoCandidatura { NomeEstado = "A aguardar aprovação" });
                context.EstadoCandidatura.Add(new EstadoCandidatura { NomeEstado = "Aceite" });
                context.EstadoCandidatura.Add(new EstadoCandidatura { NomeEstado = "Rejeitada" });
                context.SaveChanges();
            }
            if (!context.PontoInteresse.Any())
            {
                context.PontoInteresse.Add(new PontoInteresse { Nome = "EST", Url= "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12486.02758090049!2d-8.838784!3d38.522082!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xa0df10aa0caa2efa!2sInstituto+Polit%C3%A9cnico+de+Set%C3%BAbal!5e0!3m2!1spt-PT!2sus!4v1518371014365" });
                context.PontoInteresse.Add(new PontoInteresse { Nome = "Universidade de Évora", Url = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3119.2908500083818!2d-7.907848585274482!3d38.57314957359758!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd19e4dd79fbd2ad%3A0x6a31af5facc62c1b!2sUniversidade+de+%C3%89vora!5e0!3m2!1spt-PT!2sus!4v1518371071976" });
                context.PontoInteresse.Add(new PontoInteresse { Nome = "Catedral de Évora", Url = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3119.350185028786!2d-7.909174885274503!3d38.57178297367762!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd19efffc4c3c055%3A0x31b5af8e6b9a1a18!2sCatedral+de+%C3%89vora!5e0!3m2!1spt-PT!2sus!4v1518371134850" });
                context.PontoInteresse.Add(new PontoInteresse { Nome = "Serra da Arrábida", Url = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d12489.854687458905!2d-9.00875477375297!3d38.500015917168916!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd194568ceecf761%3A0x6c3af723efb0427e!2sSerra+da+Arr%C3%A1bida!5e0!3m2!1spt-PT!2sus!4v1518371241544" });

                context.SaveChanges();
            }

        }
    }
}
