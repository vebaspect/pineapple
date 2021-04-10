export interface ApiFormat {
  // Major.
  major: number,
  // Minor.
  minor: number,
  // Patch.
  patch: number,
  // Wydanie przedpremierowe.
  preRelease: string,
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
  // Wydanie przedpremierowe.
  preRelease: string,
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
