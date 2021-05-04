export interface FormState {
  // Identyfikator oprogramowania.
  softwareApplicationId: string,
}

export interface FormStateValidationResult {
  // Flaga określająca, czy stan formularza jest poprawny.
  isValid: boolean,
  // Stan poszczególnych pól formularza.
  details: {
    // Identyfikator oprogramowania.
    softwareApplicationId: string,
  },
}
