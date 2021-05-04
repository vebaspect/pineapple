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
    // Identyfikator produktu.
    productId: string,
    // Nazwa produktu.
    productName: string,
    // Identyfikator komponentu.
    componentId: string,
    // Nazwa komponentu.
    componentName: string,
    // Identyfikator wersji komponentu.
    componentVersionId: string,
    // Numer wersji komponentu.
    componentVersionNumber: string,
    // Flaga określająca, czy dostępna jest nowsza wersja komponentu.
    isNewerComponentVersionAvailable: boolean,
  }[],
  // Zdarzenie odinstalowania komponentu.
  onUninstall: (id: string, name: string) => void,
}

export interface InstalledSoftwareApplicationsListProps {
  // Flaga określająca, czy serwer został pobrany z API.
  isDataFetched: boolean,
  // Lista zainstalowanego oprogramowania.
  data: {
    // Identyfikator oprogramowania.
    softwareApplicationId: string,
    // Nazwa oprogramowania.
    softwareApplicationName: string,
  }[],
  // Zdarzenie odinstalowania oprogramowania.
  onUninstall: (id: string, name: string) => void,
}
