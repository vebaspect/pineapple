export interface ProductsProps {
  // Flaga określająca, czy drzewo produktów zostało pobrane z API.
  isDataFetched: boolean,
  // Drzewo produktów.
  data: {
    // Węzły reprezentujące produkty.
    products: {
      // Identyfikator.
      id: string,
      // Nazwa.
      name: string,
      // Opis.
      description: string,
      // Flaga określająca, czy produkt został usunięty.
      isDeleted: boolean,
      // Węzły reprezentujące komponenty.
      components: {
        // Identyfikator.
        id: string,
        // Nazwa.
        name: string,
        // Opis.
        description: string,
        // Flaga określająca, czy komponent został usunięty.
        isDeleted: boolean,
      }[],
    }[],
  },
}
