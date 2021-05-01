export interface ListProps {
  // Flaga określająca, czy lista administratorów została pobrana z API.
  isDataFetched: boolean,
  // Lista administratorów.
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
    // Flaga określająca, czy administrator został usunięty.
    isDeleted: boolean,
  }[],
  // Zdarzenie edycji administratora.
  onEdit: (id: string) => void,
  // Zdarzenie usunięcia administratora.
  onDelete: (id: string, fullName: string) => void,
}
