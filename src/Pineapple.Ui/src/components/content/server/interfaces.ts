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
