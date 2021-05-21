export interface FormState {
  // Identyfikator produktu.
  productId: string,
  // Identyfikator komponentu.
  componentId: string,
  // Identyfikator wersji komponentu.
  componentVersionId: string,
}

export interface FormStateValidationResult {
  // Flaga określająca, czy stan formularza jest poprawny.
  isValid: boolean,
  // Stan poszczególnych pól formularza.
  details: {
    // Identyfikator wersji komponentu.
    componentVersionId: string,
  },
}
