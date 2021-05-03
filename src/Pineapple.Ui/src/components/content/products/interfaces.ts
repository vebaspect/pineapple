export interface ListProps {
  // Flaga określająca, czy lista produktów została pobrana z API.
  isDataFetched: boolean,
  // Lista produktów.
  data: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
    // Flaga określająca, czy produkt został usunięty.
    isDeleted: boolean,
  }[],
  // Zdarzenie edycji produktu.
  onEdit: (id: string) => void,
  // Zdarzenie usunięcia produktu.
  onDelete: (id: string, name: string) => void,
}
