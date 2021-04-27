export interface DetailsProps {
  // Flaga określająca, czy serwer został pobrany z API.
  isDataFetched: boolean,
  // Nazwa.
  name: string,
  // Symbol.
  symbol: number,
  // Adres IP.
  ipAddress: number,
  // Identyfikator systemu operacyjnego.
  operatingSystemId: string,
  // Nazwa systemu operacyjnego.
  operatingSystemName: string,
  // Opis.
  description: string,
}

export interface InstalledComponentsListProps {
  // Flaga określająca, czy serwer został pobrany z API.
  isDataFetched: boolean,
  // Lista zainstalowanych komponentów.
  data: {
    // Identyfikator komponentu.
    componentId: string,
    // Nazwa komponentu.
    componentName: string,
    // Identyfikator wersji komponentu.
    componentVersionId: string,
    // Numer wersji komponentu.
    componentVersionNumber: string,
  }[],
}
