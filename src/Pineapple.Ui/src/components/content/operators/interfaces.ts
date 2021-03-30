export interface ListProps {
  // Flaga określająca, czy lista wdrożeniowców została pobrana z API.
  isDataFetched: boolean,
  // Lista wdrożeniowców.
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
    // Flaga określająca, czy wdrożeniowiec został usunięty.
    isDeleted: boolean,
  }[],
  // Zdarzenie edycji wdrożeniowca.
  onEdit: (id: string) => void,
  // Zdarzenie usunięcia wdrożeniowca.
  onDelete: (id: string) => void,
}
