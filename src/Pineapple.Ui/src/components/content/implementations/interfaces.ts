export interface ListProps {
  // Flaga określająca, czy lista wdrożeń została pobrana z API.
  isDataFetched: boolean,
  // Lista wdrożeń.
  data: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
    // Identyfikator menedżera.
    managerId: string,
    // Imię i nazwisko menedżera.
    managerFullName: string,
    // Flaga określająca, czy wdrożenie zostało usunięte.
    isDeleted: boolean,
  }[],
  // Zdarzenie edycji wdrożenia.
  onEdit: (id: string) => void,
  // Zdarzenie usunięcia wdrożenia.
  onDelete: (id: string, name: string) => void,
}
