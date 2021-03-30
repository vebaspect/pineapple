export interface UsersProps {
  // Flaga określająca, czy liczba programistów została pobrana z API.
  isDevelopersCountFetched: boolean,
  // Liczba programistów.
  developersCount: number,
  // Flaga określająca, czy liczba wdrożeniowców została pobrana z API.
  isOperatorsCountFetched: boolean,
  // Liczba wdrożeniowców.
  operatorsCount: number,
  // Flaga określająca, czy liczba menedżerów pobrana z API.
  isManagersCountFetched: boolean,
  // Liczba menedżerów.
  managersCount: number,
  // Flaga określająca, czy liczba administratorów została pobrana z API.
  isAdministratorsCountFetched: boolean,
  // Liczba administratorów.
  administratorsCount: number,
}
