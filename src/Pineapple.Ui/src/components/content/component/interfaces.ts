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

export interface ListProps {
  // Flaga określająca, czy lista wersji komponentu została pobrana z API.
  isDataFetched: boolean,
  // Lista wersji komponentu.
  data: {
    // Identyfikator.
    id: string,
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
    // Flaga określająca, czy wersja komponentu została usunięta.
    isDeleted: boolean,
  }[],
  // Identyfikator produktu.
  productId: string,
  // Identyfikator komponentu.
  componentId: string,
  // Zdarzenie edycji wersji komponentu.
  onEdit: (id: string) => void,
  // Zdarzenie usunięcia wersji komponentu.
  onDelete: (id: string) => void,
}
