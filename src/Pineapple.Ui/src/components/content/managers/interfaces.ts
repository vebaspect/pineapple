export interface ListProps {
  // Flaga określająca, czy lista menedżerów została pobrana z API.
  isDataFetched: boolean,
  // Lista menedżerów.
  data: {
    // Identyfikator.
    id: string,
    // Imię i nazwisko.
    fullName: string,
    // Login.
    login: string,
    // Telefon.
    phone: string,
    // E-mail.
    email: string,
    // Flaga określająca, czy menedżer został usunięty.
    isDeleted: boolean,
  }[],
  // Zdarzenie edycji menedżera.
  onEdit: (id: string) => void,
  // Zdarzenie usunięcia menedżera.
  onDelete: (id: string) => void,
}
