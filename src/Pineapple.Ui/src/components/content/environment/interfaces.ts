export interface DetailsProps {
  // Flaga określająca, czy środowisko zostało pobrane z API.
  isDataFetched: boolean,
  // Nazwa.
  name: string,
  // Symbol.
  symbol: string,
  // Identyfikator wdrożeniowca.
  operatorId: string,
  // Imię i nazwisko wdrożeniowca.
  operatorFullName: string,
  // Opis.
  description: string,
}

export interface ListProps {
  // Flaga określająca, czy lista serwerów została pobrana z API.
  isDataFetched: boolean,
  // Lista serwerów.
  data: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
    // Symbol.
    symbol: string,
    // Flaga określająca, czy serwer został usunięty.
    isDeleted: boolean,
    // Flaga określająca, czy dostępne są nowsze wersje zainstalowanych komponentów.
    isUpdateAvailable: boolean,
  }[],
  // Identyfikator wdrożenia.
  implementationId: string,
  // Identyfikator środowiska.
  environmentId: string,
  // Zdarzenie edycji serwera.
  onEdit: (id: string) => void,
  // Zdarzenie usunięcia serwera.
  onDelete: (id: string, name: string) => void,
}
