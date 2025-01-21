# Musicalia

Musicalia é um projeto de inteligência artificial que sugere playlists do Spotify baseadas no humor descrito pelo usuário. Com uma interface amigável e uma API robusta, Musicalia utiliza a IA **Llama 3.2:latest** da Ollama para interpretar descrições emocionais e recomendar o estilo musical mais adequado.

## Principais Funcionalidades

- **Interpretação de humor:** A IA analisa as descrições do usuário para identificar o gênero musical ideal.
- **Gêneros suportados:** Um conjunto abrangente de estilos musicais, incluindo pop, rock, rap, k-pop, EDM e muitos outros.
- **Recomendações personalizadas:** Gêneros sugeridos com base no humor descrito pelo usuário.

## Requisitos para Execução

1. **Docker:** Certifique-se de ter o Docker instalado.
2. **Imagens do Frontend e Backend:** Execute os containers do frontend (React + Vite) e do backend (.NET) a partir das imagens Docker.
3. **Ollama instalado:** Instale o Ollama em sua máquina host e configure o modelo **Llama 3.2:latest**.

## Como Executar

### Passo 1: Configurar o Backend

- Você pode acessar o Docker Hub e executar as imagens [Backend](https://hub.docker.com/r/davidsb04/musicalia-backend).
   
### Passo 2: Configurar o Frontend

1. Você pode acessar o Docker Hub e executar as imagens [Frontend](https://hub.docker.com/r/davidsb04/musicalia-frontend).

### Passo 3: Configurar o Ollama

1. Instale o Ollama seguindo as instruções em [Ollama](https://ollama.com/).
2. Baixe o modelo Llama 3.2:
   ```bash  
    ollama pull llama3.2-vision:latest
   
3. Certifique-se de que o Ollama esteja em execução:
    ```bash
    ollama serve
### Passo 4: Acessar a Aplicação
1. Acesse o frontend através do navegador no endereço:
    ```bash
   http://localhost:3000
2. Utilize a aplicação para descrever seu humor e obter recomendações musicais personalizadas.
   
## Estrutura do Projeto
- **Frontend:** Desenvolvido com React + Vite.
- **Backend:** Construído em .NET.
- **IA:** Integração com Ollama para utilizar o modelo Llama 3.2.
