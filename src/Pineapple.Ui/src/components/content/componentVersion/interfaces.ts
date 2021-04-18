export interface DetailsProps {
  // Flaga określająca, czy wersja komponentu została pobrana z API.
  isDataFetched: boolean,
  // Major.
  major: number,
  // Minor.
  minor: number,
  // Patch.
  patch: number,
  // Przyrostek.
  suffix: string,
  // Opis.
  description: string,
}
