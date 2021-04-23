export interface DetailsProps {
  // Flaga określająca, czy środowisko zostało pobrane z API.
  isDataFetched: boolean,
  // Nazwa.
  name: string,
  // Symbol.
  symbol: string,
  // Identyfikator wdrożeniowca.
  operatorId: string,
  // Imię i nazwisko wdrożeniowca.
  operatorFullName: string,
  // Opis.
  description: string,
}
