export interface ConfigurationProps {
  // Flaga określająca, czy liczba typów komponentów została pobrana z API.
  isComponentTypesCountFetched: boolean,
  // Liczba typów komponentów.
  componentTypesCount: number,
  // Flaga określająca, czy liczba systemów operacyjnych została pobrana z API.
  isOperatingSystemsCountFetched: boolean,
  // Liczba systemów operacyjnych.
  operatingSystemsCount: number,
  // Flaga określająca, czy liczba oprogramowania została pobrana z API.
  isSoftwareApplicationsCountFetched: boolean,
  // Liczba oprogramowania.
  softwareApplicationsCount: number,
}
