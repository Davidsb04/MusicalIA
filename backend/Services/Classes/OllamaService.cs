using OllamaSharp;
using Musicalia.Services.Interfaces;
using System.Runtime.Intrinsics.X86;
using System;

namespace Musicalia.Services.Classes
{
    public class OllamaService : IOllamaService
    {
        private readonly OllamaApiClient _ollamaApiClient;

        public OllamaService()
        {
            _ollamaApiClient = new OllamaApiClient("http://host.docker.internal:11434", "llama3.2:latest");
        }

        public async Task<string> GetMusicalGenreByOllama(string userRequest)
        {
            try
            {
                var genres = new List<string> 
                {
                    "Pop,",
                    "rap,",
                    "rock,",
                    "urbanolatino,",
                    "hiphop,",
                    "traplatino,",
                    "reggaeton,",
                    "dancepop,",
                    "poprap,",
                    "modernrock,",
                    "povindie,",
                    "musicamexicana,",
                    "latinpop,",
                    "classicrock,",
                    "filmi,",
                    "permanentwave,",
                    "trap,",
                    "alternativemetal,",
                    "k-pop,",
                    "r&b,",
                    "corrido,",
                    "canadianpop,",
                    "norteno,",
                    "sierreno,",
                    "albumrock,",
                    "softock,",
                    "popdance,",
                    "sadierreno,",
                    "edm,",
                    "hardrock,",
                    "contemporarycountry,",
                    "mellowgold,",
                    "ukpop,",
                    "melodicrap,",
                    "modernbollywood,",
                    "alternativerock,",
                    "banda,",
                    "post-grunge,",
                    "corridostumbados,",
                    "sertanejouniversitario,",
                    "numetal,",
                    "country,",
                    "artpop,",
                    "atlhiphop,",
                    "urbancontemporary,",
                    "sertanejo,",
                    "southernhiphop,",
                    "singer-songwriter,",
                    "reggaetoncolombiano,",
                    "arrocha,",
                    "frenchhiphop,",
                    "colombianpop,",
                    "altz,",
                    "countryroad,",
                    "mexicanpop,",
                    "canadianhiphop,",
                    "j-pop,",
                    "indonesianpop,",
                    "singer-songwriterpop,",
                    "ranchera,",
                    "newwavepop,",
                    "indietronica,",
                    "germanhiphop,",
                    "popurbaine,",
                    "rockenespanol,",
                    "latinalternative,",
                    "gangsterrap,",
                    "soul,",
                    "k-popboygroup,",
                    "latinarenapop,",
                    "chicagorap,",
                    "italianpop,",
                    "heartlandrock,",
                    "k-popgirlgroup,",
                    "agronejo,",
                    "moderncountrypop,",
                    "electrohouse,",
                    "latinhiphop,",
                    "canadiancontemporaryr&b,",
                    "poppunk,",
                    "neomellow,",
                    "poprock,",
                    "latinrock,",
                    "punjabipop,",
                    "rapmetal,",
                    "trapargentino,",
                    "newromantic,",
                    "newwave,",
                    "ukdance,",
                    "slaphouse,",
                    "modernalternativerock,",
                    "indiepop,",
                    "indierock,",
                    "house,",
                    "conscioushiphop,",
                    "moderncountryrock,",
                    "eastcoasthiphop,",
                    "folkrock,",
                    "metal,",
                    "turkishpop,",
                    "bedroompop,",
                    "desipop,",
                    "italianhiphop,",
                    "hoerspiel,",
                    "afrobeats,",
                    "adultstandards,",
                    "post-teenpop,",
                    "neosoul,",
                    "spedup,",
                    "cloudrap,",
                    "viralpop,",
                    "talentshow,",
                    "spanishpop,",
                    "punk,",
                    "alternativer&b,",
                    "grupera,",
                    "westcoastrap,",
                    "opm,",
                    "boyband,",
                    "psychedelicrock,",
                    "glammetal,",
                    "stompandholler,",
                    "desihiphop,",
                    "ccm,",
                    "ragerap,",
                    "hippop,",
                    "puertoricanpop,",
                    "germanpop,",
                    "miamihiphop,",
                    "argentinerock,",
                    "sertanejopop,",
                    "tropical,",
                    "glamrock,",
                    "funkcarioca,",
                    "nigerianpop,",
                    "argentinehiphop,",
                    "darktrap,",
                    "latinviralpop,",
                    "pianorock,",
                    "detroithiphop,",
                    "italianadultpop,",
                    "countryrock,",
                    "undergroundhiphop,",
                    "mexicanhiphop,",
                    "progressiveelectrohouse,",
                    "synthpop,",
                    "metropopolis,",
                    "garagerock,",
                    "indiefolk,",
                    "vocaljazz,",
                    "classical,",
                    "europop,",
                    "progressivehouse,",
                    "artrock,",
                    "yachtrock,",
                    "mpb,",
                    "pagode,"
                };

                var prompt = $"Você é um assistente musical. Aqui está uma lista de gêneros que você conhece: {genres}.\r\nSempre que um usuário descrever como foi seu dia, pedir um estilo musical e etc, responda com o gênero mais próximo com a descrição mais próximo que contém na lista. RESPONDA COM APENAS UMA PALAVRA E APENAS PALAVRAS QUE ESTEJAM NA LISTA. Pedido do usuário: {userRequest}";

                var chat = new Chat(_ollamaApiClient);

                var fullResponse = string.Empty;

                await foreach (var token in chat.SendAsync(prompt))
                    fullResponse += token;

                return fullResponse;
            }
            catch (Exception ex) 
            {
                return $"{ex.Message}";
            }

        }
    }
}
