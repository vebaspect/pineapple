export interface DetailsProps {
  // Flaga określająca, czy środowisko zostało pobrane z API.
  isDataFetched: boolean,
  // Nazwa.
  name: string,
  // Symbol.
  symbol: string,
  // Wdrożeniowiec.
  operator: string,
  // Opis.
  description: string,
}
