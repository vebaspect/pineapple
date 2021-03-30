export interface ListProps {
  // Flaga określająca, czy lista programistów została pobrana z API.
  isDataFetched: boolean,
  // Lista programistów.
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
    // Flaga określająca, czy programista został usunięty.
    isDeleted: boolean,
  }[],
  // Zdarzenie edycji programisty.
  onEdit: (id: string) => void,
  // Zdarzenie usunięcia programisty.
  onDelete: (id: string) => void,
}
