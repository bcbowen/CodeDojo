declare global {
  interface Window {
    google: Google;
    supportAI: { version: string, enableAutoReply() : void}
  }
}

interface Google {
  accounts: {
    id: {
      renderButton: (
        a: HTMLElement,
        b: {
          type?: string;
          theme?: string;
          size?: string;
          text?: string;
          shape?: string;
          width?: number;
        },
      ) => void;
      prompt: () => void;
      cancel: () => void;
      initialize: ({ client_id: string, callback }) => void;
      disableAutoSelect: () => void;
      revoke: (client_id: string, callback) => void;
    };
  };
}

export {};