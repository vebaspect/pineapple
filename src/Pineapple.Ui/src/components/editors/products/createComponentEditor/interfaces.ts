export interface FormState {
  // Nazwa.
  name: string,
  // Repozytorium kodu źródłowego (adres URL).
  sourceCodeRepositoryUrl: string,
  // Opis.
  description: string,
  // Identyfikator typu komponentu.
  componentTypeId: string,
}

export interface FormStateValidationResult {
  // Flaga określająca, czy stan formularza jest poprawny.
  isValid: boolean,
  // Stan poszczególnych pól formularza.
  details: {
    // Nazwa.
    name: string,
    // Identyfikator typu komponentu.
    componentTypeId: string,
  },
}
