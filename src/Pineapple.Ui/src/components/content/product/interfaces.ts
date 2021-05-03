export interface DetailsProps {
  // Flaga określająca, czy produkt został pobrany z API.
  isDataFetched: boolean,
  // Nazwa.
  name: string,
  // Opis.
  description: string,
}

export interface ListProps {
  // Flaga określająca, czy lista komponentów została pobrana z API.
  isDataFetched: boolean,
  // Lista komponentów.
  data: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
    // Identyfikator typu.
    componentTypeId: string,
    // Nazwa typu.
    componentTypeName: string,
    // Flaga określająca, czy komponent został usunięty.
    isDeleted: boolean,
    // Identyfikator aktualnej wersji komponentu.
    actualComponentVersionId: string,
    // Numer aktualnej wersji komponentu.
    actualComponentVersionNumber: string,
  }[],
  // Identyfikator produktu.
  productId: string,
  // Zdarzenie edycji komponentu.
  onEdit: (id: string) => void,
  // Zdarzenie usunięcia komponentu.
  onDelete: (id: string, name: string) => void,
}
