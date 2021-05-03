export interface ListProps {
  // Flaga określająca, czy lista oprogramowania została pobrana z API.
  isDataFetched: boolean,
  // Lista oprogramowania.
  data: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
    // Symbol.
    symbol: string,
    // Flaga określająca, czy oprogramowanie zostało usunięte.
    isDeleted: boolean,
  }[],
  // Zdarzenie edycji oprogramowania.
  onEdit: (id: string) => void,
  // Zdarzenie usunięcia oprogramowania.
  onDelete: (id: string, name: string) => void,
}
