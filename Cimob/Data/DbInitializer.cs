using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cimob.Data;
using Cimob.Models;
using Cimob.Models.Candidatura;
using Cimob.Models.Estatística;
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
                context.TipoConcurso.Add(new TipoConcurso { Nome = "Vasco Da Gama",  Imagem= "~/images/vascoGama.png" });        
                context.SaveChanges();
            }
            if (!context.Escola.Any())
            {
                context.Escola.Add(new Escola { Nome = "EST" , Url= "http://www.estsetubal.ips.pt/" , Pais="Portugal"});
                context.Escola.Add(new Escola { Nome = "Universidade de Évora", Url = "http://www.uevora.pt/", Pais = "Portugal" });
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
           if (!context.AjudaAutenticacao.Any())
            {
                context.AjudaAutenticacao.Add(new AjudaAutenticacao {  Descricao="Na presente página é possivel consultar todos os tipos de concursos. Estes podem ser apresentados por padrão, por tipo de concurso, por País ou por parcerias. Além disso, estes dividem-se em dois grupos, os concursos para docentes e concursos para Estudantes. Um estudante não se pode candidatar a um concurso para docente e vice-versa. Além disso, não é possível candidatar-se ao mesmo concurso duas vezes.", Controlador="Concursoes", Metodo="Index" });
                context.AjudaAutenticacao.Add(new AjudaAutenticacao {  Descricao = "Aqui poderá ver todas as informações sobre o concurso e candidatar-se ao mesmo caso esteja logado, ainda não se tenha candidatado ao mesmo e este seja para o seu tipo de utilizador.", Controlador = "Concursoes", Metodo = "consultarDetalhe" });
                context.AjudaAutenticacao.Add(new AjudaAutenticacao {  Descricao = "Aqui poderá consultar os pontos de interese e a sua localização.", Controlador = "PontoInteresses", Metodo = "Index" });
                context.AjudaAutenticacao.Add(new AjudaAutenticacao { Descricao = "Aqui poderá consultar as parcerias e consultar o respectivo Website.", Controlador = "Escolas", Metodo = "SearchEscolas" });
                context.AjudaAutenticacao.Add(new AjudaAutenticacao { Descricao = "Aqui poderá consultar as candidaturas de todos os utilizadores, vê-las ao detalhe e alterar-lhes o Estado. Ao fazer uma alteração no estado o utilizador recebe uim email com notificação. Caso aceite uma candidatura, ser-lhe-á pedido para marcar uma entrevista.", Controlador = "Candidaturas", Metodo = "IndexAdministrador" });
                context.AjudaAutenticacao.Add(new AjudaAutenticacao { Descricao = "Aqui poderá consultar as entrevistas, os tuilizadores, data e hora de cada entrevista.", Controlador = "Entrevista", Metodo = "Index" });
                context.AjudaAutenticacao.Add(new AjudaAutenticacao { Descricao = "Aqui poderá consultar as estatísticas referentes ao CIMOB.", Controlador = "Estatistica", Metodo = "Index" });
                context.SaveChanges();
            }
            if (!context.Estatistica.Any())
            {
                context.Estatistica.Add(new Estatistica { Nome = "País com mais candidaturas", Descricao = "País para onde os utilizadores mais se candidatam", Dados = "<?xml version='1.0' encoding='utf-8'?><anychart xmlns='https://cdn.anychart.com/schemas/8.1.0/xml-schema.xsd'><chart type='pie' container='container' title='XML Sample Pie'><data><point name='Portugal' value='32' fill='Green'/><point name='Brasil' value='13' fill='Orange'/><point name='Chile' value='14' fill='Red'/><point name='China' value='4' fill='Yellow'/><point name='Bélgica' value='4' fill='Blue'/><point name='República Checa' value='1' fill='Purple'/><point name='Dinamarca' value='1' fill='Black'/><point name='Alemanha' value='1' fill='Grey'/></data></chart></anychart>" });
                context.Estatistica.Add(new Estatistica { Nome = "Escolas com mais candidaturas", Descricao = "Escolas para onde os utilizadores mais se candidatam", Dados = "<?xml version='1.0' encoding='utf-8'?><anychart xmlns='https://cdn.anychart.com/schemas/8.1.0/xml-schema.xsd'><chart type='pie' container='container' title='XML Sample Pie'><data><point name='ISEL' value='32' fill='Green'/><point name='Universidade de Alcalá' value='13' fill='Orange'/><point name='Universidade de Anáhuac' value='14' fill='Red'/><point name='IP Macau' value='4' fill='Yellow'/><point name='Universidade Médica - Varna' value='4' fill='Blue'/><point name='Universidade de Tecnologia de Brno' value='1' fill='Purple'/><point name='Universidade de Aalborg' value='1' fill='Black'/><point name='ISM' value='1' fill='Grey'/></data></chart></anychart>" });
                context.Estatistica.Add(new Estatistica { Nome = "Concursos de estudantes com mais candidaturas", Descricao = "Concursos para onde os alunos mais se candidatam", Dados = "<?xml version='1.0' encoding='utf-8'?><anychart xmlns='https://cdn.anychart.com/schemas/8.1.0/xml-schema.xsd'><chart type='pie' container='container' title='XML Sample Pie'><data><point name='Vasco da Gama-ISEL' value='32' fill='Green'/><point name='BOLSAS IBERO-AMERICANAS SANTANDER - Brasil' value='13' fill='Orange'/><point name='BOLSAS IBERO-AMERICANAS SANTANDER - Chile' value='14' fill='Red'/><point name='BOLSAS IBERO-AMERICANAS SANTANDER - México' value='4' fill='Yellow'/></data></chart></anychart>" });
                context.Estatistica.Add(new Estatistica { Nome = "Cursos de origem dos candidatos", Descricao = "Cursos de origem dos candidatos", Dados = "<?xml version='1.0' encoding='utf-8'?><anychart xmlns='https://cdn.anychart.com/schemas/8.1.0/xml-schema.xsd'><chart type='pie' container='container' title='XML Sample Pie'><data><point name='Engenharia Informática' value='42' fill='Green'/><point name='Enfermagem' value='4' fill='Orange'/><point name='Contabilidade e Gestão' value='14' fill='Red'/><point name='Tecnologia Biomédica' value='4' fill='Yellow'/><point name='Engenharia do Ambiente' value='8' fill='Grey'/></data></chart></anychart>" });
                context.Estatistica.Add(new Estatistica { Nome = "Concursos de docentes com mais candidaturas", Descricao = "Concursos para onde os docentes mais se candidatam", Dados = "<?xml version='1.0' encoding='utf-8'?><anychart xmlns='https://cdn.anychart.com/schemas/8.1.0/xml-schema.xsd'><chart type='pie' container='container' title='XML Sample Pie'><data><point name='Erasmus Docentes- Bélgica' value='4' fill='Blue'/><point name='Erasmus Docentes- República Checa' value='1' fill='Purple'/><point name='Erasmus Docentes- Dinamarca' value='1' fill='Black'/><point name='Erasmus Docentes- Alemanha' value='1' fill='Grey'/></data></chart></anychart>" });
                context.SaveChanges();
            }



        }
    }
}
