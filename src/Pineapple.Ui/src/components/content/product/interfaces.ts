export interface ListProps {
  // Flaga określająca, czy lista komponentów została pobrana z API.
  isDataFetched: boolean,
  // Lista komponentów.
  data: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
    // Opis.
    description: string,
    // Flaga określająca, czy komponent zostało usunięte.
    isDeleted: boolean,
  }[],
  // Zdarzenie edycji komponentu.
  onEdit: (id: string) => void,
  // Zdarzenie usunięcia komponentu.
  onDelete: (id: string) => void,
}