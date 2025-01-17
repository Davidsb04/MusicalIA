const API_BASE_URL = 'http://localhost:32770/api';

export const chatService = {
    sendMessage: async (prompt) => {
        try {
            const response = await fetch(`${API_BASE_URL}/Chat/ChatOllama?prompt=${encodeURIComponent(prompt)}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
            });

            if (!response.ok) {
                throw new Error('Erro na resposta do servidor');
            }

            return await response.text();
        } catch (error) {
            console.error('Erro ao enviar mensagem:', error);
            throw error;
        }
    }
};