export interface DetailsProps {
  // Flaga określająca, czy wersja komponentu została pobrana z API.
  isDataFetched: boolean,
  // Rodzaj.
  kind: string,
  // Data wydania.
  releaseDate: string,
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
  // Flaga określająca, czy wersja komponentu jest oznaczona jako "Ważna".
  isImportant: boolean,
}
