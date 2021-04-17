export interface LogsProps {
  // Flaga określająca, czy lista logów została pobrana z API.
  isDataFetched: boolean,
  // Lista logów.
  data: {
    // Identyfikator.
    id: string,
    // Data modyfikacji.
    modificationDate: Date,
    // Typ.
    type: string,
    // Kategoria.
    category: string,
    // Imię i nazwisko właściciela.
    ownerFullName: string,
    // Encja.
    entity: {
      // Nazwa.
      name: string,
    },
    // Encje nadrzędne.
    parentEntities: {
      // Nazwa.
      name: string,
    }[],
    // Opis.
    description: string,
  }[],
}
