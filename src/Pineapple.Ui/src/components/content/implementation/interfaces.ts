export interface DetailsProps {
  // Flaga określająca, czy wdrożenie zostało pobrane z API.
  isDataFetched: boolean,
  // Nazwa.
  name: string,
  // Identyfikator menedżera.
  managerId: string,
  // Imię i nazwisko menedżera.
  managerFullName: string,
  // Opis.
  description: string,
}

export interface ListProps {
  // Flaga określająca, czy lista środowisk została pobrana z API.
  isDataFetched: boolean,
  // Lista środowisk.
  data: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
    // Symbol.
    symbol: string,
    // Identyfikator wdrożeniowca.
    operatorId: string,
    // Imię i nazwisko wdrożeniowca.
    operatorFullName: string,
    // Flaga określająca, czy środowisko zostało usunięte.
    isDeleted: boolean,
    // Flaga określająca, czy dostępne są nowsze wersje zainstalowanych komponentów.
    isUpdateAvailable: boolean,
  }[],
  // Identyfikator wdrożenia.
  implementationId: string,
  // Zdarzenie edycji środowiska.
  onEdit: (id: string) => void,
  // Zdarzenie usunięcia środowiska.
  onDelete: (id: string, name: string) => void,
}
