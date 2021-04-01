export interface FormState {
  // Imię i nazwisko.
  fullName: string,
  // Login.
  login: string,
  // Telefon.
  phone: string,
  // E-mail.
  email: string,
}

export interface FormStateValidationResult {
  // Flaga określająca, czy stan formularza jest poprawny.
  isValid: boolean,
  // Stan poszczególnych pól formularza.
  details: {
    // Imię i nazwisko.
    fullName: string,
    // Login.
    login: string,
  },
}
