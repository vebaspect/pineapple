export interface FormState {
  // Nazwa.
  name: string,
  // Symbol.
  symbol: string,
  // Adres IP.
  ipAddress: string,
  // Opis.
  description: string,
  // Identyfikator systemu operacyjnego.
  operatingSystemId: string,
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
    // Adres IP.
    ipAddress: string,
    // Identyfikator systemu operacyjnego.
    operatingSystemId: string,
  },
}
