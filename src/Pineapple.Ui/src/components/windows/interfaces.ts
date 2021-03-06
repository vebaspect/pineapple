import React from 'react';

export interface DialogWindowProps {
  // Flaga określająca, czy okno jest otwarte.
  isOpen: boolean,
  // Tytuł.
  title: string,
  // Zdarzenie kliknięcia na przycisk "Potwierdź".
  onConfirm: () => void,
  // Zdarzenie kliknięcia na przycisk "Anuluj".
  onCancel: () => void,
  // Treść.
  children: React.ReactNode,
}

export interface ErrorWindowProps {
  // Flaga określająca, czy okno jest otwarte.
  isOpen: boolean,
  // Zdarzenie kliknięcia na przycisk "Zamknij".
  onClose: () => void,
  // Treść.
  children: React.ReactNode,
}
