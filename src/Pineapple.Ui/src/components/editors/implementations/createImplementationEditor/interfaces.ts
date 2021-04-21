export interface FormState {
  // Nazwa.
  name: string,
  // Opis.
  description: string,
  // Identyfikator menedżera.
  managerId: string,
}

export interface FormStateValidationResult {
  // Flaga określająca, czy stan formularza jest poprawny.
  isValid: boolean,
  // Stan poszczególnych pól formularza.
  details: {
    // Nazwa.
    name: string,
    // Identyfikator menedżera.
    managerId: string,
  },
}
