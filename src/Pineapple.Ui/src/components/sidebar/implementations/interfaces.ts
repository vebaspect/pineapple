export interface ImplementationsProps {
  // Flaga określająca, czy drzewo wdrożeń zostało pobrane z API.
  isDataFetched: boolean,
  // Drzewo wdrożeń.
  data: {
    // Węzły reprezentujące wdrożenia.
    implementations: {
      // Identyfikator.
      id: string,
      // Nazwa.
      name: string,
      // Opis.
      description: string,
      // Flaga określająca, czy wdrożenie zostało usunięte.
      isDeleted: boolean,
      // Węzły reprezentujące środowiska.
      environments: {
        // Identyfikator.
        id: string,
        // Nazwa.
        name: string,
        // Opis.
        description: string,
        // Flaga określająca, czy środowisko zostało usunięte.
        isDeleted: boolean,
        // Flaga określająca, czy dostępne są nowsze wersje zainstalowanych komponentów.
        isUpdateAvailable: boolean,
      }[],
    }[],
  },
}
