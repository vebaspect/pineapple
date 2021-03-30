export interface ListProps {
  // Flaga określająca, czy lista systemów operacyjnych została pobrana z API.
  isDataFetched: boolean,
  // Lista systemów operacyjnych.
  data: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
    // Symbol.
    symbol: string,
    // Opis.
    description: string,
    // Flaga określająca, czy system operacyjny został usunięty.
    isDeleted: boolean,
  }[],
  // Zdarzenie edycji systemu operacyjnego.
  onEdit: (id: string) => void,
  // Zdarzenie usunięcia systemu operacyjnego.
  onDelete: (id: string) => void,
}
