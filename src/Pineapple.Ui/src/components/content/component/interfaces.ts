export interface DetailsProps {
  // Flaga określająca, czy komponent został pobrany z API.
  isDataFetched: boolean,
  // Nazwa.
  name: string,
  // Typ.
  type: string,
  // Opis.
  description: string,
}
