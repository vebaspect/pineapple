export interface FormState {
  // Nazwa.
  name: string,
  // Symbol.
  symbol: string,
  // Opis.
  description: string,
  // Identyfikator wdrożeniowca.
  operatorId: string,
}

export interface FormStateValidationResult {
  // Flaga określająca, czy stan formularza jest poprawny.
  isValid: boolean,
  // Stan poszczególnych pól formularza.
  details: {
    // Nazwa.
    name: string,
    // Symbol.
    symbol: string,
  },
}
