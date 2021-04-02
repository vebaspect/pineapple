export interface ListProps {
  // Flaga określająca, czy lista środowisk została pobrana z API.
  isDataFetched: boolean,
  // Lista środowisk.
  data: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
    // Opis.
    description: string,
    // Flaga określająca, czy środowisko zostało usunięte.
    isDeleted: boolean,
  }[],
  // Zdarzenie edycji środowiska.
  onEdit: (id: string) => void,
  // Zdarzenie usunięcia środowiska.
  onDelete: (id: string) => void,
}
