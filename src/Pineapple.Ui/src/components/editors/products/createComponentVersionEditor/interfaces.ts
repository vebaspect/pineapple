export interface ApiFormat {
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
}

export interface FormState {
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
}

export interface FormStateValidationResult {
  // Flaga określająca, czy stan formularza jest poprawny.
  isValid: boolean,
  // Stan poszczególnych pól formularza.
  details: {
    // Major.
    major: string,
    // Minor.
    minor: string,
    // Patch.
    patch: string,
  },
}