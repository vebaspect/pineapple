export interface LogsProps {
  // Flaga określająca, czy lista logów została pobrana z API.
  isDataFetched: boolean,
  // Lista logów.
  data: {
    // Identyfikator.
    id: string,
    // Data modyfikacji.
    modifiedDate: Date,
    // Typ.
    type: string,
    // Kategoria.
    category: string,
    // Imię i nazwisko właściciela.
    ownerFullName: string,
    // Nazwa encji.
    entityName: string,
    // Nazwa encji nadrzędnej.
    parentEntityName: string,
    // Opis.
    description: string,
  }[],
}
