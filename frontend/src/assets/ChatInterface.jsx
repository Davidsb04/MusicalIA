import React, { useState } from 'react';
import { chatService } from '../services/chatService';

const ChatInterface = () => {
  const [message, setMessage] = useState('');
  const [isLoading, setIsLoading] = useState(false);
  const [spotifyLink, setSpotifyLink] = useState('');

  const handleSendMessage = async () => {
    try {
      if (!message.trim()) return;

      setIsLoading(true);
      setSpotifyLink('');

      const response = await chatService.sendMessage(message);
      setSpotifyLink(response);
      setMessage('');

    } catch (error) {
      console.error("Erro ai enviar mensagem: ", error)
    } finally {
      setIsLoading(false);
    }
  }

  return (
    <div className="min-h-screen bg-[#1E1E1E] flex flex-col p-4">
      <div className="absolute top-4 left-4">
        <h2 className="text-white text-xl font-bold">MUSICALIA</h2>
      </div>

      <div className="flex-1 flex items-center justify-center">
        <div className="w-full max-w-3xl space-y-8">
          <h1 className="text-2xl md:text-3xl font-semibold text-white text-center">
            O que você quer ouvir hoje?
          </h1>

          {/* Input de mensagem */}
          <div className="space-y-4">
            <div className="bg-[#2A2A2A] rounded-lg border border-[#383838]">
              <div className="flex items-center p-2">
                <input
                  type="text"
                  value={message}
                  onChange={(e) => setMessage(e.target.value)}
                  onKeyDown={(e) => e.key === 'Enter' && handleSendMessage()}
                  className="flex-1 bg-transparent border-0 outline-none text-white placeholder-gray-500 px-3 py-2"
                  placeholder="Fale com a MusicalIA"
                  disabled={isLoading}
                />
                <button
                  onClick={handleSendMessage}
                  className="p-2 text-gray-400 hover:text-white transition-colors disabled:opacity-50"
                  disabled={isLoading}
                >
                  {isLoading ? (
                    <svg className="animate-spin h-5 w-5" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                      <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle>
                      <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                    </svg>
                  ) : (
                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
                      <line x1="22" y1="2" x2="11" y2="13"></line>
                      <polygon points="22 2 15 22 11 13 2 9 22 2"></polygon>
                    </svg>
                  )}
                </button>
              </div>
            </div>
          </div>

          {/* Área de resposta do Spotify */}
          {spotifyLink && (
            <div className="bg-[#2A2A2A] p-4 rounded-lg border border-[#1DB954] shadow-lg">
              <div className="flex items-center justify-between">
                <div className="flex items-center space-x-2">
                  <svg className="w-6 h-6 text-[#1DB954]" viewBox="0 0 24 24" fill="currentColor">
                    <path d="M12 0C5.4 0 0 5.4 0 12s5.4 12 12 12 12-5.4 12-12S18.66 0 12 0zm5.521 17.34c-.24.359-.66.48-1.021.24-2.82-1.74-6.36-2.101-10.561-1.141-.418.122-.779-.179-.899-.539-.12-.421.18-.78.54-.9 4.56-1.021 8.52-.6 11.64 1.32.42.18.479.659.301 1.02zm1.44-3.3c-.301.42-.841.6-1.262.3-3.239-1.98-8.159-2.58-11.939-1.38-.479.12-1.02-.12-1.14-.6-.12-.48.12-1.021.6-1.141C9.6 9.9 15 10.561 18.72 12.84c.361.181.54.78.241 1.2zm.12-3.36C15.24 8.4 8.82 8.16 5.16 9.301c-.6.179-1.2-.181-1.38-.721-.18-.601.18-1.2.72-1.381 4.26-1.26 11.28-1.02 15.721 1.621.539.3.719 1.02.419 1.56-.299.421-1.02.599-1.559.3z" />
                  </svg>
                  <span className="text-white font-medium">Spotify Link</span>
                </div>
                <a
                  href={spotifyLink}
                  target="_blank"
                  rel="noopener noreferrer"
                  className="bg-[#1DB954] text-white px-4 py-2 rounded-full hover:bg-[#1ed760] transition-colors duration-200 flex items-center space-x-2"
                >
                  <span>Abrir no Spotify</span>
                  <svg xmlns="http://www.w3.org/2000/svg" className="h-4 w-4" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M10 6H6a2 2 0 00-2 2v10a2 2 0 002 2h10a2 2 0 002-2v-4M14 4h6m0 0v6m0-6L10 14" />
                  </svg>
                </a>
              </div>
            </div>
          )}
        </div>
      </div>
    </div>
  );
};

export default ChatInterface;

