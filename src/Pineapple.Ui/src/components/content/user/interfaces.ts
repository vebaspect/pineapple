export interface DetailsProps {
  // Flaga określająca, czy użytkownik został pobrany z API.
  isDataFetched: boolean,
  // Imię i nazwisko.
  fullName: string,
  // Login.
  login: string,
  // Telefon.
  phone: string,
  // E-mail.
  email: string,
}
