export interface ListProps {
  // Flaga określająca, czy lista typów komponentów została pobrana z API.
  isDataFetched: boolean,
  // Lista typów komponentów.
  data: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
    // Symbol.
    symbol: string,
    // Opis.
    description: string,
    // Flaga określająca, czy typ komponentu został usunięty.
    isDeleted: boolean,
  }[],
  // Zdarzenie edycji typu komponentu.
  onEdit: (id: string) => void,
  // Zdarzenie usunięcia typu komponentu.
  onDelete: (id: string) => void,
}
