export interface ApiFormat {
  // Data wydania.
  releaseDate: string,
  // Major.
  major: number,
  // Minor.
  minor: number,
  // Patch.
  patch: number,
  // Przyrostek.
  suffix: string,
  // Opis.
  description: string,
  // Flaga określająca, czy wersja komponentu jest oznaczona jako "Ważna".
  isImportant: boolean,
}

export interface FormState {
  // Data wydania.
  releaseDate: string,
  // Major.
  major: string,
  // Minor.
  minor: string,
  // Patch.
  patch: string,
  // Przyrostek.
  suffix: string,
  // Opis.
  description: string,
  // Flaga określająca, czy wersja komponentu jest oznaczona jako "Ważna".
  isImportant: boolean,
}

export interface FormStateValidationResult {
  // Flaga określająca, czy stan formularza jest poprawny.
  isValid: boolean,
  // Stan poszczególnych pól formularza.
  details: {
    // Data wydania.
    releaseDate: string,
    // Major.
    major: string,
    // Minor.
    minor: string,
    // Patch.
    patch: string,
  },
}
